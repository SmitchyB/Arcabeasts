using Arcabeasts.GameData;
using Arcabeasts.GameData.Arcabeasts.GameData;
using System;

namespace Arcabeasts.Combat
{
    public static class DetermineOrder
    {
        // Determines who goes first based on their Arcabeast's speed and ability velocity.
        public static bool PlayerGoesFirst(ArcabeastDefinition playerDef, ArcabeastAbility playerAbility, ArcabeastDefinition opponentDef, ArcabeastAbility opponentAbility)
        {
            double playerVelocity = GetVelocity(playerAbility); // Get the velocity of the player's ability
            double opponentVelocity = GetVelocity(opponentAbility); // Get the velocity of the opponent's ability
            double playerTotalSpeed = playerVelocity * playerDef.Speed; // Calculate total speed for player
            double opponentTotalSpeed = opponentVelocity * opponentDef.Speed; // Calculate total speed for opponent
            return playerTotalSpeed >= opponentTotalSpeed; // Player goes first if their total speed is greater than or equal to opponent's
        }
        // Gets the velocity of the ability, which is used to determine turn order.
        private static double GetVelocity(ArcabeastAbility ability)
        {
            if (ability is OffensiveAbility o) // Offensive abilities have a velocity property
                return o.Velocity; // Return the velocity of the offensive ability
            if (ability is DefensiveAbility d) // Defensive abilities also have a velocity property
                return d.Velocity; // Return the velocity of the defensive ability
            return 0; // If the ability is neither offensive nor defensive, return 0 (no velocity)
        }
    }
}

