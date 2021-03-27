namespace MFD
{
    partial class FTPSettingsForm
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
            this.components = new System.ComponentModel.Container();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.lblFTPPass = new System.Windows.Forms.Label();
            this.lblFTPUser = new System.Windows.Forms.Label();
            this.lblFTPPort = new System.Windows.Forms.Label();
            this.lblFTPHost = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.stylesSheetManager = new Sb.Windows.Forms.StylesSheet.StylesSheetManager(this.components);
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stylesSheetManager)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.txtPass);
            this.groupBox2.Controls.Add(this.txtUser);
            this.groupBox2.Controls.Add(this.txtPort);
            this.groupBox2.Controls.Add(this.txtHost);
            this.groupBox2.Controls.Add(this.lblFTPPass);
            this.groupBox2.Controls.Add(this.lblFTPUser);
            this.groupBox2.Controls.Add(this.lblFTPPort);
            this.groupBox2.Controls.Add(this.lblFTPHost);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(363, 174);
            this.stylesSheetManager.SetStyle(this.groupBox2, "GroupBox1");
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // txtPass
            // 
            this.txtPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtPass.ForeColor = System.Drawing.Color.Blue;
            this.txtPass.Location = new System.Drawing.Point(159, 127);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(159, 20);
            this.stylesSheetManager.SetStyle(this.txtPass, "TextBox");
            this.txtPass.TabIndex = 46;
            // 
            // txtUser
            // 
            this.txtUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtUser.ForeColor = System.Drawing.Color.Blue;
            this.txtUser.Location = new System.Drawing.Point(159, 91);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(159, 20);
            this.stylesSheetManager.SetStyle(this.txtUser, "TextBox");
            this.txtUser.TabIndex = 45;
            // 
            // txtPort
            // 
            this.txtPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtPort.ForeColor = System.Drawing.Color.Blue;
            this.txtPort.Location = new System.Drawing.Point(159, 59);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(159, 20);
            this.stylesSheetManager.SetStyle(this.txtPort, "TextBox");
            this.txtPort.TabIndex = 44;
            // 
            // txtHost
            // 
            this.txtHost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtHost.ForeColor = System.Drawing.Color.Blue;
            this.txtHost.Location = new System.Drawing.Point(159, 26);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(159, 20);
            this.stylesSheetManager.SetStyle(this.txtHost, "TextBox");
            this.txtHost.TabIndex = 43;
            // 
            // lblFTPPass
            // 
            this.lblFTPPass.AutoSize = true;
            this.lblFTPPass.BackColor = System.Drawing.Color.Transparent;
            this.lblFTPPass.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblFTPPass.Location = new System.Drawing.Point(47, 130);
            this.lblFTPPass.Name = "lblFTPPass";
            this.lblFTPPass.Size = new System.Drawing.Size(97, 13);
            this.stylesSheetManager.SetStyle(this.lblFTPPass, "Label");
            this.lblFTPPass.TabIndex = 42;
            this.lblFTPPass.Text = "FTP Password";
            // 
            // lblFTPUser
            // 
            this.lblFTPUser.AutoSize = true;
            this.lblFTPUser.BackColor = System.Drawing.Color.Transparent;
            this.lblFTPUser.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblFTPUser.Location = new System.Drawing.Point(47, 94);
            this.lblFTPUser.Name = "lblFTPUser";
            this.lblFTPUser.Size = new System.Drawing.Size(65, 13);
            this.stylesSheetManager.SetStyle(this.lblFTPUser, "Label");
            this.lblFTPUser.TabIndex = 41;
            this.lblFTPUser.Text = "FTP User";
            // 
            // lblFTPPort
            // 
            this.lblFTPPort.AutoSize = true;
            this.lblFTPPort.BackColor = System.Drawing.Color.Transparent;
            this.lblFTPPort.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblFTPPort.Location = new System.Drawing.Point(47, 62);
            this.lblFTPPort.Name = "lblFTPPort";
            this.lblFTPPort.Size = new System.Drawing.Size(62, 13);
            this.stylesSheetManager.SetStyle(this.lblFTPPort, "Label");
            this.lblFTPPort.TabIndex = 10;
            this.lblFTPPort.Text = "FTP Port";
            // 
            // lblFTPHost
            // 
            this.lblFTPHost.AutoSize = true;
            this.lblFTPHost.BackColor = System.Drawing.Color.Transparent;
            this.lblFTPHost.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblFTPHost.Location = new System.Drawing.Point(47, 29);
            this.lblFTPHost.Name = "lblFTPHost";
            this.lblFTPHost.Size = new System.Drawing.Size(64, 13);
            this.stylesSheetManager.SetStyle(this.lblFTPHost, "Label");
            this.lblFTPHost.TabIndex = 9;
            this.lblFTPHost.Text = "FTP Host";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnAccept);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 175);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 40);
            this.stylesSheetManager.SetStyle(this.groupBox1, "GroupBox1");
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(282, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.stylesSheetManager.SetStyle(this.btnCancel, "Button");
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.Transparent;
            this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAccept.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAccept.Location = new System.Drawing.Point(6, 12);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.stylesSheetManager.SetStyle(this.btnAccept, "Button");
            this.btnAccept.TabIndex = 5;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // FTPSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 215);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "FTPSettingsForm";
            this.stylesSheetManager.SetStyle(this, "FormType1");
            this.Text = "FTP Settings";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stylesSheetManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblFTPPort;
        private System.Windows.Forms.Label lblFTPHost;
        private System.Windows.Forms.Label lblFTPUser;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Label lblFTPPass;
        private Sb.Windows.Forms.StylesSheet.StylesSheetManager stylesSheetManager;
    }
}