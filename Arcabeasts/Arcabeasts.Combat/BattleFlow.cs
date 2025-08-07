using Arcabeasts.GameData;
using Arcabeasts.GameData.Arcabeasts.GameData;
using System;
using System.Linq;

namespace Arcabeasts.Combat
{
    public class BattleFlow
    {
        private BattleContext _context;

        public BattleFlow(BattleContext context)
        {
            _context = context;
        }

        public void ExecuteTurn(ArcabeastAbility playerAbility, Action onComplete)
        {
            var opponentDef = ArcabeastDB.All.First(a => a.Id == _context.OpponentInstance.ArcabeastId);
            var opponentAbility = OpponentAbilitySelect.Choose(
                ArcabeastAbilityDB.All
                    .Where(a => opponentDef.AllowedMoveTypes.Contains(a.Type)
                             && _context.OpponentInstance.LearnedMoveIds.Contains(a.Id))
                    .ToList()
            );

            var playerDef = ArcabeastDB.All.First(a => a.Id == _context.PlayerInstance.ArcabeastId);
            bool playerGoesFirst = DetermineOrder.PlayerGoesFirst(playerDef, playerAbility, opponentDef, opponentAbility);

            // Process effects first
            EffectManager.ProcessEffects(_context.PlayerInstance, _context);
            EffectManager.ProcessEffects(_context.OpponentInstance, _context);

            // Early KO check (in case effects caused it)
            if (_context.PlayerInstance.CurrentHP <= 0)
            {
                _context.OnBattleEnded?.Invoke(false);
                return;
            }
            else if (_context.OpponentInstance.CurrentHP <= 0)
            {
                _context.OnBattleEnded?.Invoke(true);
                return;
            }


            Console.WriteLine($"[BattleFlow] Player goes first: {playerGoesFirst}");

            if (playerGoesFirst)
            {
                AttemptAbilityUse(_context.PlayerInstance, _context.OpponentInstance, playerAbility);

                if (_context.OpponentInstance.CurrentHP > 0) // prevent KO'd from attacking
                    AttemptAbilityUse(_context.OpponentInstance, _context.PlayerInstance, opponentAbility);
            }
            else
            {
                AttemptAbilityUse(_context.OpponentInstance, _context.PlayerInstance, opponentAbility);

                if (_context.PlayerInstance.CurrentHP > 0)
                    AttemptAbilityUse(_context.PlayerInstance, _context.OpponentInstance, playerAbility);
            }

            // Final KO check
            if (_context.PlayerInstance.CurrentHP <= 0)
            {
                _context.OnBattleEnded?.Invoke(false);
                return;
            }
            else if (_context.OpponentInstance.CurrentHP <= 0)
            {
                _context.OnBattleEnded?.Invoke(true);
                return;
            }


            // Mana regen
            int playerBefore = _context.PlayerInstance.CurrentMana;
            int opponentBefore = _context.OpponentInstance.CurrentMana;

            _context.PlayerInstance.CurrentMana = Math.Min(playerBefore + _context.PlayerInstance.ManaRegen, _context.PlayerInstance.MaxMana);
            _context.OpponentInstance.CurrentMana = Math.Min(opponentBefore + _context.OpponentInstance.ManaRegen, _context.OpponentInstance.MaxMana);

            int playerGained = _context.PlayerInstance.CurrentMana - playerBefore;
            int opponentGained = _context.OpponentInstance.CurrentMana - opponentBefore;

            _context.Log?.Invoke($"{_context.PlayerInstance.DisplayName} regenerated {playerGained} mana.");
            _context.Log?.Invoke($"{_context.OpponentInstance.DisplayName} regenerated {opponentGained} mana.");

            _context.TurnNumber++;
            onComplete?.Invoke();
        }


        private void AttemptAbilityUse(ArcabeastInstance user, ArcabeastInstance target, ArcabeastAbility ability)
        {
            if (user.IsStunned)
            {
                _context.Log?.Invoke($"{user.DisplayName} is stunned and couldn't move!");
                user.IsStunned = false;
            }
            else
            {
                UseAbility.Execute(user, target, ability, _context.Log);
            }
        }
    }
}
