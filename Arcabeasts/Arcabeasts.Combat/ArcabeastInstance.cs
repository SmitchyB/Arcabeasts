using Arcabeasts.DataLib;
using Arcabeasts.GameData.Arcabeasts.GameData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcabeasts.Combat
{
    public class ArcabeastInstance
    {
        public Guid ArcabeastId { get; set; }
        public string DisplayName { get; set; } = "";
        public int Level { get; set; }
        public int Experience { get; set; }
        public int MaxHP { get; set; }
        public int MaxMana { get; set; }
        public int CurrentHP { get; set; }
        public int CurrentMana { get; set; }
        public int ManaRegen { get; set; }
        public int Speed { get; set; }
        public int PhysicalPower { get; set; }
        public int ArcanePower { get; set; }
        public int PhysicalDefense { get; set; }
        public int ArcaneDefense { get; set; }
        public int Evasiveness { get; set; }
        public int TempSpeed { get; set; } = 0;
        public int TempPhysicalPower { get; set; } = 0;
        public int TempArcanePower { get; set; } = 0;
        public int TempPhysicalDefense { get; set; } = 0;
        public int TempArcaneDefense { get; set; } = 0;
        public int TempEvasiveness { get; set; } = 0;
        public bool IsStunned { get; set; } = false;
        public Dictionary<string, double> DamageMultipliers { get; set; } = new Dictionary<string, double>();
        public List<Guid> LearnedMoveIds { get; set; } = new List<Guid>();
        public List<ActiveEffect> ActiveEffects { get; set; } = new List<ActiveEffect>();
    }
    public class FireArcabeastInst : ArcabeastInstance
    {
        public double BurnDamage { get; set; }
        public int BurnDuration { get; set; }
        public double BurnChance { get; set; }
        public bool IsStackable { get; set; }
        public Guid PassiveAbilityId { get; set; }
    }
    public class GrassArcabeastInst : ArcabeastInstance
    {
        public double PoisonDamage { get; set; }
        public int PoisonDuration { get; set; }
        public double PoisonChance { get; set; }
        public bool IsStackable { get; set; }
        public Guid PassiveAbilityId { get; set; }
    }
    public class ElectricArcabeastInst : ArcabeastInstance
    {
        public double ShockDamagePerTurn { get; set; }
        public double ShockStunChance { get; set; }
        public int ShockStunDuration { get; set; }
        public bool IsStackable { get; set; }
        public Guid PassiveAbilityId { get; set; }
    }
    public class WaterArcabeastInst : ArcabeastInstance
    {
        public double DampenManaDrain { get; set; }
        public double DampenChance { get; set; }
        public bool IStackable { get; set; }
        public Guid PassiveAbilityId { get; set; }
    }
    public class RockArcabeastInst : ArcabeastInstance
    {
        public double GuardBreakAmount { get; set; }
        public double GuardBreakChance { get; set; }
        public int GuardBreakDuration { get; set; }
        public int AmountPhysicalReduced { get; set; }
        public int AmountArcaneReduced { get; set; }
        public bool IsStackable { get; set; }
        public Guid PassiveAbilityId { get; set; }
    }
    public class AirArcabeastInst : ArcabeastInstance
    {
        public double EvasionBoostChance { get; set; }
        public int EvasionBoostDuration { get; set; }
        public double EvasionBoostAmount { get; set; }
        public bool IsStackable { get; set; }
        public Guid PassiveAbilityId { get; set; }
    }
}
