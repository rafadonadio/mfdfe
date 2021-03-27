namespace MFD
{
    partial class GeneralSettingsForm
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
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.tbcMain = new System.Windows.Forms.TabControl();
			this.tbpGeneral = new System.Windows.Forms.TabPage();
			this.txtCotizacionUS = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.cmbFormatoComprobante = new System.Windows.Forms.ComboBox();
			this.lblFormatoComprobante = new System.Windows.Forms.Label();
			this.btnBrowseFolder = new System.Windows.Forms.Button();
			this.txtFilesFolder = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtCodigoMoneda = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtCodigoCUIT = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbEmpresas = new System.Windows.Forms.ComboBox();
			this.lblFTPHost = new System.Windows.Forms.Label();
			this.tbpEMail = new System.Windows.Forms.TabPage();
			this.txtEmailTexto = new System.Windows.Forms.TextBox();
			this.lblEmailTexto = new System.Windows.Forms.Label();
			this.txtEmailReclamos = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.chkSmtpSSLEnabled = new System.Windows.Forms.CheckBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtSmtpServerPort = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtEmailSubject = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtSmtpPass = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtSmtpUser = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtSmtpServer = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtEmail = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tbpCAE = new System.Windows.Forms.TabPage();
			this.txtWSNegocio = new System.Windows.Forms.TextBox();
			this.lblWSNegocio = new System.Windows.Forms.Label();
			this.txtNTPServer = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.tbpPublicacion = new System.Windows.Forms.TabPage();
			this.txtWSPublicacion = new System.Windows.Forms.TextBox();
			this.lblWSPublicacion = new System.Windows.Forms.Label();
			this.stylesSheetManager = new Sb.Windows.Forms.StylesSheet.StylesSheetManager(this.components);
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
			this.btnObtenerCotizacion = new System.Windows.Forms.Button();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.groupBox1.SuspendLayout();
			this.tbcMain.SuspendLayout();
			this.tbpGeneral.SuspendLayout();
			this.tbpEMail.SuspendLayout();
			this.tbpCAE.SuspendLayout();
			this.tbpPublicacion.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.stylesSheetManager)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.Color.Transparent;
			this.groupBox1.Controls.Add(this.btnCancel);
			this.groupBox1.Controls.Add(this.btnAccept);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.groupBox1.Location = new System.Drawing.Point(0, 260);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(380, 40);
			this.stylesSheetManager.SetStyle(this.groupBox1, "GroupBox1");
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.BackColor = System.Drawing.Color.Transparent;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.btnCancel.Location = new System.Drawing.Point(299, 12);
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
			// tbcMain
			// 
			this.tbcMain.Controls.Add(this.tbpGeneral);
			this.tbcMain.Controls.Add(this.tbpEMail);
			this.tbcMain.Controls.Add(this.tbpCAE);
			this.tbcMain.Controls.Add(this.tbpPublicacion);
			this.tbcMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbcMain.Location = new System.Drawing.Point(0, 0);
			this.tbcMain.Name = "tbcMain";
			this.tbcMain.SelectedIndex = 0;
			this.tbcMain.Size = new System.Drawing.Size(380, 260);
			this.stylesSheetManager.SetStyle(this.tbcMain, "");
			this.tbcMain.TabIndex = 13;
			// 
			// tbpGeneral
			// 
			this.tbpGeneral.BackColor = System.Drawing.Color.Transparent;
			this.tbpGeneral.Controls.Add(this.btnObtenerCotizacion);
			this.tbpGeneral.Controls.Add(this.txtCotizacionUS);
			this.tbpGeneral.Controls.Add(this.label13);
			this.tbpGeneral.Controls.Add(this.cmbFormatoComprobante);
			this.tbpGeneral.Controls.Add(this.lblFormatoComprobante);
			this.tbpGeneral.Controls.Add(this.btnBrowseFolder);
			this.tbpGeneral.Controls.Add(this.txtFilesFolder);
			this.tbpGeneral.Controls.Add(this.label3);
			this.tbpGeneral.Controls.Add(this.txtCodigoMoneda);
			this.tbpGeneral.Controls.Add(this.label2);
			this.tbpGeneral.Controls.Add(this.txtCodigoCUIT);
			this.tbpGeneral.Controls.Add(this.label1);
			this.tbpGeneral.Controls.Add(this.cmbEmpresas);
			this.tbpGeneral.Controls.Add(this.lblFTPHost);
			this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
			this.tbpGeneral.Name = "tbpGeneral";
			this.tbpGeneral.Padding = new System.Windows.Forms.Padding(3);
			this.tbpGeneral.Size = new System.Drawing.Size(372, 234);
			this.stylesSheetManager.SetStyle(this.tbpGeneral, "");
			this.tbpGeneral.TabIndex = 0;
			this.tbpGeneral.Text = "General";
			this.tbpGeneral.UseVisualStyleBackColor = true;
			// 
			// txtCotizacionUS
			// 
			this.txtCotizacionUS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.txtCotizacionUS.ForeColor = System.Drawing.Color.Blue;
			this.txtCotizacionUS.Location = new System.Drawing.Point(174, 191);
			this.txtCotizacionUS.Name = "txtCotizacionUS";
			this.txtCotizacionUS.Size = new System.Drawing.Size(82, 20);
			this.stylesSheetManager.SetStyle(this.txtCotizacionUS, "TextBox");
			this.txtCotizacionUS.TabIndex = 74;
			this.txtCotizacionUS.TextChanged += new System.EventHandler(this.txtCotizacionUS_TextChanged);
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.BackColor = System.Drawing.Color.Transparent;
			this.label13.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.label13.Location = new System.Drawing.Point(8, 194);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(95, 13);
			this.stylesSheetManager.SetStyle(this.label13, "Label");
			this.label13.TabIndex = 75;
			this.label13.Text = "Cotización U$";
			// 
			// cmbFormatoComprobante
			// 
			this.cmbFormatoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbFormatoComprobante.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.cmbFormatoComprobante.ForeColor = System.Drawing.Color.Blue;
			this.cmbFormatoComprobante.FormattingEnabled = true;
			this.cmbFormatoComprobante.Location = new System.Drawing.Point(174, 154);
			this.cmbFormatoComprobante.Name = "cmbFormatoComprobante";
			this.cmbFormatoComprobante.Size = new System.Drawing.Size(180, 21);
			this.stylesSheetManager.SetStyle(this.cmbFormatoComprobante, "TextBox");
			this.cmbFormatoComprobante.TabIndex = 70;
			// 
			// lblFormatoComprobante
			// 
			this.lblFormatoComprobante.AutoSize = true;
			this.lblFormatoComprobante.BackColor = System.Drawing.Color.Transparent;
			this.lblFormatoComprobante.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblFormatoComprobante.Location = new System.Drawing.Point(8, 157);
			this.lblFormatoComprobante.Name = "lblFormatoComprobante";
			this.lblFormatoComprobante.Size = new System.Drawing.Size(160, 13);
			this.stylesSheetManager.SetStyle(this.lblFormatoComprobante, "Label");
			this.lblFormatoComprobante.TabIndex = 73;
			this.lblFormatoComprobante.Text = "Formato Comprobantes";
			// 
			// btnBrowseFolder
			// 
			this.btnBrowseFolder.Location = new System.Drawing.Point(333, 121);
			this.btnBrowseFolder.Name = "btnBrowseFolder";
			this.btnBrowseFolder.Size = new System.Drawing.Size(21, 20);
			this.stylesSheetManager.SetStyle(this.btnBrowseFolder, "");
			this.btnBrowseFolder.TabIndex = 67;
			this.btnBrowseFolder.Text = "...";
			this.btnBrowseFolder.UseVisualStyleBackColor = true;
			this.btnBrowseFolder.Click += new System.EventHandler(this.btnBrowseFolder_Click);
			// 
			// txtFilesFolder
			// 
			this.txtFilesFolder.BackColor = System.Drawing.SystemColors.Window;
			this.txtFilesFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.txtFilesFolder.ForeColor = System.Drawing.Color.Blue;
			this.txtFilesFolder.Location = new System.Drawing.Point(174, 121);
			this.txtFilesFolder.Name = "txtFilesFolder";
			this.txtFilesFolder.ReadOnly = true;
			this.txtFilesFolder.Size = new System.Drawing.Size(158, 20);
			this.stylesSheetManager.SetStyle(this.txtFilesFolder, "TextBox");
			this.txtFilesFolder.TabIndex = 66;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.label3.Location = new System.Drawing.Point(8, 124);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(119, 13);
			this.stylesSheetManager.SetStyle(this.label3, "Label");
			this.label3.TabIndex = 72;
			this.label3.Text = "Carpeta Archivos";
			// 
			// txtCodigoMoneda
			// 
			this.txtCodigoMoneda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.txtCodigoMoneda.ForeColor = System.Drawing.Color.Blue;
			this.txtCodigoMoneda.Location = new System.Drawing.Point(174, 84);
			this.txtCodigoMoneda.Name = "txtCodigoMoneda";
			this.txtCodigoMoneda.Size = new System.Drawing.Size(180, 20);
			this.stylesSheetManager.SetStyle(this.txtCodigoMoneda, "TextBox");
			this.txtCodigoMoneda.TabIndex = 65;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.label2.Location = new System.Drawing.Point(8, 87);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(105, 13);
			this.stylesSheetManager.SetStyle(this.label2, "Label");
			this.label2.TabIndex = 71;
			this.label2.Text = "Código Moneda";
			// 
			// txtCodigoCUIT
			// 
			this.txtCodigoCUIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.txtCodigoCUIT.ForeColor = System.Drawing.Color.Blue;
			this.txtCodigoCUIT.Location = new System.Drawing.Point(174, 47);
			this.txtCodigoCUIT.Name = "txtCodigoCUIT";
			this.txtCodigoCUIT.Size = new System.Drawing.Size(180, 20);
			this.stylesSheetManager.SetStyle(this.txtCodigoCUIT, "TextBox");
			this.txtCodigoCUIT.TabIndex = 64;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.label1.Location = new System.Drawing.Point(8, 50);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(86, 13);
			this.stylesSheetManager.SetStyle(this.label1, "Label");
			this.label1.TabIndex = 69;
			this.label1.Text = "Código CUIT";
			// 
			// cmbEmpresas
			// 
			this.cmbEmpresas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbEmpresas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.cmbEmpresas.ForeColor = System.Drawing.Color.Blue;
			this.cmbEmpresas.FormattingEnabled = true;
			this.cmbEmpresas.Location = new System.Drawing.Point(174, 9);
			this.cmbEmpresas.Name = "cmbEmpresas";
			this.cmbEmpresas.Size = new System.Drawing.Size(180, 21);
			this.stylesSheetManager.SetStyle(this.cmbEmpresas, "TextBox");
			this.cmbEmpresas.TabIndex = 63;
			// 
			// lblFTPHost
			// 
			this.lblFTPHost.AutoSize = true;
			this.lblFTPHost.BackColor = System.Drawing.Color.Transparent;
			this.lblFTPHost.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblFTPHost.Location = new System.Drawing.Point(8, 12);
			this.lblFTPHost.Name = "lblFTPHost";
			this.lblFTPHost.Size = new System.Drawing.Size(64, 13);
			this.stylesSheetManager.SetStyle(this.lblFTPHost, "Label");
			this.lblFTPHost.TabIndex = 68;
			this.lblFTPHost.Text = "Empresa";
			// 
			// tbpEMail
			// 
			this.tbpEMail.AutoScroll = true;
			this.tbpEMail.BackColor = System.Drawing.Color.Transparent;
			this.tbpEMail.Controls.Add(this.txtEmailTexto);
			this.tbpEMail.Controls.Add(this.lblEmailTexto);
			this.tbpEMail.Controls.Add(this.txtEmailReclamos);
			this.tbpEMail.Controls.Add(this.label12);
			this.tbpEMail.Controls.Add(this.chkSmtpSSLEnabled);
			this.tbpEMail.Controls.Add(this.label10);
			this.tbpEMail.Controls.Add(this.txtSmtpServerPort);
			this.tbpEMail.Controls.Add(this.label9);
			this.tbpEMail.Controls.Add(this.txtEmailSubject);
			this.tbpEMail.Controls.Add(this.label7);
			this.tbpEMail.Controls.Add(this.txtSmtpPass);
			this.tbpEMail.Controls.Add(this.label8);
			this.tbpEMail.Controls.Add(this.txtSmtpUser);
			this.tbpEMail.Controls.Add(this.label6);
			this.tbpEMail.Controls.Add(this.txtSmtpServer);
			this.tbpEMail.Controls.Add(this.label5);
			this.tbpEMail.Controls.Add(this.txtEmail);
			this.tbpEMail.Controls.Add(this.label4);
			this.tbpEMail.Location = new System.Drawing.Point(4, 22);
			this.tbpEMail.Name = "tbpEMail";
			this.tbpEMail.Padding = new System.Windows.Forms.Padding(3);
			this.tbpEMail.Size = new System.Drawing.Size(372, 234);
			this.stylesSheetManager.SetStyle(this.tbpEMail, "");
			this.tbpEMail.TabIndex = 1;
			this.tbpEMail.Text = "EMail";
			this.tbpEMail.UseVisualStyleBackColor = true;
			// 
			// txtEmailTexto
			// 
			this.txtEmailTexto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.txtEmailTexto.ForeColor = System.Drawing.Color.Blue;
			this.txtEmailTexto.Location = new System.Drawing.Point(11, 270);
			this.txtEmailTexto.Multiline = true;
			this.txtEmailTexto.Name = "txtEmailTexto";
			this.txtEmailTexto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtEmailTexto.Size = new System.Drawing.Size(343, 81);
			this.stylesSheetManager.SetStyle(this.txtEmailTexto, "TextBox");
			this.txtEmailTexto.TabIndex = 95;
			// 
			// lblEmailTexto
			// 
			this.lblEmailTexto.AutoSize = true;
			this.lblEmailTexto.BackColor = System.Drawing.Color.Transparent;
			this.lblEmailTexto.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblEmailTexto.Location = new System.Drawing.Point(8, 254);
			this.lblEmailTexto.Name = "lblEmailTexto";
			this.lblEmailTexto.Size = new System.Drawing.Size(84, 13);
			this.stylesSheetManager.SetStyle(this.lblEmailTexto, "Label");
			this.lblEmailTexto.TabIndex = 94;
			this.lblEmailTexto.Text = "Email Texto";
			// 
			// txtEmailReclamos
			// 
			this.txtEmailReclamos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.txtEmailReclamos.ForeColor = System.Drawing.Color.Blue;
			this.txtEmailReclamos.Location = new System.Drawing.Point(174, 221);
			this.txtEmailReclamos.Name = "txtEmailReclamos";
			this.txtEmailReclamos.Size = new System.Drawing.Size(180, 20);
			this.stylesSheetManager.SetStyle(this.txtEmailReclamos, "TextBox");
			this.txtEmailReclamos.TabIndex = 92;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.BackColor = System.Drawing.Color.Transparent;
			this.label12.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.label12.Location = new System.Drawing.Point(8, 224);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(109, 13);
			this.stylesSheetManager.SetStyle(this.label12, "Label");
			this.label12.TabIndex = 93;
			this.label12.Text = "Email Reclamos";
			// 
			// chkSmtpSSLEnabled
			// 
			this.chkSmtpSSLEnabled.AutoSize = true;
			this.chkSmtpSSLEnabled.Location = new System.Drawing.Point(174, 160);
			this.chkSmtpSSLEnabled.Name = "chkSmtpSSLEnabled";
			this.chkSmtpSSLEnabled.Size = new System.Drawing.Size(15, 14);
			this.stylesSheetManager.SetStyle(this.chkSmtpSSLEnabled, "");
			this.chkSmtpSSLEnabled.TabIndex = 83;
			this.chkSmtpSSLEnabled.UseVisualStyleBackColor = true;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.BackColor = System.Drawing.Color.Transparent;
			this.label10.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.label10.Location = new System.Drawing.Point(8, 161);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(68, 13);
			this.stylesSheetManager.SetStyle(this.label10, "Label");
			this.label10.TabIndex = 91;
			this.label10.Text = "SMTP SSL";
			// 
			// txtSmtpServerPort
			// 
			this.txtSmtpServerPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.txtSmtpServerPort.ForeColor = System.Drawing.Color.Blue;
			this.txtSmtpServerPort.Location = new System.Drawing.Point(174, 69);
			this.txtSmtpServerPort.Name = "txtSmtpServerPort";
			this.txtSmtpServerPort.Size = new System.Drawing.Size(180, 20);
			this.stylesSheetManager.SetStyle(this.txtSmtpServerPort, "TextBox");
			this.txtSmtpServerPort.TabIndex = 80;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.BackColor = System.Drawing.Color.Transparent;
			this.label9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.label9.Location = new System.Drawing.Point(8, 72);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(120, 13);
			this.stylesSheetManager.SetStyle(this.label9, "Label");
			this.label9.TabIndex = 90;
			this.label9.Text = "SMTP Server Port";
			// 
			// txtEmailSubject
			// 
			this.txtEmailSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.txtEmailSubject.ForeColor = System.Drawing.Color.Blue;
			this.txtEmailSubject.Location = new System.Drawing.Point(174, 190);
			this.txtEmailSubject.Name = "txtEmailSubject";
			this.txtEmailSubject.Size = new System.Drawing.Size(180, 20);
			this.stylesSheetManager.SetStyle(this.txtEmailSubject, "TextBox");
			this.txtEmailSubject.TabIndex = 84;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.BackColor = System.Drawing.Color.Transparent;
			this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.label7.Location = new System.Drawing.Point(8, 193);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(96, 13);
			this.stylesSheetManager.SetStyle(this.label7, "Label");
			this.label7.TabIndex = 89;
			this.label7.Text = "Email Subject";
			// 
			// txtSmtpPass
			// 
			this.txtSmtpPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.txtSmtpPass.ForeColor = System.Drawing.Color.Blue;
			this.txtSmtpPass.Location = new System.Drawing.Point(174, 128);
			this.txtSmtpPass.Name = "txtSmtpPass";
			this.txtSmtpPass.Size = new System.Drawing.Size(180, 20);
			this.stylesSheetManager.SetStyle(this.txtSmtpPass, "TextBox");
			this.txtSmtpPass.TabIndex = 82;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.BackColor = System.Drawing.Color.Transparent;
			this.label8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.label8.Location = new System.Drawing.Point(8, 131);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(75, 13);
			this.stylesSheetManager.SetStyle(this.label8, "Label");
			this.label8.TabIndex = 88;
			this.label8.Text = "SMTP Pass";
			// 
			// txtSmtpUser
			// 
			this.txtSmtpUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.txtSmtpUser.ForeColor = System.Drawing.Color.Blue;
			this.txtSmtpUser.Location = new System.Drawing.Point(174, 97);
			this.txtSmtpUser.Name = "txtSmtpUser";
			this.txtSmtpUser.Size = new System.Drawing.Size(180, 20);
			this.stylesSheetManager.SetStyle(this.txtSmtpUser, "TextBox");
			this.txtSmtpUser.TabIndex = 81;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.BackColor = System.Drawing.Color.Transparent;
			this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.label6.Location = new System.Drawing.Point(8, 100);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(75, 13);
			this.stylesSheetManager.SetStyle(this.label6, "Label");
			this.label6.TabIndex = 87;
			this.label6.Text = "SMTP User";
			// 
			// txtSmtpServer
			// 
			this.txtSmtpServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.txtSmtpServer.ForeColor = System.Drawing.Color.Blue;
			this.txtSmtpServer.Location = new System.Drawing.Point(174, 40);
			this.txtSmtpServer.Name = "txtSmtpServer";
			this.txtSmtpServer.Size = new System.Drawing.Size(180, 20);
			this.stylesSheetManager.SetStyle(this.txtSmtpServer, "TextBox");
			this.txtSmtpServer.TabIndex = 79;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.label5.Location = new System.Drawing.Point(8, 43);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(89, 13);
			this.stylesSheetManager.SetStyle(this.label5, "Label");
			this.label5.TabIndex = 86;
			this.label5.Text = "SMTP Server";
			// 
			// txtEmail
			// 
			this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.txtEmail.ForeColor = System.Drawing.Color.Blue;
			this.txtEmail.Location = new System.Drawing.Point(174, 9);
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(180, 20);
			this.stylesSheetManager.SetStyle(this.txtEmail, "TextBox");
			this.txtEmail.TabIndex = 78;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.label4.Location = new System.Drawing.Point(8, 12);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(43, 13);
			this.stylesSheetManager.SetStyle(this.label4, "Label");
			this.label4.TabIndex = 85;
			this.label4.Text = "Email";
			// 
			// tbpCAE
			// 
			this.tbpCAE.BackColor = System.Drawing.Color.Transparent;
			this.tbpCAE.Controls.Add(this.txtWSNegocio);
			this.tbpCAE.Controls.Add(this.lblWSNegocio);
			this.tbpCAE.Controls.Add(this.txtNTPServer);
			this.tbpCAE.Controls.Add(this.label11);
			this.tbpCAE.Location = new System.Drawing.Point(4, 22);
			this.tbpCAE.Name = "tbpCAE";
			this.tbpCAE.Size = new System.Drawing.Size(372, 234);
			this.stylesSheetManager.SetStyle(this.tbpCAE, "");
			this.tbpCAE.TabIndex = 2;
			this.tbpCAE.Text = "CAE";
			this.tbpCAE.UseVisualStyleBackColor = true;
			// 
			// txtWSNegocio
			// 
			this.txtWSNegocio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.txtWSNegocio.ForeColor = System.Drawing.Color.Blue;
			this.txtWSNegocio.Location = new System.Drawing.Point(174, 38);
			this.txtWSNegocio.Name = "txtWSNegocio";
			this.txtWSNegocio.Size = new System.Drawing.Size(180, 20);
			this.stylesSheetManager.SetStyle(this.txtWSNegocio, "TextBox");
			this.txtWSNegocio.TabIndex = 69;
			// 
			// lblWSNegocio
			// 
			this.lblWSNegocio.AutoSize = true;
			this.lblWSNegocio.BackColor = System.Drawing.Color.Transparent;
			this.lblWSNegocio.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblWSNegocio.Location = new System.Drawing.Point(8, 42);
			this.lblWSNegocio.Name = "lblWSNegocio";
			this.lblWSNegocio.Size = new System.Drawing.Size(83, 13);
			this.stylesSheetManager.SetStyle(this.lblWSNegocio, "Label");
			this.lblWSNegocio.TabIndex = 71;
			this.lblWSNegocio.Text = "WS Negocio";
			// 
			// txtNTPServer
			// 
			this.txtNTPServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.txtNTPServer.ForeColor = System.Drawing.Color.Blue;
			this.txtNTPServer.Location = new System.Drawing.Point(174, 10);
			this.txtNTPServer.Name = "txtNTPServer";
			this.txtNTPServer.Size = new System.Drawing.Size(180, 20);
			this.stylesSheetManager.SetStyle(this.txtNTPServer, "TextBox");
			this.txtNTPServer.TabIndex = 68;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.BackColor = System.Drawing.Color.Transparent;
			this.label11.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.label11.Location = new System.Drawing.Point(8, 14);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(80, 13);
			this.stylesSheetManager.SetStyle(this.label11, "Label");
			this.label11.TabIndex = 70;
			this.label11.Text = "NTP Server";
			// 
			// tbpPublicacion
			// 
			this.tbpPublicacion.Controls.Add(this.txtWSPublicacion);
			this.tbpPublicacion.Controls.Add(this.lblWSPublicacion);
			this.tbpPublicacion.Location = new System.Drawing.Point(4, 22);
			this.tbpPublicacion.Name = "tbpPublicacion";
			this.tbpPublicacion.Padding = new System.Windows.Forms.Padding(3);
			this.tbpPublicacion.Size = new System.Drawing.Size(372, 234);
			this.stylesSheetManager.SetStyle(this.tbpPublicacion, "");
			this.tbpPublicacion.TabIndex = 3;
			this.tbpPublicacion.Text = "Publicación";
			this.tbpPublicacion.UseVisualStyleBackColor = true;
			// 
			// txtWSPublicacion
			// 
			this.txtWSPublicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.txtWSPublicacion.ForeColor = System.Drawing.Color.Blue;
			this.txtWSPublicacion.Location = new System.Drawing.Point(174, 10);
			this.txtWSPublicacion.Name = "txtWSPublicacion";
			this.txtWSPublicacion.Size = new System.Drawing.Size(180, 20);
			this.stylesSheetManager.SetStyle(this.txtWSPublicacion, "TextBox");
			this.txtWSPublicacion.TabIndex = 72;
			// 
			// lblWSPublicacion
			// 
			this.lblWSPublicacion.AutoSize = true;
			this.lblWSPublicacion.BackColor = System.Drawing.Color.Transparent;
			this.lblWSPublicacion.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblWSPublicacion.Location = new System.Drawing.Point(8, 14);
			this.lblWSPublicacion.Name = "lblWSPublicacion";
			this.lblWSPublicacion.Size = new System.Drawing.Size(105, 13);
			this.stylesSheetManager.SetStyle(this.lblWSPublicacion, "Label");
			this.lblWSPublicacion.TabIndex = 73;
			this.lblWSPublicacion.Text = "WS Publicación";
			// 
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			// 
			// btnObtenerCotizacion
			// 
			this.btnObtenerCotizacion.Location = new System.Drawing.Point(279, 189);
			this.btnObtenerCotizacion.Name = "btnObtenerCotizacion";
			this.btnObtenerCotizacion.Size = new System.Drawing.Size(75, 23);
			this.stylesSheetManager.SetStyle(this.btnObtenerCotizacion, "");
			this.btnObtenerCotizacion.TabIndex = 76;
			this.btnObtenerCotizacion.Text = "Obtener";
			this.btnObtenerCotizacion.UseVisualStyleBackColor = true;
			this.btnObtenerCotizacion.Click += new System.EventHandler(this.btnObtenerCotizacion_Click);
			// 
			// GeneralSettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::MFD.Properties.Resources.Wizbck02;
			this.ClientSize = new System.Drawing.Size(380, 300);
			this.Controls.Add(this.tbcMain);
			this.Controls.Add(this.groupBox1);
			this.Name = "GeneralSettingsForm";
			this.stylesSheetManager.SetStyle(this, "FormType1");
			this.Text = "GeneralSettings";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GeneralSettingsForm_FormClosing);
			this.groupBox1.ResumeLayout(false);
			this.tbcMain.ResumeLayout(false);
			this.tbpGeneral.ResumeLayout(false);
			this.tbpGeneral.PerformLayout();
			this.tbpEMail.ResumeLayout(false);
			this.tbpEMail.PerformLayout();
			this.tbpCAE.ResumeLayout(false);
			this.tbpCAE.PerformLayout();
			this.tbpPublicacion.ResumeLayout(false);
			this.tbpPublicacion.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.stylesSheetManager)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private Sb.Windows.Forms.StylesSheet.StylesSheetManager stylesSheetManager;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TabControl tbcMain;
        private System.Windows.Forms.TabPage tbpGeneral;
        private System.Windows.Forms.TabPage tbpEMail;
        private System.Windows.Forms.CheckBox chkSmtpSSLEnabled;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSmtpServerPort;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtEmailSubject;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSmtpPass;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSmtpUser;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSmtpServer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tbpCAE;
        private System.Windows.Forms.ComboBox cmbFormatoComprobante;
        private System.Windows.Forms.Label lblFormatoComprobante;
        private System.Windows.Forms.Button btnBrowseFolder;
        private System.Windows.Forms.TextBox txtFilesFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCodigoMoneda;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodigoCUIT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbEmpresas;
        private System.Windows.Forms.Label lblFTPHost;
        private System.Windows.Forms.TextBox txtWSNegocio;
        private System.Windows.Forms.Label lblWSNegocio;
        private System.Windows.Forms.TextBox txtNTPServer;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtEmailReclamos;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TabPage tbpPublicacion;
        private System.Windows.Forms.TextBox txtWSPublicacion;
        private System.Windows.Forms.Label lblWSPublicacion;
		private System.Windows.Forms.TextBox txtEmailTexto;
		private System.Windows.Forms.Label lblEmailTexto;
		private System.Windows.Forms.TextBox txtCotizacionUS;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		private System.Windows.Forms.Button btnObtenerCotizacion;
		private System.Windows.Forms.ToolTip toolTip;
    }
}