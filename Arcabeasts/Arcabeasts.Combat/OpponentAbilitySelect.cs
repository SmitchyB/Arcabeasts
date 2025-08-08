using Arcabeasts.GameData;
using Arcabeasts.GameData.Arcabeasts.GameData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Arcabeasts.Combat
{
    // Chooses an ability for the opponent based on current mana and available abilities.
    public static class OpponentAbilitySelect
    {
        private static readonly Random _rng = new Random(); // Random instance for ability selection
        public static ArcabeastAbility Choose(List<ArcabeastAbility> opponentAbilities) // Chooses an ability for the opponent based on current mana and available abilities.
        {
            if (opponentAbilities == null || opponentAbilities.Count == 0) // Check if the opponentAbilities list is null or empty
                return null; // If no abilities are available, return null
            var context = BattleContext.Current; // Get the current battle context
            if (context == null || context.OpponentInstance == null) // Check if the BattleContext or OpponentInstance is null
                throw new InvalidOperationException("BattleContext.Current or OpponentInstance is null."); // If so, throw an exception
            int currentMana = context.OpponentInstance.CurrentMana; // Get the current mana of the opponent instance
            // Define the Rest fallback
            var restAbility = new DefensiveAbility
            {
                Id = Guid.Empty,
                Name = "Rest",
                ManaCost = 0,
                Type = "None",
                Class = AbilityClass.Physical,
                Duration = 0,
                BuffPercentage = 0,
                TargetStat = "None",
                Velocity = 1.0,
                CanStack = false
            };

            // Filter for usable abilities (not exceeding current mana)
            var usable = opponentAbilities
                .Where(a => a.ManaCost <= currentMana && a.Name != "Rest") // Exclude Rest ability from usable list
                .ToList(); // Create a list of usable abilities based on current mana and excluding Rest
            if (usable.Count == 0) //If no usable abilities
            {
                return restAbility; //return the Rest ability
            }
            var chosen = usable[_rng.Next(usable.Count)]; // Randomly select one of the usable abilities
            return chosen; // Return the randomly chosen ability
        }
    }
}
