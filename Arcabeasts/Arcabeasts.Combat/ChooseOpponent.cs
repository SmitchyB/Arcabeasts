using Arcabeasts.DataLib;
using Arcabeasts.GameData;
using Arcabeasts.GameData.Arcabeasts.GameData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Arcabeasts.Combat
{
    public static class ChooseOpponent
    {
        private static readonly Random _rng = new Random(); // Random instance for selecting opponents
        // Generates an opponent Arcabeast instance based on the user's level
        public static ArcabeastInstance GenerateOpponent(int userLevel)
        {
            var allBeasts = ArcabeastDB.All; // Get all available Arcabeasts from the database
            var allAbilities = ArcabeastAbilityDB.All; // Get all available abilities from the database
            var randomBeast = allBeasts[_rng.Next(allBeasts.Count)]; // Randomly select an Arcabeast from the list
            var validAbilities = allAbilities // Filter abilities to only those that are allowed for the selected Arcabeast
                .Where(a => randomBeast.AllowedMoveTypes.Contains(a.Type)) // Ensure the ability type is allowed for the Arcabeast
                .ToList(); // Randomly select abilities for the Arcabeast
            var chosenAbilities = validAbilities // Select a random subset of abilities for the Arcabeast
                .OrderBy(_ => _rng.Next()) // Shuffle the abilities randomly
                .Take(4) // Take the first 4 abilities from the shuffled list
                .Select(a => a.Id) // Select the IDs of the chosen abilities
                .ToList(); //Convert the selected abilities to a list of IDs
            var scaledDef = LevelStatCalculator.ScaleStats(randomBeast, userLevel); // Scale the selected Arcabeast's stats based on the user's level
            var instance = ArcabeastFactory.CreateInstance( // Create a new Arcabeast instance with the scaled stats and chosen abilities
                scaledDef, // Use the scaled definition of the Arcabeast
                scaledDef.Name, // Use the name of the Arcabeast as the display name
                userLevel, // Use the user's level as the instance's level
                0, // Set the instance's current experience to 0
                chosenAbilities // Use the list of chosen ability IDs for the instance
            );
            //Apply scaled stats to instance
            instance.MaxHP = scaledDef.MaxHP; // Set the instance's maximum HP to the scaled value
            instance.MaxMana = scaledDef.MaxMana; // Set the instance's maximum mana to the scaled value
            instance.ManaRegen = scaledDef.ManaRegen; // Set the instance's mana regeneration to the scaled value
            instance.Speed = scaledDef.Speed; // Set the instance's speed to the scaled value
            instance.PhysicalPower = scaledDef.PhysicalPower; // Set the instance's physical power to the scaled value
            instance.ArcanePower = scaledDef.ArcanePower; // Set the instance's arcane power to the scaled value
            instance.PhysicalDefense = scaledDef.PhysicalDefense; // Set the instance's physical defense to the scaled value
            instance.ArcaneDefense = scaledDef.ArcaneDefense; // Set the instance's arcane defense to the scaled value
            instance.Evasiveness = scaledDef.Evasiveness; // Set the instance's evasiveness to the scaled value
            instance.CurrentHP = instance.MaxHP; // Set the instance's current HP to its maximum HP
            instance.CurrentMana = instance.MaxMana; // Set the instance's current mana to its maximum mana
            return instance; // Return the newly created Arcabeast instance
        }
    }
}
