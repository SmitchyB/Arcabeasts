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
    public partial class UserProfileSelection : Form
    {
        private readonly PlayerData _playerData;
        private ArcabeastDefinition _selectedArcabeast;
        private int _currentProfileIndex;

        public UserProfileSelection()
        {
            InitializeComponent();
            this.Size = new Size(1920, 1080);
            _playerData = PlayerDataService.LoadOrCreatePlayerData();
            CenterFlowProfileSlots();
            LoadProfiles();
        }

        private void CenterFlowProfileSlots()
        {
            flowProfileSlots.Location = new Point(
                (this.ClientSize.Width - flowProfileSlots.Width) / 2,
                (this.ClientSize.Height - flowProfileSlots.Height) / 2
            );
        }

        private void LoadProfiles()
        {
            flowProfileSlots.Controls.Clear();
            for (int i = 0; i < 3; i++)
            {
                var profile = _playerData.UserProfiles.ElementAtOrDefault(i);
                Panel box = new Panel
                {
                    Size = new Size(300, 180),
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(50),
                    BackColor = Color.FromArgb(32, 32, 32),
                    Cursor = Cursors.Hand
                };

                int index = i;

                if (profile == null)
                {
                    var label = new Label { Text = "Create New", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, ForeColor = Color.White };
                    box.Controls.Add(label);
                    AttachClick(box, () => ShowSelectionScreen(index));
                }
                else
                {
                    Console.WriteLine($"Looking for ArcabeastId: {profile.Arcabeast.ArcabeastId}");
                    foreach (var a in ArcabeastDB.All)
                        Console.WriteLine($"Arcabeast in DB: {a.Id} - {a.Name}");

                    var arcabeast = ArcabeastDB.All.FirstOrDefault(a => a.Id == profile.Arcabeast.ArcabeastId);
                    if (arcabeast == null)
                    {
                        var label = new Label { Text = "Invalid Arcabeast", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, ForeColor = Color.Red };
                        box.Controls.Add(label);
                        AttachClick(box, () => LoadProfile(index));
                        flowProfileSlots.Controls.Add(box);
                        continue;
                    }

                    var name = new Label { Text = profile.PlayerName, Dock = DockStyle.Top, TextAlign = ContentAlignment.MiddleCenter, ForeColor = Color.White };
                    var level = new Label { Text = "Lvl: " + profile.Arcabeast.Level, Dock = DockStyle.Bottom, TextAlign = ContentAlignment.MiddleCenter, ForeColor = Color.White };
                    var pic = new PictureBox
                    {
                        ImageLocation = arcabeast.AssetPath,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Dock = DockStyle.Fill
                    };
                    box.Controls.Add(name);
                    box.Controls.Add(pic);
                    box.Controls.Add(level);
                    AttachClick(box, () => LoadProfile(index));
                }
                flowProfileSlots.Controls.Add(box);
            }
        }

        private void AttachClick(Control control, Action clickAction)
        {
            control.Click += (_, __) => clickAction();
            foreach (Control child in control.Controls)
                AttachClick(child, clickAction);
        }

        private void ShowSelectionScreen(int profileIndex)
        {
            _currentProfileIndex = profileIndex;
            flowProfileSlots.Visible = false;
            panelSelectionScreen.Visible = true;
            panelSummary.Visible = false;
            LoadArcabeastOptions();
        }

        private void LoadArcabeastOptions()
        {
            flowArcabeastSelection.Controls.Clear();
            foreach (var beast in ArcabeastDB.All)
            {
                var panel = new Panel
                {
                    Size = new Size(120, 140),
                    Margin = new Padding(10),
                    BackColor = Color.FromArgb(32, 32, 32)
                };

                var pic = new PictureBox
                {
                    ImageLocation = beast.AssetPath,
                    Size = new Size(120, 100),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    BorderStyle = BorderStyle.FixedSingle,
                    Cursor = Cursors.Hand,
                    Tag = beast
                };
                pic.Click += (s, e) => SelectArcabeast((ArcabeastDefinition)pic.Tag);

                var label = new Label
                {
                    Text = beast.Name,
                    Dock = DockStyle.Bottom,
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = Color.White
                };

                panel.Controls.Add(pic);
                panel.Controls.Add(label);
                AttachClick(panel, () => SelectArcabeast(beast));
                flowArcabeastSelection.Controls.Add(panel);
            }
        }

        private void SelectArcabeast(ArcabeastDefinition beast)
        {
            _selectedArcabeast = beast;
            foreach (Panel panel in flowArcabeastSelection.Controls)
            {
                if (panel.Controls[0] is PictureBox pb)
                    pb.BorderStyle = ((ArcabeastDefinition)pb.Tag == beast) ? BorderStyle.Fixed3D : BorderStyle.FixedSingle;
            }
            ValidateNextButton();
        }

        private void ValidateNextButton()
        {
            btnNext.Enabled = _selectedArcabeast != null && !string.IsNullOrWhiteSpace(txtPlayerName.Text);
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            string playerName = txtPlayerName.Text.Trim();
            string customName = string.IsNullOrWhiteSpace(txtCustomName.Text) ? _selectedArcabeast.Name : txtCustomName.Text.Trim();

            lblSummary.Text = $"Player Name: {playerName}\nArcabeast: {customName} (Level 1)\nType: {_selectedArcabeast.Type}";
            panelSelectionScreen.Visible = false;
            panelSummary.Visible = true;
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            var newProfile = new UserProfile
            {
                PlayerName = txtPlayerName.Text.Trim(),
                Arcabeast = new PlayerArcabeast
                {
                    ArcabeastId = _selectedArcabeast.Id,
                    CustomName = string.IsNullOrWhiteSpace(txtCustomName.Text) ? _selectedArcabeast.Name : txtCustomName.Text.Trim(),
                    Level = 1,
                    Experience = 0,
                    LearnedMoveIds = new List<Guid>()
                }
            };

            if (_playerData.UserProfiles.Count < 3)
                _playerData.UserProfiles.Add(newProfile);
            else return;

            PlayerDataService.SavePlayerData(_playerData);
            LoadProfile(_playerData.UserProfiles.Count - 1);
        }

        private void LoadProfile(int index)
        {
            var selectedProfile = _playerData.UserProfiles[index];
            var mainMenu = new MainGameMenu(selectedProfile, index, _playerData.UserId);
            mainMenu.FormClosed += (_, __) => this.Show();
            this.Hide();
            mainMenu.Show();
        }


        private void BtnBackToProfiles_Click(object sender, EventArgs e)
        {
            panelSelectionScreen.Visible = false;
            flowProfileSlots.Visible = true;
            panelSummary.Visible = false;
            _selectedArcabeast = null;
        }

        private void TxtPlayerName_TextChanged(object sender, EventArgs e)
        {
            ValidateNextButton();
        }
    }
}

