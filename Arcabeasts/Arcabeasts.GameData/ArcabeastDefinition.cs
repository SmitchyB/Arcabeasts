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

            public List<string> AllowedMoveTypes { get; set; } = new List<string>();
            public Dictionary<string, double> DamageMultipliers { get; set; } = new Dictionary<string, double>();
        }

        public class FireArcabeast : ArcabeastDefinition
        {
            public int BurnDamage { get; set; }
            public int BurnDuration { get; set; }
        }

        public class GrassArcabeast : ArcabeastDefinition
        {
            public int PoisonDamage { get; set; }
            public int PoisonDuration { get; set; }
        }

        public class ElectricArcabeast : ArcabeastDefinition
        {
            public int ShockDamagePerTurn { get; set; }
            public double ShockStunChance { get; set; }
            public int ShockStunDuration { get; set; }
        }

        public class WaterArcabeast : ArcabeastDefinition
        {
            public int DampenManaDrain { get; set; }
        }

        public class RockArcabeast : ArcabeastDefinition
        {
            public int GuardBreakAmount { get; set; }
            public int GuardBreakChance { get; set; }
        }

        public class AirArcabeast : ArcabeastDefinition
        {
            public double EvasionBoostChance { get; set; }
            public int EvasionBoostDuration { get; set; }
            public int EvasionBoostAmount { get; set; }
        }

        public class PrimeArcabeast : ArcabeastDefinition
        {
            // Prime has no passive
        }
    }

}
