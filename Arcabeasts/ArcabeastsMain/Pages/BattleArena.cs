// BattleArena.cs
using Arcabeasts.Combat;
using Arcabeasts.DataLib;
using Arcabeasts.GameData;
using Arcabeasts.GameData.Arcabeasts.GameData;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ArcabeastsMain.Pages
{
    public partial class BattleArena : Form
    {
        private readonly UserProfile _profile; // The user's profile containing their Arcabeast and other data
        private readonly int _profileIndex; // The index of the profile in the user's profile list
        private readonly Guid _userId; // The unique identifier for the user, used to save/load data
        private ArcabeastDefinition _userArcabeastDef; // The definition of the user's Arcabeast, containing its stats and abilities
        private ArcabeastInstance _userInstance; // The instance of the user's Arcabeast, which includes current stats and effects
        private List<ArcabeastAbility> _userAbilities = new List<ArcabeastAbility>(); // The list of abilities the user can use in battle, filtered by allowed move types and learned moves
        private ArcabeastDefinition _opponentArcabeastDef; // The definition of the opponent's Arcabeast, chosen based on the user's Arcabeast level
        private ArcabeastInstance _opponentInstance; // The instance of the opponent's Arcabeast, which includes current stats and effects
        private BattleContext _battleContext; // The context of the battle, containing player and opponent instances, turn number, and callbacks
        private BattleFlow _battleFlow; // The flow of the battle, handling turn execution and combat logic
        public BattleArena(UserProfile profile, int profileIndex, Guid userId)
        {
            InitializeComponent(); // Initialize the form components
            _profile = profile; // The user's profile containing their Arcabeast and other data
            _profileIndex = profileIndex; // The index of the profile in the user's profile list
            _userId = userId; // The unique identifier for the user, used to save/load data
            SetupUserArcabeast(); // Setup the user's Arcabeast instance and abilities based on their profile
            SetupOpponentArcabeast(); // Setup the opponent's Arcabeast instance based on the user's Arcabeast level
            _battleContext = new BattleContext // Create a new battle context to manage the battle state
            {
                PlayerInstance = _userInstance, // The player's Arcabeast instance
                OpponentInstance = _opponentInstance, // The opponent's Arcabeast instance
                TurnNumber = 1, // The current turn number in the battle
                OriginalProfile = _profile, // The original profile of the user, used for reference
                ProfileIndex = _profileIndex, // The index of the profile in the user's profile list
                UserId = _userId // The unique identifier for the user, used to save/load data
            };
            _battleContext.OnBattleEnded = (playerWon) => // Callback when the battle ends, either victory or defeat
            {
                BattleContext.Current = null; // Clear the current battle context
                var resultForm = new PostBattle(_battleContext, playerWon); // Create a new PostBattle form to display the results
                resultForm.Show(); // Show the PostBattle form
                this.Invoke((Action)(() => this.Hide())); // Hide the current BattleArena form
            };
            BattleContext.Current = _battleContext; // Set the current battle context to the one created for this battle
            _battleContext.Log = AppendCombatText; // Set the log callback to append combat text to the UI
            _battleFlow = new BattleFlow(_battleContext); // Create a new BattleFlow instance to manage the battle logic
            UpdateTurnLabel(); // Update the turn label to reflect the current turn number
        }
        // Method to set up the user's Arcabeast instance and abilities based on their profile
        private void SetupUserArcabeast()
        {
            _userArcabeastDef = ArcabeastDB.All.First(a => a.Id == _profile.Arcabeast.ArcabeastId); // Get the definition of the user's Arcabeast from the database
            var scaledDef = LevelStatCalculator.ScaleStats(_userArcabeastDef, _profile.Arcabeast.Level); // Scale the Arcabeast stats based on the user's level
            _userAbilities = ArcabeastAbilityDB.All // Get all abilities from the database
                .Where(a => scaledDef.AllowedMoveTypes.Contains(a.Type) && _profile.Arcabeast.LearnedMoveIds.Contains(a.Id)) // Filter abilities based on allowed move types and learned moves
                .ToList(); // Convert to a list for easier manipulation
            _userInstance = ArcabeastFactory.CreateInstance( // Create a new Arcabeast instance for the user
                scaledDef, // Use the scaled definition for stats
                string.IsNullOrWhiteSpace(_profile.Arcabeast.CustomName) // Check if the user has a custom name for their Arcabeast
                    ? scaledDef.Name // If no custom name, use the default name from the definition
                    : _profile.Arcabeast.CustomName, // If a custom name exists, use it
                _profile.Arcabeast.Level, // Set the level of the Arcabeast instance
                _profile.Arcabeast.Experience, // Set the experience of the Arcabeast instance
                _profile.Arcabeast.LearnedMoveIds // Pass the learned move IDs from the user's profile
            );
            // Apply scaled stats to instance
            _userInstance.MaxHP = scaledDef.MaxHP; // Set the maximum HP of the user's Arcabeast instance
            _userInstance.MaxMana = scaledDef.MaxMana; // Set the maximum Mana of the user's Arcabeast instance
            _userInstance.ManaRegen = scaledDef.ManaRegen; // Set the Mana regeneration rate of the user's Arcabeast instance
            _userInstance.Speed = scaledDef.Speed; // Set the speed of the user's Arcabeast instance
            _userInstance.PhysicalPower = scaledDef.PhysicalPower; // Set the physical power of the user's Arcabeast instance
            _userInstance.ArcanePower = scaledDef.ArcanePower; // Set the arcane power of the user's Arcabeast instance
            _userInstance.PhysicalDefense = scaledDef.PhysicalDefense; // Set the physical defense of the user's Arcabeast instance
            _userInstance.ArcaneDefense = scaledDef.ArcaneDefense; // Set the arcane defense of the user's Arcabeast instance
            _userInstance.Evasiveness = scaledDef.Evasiveness; // Set the evasiveness of the user's Arcabeast instance
            _userInstance.CurrentHP = _userInstance.MaxHP; // Set the current HP of the user's Arcabeast instance to its maximum HP
            _userInstance.CurrentMana = _userInstance.MaxMana; // Set the current Mana of the user's Arcabeast instance to its maximum Mana
            DrawUserUI(); // Draw the user's Arcabeast UI with the current stats and abilities
        }
        // Method to set up the opponent's Arcabeast instance based on the user's Arcabeast level
        private void SetupOpponentArcabeast()
        {
            _opponentInstance = ChooseOpponent.GenerateOpponent(_userInstance.Level); // Generate a random opponent Arcabeast based on the user's Arcabeast level
            _opponentArcabeastDef = ArcabeastDB.All.First(a => a.Id == _opponentInstance.ArcabeastId); // Get the definition of the opponent's Arcabeast from the database
            DrawOpponentUI(); // Draw the opponent's Arcabeast UI with the current stats and abilities
        }
        // Method to draw the user's Arcabeast UI with current stats and abilities
        private void DrawUserUI()
        {
            lblUserName.Text = _userInstance.DisplayName; // Set the label text to the user's Arcabeast display name
            lblUserLevel.Text = $"Level: {_userInstance.Level}"; // Set the label text to the user's Arcabeast level
            lblUserHP.Text = $"HP: {_userInstance.CurrentHP}/{_userInstance.MaxHP}"; // Set the label text to the user's Arcabeast current and maximum HP
            lblUserMana.Text = $"Mana: {_userInstance.CurrentMana}/{_userInstance.MaxMana}"; // Set the label text to the user's Arcabeast current and maximum Mana
            barUserHP.Maximum = _userInstance.MaxHP; // Set the maximum value of the HP progress bar to the user's Arcabeast maximum HP
            barUserHP.Value = _userInstance.CurrentHP; // Set the current value of the HP progress bar to the user's Arcabeast current HP
            barUserMana.Maximum = _userInstance.MaxMana; // Set the maximum value of the Mana progress bar to the user's Arcabeast maximum Mana
            barUserMana.Value = _userInstance.CurrentMana; // Set the current value of the Mana progress bar to the user's Arcabeast current Mana
            picUser.Image = Image.FromFile(_userArcabeastDef.AssetPath); // Load the image for the user's Arcabeast from its asset path
            lblUserStats.Text = $"SPD: {_userInstance.TempSpeed}\n" + // Set the label text to display the user's Arcabeast temporary stats
                        $"PWR: {_userInstance.TempPhysicalPower}\n" + // Set the label text to display the user's Arcabeast temporary physical power
                        $"ARC: {_userInstance.TempArcanePower}\n" + // Set the label text to display the user's Arcabeast temporary arcane power
                        $"DEF: {_userInstance.TempPhysicalDefense}\n" + // Set the label text to display the user's Arcabeast temporary physical defense
                        $"ARDEF: {_userInstance.TempArcaneDefense}\n" + // Set the label text to display the user's Arcabeast temporary arcane defense
                        $"EVA: {_userInstance.TempEvasiveness}"; // Set the label text to display the user's Arcabeast temporary evasiveness
            lblUserEffects.Text = string.Join("\n", // Set the label text to display the active effects on the user's Arcabeast
                _userInstance.ActiveEffects.Select(e => // Select each active effect and format it
                {
                    var ability = ArcabeastAbilityDB.All.FirstOrDefault(a => a.Id == e.Id); // Find the ability associated with the effect
                    string name = ability?.Name ?? e.GetType().Name; // Use the ability name if it exists, otherwise use the effect type name
                    return $"{name} ({e.RemainingTurns} turns)"; // Format the effect name and remaining turns
                })
            );
        }
        // Method to draw the opponent's Arcabeast UI with current stats and abilities
        private void DrawOpponentUI()
        {
            lblOpponentName.Text = _opponentInstance.DisplayName; // Set the label text to the opponent's Arcabeast display name
            lblOpponentLevel.Text = $"Level: {_opponentInstance.Level}"; // Set the label text to the opponent's Arcabeast level
            lblOpponentHP.Text = $"HP: {_opponentInstance.CurrentHP}/{_opponentInstance.MaxHP}"; // Set the label text to the opponent's Arcabeast current and maximum HP
            lblOpponentMana.Text = $"Mana: {_opponentInstance.CurrentMana}/{_opponentInstance.MaxMana}"; // Set the label text to the opponent's Arcabeast current and maximum Mana
            barOpponentHP.Maximum = _opponentInstance.MaxHP; // Set the maximum value of the HP progress bar to the opponent's Arcabeast maximum HP
            barOpponentHP.Value = _opponentInstance.CurrentHP; // Set the current value of the HP progress bar to the opponent's Arcabeast current HP
            barOpponentMana.Maximum = _opponentInstance.MaxMana; // Set the maximum value of the Mana progress bar to the opponent's Arcabeast maximum Mana
            barOpponentMana.Value = _opponentInstance.CurrentMana; // Set the current value of the Mana progress bar to the opponent's Arcabeast current Mana
            picOpponent.Image = Image.FromFile(_opponentArcabeastDef.AssetPath); // Load the image for the opponent's Arcabeast from its asset path
            lblOpponentStats.Text = $"SPD: {_opponentInstance.TempSpeed}\n" + // Set the label text to display the opponent's Arcabeast temporary stats
                            $"PWR: {_opponentInstance.TempPhysicalPower}\n" + // Set the label text to display the opponent's Arcabeast temporary physical power
                            $"ARC: {_opponentInstance.TempArcanePower}\n" + // Set the label text to display the opponent's Arcabeast temporary arcane power
                            $"DEF: {_opponentInstance.TempPhysicalDefense}\n" + // Set the label text to display the opponent's Arcabeast temporary physical defense
                            $"ARDEF: {_opponentInstance.TempArcaneDefense}\n" + // Set the label text to display the opponent's Arcabeast temporary arcane defense
                            $"EVA: {_opponentInstance.TempEvasiveness}"; // Set the label text to display the opponent's Arcabeast temporary evasiveness
            lblOpponentEffects.Text = string.Join("\n", // Set the label text to display the active effects on the opponent's Arcabeast
               _opponentInstance.ActiveEffects.Select(e => // Select each active effect and format it
               {
                   var ability = ArcabeastAbilityDB.All.FirstOrDefault(a => a.Id == e.Id); // Find the ability associated with the effect
                   string name = ability?.Name ?? e.GetType().Name; // Use the ability name if it exists, otherwise use the effect type name
                   return $"{name} ({e.RemainingTurns} turns)"; // Format the effect name and remaining turns
               })
            );
            DisplayAbilityButtons(); // Display the ability buttons for the user to select their actions
        }
        // Method to display the ability buttons based on the user's abilities and current mana
        private void DisplayAbilityButtons()
        {
            Button[] buttons = { btnAbility1, btnAbility2, btnAbility3, btnAbility4, btnAbility5 }; // Array of buttons for abilities
            var displayAbilities = new List<ArcabeastAbility>(_userAbilities); // Create a list of abilities to display, starting with the user's abilities
            // Add pseudo ability Rest (button 5)
            var restAbility = new DefensiveAbility // Create a new defensive ability for Rest
            {
                Id = Guid.Empty,
                Name = "Rest",
                ManaCost = 0,
                Type = "None",
                Class = AbilityClass.Physical,
                Duration = 0,
                BuffPercentage = 0,
                TargetStat = "None",
                Velocity = 1.0,
                CanStack = false
            };
            displayAbilities.Add(restAbility); // Add the Rest ability to the list of abilities to display
            bool hasUsable = false; // Flag to track if there are any usable abilities (excluding Rest)
            for (int i = 0; i < buttons.Length; i++) // Loop through each button to set its properties based on the abilities
            {
                if (i < displayAbilities.Count) // Check if there is an ability to display for this button
                {
                    var ability = displayAbilities[i]; // Get the ability for this button
                    bool canUse = ability.Name == "Rest" || _userInstance.CurrentMana >= ability.ManaCost; // Check if the ability can be used (Rest can always be used, others require sufficient mana)
                    buttons[i].Text = $"{ability.Name} ({ability.ManaCost})"; // Set the button text to the ability name and mana cost
                    buttons[i].Tag = ability; // Store the ability in the button's Tag property for later use
                    buttons[i].Visible = true; // Make the button visible
                    buttons[i].Enabled = canUse; // Enable the button if the ability can be used
                    if (canUse && ability.Name != "Rest") // If the ability can be used and is not Rest
                        hasUsable = true; // Set the flag to true indicating there are usable abilities
                }
                else // default case if there are no more abilities to display. this should never happen
                {
                    buttons[i].Visible = false; // Hide the button
                }
            }
            // If no usable abilities (excluding Rest),
            if (!hasUsable)
            {
                txtCombatLog.Text += $"{_userInstance.DisplayName} has no usable abilities. You need to Rest.\r\n"; // Append a message to the combat log indicating no usable abilities
            }
        }
        // Event handler for when an ability button is clicked
        private void AbilityButton_Click(object sender, EventArgs e)
        {
            txtCombatLog.Clear(); // Clear the combat log before executing the turn
            ToggleAbilityButtons(false); // Disable buttons
            var playerAbility = (ArcabeastAbility)((Button)sender).Tag; // Get the ability associated with the clicked button from its Tag property
            _battleFlow.ExecuteTurn(playerAbility, OnTurnComplete); // Execute the turn with the selected ability and a callback for when the turn is complete
        }
        // Helper method to toggle the visibility and enabled state of the ability buttons
        private void ToggleAbilityButtons(bool visible)
        {
            btnAbility1.Visible = visible; // Toggle visibility of ability button 1
            btnAbility2.Visible = visible; // Toggle visibility of ability button 2
            btnAbility3.Visible = visible; // Toggle visibility of ability button 3
            btnAbility4.Visible = visible; // Toggle visibility of ability button 4
            btnAbility1.Enabled = visible; // Toggle enabled state of ability button 1
        }
        // Method to append combat text to the combat log textbox
        public void AppendCombatText(string message)
        {
            txtCombatLog.AppendText(message + "\r\n"); // Append the message to the combat log textbox with a newline
        }
        // Method to handle the end of the turn and update the UI accordingly
        private void OnTurnComplete()
        {
            UpdateTurnLabel(); // Update the turn label to reflect the current turn number and stats
            ToggleAbilityButtons(true); // Re-enable the ability buttons for the user to select their next action
            DrawUserUI(); // Redraw the user's Arcabeast UI with the updated stats and effects
            DrawOpponentUI(); // Redraw the opponent's Arcabeast UI with the updated stats and effects
        }
        // Method to update labels and progress bars for the current turn
        private void UpdateTurnLabel()
        {
            lblTurnNumber.Text = $"Turn: {_battleContext.TurnNumber}"; // Set the label text to the current turn number
            barUserHP.Value = Math.Max(0, _userInstance.CurrentHP); // Ensure the user's HP progress bar does not go below 0
            barUserMana.Value = Math.Max(0, _userInstance.CurrentMana); // Ensure the user's Mana progress bar does not go below 0
            lblUserHP.Text = $"HP: {_userInstance.CurrentHP}/{_userInstance.MaxHP}"; // Set the label text to the user's Arcabeast current and maximum HP
            lblUserMana.Text = $"Mana: {_userInstance.CurrentMana}/{_userInstance.MaxMana}"; // Set the label text to the user's Arcabeast current and maximum Mana
            barOpponentHP.Value = Math.Max(0, _opponentInstance.CurrentHP); // Ensure the opponent's HP progress bar does not go below 0
            barOpponentMana.Value = Math.Max(0, _opponentInstance.CurrentMana); // Ensure the opponent's Mana progress bar does not go below 0
            lblOpponentHP.Text = $"HP: {_opponentInstance.CurrentHP}/{_opponentInstance.MaxHP}"; // Set the label text to the opponent's Arcabeast current and maximum HP
            lblOpponentMana.Text = $"Mana: {_opponentInstance.CurrentMana}/{_opponentInstance.MaxMana}"; // Set the label text to the opponent's Arcabeast current and maximum Mana
        }
    }
}
