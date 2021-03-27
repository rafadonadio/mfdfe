namespace MFD
{
    partial class ClientesCRUD
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
			this.chkEnDolares = new System.Windows.Forms.CheckBox();
			this.lblEnDolares = new System.Windows.Forms.Label();
			this.lblId = new System.Windows.Forms.Label();
			this.txtCodigoPostal = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.txtTelefonos = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.dcPais = new FrameWork.CRUDModel.Windows.UI.DataCombo();
			this.label4 = new System.Windows.Forms.Label();
			this.dcProvincia = new FrameWork.CRUDModel.Windows.UI.DataCombo();
			this.txtLocalidad = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtDomicilio = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtCUIT = new System.Windows.Forms.MaskedTextBox();
			this.dcTipoPago = new FrameWork.CRUDModel.Windows.UI.DataCombo();
			this.label2 = new System.Windows.Forms.Label();
			this.chkIIBBExcento = new System.Windows.Forms.CheckBox();
			this.lblIIBBExento = new System.Windows.Forms.Label();
			this.dcTipoContribuyente = new FrameWork.CRUDModel.Windows.UI.DataCombo();
			this.lblTipoContrib = new System.Windows.Forms.Label();
			this.dcClase = new FrameWork.CRUDModel.Windows.UI.DataCombo();
			this.lbl = new System.Windows.Forms.Label();
			this.lblEmail = new System.Windows.Forms.Label();
			this.txtEmail = new System.Windows.Forms.TextBox();
			this.lblCUIT = new System.Windows.Forms.Label();
			this.lblCliente = new System.Windows.Forms.Label();
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
			this.groupBox1.Location = new System.Drawing.Point(0, 460);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(459, 45);
			this.stylesSheetManager.SetStyle(this.groupBox1, "GroupBox1");
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.BackColor = System.Drawing.Color.Transparent;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnCancel.Location = new System.Drawing.Point(378, 12);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.stylesSheetManager.SetStyle(this.btnCancel, "Button");
			this.btnCancel.TabIndex = 15;
			this.btnCancel.Text = "Cancelar";
			this.btnCancel.UseVisualStyleBackColor = false;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnAccept
			// 
			this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.btnAccept.BackColor = System.Drawing.Color.Transparent;
			this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAccept.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.btnAccept.Location = new System.Drawing.Point(6, 12);
			this.btnAccept.Name = "btnAccept";
			this.btnAccept.Size = new System.Drawing.Size(75, 23);
			this.stylesSheetManager.SetStyle(this.btnAccept, "Button");
			this.btnAccept.TabIndex = 14;
			this.btnAccept.Text = "Aceptar";
			this.btnAccept.UseVisualStyleBackColor = false;
			this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.BackColor = System.Drawing.Color.Transparent;
			this.groupBox2.Controls.Add(this.chkEnDolares);
			this.groupBox2.Controls.Add(this.lblEnDolares);
			this.groupBox2.Controls.Add(this.lblId);
			this.groupBox2.Controls.Add(this.txtCodigoPostal);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.txtTelefonos);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.dcPais);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.dcProvincia);
			this.groupBox2.Controls.Add(this.txtLocalidad);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.txtDomicilio);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.txtCUIT);
			this.groupBox2.Controls.Add(this.dcTipoPago);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.chkIIBBExcento);
			this.groupBox2.Controls.Add(this.lblIIBBExento);
			this.groupBox2.Controls.Add(this.dcTipoContribuyente);
			this.groupBox2.Controls.Add(this.lblTipoContrib);
			this.groupBox2.Controls.Add(this.dcClase);
			this.groupBox2.Controls.Add(this.lbl);
			this.groupBox2.Controls.Add(this.lblEmail);
			this.groupBox2.Controls.Add(this.txtEmail);
			this.groupBox2.Controls.Add(this.lblCUIT);
			this.groupBox2.Controls.Add(this.lblCliente);
			this.groupBox2.Controls.Add(this.txtNombre);
			this.groupBox2.Controls.Add(this.lblNombre);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.groupBox2.Location = new System.Drawing.Point(0, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(459, 454);
			this.stylesSheetManager.SetStyle(this.groupBox2, "GroupBox1");
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			// 
			// chkEnDolares
			// 
			this.chkEnDolares.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.chkEnDolares.AutoSize = true;
			this.chkEnDolares.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.chkEnDolares.ForeColor = System.Drawing.Color.Blue;
			this.chkEnDolares.Location = new System.Drawing.Point(372, 401);
			this.chkEnDolares.Name = "chkEnDolares";
			this.chkEnDolares.Size = new System.Drawing.Size(15, 14);
			this.stylesSheetManager.SetStyle(this.chkEnDolares, "TextBox");
			this.chkEnDolares.TabIndex = 70;
			this.chkEnDolares.UseVisualStyleBackColor = true;
			// 
			// lblEnDolares
			// 
			this.lblEnDolares.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lblEnDolares.AutoSize = true;
			this.lblEnDolares.BackColor = System.Drawing.Color.Transparent;
			this.lblEnDolares.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblEnDolares.Location = new System.Drawing.Point(222, 401);
			this.lblEnDolares.Name = "lblEnDolares";
			this.lblEnDolares.Size = new System.Drawing.Size(143, 13);
			this.stylesSheetManager.SetStyle(this.lblEnDolares, "Label");
			this.lblEnDolares.TabIndex = 71;
			this.lblEnDolares.Text = "Comprobante en U$S";
			// 
			// lblId
			// 
			this.lblId.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lblId.AutoSize = true;
			this.lblId.BackColor = System.Drawing.Color.Transparent;
			this.lblId.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblId.Location = new System.Drawing.Point(172, 25);
			this.lblId.Name = "lblId";
			this.lblId.Size = new System.Drawing.Size(0, 13);
			this.stylesSheetManager.SetStyle(this.lblId, "Label");
			this.lblId.TabIndex = 69;
			// 
			// txtCodigoPostal
			// 
			this.txtCodigoPostal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtCodigoPostal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.txtCodigoPostal.ForeColor = System.Drawing.Color.Blue;
			this.txtCodigoPostal.Location = new System.Drawing.Point(175, 250);
			this.txtCodigoPostal.Name = "txtCodigoPostal";
			this.txtCodigoPostal.Size = new System.Drawing.Size(210, 20);
			this.stylesSheetManager.SetStyle(this.txtCodigoPostal, "TextBox");
			this.txtCodigoPostal.TabIndex = 8;
			// 
			// label7
			// 
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label7.AutoSize = true;
			this.label7.BackColor = System.Drawing.Color.Transparent;
			this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.label7.Location = new System.Drawing.Point(47, 253);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(95, 13);
			this.stylesSheetManager.SetStyle(this.label7, "Label");
			this.label7.TabIndex = 68;
			this.label7.Text = "Código Postal";
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label6.AutoSize = true;
			this.label6.BackColor = System.Drawing.Color.Transparent;
			this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.label6.Location = new System.Drawing.Point(47, 346);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(71, 13);
			this.stylesSheetManager.SetStyle(this.label6, "Label");
			this.label6.TabIndex = 66;
			this.label6.Text = "Telefonos";
			// 
			// txtTelefonos
			// 
			this.txtTelefonos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtTelefonos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.txtTelefonos.ForeColor = System.Drawing.Color.Blue;
			this.txtTelefonos.Location = new System.Drawing.Point(175, 340);
			this.txtTelefonos.Name = "txtTelefonos";
			this.txtTelefonos.Size = new System.Drawing.Size(210, 20);
			this.stylesSheetManager.SetStyle(this.txtTelefonos, "TextBox");
			this.txtTelefonos.TabIndex = 11;
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.label5.Location = new System.Drawing.Point(47, 318);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(34, 13);
			this.stylesSheetManager.SetStyle(this.label5, "Label");
			this.label5.TabIndex = 64;
			this.label5.Text = "País";
			// 
			// dcPais
			// 
			this.dcPais.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dcPais.DataType = null;
			this.dcPais.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.dcPais.ForeColor = System.Drawing.Color.Blue;
			this.dcPais.Location = new System.Drawing.Point(175, 311);
			this.dcPais.Name = "dcPais";
			this.dcPais.Selected = null;
			this.dcPais.ShowDelete = true;
			this.dcPais.Size = new System.Drawing.Size(210, 20);
			this.stylesSheetManager.SetStyle(this.dcPais, "TextBox");
			this.dcPais.TabIndex = 10;
			this.dcPais.TitleCRUD = null;
			this.dcPais.TitleGrid = null;
			this.dcPais.Load += new System.EventHandler(this.dcPais_Load);
			this.dcPais.BrowseClick += new FrameWork.CRUDModel.Windows.UI.DataCombo.BrowseTypeEvent(this.dcPais_BrowseClick);
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.label4.Location = new System.Drawing.Point(47, 289);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(68, 13);
			this.stylesSheetManager.SetStyle(this.label4, "Label");
			this.label4.TabIndex = 62;
			this.label4.Text = "Provincia";
			// 
			// dcProvincia
			// 
			this.dcProvincia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dcProvincia.DataType = null;
			this.dcProvincia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.dcProvincia.ForeColor = System.Drawing.Color.Blue;
			this.dcProvincia.Location = new System.Drawing.Point(175, 282);
			this.dcProvincia.Name = "dcProvincia";
			this.dcProvincia.Selected = null;
			this.dcProvincia.ShowDelete = true;
			this.dcProvincia.Size = new System.Drawing.Size(210, 20);
			this.stylesSheetManager.SetStyle(this.dcProvincia, "TextBox");
			this.dcProvincia.TabIndex = 9;
			this.dcProvincia.TitleCRUD = null;
			this.dcProvincia.TitleGrid = null;
			this.dcProvincia.Load += new System.EventHandler(this.dcProvincia_Load);
			this.dcProvincia.BrowseClick += new FrameWork.CRUDModel.Windows.UI.DataCombo.BrowseTypeEvent(this.dcProvincia_BrowseClick);
			// 
			// txtLocalidad
			// 
			this.txtLocalidad.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtLocalidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.txtLocalidad.ForeColor = System.Drawing.Color.Blue;
			this.txtLocalidad.Location = new System.Drawing.Point(175, 219);
			this.txtLocalidad.Name = "txtLocalidad";
			this.txtLocalidad.Size = new System.Drawing.Size(210, 20);
			this.stylesSheetManager.SetStyle(this.txtLocalidad, "TextBox");
			this.txtLocalidad.TabIndex = 7;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.label3.Location = new System.Drawing.Point(47, 222);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(69, 13);
			this.stylesSheetManager.SetStyle(this.label3, "Label");
			this.label3.TabIndex = 59;
			this.label3.Text = "Localidad";
			// 
			// txtDomicilio
			// 
			this.txtDomicilio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtDomicilio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.txtDomicilio.ForeColor = System.Drawing.Color.Blue;
			this.txtDomicilio.Location = new System.Drawing.Point(175, 189);
			this.txtDomicilio.Name = "txtDomicilio";
			this.txtDomicilio.Size = new System.Drawing.Size(210, 20);
			this.stylesSheetManager.SetStyle(this.txtDomicilio, "TextBox");
			this.txtDomicilio.TabIndex = 6;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.label1.Location = new System.Drawing.Point(47, 192);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(67, 13);
			this.stylesSheetManager.SetStyle(this.label1, "Label");
			this.label1.TabIndex = 57;
			this.label1.Text = "Domicilio";
			// 
			// txtCUIT
			// 
			this.txtCUIT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtCUIT.Culture = new System.Globalization.CultureInfo("es-AR");
			this.txtCUIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.txtCUIT.ForeColor = System.Drawing.Color.Blue;
			this.txtCUIT.Location = new System.Drawing.Point(175, 71);
			this.txtCUIT.Mask = "00-00000000-0";
			this.txtCUIT.Name = "txtCUIT";
			this.txtCUIT.Size = new System.Drawing.Size(110, 20);
			this.stylesSheetManager.SetStyle(this.txtCUIT, "TextBox");
			this.txtCUIT.TabIndex = 2;
			// 
			// dcTipoPago
			// 
			this.dcTipoPago.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dcTipoPago.DataType = null;
			this.dcTipoPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.dcTipoPago.ForeColor = System.Drawing.Color.Blue;
			this.dcTipoPago.Location = new System.Drawing.Point(175, 159);
			this.dcTipoPago.Name = "dcTipoPago";
			this.dcTipoPago.Selected = null;
			this.dcTipoPago.ShowDelete = true;
			this.dcTipoPago.Size = new System.Drawing.Size(210, 20);
			this.stylesSheetManager.SetStyle(this.dcTipoPago, "TextBox");
			this.dcTipoPago.TabIndex = 5;
			this.dcTipoPago.TitleCRUD = null;
			this.dcTipoPago.TitleGrid = null;
			this.dcTipoPago.Load += new System.EventHandler(this.dcTipoPago_Load);
			this.dcTipoPago.BrowseClick += new FrameWork.CRUDModel.Windows.UI.DataCombo.BrowseTypeEvent(this.dcTipoPago_BrowseClick);
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.label2.Location = new System.Drawing.Point(47, 166);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(91, 13);
			this.stylesSheetManager.SetStyle(this.label2, "Label");
			this.label2.TabIndex = 56;
			this.label2.Text = "Tipo de Pago";
			// 
			// chkIIBBExcento
			// 
			this.chkIIBBExcento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.chkIIBBExcento.AutoSize = true;
			this.chkIIBBExcento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.chkIIBBExcento.ForeColor = System.Drawing.Color.Blue;
			this.chkIIBBExcento.Location = new System.Drawing.Point(175, 401);
			this.chkIIBBExcento.Name = "chkIIBBExcento";
			this.chkIIBBExcento.Size = new System.Drawing.Size(15, 14);
			this.stylesSheetManager.SetStyle(this.chkIIBBExcento, "TextBox");
			this.chkIIBBExcento.TabIndex = 13;
			this.chkIIBBExcento.UseVisualStyleBackColor = true;
			// 
			// lblIIBBExento
			// 
			this.lblIIBBExento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lblIIBBExento.AutoSize = true;
			this.lblIIBBExento.BackColor = System.Drawing.Color.Transparent;
			this.lblIIBBExento.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblIIBBExento.Location = new System.Drawing.Point(47, 401);
			this.lblIIBBExento.Name = "lblIIBBExento";
			this.lblIIBBExento.Size = new System.Drawing.Size(84, 13);
			this.stylesSheetManager.SetStyle(this.lblIIBBExento, "Label");
			this.lblIIBBExento.TabIndex = 53;
			this.lblIIBBExento.Text = "IIBB Exento";
			// 
			// dcTipoContribuyente
			// 
			this.dcTipoContribuyente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dcTipoContribuyente.DataType = null;
			this.dcTipoContribuyente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.dcTipoContribuyente.ForeColor = System.Drawing.Color.Blue;
			this.dcTipoContribuyente.Location = new System.Drawing.Point(175, 129);
			this.dcTipoContribuyente.Name = "dcTipoContribuyente";
			this.dcTipoContribuyente.Selected = null;
			this.dcTipoContribuyente.ShowDelete = true;
			this.dcTipoContribuyente.Size = new System.Drawing.Size(210, 20);
			this.stylesSheetManager.SetStyle(this.dcTipoContribuyente, "TextBox");
			this.dcTipoContribuyente.TabIndex = 4;
			this.dcTipoContribuyente.TitleCRUD = null;
			this.dcTipoContribuyente.TitleGrid = null;
			this.dcTipoContribuyente.Load += new System.EventHandler(this.dcTipoContribuyente_Load);
			this.dcTipoContribuyente.BrowseClick += new FrameWork.CRUDModel.Windows.UI.DataCombo.BrowseTypeEvent(this.dcTipoContribuyente_BrowseClick);
			// 
			// lblTipoContrib
			// 
			this.lblTipoContrib.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lblTipoContrib.AutoSize = true;
			this.lblTipoContrib.BackColor = System.Drawing.Color.Transparent;
			this.lblTipoContrib.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblTipoContrib.Location = new System.Drawing.Point(47, 136);
			this.lblTipoContrib.Name = "lblTipoContrib";
			this.lblTipoContrib.Size = new System.Drawing.Size(99, 13);
			this.stylesSheetManager.SetStyle(this.lblTipoContrib, "Label");
			this.lblTipoContrib.TabIndex = 50;
			this.lblTipoContrib.Text = "Contribuyente";
			// 
			// dcClase
			// 
			this.dcClase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dcClase.DataType = null;
			this.dcClase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.dcClase.ForeColor = System.Drawing.Color.Blue;
			this.dcClase.Location = new System.Drawing.Point(175, 101);
			this.dcClase.Name = "dcClase";
			this.dcClase.Selected = null;
			this.dcClase.ShowDelete = true;
			this.dcClase.Size = new System.Drawing.Size(210, 20);
			this.stylesSheetManager.SetStyle(this.dcClase, "TextBox");
			this.dcClase.TabIndex = 3;
			this.dcClase.TitleCRUD = null;
			this.dcClase.TitleGrid = null;
			this.dcClase.Load += new System.EventHandler(this.dcClase_Load);
			this.dcClase.BrowseClick += new FrameWork.CRUDModel.Windows.UI.DataCombo.BrowseTypeEvent(this.dcClase_BrowseClick);
			// 
			// lbl
			// 
			this.lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lbl.AutoSize = true;
			this.lbl.BackColor = System.Drawing.Color.Transparent;
			this.lbl.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.lbl.Location = new System.Drawing.Point(47, 107);
			this.lbl.Name = "lbl";
			this.lbl.Size = new System.Drawing.Size(46, 13);
			this.stylesSheetManager.SetStyle(this.lbl, "Label");
			this.lbl.TabIndex = 19;
			this.lbl.Text = "Clase ";
			// 
			// lblEmail
			// 
			this.lblEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lblEmail.AutoSize = true;
			this.lblEmail.BackColor = System.Drawing.Color.Transparent;
			this.lblEmail.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblEmail.Location = new System.Drawing.Point(47, 376);
			this.lblEmail.Name = "lblEmail";
			this.lblEmail.Size = new System.Drawing.Size(43, 13);
			this.stylesSheetManager.SetStyle(this.lblEmail, "Label");
			this.lblEmail.TabIndex = 18;
			this.lblEmail.Text = "Email";
			// 
			// txtEmail
			// 
			this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.txtEmail.ForeColor = System.Drawing.Color.Blue;
			this.txtEmail.Location = new System.Drawing.Point(175, 370);
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(210, 20);
			this.stylesSheetManager.SetStyle(this.txtEmail, "TextBox");
			this.txtEmail.TabIndex = 12;
			// 
			// lblCUIT
			// 
			this.lblCUIT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lblCUIT.AutoSize = true;
			this.lblCUIT.BackColor = System.Drawing.Color.Transparent;
			this.lblCUIT.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblCUIT.Location = new System.Drawing.Point(47, 79);
			this.lblCUIT.Name = "lblCUIT";
			this.lblCUIT.Size = new System.Drawing.Size(38, 13);
			this.stylesSheetManager.SetStyle(this.lblCUIT, "Label");
			this.lblCUIT.TabIndex = 14;
			this.lblCUIT.Text = "CUIT";
			// 
			// lblCliente
			// 
			this.lblCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lblCliente.AutoSize = true;
			this.lblCliente.BackColor = System.Drawing.Color.Transparent;
			this.lblCliente.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblCliente.Location = new System.Drawing.Point(47, 25);
			this.lblCliente.Name = "lblCliente";
			this.lblCliente.Size = new System.Drawing.Size(52, 13);
			this.stylesSheetManager.SetStyle(this.lblCliente, "Label");
			this.lblCliente.TabIndex = 12;
			this.lblCliente.Text = "Cliente";
			// 
			// txtNombre
			// 
			this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.txtNombre.ForeColor = System.Drawing.Color.Blue;
			this.txtNombre.Location = new System.Drawing.Point(175, 46);
			this.txtNombre.Name = "txtNombre";
			this.txtNombre.Size = new System.Drawing.Size(210, 20);
			this.stylesSheetManager.SetStyle(this.txtNombre, "TextBox");
			this.txtNombre.TabIndex = 1;
			// 
			// lblNombre
			// 
			this.lblNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lblNombre.AutoSize = true;
			this.lblNombre.BackColor = System.Drawing.Color.Transparent;
			this.lblNombre.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblNombre.Location = new System.Drawing.Point(47, 52);
			this.lblNombre.Name = "lblNombre";
			this.lblNombre.Size = new System.Drawing.Size(58, 13);
			this.stylesSheetManager.SetStyle(this.lblNombre, "Label");
			this.lblNombre.TabIndex = 9;
			this.lblNombre.Text = "Nombre";
			// 
			// ClientesCRUD
			// 
			this.AcceptButton = this.btnAccept;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(459, 505);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.Name = "ClientesCRUD";
			this.stylesSheetManager.SetStyle(this, "FormType1");
			this.Text = "ClientesCRUD";
			this.Title = "ClientesCRUD";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.stylesSheetManager)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblCUIT;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lbl;
        private FrameWork.CRUDModel.Windows.UI.DataCombo dcClase;
        private FrameWork.CRUDModel.Windows.UI.DataCombo dcTipoContribuyente;
        private System.Windows.Forms.Label lblTipoContrib;
        private System.Windows.Forms.CheckBox chkIIBBExcento;
        private System.Windows.Forms.Label lblIIBBExento;
        private FrameWork.CRUDModel.Windows.UI.DataCombo dcTipoPago;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtCUIT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLocalidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDomicilio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTelefonos;
        private System.Windows.Forms.Label label5;
        private FrameWork.CRUDModel.Windows.UI.DataCombo dcPais;
        private System.Windows.Forms.Label label4;
        private FrameWork.CRUDModel.Windows.UI.DataCombo dcProvincia;
        private Sb.Windows.Forms.StylesSheet.StylesSheetManager stylesSheetManager;
        private System.Windows.Forms.TextBox txtCodigoPostal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblId;
		private System.Windows.Forms.CheckBox chkEnDolares;
		private System.Windows.Forms.Label lblEnDolares;
    }
}