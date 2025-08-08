namespace ArcabeastsMain
{
    partial class GameStartMenu
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnExit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // ======= THEME PALETTE =======
            // Primary Accent (Gold)
            System.Drawing.Color gold = System.Drawing.Color.FromArgb(212, 175, 55);     // #D4AF37
            // Secondary Accent (Muted Bronze)
            System.Drawing.Color bronze = System.Drawing.Color.FromArgb(161, 126, 52);   // #A17E34
            // Hover/Darker Bronze
            System.Drawing.Color bronzeDark = System.Drawing.Color.FromArgb(120, 95, 40);
            // Muted Silver (UI text / borders)
            System.Drawing.Color mutedSilver = System.Drawing.Color.FromArgb(192, 192, 192); // #C0C0C0
            // Deep text on gold
            System.Drawing.Color nearBlack = System.Drawing.Color.FromArgb(20, 20, 20);

            // ======= FORM =======
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Name = "GameStartMenu";
            this.Text = "Arcabeasts";
            // Keep your image background; update path if yours differs.
            this.BackgroundImage = System.Drawing.Image.FromFile(@"Assets\ArcabeastsMenu.png");
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MaximizeBox = false; // already maximized; avoid weird resize flicker

            // ======= BUTTON: PLAY =======
            this.btnPlay.BackColor = gold;
            this.btnPlay.ForeColor = mutedSilver; // silver text
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlay.FlatAppearance.BorderSize = 1;
            this.btnPlay.FlatAppearance.BorderColor = mutedSilver;
            this.btnPlay.FlatAppearance.MouseOverBackColor = bronze;
            this.btnPlay.FlatAppearance.MouseDownBackColor = bronzeDark;
            this.btnPlay.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.btnPlay.Location = new System.Drawing.Point(860, 700);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(200, 75);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);

            // ======= BUTTON: EXIT =======
            this.btnExit.BackColor = gold; // same gold as Play
            this.btnExit.ForeColor = mutedSilver; // also silver text for consistency
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.FlatAppearance.BorderSize = 1;
            this.btnExit.FlatAppearance.BorderColor = mutedSilver;
            this.btnExit.FlatAppearance.MouseOverBackColor = bronze;
            this.btnExit.FlatAppearance.MouseDownBackColor = bronzeDark;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.btnExit.Location = new System.Drawing.Point(860, 800);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(200, 70);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);


            // ======= ADD CONTROLS =======
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnExit);

            this.ResumeLayout(false);
        }
    }
}

