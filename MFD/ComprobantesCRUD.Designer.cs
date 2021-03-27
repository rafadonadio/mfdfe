namespace MFD
{
    partial class ComprobantesCRUD
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
			this.DetallesGrid = new FrameWork.CRUDModel.Windows.UI.Grid.GridCRUDControl();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnRepeticion = new System.Windows.Forms.Button();
			this.btnReSend = new System.Windows.Forms.Button();
			this.btnAnular = new System.Windows.Forms.Button();
			this.btnEmitir = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnAccept = new System.Windows.Forms.Button();
			this.txtObservaciones = new System.Windows.Forms.TextBox();
			this.lblObservaciones = new System.Windows.Forms.Label();
			this.txtPercepciones = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtSubtotalAImp = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtIva2 = new System.Windows.Forms.Label();
			this.lblIva2 = new System.Windows.Forms.Label();
			this.txtIva1 = new System.Windows.Forms.Label();
			this.txtTotal = new System.Windows.Forms.Label();
			this.lblIva1 = new System.Windows.Forms.Label();
			this.lblTotalT = new System.Windows.Forms.Label();
			this.lblEstado = new System.Windows.Forms.Label();
			this.cmbPago = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.lblCliente = new System.Windows.Forms.Label();
			this.txtDescuentoCalc = new WindowsFormsControls.NumericControl();
			this.dcCliente = new FrameWork.CRUDModel.Windows.UI.DataCombo();
			this.label3 = new System.Windows.Forms.Label();
			this.txtNumero = new System.Windows.Forms.MaskedTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbTipo = new System.Windows.Forms.ComboBox();
			this.lblTipo = new System.Windows.Forms.Label();
			this.lblFecha = new System.Windows.Forms.Label();
			this.txtFecha = new System.Windows.Forms.DateTimePicker();
			this.stylesSheetManager = new Sb.Windows.Forms.StylesSheet.StylesSheetManager(this.components);
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.txtCAE = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.groupReport = new System.Windows.Forms.GroupBox();
			this.lblPagado = new System.Windows.Forms.Label();
			this.chkPagado = new System.Windows.Forms.CheckBox();
			this.lblGenerarXml = new System.Windows.Forms.Label();
			this.chkGenXML = new System.Windows.Forms.CheckBox();
			this.lblVerReporte = new System.Windows.Forms.Label();
			this.chkVerReporte = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.stylesSheetManager)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupReport.SuspendLayout();
			this.SuspendLayout();
			// 
			// DetallesGrid
			// 
			this.DetallesGrid.ActionButtonImageIndex = -1;
			this.DetallesGrid.ActionButtonText = "Action";
			this.DetallesGrid.ActionButtonVisible = false;
			this.DetallesGrid.AllowColumnDrag = true;
			this.DetallesGrid.AlternatingColors = true;
			this.DetallesGrid.AutomaticSort = true;
			this.DetallesGrid.BackColor = System.Drawing.Color.Transparent;
			this.DetallesGrid.ButtonPadding = 8;
			this.DetallesGrid.ButtonsVisible = true;
			this.DetallesGrid.CreateButtonImageIndex = 0;
			this.DetallesGrid.CreateButtonText = " Agregar";
			this.DetallesGrid.CreateButtonVisible = true;
			this.DetallesGrid.DeleteButtonImageIndex = 2;
			this.DetallesGrid.DeleteButtonText = "Eliminar";
			this.DetallesGrid.DeleteButtonVisible = true;
			this.DetallesGrid.ImageListDefault = true;
			this.DetallesGrid.ItemType = null;
			this.DetallesGrid.Location = new System.Drawing.Point(12, 128);
			this.DetallesGrid.Name = "DetallesGrid";
			this.DetallesGrid.Padding = new System.Windows.Forms.Padding(8);
			this.DetallesGrid.RetrieveButtonImageIndex = 3;
			this.DetallesGrid.RetrieveButtonText = "Consultar";
			this.DetallesGrid.RetrieveButtonVisible = true;
			this.DetallesGrid.Size = new System.Drawing.Size(483, 192);
			this.stylesSheetManager.SetStyle(this.DetallesGrid, "");
			this.DetallesGrid.TabIndex = 1;
			this.DetallesGrid.UpdateButtonImageIndex = 1;
			this.DetallesGrid.UpdateButtonText = "Modificar";
			this.DetallesGrid.UpdateButtonVisible = true;
			this.DetallesGrid.DeleteItemRequired += new FrameWork.CRUDModel.Windows.UI.Grid.ObjectEvent(this.DetallesGrid_DeleteItemRequired);
			this.DetallesGrid.ResetLayout += new FrameWork.CRUDModel.Windows.UI.Grid.ResetLayoutEvent(this.DetallesGrid_ResetLayout);
			this.DetallesGrid.UpdateItemRequired += new FrameWork.CRUDModel.Windows.UI.Grid.ObjectEvent(this.DetallesGrid_UpdateItemRequired);
			this.DetallesGrid.RetrieveItemRequired += new FrameWork.CRUDModel.Windows.UI.Grid.ObjectEvent(this.DetallesGrid_RetrieveItemRequired);
			this.DetallesGrid.CreateItemRequired += new FrameWork.CRUDModel.Windows.UI.Grid.ItemCreateEvent(this.DetallesGrid_CreateItemRequired);
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.Color.Transparent;
			this.groupBox1.Controls.Add(this.btnRepeticion);
			this.groupBox1.Controls.Add(this.btnReSend);
			this.groupBox1.Controls.Add(this.btnAnular);
			this.groupBox1.Controls.Add(this.btnEmitir);
			this.groupBox1.Controls.Add(this.btnCancel);
			this.groupBox1.Controls.Add(this.btnAccept);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.groupBox1.Location = new System.Drawing.Point(0, 526);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(507, 40);
			this.stylesSheetManager.SetStyle(this.groupBox1, "GroupBox1");
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			// 
			// btnRepeticion
			// 
			this.btnRepeticion.BackColor = System.Drawing.Color.Transparent;
			this.btnRepeticion.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.btnRepeticion.Location = new System.Drawing.Point(414, 13);
			this.btnRepeticion.Name = "btnRepeticion";
			this.btnRepeticion.Size = new System.Drawing.Size(75, 23);
			this.stylesSheetManager.SetStyle(this.btnRepeticion, "Button");
			this.btnRepeticion.TabIndex = 11;
			this.btnRepeticion.Text = "Repetir";
			this.btnRepeticion.UseVisualStyleBackColor = false;
			this.btnRepeticion.Click += new System.EventHandler(this.btnRepeticion_Click);
			// 
			// btnReSend
			// 
			this.btnReSend.BackColor = System.Drawing.Color.Transparent;
			this.btnReSend.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.btnReSend.Location = new System.Drawing.Point(210, 13);
			this.btnReSend.Name = "btnReSend";
			this.btnReSend.Size = new System.Drawing.Size(75, 23);
			this.stylesSheetManager.SetStyle(this.btnReSend, "Button");
			this.btnReSend.TabIndex = 9;
			this.btnReSend.Text = "Reenviar";
			this.btnReSend.UseVisualStyleBackColor = false;
			this.btnReSend.Click += new System.EventHandler(this.btnReSend_Click);
			// 
			// btnAnular
			// 
			this.btnAnular.BackColor = System.Drawing.Color.Transparent;
			this.btnAnular.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.btnAnular.Location = new System.Drawing.Point(212, 13);
			this.btnAnular.Name = "btnAnular";
			this.btnAnular.Size = new System.Drawing.Size(72, 23);
			this.stylesSheetManager.SetStyle(this.btnAnular, "Button");
			this.btnAnular.TabIndex = 10;
			this.btnAnular.Text = "Anular Comprobante";
			this.btnAnular.UseVisualStyleBackColor = false;
			this.btnAnular.Visible = false;
			this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
			// 
			// btnEmitir
			// 
			this.btnEmitir.BackColor = System.Drawing.Color.Transparent;
			this.btnEmitir.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.btnEmitir.Location = new System.Drawing.Point(108, 13);
			this.btnEmitir.Name = "btnEmitir";
			this.btnEmitir.Size = new System.Drawing.Size(75, 23);
			this.stylesSheetManager.SetStyle(this.btnEmitir, "Button");
			this.btnEmitir.TabIndex = 8;
			this.btnEmitir.Text = "Emitir Comprobante";
			this.btnEmitir.UseVisualStyleBackColor = false;
			this.btnEmitir.Click += new System.EventHandler(this.btnEmitir_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.BackColor = System.Drawing.Color.Transparent;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.btnCancel.Location = new System.Drawing.Point(312, 13);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.stylesSheetManager.SetStyle(this.btnCancel, "Button");
			this.btnCancel.TabIndex = 7;
			this.btnCancel.Text = "Cancelar";
			this.btnCancel.UseVisualStyleBackColor = false;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnAccept
			// 
			this.btnAccept.BackColor = System.Drawing.Color.Transparent;
			this.btnAccept.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.btnAccept.Location = new System.Drawing.Point(6, 13);
			this.btnAccept.Name = "btnAccept";
			this.btnAccept.Size = new System.Drawing.Size(75, 23);
			this.stylesSheetManager.SetStyle(this.btnAccept, "Button");
			this.btnAccept.TabIndex = 6;
			this.btnAccept.Text = "Aceptar";
			this.btnAccept.UseVisualStyleBackColor = false;
			this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
			// 
			// txtObservaciones
			// 
			this.txtObservaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.txtObservaciones.ForeColor = System.Drawing.Color.Blue;
			this.txtObservaciones.Location = new System.Drawing.Point(6, 98);
			this.txtObservaciones.Multiline = true;
			this.txtObservaciones.Name = "txtObservaciones";
			this.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtObservaciones.Size = new System.Drawing.Size(459, 48);
			this.stylesSheetManager.SetStyle(this.txtObservaciones, "");
			this.txtObservaciones.TabIndex = 5;
			// 
			// lblObservaciones
			// 
			this.lblObservaciones.AutoSize = true;
			this.lblObservaciones.BackColor = System.Drawing.Color.Transparent;
			this.lblObservaciones.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblObservaciones.Location = new System.Drawing.Point(15, 79);
			this.lblObservaciones.Name = "lblObservaciones";
			this.lblObservaciones.Size = new System.Drawing.Size(103, 13);
			this.stylesSheetManager.SetStyle(this.lblObservaciones, "");
			this.lblObservaciones.TabIndex = 27;
			this.lblObservaciones.Text = "Observaciones";
			// 
			// txtPercepciones
			// 
			this.txtPercepciones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtPercepciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtPercepciones.Location = new System.Drawing.Point(124, 40);
			this.txtPercepciones.Name = "txtPercepciones";
			this.txtPercepciones.Size = new System.Drawing.Size(104, 17);
			this.stylesSheetManager.SetStyle(this.txtPercepciones, "");
			this.txtPercepciones.TabIndex = 38;
			this.txtPercepciones.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.label5.Location = new System.Drawing.Point(18, 40);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(102, 17);
			this.stylesSheetManager.SetStyle(this.label5, "Label");
			this.label5.TabIndex = 37;
			this.label5.Text = "Percepciones";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtSubtotalAImp
			// 
			this.txtSubtotalAImp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtSubtotalAImp.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtSubtotalAImp.Location = new System.Drawing.Point(124, 15);
			this.txtSubtotalAImp.Name = "txtSubtotalAImp";
			this.txtSubtotalAImp.Size = new System.Drawing.Size(104, 17);
			this.stylesSheetManager.SetStyle(this.txtSubtotalAImp, "");
			this.txtSubtotalAImp.TabIndex = 36;
			this.txtSubtotalAImp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.label4.Location = new System.Drawing.Point(6, 15);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(114, 17);
			this.stylesSheetManager.SetStyle(this.label4, "Label");
			this.label4.TabIndex = 35;
			this.label4.Text = "Subtotal a/Imp";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtIva2
			// 
			this.txtIva2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtIva2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtIva2.Location = new System.Drawing.Point(356, 40);
			this.txtIva2.Name = "txtIva2";
			this.txtIva2.Size = new System.Drawing.Size(111, 16);
			this.stylesSheetManager.SetStyle(this.txtIva2, "");
			this.txtIva2.TabIndex = 34;
			this.txtIva2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblIva2
			// 
			this.lblIva2.BackColor = System.Drawing.Color.Transparent;
			this.lblIva2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblIva2.Location = new System.Drawing.Point(262, 39);
			this.lblIva2.Name = "lblIva2";
			this.lblIva2.Size = new System.Drawing.Size(87, 17);
			this.stylesSheetManager.SetStyle(this.lblIva2, "Label");
			this.lblIva2.TabIndex = 33;
			this.lblIva2.Text = "IVA2";
			this.lblIva2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtIva1
			// 
			this.txtIva1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtIva1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtIva1.Location = new System.Drawing.Point(356, 16);
			this.txtIva1.Name = "txtIva1";
			this.txtIva1.Size = new System.Drawing.Size(111, 16);
			this.stylesSheetManager.SetStyle(this.txtIva1, "");
			this.txtIva1.TabIndex = 30;
			this.txtIva1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtTotal
			// 
			this.txtTotal.BackColor = System.Drawing.Color.DimGray;
			this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtTotal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.txtTotal.Location = new System.Drawing.Point(364, 63);
			this.txtTotal.Name = "txtTotal";
			this.txtTotal.Size = new System.Drawing.Size(103, 26);
			this.stylesSheetManager.SetStyle(this.txtTotal, "");
			this.txtTotal.TabIndex = 29;
			this.txtTotal.Text = "0.00";
			this.txtTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblIva1
			// 
			this.lblIva1.BackColor = System.Drawing.Color.Transparent;
			this.lblIva1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblIva1.Location = new System.Drawing.Point(262, 15);
			this.lblIva1.Name = "lblIva1";
			this.lblIva1.Size = new System.Drawing.Size(88, 17);
			this.stylesSheetManager.SetStyle(this.lblIva1, "Label");
			this.lblIva1.TabIndex = 28;
			this.lblIva1.Text = "IVA1";
			this.lblIva1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblTotalT
			// 
			this.lblTotalT.BackColor = System.Drawing.Color.Transparent;
			this.lblTotalT.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblTotalT.Location = new System.Drawing.Point(252, 62);
			this.lblTotalT.Name = "lblTotalT";
			this.lblTotalT.Size = new System.Drawing.Size(106, 26);
			this.stylesSheetManager.SetStyle(this.lblTotalT, "Label");
			this.lblTotalT.TabIndex = 27;
			this.lblTotalT.Text = "Total";
			this.lblTotalT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblEstado
			// 
			this.lblEstado.AutoSize = true;
			this.lblEstado.BackColor = System.Drawing.Color.Transparent;
			this.lblEstado.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblEstado.ForeColor = System.Drawing.Color.Blue;
			this.lblEstado.Location = new System.Drawing.Point(149, 11);
			this.lblEstado.Name = "lblEstado";
			this.lblEstado.Size = new System.Drawing.Size(120, 23);
			this.stylesSheetManager.SetStyle(this.lblEstado, "");
			this.lblEstado.TabIndex = 54;
			this.lblEstado.Text = "PENDIENTE";
			this.lblEstado.DoubleClick += new System.EventHandler(this.lblEstado_DoubleClick);
			// 
			// cmbPago
			// 
			this.cmbPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPago.Enabled = false;
			this.cmbPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.cmbPago.ForeColor = System.Drawing.Color.Blue;
			this.cmbPago.FormattingEnabled = true;
			this.cmbPago.Location = new System.Drawing.Point(342, 65);
			this.cmbPago.Name = "cmbPago";
			this.cmbPago.Size = new System.Drawing.Size(123, 21);
			this.stylesSheetManager.SetStyle(this.cmbPago, "TextBox");
			this.cmbPago.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.label2.Location = new System.Drawing.Point(247, 70);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(91, 13);
			this.stylesSheetManager.SetStyle(this.label2, "Label");
			this.label2.TabIndex = 52;
			this.label2.Text = "Tipo de Pago";
			// 
			// lblCliente
			// 
			this.lblCliente.AutoSize = true;
			this.lblCliente.BackColor = System.Drawing.Color.Transparent;
			this.lblCliente.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblCliente.Location = new System.Drawing.Point(285, 43);
			this.lblCliente.Name = "lblCliente";
			this.lblCliente.Size = new System.Drawing.Size(52, 13);
			this.stylesSheetManager.SetStyle(this.lblCliente, "Label");
			this.lblCliente.TabIndex = 51;
			this.lblCliente.Text = "Cliente";
			// 
			// txtDescuentoCalc
			// 
			this.txtDescuentoCalc.AllowNegatives = false;
			this.txtDescuentoCalc.DecimalPlaces = 2;
			this.txtDescuentoCalc.DecimalPoint = '.';
			this.txtDescuentoCalc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.txtDescuentoCalc.ForeColor = System.Drawing.Color.Blue;
			this.txtDescuentoCalc.Location = new System.Drawing.Point(344, 95);
			this.txtDescuentoCalc.Name = "txtDescuentoCalc";
			this.txtDescuentoCalc.ShowCalculator = true;
			this.txtDescuentoCalc.Size = new System.Drawing.Size(123, 20);
			this.stylesSheetManager.SetStyle(this.txtDescuentoCalc, "TextBox");
			this.txtDescuentoCalc.TabIndex = 3;
			this.txtDescuentoCalc.Value = 0;
			this.txtDescuentoCalc.Leave += new System.EventHandler(this.txtDescuentoCalc_Leave);
			// 
			// dcCliente
			// 
			this.dcCliente.DataType = null;
			this.dcCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.dcCliente.ForeColor = System.Drawing.Color.Blue;
			this.dcCliente.Location = new System.Drawing.Point(342, 39);
			this.dcCliente.Name = "dcCliente";
			this.dcCliente.Selected = null;
			this.dcCliente.ShowDelete = true;
			this.dcCliente.Size = new System.Drawing.Size(125, 20);
			this.stylesSheetManager.SetStyle(this.dcCliente, "TextBox");
			this.dcCliente.TabIndex = 0;
			this.dcCliente.TitleCRUD = null;
			this.dcCliente.TitleGrid = null;
			this.dcCliente.ItemAssign += new FrameWork.CRUDModel.Windows.UI.DataCombo.ComboAction(this.dcCliente_ItemAssign);
			this.dcCliente.BrowseClick += new FrameWork.CRUDModel.Windows.UI.DataCombo.BrowseTypeEvent(this.dcCliente_BrowseClick);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.label3.Location = new System.Drawing.Point(242, 98);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(101, 13);
			this.stylesSheetManager.SetStyle(this.label3, "Label");
			this.label3.TabIndex = 44;
			this.label3.Text = "Descuento(%)";
			// 
			// txtNumero
			// 
			this.txtNumero.Culture = new System.Globalization.CultureInfo("es-AR");
			this.txtNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.txtNumero.ForeColor = System.Drawing.Color.Blue;
			this.txtNumero.Location = new System.Drawing.Point(75, 95);
			this.txtNumero.Mask = "9999-99999999";
			this.txtNumero.Name = "txtNumero";
			this.txtNumero.ReadOnly = true;
			this.txtNumero.Size = new System.Drawing.Size(125, 20);
			this.stylesSheetManager.SetStyle(this.txtNumero, "TextBox");
			this.txtNumero.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.label1.Location = new System.Drawing.Point(16, 98);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 13);
			this.stylesSheetManager.SetStyle(this.label1, "Label");
			this.label1.TabIndex = 42;
			this.label1.Text = "Número";
			// 
			// cmbTipo
			// 
			this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTipo.Enabled = false;
			this.cmbTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.cmbTipo.ForeColor = System.Drawing.Color.Blue;
			this.cmbTipo.FormattingEnabled = true;
			this.cmbTipo.Location = new System.Drawing.Point(75, 68);
			this.cmbTipo.Name = "cmbTipo";
			this.cmbTipo.Size = new System.Drawing.Size(153, 21);
			this.stylesSheetManager.SetStyle(this.cmbTipo, "TextBox");
			this.cmbTipo.TabIndex = 41;
			this.cmbTipo.SelectedIndexChanged += new System.EventHandler(this.cmbTipo_SelectedIndexChanged);
			// 
			// lblTipo
			// 
			this.lblTipo.AutoSize = true;
			this.lblTipo.BackColor = System.Drawing.Color.Transparent;
			this.lblTipo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblTipo.Location = new System.Drawing.Point(36, 73);
			this.lblTipo.Name = "lblTipo";
			this.lblTipo.Size = new System.Drawing.Size(35, 13);
			this.stylesSheetManager.SetStyle(this.lblTipo, "Label");
			this.lblTipo.TabIndex = 40;
			this.lblTipo.Text = "Tipo";
			// 
			// lblFecha
			// 
			this.lblFecha.AutoSize = true;
			this.lblFecha.BackColor = System.Drawing.Color.Transparent;
			this.lblFecha.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblFecha.Location = new System.Drawing.Point(25, 47);
			this.lblFecha.Name = "lblFecha";
			this.lblFecha.Size = new System.Drawing.Size(46, 13);
			this.stylesSheetManager.SetStyle(this.lblFecha, "Label");
			this.lblFecha.TabIndex = 39;
			this.lblFecha.Text = "Fecha";
			// 
			// txtFecha
			// 
			this.txtFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
			this.txtFecha.ForeColor = System.Drawing.Color.Blue;
			this.txtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.txtFecha.Location = new System.Drawing.Point(75, 43);
			this.txtFecha.Name = "txtFecha";
			this.txtFecha.Size = new System.Drawing.Size(125, 20);
			this.stylesSheetManager.SetStyle(this.txtFecha, "TextBox");
			this.txtFecha.TabIndex = 0;
			// 
			// groupBox2
			// 
			this.groupBox2.BackColor = System.Drawing.Color.Transparent;
			this.groupBox2.Controls.Add(this.lblEstado);
			this.groupBox2.Controls.Add(this.lblCliente);
			this.groupBox2.Controls.Add(this.cmbPago);
			this.groupBox2.Controls.Add(this.txtFecha);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.lblFecha);
			this.groupBox2.Controls.Add(this.lblTipo);
			this.groupBox2.Controls.Add(this.txtDescuentoCalc);
			this.groupBox2.Controls.Add(this.cmbTipo);
			this.groupBox2.Controls.Add(this.dcCliente);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.txtNumero);
			this.groupBox2.Location = new System.Drawing.Point(15, 3);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(480, 128);
			this.stylesSheetManager.SetStyle(this.groupBox2, "GroupBox1");
			this.groupBox2.TabIndex = 39;
			this.groupBox2.TabStop = false;
			// 
			// groupBox3
			// 
			this.groupBox3.BackColor = System.Drawing.Color.Transparent;
			this.groupBox3.Controls.Add(this.txtCAE);
			this.groupBox3.Controls.Add(this.label6);
			this.groupBox3.Controls.Add(this.txtPercepciones);
			this.groupBox3.Controls.Add(this.lblIva1);
			this.groupBox3.Controls.Add(this.lblObservaciones);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.txtObservaciones);
			this.groupBox3.Controls.Add(this.lblTotalT);
			this.groupBox3.Controls.Add(this.txtSubtotalAImp);
			this.groupBox3.Controls.Add(this.txtTotal);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.txtIva1);
			this.groupBox3.Controls.Add(this.txtIva2);
			this.groupBox3.Controls.Add(this.lblIva2);
			this.groupBox3.Location = new System.Drawing.Point(15, 313);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(480, 184);
			this.stylesSheetManager.SetStyle(this.groupBox3, "GroupBox1");
			this.groupBox3.TabIndex = 40;
			this.groupBox3.TabStop = false;
			// 
			// txtCAE
			// 
			this.txtCAE.Location = new System.Drawing.Point(54, 153);
			this.txtCAE.Name = "txtCAE";
			this.txtCAE.ReadOnly = true;
			this.txtCAE.Size = new System.Drawing.Size(408, 20);
			this.stylesSheetManager.SetStyle(this.txtCAE, "");
			this.txtCAE.TabIndex = 40;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.BackColor = System.Drawing.Color.Transparent;
			this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.label6.Location = new System.Drawing.Point(12, 156);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(32, 13);
			this.stylesSheetManager.SetStyle(this.label6, "");
			this.label6.TabIndex = 39;
			this.label6.Text = "CAE";
			// 
			// groupReport
			// 
			this.groupReport.BackColor = System.Drawing.Color.Transparent;
			this.groupReport.Controls.Add(this.lblPagado);
			this.groupReport.Controls.Add(this.chkPagado);
			this.groupReport.Controls.Add(this.lblGenerarXml);
			this.groupReport.Controls.Add(this.chkGenXML);
			this.groupReport.Controls.Add(this.lblVerReporte);
			this.groupReport.Controls.Add(this.chkVerReporte);
			this.groupReport.Location = new System.Drawing.Point(15, 500);
			this.groupReport.Name = "groupReport";
			this.groupReport.Size = new System.Drawing.Size(480, 30);
			this.stylesSheetManager.SetStyle(this.groupReport, "GroupBox1");
			this.groupReport.TabIndex = 41;
			this.groupReport.TabStop = false;
			// 
			// lblPagado
			// 
			this.lblPagado.AutoSize = true;
			this.lblPagado.BackColor = System.Drawing.Color.Transparent;
			this.lblPagado.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblPagado.Location = new System.Drawing.Point(381, 11);
			this.lblPagado.Name = "lblPagado";
			this.lblPagado.Size = new System.Drawing.Size(55, 13);
			this.stylesSheetManager.SetStyle(this.lblPagado, "");
			this.lblPagado.TabIndex = 44;
			this.lblPagado.Text = "Pagado";
			// 
			// chkPagado
			// 
			this.chkPagado.AutoSize = true;
			this.chkPagado.Location = new System.Drawing.Point(441, 11);
			this.chkPagado.Name = "chkPagado";
			this.chkPagado.Size = new System.Drawing.Size(15, 14);
			this.stylesSheetManager.SetStyle(this.chkPagado, "");
			this.chkPagado.TabIndex = 43;
			this.chkPagado.UseVisualStyleBackColor = true;
			// 
			// lblGenerarXml
			// 
			this.lblGenerarXml.AutoSize = true;
			this.lblGenerarXml.BackColor = System.Drawing.Color.Transparent;
			this.lblGenerarXml.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblGenerarXml.Location = new System.Drawing.Point(189, 11);
			this.lblGenerarXml.Name = "lblGenerarXml";
			this.lblGenerarXml.Size = new System.Drawing.Size(89, 13);
			this.stylesSheetManager.SetStyle(this.lblGenerarXml, "");
			this.lblGenerarXml.TabIndex = 42;
			this.lblGenerarXml.Text = "Generar XML";
			this.lblGenerarXml.Visible = false;
			// 
			// chkGenXML
			// 
			this.chkGenXML.AutoSize = true;
			this.chkGenXML.Location = new System.Drawing.Point(281, 11);
			this.chkGenXML.Name = "chkGenXML";
			this.chkGenXML.Size = new System.Drawing.Size(15, 14);
			this.stylesSheetManager.SetStyle(this.chkGenXML, "");
			this.chkGenXML.TabIndex = 41;
			this.chkGenXML.UseVisualStyleBackColor = true;
			this.chkGenXML.Visible = false;
			// 
			// lblVerReporte
			// 
			this.lblVerReporte.AutoSize = true;
			this.lblVerReporte.BackColor = System.Drawing.Color.Transparent;
			this.lblVerReporte.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblVerReporte.Location = new System.Drawing.Point(15, 11);
			this.lblVerReporte.Name = "lblVerReporte";
			this.lblVerReporte.Size = new System.Drawing.Size(84, 13);
			this.stylesSheetManager.SetStyle(this.lblVerReporte, "");
			this.lblVerReporte.TabIndex = 40;
			this.lblVerReporte.Text = "Ver Reporte";
			// 
			// chkVerReporte
			// 
			this.chkVerReporte.AutoSize = true;
			this.chkVerReporte.Location = new System.Drawing.Point(102, 11);
			this.chkVerReporte.Name = "chkVerReporte";
			this.chkVerReporte.Size = new System.Drawing.Size(15, 14);
			this.stylesSheetManager.SetStyle(this.chkVerReporte, "");
			this.chkVerReporte.TabIndex = 0;
			this.chkVerReporte.UseVisualStyleBackColor = true;
			// 
			// ComprobantesCRUD
			// 
			this.AcceptButton = this.btnAccept;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(507, 566);
			this.Controls.Add(this.groupReport);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.DetallesGrid);
			this.MaximizeBox = false;
			this.Name = "ComprobantesCRUD";
			this.stylesSheetManager.SetStyle(this, "FormType1");
			this.Text = "ComprobantesCRUD";
			this.Title = "ComprobantesCRUD";
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.stylesSheetManager)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupReport.ResumeLayout(false);
			this.groupReport.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private FrameWork.CRUDModel.Windows.UI.Grid.GridCRUDControl DetallesGrid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.Label txtIva2;
        private System.Windows.Forms.Label lblIva2;
        private System.Windows.Forms.Label txtIva1;
        private System.Windows.Forms.Label txtTotal;
        private System.Windows.Forms.Label lblIva1;
        private System.Windows.Forms.Label lblTotalT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtNumero;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker txtFecha;
        private FrameWork.CRUDModel.Windows.UI.DataCombo dcCliente;
        private WindowsFormsControls.NumericControl txtDescuentoCalc;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label txtPercepciones;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label txtSubtotalAImp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbPago;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Button btnEmitir;
        private Sb.Windows.Forms.StylesSheet.StylesSheetManager stylesSheetManager;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnReSend;
        private System.Windows.Forms.TextBox txtCAE;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAnular;
        private System.Windows.Forms.GroupBox groupReport;
        private System.Windows.Forms.Label lblVerReporte;
        private System.Windows.Forms.CheckBox chkVerReporte;
		private System.Windows.Forms.Label lblGenerarXml;
		private System.Windows.Forms.CheckBox chkGenXML;
		private System.Windows.Forms.Label lblPagado;
		private System.Windows.Forms.CheckBox chkPagado;
		private System.Windows.Forms.Button btnRepeticion;
    }
}