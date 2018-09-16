namespace Tg029.Storage.UI.Report
{
    partial class FrmChildReport
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
            this.ctrlReport1 = new Tg029.Storage.UI.Report.CtrlReport();
            this.SuspendLayout();
            // 
            // ctrlReport1
            // 
            this.ctrlReport1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlReport1.Location = new System.Drawing.Point(0, 0);
            this.ctrlReport1.Name = "ctrlReport1";
            this.ctrlReport1.ReportTemplateFile = null;
            this.ctrlReport1.Size = new System.Drawing.Size(486, 364);
            this.ctrlReport1.TabIndex = 0;
            this.ctrlReport1.ReportInit += new Tg029.Storage.UI.Report.CtrlReport.ReportInitEventHandler(this.ctrlReport1_ReportInit);
            // 
            // FrmChildReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 364);
            this.Controls.Add(this.ctrlReport1);
            this.Name = "FrmChildReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "报表详细内容";
            this.Load += new System.EventHandler(this.FrmChildReport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CtrlReport ctrlReport1;
    }
}