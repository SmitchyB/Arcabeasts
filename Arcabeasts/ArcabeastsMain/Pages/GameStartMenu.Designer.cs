namespace ArcabeastsMain
{
    partial class GameStartMenu
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnExit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // GameStartMenu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GameStartMenu";
            this.Text = "Arcabeasts";
            this.BackgroundImage = System.Drawing.Image.FromFile(@"Assets\ArcabeastsMenu.png");
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;

            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.btnPlay.ForeColor = System.Drawing.Color.White;
            this.btnPlay.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.btnPlay.Location = new System.Drawing.Point(860, 700); // Centered horizontally
            this.btnPlay.Size = new System.Drawing.Size(200, 75);
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);

            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.btnExit.Location = new System.Drawing.Point(860, 800); // Below Play button
            this.btnExit.Size = new System.Drawing.Size(200, 75);
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);

            // 
            // Add Controls
            // 
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnExit);

            this.ResumeLayout(false);
        }
    }
}
