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
        // Inside GameStartMenu
        private void btnPlay_Click(object sender, EventArgs e)
        {
            // Try to load or create player data
            var existingPlayerData = PlayerDataService.LoadOrCreatePlayerData();

            // If it has no UserId yet, generate and save one
            if (existingPlayerData.UserId == Guid.Empty)
            {
                existingPlayerData.UserId = Guid.NewGuid();
                PlayerDataService.SavePlayerData(existingPlayerData);
            }

            var profileForm = new UserProfileSelection();
            profileForm.FormClosed += (s, args) => this.Close(); // closes menu when done
            this.Hide();
            profileForm.Show();
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
