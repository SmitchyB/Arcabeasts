using Arcabeasts.Combat;
using Arcabeasts.DataLib;
using System;
using System.Windows.Forms;

namespace ArcabeastsMain.Pages
{
    public partial class PostBattle : Form
    {
        private readonly bool _playerWon;
        private readonly BattleContext _context;

        public PostBattle(BattleContext context, bool playerWon)
        {
            InitializeComponent();
            _context = context;
            _playerWon = playerWon;
            LoadResult();
        }

        private void LoadResult()
        {
            if (_playerWon)
            {
                lblResult.Text = "Victory!";

                var playerData = PlayerDataService.LoadOrCreatePlayerData();
                var profile = playerData.UserProfiles[_context.ProfileIndex];

                int gainedExp = PostBattleCalc.CalculateExpReward(_context.OpponentInstance.Level);
                int levelBefore = profile.Arcabeast.Level;

                PostBattleCalc.GrantExp(profile.Arcabeast, gainedExp);

                // Replace the profile and save
                playerData.UserProfiles[_context.ProfileIndex] = profile;
                PlayerDataService.SavePlayerData(playerData);

                int levelAfter = profile.Arcabeast.Level;
                string levelUpText = levelAfter > levelBefore
                    ? $"Leveled up to {levelAfter}!"
                    : "No level up.";

                lblExpInfo.Text = $"EXP Gained: {gainedExp}\n{levelUpText}";
            }
            else
            {
                lblResult.Text = "Defeat";
                lblExpInfo.Text = "No EXP awarded.";
            }
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            var updatedData = PlayerDataService.LoadOrCreatePlayerData();
            var updatedProfile = updatedData.UserProfiles[_context.ProfileIndex];
            var menu = new MainGameMenu(updatedProfile, _context.ProfileIndex, _context.UserId);
            menu.Show();
            this.Close();

        }


        public static void HandleResult(BattleContext context, bool playerWon)
        {
            BattleContext.Current = null;
            var postBattle = new PostBattle(context, playerWon);
            postBattle.Show();
        }
    }
}
