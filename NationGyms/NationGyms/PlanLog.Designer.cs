
namespace NationGyms
{
    partial class PlanLog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.homeClose = new System.Windows.Forms.Label();
            this.labTitle = new System.Windows.Forms.Label();
            this.listLog = new System.Windows.Forms.ListBox();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(160)))), ((int)(((byte)(63)))));
            this.panelHeader.Controls.Add(this.homeClose);
            this.panelHeader.Controls.Add(this.labTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(781, 133);
            this.panelHeader.TabIndex = 0;
            // 
            // homeClose
            // 
            this.homeClose.AutoSize = true;
            this.homeClose.Font = new System.Drawing.Font("Dubai", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homeClose.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.homeClose.Location = new System.Drawing.Point(687, 9);
            this.homeClose.Name = "homeClose";
            this.homeClose.Size = new System.Drawing.Size(65, 81);
            this.homeClose.TabIndex = 7;
            this.homeClose.Text = "X";
            this.homeClose.Click += new System.EventHandler(this.homeClose_Click);
            // 
            // labTitle
            // 
            this.labTitle.AutoSize = true;
            this.labTitle.Font = new System.Drawing.Font("Dubai", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTitle.Location = new System.Drawing.Point(35, 9);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(626, 121);
            this.labTitle.TabIndex = 4;
            this.labTitle.Text = "Changes made Log";
            // 
            // listLog
            // 
            this.listLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listLog.FormattingEnabled = true;
            this.listLog.ItemHeight = 26;
            this.listLog.Location = new System.Drawing.Point(83, 169);
            this.listLog.Name = "listLog";
            this.listLog.Size = new System.Drawing.Size(605, 576);
            this.listLog.TabIndex = 5;
            // 
            // PlanLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 793);
            this.Controls.Add(this.listLog);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PlanLog";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.PlanLog_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labTitle;
        private System.Windows.Forms.ListBox listLog;
        private System.Windows.Forms.Label homeClose;
    }
}