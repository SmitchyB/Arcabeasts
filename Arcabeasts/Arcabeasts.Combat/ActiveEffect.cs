using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcabeasts.Combat
{
    public abstract class ActiveEffect
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int RemainingTurns { get; set; }
        public int Duration { get; set; } // 0 = entire battle, >0 = specific turns
        public bool IsExpired => RemainingTurns <= 0;
        public bool IsStackable { get; set; }
        public virtual void OnTurnStart(BattleContext context, ArcabeastInstance target) { }
        public virtual void OnTurnEnd(BattleContext context, ArcabeastInstance target) { }
    }

    // Buff applied by defensive abilities
    public class StatBuffEffect : ActiveEffect
    {
        public string TargetStat { get; set; }
        public double BuffPercentage { get; set; }
        public int AmountAdded { get; set; } //Post calculation for buffs
    }

    public class BurnEffect : ActiveEffect
    {
        public double DamagePerTurn { get; set; }
        public double BurnChance { get; set; }
    }

    public class PoisonEffect : ActiveEffect
    {
        public double DamagePerTurn { get; set; }
        public double PoisonChance { get; set; }
    }

    public class ShockEffect : ActiveEffect
    {
        public double DamagePerTurn { get; set; }
        public double StunChance { get; set; }
    }

    public class DampenEffect : ActiveEffect
    {
        public double ManaDrain { get; set; }
        public double DampenChance { get; set; }
    }

    public class GuardBreakEffect : ActiveEffect
    {
        public double DefenseReduction { get; set; }
        public int AmountPhysicalReduced { get; set; }
        public int AmountArcaneReduced { get; set; }
        public double GuardBreakChance { get; set; }
    }

    public class EvasionBoostEffect : ActiveEffect
    {
        public double EvasionIncrease { get; set; }
        public double EvasionBoostChance { get; set; }
        public int AmountAdded { get; set; } //Post calculation
    }

}
