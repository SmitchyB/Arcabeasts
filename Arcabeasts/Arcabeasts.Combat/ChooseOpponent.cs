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
        private static readonly Random _rng = new Random();

        public static ArcabeastInstance GenerateOpponent(int userLevel)
        {
            var allBeasts = ArcabeastDB.All;
            var allAbilities = ArcabeastAbilityDB.All;

            var randomBeast = allBeasts[_rng.Next(allBeasts.Count)];

            var validAbilities = allAbilities
                .Where(a => randomBeast.AllowedMoveTypes.Contains(a.Type))
                .ToList();

            var chosenAbilities = validAbilities
                .OrderBy(_ => _rng.Next())
                .Take(4)
                .Select(a => a.Id)
                .ToList();

            var scaledDef = LevelStatCalculator.ScaleStats(randomBeast, userLevel);

            var instance = ArcabeastFactory.CreateInstance(
                scaledDef,
                scaledDef.Name,
                userLevel,
                0,
                chosenAbilities
            );

            // 🔁 Apply scaled stats to instance
            instance.MaxHP = scaledDef.MaxHP;
            instance.MaxMana = scaledDef.MaxMana;
            instance.ManaRegen = scaledDef.ManaRegen;
            instance.Speed = scaledDef.Speed;
            instance.PhysicalPower = scaledDef.PhysicalPower;
            instance.ArcanePower = scaledDef.ArcanePower;
            instance.PhysicalDefense = scaledDef.PhysicalDefense;
            instance.ArcaneDefense = scaledDef.ArcaneDefense;
            instance.Evasiveness = scaledDef.Evasiveness;
            instance.CurrentHP = instance.MaxHP;
            instance.CurrentMana = instance.MaxMana;

            return instance;
        }

    }
}
