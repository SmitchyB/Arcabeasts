using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;

namespace Arcabeasts.Combat
{
    public static class EffectManager
    {
        public static void AddEffect(ArcabeastInstance target, ActiveEffect effect)
        {
            // Check for non-stackable duplication BEFORE modifying anything
            if (!effect.IsStackable)
            {
                var existing = target.ActiveEffects.Find(e => e.Id == effect.Id && !e.IsExpired);
                if (existing != null)
                {
                    // ⛔ Prevent reapplying and resetting duration
                    BattleContext.Current?.Log?.Invoke($"[EffectManager] Prevented duplicate non-stackable: {effect.GetType().Name}");
                    return;
                }
            }

            // Only set duration + add effect if allowed
            effect.RemainingTurns = effect.Duration;

            if (effect is StatBuffEffect buff)
            {
                int baseValue = GetBaseStat(target, buff.TargetStat);
                buff.AmountAdded = (int)(baseValue * buff.BuffPercentage);
                ApplyBuff(target, buff.TargetStat, buff.AmountAdded);
            }

            target.ActiveEffects.Add(effect);
        }


        public static void ProcessEffects(ArcabeastInstance target, BattleContext context)
        {
            for (int i = target.ActiveEffects.Count - 1; i >= 0; i--)
            {
                var effect = target.ActiveEffects[i];

                if (effect is BurnEffect burn)
                {
                    int dmg = (int)(target.CurrentHP * burn.DamagePerTurn);
                    ApplyDamage(target, dmg);
                    context?.Log?.Invoke($"{target.DisplayName} is hurt by burn for {dmg} damage ({burn.DamagePerTurn:P0} of current HP).");
                }
                else if (effect is PoisonEffect poison)
                {
                    int dmg = (int)(target.CurrentHP * poison.DamagePerTurn);
                    ApplyDamage(target, dmg);
                    context?.Log?.Invoke($"{target.DisplayName} is hurt by poison for {dmg} damage ({poison.DamagePerTurn:P0} of current HP).");
                }
                else if (effect is ShockEffect shock)
                {
                    int dmg = (int)(target.CurrentHP * shock.DamagePerTurn);
                    ApplyDamage(target, dmg);
                    context?.Log?.Invoke($"{target.DisplayName} is hurt by shock for {dmg} damage ({shock.DamagePerTurn:P0} of current HP).");

                    if (RandomChance(shock.StunChance))
                    {
                        target.IsStunned = true;
                        context?.Log?.Invoke($"{target.DisplayName} is stunned! ({shock.StunChance:P0} chance)");
                    }
                }
                else if (effect is DampenEffect dampen)
                {
                    int drain = (int)(target.MaxMana * dampen.ManaDrain);
                    int oldMana = target.CurrentMana;
                    target.CurrentMana = Math.Max(0, oldMana - drain);
                    context?.Log?.Invoke($"{target.DisplayName}'s mana drained by {drain} ({dampen.ManaDrain:P0} of max mana).");
                }
                else if (effect is GuardBreakEffect guard)
                {
                    int basePhys = target.PhysicalDefense;
                    int baseArc = target.ArcaneDefense;

                    int physDown = (int)(basePhys * guard.DefenseReduction);
                    int arcDown = (int)(baseArc * guard.DefenseReduction);

                    target.TempPhysicalDefense -= physDown;
                    target.TempArcaneDefense -= arcDown;

                    guard.AmountPhysicalReduced = physDown;
                    guard.AmountArcaneReduced = arcDown;

                    context?.Log?.Invoke($"{target.DisplayName}'s defenses dropped by {guard.DefenseReduction:P0}: -{physDown} Phys, -{arcDown} Arc.");
                }
                else if (effect is EvasionBoostEffect evasion)
                {
                    int baseEvade = target.Evasiveness;
                    int boost = (int)(baseEvade * evasion.EvasionIncrease);

                    target.TempEvasiveness += boost;
                    evasion.AmountAdded = boost;

                    context?.Log?.Invoke($"{target.DisplayName}'s evasiveness rose by {boost} ({evasion.EvasionIncrease:P0} of base {baseEvade}).");
                }

                effect.RemainingTurns--;

                if (effect.IsExpired)
                {
                    if (effect is StatBuffEffect buff)
                    {
                        RemoveBuff(target, buff.TargetStat, buff.AmountAdded);
                        context?.Log?.Invoke($"{target.DisplayName}'s {buff.TargetStat} buff faded. (-{buff.AmountAdded})");
                    }
                    else if (effect is GuardBreakEffect gb)
                    {
                        target.TempPhysicalDefense += gb.AmountPhysicalReduced;
                        target.TempArcaneDefense += gb.AmountArcaneReduced;
                        context?.Log?.Invoke($"{target.DisplayName}'s defenses recovered: +{gb.AmountPhysicalReduced} Phys, +{gb.AmountArcaneReduced} Arc.");
                    }
                    else if (effect is EvasionBoostEffect ev)
                    {
                        target.TempEvasiveness -= ev.AmountAdded;
                        context?.Log?.Invoke($"{target.DisplayName}'s evasiveness boost faded. (-{ev.AmountAdded})");
                    }

                    target.ActiveEffects.RemoveAt(i);
                }
            }
        }


