using Arcabeasts.GameData;
using Arcabeasts.GameData.Arcabeasts.GameData;
using System;
using System.Linq;

namespace Arcabeasts.Combat
{
    // Logic for executing abilities in combat
    internal static class UseAbility
    {
        private static readonly Random _rng = new Random(); // Random instance for damage calculation
        public static bool Execute(
            ArcabeastInstance user, // The Arcabeast using the ability
            ArcabeastInstance target, // The target Arcabeast
            ArcabeastAbility ability, // The ability being used
            Action<string> logCallback = null) // Callback for logging messages
        {
            if (ability != null && ability.Name == "Rest") //Special case for the Rest ability needs to run before any other checks to avoid it being classified a Defensive ability
            {
                int before = user.CurrentMana; // Store mana before resting
                int regenAmount = user.ManaRegen; // Amount of mana to regenerate
                user.CurrentMana = Math.Min(user.CurrentMana + regenAmount, user.MaxMana); // Regenerate mana, ensuring it doesn't exceed max mana
                int recovered = user.CurrentMana - before; // Calculate how much mana was recovered
                logCallback?.Invoke($"{user.DisplayName} is resting. Recovered {recovered} mana."); // Log the mana recovery
                return true; // Ability executed successfully
            }
            if (ability is DefensiveAbility def) // Check if the ability is a defensive ability
            {
                bool alreadyApplied = user.ActiveEffects.Any(e => e.Id == ability.Id); // Check if the effect is already applied
                bool success = def.CanStack || !alreadyApplied; // Determine if the ability can be applied based on stacking rules
                user.CurrentMana -= def.ManaCost; // Deduct mana cost for using the ability
                if (success) // If the ability can be applied
                {
                    logCallback?.Invoke($"{user.DisplayName} used {def.Name}. {def.TargetStat} was raised!"); // Log the successful application of the ability
                    var simulatedEffect = new StatBuffEffect // Create a new effect instance
                    {
                        Id = def.Id, // Unique identifier for the effect
                        Duration = def.Duration, // Duration of the effect
                        RemainingTurns = def.Duration, // Remaining turns for the effect
                        BuffPercentage = def.BuffPercentage, // Percentage increase for the stat
                        TargetStat = def.TargetStat, // The stat being buffed
                        IsStackable = def.CanStack // Whether the effect can stack with existing effects
                    };
                    EffectManager.AddEffect(user, simulatedEffect); // Add the effect to the user's active effects
                }
                else //If the effect is already applied and cannot stack
                {
                    logCallback?.Invoke($"{user.DisplayName} used {def.Name}, but it had no effect!"); // Log that the effect was not applied
                }
                return success; // Return whether the ability was successfully applied
            }
            if (ability is OffensiveAbility off) // Check if the ability is an offensive ability
            {
                double accuracy = off.Accuracy; // Base accuracy of the ability
                double evasivenessPenalty = target.Evasiveness * 0.01; // Calculate evasiveness penalty based on target's evasiveness
                double variance = _rng.NextDouble() * 0.24 + 0.01; // Random variance between 0.01 and 0.25 to add unpredictability
                double hitChance = Math.Min(Math.Max(accuracy - evasivenessPenalty + variance, 0), 1); // Calculate final hit chance, ensuring it's between 0 and 1
                double roll = _rng.NextDouble(); // Generate a random roll between 0 and 1 to determine if the attack hits
                bool isHit = roll <= hitChance; // Check if the attack hits based on the roll and hit chance
                user.CurrentMana -= off.ManaCost; // Deduct mana cost for using the ability
                if (!isHit) // If the attack misses
                {
                    logCallback?.Invoke($"{user.DisplayName} used {off.Name} and missed {target.DisplayName}!"); // Log the miss
                    return false; // Return false to indicate the ability was not successfully executed
                }
                int damage = CalculateDamage(user, target, off, out double multiplier, out string type); // Calculate the damage dealt by the ability
                ApplyDamage(target, damage); // Apply the calculated damage to the target
                if (off.Class == AbilityClass.Physical) // If the ability is physical, trigger passive effects
                {
                    EffectManager.TriggerTypePassive(target, user, BattleContext.Current); // Trigger any passive effects that may apply based on the ability type
                }
                string extra = null; // Initialize extra message for effectiveness
                if (multiplier == 2.0) // Check for super effective hits
                    extra = "It was super effective!"; // If the damage multiplier indicates a super effective hit
                else if (multiplier == 1.5) // Check for effective hits
                    extra = "It was very effective!"; // If the damage multiplier indicates a very effective hit
                else if (multiplier == 0.5) // Check for not very effective hits
                    extra = "It was not very effective!"; // If the damage multiplier indicates a not very effective hit
                string classType = off.Class == AbilityClass.Physical ? "Physical" : "Arcane"; // Determine the class type of the ability
                string logMsg = $"{user.DisplayName} used {off.Name} and hit {target.DisplayName} for {damage} {type} ({classType}) damage!"; //Construct the log message
                if (extra != null) // If there is an extra message for effectiveness
                    logMsg += $" {extra}"; // Append the effectiveness message to the log
                logCallback?.Invoke(logMsg); // Log the attack details
                return true; // Return true to indicate the ability was successfully executed
            }
            return false; // If the ability is neither offensive nor defensive, return false
        }
        // Calculates the damage dealt by an offensive ability
        private static int CalculateDamage(
            ArcabeastInstance user, // The Arcabeast using the ability
            ArcabeastInstance target, // The target Arcabeast
            OffensiveAbility ability, // The offensive ability being used
            out double multiplier, // The damage multiplier based on target's type
            out string type) // The type of damage dealt by the ability
        {
            bool isPhysical = ability.Class == AbilityClass.Physical; // Determine if the ability is physical or arcane
            int attackerPower = isPhysical ? user.PhysicalPower + user.TempPhysicalPower // Calculate attacker's power based on ability type
                                           : user.ArcanePower + user.TempArcanePower; // Add temporary power boosts if applicable
            int defenderDefense = isPhysical ? target.PhysicalDefense + target.TempPhysicalDefense // Calculate defender's defense based on ability type
                                             : target.ArcaneDefense + target.TempArcaneDefense; // Add temporary defense boosts if applicable
            multiplier = target.DamageMultipliers.TryGetValue(ability.Type, out double mult) ? mult : 1.0; // Get the damage multiplier for the target's type, defaulting to 1.0 if not found
            type = ability.Type; // Set the type of damage dealt by the ability
            double variance = _rng.NextDouble() * 4 - 2; // ±2 variance
            double rawDamage = ((double)attackerPower * ability.BasePower) / defenderDefense; // Calculate raw damage based on attacker's power, ability's base power, and defender's defense
            double finalDamage = rawDamage * multiplier + variance; // Apply the damage multiplier and variance to the raw damage
            return Math.Max(1, (int)Math.Round(finalDamage)); // Ensure the final damage is at least 1, rounding to the nearest integer
        }
        // Applies damage to the target Arcabeast instance
        private static void ApplyDamage(ArcabeastInstance target, int amount)
        {
            target.CurrentHP = Math.Max(0, target.CurrentHP - amount); // Reduce the target's current HP by the damage amount, ensuring it doesn't go below 0
        }
    }
}

