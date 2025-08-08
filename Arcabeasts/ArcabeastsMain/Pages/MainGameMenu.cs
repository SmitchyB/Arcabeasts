using Arcabeasts.DataLib;
using Arcabeasts.GameData;
using Arcabeasts.Combat;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ArcabeastsMain.Pages
{
    public partial class MainGameMenu : Form
    {
        private readonly UserProfile _profile; // The user's profile containing their Arcabeast and moves
        private readonly int _profileIndex; // The index of the profile in the user's profile list
        private readonly Guid _userId; // The unique identifier for the user

        public MainGameMenu(UserProfile profile, int profileIndex, Guid userId)
        {
            InitializeComponent(); // Ensure this method is called after InitializeComponent
            _profile = profile; // The user's profile containing their Arcabeast and moves
            _profileIndex = profileIndex; // The index of the profile in the user's profile list
            _userId = userId; // The unique identifier for the user
            LoadArcabeastVisuals(); // Load the Arcabeast visuals and stats
            LoadMoves(); // Load the moves for the Arcabeast
        }
        // Loads the visuals and stats of the Arcabeast based on the user's profile
        private void LoadArcabeastVisuals()
        {
            var arcabeast = ArcabeastDB.All.FirstOrDefault(a => a.Id == _profile.Arcabeast.ArcabeastId); // Find the Arcabeast by its ID from the profile
            if (arcabeast == null) return; // If the Arcabeast is not found, exit the method
            if (System.IO.File.Exists(arcabeast.AssetPath)) // Check if the asset file exists
            {
                this.BackgroundImage = Image.FromFile(arcabeast.AssetPath); // Load the background image from the asset path
                this.BackgroundImageLayout = ImageLayout.Stretch; // Set the background image layout to stretch
            }
            var scaled = LevelStatCalculator.ScaleStats(arcabeast, _profile.Arcabeast.Level); // Scale the Arcabeast's stats based on its level
            string displayName = string.IsNullOrWhiteSpace(_profile.Arcabeast.CustomName) // Check if the custom name is empty or null
                ? arcabeast.Name // If it is, use the Arcabeast's default name
                : _profile.Arcabeast.CustomName; // Otherwise, use the custom name from the profile
            int currentLevel = _profile.Arcabeast.Level; // Get the current level of the Arcabeast from the profile
            int currentXP = _profile.Arcabeast.Experience; // Get the current experience points of the Arcabeast from the profile
            int xpToNextLevel = PostBattleCalc.RequiredExpForLevel(currentLevel); // Calculate the required experience points for the next level based on the current level
            lblName.Text = $"Name: {displayName}"; // Set the label text to display the Arcabeast's name
            lblLevel.Text = $"Level: {currentLevel}"; // Set the label text to display the Arcabeast's level
            lblExperience.Text = $"XP: {currentXP} / {xpToNextLevel}"; // Set the label text to display the Arcabeast's current experience points and the required points for the next level
        }
        // Event handler for the "Battle" button click
        private void BtnBattle_Click(object sender, EventArgs e)
        {
            var battle = new BattleArena(_profile, _profileIndex, _userId); // Create a new BattleArena instance with the user's profile, profile index, and user ID
            battle.FormClosed += (_, __) => this.Show(); // Show the main menu again when the battle form is closed
            this.Hide(); // Hide the main menu to show the battle arena
            battle.Show(); // Show the battle arena form
        }
        // Event handler for the "Manage Moves" button click
        private void BtnManageMoves_Click(object sender, EventArgs e)
        {
            panelMenu.Visible = false; // Hide the main menu panel
            panelManageMoves.Visible = true; // Show the manage moves panel
            LoadMoves(); // Load the moves for the Arcabeast to display in the manage moves panel
        }
        // Event handler for the "Back to Menu" button click in the manage moves panel
        private void BtnBackToMenu_Click(object sender, EventArgs e)
        {
            panelManageMoves.Visible = false; // Hide the manage moves panel
            panelMenu.Visible = true; // Show the main menu panel
            LoadMoves(); // Load the moves again to ensure the UI is updated
        }
        // Loads the moves available for the Arcabeast and displays them in the UI
        private void LoadMoves()
        {
            flowCurrentMoves.Controls.Clear(); // Clear the current moves flow layout panel
            flowAvailableMoves.Controls.Clear(); // Clear the available moves flow layout panel
            var arcabeast = ArcabeastDB.All.First(a => a.Id == _profile.Arcabeast.ArcabeastId); // Find the Arcabeast by its ID from the profile
            var learnedMoves = _profile.Arcabeast.LearnedMoveIds; // Get the list of learned move IDs from the Arcabeast in the profile
            // Determine if this Arcabeast is Prime (Prime can use any ability type)
            bool isPrime =
                (arcabeast.Type?.Equals("Prime", StringComparison.OrdinalIgnoreCase) ?? false) // True if Type string equals "Prime"
                || (arcabeast.AllowedMoveTypes?.Contains("ALL") ?? false); // Or if you use an "ALL" sentinel in AllowedMoveTypes
            var allMoves = (isPrime // If Prime, no type filtering — can see all abilities
                ? ArcabeastAbilityDB.All // All moves from the DB
                : ArcabeastAbilityDB.All.Where(a => arcabeast.AllowedMoveTypes.Contains(a.Type)) // Otherwise filter by allowed types
            ).ToList(); // Materialize to a list for iteration
            foreach (var move in allMoves) // Iterate through each move in the list
            {
                var moveButton = new Button // Create a new button for each move
                {
                    Text = move.Name, // Set the button text to the move's name
                    Width = 300, // Set the button width
                    Height = 50, // Set the button height
                    BackColor = Color.DarkSlateBlue, // Set the button background color
                    ForeColor = Color.White, // Set the button text color
                    Tag = move.Id // Store the move ID in the button's Tag property
                };
                if (learnedMoves.Contains(move.Id)) // Check if the move is already learned by the Arcabeast
                {
                    moveButton.Click += (s, e) => // If the move is learned, set up the click event to remove it
                    {
                        learnedMoves.Remove((Guid)moveButton.Tag); // Remove the move from the learned moves list
                        SaveProfile(); // Save the updated profile
                        LoadMoves(); // Reload the moves to update the UI
                    };
                    flowCurrentMoves.Controls.Add(moveButton); // Add the button to the current moves flow layout panel
                }
                else // If the move is not learned
                {
                    moveButton.Click += (s, e) => // Set up the click event to add the move
                    {
                        if (learnedMoves.Count >= 4) // Check if the user already has 4 moves learned
                        {
                            var toReplace = learnedMoves[0]; // If so, replace the first learned move (simple policy; consider a UI picker later)
                            learnedMoves.Remove(toReplace); // Remove the first learned move from the list
                        }
                        learnedMoves.Add((Guid)moveButton.Tag); // Add the new move to the learned moves list
                        SaveProfile(); // Save the updated profile
                        LoadMoves(); // Reload the moves to update the UI
                    };
                    flowAvailableMoves.Controls.Add(moveButton); // Add the button to the available moves flow layout panel
                }
            }
            lblWarning.Text = ""; // Clear the warning label text
            if (panelManageMoves.Visible) // If the manage moves panel is visible
            {
                lblWarning.Text += "💡 Click a move to add or remove it. You can equip up to 4 moves.\n"; // Add a hint about managing moves
            }
            if (learnedMoves.Count == 0) // If the user has no moves learned
            {
                lblWarning.Text += "❌ You must equip at least 1 move before you can battle."; // Add a warning about needing at least one move
                btnBattle.Enabled = false; // Disable the battle button
            }
            else if (learnedMoves.Count < 4) // If the user has less than 4 moves learned
            {
                lblWarning.Text += "⚠️ You have less than 4 moves equipped. Consider adding more."; // Add a warning about having less than 4 moves
                btnBattle.Enabled = true; // Enable the battle button
            }
            else if (learnedMoves.Count == 4) // If the user has 4 moves learned
            {
                lblWarning.Text += "✅ You have 4 moves equipped. You're ready to battle!"; // Add a confirmation message
                btnBattle.Enabled = true; // Enable the battle button
            }
        }

        // Saves the user's profile with the updated moves and Arcabeast information
        private void SaveProfile()
        {
            PlayerDataService.UpdateUserProfile(_userId, _profileIndex, _profile); // Update the user profile in the player data service with the current profile
        }
    }
}
