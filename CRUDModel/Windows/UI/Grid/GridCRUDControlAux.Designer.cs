namespace FrameWork.CRUDModel.Windows.UI.Grid
{
    partial class GridCRUDControlAux
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GridCRUDControlAux));
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnAction = new System.Windows.Forms.Button();
            this.btnRetrieve = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.grdData = new Janus.Windows.GridEX.GridEX();
            this.pnlButtons.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnAction);
            this.pnlButtons.Controls.Add(this.btnRetrieve);
            this.pnlButtons.Controls.Add(this.btnDelete);
            this.pnlButtons.Controls.Add(this.btnUpdate);
            this.pnlButtons.Controls.Add(this.btnCreate);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 235);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(461, 37);
            this.pnlButtons.TabIndex = 0;
            // 
            // btnAction
            // 
            this.btnAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAction.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAction.Location = new System.Drawing.Point(383, 7);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(75, 23);
            this.btnAction.TabIndex = 4;
            this.btnAction.Text = "Acción";
            this.btnAction.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            this.btnAction.TextChanged += new System.EventHandler(this.Button_TextChanged);
            // 
            // btnRetrieve
            // 
            this.btnRetrieve.Image = ((System.Drawing.Image)(resources.GetObject("btnRetrieve.Image")));
            this.btnRetrieve.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRetrieve.Location = new System.Drawing.Point(250, 7);
            this.btnRetrieve.Name = "btnRetrieve";
            this.btnRetrieve.Size = new System.Drawing.Size(75, 23);
            this.btnRetrieve.TabIndex = 3;
            this.btnRetrieve.Text = "Consultar";
            this.btnRetrieve.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRetrieve.UseVisualStyleBackColor = true;
            this.btnRetrieve.VisibleChanged += new System.EventHandler(this.Button_VisibleChanged);
            this.btnRetrieve.Click += new System.EventHandler(this.btnRetrieve_Click);
            this.btnRetrieve.TextChanged += new System.EventHandler(this.Button_TextChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(168, 7);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Borrar";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.VisibleChanged += new System.EventHandler(this.Button_VisibleChanged);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnDelete.TextChanged += new System.EventHandler(this.Button_TextChanged);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(86, 7);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Modificar";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.VisibleChanged += new System.EventHandler(this.Button_VisibleChanged);
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            this.btnUpdate.TextChanged += new System.EventHandler(this.Button_TextChanged);
            // 
            // btnCreate
            // 
            this.btnCreate.Image = ((System.Drawing.Image)(resources.GetObject("btnCreate.Image")));
            this.btnCreate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreate.Location = new System.Drawing.Point(4, 7);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "Crear";
            this.btnCreate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.VisibleChanged += new System.EventHandler(this.Button_VisibleChanged);
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            this.btnCreate.TextChanged += new System.EventHandler(this.Button_TextChanged);
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.grdData);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 0);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(5);
            this.pnlGrid.Size = new System.Drawing.Size(461, 235);
            this.pnlGrid.TabIndex = 0;
            // 
            // grdData
            // 
            this.grdData.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdData.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.grdData.GroupByBoxVisible = false;
            this.grdData.Location = new System.Drawing.Point(5, 5);
            this.grdData.Name = "grdData";
            this.grdData.Size = new System.Drawing.Size(451, 225);
            this.grdData.TabIndex = 0;
            this.grdData.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.grdData.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            this.grdData.RowDoubleClick += new Janus.Windows.GridEX.RowActionEventHandler(this.grdData_RowDoubleClick);
            // 
            // GridCRUDControlAux
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlButtons);
            this.Name = "GridCRUDControlAux";
            this.Size = new System.Drawing.Size(461, 272);
            this.VisibleChanged += new System.EventHandler(this.GridCRUDControlAux_VisibleChanged);
            this.pnlButtons.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.Button btnRetrieve;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCreate;
        private Janus.Windows.GridEX.GridEX grdData;
    }
}
