namespace MFD
{
    partial class ReportViewer
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
            this.viewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // viewer
            // 
            this.viewer.ActiveViewIndex = -1;
            this.viewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.viewer.DisplayGroupTree = false;
            this.viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewer.Location = new System.Drawing.Point(0, 0);
            this.viewer.Name = "viewer";
            this.viewer.SelectionFormula = "";
            this.viewer.ShowGroupTreeButton = false;
            this.viewer.ShowRefreshButton = false;
            this.viewer.Size = new System.Drawing.Size(485, 347);
            this.viewer.TabIndex = 0;
            this.viewer.ViewTimeSelectionFormula = "";
            // 
            // ReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 347);
            this.Controls.Add(this.viewer);
            this.Name = "ReportViewer";
            this.ShowInTaskbar = false;
            this.Text = "ReportViewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer viewer;
    }
}