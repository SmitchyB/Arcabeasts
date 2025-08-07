using Arcabeasts.GameData;
using Arcabeasts.GameData.Arcabeasts.GameData;
using System;
using System.Linq;

namespace Arcabeasts.Combat
{
    internal static class UseAbility
    {
        private static readonly Random _rng = new Random();

        public static bool Execute(
            ArcabeastInstance user,
            ArcabeastInstance target,
            ArcabeastAbility ability,
            Action<string> logCallback = null)
        {
            if (ability != null && ability.Name == "Rest")
            {
                int before = user.CurrentMana;
                int regenAmount = user.ManaRegen;
                user.CurrentMana = Math.Min(user.CurrentMana + regenAmount, user.MaxMana);
                int recovered = user.CurrentMana - before;

                logCallback?.Invoke($"{user.DisplayName} is resting. Recovered {recovered} mana.");
                return true;
            }

            if (ability is DefensiveAbility def)
            {
                bool alreadyApplied = user.ActiveEffects.Any(e => e.Id == ability.Id);
                bool success = def.CanStack || !alreadyApplied;

                user.CurrentMana -= def.ManaCost;

                if (success)
                {
                    logCallback?.Invoke($"{user.DisplayName} used {def.Name}. {def.TargetStat} was raised!");
                    var simulatedEffect = new StatBuffEffect
                    {
                        Id = def.Id,
                        Duration = def.Duration,
                        RemainingTurns = def.Duration,
                        BuffPercentage = def.BuffPercentage,
                        TargetStat = def.TargetStat,
                        IsStackable = def.CanStack
                    };
                    EffectManager.AddEffect(user, simulatedEffect);
                }
                else
                {
                    logCallback?.Invoke($"{user.DisplayName} used {def.Name}, but it had no effect!");
                }

                return success;
            }

            if (ability is OffensiveAbility off)
            {
                double accuracy = off.Accuracy;
                double evasivenessPenalty = target.Evasiveness * 0.01;
                double variance = _rng.NextDouble() * 0.24 + 0.01;
                double hitChance = Math.Min(Math.Max(accuracy - evasivenessPenalty + variance, 0), 1);

                double roll = _rng.NextDouble();
                bool isHit = roll <= hitChance;

                user.CurrentMana -= off.ManaCost;

                if (!isHit)
                {
                    logCallback?.Invoke($"{user.DisplayName} used {off.Name} and missed {target.DisplayName}!");
                    return false;
                }

                int damage = CalculateDamage(user, target, off, out double multiplier, out string type);
                ApplyDamage(target, damage);
                if (off.Class == AbilityClass.Physical)
                {
                    EffectManager.TriggerTypePassive(target, user, BattleContext.Current);
                }
                string extra = null;
                if (multiplier == 2.0)
                    extra = "It was super effective!";
                else if (multiplier == 1.5)
                    extra = "It was very effective!";
                else if (multiplier == 0.5)
                    extra = "It was not very effective!";

                string classType = off.Class == AbilityClass.Physical ? "Physical" : "Arcane";
                string logMsg = $"{user.DisplayName} used {off.Name} and hit {target.DisplayName} for {damage} {type} ({classType}) damage!";

                if (extra != null)
                    logMsg += $" {extra}";

                logCallback?.Invoke(logMsg);
                return true;
            }

            return false;
        }

        private static int CalculateDamage(
            ArcabeastInstance user,
            ArcabeastInstance target,
            OffensiveAbility ability,
            out double multiplier,
            out string type)
        {
            bool isPhysical = ability.Class == AbilityClass.Physical;

            int attackerPower = isPhysical ? user.PhysicalPower + user.TempPhysicalPower
                                           : user.ArcanePower + user.TempArcanePower;
            int defenderDefense = isPhysical ? target.PhysicalDefense + target.TempPhysicalDefense
                                             : target.ArcaneDefense + target.TempArcaneDefense;

            multiplier = target.DamageMultipliers.TryGetValue(ability.Type, out double mult) ? mult : 1.0;
            type = ability.Type;

            double variance = _rng.NextDouble() * 4 - 2; // ±2 variance
            double rawDamage = ((double)attackerPower * ability.BasePower) / defenderDefense;
            double finalDamage = rawDamage * multiplier + variance;

            return Math.Max(1, (int)Math.Round(finalDamage));
        }

        private static void ApplyDamage(ArcabeastInstance target, int amount)
        {
            target.CurrentHP = Math.Max(0, target.CurrentHP - amount);
        }
    }
}

