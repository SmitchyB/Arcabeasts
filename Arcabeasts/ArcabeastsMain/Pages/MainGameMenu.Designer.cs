namespace ArcabeastsMain.Pages
{
    partial class MainGameMenu
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnBattle;
        private System.Windows.Forms.Button btnManageMoves;
        private System.Windows.Forms.Panel panelManageMoves;
        private System.Windows.Forms.Button btnBackToMenu;
        private System.Windows.Forms.FlowLayoutPanel flowCurrentMoves;
        private System.Windows.Forms.FlowLayoutPanel flowAvailableMoves;

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label lblExperience;

        private System.Windows.Forms.Label lblWarning; // 🔥 NEW

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnBattle = new System.Windows.Forms.Button();
            this.btnManageMoves = new System.Windows.Forms.Button();
            this.panelManageMoves = new System.Windows.Forms.Panel();
            this.btnBackToMenu = new System.Windows.Forms.Button();
            this.flowCurrentMoves = new System.Windows.Forms.FlowLayoutPanel();
            this.flowAvailableMoves = new System.Windows.Forms.FlowLayoutPanel();
            this.lblName = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.lblExperience = new System.Windows.Forms.Label();
            this.lblWarning = new System.Windows.Forms.Label(); // 🔥 NEW

            this.SuspendLayout();

            // panelMenu
            this.panelMenu.BackColor = System.Drawing.Color.Transparent;
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMenu.Controls.Add(this.lblWarning); // 🔥 Add warning label first
            this.panelMenu.Controls.Add(this.btnBattle);
            this.panelMenu.Controls.Add(this.btnManageMoves);
            this.panelMenu.Controls.Add(this.lblName);
            this.panelMenu.Controls.Add(this.lblLevel);
            this.panelMenu.Controls.Add(this.lblExperience);

            // btnBattle
            this.btnBattle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.btnBattle.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.btnBattle.ForeColor = System.Drawing.Color.White;
            this.btnBattle.Location = new System.Drawing.Point(760, 750);
            this.btnBattle.Size = new System.Drawing.Size(400, 100);
            this.btnBattle.Text = "Battle";
            this.btnBattle.Click += new System.EventHandler(this.BtnBattle_Click);

            // btnManageMoves
            this.btnManageMoves.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.btnManageMoves.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.btnManageMoves.ForeColor = System.Drawing.Color.White;
            this.btnManageMoves.Location = new System.Drawing.Point(760, 880);
            this.btnManageMoves.Size = new System.Drawing.Size(400, 100);
            this.btnManageMoves.Text = "Manage Moves";
            this.btnManageMoves.Click += new System.EventHandler(this.BtnManageMoves_Click);

            // lblName
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Location = new System.Drawing.Point(50, 50);
            this.lblName.Size = new System.Drawing.Size(1000, 50);

            // lblLevel
            this.lblLevel.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.lblLevel.ForeColor = System.Drawing.Color.White;
            this.lblLevel.BackColor = System.Drawing.Color.Transparent;
            this.lblLevel.Location = new System.Drawing.Point(50, 110);
            this.lblLevel.Size = new System.Drawing.Size(600, 40);

            // lblExperience
            this.lblExperience.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.lblExperience.ForeColor = System.Drawing.Color.White;
            this.lblExperience.BackColor = System.Drawing.Color.Transparent;
            this.lblExperience.Location = new System.Drawing.Point(50, 160);
            this.lblExperience.Size = new System.Drawing.Size(800, 40);

            // lblWarning 🔥
            // lblWarning 🔧 Adjusted just above bottom
            this.lblWarning.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblWarning.ForeColor = System.Drawing.Color.Yellow;
            this.lblWarning.BackColor = System.Drawing.Color.Transparent;
            this.lblWarning.Size = new System.Drawing.Size(1000, 60);
            this.lblWarning.Location = new System.Drawing.Point(460, 1000 - 20); // manually moved up by 20px
            this.lblWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;



            // panelManageMoves
            this.panelManageMoves.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            this.panelManageMoves.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelManageMoves.Visible = false;
            this.panelManageMoves.Controls.Add(this.lblWarning); // 🔥 Add warning label here too
            this.panelManageMoves.Controls.Add(this.btnBackToMenu);
            this.panelManageMoves.Controls.Add(this.flowCurrentMoves);
            this.panelManageMoves.Controls.Add(this.flowAvailableMoves);

            // btnBackToMenu
            this.btnBackToMenu.Text = "Back";
            this.btnBackToMenu.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnBackToMenu.BackColor = System.Drawing.Color.Gray;
            this.btnBackToMenu.ForeColor = System.Drawing.Color.White;
            this.btnBackToMenu.Size = new System.Drawing.Size(200, 60);
            this.btnBackToMenu.Location = new System.Drawing.Point(20, 20);
            this.btnBackToMenu.Click += new System.EventHandler(this.BtnBackToMenu_Click);

            // flowCurrentMoves
            this.flowCurrentMoves.Location = new System.Drawing.Point(100, 100);
            this.flowCurrentMoves.Size = new System.Drawing.Size(800, 850);
            this.flowCurrentMoves.AutoScroll = true;

            // flowAvailableMoves
            this.flowAvailableMoves.Location = new System.Drawing.Point(1020, 100);
            this.flowAvailableMoves.Size = new System.Drawing.Size(800, 850);
            this.flowAvailableMoves.AutoScroll = true;

            // MainGameMenu
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.panelManageMoves);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainGameMenu";
            this.Text = "Main Game Menu";

            this.ResumeLayout(false);
        }
    }
}
