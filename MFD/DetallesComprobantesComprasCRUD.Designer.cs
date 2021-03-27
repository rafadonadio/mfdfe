namespace MFD {
    partial class DetallesComprobantesComprasCRUD {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.stylesSheetManager = new Sb.Windows.Forms.StylesSheet.StylesSheetManager(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtImporteOperacionesExentas = new WindowsFormsControls.NumericControl();
            this.lblImporteOperacionesExentas = new System.Windows.Forms.Label();
            this.txtImporteNoGravado = new WindowsFormsControls.NumericControl();
            this.lblImporteNoGravado = new System.Windows.Forms.Label();
            this.cmbTipoIva = new System.Windows.Forms.ComboBox();
            this.lblTipoIVA = new System.Windows.Forms.Label();
            this.txtImporteGravado = new WindowsFormsControls.NumericControl();
            this.lblImporteGravado = new System.Windows.Forms.Label();
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
            this.groupBox1.Location = new System.Drawing.Point(0, 125);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(309, 40);
            this.stylesSheetManager.SetStyle(this.groupBox1, "GroupBox1");
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(228, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.stylesSheetManager.SetStyle(this.btnCancel, "Button");
            this.btnCancel.TabIndex = 1;
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
            this.btnAccept.TabIndex = 0;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtImporteOperacionesExentas);
            this.groupBox2.Controls.Add(this.lblImporteOperacionesExentas);
            this.groupBox2.Controls.Add(this.txtImporteNoGravado);
            this.groupBox2.Controls.Add(this.lblImporteNoGravado);
            this.groupBox2.Controls.Add(this.cmbTipoIva);
            this.groupBox2.Controls.Add(this.lblTipoIVA);
            this.groupBox2.Controls.Add(this.txtImporteGravado);
            this.groupBox2.Controls.Add(this.lblImporteGravado);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(309, 125);
            this.stylesSheetManager.SetStyle(this.groupBox2, "");
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // txtImporteOperacionesExentas
            // 
            this.txtImporteOperacionesExentas.AllowNegatives = false;
            this.txtImporteOperacionesExentas.DecimalPlaces = 2;
            this.txtImporteOperacionesExentas.DecimalPoint = '.';
            this.txtImporteOperacionesExentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtImporteOperacionesExentas.ForeColor = System.Drawing.Color.Blue;
            this.txtImporteOperacionesExentas.Location = new System.Drawing.Point(163, 93);
            this.txtImporteOperacionesExentas.Name = "txtImporteOperacionesExentas";
            this.txtImporteOperacionesExentas.ShowCalculator = true;
            this.txtImporteOperacionesExentas.Size = new System.Drawing.Size(123, 20);
            this.stylesSheetManager.SetStyle(this.txtImporteOperacionesExentas, "TextBox");
            this.txtImporteOperacionesExentas.TabIndex = 3;
            this.txtImporteOperacionesExentas.Value = 0;
            // 
            // lblImporteOperacionesExentas
            // 
            this.lblImporteOperacionesExentas.AutoSize = true;
            this.lblImporteOperacionesExentas.BackColor = System.Drawing.Color.Transparent;
            this.lblImporteOperacionesExentas.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblImporteOperacionesExentas.Location = new System.Drawing.Point(19, 100);
            this.lblImporteOperacionesExentas.Name = "lblImporteOperacionesExentas";
            this.lblImporteOperacionesExentas.Size = new System.Drawing.Size(109, 13);
            this.stylesSheetManager.SetStyle(this.lblImporteOperacionesExentas, "Label");
            this.lblImporteOperacionesExentas.TabIndex = 64;
            this.lblImporteOperacionesExentas.Text = "Importe Exento";
            // 
            // txtImporteNoGravado
            // 
            this.txtImporteNoGravado.AllowNegatives = false;
            this.txtImporteNoGravado.DecimalPlaces = 2;
            this.txtImporteNoGravado.DecimalPoint = '.';
            this.txtImporteNoGravado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtImporteNoGravado.ForeColor = System.Drawing.Color.Blue;
            this.txtImporteNoGravado.Location = new System.Drawing.Point(163, 67);
            this.txtImporteNoGravado.Name = "txtImporteNoGravado";
            this.txtImporteNoGravado.ShowCalculator = true;
            this.txtImporteNoGravado.Size = new System.Drawing.Size(123, 20);
            this.stylesSheetManager.SetStyle(this.txtImporteNoGravado, "TextBox");
            this.txtImporteNoGravado.TabIndex = 2;
            this.txtImporteNoGravado.Value = 0;
            // 
            // lblImporteNoGravado
            // 
            this.lblImporteNoGravado.AutoSize = true;
            this.lblImporteNoGravado.BackColor = System.Drawing.Color.Transparent;
            this.lblImporteNoGravado.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblImporteNoGravado.Location = new System.Drawing.Point(19, 74);
            this.lblImporteNoGravado.Name = "lblImporteNoGravado";
            this.lblImporteNoGravado.Size = new System.Drawing.Size(139, 13);
            this.stylesSheetManager.SetStyle(this.lblImporteNoGravado, "Label");
            this.lblImporteNoGravado.TabIndex = 62;
            this.lblImporteNoGravado.Text = "Importe no Gravado";
            // 
            // cmbTipoIva
            // 
            this.cmbTipoIva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoIva.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbTipoIva.ForeColor = System.Drawing.Color.Blue;
            this.cmbTipoIva.FormattingEnabled = true;
            this.cmbTipoIva.Location = new System.Drawing.Point(163, 14);
            this.cmbTipoIva.Name = "cmbTipoIva";
            this.cmbTipoIva.Size = new System.Drawing.Size(123, 21);
            this.stylesSheetManager.SetStyle(this.cmbTipoIva, "TextBox");
            this.cmbTipoIva.TabIndex = 0;
            // 
            // lblTipoIVA
            // 
            this.lblTipoIVA.AutoSize = true;
            this.lblTipoIVA.BackColor = System.Drawing.Color.Transparent;
            this.lblTipoIVA.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTipoIVA.Location = new System.Drawing.Point(22, 22);
            this.lblTipoIVA.Name = "lblTipoIVA";
            this.lblTipoIVA.Size = new System.Drawing.Size(30, 13);
            this.stylesSheetManager.SetStyle(this.lblTipoIVA, "Label");
            this.lblTipoIVA.TabIndex = 60;
            this.lblTipoIVA.Text = "IVA";
            // 
            // txtImporteGravado
            // 
            this.txtImporteGravado.AllowNegatives = false;
            this.txtImporteGravado.DecimalPlaces = 2;
            this.txtImporteGravado.DecimalPoint = '.';
            this.txtImporteGravado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtImporteGravado.ForeColor = System.Drawing.Color.Blue;
            this.txtImporteGravado.Location = new System.Drawing.Point(163, 41);
            this.txtImporteGravado.Name = "txtImporteGravado";
            this.txtImporteGravado.ShowCalculator = true;
            this.txtImporteGravado.Size = new System.Drawing.Size(123, 20);
            this.stylesSheetManager.SetStyle(this.txtImporteGravado, "TextBox");
            this.txtImporteGravado.TabIndex = 1;
            this.txtImporteGravado.Value = 0;
            // 
            // lblImporteGravado
            // 
            this.lblImporteGravado.AutoSize = true;
            this.lblImporteGravado.BackColor = System.Drawing.Color.Transparent;
            this.lblImporteGravado.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblImporteGravado.Location = new System.Drawing.Point(19, 48);
            this.lblImporteGravado.Name = "lblImporteGravado";
            this.lblImporteGravado.Size = new System.Drawing.Size(119, 13);
            this.stylesSheetManager.SetStyle(this.lblImporteGravado, "Label");
            this.lblImporteGravado.TabIndex = 54;
            this.lblImporteGravado.Text = "Importe Gravado";
            // 
            // DetallesComprobantesComprasCRUD
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(309, 165);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DetallesComprobantesComprasCRUD";
            this.stylesSheetManager.SetStyle(this, "");
            this.Text = "DetallesComprobantesComprasCRUD";
            this.Title = "DetallesComprobantesComprasCRUD";
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
        private WindowsFormsControls.NumericControl txtImporteGravado;
        private System.Windows.Forms.Label lblImporteGravado;
        private System.Windows.Forms.ComboBox cmbTipoIva;
        private System.Windows.Forms.Label lblTipoIVA;
        private WindowsFormsControls.NumericControl txtImporteOperacionesExentas;
        private System.Windows.Forms.Label lblImporteOperacionesExentas;
        private WindowsFormsControls.NumericControl txtImporteNoGravado;
        private System.Windows.Forms.Label lblImporteNoGravado;
    }
}