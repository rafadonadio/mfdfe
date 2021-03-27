namespace MFD
{
    partial class DetallesComprobantesCRUD
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
			this.txtImporteUnitarioForm = new WindowsFormsControls.NumericControl();
			this.txtCantidad = new WindowsFormsControls.NumericControl();
			this.dcProducto = new FrameWork.CRUDModel.Windows.UI.DataCombo();
			this.lblProducto = new System.Windows.Forms.Label();
			this.lblCantidad = new System.Windows.Forms.Label();
			this.lblImporteUnitario = new System.Windows.Forms.Label();
			this.stylesSheetManager = new Sb.Windows.Forms.StylesSheet.StylesSheetManager(this.components);
			this.txtImporteUnitario = new System.Windows.Forms.TextBox();
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
			this.groupBox1.Location = new System.Drawing.Point(0, 146);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(328, 40);
			this.stylesSheetManager.SetStyle(this.groupBox1, "GroupBox1");
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.BackColor = System.Drawing.Color.Transparent;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.btnCancel.Location = new System.Drawing.Point(247, 12);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.stylesSheetManager.SetStyle(this.btnCancel, "Button");
			this.btnCancel.TabIndex = 11;
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
			this.btnAccept.TabIndex = 10;
			this.btnAccept.Text = "Aceptar";
			this.btnAccept.UseVisualStyleBackColor = false;
			this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.BackColor = System.Drawing.Color.Transparent;
			this.groupBox2.Controls.Add(this.txtImporteUnitario);
			this.groupBox2.Controls.Add(this.txtImporteUnitarioForm);
			this.groupBox2.Controls.Add(this.txtCantidad);
			this.groupBox2.Controls.Add(this.dcProducto);
			this.groupBox2.Controls.Add(this.lblProducto);
			this.groupBox2.Controls.Add(this.lblCantidad);
			this.groupBox2.Controls.Add(this.lblImporteUnitario);
			this.groupBox2.Location = new System.Drawing.Point(0, -3);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(328, 149);
			this.stylesSheetManager.SetStyle(this.groupBox2, "GroupBox1");
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			// 
			// txtImporteUnitarioForm
			// 
			this.txtImporteUnitarioForm.AllowNegatives = false;
			this.txtImporteUnitarioForm.DecimalPlaces = 2;
			this.txtImporteUnitarioForm.DecimalPoint = '.';
			this.txtImporteUnitarioForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.txtImporteUnitarioForm.ForeColor = System.Drawing.Color.Blue;
			this.txtImporteUnitarioForm.Location = new System.Drawing.Point(143, 98);
			this.txtImporteUnitarioForm.Name = "txtImporteUnitarioForm";
			this.txtImporteUnitarioForm.ShowCalculator = true;
			this.txtImporteUnitarioForm.Size = new System.Drawing.Size(123, 20);
			this.stylesSheetManager.SetStyle(this.txtImporteUnitarioForm, "TextBox");
			this.txtImporteUnitarioForm.TabIndex = 2;
			this.txtImporteUnitarioForm.Value = 0;
			this.txtImporteUnitarioForm.Validated += new System.EventHandler(this.txtImporteUnitarioForm_Validated);
			// 
			// txtCantidad
			// 
			this.txtCantidad.AllowNegatives = false;
			this.txtCantidad.DecimalPlaces = 2;
			this.txtCantidad.DecimalPoint = '.';
			this.txtCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.txtCantidad.ForeColor = System.Drawing.Color.Blue;
			this.txtCantidad.Location = new System.Drawing.Point(143, 63);
			this.txtCantidad.Name = "txtCantidad";
			this.txtCantidad.ShowCalculator = true;
			this.txtCantidad.Size = new System.Drawing.Size(123, 20);
			this.stylesSheetManager.SetStyle(this.txtCantidad, "TextBox");
			this.txtCantidad.TabIndex = 1;
			this.txtCantidad.Value = 1;
			// 
			// dcProducto
			// 
			this.dcProducto.DataType = null;
			this.dcProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.dcProducto.ForeColor = System.Drawing.Color.Blue;
			this.dcProducto.Location = new System.Drawing.Point(143, 28);
			this.dcProducto.Name = "dcProducto";
			this.dcProducto.Selected = null;
			this.dcProducto.ShowDelete = true;
			this.dcProducto.Size = new System.Drawing.Size(167, 20);
			this.stylesSheetManager.SetStyle(this.dcProducto, "TextBox");
			this.dcProducto.TabIndex = 0;
			this.dcProducto.TitleCRUD = null;
			this.dcProducto.TitleGrid = null;
			this.dcProducto.Load += new System.EventHandler(this.dcProducto_Load);
			this.dcProducto.ItemAssign += new FrameWork.CRUDModel.Windows.UI.DataCombo.ComboAction(this.dcProducto_ItemAssign);
			this.dcProducto.BrowseClick += new FrameWork.CRUDModel.Windows.UI.DataCombo.BrowseTypeEvent(this.dcProducto_BrowseClick);
			// 
			// lblProducto
			// 
			this.lblProducto.AutoSize = true;
			this.lblProducto.BackColor = System.Drawing.Color.Transparent;
			this.lblProducto.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblProducto.Location = new System.Drawing.Point(12, 28);
			this.lblProducto.Name = "lblProducto";
			this.lblProducto.Size = new System.Drawing.Size(65, 13);
			this.stylesSheetManager.SetStyle(this.lblProducto, "Label");
			this.lblProducto.TabIndex = 54;
			this.lblProducto.Text = "Producto";
			// 
			// lblCantidad
			// 
			this.lblCantidad.AutoSize = true;
			this.lblCantidad.BackColor = System.Drawing.Color.Transparent;
			this.lblCantidad.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblCantidad.Location = new System.Drawing.Point(12, 70);
			this.lblCantidad.Name = "lblCantidad";
			this.lblCantidad.Size = new System.Drawing.Size(64, 13);
			this.stylesSheetManager.SetStyle(this.lblCantidad, "Label");
			this.lblCantidad.TabIndex = 53;
			this.lblCantidad.Text = "Cantidad";
			// 
			// lblImporteUnitario
			// 
			this.lblImporteUnitario.AutoSize = true;
			this.lblImporteUnitario.BackColor = System.Drawing.Color.Transparent;
			this.lblImporteUnitario.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblImporteUnitario.Location = new System.Drawing.Point(12, 105);
			this.lblImporteUnitario.Name = "lblImporteUnitario";
			this.lblImporteUnitario.Size = new System.Drawing.Size(116, 13);
			this.stylesSheetManager.SetStyle(this.lblImporteUnitario, "Label");
			this.lblImporteUnitario.TabIndex = 52;
			this.lblImporteUnitario.Text = "Importe Unitario";
			// 
			// txtImporteUnitario
			// 
			this.txtImporteUnitario.Location = new System.Drawing.Point(143, 125);
			this.txtImporteUnitario.Name = "txtImporteUnitario";
			this.txtImporteUnitario.Size = new System.Drawing.Size(100, 20);
			this.stylesSheetManager.SetStyle(this.txtImporteUnitario, "");
			this.txtImporteUnitario.TabIndex = 55;
			this.txtImporteUnitario.Visible = false;
			// 
			// DetallesComprobantesCRUD
			// 
			this.AcceptButton = this.btnAccept;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(328, 186);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "DetallesComprobantesCRUD";
			this.stylesSheetManager.SetStyle(this, "FormType1");
			this.Text = "DetallesComprobantesCRUD";
			this.Title = "DetallesComprobantesCRUD";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.stylesSheetManager)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.GroupBox groupBox2;
        private WindowsFormsControls.NumericControl txtImporteUnitarioForm;
        private WindowsFormsControls.NumericControl txtCantidad;
        private FrameWork.CRUDModel.Windows.UI.DataCombo dcProducto;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblImporteUnitario;
        private Sb.Windows.Forms.StylesSheet.StylesSheetManager stylesSheetManager;
		private System.Windows.Forms.TextBox txtImporteUnitario;
    }
}