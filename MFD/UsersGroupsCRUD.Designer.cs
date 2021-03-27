namespace MFD
{
    partial class UsersGroupsCRUD
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gpbAddFunction = new System.Windows.Forms.GroupBox();
            this.gpbCRUDItems = new System.Windows.Forms.GroupBox();
            this.chkCRUDItems = new System.Windows.Forms.CheckedListBox();
            this.cmbCRUDModules = new System.Windows.Forms.ComboBox();
            this.gpbSpecialItems = new System.Windows.Forms.GroupBox();
            this.chkSpecialItems = new System.Windows.Forms.CheckedListBox();
            this.cmbSpecialModules = new System.Windows.Forms.ComboBox();
            this.gpbGeneralItems = new System.Windows.Forms.GroupBox();
            this.chkGeneralItems = new System.Windows.Forms.CheckedListBox();
            this.btnItemCancel = new System.Windows.Forms.Button();
            this.btnItemAccept = new System.Windows.Forms.Button();
            this.rbtGeneral = new System.Windows.Forms.RadioButton();
            this.rbtSpecial = new System.Windows.Forms.RadioButton();
            this.rbtCRUD = new System.Windows.Forms.RadioButton();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lstPermisos = new System.Windows.Forms.ListBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.stylesSheetManager = new Sb.Windows.Forms.StylesSheet.StylesSheetManager(this.components);
            this.groupBox2.SuspendLayout();
            this.gpbAddFunction.SuspendLayout();
            this.gpbCRUDItems.SuspendLayout();
            this.gpbSpecialItems.SuspendLayout();
            this.gpbGeneralItems.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stylesSheetManager)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.gpbAddFunction);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.lstPermisos);
            this.groupBox2.Controls.Add(this.txtNombre);
            this.groupBox2.Controls.Add(this.lblDescripcion);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(469, 457);
            this.stylesSheetManager.SetStyle(this.groupBox2, "GroupBox1");
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // gpbAddFunction
            // 
            this.gpbAddFunction.BackColor = System.Drawing.Color.Transparent;
            this.gpbAddFunction.Controls.Add(this.gpbCRUDItems);
            this.gpbAddFunction.Controls.Add(this.gpbSpecialItems);
            this.gpbAddFunction.Controls.Add(this.gpbGeneralItems);
            this.gpbAddFunction.Controls.Add(this.btnItemCancel);
            this.gpbAddFunction.Controls.Add(this.btnItemAccept);
            this.gpbAddFunction.Controls.Add(this.rbtGeneral);
            this.gpbAddFunction.Controls.Add(this.rbtSpecial);
            this.gpbAddFunction.Controls.Add(this.rbtCRUD);
            this.gpbAddFunction.Location = new System.Drawing.Point(96, 226);
            this.gpbAddFunction.Name = "gpbAddFunction";
            this.gpbAddFunction.Size = new System.Drawing.Size(298, 225);
            this.stylesSheetManager.SetStyle(this.gpbAddFunction, "");
            this.gpbAddFunction.TabIndex = 13;
            this.gpbAddFunction.TabStop = false;
            this.gpbAddFunction.Visible = false;
            // 
            // gpbCRUDItems
            // 
            this.gpbCRUDItems.Controls.Add(this.chkCRUDItems);
            this.gpbCRUDItems.Controls.Add(this.cmbCRUDModules);
            this.gpbCRUDItems.Location = new System.Drawing.Point(17, 32);
            this.gpbCRUDItems.Name = "gpbCRUDItems";
            this.gpbCRUDItems.Size = new System.Drawing.Size(270, 150);
            this.stylesSheetManager.SetStyle(this.gpbCRUDItems, "");
            this.gpbCRUDItems.TabIndex = 21;
            this.gpbCRUDItems.TabStop = false;
            // 
            // chkCRUDItems
            // 
            this.chkCRUDItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.chkCRUDItems.ForeColor = System.Drawing.Color.Blue;
            this.chkCRUDItems.FormattingEnabled = true;
            this.chkCRUDItems.Location = new System.Drawing.Point(14, 49);
            this.chkCRUDItems.Name = "chkCRUDItems";
            this.chkCRUDItems.Size = new System.Drawing.Size(238, 94);
            this.stylesSheetManager.SetStyle(this.chkCRUDItems, "TextBox");
            this.chkCRUDItems.TabIndex = 1;
            // 
            // cmbCRUDModules
            // 
            this.cmbCRUDModules.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCRUDModules.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbCRUDModules.ForeColor = System.Drawing.Color.Blue;
            this.cmbCRUDModules.FormattingEnabled = true;
            this.cmbCRUDModules.Location = new System.Drawing.Point(13, 19);
            this.cmbCRUDModules.Name = "cmbCRUDModules";
            this.cmbCRUDModules.Size = new System.Drawing.Size(239, 21);
            this.stylesSheetManager.SetStyle(this.cmbCRUDModules, "TextBox");
            this.cmbCRUDModules.TabIndex = 0;
            // 
            // gpbSpecialItems
            // 
            this.gpbSpecialItems.Controls.Add(this.chkSpecialItems);
            this.gpbSpecialItems.Controls.Add(this.cmbSpecialModules);
            this.gpbSpecialItems.Location = new System.Drawing.Point(17, 32);
            this.gpbSpecialItems.Name = "gpbSpecialItems";
            this.gpbSpecialItems.Size = new System.Drawing.Size(270, 150);
            this.stylesSheetManager.SetStyle(this.gpbSpecialItems, "");
            this.gpbSpecialItems.TabIndex = 18;
            this.gpbSpecialItems.TabStop = false;
            // 
            // chkSpecialItems
            // 
            this.chkSpecialItems.FormattingEnabled = true;
            this.chkSpecialItems.Location = new System.Drawing.Point(14, 49);
            this.chkSpecialItems.Name = "chkSpecialItems";
            this.chkSpecialItems.Size = new System.Drawing.Size(238, 94);
            this.stylesSheetManager.SetStyle(this.chkSpecialItems, "");
            this.chkSpecialItems.TabIndex = 1;
            // 
            // cmbSpecialModules
            // 
            this.cmbSpecialModules.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpecialModules.FormattingEnabled = true;
            this.cmbSpecialModules.Location = new System.Drawing.Point(13, 19);
            this.cmbSpecialModules.Name = "cmbSpecialModules";
            this.cmbSpecialModules.Size = new System.Drawing.Size(239, 21);
            this.stylesSheetManager.SetStyle(this.cmbSpecialModules, "");
            this.cmbSpecialModules.TabIndex = 0;
            // 
            // gpbGeneralItems
            // 
            this.gpbGeneralItems.Controls.Add(this.chkGeneralItems);
            this.gpbGeneralItems.Location = new System.Drawing.Point(17, 32);
            this.gpbGeneralItems.Name = "gpbGeneralItems";
            this.gpbGeneralItems.Size = new System.Drawing.Size(270, 150);
            this.stylesSheetManager.SetStyle(this.gpbGeneralItems, "");
            this.gpbGeneralItems.TabIndex = 17;
            this.gpbGeneralItems.TabStop = false;
            // 
            // chkGeneralItems
            // 
            this.chkGeneralItems.FormattingEnabled = true;
            this.chkGeneralItems.Location = new System.Drawing.Point(14, 19);
            this.chkGeneralItems.Name = "chkGeneralItems";
            this.chkGeneralItems.Size = new System.Drawing.Size(238, 124);
            this.stylesSheetManager.SetStyle(this.chkGeneralItems, "");
            this.chkGeneralItems.TabIndex = 1;
            // 
            // btnItemCancel
            // 
            this.btnItemCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnItemCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnItemCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnItemCancel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnItemCancel.Location = new System.Drawing.Point(212, 186);
            this.btnItemCancel.Name = "btnItemCancel";
            this.btnItemCancel.Size = new System.Drawing.Size(75, 23);
            this.stylesSheetManager.SetStyle(this.btnItemCancel, "Button");
            this.btnItemCancel.TabIndex = 13;
            this.btnItemCancel.Text = "Cancelar";
            this.btnItemCancel.UseVisualStyleBackColor = false;
            this.btnItemCancel.Click += new System.EventHandler(this.btnItemCancel_Click);
            // 
            // btnItemAccept
            // 
            this.btnItemAccept.BackColor = System.Drawing.Color.Transparent;
            this.btnItemAccept.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnItemAccept.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnItemAccept.Location = new System.Drawing.Point(17, 186);
            this.btnItemAccept.Name = "btnItemAccept";
            this.btnItemAccept.Size = new System.Drawing.Size(75, 23);
            this.stylesSheetManager.SetStyle(this.btnItemAccept, "Button");
            this.btnItemAccept.TabIndex = 12;
            this.btnItemAccept.Text = "Agregar";
            this.btnItemAccept.UseVisualStyleBackColor = false;
            this.btnItemAccept.Click += new System.EventHandler(this.btnItemAccept_Click);
            // 
            // rbtGeneral
            // 
            this.rbtGeneral.AutoSize = true;
            this.rbtGeneral.BackColor = System.Drawing.Color.Transparent;
            this.rbtGeneral.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.rbtGeneral.Location = new System.Drawing.Point(166, 9);
            this.rbtGeneral.Name = "rbtGeneral";
            this.rbtGeneral.Size = new System.Drawing.Size(91, 17);
            this.stylesSheetManager.SetStyle(this.rbtGeneral, "Label");
            this.rbtGeneral.TabIndex = 2;
            this.rbtGeneral.Text = "Generales";
            this.rbtGeneral.UseVisualStyleBackColor = false;
            this.rbtGeneral.CheckedChanged += new System.EventHandler(this.rbtGeneral_CheckedChanged);
            // 
            // rbtSpecial
            // 
            this.rbtSpecial.AutoSize = true;
            this.rbtSpecial.BackColor = System.Drawing.Color.Transparent;
            this.rbtSpecial.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.rbtSpecial.Location = new System.Drawing.Point(75, 9);
            this.rbtSpecial.Name = "rbtSpecial";
            this.rbtSpecial.Size = new System.Drawing.Size(94, 17);
            this.stylesSheetManager.SetStyle(this.rbtSpecial, "Label");
            this.rbtSpecial.TabIndex = 1;
            this.rbtSpecial.Text = "Especiales";
            this.rbtSpecial.UseVisualStyleBackColor = false;
            this.rbtSpecial.CheckedChanged += new System.EventHandler(this.rbtSpecial_CheckedChanged);
            // 
            // rbtCRUD
            // 
            this.rbtCRUD.AutoSize = true;
            this.rbtCRUD.BackColor = System.Drawing.Color.Transparent;
            this.rbtCRUD.Checked = true;
            this.rbtCRUD.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.rbtCRUD.Location = new System.Drawing.Point(7, 9);
            this.rbtCRUD.Name = "rbtCRUD";
            this.rbtCRUD.Size = new System.Drawing.Size(59, 17);
            this.stylesSheetManager.SetStyle(this.rbtCRUD, "Label");
            this.rbtCRUD.TabIndex = 0;
            this.rbtCRUD.TabStop = true;
            this.rbtCRUD.Text = "CRUD";
            this.rbtCRUD.UseVisualStyleBackColor = false;
            this.rbtCRUD.CheckedChanged += new System.EventHandler(this.rbtCRUD_CheckedChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDelete.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnDelete.Location = new System.Drawing.Point(319, 197);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.stylesSheetManager.SetStyle(this.btnDelete, "Button");
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Eliminar";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAdd.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAdd.Location = new System.Drawing.Point(97, 197);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.stylesSheetManager.SetStyle(this.btnAdd, "Button");
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "Agregar";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lstPermisos
            // 
            this.lstPermisos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lstPermisos.ForeColor = System.Drawing.Color.Blue;
            this.lstPermisos.FormattingEnabled = true;
            this.lstPermisos.Location = new System.Drawing.Point(97, 74);
            this.lstPermisos.Name = "lstPermisos";
            this.lstPermisos.ScrollAlwaysVisible = true;
            this.lstPermisos.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstPermisos.Size = new System.Drawing.Size(297, 121);
            this.lstPermisos.Sorted = true;
            this.stylesSheetManager.SetStyle(this.lstPermisos, "TextBox");
            this.lstPermisos.TabIndex = 10;
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtNombre.ForeColor = System.Drawing.Color.Blue;
            this.txtNombre.Location = new System.Drawing.Point(97, 35);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(297, 20);
            this.stylesSheetManager.SetStyle(this.txtNombre, "TextBox");
            this.txtNombre.TabIndex = 1;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.BackColor = System.Drawing.Color.Transparent;
            this.lblDescripcion.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblDescripcion.Location = new System.Drawing.Point(23, 38);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(58, 13);
            this.stylesSheetManager.SetStyle(this.lblDescripcion, "Label");
            this.lblDescripcion.TabIndex = 9;
            this.lblDescripcion.Text = "Nombre";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnAccept);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 457);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(469, 40);
            this.stylesSheetManager.SetStyle(this.groupBox1, "GroupBox1");
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(388, 12);
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
            // UsersGroupsCRUD
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(469, 497);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "UsersGroupsCRUD";
            this.stylesSheetManager.SetStyle(this, "FormType1");
            this.Text = "UsersGroupsCRUD";
            this.Title = "UsersGroupsCRUD";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gpbAddFunction.ResumeLayout(false);
            this.gpbAddFunction.PerformLayout();
            this.gpbCRUDItems.ResumeLayout(false);
            this.gpbSpecialItems.ResumeLayout(false);
            this.gpbGeneralItems.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stylesSheetManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.GroupBox gpbAddFunction;
        private System.Windows.Forms.RadioButton rbtGeneral;
        private System.Windows.Forms.RadioButton rbtSpecial;
        private System.Windows.Forms.RadioButton rbtCRUD;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lstPermisos;
        private System.Windows.Forms.Button btnItemCancel;
        private System.Windows.Forms.Button btnItemAccept;
        private System.Windows.Forms.GroupBox gpbCRUDItems;
        private System.Windows.Forms.CheckedListBox chkCRUDItems;
        private System.Windows.Forms.GroupBox gpbSpecialItems;
        private System.Windows.Forms.CheckedListBox chkSpecialItems;
        private System.Windows.Forms.ComboBox cmbSpecialModules;
        private System.Windows.Forms.ComboBox cmbCRUDModules;
        private System.Windows.Forms.GroupBox gpbGeneralItems;
        private System.Windows.Forms.CheckedListBox chkGeneralItems;
        private Sb.Windows.Forms.StylesSheet.StylesSheetManager stylesSheetManager;
    }
}