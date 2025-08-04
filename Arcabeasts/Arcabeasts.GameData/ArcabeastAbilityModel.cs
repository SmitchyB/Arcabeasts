using System;

namespace Arcabeasts.GameData
{
    public enum AbilityClass
    {
        Physical,
        Arcane
    }

    public abstract class ArcabeastAbility
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Type { get; set; } // Fire, Water, etc.
        public AbilityClass Class { get; set; }
        public int BasePower { get; set; }
        public int ManaCost { get; set; }
    }

    public class OffensiveAbility : ArcabeastAbility
    {
        public double Accuracy { get; set; } = 1.0;
        public double Velocity { get; set; } = 1;
        public bool IsMultiTurn { get; set; } = false;
        public int ChargeTurns { get; set; } = 0;
    }

    public class DefensiveAbility : ArcabeastAbility
    {
        public string TargetStat { get; set; }
        public double BuffPercentage { get; set; }
        public int Duration { get; set; } // 0 = entire battle
        public bool CanStack { get; set; } = false;
    }
}

