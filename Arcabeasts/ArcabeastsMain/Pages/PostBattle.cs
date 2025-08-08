using Arcabeasts.Combat;
using Arcabeasts.DataLib;
using System;
using System.Windows.Forms;

namespace ArcabeastsMain.Pages
{
    public partial class PostBattle : Form
    {
        private readonly bool _playerWon; // True if the player won the battle, false if they lost
        private readonly BattleContext _context; // Context containing battle and player data
        public PostBattle(BattleContext context, bool playerWon) // Constructor that initializes the form with the battle context and result
        {
            InitializeComponent(); // Initialize the form components
            _context = context; // Store the battle context for later use
            _playerWon = playerWon; // Store whether the player won or lost the battle
            LoadResult(); // Load the result of the battle into the form
        }
        // Method to load the result of the battle into the form
        private void LoadResult()
        {
            if (_playerWon) // Check if the player won the battle
            {
                lblResult.Text = "Victory!"; // Display victory message
                var playerData = PlayerDataService.LoadOrCreatePlayerData(); // Load the player's data
                var profile = playerData.UserProfiles[_context.ProfileIndex]; // Get the player's profile based on the context's profile index
                int gainedExp = PostBattleCalc.CalculateExpReward(_context.OpponentInstance.Level); // Calculate the experience points gained based on the opponent's level
                int levelBefore = profile.Arcabeast.Level; // Store the Arcabeast's level before gaining experience
                PostBattleCalc.GrantExp(profile.Arcabeast, gainedExp); // Grant the calculated experience points to the Arcabeast in the player's profile
                playerData.UserProfiles[_context.ProfileIndex] = profile; // Update the player's profile with the modified Arcabeast data
                PlayerDataService.SavePlayerData(playerData); // Save the updated player data back to the database
                int levelAfter = profile.Arcabeast.Level; // Get the Arcabeast's level after gaining experience
                string levelUpText = levelAfter > levelBefore // Check if the Arcabeast leveled up
                    ? $"Leveled up to {levelAfter}!" // If it did, display the new level
                    : "No level up."; // If it didn't, display a message indicating no level up
                lblExpInfo.Text = $"EXP Gained: {gainedExp}\n{levelUpText}"; // Display the experience gained and level up information
            }
            else // If the player lost the battle
            {
                lblResult.Text = "Defeat"; // Display defeat message
                lblExpInfo.Text = "No EXP awarded."; // Indicate that no experience points were awarded for losing the battle
            }
        }
        // Event handler for the "Continue" button click
        private void btnContinue_Click(object sender, EventArgs e)
        {
            var updatedData = PlayerDataService.LoadOrCreatePlayerData(); // Load the player's data again to ensure we have the latest information
            var updatedProfile = updatedData.UserProfiles[_context.ProfileIndex]; // Get the updated profile based on the context's profile index
            var menu = new MainGameMenu(updatedProfile, _context.ProfileIndex, _context.UserId); // Create a new MainGameMenu instance with the updated profile, profile index, and user ID
            menu.Show(); // Show the main game menu
            this.Close(); // Close the PostBattle form
        }
        // Method to handle the result of the battle and transition to the post-battle screen
        public static void HandleResult(BattleContext context, bool playerWon)
        {
            BattleContext.Current = null; // Clear the current battle context to prevent memory leaks
            var postBattle = new PostBattle(context, playerWon); // Create a new PostBattle instance with the provided context and result
            postBattle.Show(); // Show the PostBattle form to display the result of the battle
        }
    }
}
