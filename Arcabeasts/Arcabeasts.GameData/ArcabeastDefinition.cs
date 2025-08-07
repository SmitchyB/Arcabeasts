using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcabeasts.GameData
{
    using System;
    using System.Collections.Generic;

    namespace Arcabeasts.GameData
    {
        public abstract class ArcabeastDefinition
        {
            public Guid Id { get; set; } = Guid.NewGuid();
            public string Name { get; set; }
            public string Type { get; set; }

            public string AssetPath { get; set; }

            public int MaxHP { get; set; }
            public int MaxMana { get; set; }
            public int ManaRegen { get; set; }
            public int Speed { get; set; }

            public int PhysicalPower { get; set; }
            public int ArcanePower { get; set; }
            public int PhysicalDefense { get; set; }
            public int ArcaneDefense { get; set; }
            public int Evasiveness { get; set; }
            public List<string> AllowedMoveTypes { get; set; } = new List<string>();
            public Dictionary<string, double> DamageMultipliers { get; set; } = new Dictionary<string, double>();
        }

        public class FireArcabeast : ArcabeastDefinition
        {
            public double BurnDamage { get; set; }
            public int BurnDuration { get; set; }
            public double BurnChance { get; set; } // Chance to apply burn
            public bool isStackable { get; set; }
            public Guid PassiveAbilityId { get; set; } // Link to the passive ability
        }

        public class GrassArcabeast : ArcabeastDefinition
        {
            public double PoisonDamage { get; set; }
            public int PoisonDuration { get; set; }
            public double PoisonChance { get; set; } // Chance to apply poison
            public bool isStackable { get; set; }
            public Guid PassiveAbilityId { get; set; } // Link to the passive ability
        }

        public class ElectricArcabeast : ArcabeastDefinition
        {
            public double ShockDamagePerTurn { get; set; }
            public double ShockStunChance { get; set; } // Chance to apply stun and repeat stun
            public int ShockStunDuration { get; set; }
            public bool isStackable { get; set; }
            public Guid PassiveAbilityId { get; set; } // Link to the passive ability
        }

        public class WaterArcabeast : ArcabeastDefinition
        {
            public double DampenManaDrain { get; set; }
            public double DampenChance { get; set; }
            public bool isStackable { get; set; }
            public Guid PassiveAbilityId { get; set; } // Link to the passive ability
        }

        public class RockArcabeast : ArcabeastDefinition
        {
            public double GuardBreakAmount { get; set; }
            public double GuardBreakChance { get; set; }
            public bool isStackable { get; set; }
            public Guid PassiveAbilityId { get; set; } // Link to the passive ability
        }

        public class AirArcabeast : ArcabeastDefinition
        {
            public double EvasionBoostChance { get; set; }
            public int EvasionBoostDuration { get; set; }
            public double EvasionBoostAmount { get; set; }
            public bool isStackable { get; set; }
            public Guid PassiveAbilityId { get; set; } // Link to the passive ability
        }

        public class PrimeArcabeast : ArcabeastDefinition
        {
            // Prime has no passive
        }
    }

}
