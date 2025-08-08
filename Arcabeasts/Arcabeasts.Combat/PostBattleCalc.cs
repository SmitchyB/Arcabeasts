using Arcabeasts.DataLib;
using System;

namespace Arcabeasts.Combat
{
    public static class PostBattleCalc
    {
        // Calculates the experience reward based on the opponent's level
        public static int CalculateExpReward(int opponentLevel)
        {
            return (int)(50 * Math.Pow(1.1, opponentLevel)); // Determines exp based on opponent's level with exponential scaling
        }
        // Calculates the experience needed to reach the next level
        public static int RequiredExpForLevel(int level) 
        {
            return (int)(100 * Math.Pow(level, 1.5)); // Determines the required exp for the next level with exponential growth
        }
        // Grants experience to the Arcabeast and levels it up if enough experience is gained
        public static void GrantExp(PlayerArcabeast arcabeast, int exp)
        {
            arcabeast.Experience += exp; // Add the granted experience to the Arcabeast's current experience
            while (true) // Loop to check if the Arcabeast can level up
            {
                int xpNeeded = RequiredExpForLevel(arcabeast.Level); // Calculate the experience needed for the next level
                if (arcabeast.Experience < xpNeeded) // If not enough experience, break the loop
                    break;

                arcabeast.Experience -= xpNeeded; // Subtract the required experience for leveling up
                arcabeast.Level++; // Increment the Arcabeast's level
            }
        }
    }
}
