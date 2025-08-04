using Arcabeasts.DataLib;
using Arcabeasts.GameData;
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

            var arcabeast = ArcabeastDB.All.FirstOrDefault(a => a.Id == _profile.Arcabeast.ArcabeastId);
            if (arcabeast != null)
                backgroundImage.Image = Image.FromFile(arcabeast.AssetPath);

            LoadMoves();
        }

        private void BtnBattle_Click(object sender, EventArgs e)
        {
            var battle = new BattleArena(); // Implement separately
            battle.FormClosed += (_, __) => this.Show();
            this.Hide();
            battle.Show();
        }

        private void BtnManageMoves_Click(object sender, EventArgs e)
        {
            panelMenu.Visible = false;
            panelManageMoves.Visible = true;
        }

        private void BtnBackToMenu_Click(object sender, EventArgs e)
        {
            panelManageMoves.Visible = false;
            panelMenu.Visible = true;
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
        }

        private void SaveProfile()
        {
            PlayerDataService.UpdateUserProfile(_userId, _profileIndex, _profile);
        }
    }
}
