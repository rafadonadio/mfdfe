namespace MFD
{
    partial class RepeticionesCRUD
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
			this.txtId = new System.Windows.Forms.TextBox();
			this.txtTipoComprobante = new System.Windows.Forms.TextBox();
			this.txtNroComprobante = new System.Windows.Forms.TextBox();
			this.lblTipoComprobante = new System.Windows.Forms.Label();
			this.lblNroComprobante = new System.Windows.Forms.Label();
			this.cboDiaMes = new System.Windows.Forms.NumericUpDown();
			this.lblFechaHasta = new System.Windows.Forms.Label();
			this.lblDiaMes = new System.Windows.Forms.Label();
			this.txtHasta = new System.Windows.Forms.DateTimePicker();
			this.stylesSheetManager = new Sb.Windows.Forms.StylesSheet.StylesSheetManager(this.components);
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cboDiaMes)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.stylesSheetManager)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.Color.Transparent;
			this.groupBox1.Controls.Add(this.btnCancel);
			this.groupBox1.Controls.Add(this.btnAccept);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.groupBox1.Location = new System.Drawing.Point(0, 169);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(361, 40);
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
			this.btnCancel.Location = new System.Drawing.Point(280, 12);
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
			this.groupBox2.Controls.Add(this.txtId);
			this.groupBox2.Controls.Add(this.txtTipoComprobante);
			this.groupBox2.Controls.Add(this.txtNroComprobante);
			this.groupBox2.Controls.Add(this.lblTipoComprobante);
			this.groupBox2.Controls.Add(this.lblNroComprobante);
			this.groupBox2.Controls.Add(this.cboDiaMes);
			this.groupBox2.Controls.Add(this.lblFechaHasta);
			this.groupBox2.Controls.Add(this.lblDiaMes);
			this.groupBox2.Controls.Add(this.txtHasta);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox2.Location = new System.Drawing.Point(0, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(361, 163);
			this.stylesSheetManager.SetStyle(this.groupBox2, "GroupBox1");
			this.groupBox2.TabIndex = 7;
			this.groupBox2.TabStop = false;
			// 
			// txtId
			// 
			this.txtId.Location = new System.Drawing.Point(151, 127);
			this.txtId.Name = "txtId";
			this.txtId.Size = new System.Drawing.Size(100, 20);
			this.stylesSheetManager.SetStyle(this.txtId, "");
			this.txtId.TabIndex = 17;
			this.txtId.Visible = false;
			// 
			// txtTipoComprobante
			// 
			this.txtTipoComprobante.Enabled = false;
			this.txtTipoComprobante.Location = new System.Drawing.Point(151, 12);
			this.txtTipoComprobante.Name = "txtTipoComprobante";
			this.txtTipoComprobante.ReadOnly = true;
			this.txtTipoComprobante.Size = new System.Drawing.Size(198, 20);
			this.stylesSheetManager.SetStyle(this.txtTipoComprobante, "");
			this.txtTipoComprobante.TabIndex = 16;
			// 
			// txtNroComprobante
			// 
			this.txtNroComprobante.Enabled = false;
			this.txtNroComprobante.Location = new System.Drawing.Point(151, 38);
			this.txtNroComprobante.Name = "txtNroComprobante";
			this.txtNroComprobante.ReadOnly = true;
			this.txtNroComprobante.Size = new System.Drawing.Size(198, 20);
			this.stylesSheetManager.SetStyle(this.txtNroComprobante, "");
			this.txtNroComprobante.TabIndex = 15;
			// 
			// lblTipoComprobante
			// 
			this.lblTipoComprobante.AutoSize = true;
			this.lblTipoComprobante.BackColor = System.Drawing.Color.Transparent;
			this.lblTipoComprobante.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblTipoComprobante.Location = new System.Drawing.Point(23, 16);
			this.lblTipoComprobante.Name = "lblTipoComprobante";
			this.lblTipoComprobante.Size = new System.Drawing.Size(126, 13);
			this.stylesSheetManager.SetStyle(this.lblTipoComprobante, "Label");
			this.lblTipoComprobante.TabIndex = 14;
			this.lblTipoComprobante.Text = "Tipo Comprobante";
			// 
			// lblNroComprobante
			// 
			this.lblNroComprobante.AutoSize = true;
			this.lblNroComprobante.BackColor = System.Drawing.Color.Transparent;
			this.lblNroComprobante.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblNroComprobante.Location = new System.Drawing.Point(23, 41);
			this.lblNroComprobante.Name = "lblNroComprobante";
			this.lblNroComprobante.Size = new System.Drawing.Size(125, 13);
			this.stylesSheetManager.SetStyle(this.lblNroComprobante, "Label");
			this.lblNroComprobante.TabIndex = 13;
			this.lblNroComprobante.Text = "Nro. Comprobante";
			// 
			// cboDiaMes
			// 
			this.cboDiaMes.Location = new System.Drawing.Point(151, 64);
			this.cboDiaMes.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
			this.cboDiaMes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.cboDiaMes.Name = "cboDiaMes";
			this.cboDiaMes.Size = new System.Drawing.Size(46, 20);
			this.stylesSheetManager.SetStyle(this.cboDiaMes, "");
			this.cboDiaMes.TabIndex = 12;
			this.cboDiaMes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// lblFechaHasta
			// 
			this.lblFechaHasta.AutoSize = true;
			this.lblFechaHasta.BackColor = System.Drawing.Color.Transparent;
			this.lblFechaHasta.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblFechaHasta.Location = new System.Drawing.Point(23, 91);
			this.lblFechaHasta.Name = "lblFechaHasta";
			this.lblFechaHasta.Size = new System.Drawing.Size(87, 13);
			this.stylesSheetManager.SetStyle(this.lblFechaHasta, "Label");
			this.lblFechaHasta.TabIndex = 10;
			this.lblFechaHasta.Text = "Fecha Hasta";
			// 
			// lblDiaMes
			// 
			this.lblDiaMes.AutoSize = true;
			this.lblDiaMes.BackColor = System.Drawing.Color.Transparent;
			this.lblDiaMes.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblDiaMes.Location = new System.Drawing.Point(23, 66);
			this.lblDiaMes.Name = "lblDiaMes";
			this.lblDiaMes.Size = new System.Drawing.Size(83, 13);
			this.stylesSheetManager.SetStyle(this.lblDiaMes, "Label");
			this.lblDiaMes.TabIndex = 9;
			this.lblDiaMes.Text = "Día del mes";
			// 
			// txtHasta
			// 
			this.txtHasta.Location = new System.Drawing.Point(151, 90);
			this.txtHasta.Name = "txtHasta";
			this.txtHasta.Size = new System.Drawing.Size(200, 20);
			this.stylesSheetManager.SetStyle(this.txtHasta, "");
			this.txtHasta.TabIndex = 11;
			// 
			// RepeticionesCRUD
			// 
			this.AcceptButton = this.btnAccept;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(361, 209);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.Name = "RepeticionesCRUD";
			this.stylesSheetManager.SetStyle(this, "FormType1");
			this.Text = "RepeticionesCRUD";
			this.Title = "RepeticionesCRUD";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.cboDiaMes)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.stylesSheetManager)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblDiaMes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
		private System.Windows.Forms.Label lblFechaHasta;
        private Sb.Windows.Forms.StylesSheet.StylesSheetManager stylesSheetManager;
		private System.Windows.Forms.Label lblNroComprobante;
		private System.Windows.Forms.NumericUpDown cboDiaMes;
		private System.Windows.Forms.DateTimePicker txtHasta;
		private System.Windows.Forms.TextBox txtId;
		private System.Windows.Forms.TextBox txtTipoComprobante;
		private System.Windows.Forms.TextBox txtNroComprobante;
		private System.Windows.Forms.Label lblTipoComprobante;
    }
}