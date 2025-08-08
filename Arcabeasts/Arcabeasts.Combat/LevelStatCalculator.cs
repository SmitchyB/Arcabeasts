using Arcabeasts.GameData.Arcabeasts.GameData;
using System;

namespace Arcabeasts.Combat
{
    //Scales Arcabeast stats based on their level.
    public static class LevelStatCalculator
    {
        private const double ScalingFactor = 0.05; // 5% increase per level
        public static ArcabeastDefinition ScaleStats(ArcabeastDefinition baseDef, int level)
        {
            if (level <= 1) return baseDef; // No scaling for level 1
            var multiplier = 1 + ScalingFactor * (level - 1); // Calculate the scaling multiplier based on level
            baseDef.MaxHP = ScaleStat(baseDef.MaxHP, multiplier); // Scale MaxHP
            baseDef.MaxMana = ScaleStat(baseDef.MaxMana, multiplier); // Scale MaxMana
            baseDef.ManaRegen = ScaleStat(baseDef.ManaRegen, multiplier); // Scale ManaRegen
            baseDef.Speed = ScaleStat(baseDef.Speed, multiplier); // Scale Speed
            baseDef.PhysicalPower = ScaleStat(baseDef.PhysicalPower, multiplier); // Scale PhysicalPower
            baseDef.ArcanePower = ScaleStat(baseDef.ArcanePower, multiplier); // Scale ArcanePower
            baseDef.PhysicalDefense = ScaleStat(baseDef.PhysicalDefense, multiplier);// Scale PhysicalDefense
            baseDef.ArcaneDefense = ScaleStat(baseDef.ArcaneDefense, multiplier); // Scale ArcaneDefense
            baseDef.Evasiveness = ScaleStat(baseDef.Evasiveness, multiplier); // Scale Evasiveness
            return baseDef; // Return the scaled ArcabeastDefinition
        }
        // Math for scaling stats based on level
        private static int ScaleStat(int baseValue, double multiplier)
        {
            return (int)Math.Round(baseValue * multiplier); // Scale the stat by the multiplier and round to nearest integer
        }
    }
}
