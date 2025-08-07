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
        private readonly UserProfile _profile;
        private readonly int _profileIndex;
        private readonly Guid _userId;

        public MainGameMenu(UserProfile profile, int profileIndex, Guid userId)
        {
            InitializeComponent();
            _profile = profile;
            _profileIndex = profileIndex;
            _userId = userId;

            LoadArcabeastVisuals();
            LoadMoves();
        }

        private void LoadArcabeastVisuals()
        {
            var arcabeast = ArcabeastDB.All.FirstOrDefault(a => a.Id == _profile.Arcabeast.ArcabeastId);
            if (arcabeast == null) return;

            if (System.IO.File.Exists(arcabeast.AssetPath))
            {
                this.BackgroundImage = Image.FromFile(arcabeast.AssetPath);
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }

            var scaled = LevelStatCalculator.ScaleStats(arcabeast, _profile.Arcabeast.Level);

            string displayName = string.IsNullOrWhiteSpace(_profile.Arcabeast.CustomName)
                ? arcabeast.Name
                : _profile.Arcabeast.CustomName;

            int currentLevel = _profile.Arcabeast.Level;
            int currentXP = _profile.Arcabeast.Experience;
            int xpToNextLevel = PostBattleCalc.RequiredExpForLevel(currentLevel);

            lblName.Text = $"Name: {displayName}";
            lblLevel.Text = $"Level: {currentLevel}";
            lblExperience.Text = $"XP: {currentXP} / {xpToNextLevel}";
        }

        private void BtnBattle_Click(object sender, EventArgs e)
        {
            var battle = new BattleArena(_profile, _profileIndex, _userId);
            battle.FormClosed += (_, __) => this.Show();
            this.Hide();
            battle.Show();
        }

        private void BtnManageMoves_Click(object sender, EventArgs e)
        {
            panelMenu.Visible = false;
            panelManageMoves.Visible = true;
            LoadMoves(); // Update warning
        }

        private void BtnBackToMenu_Click(object sender, EventArgs e)
        {
            panelManageMoves.Visible = false;
            panelMenu.Visible = true;
            LoadMoves(); // Update warning
        }

        private void LoadMoves()
        {
            flowCurrentMoves.Controls.Clear();
            flowAvailableMoves.Controls.Clear();

            var arcabeast = ArcabeastDB.All.First(a => a.Id == _profile.Arcabeast.ArcabeastId);
            var learnedMoves = _profile.Arcabeast.LearnedMoveIds;
            var allMoves = ArcabeastAbilityDB.All
                .Where(a => arcabeast.AllowedMoveTypes.Contains(a.Type))
                .ToList();

            foreach (var move in allMoves)
            {
                var moveButton = new Button
                {
                    Text = move.Name,
                    Width = 300,
                    Height = 50,
                    BackColor = Color.DarkSlateBlue,
                    ForeColor = Color.White,
                    Tag = move.Id
                };

                if (learnedMoves.Contains(move.Id))
                {
                    moveButton.Click += (s, e) =>
                    {
                        learnedMoves.Remove((Guid)moveButton.Tag);
                        SaveProfile();
                        LoadMoves();
                    };
                    flowCurrentMoves.Controls.Add(moveButton);
                }
                else
                {
                    moveButton.Click += (s, e) =>
                    {
                        if (learnedMoves.Count >= 4)
                        {
                            var toReplace = learnedMoves[0];
                            learnedMoves.Remove(toReplace);
                        }

                        learnedMoves.Add((Guid)moveButton.Tag);
                        SaveProfile();
                        LoadMoves();
                    };
                    flowAvailableMoves.Controls.Add(moveButton);
                }
            }

            // Update warning text
            lblWarning.Text = "";

            if (panelManageMoves.Visible)
            {
                lblWarning.Text += "💡 Click a move to add or remove it. You can equip up to 4 moves.\n";
            }

            if (learnedMoves.Count == 0)
            {
                lblWarning.Text += "❌ You must equip at least 1 move before you can battle.";
                btnBattle.Enabled = false;
            }
            else if (learnedMoves.Count < 4)
            {
                lblWarning.Text += "⚠️ You have less than 4 moves equipped. Consider adding more.";
                btnBattle.Enabled = true;
            }
            else
            {
                btnBattle.Enabled = true;
            }
        }

        private void SaveProfile()
        {
            PlayerDataService.UpdateUserProfile(_userId, _profileIndex, _profile);
        }
    }
}
