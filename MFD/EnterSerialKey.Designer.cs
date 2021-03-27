namespace MFD
{
    partial class EnterSerialKey
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
            this.stylesSheetManager = new Sb.Windows.Forms.StylesSheet.StylesSheetManager(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSerialKey = new System.Windows.Forms.TextBox();
            this.lblFTPUser = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.stylesSheetManager)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnAccept);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 105);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(346, 40);
            this.stylesSheetManager.SetStyle(this.groupBox1, "GroupBox1");
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(265, 12);
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
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.lblMessage);
            this.groupBox2.Controls.Add(this.txtSerialKey);
            this.groupBox2.Controls.Add(this.lblFTPUser);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(346, 99);
            this.stylesSheetManager.SetStyle(this.groupBox2, "GroupBox1");
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            // 
            // txtSerialKey
            // 
            this.txtSerialKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtSerialKey.ForeColor = System.Drawing.Color.Blue;
            this.txtSerialKey.Location = new System.Drawing.Point(159, 62);
            this.txtSerialKey.Name = "txtSerialKey";
            this.txtSerialKey.Size = new System.Drawing.Size(159, 20);
            this.stylesSheetManager.SetStyle(this.txtSerialKey, "TextBox");
            this.txtSerialKey.TabIndex = 1;
            // 
            // lblFTPUser
            // 
            this.lblFTPUser.AutoSize = true;
            this.lblFTPUser.BackColor = System.Drawing.Color.Transparent;
            this.lblFTPUser.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblFTPUser.Location = new System.Drawing.Point(47, 65);
            this.lblFTPUser.Name = "lblFTPUser";
            this.lblFTPUser.Size = new System.Drawing.Size(73, 13);
            this.stylesSheetManager.SetStyle(this.lblFTPUser, "Label");
            this.lblFTPUser.TabIndex = 41;
            this.lblFTPUser.Text = "Serial Key";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblMessage.Location = new System.Drawing.Point(47, 28);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 13);
            this.stylesSheetManager.SetStyle(this.lblMessage, "Label");
            this.lblMessage.TabIndex = 42;
            // 
            // EnterSerialKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 145);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "EnterSerialKey";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.stylesSheetManager.SetStyle(this, "");
            this.Text = "Ingresar Serial Key";
            this.Load += new System.EventHandler(this.EnterSerialKey_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stylesSheetManager)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Sb.Windows.Forms.StylesSheet.StylesSheetManager stylesSheetManager;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtSerialKey;
        private System.Windows.Forms.Label lblFTPUser;
        private System.Windows.Forms.Label lblMessage;
    }
}