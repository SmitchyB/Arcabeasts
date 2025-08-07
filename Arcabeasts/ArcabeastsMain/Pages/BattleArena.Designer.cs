namespace ArcabeastsMain.Pages
{
    partial class BattleArena
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox picUser;
        private System.Windows.Forms.PictureBox picOpponent;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblUserLevel;
        private System.Windows.Forms.Label lblUserHP;
        private System.Windows.Forms.Label lblUserMana;
        private System.Windows.Forms.Label lblOpponentName;
        private System.Windows.Forms.Label lblOpponentLevel;
        private System.Windows.Forms.Label lblOpponentHP;
        private System.Windows.Forms.Label lblOpponentMana;
        private System.Windows.Forms.Label lblTurnNumber;
        private System.Windows.Forms.ProgressBar barUserHP;
        private System.Windows.Forms.ProgressBar barUserMana;
        private System.Windows.Forms.ProgressBar barOpponentHP;
        private System.Windows.Forms.ProgressBar barOpponentMana;
        private System.Windows.Forms.Button btnAbility1;
        private System.Windows.Forms.Button btnAbility2;
        private System.Windows.Forms.Button btnAbility3;
        private System.Windows.Forms.Button btnAbility4;
        private System.Windows.Forms.Button btnAbility5;
        private System.Windows.Forms.Label lblUserStats;
        private System.Windows.Forms.Label lblOpponentStats;
        private System.Windows.Forms.Label lblUserEffects;
        private System.Windows.Forms.Label lblOpponentEffects;
        private System.Windows.Forms.TextBox txtCombatLog;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picUser = new System.Windows.Forms.PictureBox();
            this.picOpponent = new System.Windows.Forms.PictureBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblUserLevel = new System.Windows.Forms.Label();
            this.lblUserHP = new System.Windows.Forms.Label();
            this.lblUserMana = new System.Windows.Forms.Label();
            this.lblOpponentName = new System.Windows.Forms.Label();
            this.lblOpponentLevel = new System.Windows.Forms.Label();
            this.lblOpponentHP = new System.Windows.Forms.Label();
            this.lblOpponentMana = new System.Windows.Forms.Label();
            this.lblTurnNumber = new System.Windows.Forms.Label();
            this.barUserHP = new System.Windows.Forms.ProgressBar();
            this.barUserMana = new System.Windows.Forms.ProgressBar();
            this.barOpponentHP = new System.Windows.Forms.ProgressBar();
            this.barOpponentMana = new System.Windows.Forms.ProgressBar();
            this.btnAbility1 = new System.Windows.Forms.Button();
            this.btnAbility2 = new System.Windows.Forms.Button();
            this.btnAbility3 = new System.Windows.Forms.Button();
            this.btnAbility4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOpponent)).BeginInit();
            this.SuspendLayout();

            // Form
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Text = "BattleArena";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            // Turn Label
            this.lblTurnNumber.Location = new System.Drawing.Point(860, 20);
            this.lblTurnNumber.Size = new System.Drawing.Size(200, 30);
            this.lblTurnNumber.ForeColor = System.Drawing.Color.White;
            this.lblTurnNumber.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTurnNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // User Side
            this.lblUserName.Location = new System.Drawing.Point(100, 50);
            this.lblUserName.ForeColor = System.Drawing.Color.White;
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblUserName.Size = new System.Drawing.Size(200, 30);

            this.lblUserLevel.Location = new System.Drawing.Point(100, 80);
            this.lblUserLevel.ForeColor = System.Drawing.Color.White;
            this.lblUserLevel.Size = new System.Drawing.Size(200, 20);

            this.barUserHP.Location = new System.Drawing.Point(100, 110);
            this.barUserHP.Size = new System.Drawing.Size(300, 20);
            this.barUserHP.ForeColor = System.Drawing.Color.Lime;

            this.lblUserHP.Location = new System.Drawing.Point(100, 135);
            this.lblUserHP.ForeColor = System.Drawing.Color.White;
            this.lblUserHP.Size = new System.Drawing.Size(200, 20);

            this.barUserMana.Location = new System.Drawing.Point(100, 160);
            this.barUserMana.Size = new System.Drawing.Size(300, 20);
            this.barUserMana.ForeColor = System.Drawing.Color.DodgerBlue;

            this.lblUserMana.Location = new System.Drawing.Point(100, 185);
            this.lblUserMana.ForeColor = System.Drawing.Color.White;
            this.lblUserMana.Size = new System.Drawing.Size(200, 20);

            this.picUser.Location = new System.Drawing.Point(100, 210);
            this.picUser.Size = new System.Drawing.Size(300, 300);
            this.picUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            // User Stats Label
            this.lblUserStats = new System.Windows.Forms.Label();
            this.lblUserStats.Location = new System.Drawing.Point(100, 520); // BELOW the picUser (Y=210 + 300)
            this.lblUserStats.Size = new System.Drawing.Size(300, 120);
            this.lblUserStats.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblUserStats.ForeColor = System.Drawing.Color.White;
            this.lblUserStats.BackColor = System.Drawing.Color.Transparent;
            this.lblUserStats.Text = "Stats";
            this.Controls.Add(this.lblUserStats);

            //User Active Effects
            this.lblUserEffects = new System.Windows.Forms.Label();
            this.lblUserEffects.Location = new System.Drawing.Point(100, 650); // Adjusted below stats
            this.lblUserEffects.Size = new System.Drawing.Size(300, 200);
            this.lblUserEffects.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblUserEffects.ForeColor = System.Drawing.Color.LightGreen;
            this.lblUserEffects.BackColor = System.Drawing.Color.Transparent;
            this.lblUserEffects.Text = "Effects";
            this.Controls.Add(this.lblUserEffects);

            //Combat Log
            this.txtCombatLog = new System.Windows.Forms.TextBox();
            this.txtCombatLog.Multiline = true;
            this.txtCombatLog.ReadOnly = true;
            this.txtCombatLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCombatLog.Location = new System.Drawing.Point(650, 310); // Adjust this location as needed
            this.txtCombatLog.Size = new System.Drawing.Size(600, 150);
            this.txtCombatLog.Font = new System.Drawing.Font("Consolas", 10);
            this.Controls.Add(this.txtCombatLog);


            // Opponent Side
            this.lblOpponentName.Location = new System.Drawing.Point(1500, 50);
            this.lblOpponentName.ForeColor = System.Drawing.Color.White;
            this.lblOpponentName.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblOpponentName.Size = new System.Drawing.Size(200, 30);

            this.lblOpponentLevel.Location = new System.Drawing.Point(1500, 80);
            this.lblOpponentLevel.ForeColor = System.Drawing.Color.White;
            this.lblOpponentLevel.Size = new System.Drawing.Size(200, 20);

            this.barOpponentHP.Location = new System.Drawing.Point(1500, 110);
            this.barOpponentHP.Size = new System.Drawing.Size(300, 20);
            this.barOpponentHP.ForeColor = System.Drawing.Color.Lime;

            this.lblOpponentHP.Location = new System.Drawing.Point(1500, 135);
            this.lblOpponentHP.ForeColor = System.Drawing.Color.White;
            this.lblOpponentHP.Size = new System.Drawing.Size(200, 20);

            this.barOpponentMana.Location = new System.Drawing.Point(1500, 160);
            this.barOpponentMana.Size = new System.Drawing.Size(300, 20);
            this.barOpponentMana.ForeColor = System.Drawing.Color.DodgerBlue;

            this.lblOpponentMana.Location = new System.Drawing.Point(1500, 185);
            this.lblOpponentMana.ForeColor = System.Drawing.Color.White;
            this.lblOpponentMana.Size = new System.Drawing.Size(200, 20);

            this.picOpponent.Location = new System.Drawing.Point(1500, 210);
            this.picOpponent.Size = new System.Drawing.Size(300, 300);
            this.picOpponent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            // Opponent Stats Label
            this.lblOpponentStats = new System.Windows.Forms.Label();
            this.lblOpponentStats.Location = new System.Drawing.Point(1500, 520); // BELOW the picOpponent (Y=210 + 300)
            this.lblOpponentStats.Size = new System.Drawing.Size(300, 120);
            this.lblOpponentStats.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblOpponentStats.ForeColor = System.Drawing.Color.White;
            this.lblOpponentStats.BackColor = System.Drawing.Color.Transparent;
            this.lblOpponentStats.Text = "Stats";
            this.Controls.Add(this.lblOpponentStats);

            // Opponent Active Effects
            this.lblOpponentEffects = new System.Windows.Forms.Label();
            this.lblOpponentEffects.Location = new System.Drawing.Point(1500, 650); // Adjusted below stats
            this.lblOpponentEffects.Size = new System.Drawing.Size(300, 200);
            this.lblOpponentEffects.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblOpponentEffects.ForeColor = System.Drawing.Color.LightPink;
            this.lblOpponentEffects.BackColor = System.Drawing.Color.Transparent;
            this.lblOpponentEffects.Text = "Effects";
            this.Controls.Add(this.lblOpponentEffects);

            //Rest Button creation
            this.btnAbility5 = new System.Windows.Forms.Button();
            this.btnAbility5.Click += new System.EventHandler(this.AbilityButton_Click);
            this.btnAbility5.Location = new System.Drawing.Point(860, 760); // Centered and 100px above the top row
            this.Controls.Add(this.btnAbility5);

            // Ability Buttons
            System.Windows.Forms.Button[] abilityButtons = { btnAbility1, btnAbility2, btnAbility3, btnAbility4, btnAbility5 };
            for (int i = 0; i < abilityButtons.Length; i++)
            {
                abilityButtons[i].Size = new System.Drawing.Size(300, 80);
                abilityButtons[i].Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
                abilityButtons[i].ForeColor = System.Drawing.Color.White;
                abilityButtons[i].BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
                abilityButtons[i].Visible = false;
            }

            this.btnAbility1.Location = new System.Drawing.Point(700, 860);
            this.btnAbility2.Location = new System.Drawing.Point(1020, 860);
            this.btnAbility3.Location = new System.Drawing.Point(700, 960);
            this.btnAbility4.Location = new System.Drawing.Point(1020, 960);
            this.btnAbility1.Click += new System.EventHandler(this.AbilityButton_Click);
            this.btnAbility2.Click += new System.EventHandler(this.AbilityButton_Click);
            this.btnAbility3.Click += new System.EventHandler(this.AbilityButton_Click);
            this.btnAbility4.Click += new System.EventHandler(this.AbilityButton_Click);

            // Add to Form
            this.Controls.Add(this.lblTurnNumber);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblUserLevel);
            this.Controls.Add(this.barUserHP);
            this.Controls.Add(this.lblUserHP);
            this.Controls.Add(this.barUserMana);
            this.Controls.Add(this.lblUserMana);
            this.Controls.Add(this.picUser);
            this.Controls.Add(this.lblOpponentName);
            this.Controls.Add(this.lblOpponentLevel);
            this.Controls.Add(this.barOpponentHP);
            this.Controls.Add(this.lblOpponentHP);
            this.Controls.Add(this.barOpponentMana);
            this.Controls.Add(this.lblOpponentMana);
            this.Controls.Add(this.picOpponent);
            this.Controls.Add(this.btnAbility1);
            this.Controls.Add(this.btnAbility2);
            this.Controls.Add(this.btnAbility3);
            this.Controls.Add(this.btnAbility4);
            this.Controls.Add(this.btnAbility5);

            ((System.ComponentModel.ISupportInitialize)(this.picUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOpponent)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
