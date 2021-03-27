namespace MFD
{
    partial class HacerBackup
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.btnHacerBackup = new System.Windows.Forms.Button();
			this.lblServidor = new System.Windows.Forms.Label();
			this.txtServidor = new System.Windows.Forms.TextBox();
			this.lblBase = new System.Windows.Forms.Label();
			this.lblBackup = new System.Windows.Forms.Label();
			this.txtBase = new System.Windows.Forms.TextBox();
			this.txtBackup = new System.Windows.Forms.TextBox();
			this.btnPath = new System.Windows.Forms.Button();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.stylesSheetManager = new Sb.Windows.Forms.StylesSheet.StylesSheetManager(this.components);
			((System.ComponentModel.ISupportInitialize)(this.stylesSheetManager)).BeginInit();
			this.SuspendLayout();
			// 
			// btnHacerBackup
			// 
			this.btnHacerBackup.BackColor = System.Drawing.Color.Transparent;
			this.btnHacerBackup.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.btnHacerBackup.Location = new System.Drawing.Point(228, 125);
			this.btnHacerBackup.Name = "btnHacerBackup";
			this.btnHacerBackup.Size = new System.Drawing.Size(134, 23);
			this.stylesSheetManager.SetStyle(this.btnHacerBackup, "Button");
			this.btnHacerBackup.TabIndex = 0;
			this.btnHacerBackup.Text = "Realizar Back Up";
			this.btnHacerBackup.UseVisualStyleBackColor = false;
			this.btnHacerBackup.Click += new System.EventHandler(this.btnHacerBackup_Click);
			// 
			// lblServidor
			// 
			this.lblServidor.AutoSize = true;
			this.lblServidor.BackColor = System.Drawing.Color.Transparent;
			this.lblServidor.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblServidor.Location = new System.Drawing.Point(12, 26);
			this.lblServidor.Name = "lblServidor";
			this.lblServidor.Size = new System.Drawing.Size(95, 13);
			this.stylesSheetManager.SetStyle(this.lblServidor, "Label");
			this.lblServidor.TabIndex = 1;
			this.lblServidor.Text = "Servidor SQL:";
			// 
			// txtServidor
			// 
			this.txtServidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.txtServidor.ForeColor = System.Drawing.Color.Blue;
			this.txtServidor.Location = new System.Drawing.Point(134, 23);
			this.txtServidor.Name = "txtServidor";
			this.txtServidor.ReadOnly = true;
			this.txtServidor.Size = new System.Drawing.Size(473, 20);
			this.stylesSheetManager.SetStyle(this.txtServidor, "TextBox");
			this.txtServidor.TabIndex = 2;
			// 
			// lblBase
			// 
			this.lblBase.AutoSize = true;
			this.lblBase.BackColor = System.Drawing.Color.Transparent;
			this.lblBase.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblBase.Location = new System.Drawing.Point(12, 59);
			this.lblBase.Name = "lblBase";
			this.lblBase.Size = new System.Drawing.Size(102, 13);
			this.stylesSheetManager.SetStyle(this.lblBase, "Label");
			this.lblBase.TabIndex = 3;
			this.lblBase.Text = "Base de datos:";
			// 
			// lblBackup
			// 
			this.lblBackup.AutoSize = true;
			this.lblBackup.BackColor = System.Drawing.Color.Transparent;
			this.lblBackup.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblBackup.Location = new System.Drawing.Point(12, 92);
			this.lblBackup.Name = "lblBackup";
			this.lblBackup.Size = new System.Drawing.Size(116, 13);
			this.stylesSheetManager.SetStyle(this.lblBackup, "Label");
			this.lblBackup.TabIndex = 4;
			this.lblBackup.Text = "Destino Back Up:";
			// 
			// txtBase
			// 
			this.txtBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.txtBase.ForeColor = System.Drawing.Color.Blue;
			this.txtBase.Location = new System.Drawing.Point(134, 56);
			this.txtBase.Name = "txtBase";
			this.txtBase.ReadOnly = true;
			this.txtBase.Size = new System.Drawing.Size(473, 20);
			this.stylesSheetManager.SetStyle(this.txtBase, "TextBox");
			this.txtBase.TabIndex = 5;
			// 
			// txtBackup
			// 
			this.txtBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.txtBackup.ForeColor = System.Drawing.Color.Blue;
			this.txtBackup.Location = new System.Drawing.Point(134, 89);
			this.txtBackup.Name = "txtBackup";
			this.txtBackup.Size = new System.Drawing.Size(443, 20);
			this.stylesSheetManager.SetStyle(this.txtBackup, "TextBox");
			this.txtBackup.TabIndex = 6;
			// 
			// btnPath
			// 
			this.btnPath.Location = new System.Drawing.Point(583, 89);
			this.btnPath.Name = "btnPath";
			this.btnPath.Size = new System.Drawing.Size(24, 20);
			this.stylesSheetManager.SetStyle(this.btnPath, "");
			this.btnPath.TabIndex = 7;
			this.btnPath.Text = "...";
			this.btnPath.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnPath.UseVisualStyleBackColor = true;
			this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
			// 
			// openFileDialog
			// 
			this.openFileDialog.FileName = "openFileDialog";
			// 
			// HacerBackup
			// 
			this.AccessibleDescription = "HBackup";
			this.AccessibleName = "HBackup";
			this.AccessibleRole = System.Windows.Forms.AccessibleRole.Dialog;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(619, 169);
			this.Controls.Add(this.btnPath);
			this.Controls.Add(this.txtBase);
			this.Controls.Add(this.lblBackup);
			this.Controls.Add(this.lblBase);
			this.Controls.Add(this.txtServidor);
			this.Controls.Add(this.lblServidor);
			this.Controls.Add(this.btnHacerBackup);
			this.Controls.Add(this.txtBackup);
			this.Name = "HacerBackup";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.stylesSheetManager.SetStyle(this, "");
			this.Text = "Backup";
			((System.ComponentModel.ISupportInitialize)(this.stylesSheetManager)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHacerBackup;
        private System.Windows.Forms.Label lblServidor;
        private System.Windows.Forms.TextBox txtServidor;
        private System.Windows.Forms.Label lblBase;
        private System.Windows.Forms.Label lblBackup;
        private System.Windows.Forms.TextBox txtBase;
        private System.Windows.Forms.TextBox txtBackup;
		private System.Windows.Forms.Button btnPath;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private Sb.Windows.Forms.StylesSheet.StylesSheetManager stylesSheetManager;
    }
}