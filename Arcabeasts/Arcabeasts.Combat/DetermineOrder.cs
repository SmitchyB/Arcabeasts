using Arcabeasts.GameData;
using Arcabeasts.GameData.Arcabeasts.GameData;
using System;

namespace Arcabeasts.Combat
{
    public static class DetermineOrder
    {
        public static bool PlayerGoesFirst(ArcabeastDefinition playerDef, ArcabeastAbility playerAbility, ArcabeastDefinition opponentDef, ArcabeastAbility opponentAbility)
        {
            double playerVelocity = GetVelocity(playerAbility);
            double opponentVelocity = GetVelocity(opponentAbility);

            double playerTotalSpeed = playerVelocity * playerDef.Speed;
            double opponentTotalSpeed = opponentVelocity * opponentDef.Speed;

            Console.WriteLine($"[DetermineOrder] Player: {playerAbility.Name}, Velocity: {playerTotalSpeed}");
            Console.WriteLine($"[DetermineOrder] Opponent: {opponentAbility.Name}, Velocity: {opponentTotalSpeed}");

            return playerTotalSpeed >= opponentTotalSpeed;
        }

        private static double GetVelocity(ArcabeastAbility ability)
        {
            if (ability is OffensiveAbility o)
                return o.Velocity;
            if (ability is DefensiveAbility d)
                return d.Velocity;
            return 0;
        }
    }
}

