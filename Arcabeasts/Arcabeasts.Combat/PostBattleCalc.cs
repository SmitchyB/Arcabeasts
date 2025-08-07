using Arcabeasts.DataLib;
using System;

namespace Arcabeasts.Combat
{
    public static class PostBattleCalc
    {
        /// <summary>
        /// Calculate EXP reward based on opponent level (scales upward).
        /// </summary>
        public static int CalculateExpReward(int opponentLevel)
        {
            return (int)(50 * Math.Pow(1.1, opponentLevel)); // Scales quickly, tweak as needed
        }

        /// <summary>
        /// Returns the EXP required to reach the next level from the given level.
        /// </summary>
        public static int RequiredExpForLevel(int level)
        {
            return (int)(100 * Math.Pow(level, 1.5)); // nonlinear scaling
        }

        /// <summary>
        /// Adds EXP and handles level up logic.
        /// </summary>
        public static void GrantExp(PlayerArcabeast arcabeast, int exp)
        {
            Console.WriteLine($"[DEBUG] Before Grant: Level={arcabeast.Level}, EXP={arcabeast.Experience}, Gained={exp}");

            arcabeast.Experience += exp;

            while (true)
            {
                int xpNeeded = RequiredExpForLevel(arcabeast.Level);
                Console.WriteLine($"[DEBUG] Check: Level={arcabeast.Level}, EXP={arcabeast.Experience}, Needed={xpNeeded}");

                if (arcabeast.Experience < xpNeeded)
                    break;

                arcabeast.Experience -= xpNeeded;
                arcabeast.Level++;

                Console.WriteLine($"[DEBUG] Level up! New Level={arcabeast.Level}, Remaining EXP={arcabeast.Experience}");
            }

            Console.WriteLine($"[DEBUG] After Grant: Final Level={arcabeast.Level}, EXP={arcabeast.Experience}");
        }

    }
}