        private static int GetBaseStat(ArcabeastInstance beast, string stat)
        {
            switch (stat)
            {
                case "Speed": return beast.Speed;
                case "PhysicalPower": return beast.PhysicalPower;
                case "ArcanePower": return beast.ArcanePower;
                case "PhysicalDefense": return beast.PhysicalDefense;
                case "ArcaneDefense": return beast.ArcaneDefense;
                case "Evasiveness": return beast.Evasiveness;
                default: return 0;
            }
        }

        private static void ApplyBuff(ArcabeastInstance beast, string stat, int amount)
        {
            switch (stat)
            {
                case "Speed": beast.TempSpeed += amount; break;
                case "PhysicalPower": beast.TempPhysicalPower += amount; break;
                case "ArcanePower": beast.TempArcanePower += amount; break;
                case "PhysicalDefense": beast.TempPhysicalDefense += amount; break;
                case "ArcaneDefense": beast.TempArcaneDefense += amount; break;
                case "Evasiveness": beast.TempEvasiveness += amount; break;
            }
        }

        private static void RemoveBuff(ArcabeastInstance beast, string stat, int amount)
        {
            switch (stat)
            {
                case "Speed": beast.TempSpeed -= amount; break;
                case "PhysicalPower": beast.TempPhysicalPower -= amount; break;
                case "ArcanePower": beast.TempArcanePower -= amount; break;
                case "PhysicalDefense": beast.TempPhysicalDefense -= amount; break;
                case "ArcaneDefense": beast.TempArcaneDefense -= amount; break;
                case "Evasiveness": beast.TempEvasiveness -= amount; break;
            }
        }
        public static void TriggerTypePassive(ArcabeastInstance defender, ArcabeastInstance attacker, BattleContext context)
        {
            if (defender is FireArcabeastInst fire && attacker.GetType() != typeof(FireArcabeastInst))
            {
                if (RandomChance(fire.BurnChance))
                {
                    var burn = new BurnEffect
                    {
                        Id = fire.PassiveAbilityId,
                        Duration = fire.BurnDuration,
                        RemainingTurns = fire.BurnDuration,
                        DamagePerTurn = fire.BurnDamage,
                        IsStackable = fire.IsStackable
                    };
                    AddEffect(attacker, burn);
                    context?.Log?.Invoke($"{attacker.DisplayName} was burned by {defender.DisplayName}'s passive! ({fire.BurnChance:P0} chance, {fire.BurnDamage:P0} per turn for {fire.BurnDuration} turns)");
                }
            }
            else if (defender is GrassArcabeastInst grass && attacker.GetType() != typeof(GrassArcabeastInst))
            {
                if (RandomChance(grass.PoisonChance))
                {
                    var poison = new PoisonEffect
                    {
                        Id = grass.PassiveAbilityId,
                        Duration = grass.PoisonDuration,
                        RemainingTurns = grass.PoisonDuration,
                        DamagePerTurn = grass.PoisonDamage,
                        IsStackable = grass.IsStackable
                    };
                    AddEffect(attacker, poison);
                    context?.Log?.Invoke($"{attacker.DisplayName} was poisoned by {defender.DisplayName}'s passive! ({grass.PoisonChance:P0} chance, {grass.PoisonDamage:P0} per turn for {grass.PoisonDuration} turns)");
                }
            }
            else if (defender is ElectricArcabeastInst elec && attacker.GetType() != typeof(ElectricArcabeastInst))
            {
                if (RandomChance(elec.ShockStunChance))
                {
                    var shock = new ShockEffect
                    {
                        Id = elec.PassiveAbilityId,
                        Duration = elec.ShockStunDuration,
                        RemainingTurns = elec.ShockStunDuration,
                        DamagePerTurn = elec.ShockDamagePerTurn,
                        StunChance = elec.ShockStunChance,
                        IsStackable = elec.IsStackable
                    };
                    AddEffect(attacker, shock);
                    context?.Log?.Invoke($"{attacker.DisplayName} was shocked by {defender.DisplayName}'s passive! ({elec.ShockStunChance:P0} stun chance, {elec.ShockDamagePerTurn:P0} dmg/turn for {elec.ShockStunDuration} turns)");
                }
            }
            else if (defender is WaterArcabeastInst water && attacker.GetType() != typeof(WaterArcabeastInst))
            {
                if (RandomChance(water.DampenChance))
                {
                    var damp = new DampenEffect
                    {
                        Id = water.PassiveAbilityId,
                        Duration = 1,
                        RemainingTurns = 1,
                        ManaDrain = water.DampenManaDrain,
                        IsStackable = water.IStackable
                    };
                    AddEffect(attacker, damp);
                    context?.Log?.Invoke($"{attacker.DisplayName}'s mana was sapped by {defender.DisplayName}'s passive! ({water.DampenManaDrain:P0} of max mana)");
                }
            }
            else if (defender is RockArcabeastInst rock && attacker.GetType() != typeof(RockArcabeastInst))
            {
                if (RandomChance(rock.GuardBreakChance))
                {
                    var debuff = new GuardBreakEffect
                    {
                        Id = rock.PassiveAbilityId,
                        Duration = 2,
                        RemainingTurns = 2,
                        DefenseReduction = rock.GuardBreakAmount,
                        IsStackable = rock.IsStackable
                    };
                    AddEffect(attacker, debuff);
                    context?.Log?.Invoke($"{attacker.DisplayName}'s defenses were reduced by {defender.DisplayName}'s passive! (-{rock.GuardBreakAmount:P0} Phys & Arcane Def for 2 turns)");
                }
            }
            else if (defender is AirArcabeastInst air && attacker.GetType() != typeof(AirArcabeastInst))
            {
                if (RandomChance(air.EvasionBoostChance))
                {
                    var boost = new EvasionBoostEffect
                    {
                        Id = air.PassiveAbilityId,
                        Duration = air.EvasionBoostDuration,
                        RemainingTurns = air.EvasionBoostDuration,
                        EvasionIncrease = air.EvasionBoostAmount,
                        IsStackable = air.IsStackable
                    };
                    AddEffect(defender, boost);
                    context?.Log?.Invoke($"{defender.DisplayName}'s evasiveness rose by {air.EvasionBoostAmount:P0} due to its passive! ({air.EvasionBoostDuration} turn boost)");
                }
            }
        }


        private static bool RandomChance(double chance)
        {
            return new Random().NextDouble() < chance;
        }
        private static void ApplyDamage(ArcabeastInstance target, int damage)
        {
            target.CurrentHP = Math.Max(0, target.CurrentHP - damage);
        }


    }
}
