    using Arcabeasts.GameData;
    using Arcabeasts.GameData.Arcabeasts.GameData;
    using System;
    using System.Linq;

    namespace Arcabeasts.Combat
    {
        public class BattleFlow
        {
            private BattleContext _context; // holds the battle context
            public BattleFlow(BattleContext context) // constructor to initialize the battle flow with a context
            {
                _context = context; // initialize with the provided battle context
            }
            // Executes a turn in the battle, processing player and opponent abilities
            public void ExecuteTurn(ArcabeastAbility playerAbility, Action onComplete)
            {
                var opponentDef = ArcabeastDB.All.First(a => a.Id == _context.OpponentInstance.ArcabeastId); // get the opponent's definition
                var opponentAbility = OpponentAbilitySelect.Choose( // choose an ability for the opponent
                    ArcabeastAbilityDB.All // get all abilities from the database
                        .Where(a => _context.OpponentInstance.LearnedMoveIds.Contains(a.Id)) // filter abilities to those the opponent has learned
                        .ToList() // convert to a list 
                );

            var playerDef = ArcabeastDB.All.First(a => a.Id == _context.PlayerInstance.ArcabeastId); // get the player's definition
                bool playerGoesFirst = DetermineOrder.PlayerGoesFirst(playerDef, playerAbility, opponentDef, opponentAbility); // determine if the player goes first based on their speed and abilities
                // Process effects first
                EffectManager.ProcessEffects(_context.PlayerInstance, _context); // process any active effects on the player instance
                EffectManager.ProcessEffects(_context.OpponentInstance, _context); // process any active effects on the opponent instance
                // Early KO check (in case effects caused it)
                if (_context.PlayerInstance.CurrentHP <= 0) // check if the player is KO'd
                {
                    _context.OnBattleEnded?.Invoke(false); // if the player is KO'd, end the battle with a loss
                    return;
                }
                else if (_context.OpponentInstance.CurrentHP <= 0)  // check if the opponent is KO'd
                {
                    _context.OnBattleEnded?.Invoke(true); // if the opponent is KO'd, end the battle with a win
                    return;
                }
                if (playerGoesFirst) // if the player goes first
                {
                    AttemptAbilityUse(_context.PlayerInstance, _context.OpponentInstance, playerAbility); // attempt to use the player's ability on the opponent

                    if (_context.OpponentInstance.CurrentHP > 0) // if the opponent is still alive
                        AttemptAbilityUse(_context.OpponentInstance, _context.PlayerInstance, opponentAbility); // attempt to use the opponent's ability on the player
                }
                else // if the opponent goes first
                {
                    AttemptAbilityUse(_context.OpponentInstance, _context.PlayerInstance, opponentAbility); // attempt to use the opponent's ability on the player
                    if (_context.PlayerInstance.CurrentHP > 0) // if the player is still alive
                        AttemptAbilityUse(_context.PlayerInstance, _context.OpponentInstance, playerAbility); // attempt to use the player's ability on the opponent
                }
                // Final KO check
                if (_context.PlayerInstance.CurrentHP <= 0) // check if the player is KO'd
                {
                    _context.OnBattleEnded?.Invoke(false); // if the player is KO'd, end the battle with a loss
                    return;
                }
                else if (_context.OpponentInstance.CurrentHP <= 0) // check if the opponent is KO'd
                {
                    _context.OnBattleEnded?.Invoke(true); // if the opponent is KO'd, end the battle with a win
                    return; 
                }
                // Mana regen
                int playerBefore = _context.PlayerInstance.CurrentMana; // store the player's mana before regeneration
                int opponentBefore = _context.OpponentInstance.CurrentMana; // store the opponent's mana before regeneration
                _context.PlayerInstance.CurrentMana = Math.Min(playerBefore + _context.PlayerInstance.ManaRegen, _context.PlayerInstance.MaxMana); // regenerate the player's mana, ensuring it does not exceed the maximum
                _context.OpponentInstance.CurrentMana = Math.Min(opponentBefore + _context.OpponentInstance.ManaRegen, _context.OpponentInstance.MaxMana); // regenerate the opponent's mana, ensuring it does not exceed the maximum
                int playerGained = _context.PlayerInstance.CurrentMana - playerBefore; // calculate how much mana the player gained
                int opponentGained = _context.OpponentInstance.CurrentMana - opponentBefore; // calculate how much mana the opponent gained
                _context.Log?.Invoke($"{_context.PlayerInstance.DisplayName} regenerated {playerGained} mana."); // log the mana regeneration for the player
                _context.Log?.Invoke($"{_context.OpponentInstance.DisplayName} regenerated {opponentGained} mana."); // log the mana regeneration for the opponent
                _context.TurnNumber++; // increment the turn number
                onComplete?.Invoke(); // invoke the completion action, signaling that the turn has finished
            }
            // Attempts to use an ability on a target, checking for stun status and logging the action
            private void AttemptAbilityUse(ArcabeastInstance user, ArcabeastInstance target, ArcabeastAbility ability)
            {
                if (user.IsStunned) // check if the user is stunned
                {
                    _context.Log?.Invoke($"{user.DisplayName} is stunned and couldn't move!"); // log that the user is stunned and unable to act
                    user.IsStunned = false; // reset the stunned status for the next turn
                }
                else // else if the user is not stunnded
                {
                    UseAbility.Execute(user, target, ability, _context.Log); // execute the ability, passing in the user, target, ability, and log callback
                }
            }
        }
    }
