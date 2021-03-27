namespace MFD
{
    partial class ImportarExcel
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
			this.btnImportarExcel = new System.Windows.Forms.Button();
			this.lblEntidad = new System.Windows.Forms.Label();
			this.lblPath = new System.Windows.Forms.Label();
			this.txtFileProductos = new System.Windows.Forms.TextBox();
			this.btnPathProductos = new System.Windows.Forms.Button();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.stylesSheetManager = new Sb.Windows.Forms.StylesSheet.StylesSheetManager(this.components);
			this.cboEntidad = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.stylesSheetManager)).BeginInit();
			this.SuspendLayout();
			// 
			// btnImportarExcel
			// 
			this.btnImportarExcel.BackColor = System.Drawing.Color.Transparent;
			this.btnImportarExcel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.btnImportarExcel.Location = new System.Drawing.Point(228, 91);
			this.btnImportarExcel.Name = "btnImportarExcel";
			this.btnImportarExcel.Size = new System.Drawing.Size(150, 23);
			this.stylesSheetManager.SetStyle(this.btnImportarExcel, "Button");
			this.btnImportarExcel.TabIndex = 0;
			this.btnImportarExcel.Text = "Importar Archivo";
			this.btnImportarExcel.UseVisualStyleBackColor = false;
			this.btnImportarExcel.Click += new System.EventHandler(this.btnImportarExcel_Click);
			// 
			// lblEntidad
			// 
			this.lblEntidad.AutoSize = true;
			this.lblEntidad.BackColor = System.Drawing.Color.Transparent;
			this.lblEntidad.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblEntidad.Location = new System.Drawing.Point(12, 25);
			this.lblEntidad.Name = "lblEntidad";
			this.lblEntidad.Size = new System.Drawing.Size(56, 13);
			this.stylesSheetManager.SetStyle(this.lblEntidad, "Label");
			this.lblEntidad.TabIndex = 3;
			this.lblEntidad.Text = "Entidad";
			// 
			// lblPath
			// 
			this.lblPath.AutoSize = true;
			this.lblPath.BackColor = System.Drawing.Color.Transparent;
			this.lblPath.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblPath.Location = new System.Drawing.Point(12, 58);
			this.lblPath.Name = "lblPath";
			this.lblPath.Size = new System.Drawing.Size(57, 13);
			this.stylesSheetManager.SetStyle(this.lblPath, "Label");
			this.lblPath.TabIndex = 4;
			this.lblPath.Text = "Archivo";
			// 
			// txtFileProductos
			// 
			this.txtFileProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.txtFileProductos.ForeColor = System.Drawing.Color.Blue;
			this.txtFileProductos.Location = new System.Drawing.Point(134, 55);
			this.txtFileProductos.Name = "txtFileProductos";
			this.txtFileProductos.Size = new System.Drawing.Size(443, 20);
			this.stylesSheetManager.SetStyle(this.txtFileProductos, "TextBox");
			this.txtFileProductos.TabIndex = 6;
			// 
			// btnPathProductos
			// 
			this.btnPathProductos.Location = new System.Drawing.Point(583, 55);
			this.btnPathProductos.Name = "btnPathProductos";
			this.btnPathProductos.Size = new System.Drawing.Size(24, 20);
			this.stylesSheetManager.SetStyle(this.btnPathProductos, "");
			this.btnPathProductos.TabIndex = 7;
			this.btnPathProductos.Text = "...";
			this.btnPathProductos.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.btnPathProductos.UseVisualStyleBackColor = true;
			this.btnPathProductos.Click += new System.EventHandler(this.btnPathProductos_Click);
			// 
			// openFileDialog
			// 
			this.openFileDialog.FileName = "openFileDialog";
			// 
			// cboEntidad
			// 
			this.cboEntidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboEntidad.FormattingEnabled = true;
			this.cboEntidad.Items.AddRange(new object[] {
            "Clientes",
            "Productos"});
			this.cboEntidad.Location = new System.Drawing.Point(134, 16);
			this.cboEntidad.Name = "cboEntidad";
			this.cboEntidad.Size = new System.Drawing.Size(121, 21);
			this.stylesSheetManager.SetStyle(this.cboEntidad, "");
			this.cboEntidad.TabIndex = 8;
			// 
			// ImportarExcel
			// 
			this.AccessibleDescription = "HBackup";
			this.AccessibleName = "HBackup";
			this.AccessibleRole = System.Windows.Forms.AccessibleRole.Dialog;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(619, 131);
			this.Controls.Add(this.cboEntidad);
			this.Controls.Add(this.btnPathProductos);
			this.Controls.Add(this.lblPath);
			this.Controls.Add(this.lblEntidad);
			this.Controls.Add(this.btnImportarExcel);
			this.Controls.Add(this.txtFileProductos);
			this.Name = "ImportarExcel";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.stylesSheetManager.SetStyle(this, "");
			this.Text = "Importar Clientes y Productos";
			((System.ComponentModel.ISupportInitialize)(this.stylesSheetManager)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.Button btnImportarExcel;
        private System.Windows.Forms.Label lblEntidad;
		private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.TextBox txtFileProductos;
		private System.Windows.Forms.Button btnPathProductos;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private Sb.Windows.Forms.StylesSheet.StylesSheetManager stylesSheetManager;
		private System.Windows.Forms.ComboBox cboEntidad;
    }
}