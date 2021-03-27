namespace MFD
{
    partial class ProductosCRUD
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
			this.cmbIva = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtImporte = new WindowsFormsControls.NumericControl();
			this.dcRubro = new FrameWork.CRUDModel.Windows.UI.DataCombo();
			this.lblRubro = new System.Windows.Forms.Label();
			this.dcClase = new FrameWork.CRUDModel.Windows.UI.DataCombo();
			this.lbl = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.lblIdentificacion = new System.Windows.Forms.Label();
			this.txtIdentificacion = new System.Windows.Forms.TextBox();
			this.txtNombre = new System.Windows.Forms.TextBox();
			this.lblNombre = new System.Windows.Forms.Label();
			this.stylesSheetManager = new Sb.Windows.Forms.StylesSheet.StylesSheetManager(this.components);
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
			this.groupBox1.Location = new System.Drawing.Point(0, 303);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(417, 40);
			this.stylesSheetManager.SetStyle(this.groupBox1, "GroupBox1");
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.BackColor = System.Drawing.Color.Transparent;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.btnCancel.Location = new System.Drawing.Point(336, 12);
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
			this.groupBox2.Controls.Add(this.cmbIva);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.txtImporte);
			this.groupBox2.Controls.Add(this.dcRubro);
			this.groupBox2.Controls.Add(this.lblRubro);
			this.groupBox2.Controls.Add(this.dcClase);
			this.groupBox2.Controls.Add(this.lbl);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.lblIdentificacion);
			this.groupBox2.Controls.Add(this.txtIdentificacion);
			this.groupBox2.Controls.Add(this.txtNombre);
			this.groupBox2.Controls.Add(this.lblNombre);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox2.Location = new System.Drawing.Point(0, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(417, 297);
			this.stylesSheetManager.SetStyle(this.groupBox2, "GroupBox1");
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			// 
			// cmbIva
			// 
			this.cmbIva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbIva.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.cmbIva.ForeColor = System.Drawing.Color.Blue;
			this.cmbIva.FormattingEnabled = true;
			this.cmbIva.Location = new System.Drawing.Point(120, 266);
			this.cmbIva.Name = "cmbIva";
			this.cmbIva.Size = new System.Drawing.Size(291, 21);
			this.stylesSheetManager.SetStyle(this.cmbIva, "TextBox");
			this.cmbIva.TabIndex = 6;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.label2.Location = new System.Drawing.Point(16, 269);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(30, 13);
			this.stylesSheetManager.SetStyle(this.label2, "Label");
			this.label2.TabIndex = 58;
			this.label2.Text = "IVA";
			// 
			// txtImporte
			// 
			this.txtImporte.AllowNegatives = false;
			this.txtImporte.DecimalPlaces = 2;
			this.txtImporte.DecimalPoint = '.';
			this.txtImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.txtImporte.ForeColor = System.Drawing.Color.Blue;
			this.txtImporte.Location = new System.Drawing.Point(120, 232);
			this.txtImporte.Name = "txtImporte";
			this.txtImporte.ShowCalculator = true;
			this.txtImporte.Size = new System.Drawing.Size(291, 20);
			this.stylesSheetManager.SetStyle(this.txtImporte, "TextBox");
			this.txtImporte.TabIndex = 5;
			this.txtImporte.Value = 0;
			// 
			// dcRubro
			// 
			this.dcRubro.DataType = null;
			this.dcRubro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.dcRubro.ForeColor = System.Drawing.Color.Blue;
			this.dcRubro.Location = new System.Drawing.Point(120, 200);
			this.dcRubro.Name = "dcRubro";
			this.dcRubro.Selected = null;
			this.dcRubro.ShowDelete = true;
			this.dcRubro.Size = new System.Drawing.Size(291, 20);
			this.stylesSheetManager.SetStyle(this.dcRubro, "TextBox");
			this.dcRubro.TabIndex = 4;
			this.dcRubro.TitleCRUD = null;
			this.dcRubro.TitleGrid = null;
			this.dcRubro.Load += new System.EventHandler(this.dcRubro_Load);
			this.dcRubro.BrowseClick += new FrameWork.CRUDModel.Windows.UI.DataCombo.BrowseTypeEvent(this.dcRubro_BrowseClick);
			// 
			// lblRubro
			// 
			this.lblRubro.AutoSize = true;
			this.lblRubro.BackColor = System.Drawing.Color.Transparent;
			this.lblRubro.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblRubro.Location = new System.Drawing.Point(16, 206);
			this.lblRubro.Name = "lblRubro";
			this.lblRubro.Size = new System.Drawing.Size(45, 13);
			this.stylesSheetManager.SetStyle(this.lblRubro, "Label");
			this.lblRubro.TabIndex = 54;
			this.lblRubro.Text = "Rubro";
			// 
			// dcClase
			// 
			this.dcClase.DataType = null;
			this.dcClase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.dcClase.ForeColor = System.Drawing.Color.Blue;
			this.dcClase.Location = new System.Drawing.Point(120, 171);
			this.dcClase.Name = "dcClase";
			this.dcClase.Selected = null;
			this.dcClase.ShowDelete = true;
			this.dcClase.Size = new System.Drawing.Size(291, 20);
			this.stylesSheetManager.SetStyle(this.dcClase, "TextBox");
			this.dcClase.TabIndex = 3;
			this.dcClase.TitleCRUD = null;
			this.dcClase.TitleGrid = null;
			this.dcClase.Load += new System.EventHandler(this.dcClase_Load);
			this.dcClase.BrowseClick += new FrameWork.CRUDModel.Windows.UI.DataCombo.BrowseTypeEvent(this.dcClase_BrowseClick);
			// 
			// lbl
			// 
			this.lbl.AutoSize = true;
			this.lbl.BackColor = System.Drawing.Color.Transparent;
			this.lbl.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.lbl.Location = new System.Drawing.Point(16, 177);
			this.lbl.Name = "lbl";
			this.lbl.Size = new System.Drawing.Size(42, 13);
			this.stylesSheetManager.SetStyle(this.lbl, "Label");
			this.lbl.TabIndex = 52;
			this.lbl.Text = "Clase";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.label1.Location = new System.Drawing.Point(16, 239);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 13);
			this.stylesSheetManager.SetStyle(this.label1, "Label");
			this.label1.TabIndex = 18;
			this.label1.Text = "Importe";
			// 
			// lblIdentificacion
			// 
			this.lblIdentificacion.AutoSize = true;
			this.lblIdentificacion.BackColor = System.Drawing.Color.Transparent;
			this.lblIdentificacion.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblIdentificacion.Location = new System.Drawing.Point(16, 23);
			this.lblIdentificacion.Name = "lblIdentificacion";
			this.lblIdentificacion.Size = new System.Drawing.Size(97, 13);
			this.stylesSheetManager.SetStyle(this.lblIdentificacion, "Label");
			this.lblIdentificacion.TabIndex = 14;
			this.lblIdentificacion.Text = "Identificación";
			// 
			// txtIdentificacion
			// 
			this.txtIdentificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.txtIdentificacion.ForeColor = System.Drawing.Color.Blue;
			this.txtIdentificacion.Location = new System.Drawing.Point(120, 19);
			this.txtIdentificacion.Multiline = true;
			this.txtIdentificacion.Name = "txtIdentificacion";
			this.txtIdentificacion.Size = new System.Drawing.Size(291, 20);
			this.stylesSheetManager.SetStyle(this.txtIdentificacion, "TextBox");
			this.txtIdentificacion.TabIndex = 2;
			// 
			// txtNombre
			// 
			this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.txtNombre.ForeColor = System.Drawing.Color.Blue;
			this.txtNombre.Location = new System.Drawing.Point(120, 45);
			this.txtNombre.MaxLength = 300;
			this.txtNombre.Multiline = true;
			this.txtNombre.Name = "txtNombre";
			this.txtNombre.Size = new System.Drawing.Size(291, 118);
			this.stylesSheetManager.SetStyle(this.txtNombre, "TextBox");
			this.txtNombre.TabIndex = 1;
			// 
			// lblNombre
			// 
			this.lblNombre.AutoSize = true;
			this.lblNombre.BackColor = System.Drawing.Color.Transparent;
			this.lblNombre.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblNombre.Location = new System.Drawing.Point(16, 50);
			this.lblNombre.Name = "lblNombre";
			this.lblNombre.Size = new System.Drawing.Size(58, 13);
			this.stylesSheetManager.SetStyle(this.lblNombre, "Label");
			this.lblNombre.TabIndex = 9;
			this.lblNombre.Text = "Nombre";
			// 
			// ProductosCRUD
			// 
			this.AcceptButton = this.btnAccept;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(417, 343);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.Name = "ProductosCRUD";
			this.stylesSheetManager.SetStyle(this, "FormType1");
			this.Text = "ProductosCRUD";
			this.Title = "ProductosCRUD";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.stylesSheetManager)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblIdentificacion;
        private System.Windows.Forms.TextBox txtIdentificacion;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private FrameWork.CRUDModel.Windows.UI.DataCombo dcRubro;
        private System.Windows.Forms.Label lblRubro;
        private FrameWork.CRUDModel.Windows.UI.DataCombo dcClase;
        private System.Windows.Forms.Label lbl;
        private WindowsFormsControls.NumericControl txtImporte;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbIva;
        private Sb.Windows.Forms.StylesSheet.StylesSheetManager stylesSheetManager;
    }
}