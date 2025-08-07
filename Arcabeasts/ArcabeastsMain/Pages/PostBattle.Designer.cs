namespace ArcabeastsMain.Pages
{
    partial class PostBattle
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblExpInfo;
        private System.Windows.Forms.Button btnContinue;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblResult = new System.Windows.Forms.Label();
            this.lblExpInfo = new System.Windows.Forms.Label();
            this.btnContinue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblResult
            // 
            this.lblResult.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblResult.ForeColor = System.Drawing.Color.White;
            this.lblResult.Location = new System.Drawing.Point(0, 30);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(800, 60);
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblExpInfo
            // 
            this.lblExpInfo.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblExpInfo.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblExpInfo.Location = new System.Drawing.Point(0, 100);
            this.lblExpInfo.Name = "lblExpInfo";
            this.lblExpInfo.Size = new System.Drawing.Size(800, 100);
            this.lblExpInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnContinue
            // 
            this.btnContinue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnContinue.Location = new System.Drawing.Point(300, 250);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(200, 60);
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);

            // PostBattle
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblExpInfo);
            this.Controls.Add(this.btnContinue);
            this.Name = "PostBattle";
            this.Text = "Battle Result";

        }
    }
}
