using Arcabeasts.DataLib;
using Arcabeasts.GameData;
using ArcabeastsMain.Pages;
using System;
using System.Windows.Forms;

namespace ArcabeastsMain
{
    public partial class GameStartMenu : Form
    {
        public GameStartMenu()
        {
            InitializeComponent();
        }
        
        //Play button click event
        private void btnPlay_Click(object sender, EventArgs e)
        {
            var existingPlayerData = PlayerDataService.LoadOrCreatePlayerData(); // Load existing player data or create a new one
            if (existingPlayerData.UserId == Guid.Empty) // Check if UserId is empty
            {
                existingPlayerData.UserId = Guid.NewGuid(); // Assign a new GUID
                PlayerDataService.SavePlayerData(existingPlayerData); // Save the updated player data
            }
            var profileForm = new UserProfileSelection(); // Create a new instance of UserProfileSelection
            profileForm.FormClosed += (s, args) => this.Show(); // Show the GameStartMenu again when UserProfileSelection is closed
            this.Hide(); // Hide the GameStartMenu
            profileForm.Show(); // Show the UserProfileSelection form
        }
        //Click event for the Exit button
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Exit the application
        }
    }
}
