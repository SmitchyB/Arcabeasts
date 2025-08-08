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
        private readonly PlayerData _playerData; // Stores the player data loaded from or created in the PlayerDataService
        private ArcabeastDefinition _selectedArcabeast; // Stores the currently selected Arcabeast definition
        private int _currentProfileIndex; // Index of the currently selected profile for operations like creating or loading a profile

        public UserProfileSelection()
        {
            InitializeComponent();
            _playerData = PlayerDataService.LoadOrCreatePlayerData();
            LoadProfiles();

            this.Load += new EventHandler(UserProfileSelection_Load);
        }

        private void UserProfileSelection_Load(object sender, EventArgs e)
        {
            CenterFlowProfileSlots();
        }

        // Helps center the flow layout panel containing profile slots in the middle of the form
        private void CenterFlowProfileSlots()
        {
            flowProfileSlots.Location = new Point(
              (this.ClientSize.Width - flowProfileSlots.Width) / 2, // Center horizontally
                  (this.ClientSize.Height - flowProfileSlots.Height) / 2 // Center vertically
              );
        }
        // Loads the user profiles into the flow layout panel
        private void LoadProfiles()
        {
            flowProfileSlots.Controls.Clear(); // Clear existing controls in the flow layout panel
            for (int i = 0; i < 3; i++) // Loop through the maximum number of profiles (3)
            {
                var profile = _playerData.UserProfiles.ElementAtOrDefault(i); // Get the profile at index i, or null if it doesn't exist
                Panel box = new Panel // Create a new panel for each profile slot and set styling
                {
                    Size = new Size(500, 500), // Set the size of the panel
                    BorderStyle = BorderStyle.FixedSingle, // Set the border style to fixed single
                    Margin = new Padding(50), // Set the margin around the panel
                    BackColor = Color.FromArgb(32, 32, 32), // Set the background color of the panel
                    Cursor = Cursors.Hand // Set the cursor to hand when hovering over the panel
                };

                int index = i; //Capture the current index for the click event

                // If the profile is null, create a label prompting to create a new profile
                if (profile == null)
                {
                    var label = new Label { Text = "Create New", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, ForeColor = Color.White }; // Create a label for the "Create New" profile slot
                    box.Controls.Add(label); // Add the label to the panel
                    AttachClick(box, () => ShowSelectionScreen(index)); // Attach a click event to the panel that shows the selection screen for creating a new profile
                }
                else // If the profile exists, display the profile information
                {
                    var arcabeast = ArcabeastDB.All.FirstOrDefault(a => a.Id == profile.Arcabeast.ArcabeastId); // Get the Arcabeast definition for the profile's Arcabeast ID
                    if (arcabeast == null) // If the Arcabeast definition is not found, display an error label
                    {
                        var label = new Label { Text = "Invalid Arcabeast", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter, ForeColor = Color.Red }; // Create a label for invalid Arcabeast
                        box.Controls.Add(label); // Add the label to the panel
                        AttachClick(box, () => LoadProfile(index)); // Attach a click event to the panel that loads the profile
                        flowProfileSlots.Controls.Add(box); // Add the panel to the flow layout panel
                        continue; // Skip to the next iteration if Arcabeast is invalid
                    }
                    var name = new Label { Text = profile.PlayerName, Dock = DockStyle.Top, TextAlign = ContentAlignment.MiddleCenter, ForeColor = Color.White }; // Create a label for the player's name
                    var level = new Label { Text = "Lvl: " + profile.Arcabeast.Level, Dock = DockStyle.Bottom, TextAlign = ContentAlignment.MiddleCenter, ForeColor = Color.White }; // Create a label for the Arcabeast's level
                    var pic = new PictureBox // Create a PictureBox to display the Arcabeast's image
                    {
                        ImageLocation = arcabeast.AssetPath, // Set the image location to the Arcabeast's asset path
                        SizeMode = PictureBoxSizeMode.StretchImage, // Set the size mode to stretch the image
                        Dock = DockStyle.Fill // Fill the panel with the image
                    };
                    box.Controls.Add(name); // Add the player's name label to the panel
                    box.Controls.Add(pic); // Add the arcabeast image to the panel
                    box.Controls.Add(level); // Add the Arcabeast's level label to the panel
                    AttachClick(box, () => LoadProfile(index)); // Attach a click event to the panel that loads the profile when clicked
                }
                flowProfileSlots.Controls.Add(box); // Add the panel to the flow layout panel
            }
        }
        // Attaches a click event to a control and all its child controls
        private void AttachClick(Control control, Action clickAction)
        {
            control.Click += (_, __) => clickAction(); // Attach the click event to the control
            foreach (Control child in control.Controls) // Iterate through all child controls
                AttachClick(child, clickAction); // Recursively attach the click event to each child control
        }
        // Shows the selection screen for creating a new profile or selecting an existing one
        private void ShowSelectionScreen(int profileIndex)
        {
            _currentProfileIndex = profileIndex; // Store the index of the profile being created or selected
            flowProfileSlots.Visible = false; // Hide the flow layout panel containing profile slots
            panelSelectionScreen.Visible = true; // Show the selection screen panel
            panelSummary.Visible = false; // Hide the summary panel
            LoadArcabeastOptions(); // Load the available Arcabeast options into the selection screen
        }
        // Loads the available Arcabeast options into the selection screen
        private void LoadArcabeastOptions()
        {
            flowArcabeastSelection.Controls.Clear(); // Clear any existing controls in the Arcabeast selection flow layout panel
            foreach (var beast in ArcabeastDB.All) // Iterate through all Arcabeast definitions in the database
            {
                var panel = new Panel // Create a new panel for each Arcabeast option
                {
                    Size = new Size(120, 140), // Set the size of the panel
                    Margin = new Padding(10), // Set the margin around the panel
                    BackColor = Color.FromArgb(32, 32, 32) // Set the background color of the panel
                };
                var pic = new PictureBox // Create a PictureBox to display the Arcabeast's image
                {
                    ImageLocation = beast.AssetPath, // Set the image location to the Arcabeast's asset path
                    Size = new Size(120, 120), // Set the size of the PictureBox
                    SizeMode = PictureBoxSizeMode.StretchImage, // Set the size mode to stretch the image
                    BorderStyle = BorderStyle.FixedSingle, // Set the border style to fixed single
                    Cursor = Cursors.Hand, // Set the cursor to hand when hovering over the PictureBox
                    Tag = beast // Store the Arcabeast definition in the Tag property of the PictureBox
                };
                pic.Click += (s, e) => SelectArcabeast((ArcabeastDefinition)pic.Tag); // Attach a click event to the PictureBox that selects the Arcabeast when clicked
                var label = new Label // Create a label to display the Arcabeast's name
                {
                    Text = beast.Name, // Set the text of the label to the Arcabeast's name
                    Dock = DockStyle.Bottom, // Set the label to dock at the bottom of the panel
                    TextAlign = ContentAlignment.MiddleCenter, // Set the text alignment to center
                    ForeColor = Color.White // Set the text color to white
                };
                panel.Controls.Add(pic); // Add the PictureBox to the panel
                panel.Controls.Add(label); // Add the label to the panel
                AttachClick(panel, () => SelectArcabeast(beast)); // Attach a click event to the panel that selects the Arcabeast when clicked
                flowArcabeastSelection.Controls.Add(panel); // Add the panel to the Arcabeast selection flow layout panel
            }
        }
        // Selects an Arcabeast and updates the UI to reflect the selection
        private void SelectArcabeast(ArcabeastDefinition beast)
        {
            _selectedArcabeast = beast; // Store the selected Arcabeast definition
            foreach (Panel panel in flowArcabeastSelection.Controls) // Iterate through all panels in the Arcabeast selection flow layout panel
            {
                if (panel.Controls[0] is PictureBox pb) // Check if the first control in the panel is a PictureBox
                    pb.BorderStyle = ((ArcabeastDefinition)pb.Tag == beast) ? BorderStyle.Fixed3D : BorderStyle.FixedSingle; // Set the border style to Fixed3D if the Arcabeast is selected, otherwise set it to FixedSingle
            }
            ValidateNextButton(); // Validate the Next button to enable or disable it based on the selection and player name input
        }
        // Validates the Next button to enable or disable it based on the selected Arcabeast and player name input
        private void ValidateNextButton()
        {
            btnNext.Enabled = _selectedArcabeast != null && !string.IsNullOrWhiteSpace(txtPlayerName.Text); // Enable the Next button if an Arcabeast is selected and the player name is not empty
        }
        // Event handlers for next button click
        private void BtnNext_Click(object sender, EventArgs e)
        {
            string playerName = txtPlayerName.Text.Trim(); // Get the player name from the text box and trim any whitespace
            string customName = string.IsNullOrWhiteSpace(txtCustomName.Text) ? _selectedArcabeast.Name : txtCustomName.Text.Trim(); // Get the custom name from the text box or use the Arcabeast's name if the custom name is empty

            lblSummary.Text = $"Player Name: {playerName}\nArcabeast: {customName} (Level 1)\nType: {_selectedArcabeast.Type}"; // Set the summary label text with the player name, custom Arcabeast name, and Arcabeast type
            panelSelectionScreen.Visible = false; // Hide the selection screen panel
            panelSummary.Visible = true; // Show the summary panel
        }
        // Event handler for the confirm button click
        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            var newProfile = new UserProfile // Create a new UserProfile with the player name and Arcabeast details
            {
                PlayerName = txtPlayerName.Text.Trim(), // Get the player name from the text box and trim any whitespace
                Arcabeast = new PlayerArcabeast // Create a new PlayerArcabeast with the selected Arcabeast ID, custom name, level, experience, and learned moves
                {
                    ArcabeastId = _selectedArcabeast.Id, // Set the Arcabeast ID to the selected Arcabeast's ID
                    CustomName = string.IsNullOrWhiteSpace(txtCustomName.Text) ? _selectedArcabeast.Name : txtCustomName.Text.Trim(), // Set the custom name to the text box input or the Arcabeast's name if the input is empty
                    Level = 1, // Set the initial level to 1
                    Experience = 0, // Set the initial experience to 0
                    LearnedMoveIds = new List<Guid>() // Initialize an empty list of learned move IDs
                }
            };
            if (_playerData.UserProfiles.Count < 3) // Check if the player has less than 3 profiles
                _playerData.UserProfiles.Add(newProfile); // Add the new profile to the player's profiles
            else return; // If the player already has 3 profiles, do not add a new one
            PlayerDataService.SavePlayerData(_playerData); // Save the updated player data with the new profile
            LoadProfile(_playerData.UserProfiles.Count - 1); // Load the newly created profile by its index
        }
        // Loads the selected profile by its index and navigates to the main game menu
        private void LoadProfile(int index)
        {
            var selectedProfile = _playerData.UserProfiles[index]; // Get the selected profile by its index
            var mainMenu = new MainGameMenu(selectedProfile, index, _playerData.UserId); // Create a new MainGameMenu with the selected profile, its index, and the user's ID
            mainMenu.FormClosed += (_, __) => this.Show(); // Show the UserProfileSelection form again when the MainGameMenu is closed
            this.Hide(); // Hide the UserProfileSelection form
            mainMenu.Show(); // Show the MainGameMenu form
        }
        // Event handler for the Back button click to return to the profile selection screen
        private void BtnBackToProfiles_Click(object sender, EventArgs e)
        {
            panelSelectionScreen.Visible = false; // Hide the selection screen panel
            flowProfileSlots.Visible = true; // Show the flow layout panel containing profile slots
            panelSummary.Visible = false; // Hide the summary panel
            _selectedArcabeast = null; // Reset the selected Arcabeast to null
        }
        // Event handler for the player name text box text changed event to validate the Next button
        private void TxtPlayerName_TextChanged(object sender, EventArgs e)
        {
            ValidateNextButton(); // Validate the Next button to enable or disable it based on the selected Arcabeast and player name input
        }
    }
}

