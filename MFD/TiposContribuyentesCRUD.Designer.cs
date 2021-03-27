namespace MFD
{
    partial class TiposContribuyentesCRUD
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnAccept = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.cmbTipoNotaDebito = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.cmbTipoNotaCredito = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtCodigo = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cmbTipoFactura = new System.Windows.Forms.ComboBox();
			this.chkPercepciones = new System.Windows.Forms.CheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.chkDiscriminaIVA = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtDescripcion = new System.Windows.Forms.TextBox();
			this.lblDescripcion = new System.Windows.Forms.Label();
			this.stylesSheetManager = new Sb.Windows.Forms.StylesSheet.StylesSheetManager(this.components);
			this.chkComputaIVA = new System.Windows.Forms.CheckBox();
			this.lblComputaIVA = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.stylesSheetManager)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.Color.Transparent;
			this.groupBox1.Controls.Add(this.btnCancel);
			this.groupBox1.Controls.Add(this.btnAccept);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.groupBox1.Location = new System.Drawing.Point(0, 312);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(330, 40);
			this.stylesSheetManager.SetStyle(this.groupBox1, "GroupBox1");
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.BackColor = System.Drawing.Color.Transparent;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.btnCancel.Location = new System.Drawing.Point(249, 12);
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
			// groupBox2
			// 
			this.groupBox2.BackColor = System.Drawing.Color.Transparent;
			this.groupBox2.Controls.Add(this.chkComputaIVA);
			this.groupBox2.Controls.Add(this.lblComputaIVA);
			this.groupBox2.Controls.Add(this.cmbTipoNotaDebito);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.cmbTipoNotaCredito);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.txtCodigo);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.cmbTipoFactura);
			this.groupBox2.Controls.Add(this.chkPercepciones);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.chkDiscriminaIVA);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.txtDescripcion);
			this.groupBox2.Controls.Add(this.lblDescripcion);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox2.Location = new System.Drawing.Point(0, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(330, 306);
			this.stylesSheetManager.SetStyle(this.groupBox2, "GroupBox1");
			this.groupBox2.TabIndex = 7;
			this.groupBox2.TabStop = false;
			// 
			// cmbTipoNotaDebito
			// 
			this.cmbTipoNotaDebito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTipoNotaDebito.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.cmbTipoNotaDebito.ForeColor = System.Drawing.Color.Blue;
			this.cmbTipoNotaDebito.FormattingEnabled = true;
			this.cmbTipoNotaDebito.Location = new System.Drawing.Point(155, 182);
			this.cmbTipoNotaDebito.Name = "cmbTipoNotaDebito";
			this.cmbTipoNotaDebito.Size = new System.Drawing.Size(163, 21);
			this.stylesSheetManager.SetStyle(this.cmbTipoNotaDebito, "TextBox");
			this.cmbTipoNotaDebito.TabIndex = 5;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.BackColor = System.Drawing.Color.Transparent;
			this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.label6.Location = new System.Drawing.Point(23, 185);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(115, 13);
			this.stylesSheetManager.SetStyle(this.label6, "Label");
			this.label6.TabIndex = 52;
			this.label6.Text = "Tipo Nota Débito";
			// 
			// cmbTipoNotaCredito
			// 
			this.cmbTipoNotaCredito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTipoNotaCredito.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.cmbTipoNotaCredito.ForeColor = System.Drawing.Color.Blue;
			this.cmbTipoNotaCredito.FormattingEnabled = true;
			this.cmbTipoNotaCredito.Location = new System.Drawing.Point(155, 146);
			this.cmbTipoNotaCredito.Name = "cmbTipoNotaCredito";
			this.cmbTipoNotaCredito.Size = new System.Drawing.Size(163, 21);
			this.stylesSheetManager.SetStyle(this.cmbTipoNotaCredito, "TextBox");
			this.cmbTipoNotaCredito.TabIndex = 4;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.label5.Location = new System.Drawing.Point(23, 149);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(120, 13);
			this.stylesSheetManager.SetStyle(this.label5, "Label");
			this.label5.TabIndex = 50;
			this.label5.Text = "Tipo Nota Crédito";
			// 
			// txtCodigo
			// 
			this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.txtCodigo.ForeColor = System.Drawing.Color.Blue;
			this.txtCodigo.Location = new System.Drawing.Point(155, 73);
			this.txtCodigo.Name = "txtCodigo";
			this.txtCodigo.Size = new System.Drawing.Size(163, 20);
			this.stylesSheetManager.SetStyle(this.txtCodigo, "TextBox");
			this.txtCodigo.TabIndex = 2;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.label4.Location = new System.Drawing.Point(23, 76);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(51, 13);
			this.stylesSheetManager.SetStyle(this.label4, "Label");
			this.label4.TabIndex = 47;
			this.label4.Text = "Código";
			// 
			// cmbTipoFactura
			// 
			this.cmbTipoFactura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTipoFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.cmbTipoFactura.ForeColor = System.Drawing.Color.Blue;
			this.cmbTipoFactura.FormattingEnabled = true;
			this.cmbTipoFactura.Location = new System.Drawing.Point(155, 110);
			this.cmbTipoFactura.Name = "cmbTipoFactura";
			this.cmbTipoFactura.Size = new System.Drawing.Size(163, 21);
			this.stylesSheetManager.SetStyle(this.cmbTipoFactura, "TextBox");
			this.cmbTipoFactura.TabIndex = 3;
			// 
			// chkPercepciones
			// 
			this.chkPercepciones.AutoSize = true;
			this.chkPercepciones.BackColor = System.Drawing.Color.Transparent;
			this.chkPercepciones.Location = new System.Drawing.Point(155, 286);
			this.chkPercepciones.Name = "chkPercepciones";
			this.chkPercepciones.Size = new System.Drawing.Size(15, 14);
			this.stylesSheetManager.SetStyle(this.chkPercepciones, "");
			this.chkPercepciones.TabIndex = 7;
			this.chkPercepciones.UseVisualStyleBackColor = false;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.label3.Location = new System.Drawing.Point(23, 287);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(94, 13);
			this.stylesSheetManager.SetStyle(this.label3, "Label");
			this.label3.TabIndex = 14;
			this.label3.Text = "Percepciones";
			// 
			// chkDiscriminaIVA
			// 
			this.chkDiscriminaIVA.AutoSize = true;
			this.chkDiscriminaIVA.BackColor = System.Drawing.Color.Transparent;
			this.chkDiscriminaIVA.Location = new System.Drawing.Point(155, 224);
			this.chkDiscriminaIVA.Name = "chkDiscriminaIVA";
			this.chkDiscriminaIVA.Size = new System.Drawing.Size(15, 14);
			this.stylesSheetManager.SetStyle(this.chkDiscriminaIVA, "");
			this.chkDiscriminaIVA.TabIndex = 6;
			this.chkDiscriminaIVA.UseVisualStyleBackColor = false;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.label2.Location = new System.Drawing.Point(23, 225);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(103, 13);
			this.stylesSheetManager.SetStyle(this.label2, "Label");
			this.label2.TabIndex = 12;
			this.label2.Text = "Discrimina IVA";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.label1.Location = new System.Drawing.Point(23, 113);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(89, 13);
			this.stylesSheetManager.SetStyle(this.label1, "Label");
			this.label1.TabIndex = 10;
			this.label1.Text = "Tipo Factura";
			// 
			// txtDescripcion
			// 
			this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.txtDescripcion.ForeColor = System.Drawing.Color.Blue;
			this.txtDescripcion.Location = new System.Drawing.Point(155, 35);
			this.txtDescripcion.Name = "txtDescripcion";
			this.txtDescripcion.Size = new System.Drawing.Size(163, 20);
			this.stylesSheetManager.SetStyle(this.txtDescripcion, "TextBox");
			this.txtDescripcion.TabIndex = 1;
			// 
			// lblDescripcion
			// 
			this.lblDescripcion.AutoSize = true;
			this.lblDescripcion.BackColor = System.Drawing.Color.Transparent;
			this.lblDescripcion.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblDescripcion.Location = new System.Drawing.Point(23, 38);
			this.lblDescripcion.Name = "lblDescripcion";
			this.lblDescripcion.Size = new System.Drawing.Size(83, 13);
			this.stylesSheetManager.SetStyle(this.lblDescripcion, "Label");
			this.lblDescripcion.TabIndex = 9;
			this.lblDescripcion.Text = "Descripcion";
			// 
			// chkComputaIVA
			// 
			this.chkComputaIVA.AutoSize = true;
			this.chkComputaIVA.BackColor = System.Drawing.Color.Transparent;
			this.chkComputaIVA.Location = new System.Drawing.Point(155, 256);
			this.chkComputaIVA.Name = "chkComputaIVA";
			this.chkComputaIVA.Size = new System.Drawing.Size(15, 14);
			this.stylesSheetManager.SetStyle(this.chkComputaIVA, "");
			this.chkComputaIVA.TabIndex = 53;
			this.chkComputaIVA.UseVisualStyleBackColor = false;
			// 
			// lblComputaIVA
			// 
			this.lblComputaIVA.AutoSize = true;
			this.lblComputaIVA.BackColor = System.Drawing.Color.Transparent;
			this.lblComputaIVA.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblComputaIVA.Location = new System.Drawing.Point(23, 257);
			this.lblComputaIVA.Name = "lblComputaIVA";
			this.lblComputaIVA.Size = new System.Drawing.Size(91, 13);
			this.stylesSheetManager.SetStyle(this.lblComputaIVA, "Label");
			this.lblComputaIVA.TabIndex = 54;
			this.lblComputaIVA.Text = "Computa IVA";
			// 
			// TiposContribuyentesCRUD
			// 
			this.AcceptButton = this.btnAccept;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(330, 352);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.Name = "TiposContribuyentesCRUD";
			this.stylesSheetManager.SetStyle(this, "FormType1");
			this.Text = "TiposContribuyentesCRUD";
			this.Title = "TiposContribuyentesCRUD";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.stylesSheetManager)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.CheckBox chkDiscriminaIVA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkPercepciones;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTipoFactura;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label4;
        private Sb.Windows.Forms.StylesSheet.StylesSheetManager stylesSheetManager;
        private System.Windows.Forms.ComboBox cmbTipoNotaDebito;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbTipoNotaCredito;
        private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckBox chkComputaIVA;
		private System.Windows.Forms.Label lblComputaIVA;
    }
}