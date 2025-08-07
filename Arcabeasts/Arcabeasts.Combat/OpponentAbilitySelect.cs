using Arcabeasts.GameData;
using Arcabeasts.GameData.Arcabeasts.GameData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Arcabeasts.Combat
{
    public static class OpponentAbilitySelect
    {
        private static readonly Random _rng = new Random();

        public static ArcabeastAbility Choose(List<ArcabeastAbility> opponentAbilities)
        {
            if (opponentAbilities == null || opponentAbilities.Count == 0)
                return null;

            var context = BattleContext.Current;
            if (context == null || context.OpponentInstance == null)
                throw new InvalidOperationException("BattleContext.Current or OpponentInstance is null.");

            int currentMana = context.OpponentInstance.CurrentMana;

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
                .Where(a => a.ManaCost <= currentMana && a.Name != "Rest")
                .ToList();

            if (usable.Count == 0)
            {
                Console.WriteLine("[OpponentAbilitySelect] No usable abilities, opponent will Rest.");
                return restAbility;
            }

            // Randomly pick from usable non-Rest abilities
            var chosen = usable[_rng.Next(usable.Count)];
            Console.WriteLine($"[OpponentAbilitySelect] Opponent chose: {chosen.Name}");
            return chosen;
        }
    }
}
