namespace ArcabeastsMain.Pages
{
    partial class MainGameMenu
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox backgroundImage;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnBattle;
        private System.Windows.Forms.Button btnManageMoves;
        private System.Windows.Forms.Panel panelManageMoves;
        private System.Windows.Forms.Button btnBackToMenu;
        private System.Windows.Forms.FlowLayoutPanel flowCurrentMoves;
        private System.Windows.Forms.FlowLayoutPanel flowAvailableMoves;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.backgroundImage = new System.Windows.Forms.PictureBox();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnBattle = new System.Windows.Forms.Button();
            this.btnManageMoves = new System.Windows.Forms.Button();
            this.panelManageMoves = new System.Windows.Forms.Panel();
            this.btnBackToMenu = new System.Windows.Forms.Button();
            this.flowCurrentMoves = new System.Windows.Forms.FlowLayoutPanel();
            this.flowAvailableMoves = new System.Windows.Forms.FlowLayoutPanel();

            ((System.ComponentModel.ISupportInitialize)(this.backgroundImage)).BeginInit();
            this.SuspendLayout();

            // backgroundImage
            this.backgroundImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backgroundImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

            // panelMenu
            this.panelMenu.BackColor = System.Drawing.Color.Transparent;
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMenu.Controls.Add(this.btnBattle);
            this.panelMenu.Controls.Add(this.btnManageMoves);

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

            // panelManageMoves
            this.panelManageMoves.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            this.panelManageMoves.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelManageMoves.Visible = false;
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
            this.Controls.Add(this.backgroundImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainGameMenu";
            this.Text = "Main Game Menu";

            ((System.ComponentModel.ISupportInitialize)(this.backgroundImage)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
