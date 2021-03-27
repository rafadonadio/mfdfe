using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using FrameWork.CRUDModel.Windows;

namespace FrameWork.CRUDModel.Windows.UI
{
    public class DataCombo : UserControl
    {
        public delegate void ComboAction();
        public Boolean ValueChanged;

        public event ComboAction ItemSelect;
        public event ComboAction ItemDelete;
        public event ComboAction ItemAssign;
        public event ComboAction ItemCancel;

        private TextBox txtData;
        private Button cmdBrowse;
        private Button cmdDelete;
        private Type dataType;
        private String titleGrid;
        private String titleCRUD;
        private Object selected;

        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private Container components = null;

        public DataCombo()
        {
            // Llamada necesaria para el Diseñador de formularios Windows.Forms.
            InitializeComponent();
        }

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                    components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes
        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
			this.txtData = new System.Windows.Forms.TextBox();
			this.cmdDelete = new System.Windows.Forms.Button();
			this.cmdBrowse = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtData
			// 
			this.txtData.Location = new System.Drawing.Point(0, 0);
			this.txtData.MaxLength = 0;
			this.txtData.Name = "txtData";
			this.txtData.Size = new System.Drawing.Size(240, 20);
			this.txtData.TabIndex = 1;
			this.txtData.TextChanged += new System.EventHandler(this.txtData_TextChanged);
			this.txtData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtData_KeyPress);
			// 
			// cmdDelete
			// 
			this.cmdDelete.Location = new System.Drawing.Point(264, 0);
			this.cmdDelete.Name = "cmdDelete";
			this.cmdDelete.Size = new System.Drawing.Size(24, 20);
			this.cmdDelete.TabIndex = 3;
			this.cmdDelete.Text = "X";
			this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
			// 
			// cmdBrowse
			// 
			this.cmdBrowse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.cmdBrowse.Image = global::WindowsFormsControls.Properties.Resources.ZOOM;
			this.cmdBrowse.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
			this.cmdBrowse.Location = new System.Drawing.Point(240, 0);
			this.cmdBrowse.Name = "cmdBrowse";
			this.cmdBrowse.Size = new System.Drawing.Size(24, 20);
			this.cmdBrowse.TabIndex = 2;
			this.cmdBrowse.Text = "...";
			this.cmdBrowse.Click += new System.EventHandler(this.cmdBrowse_Click);
			// 
			// DataCombo
			// 
			this.Controls.Add(this.cmdDelete);
			this.Controls.Add(this.cmdBrowse);
			this.Controls.Add(this.txtData);
			this.Name = "DataCombo";
			this.Size = new System.Drawing.Size(288, 20);
			this.ForeColorChanged += new System.EventHandler(this.DataCombo_ForeColorChanged);
			this.SizeChanged += new System.EventHandler(this.DataCombo_SizeChanged);
			this.ResumeLayout(false);
			this.PerformLayout();

        }
        #endregion


        public delegate void BrowseTypeEvent(DataCombo dc, Type dataType);

        public event BrowseTypeEvent BrowseClick;

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            if (BrowseClick != null)
                BrowseClick(this, dataType);
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            selected = null;
            txtData.Text = "";

            if (ItemDelete != null)
                ItemDelete();
        }

        private void Redistribute()
        {
            cmdDelete.Left = this.Width - cmdDelete.Width;
            cmdBrowse.Left = (ShowDelete ? cmdDelete.Left - cmdDelete.Width : this.Width - cmdBrowse.Width);
            txtData.Width = cmdBrowse.Left;
            this.Height = txtData.Height;
        }

        private void DataCombo_SizeChanged(object sender, System.EventArgs e)
        {
            Redistribute();
        }

        public bool ShowDelete
        {
            get
            { return cmdDelete.Visible; }
            set
            {
                cmdDelete.Visible = value;
                Redistribute();
            }
        }

        [Browsable(false)]
        public Type DataType
        {
            get { return dataType; }
            set { dataType = value; }
        }
        [Browsable(false)]
        public String TitleGrid
        {
            get { return titleGrid; }
            set { titleGrid = value; }
        }
        [Browsable(false)]
        public String TitleCRUD
        {
            get { return titleCRUD; }
            set { titleCRUD = value; }
        }
        [Browsable(false)]
        public Object Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                if (selected != null)
                    txtData.Text = selected.ToString();
                else
                    txtData.Text = "";

                ValueChanged = false;
                if (ItemAssign != null)
                    ItemAssign();
            }
        }

        public override String Text 
        {
            get { return txtData.Text; }
        }

        private void txtData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar (Keys.Return)) 
            {
                if (BrowseClick != null)
                    BrowseClick(this, dataType);
            }
        }

        private void DataCombo_ForeColorChanged(object sender, EventArgs e)
        {
            txtData.ForeColor = ForeColor; 
        }

        private void txtData_TextChanged(object sender, EventArgs e)
        {
            ValueChanged = true;
        }
    }
}