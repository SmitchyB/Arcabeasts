using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;

namespace Arcabeasts.Combat
{
    public static class EffectManager
    {
        //Add an effect to the target Arcabeast instance
        public static void AddEffect(ArcabeastInstance target, ActiveEffect effect)
        {
            if (!effect.IsStackable) // Check for non-stackable duplication BEFORE modifying anything
            {
                var existing = target.ActiveEffects.Find(e => e.Id == effect.Id && !e.IsExpired); // Find existing non-stackable effect by ID
                if (existing != null) // If found, prevent reapplying
                {
                    return;
                }
            }
            effect.RemainingTurns = effect.Duration; // Reset remaining turns to full duration
            if (effect is StatBuffEffect buff) // Handle stat buffs
            {
                int baseValue = GetBaseStat(target, buff.TargetStat); // Get the base stat value
                buff.AmountAdded = (int)(baseValue * buff.BuffPercentage); // Calculate the amount to add based on percentage
                ApplyBuff(target, buff.TargetStat, buff.AmountAdded); // Apply the buff to the target's temporary stats
            }
            target.ActiveEffects.Add(effect); // Add the effect to the target's active effects list
        }
        // Process all active effects on the target Arcabeast instance
        public static void ProcessEffects(ArcabeastInstance target, BattleContext context)
        {
            for (int i = target.ActiveEffects.Count - 1; i >= 0; i--) // Iterate through effects in reverse order
            {
                var effect = target.ActiveEffects[i]; // Get the current effect
                if (effect is BurnEffect burn) // Handle burn effects
                {
                    int dmg = (int)(target.CurrentHP * burn.DamagePerTurn); // Calculate damage based on current HP
                    ApplyDamage(target, dmg); // Apply the damage to the target
                    context?.Log?.Invoke($"{target.DisplayName} is hurt by burn for {dmg} damage ({burn.DamagePerTurn:P0} of current HP)."); // Log the burn damage
                }
                else if (effect is PoisonEffect poison) // Handle poison effects
                {
                    int dmg = (int)(target.CurrentHP * poison.DamagePerTurn); // Calculate damage based on current HP
                    ApplyDamage(target, dmg); // Apply the damage to the target
                    context?.Log?.Invoke($"{target.DisplayName} is hurt by poison for {dmg} damage ({poison.DamagePerTurn:P0} of current HP)."); // Log the poison damage
                }
                else if (effect is ShockEffect shock) // Handle shock effects
                {
                    int dmg = (int)(target.CurrentHP * shock.DamagePerTurn); // Calculate damage based on current HP
                    ApplyDamage(target, dmg); // Apply the damage to the target
                    context?.Log?.Invoke($"{target.DisplayName} is hurt by shock for {dmg} damage ({shock.DamagePerTurn:P0} of current HP)."); // Log the shock damage
                    if (RandomChance(shock.StunChance)) // Check if the target is stunned
                    {
                        target.IsStunned = true; // Set the stunned state
                        context?.Log?.Invoke($"{target.DisplayName} is stunned! ({shock.StunChance:P0} chance)"); // Log the stun
                    }
                }
                else if (effect is DampenEffect dampen) // Handle dampen effects
                {
                    int drain = (int)(target.MaxMana * dampen.ManaDrain); // Calculate mana drain based on max mana
                    int oldMana = target.CurrentMana; // Store the old mana value
                    target.CurrentMana = Math.Max(0, oldMana - drain); // Apply the mana drain, ensuring it doesn't go below 0
                    context?.Log?.Invoke($"{target.DisplayName}'s mana drained by {drain} ({dampen.ManaDrain:P0} of max mana)."); // Log the mana drain
                }
                else if (effect is GuardBreakEffect guard) // Handle guard break effects
                {
                    int basePhys = target.PhysicalDefense; // Get the base physical defense
                    int baseArc = target.ArcaneDefense; // Get the base arcane defense
                    int physDown = (int)(basePhys * guard.DefenseReduction); // Calculate physical defense reduction
                    int arcDown = (int)(baseArc * guard.DefenseReduction); // Calculate arcane defense reduction
                    target.TempPhysicalDefense -= physDown; // Apply the physical defense reduction
                    target.TempArcaneDefense -= arcDown; // Apply the arcane defense reduction
                    guard.AmountPhysicalReduced = physDown; // Store the amount reduced for logging
                    guard.AmountArcaneReduced = arcDown; // Store the amount reduced for logging
                    context?.Log?.Invoke($"{target.DisplayName}'s defenses dropped by {guard.DefenseReduction:P0}: -{physDown} Phys, -{arcDown} Arc."); // Log the guard break effect
                }
                else if (effect is EvasionBoostEffect evasion) // Handle evasion boost effects
                {
                    int baseEvade = target.Evasiveness; // Get the base evasiveness
                    int boost = (int)(baseEvade * evasion.EvasionIncrease); // Calculate the boost based on the increase percentage
                    target.TempEvasiveness += boost; // Apply the boost to the target's temporary evasiveness
                    evasion.AmountAdded = boost; // Store the amount added for logging
                    context?.Log?.Invoke($"{target.DisplayName}'s evasiveness rose by {boost} ({evasion.EvasionIncrease:P0} of base {baseEvade})."); // Log the evasion boost
                }
                effect.RemainingTurns--; // Decrease the remaining turns for the effect
                if (effect.IsExpired) // Check if the effect has expired
                {
                    if (effect is StatBuffEffect buff) // Hanlde stat buff effects expiring
                    {
                        RemoveBuff(target, buff.TargetStat, buff.AmountAdded); // Remove the buff from the target's temporary stats
                        context?.Log?.Invoke($"{target.DisplayName}'s {buff.TargetStat} buff faded. (-{buff.AmountAdded})"); // Log the buff fade
                    }
                    else if (effect is GuardBreakEffect gb) // Handle guard break effects expiring
                    {
                        target.TempPhysicalDefense += gb.AmountPhysicalReduced; // Restore the physical defense
                        target.TempArcaneDefense += gb.AmountArcaneReduced; // Restore the arcane defense
                        context?.Log?.Invoke($"{target.DisplayName}'s defenses recovered: +{gb.AmountPhysicalReduced} Phys, +{gb.AmountArcaneReduced} Arc."); // Log the guard break recovery
                    }
                    else if (effect is EvasionBoostEffect ev) // Handle evasion boost effects expiring
                    {
                        target.TempEvasiveness -= ev.AmountAdded; // Remove the evasion boost from the target's temporary evasiveness
                        context?.Log?.Invoke($"{target.DisplayName}'s evasiveness boost faded. (-{ev.AmountAdded})"); // Log the evasion boost fade
                    }
                    target.ActiveEffects.RemoveAt(i); // Remove the expired effect from the active effects list
                }
            }
        }
        // Get the base stat value for a given stat name
        private static int GetBaseStat(ArcabeastInstance beast, string stat)
        {
            switch (stat) // Match the stat name to the corresponding property
            {
                case "Speed": return beast.Speed; // Return the base speed
                case "PhysicalPower": return beast.PhysicalPower; // Return the base physical power
                case "ArcanePower": return beast.ArcanePower; // Return the base arcane power
                case "PhysicalDefense": return beast.PhysicalDefense; // Return the base physical defense
                case "ArcaneDefense": return beast.ArcaneDefense; // Return the base arcane defense
                case "Evasiveness": return beast.Evasiveness; // Return the base evasiveness
                default: return 0; // If the stat name doesn't match any known stat, return 0
            }
        }
        // Apply a buff to the target Arcabeast instance's temporary stats
        private static void ApplyBuff(ArcabeastInstance beast, string stat, int amount)
        {
            switch (stat) // Match the stat name to the corresponding temporary property
            {
                case "Speed": beast.TempSpeed += amount; break; // Apply the buff to temporary speed
                case "PhysicalPower": beast.TempPhysicalPower += amount; break; // Apply the buff to temporary physical power
                case "ArcanePower": beast.TempArcanePower += amount; break; // Apply the buff to temporary arcane power
                case "PhysicalDefense": beast.TempPhysicalDefense += amount; break; // Apply the buff to temporary physical defense
                case "ArcaneDefense": beast.TempArcaneDefense += amount; break; // Apply the buff to temporary arcane defense
                case "Evasiveness": beast.TempEvasiveness += amount; break; // Apply the buff to temporary evasiveness
            }
        }
        // Remove a buff from the target Arcabeast instance's temporary stats
        private static void RemoveBuff(ArcabeastInstance beast, string stat, int amount)
        {
            switch (stat) // Match the stat name to the corresponding temporary property
            {
                case "Speed": beast.TempSpeed -= amount; break; // Remove the buff from temporary speed
                case "PhysicalPower": beast.TempPhysicalPower -= amount; break; // Remove the buff from temporary physical power
                case "ArcanePower": beast.TempArcanePower -= amount; break; // Remove the buff from temporary arcane power
                case "PhysicalDefense": beast.TempPhysicalDefense -= amount; break; // Remove the buff from temporary physical defense
                case "ArcaneDefense": beast.TempArcaneDefense -= amount; break; // Remove the buff from temporary arcane defense
                case "Evasiveness": beast.TempEvasiveness -= amount; break; // Remove the buff from temporary evasiveness
            }
        }
        // Trigger the passive ability effects based on the defender's type and the attacker's type
        public static void TriggerTypePassive(ArcabeastInstance defender, ArcabeastInstance attacker, BattleContext context)
        {
            if (defender is FireArcabeastInst fire && attacker.GetType() != typeof(FireArcabeastInst)) // Check if defender is Fire type and attacker is not
            {
                if (RandomChance(fire.BurnChance)) // Check if the burn effect should trigger
                {
                    var burn = new BurnEffect // Create a new burn effect
                    {
                        Id = fire.PassiveAbilityId, // Set the effect ID
                        Duration = fire.BurnDuration, // Set the effect duration
                        RemainingTurns = fire.BurnDuration, // Set the remaining turns to full duration
                        DamagePerTurn = fire.BurnDamage, // Set the damage per turn
                        IsStackable = fire.IsStackable // Set whether the effect is stackable
                    };
                    AddEffect(attacker, burn); // Add the burn effect to the attacker
                    context?.Log?.Invoke($"{attacker.DisplayName} was burned by {defender.DisplayName}'s passive! ({fire.BurnChance:P0} chance, {fire.BurnDamage:P0} per turn for {fire.BurnDuration} turns)"); // Log the burn effect
                }
            }
            else if (defender is GrassArcabeastInst grass && attacker.GetType() != typeof(GrassArcabeastInst)) // Check if defender is Grass type and attacker is not
            {
                if (RandomChance(grass.PoisonChance)) // Check if the poison effect should trigger
                {
                    var poison = new PoisonEffect // Create a new poison effect
                    {
                        Id = grass.PassiveAbilityId, // Set the effect ID
                        Duration = grass.PoisonDuration, // Set the effect duration
                        RemainingTurns = grass.PoisonDuration, // Set the remaining turns to full duration
                        DamagePerTurn = grass.PoisonDamage, // Set the damage per turn
                        IsStackable = grass.IsStackable // Set whether the effect is stackable
                    };
                    AddEffect(attacker, poison); // Add the poison effect to the attacker
                    context?.Log?.Invoke($"{attacker.DisplayName} was poisoned by {defender.DisplayName}'s passive! ({grass.PoisonChance:P0} chance, {grass.PoisonDamage:P0} per turn for {grass.PoisonDuration} turns)"); // Log the poison effect
                }
            }
            else if (defender is ElectricArcabeastInst elec && attacker.GetType() != typeof(ElectricArcabeastInst)) // Check if defender is Electric type and attacker is not
            {
                if (RandomChance(elec.ShockStunChance)) // Check if the shock effect should trigger
                {
                    var shock = new ShockEffect // Create a new shock effect
                    {
                        Id = elec.PassiveAbilityId, // Set the effect ID
                        Duration = elec.ShockStunDuration, // Set the effect duration
                        RemainingTurns = elec.ShockStunDuration, // Set the remaining turns to full duration
                        DamagePerTurn = elec.ShockDamagePerTurn, // Set the damage per turn
                        StunChance = elec.ShockStunChance, // Set the stun chance
                        IsStackable = elec.IsStackable // Set whether the effect is stackable
                    };
                    AddEffect(attacker, shock); // Add the shock effect to the attacker
                    context?.Log?.Invoke($"{attacker.DisplayName} was shocked by {defender.DisplayName}'s passive! ({elec.ShockStunChance:P0} stun chance, {elec.ShockDamagePerTurn:P0} dmg/turn for {elec.ShockStunDuration} turns)"); // Log the shock effect
                }
            }
            else if (defender is WaterArcabeastInst water && attacker.GetType() != typeof(WaterArcabeastInst)) // Check if defender is Water type and attacker is not
            { 
                if (RandomChance(water.DampenChance)) // Check if the dampen effect should trigger
                {
                    var damp = new DampenEffect // Create a new dampen effect
                    { 
                        Id = water.PassiveAbilityId, // Set the effect ID
                        Duration = 1, // Set the effect duration to 1 turn
                        RemainingTurns = 1, // Set the remaining turns to 1
                        ManaDrain = water.DampenManaDrain, // Set the mana drain percentage
                        IsStackable = water.IStackable // Set whether the effect is stackable
                    };
                    AddEffect(attacker, damp); // Add the dampen effect to the attacker
                    context?.Log?.Invoke($"{attacker.DisplayName}'s mana was sapped by {defender.DisplayName}'s passive! ({water.DampenManaDrain:P0} of max mana)"); // Log the dampen effect
                }
            }
            else if (defender is RockArcabeastInst rock && attacker.GetType() != typeof(RockArcabeastInst)) // Check if defender is Rock type and attacker is not
            {
                if (RandomChance(rock.GuardBreakChance)) // Check if the guard break effect should trigger
                {
                    var debuff = new GuardBreakEffect // Create a new guard break effect
                    {
                        Id = rock.PassiveAbilityId, // Set the effect ID
                        Duration = rock.GuardBreakDuration, // Set the effect duration
                        RemainingTurns = rock.GuardBreakDuration, // Set the remaining turns to full duration
                        DefenseReduction = rock.GuardBreakAmount, // Set the defense reduction percentage
                        IsStackable = rock.IsStackable // Set whether the effect is stackable
                    };
                    AddEffect(attacker, debuff); // Add the guard break effect to the attacker
                    context?.Log?.Invoke($"{attacker.DisplayName}'s defenses were reduced by {defender.DisplayName}'s passive! (-{rock.GuardBreakAmount:P0} Phys & Arcane Def for 2 turns)"); // Log the guard break effect
                }
            }
            else if (defender is AirArcabeastInst air && attacker.GetType() != typeof(AirArcabeastInst)) // Check if defender is Air type and attacker is not
            {
                if (RandomChance(air.EvasionBoostChance)) // Check if the evasion boost effect should trigger
                {
                    var boost = new EvasionBoostEffect // Create a new evasion boost effect
                    {
                        Id = air.PassiveAbilityId, // Set the effect ID
                        Duration = air.EvasionBoostDuration, // Set the effect duration
                        RemainingTurns = air.EvasionBoostDuration, // Set the remaining turns to full duration
                        EvasionIncrease = air.EvasionBoostAmount, // Set the evasion increase percentage
                        IsStackable = air.IsStackable // Set whether the effect is stackable
                    };
                    AddEffect(defender, boost); // Add the evasion boost effect to the defender
                    context?.Log?.Invoke($"{defender.DisplayName}'s evasiveness rose by {air.EvasionBoostAmount:P0} due to its passive! ({air.EvasionBoostDuration} turn boost)"); // Log the evasion boost effect
                }
            }
        }
        // Check if a random chance occurs based on the given percentage
        private static bool RandomChance(double chance)
        {
            return new Random().NextDouble() < chance; // Generate a random double and compare it to the chance
        }
        // Apply damage to the target Arcabeast instance, ensuring HP does not go below 0
        private static void ApplyDamage(ArcabeastInstance target, int damage)
        {
            target.CurrentHP = Math.Max(0, target.CurrentHP - damage); // Subtract the damage from current HP, ensuring it doesn't go below 0
        }
    }
}
