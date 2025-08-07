using Arcabeasts.GameData.Arcabeasts.GameData;
using System;

namespace Arcabeasts.Combat
{
    public static class LevelStatCalculator
    {
        // Percent increase per level (e.g. 0.05 = 5%)
        private const double ScalingFactor = 0.05;

        public static ArcabeastDefinition ScaleStats(ArcabeastDefinition baseDef, int level)
        {
            if (level <= 1) return baseDef; // No scaling for level 1

            var multiplier = 1 + ScalingFactor * (level - 1);

            baseDef.MaxHP = ScaleStat(baseDef.MaxHP, multiplier);
            baseDef.MaxMana = ScaleStat(baseDef.MaxMana, multiplier);
            baseDef.ManaRegen = ScaleStat(baseDef.ManaRegen, multiplier);
            baseDef.Speed = ScaleStat(baseDef.Speed, multiplier);
            baseDef.PhysicalPower = ScaleStat(baseDef.PhysicalPower, multiplier);
            baseDef.ArcanePower = ScaleStat(baseDef.ArcanePower, multiplier);
            baseDef.PhysicalDefense = ScaleStat(baseDef.PhysicalDefense, multiplier);
            baseDef.ArcaneDefense = ScaleStat(baseDef.ArcaneDefense, multiplier);
            baseDef.Evasiveness = ScaleStat(baseDef.Evasiveness, multiplier);

            return baseDef;
        }

        private static int ScaleStat(int baseValue, double multiplier)
        {
            return (int)Math.Round(baseValue * multiplier);
        }
    }
}
