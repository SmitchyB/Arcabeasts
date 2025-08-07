using System.Drawing;
using System.Windows.Forms;

namespace ArcabeastsMain.Pages
{
    partial class UserProfileSelection
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.flowProfileSlots = new System.Windows.Forms.FlowLayoutPanel();
            this.panelSelectionScreen = new System.Windows.Forms.Panel();
            this.flowArcabeastSelection = new System.Windows.Forms.FlowLayoutPanel();
            this.txtPlayerName = new System.Windows.Forms.TextBox();
            this.txtCustomName = new System.Windows.Forms.TextBox();
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.lblCustomName = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.panelSummary = new System.Windows.Forms.Panel();
            this.lblSummary = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();

            this.panelSelectionScreen.SuspendLayout();
            this.panelSummary.SuspendLayout();
            this.SuspendLayout();

            // Main form
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.Text = "UserProfileSelection";

            // flowProfileSlots
            this.flowProfileSlots.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowProfileSlots.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.flowProfileSlots.WrapContents = false;
            this.flowProfileSlots.Padding = new Padding(50);
            this.flowProfileSlots.AutoScroll = true;
            this.flowProfileSlots.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);

            // panelSelectionScreen
            this.panelSelectionScreen.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.panelSelectionScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSelectionScreen.Controls.Add(this.flowArcabeastSelection);
            this.panelSelectionScreen.Controls.Add(this.lblPlayerName);
            this.panelSelectionScreen.Controls.Add(this.txtPlayerName);
            this.panelSelectionScreen.Controls.Add(this.lblCustomName);
            this.panelSelectionScreen.Controls.Add(this.txtCustomName);
            this.panelSelectionScreen.Controls.Add(this.btnBack);
            this.panelSelectionScreen.Controls.Add(this.btnNext);
            this.panelSelectionScreen.Visible = false;

            // flowArcabeastSelection
            this.flowArcabeastSelection.Location = new System.Drawing.Point(50, 30);
            this.flowArcabeastSelection.Size = new System.Drawing.Size(1800, 700);
            this.flowArcabeastSelection.AutoScroll = true;
            this.flowArcabeastSelection.WrapContents = true;
            this.flowArcabeastSelection.FlowDirection = FlowDirection.LeftToRight;
            this.flowArcabeastSelection.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);

            // txtPlayerName
            this.txtPlayerName.Location = new System.Drawing.Point(250, 750);
            this.txtPlayerName.Size = new System.Drawing.Size(300, 30);
            this.txtPlayerName.ForeColor = System.Drawing.Color.White;
            this.txtPlayerName.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.txtPlayerName.TextChanged += new System.EventHandler(this.TxtPlayerName_TextChanged);

            // lblPlayerName
            this.lblPlayerName.Text = "Player Name:";
            this.lblPlayerName.ForeColor = System.Drawing.Color.White;
            this.lblPlayerName.Location = new System.Drawing.Point(150, 750);
            this.lblPlayerName.Size = new System.Drawing.Size(100, 30);

            // txtCustomName
            this.txtCustomName.Location = new System.Drawing.Point(750, 750);
            this.txtCustomName.Size = new System.Drawing.Size(300, 30);
            this.txtCustomName.ForeColor = System.Drawing.Color.White;
            this.txtCustomName.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);

            // lblCustomName
            this.lblCustomName.Text = "Arcabeast Name:";
            this.lblCustomName.ForeColor = System.Drawing.Color.White;
            this.lblCustomName.Location = new System.Drawing.Point(600, 750);
            this.lblCustomName.Size = new System.Drawing.Size(150, 30);

            // btnBack
            this.btnBack.Text = "Back";
            this.btnBack.Location = new System.Drawing.Point(150, 850);
            this.btnBack.Size = new System.Drawing.Size(150, 50);
            this.btnBack.BackColor = System.Drawing.Color.Gray;
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Click += new System.EventHandler(this.BtnBackToProfiles_Click);

            // btnNext
            this.btnNext.Text = "Next";
            this.btnNext.Location = new System.Drawing.Point(1620, 850);
            this.btnNext.Size = new System.Drawing.Size(150, 50);
            this.btnNext.BackColor = System.Drawing.Color.Gray;
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Enabled = false;
            this.btnNext.Click += new System.EventHandler(this.BtnNext_Click);

            // panelSummary
            this.panelSummary.Dock = DockStyle.Fill;
            this.panelSummary.Visible = false;
            this.panelSummary.BackColor = System.Drawing.Color.FromArgb(24, 24, 24);
            this.panelSummary.Controls.Add(this.lblSummary);
            this.panelSummary.Controls.Add(this.btnConfirm);

            // lblSummary
            this.lblSummary.ForeColor = System.Drawing.Color.White;
            this.lblSummary.Font = new Font("Segoe UI", 14);
            this.lblSummary.Location = new Point(100, 100);
            this.lblSummary.Size = new Size(1000, 400);

            // btnConfirm
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.Size = new Size(200, 60);
            this.btnConfirm.Location = new Point(1600, 900);
            this.btnConfirm.BackColor = System.Drawing.Color.Gray;
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);

            // Add panels to main form
            this.Controls.Add(this.flowProfileSlots);
            this.Controls.Add(this.panelSelectionScreen);
            this.Controls.Add(this.panelSummary);

            this.panelSelectionScreen.ResumeLayout(false);
            this.panelSelectionScreen.PerformLayout();
            this.panelSummary.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowProfileSlots;
        private System.Windows.Forms.Panel panelSelectionScreen;
        private System.Windows.Forms.FlowLayoutPanel flowArcabeastSelection;
        private System.Windows.Forms.TextBox txtPlayerName;
        private System.Windows.Forms.TextBox txtCustomName;
        private System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.Label lblCustomName;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Panel panelSummary;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.Button btnConfirm;
    }
}
