using System;
using System.ComponentModel;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using FrameWork.DataBusinessModel.DataModel;

namespace FrameWork.CRUDModel.Windows.UI.Grid {
	/// <summary>
	/// Summary description for GridForm.
	/// </summary>
	public class GridForm : Form, IGridForm {
		private ImageList imlToolbar;
		private ContextMenu mnuGrid;
		private MenuItem mnuGrid_Create;
		private MenuItem mnuGrid_Update;
		private MenuItem mnuGrid_Delete;
		private MenuItem mnuGrid_Retrieve;
		private MenuItem mnuGrid_Sep1;
		private IContainer components;
		private GridEX grdData;
		private ToolBar tbrGrid;
		private ToolBarButton tbtCreate;
		private ToolBarButton tbtUpdate;
		private ToolBarButton tbtDelete;
		private ToolBarButton tbtRetrieve;
		private ToolBarButton tbtSep1;
		private ToolBarButton tbtReload;
		private ToolBarButton tbtSep2;
		private ToolBarButton tbtMoveFirst;
		private ToolBarButton tbtMoveBack;
		private ToolBarButton tbtMoveNext;
		private ToolBarButton tbtMoveLast;
		private ToolBarButton tbtSep3;
		private ToolBarButton tbtExport;
		private ToolBarButton tbtPrint;
		private Panel pnlToolbox;
		private TabControl tbcToolbox;
		private TabPage tbpFilter;
		private TabPage tbpAggregate;
		private TabPage tbpOrder;
		private TabPage tbpFind;
		private Panel pnlGrid;
		private GridFilterToolbox gridFilterToolbox;
		private GridAggregateToolbox gridAggregateToolbox;
		private GridOrderToolbox gridOrderToolbox;
		private GridFreezeColumnsToolbox gridFreezeColumnsToolbox;
		private GridFindToolbox gridFindToolbox;
		private TabPage tbpFreezeColumns;
		private TabPage tbpColumns;
		private GridColumnsToolbox gridColumnsToolbox;
		private ImageList imlToolbox;
		private System.Windows.Forms.MenuItem mnuGrid_ResetLayout;

		public event NonObjectEvent CreateObject;
		public event ObjectEvent SelectObject, RetrieveObject , UpdateObject , DeleteObject;
		public event NonObjectEvent Reload;
		public event ExitEvent Exit;
		public event PersistLayoutEvent LoadLayout , SaveLayout;
		public event ResetLayoutEvent ResetLayout;
        public event FormLayoutEvent LoadFormLayout, SaveFormLayout;
		private string title;
		private Type persistentType;

        private bool allEnabled;
        private bool createEnabled, retrieveEnabled, updateEnabled, deleteEnabled;
        private bool refreshDataSourceEnabled;
        private bool navigationEnabled;
        private bool retrieveLayoutEnabled;
        private bool excelExportEnabled, printEnabled;

	    public GridForm() {
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing) {
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GridForm));
            this.imlToolbar = new System.Windows.Forms.ImageList(this.components);
            this.mnuGrid = new System.Windows.Forms.ContextMenu();
            this.mnuGrid_Create = new System.Windows.Forms.MenuItem();
            this.mnuGrid_Update = new System.Windows.Forms.MenuItem();
            this.mnuGrid_Delete = new System.Windows.Forms.MenuItem();
            this.mnuGrid_Retrieve = new System.Windows.Forms.MenuItem();
            this.mnuGrid_Sep1 = new System.Windows.Forms.MenuItem();
            this.mnuGrid_ResetLayout = new System.Windows.Forms.MenuItem();
            this.imlToolbox = new System.Windows.Forms.ImageList(this.components);
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.grdData = new Janus.Windows.GridEX.GridEX();
            this.tbrGrid = new System.Windows.Forms.ToolBar();
            this.tbtCreate = new System.Windows.Forms.ToolBarButton();
            this.tbtUpdate = new System.Windows.Forms.ToolBarButton();
            this.tbtDelete = new System.Windows.Forms.ToolBarButton();
            this.tbtRetrieve = new System.Windows.Forms.ToolBarButton();
            this.tbtSep1 = new System.Windows.Forms.ToolBarButton();
            this.tbtReload = new System.Windows.Forms.ToolBarButton();
            this.tbtSep2 = new System.Windows.Forms.ToolBarButton();
            this.tbtMoveFirst = new System.Windows.Forms.ToolBarButton();
            this.tbtMoveBack = new System.Windows.Forms.ToolBarButton();
            this.tbtMoveNext = new System.Windows.Forms.ToolBarButton();
            this.tbtMoveLast = new System.Windows.Forms.ToolBarButton();
            this.tbtSep3 = new System.Windows.Forms.ToolBarButton();
            this.tbtExport = new System.Windows.Forms.ToolBarButton();
            this.tbtPrint = new System.Windows.Forms.ToolBarButton();
            this.pnlToolbox = new System.Windows.Forms.Panel();
            this.tbcToolbox = new System.Windows.Forms.TabControl();
            this.tbpFilter = new System.Windows.Forms.TabPage();
            this.gridFilterToolbox = new FrameWork.CRUDModel.Windows.UI.Grid.GridFilterToolbox();
            this.tbpFreezeColumns = new System.Windows.Forms.TabPage();
            this.gridFreezeColumnsToolbox = new FrameWork.CRUDModel.Windows.UI.Grid.GridFreezeColumnsToolbox();
            this.tbpAggregate = new System.Windows.Forms.TabPage();
            this.gridAggregateToolbox = new FrameWork.CRUDModel.Windows.UI.Grid.GridAggregateToolbox();
            this.tbpOrder = new System.Windows.Forms.TabPage();
            this.gridOrderToolbox = new FrameWork.CRUDModel.Windows.UI.Grid.GridOrderToolbox();
            this.tbpFind = new System.Windows.Forms.TabPage();
            this.gridFindToolbox = new FrameWork.CRUDModel.Windows.UI.Grid.GridFindToolbox();
            this.tbpColumns = new System.Windows.Forms.TabPage();
            this.gridColumnsToolbox = new FrameWork.CRUDModel.Windows.UI.Grid.GridColumnsToolbox();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.pnlToolbox.SuspendLayout();
            this.tbcToolbox.SuspendLayout();
            this.tbpFilter.SuspendLayout();
            this.tbpFreezeColumns.SuspendLayout();
            this.tbpAggregate.SuspendLayout();
            this.tbpOrder.SuspendLayout();
            this.tbpFind.SuspendLayout();
            this.tbpColumns.SuspendLayout();
            this.SuspendLayout();
            // 
            // imlToolbar
            // 
            this.imlToolbar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlToolbar.ImageStream")));
            this.imlToolbar.TransparentColor = System.Drawing.Color.Empty;
            this.imlToolbar.Images.SetKeyName(0, "");
            this.imlToolbar.Images.SetKeyName(1, "");
            this.imlToolbar.Images.SetKeyName(2, "");
            this.imlToolbar.Images.SetKeyName(3, "");
            this.imlToolbar.Images.SetKeyName(4, "");
            this.imlToolbar.Images.SetKeyName(5, "");
            this.imlToolbar.Images.SetKeyName(6, "");
            this.imlToolbar.Images.SetKeyName(7, "");
            this.imlToolbar.Images.SetKeyName(8, "");
            this.imlToolbar.Images.SetKeyName(9, "");
            this.imlToolbar.Images.SetKeyName(10, "");
            // 
            // mnuGrid
            // 
            this.mnuGrid.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuGrid_Create,
            this.mnuGrid_Update,
            this.mnuGrid_Delete,
            this.mnuGrid_Retrieve,
            this.mnuGrid_Sep1,
            this.mnuGrid_ResetLayout});
            // 
            // mnuGrid_Create
            // 
            this.mnuGrid_Create.Index = 0;
            this.mnuGrid_Create.Text = "Agregar";
            this.mnuGrid_Create.Click += new System.EventHandler(this.mnuGrid_Create_Click);
            // 
            // mnuGrid_Update
            // 
            this.mnuGrid_Update.Index = 1;
            this.mnuGrid_Update.Text = "Modificar";
            this.mnuGrid_Update.Click += new System.EventHandler(this.mnuGrid_Update_Click);
            // 
            // mnuGrid_Delete
            // 
            this.mnuGrid_Delete.Index = 2;
            this.mnuGrid_Delete.Text = "Eliminar";
            this.mnuGrid_Delete.Click += new System.EventHandler(this.mnuGrid_Delete_Click);
            // 
            // mnuGrid_Retrieve
            // 
            this.mnuGrid_Retrieve.Index = 3;
            this.mnuGrid_Retrieve.Text = "Consultar";
            this.mnuGrid_Retrieve.Click += new System.EventHandler(this.mnuGrid_Retrieve_Click);
            // 
            // mnuGrid_Sep1
            // 
            this.mnuGrid_Sep1.Index = 4;
            this.mnuGrid_Sep1.Text = "-";
            // 
            // mnuGrid_ResetLayout
            // 
            this.mnuGrid_ResetLayout.Index = 5;
            this.mnuGrid_ResetLayout.Text = "Restablecer Grilla";
            this.mnuGrid_ResetLayout.Click += new System.EventHandler(this.mnuGrid_ResetLayout_Click);
            // 
            // imlToolbox
            // 
            this.imlToolbox.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlToolbox.ImageStream")));
            this.imlToolbox.TransparentColor = System.Drawing.Color.Transparent;
            this.imlToolbox.Images.SetKeyName(0, "");
            this.imlToolbox.Images.SetKeyName(1, "");
            this.imlToolbox.Images.SetKeyName(2, "");
            this.imlToolbox.Images.SetKeyName(3, "");
            this.imlToolbox.Images.SetKeyName(4, "");
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.grdData);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(0, 48);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(532, 289);
            this.pnlGrid.TabIndex = 11;
            // 
            // grdData
            // 
            this.grdData.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdData.AlternatingColors = true;
            this.grdData.AlternatingRowFormatStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grdData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdData.ContextMenu = this.mnuGrid;
            this.grdData.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.grdData.GroupByBoxVisible = false;
            this.grdData.IncrementalSearchMode = Janus.Windows.GridEX.IncrementalSearchMode.AllCharacters;
            this.grdData.Location = new System.Drawing.Point(8, 8);
            this.grdData.Name = "grdData";
            this.grdData.RowFormatStyle.BackColor = System.Drawing.SystemColors.Info;
            this.grdData.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdData.Size = new System.Drawing.Size(516, 273);
            this.grdData.TabIndex = 4;
            this.grdData.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.grdData.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            this.grdData.RowDoubleClick += new Janus.Windows.GridEX.RowActionEventHandler(this.grdData_RowDoubleClick);
            // 
            // tbrGrid
            // 
            this.tbrGrid.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.tbtCreate,
            this.tbtUpdate,
            this.tbtDelete,
            this.tbtRetrieve,
            this.tbtSep1,
            this.tbtReload,
            this.tbtSep2,
            this.tbtMoveFirst,
            this.tbtMoveBack,
            this.tbtMoveNext,
            this.tbtMoveLast,
            this.tbtSep3,
            this.tbtExport,
            this.tbtPrint});
            this.tbrGrid.ButtonSize = new System.Drawing.Size(24, 24);
            this.tbrGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbrGrid.DropDownArrows = true;
            this.tbrGrid.ImageList = this.imlToolbar;
            this.tbrGrid.Location = new System.Drawing.Point(0, 337);
            this.tbrGrid.Name = "tbrGrid";
            this.tbrGrid.ShowToolTips = true;
            this.tbrGrid.Size = new System.Drawing.Size(532, 36);
            this.tbrGrid.TabIndex = 9;
            this.tbrGrid.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tbrGrid_ButtonClick);
            // 
            // tbtCreate
            // 
            this.tbtCreate.ImageIndex = 0;
            this.tbtCreate.Name = "tbtCreate";
            this.tbtCreate.ToolTipText = "Agregar";
            // 
            // tbtUpdate
            // 
            this.tbtUpdate.ImageIndex = 1;
            this.tbtUpdate.Name = "tbtUpdate";
            this.tbtUpdate.ToolTipText = "Modificar";
            // 
            // tbtDelete
            // 
            this.tbtDelete.ImageIndex = 2;
            this.tbtDelete.Name = "tbtDelete";
            this.tbtDelete.ToolTipText = "Eliminar";
            // 
            // tbtRetrieve
            // 
            this.tbtRetrieve.ImageIndex = 3;
            this.tbtRetrieve.Name = "tbtRetrieve";
            this.tbtRetrieve.ToolTipText = "Consultar";
            // 
            // tbtSep1
            // 
            this.tbtSep1.Name = "tbtSep1";
            this.tbtSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbtReload
            // 
            this.tbtReload.ImageIndex = 4;
            this.tbtReload.Name = "tbtReload";
            this.tbtReload.ToolTipText = "Recargar Grilla";
            // 
            // tbtSep2
            // 
            this.tbtSep2.Name = "tbtSep2";
            this.tbtSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbtMoveFirst
            // 
            this.tbtMoveFirst.ImageIndex = 5;
            this.tbtMoveFirst.Name = "tbtMoveFirst";
            this.tbtMoveFirst.ToolTipText = "Primero";
            // 
            // tbtMoveBack
            // 
            this.tbtMoveBack.ImageIndex = 6;
            this.tbtMoveBack.Name = "tbtMoveBack";
            this.tbtMoveBack.ToolTipText = "Anterior";
            // 
            // tbtMoveNext
            // 
            this.tbtMoveNext.ImageIndex = 7;
            this.tbtMoveNext.Name = "tbtMoveNext";
            this.tbtMoveNext.ToolTipText = "Siguiente";
            // 
            // tbtMoveLast
            // 
            this.tbtMoveLast.ImageIndex = 8;
            this.tbtMoveLast.Name = "tbtMoveLast";
            this.tbtMoveLast.ToolTipText = "Último";
            // 
            // tbtSep3
            // 
            this.tbtSep3.Name = "tbtSep3";
            this.tbtSep3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbtExport
            // 
            this.tbtExport.ImageIndex = 9;
            this.tbtExport.Name = "tbtExport";
            this.tbtExport.ToolTipText = "Exportar a Excel";
            // 
            // tbtPrint
            // 
            this.tbtPrint.ImageIndex = 10;
            this.tbtPrint.Name = "tbtPrint";
            this.tbtPrint.ToolTipText = "Imprimir";
            // 
            // pnlToolbox
            // 
            this.pnlToolbox.Controls.Add(this.tbcToolbox);
            this.pnlToolbox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbox.Location = new System.Drawing.Point(0, 0);
            this.pnlToolbox.Name = "pnlToolbox";
            this.pnlToolbox.Padding = new System.Windows.Forms.Padding(8);
            this.pnlToolbox.Size = new System.Drawing.Size(532, 48);
            this.pnlToolbox.TabIndex = 10;
            this.pnlToolbox.Leave += new System.EventHandler(this.pnlToolbox_Leave);
            // 
            // tbcToolbox
            // 
            this.tbcToolbox.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tbcToolbox.Controls.Add(this.tbpFilter);
            this.tbcToolbox.Controls.Add(this.tbpFreezeColumns);
            this.tbcToolbox.Controls.Add(this.tbpAggregate);
            this.tbcToolbox.Controls.Add(this.tbpOrder);
            this.tbcToolbox.Controls.Add(this.tbpFind);
            this.tbcToolbox.Controls.Add(this.tbpColumns);
            this.tbcToolbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcToolbox.ImageList = this.imlToolbox;
            this.tbcToolbox.ItemSize = new System.Drawing.Size(59, 22);
            this.tbcToolbox.Location = new System.Drawing.Point(8, 8);
            this.tbcToolbox.Multiline = true;
            this.tbcToolbox.Name = "tbcToolbox";
            this.tbcToolbox.SelectedIndex = 0;
            this.tbcToolbox.Size = new System.Drawing.Size(516, 32);
            this.tbcToolbox.TabIndex = 0;
            this.tbcToolbox.SelectedIndexChanged += new System.EventHandler(this.tbcToolbox_SelectedIndexChanged);
            // 
            // tbpFilter
            // 
            this.tbpFilter.AutoScroll = true;
            this.tbpFilter.Controls.Add(this.gridFilterToolbox);
            this.tbpFilter.ImageIndex = 0;
            this.tbpFilter.Location = new System.Drawing.Point(4, 4);
            this.tbpFilter.Name = "tbpFilter";
            this.tbpFilter.Size = new System.Drawing.Size(508, 2);
            this.tbpFilter.TabIndex = 0;
            this.tbpFilter.Text = "Filtrar";
            // 
            // gridFilterToolbox
            // 
            this.gridFilterToolbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridFilterToolbox.Location = new System.Drawing.Point(0, 0);
            this.gridFilterToolbox.Name = "gridFilterToolbox";
            this.gridFilterToolbox.Size = new System.Drawing.Size(508, 2);
            this.gridFilterToolbox.TabIndex = 0;
            // 
            // tbpFreezeColumns
            // 
            this.tbpFreezeColumns.Controls.Add(this.gridFreezeColumnsToolbox);
            this.tbpFreezeColumns.ImageIndex = 3;
            this.tbpFreezeColumns.Location = new System.Drawing.Point(4, 4);
            this.tbpFreezeColumns.Name = "tbpFreezeColumns";
            this.tbpFreezeColumns.Size = new System.Drawing.Size(508, 2);
            this.tbpFreezeColumns.TabIndex = 3;
            this.tbpFreezeColumns.Text = "Fijar Columnas";
            this.tbpFreezeColumns.Visible = false;
            // 
            // gridFreezeColumnsToolbox
            // 
            this.gridFreezeColumnsToolbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridFreezeColumnsToolbox.Location = new System.Drawing.Point(0, 0);
            this.gridFreezeColumnsToolbox.Name = "gridFreezeColumnsToolbox";
            this.gridFreezeColumnsToolbox.Size = new System.Drawing.Size(508, 2);
            this.gridFreezeColumnsToolbox.TabIndex = 0;
            // 
            // tbpAggregate
            // 
            this.tbpAggregate.Controls.Add(this.gridAggregateToolbox);
            this.tbpAggregate.ImageIndex = 2;
            this.tbpAggregate.Location = new System.Drawing.Point(4, 4);
            this.tbpAggregate.Name = "tbpAggregate";
            this.tbpAggregate.Size = new System.Drawing.Size(508, 2);
            this.tbpAggregate.TabIndex = 2;
            this.tbpAggregate.Text = "Calcular";
            this.tbpAggregate.Visible = false;
            // 
            // gridAggregateToolbox
            // 
            this.gridAggregateToolbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAggregateToolbox.Location = new System.Drawing.Point(0, 0);
            this.gridAggregateToolbox.Name = "gridAggregateToolbox";
            this.gridAggregateToolbox.Size = new System.Drawing.Size(508, 2);
            this.gridAggregateToolbox.TabIndex = 0;
            // 
            // tbpOrder
            // 
            this.tbpOrder.AutoScroll = true;
            this.tbpOrder.Controls.Add(this.gridOrderToolbox);
            this.tbpOrder.ImageIndex = 1;
            this.tbpOrder.Location = new System.Drawing.Point(4, 4);
            this.tbpOrder.Name = "tbpOrder";
            this.tbpOrder.Size = new System.Drawing.Size(508, 2);
            this.tbpOrder.TabIndex = 1;
            this.tbpOrder.Text = "Ordenar";
            this.tbpOrder.Visible = false;
            // 
            // gridOrderToolbox
            // 
            this.gridOrderToolbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridOrderToolbox.Location = new System.Drawing.Point(0, 0);
            this.gridOrderToolbox.Name = "gridOrderToolbox";
            this.gridOrderToolbox.Size = new System.Drawing.Size(508, 2);
            this.gridOrderToolbox.TabIndex = 0;
            // 
            // tbpFind
            // 
            this.tbpFind.Controls.Add(this.gridFindToolbox);
            this.tbpFind.ImageIndex = 4;
            this.tbpFind.Location = new System.Drawing.Point(4, 4);
            this.tbpFind.Name = "tbpFind";
            this.tbpFind.Size = new System.Drawing.Size(508, 2);
            this.tbpFind.TabIndex = 4;
            this.tbpFind.Text = "Buscar";
            this.tbpFind.Visible = false;
            // 
            // gridFindToolbox
            // 
            this.gridFindToolbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridFindToolbox.Location = new System.Drawing.Point(0, 0);
            this.gridFindToolbox.Name = "gridFindToolbox";
            this.gridFindToolbox.Size = new System.Drawing.Size(508, 2);
            this.gridFindToolbox.TabIndex = 0;
            // 
            // tbpColumns
            // 
            this.tbpColumns.Controls.Add(this.gridColumnsToolbox);
            this.tbpColumns.Location = new System.Drawing.Point(4, 4);
            this.tbpColumns.Name = "tbpColumns";
            this.tbpColumns.Size = new System.Drawing.Size(508, 2);
            this.tbpColumns.TabIndex = 5;
            this.tbpColumns.Text = "Columnas";
            // 
            // gridColumnsToolbox
            // 
            this.gridColumnsToolbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridColumnsToolbox.Location = new System.Drawing.Point(0, 0);
            this.gridColumnsToolbox.Name = "gridColumnsToolbox";
            this.gridColumnsToolbox.Size = new System.Drawing.Size(508, 2);
            this.gridColumnsToolbox.TabIndex = 0;
            // 
            // GridForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(532, 373);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.tbrGrid);
            this.Controls.Add(this.pnlToolbox);
            this.MinimumSize = new System.Drawing.Size(540, 400);
            this.Name = "GridForm";
            this.Text = "GridForm";
            this.Closed += new System.EventHandler(this.GridForm_Closed);
            this.Load += new System.EventHandler(this.GridForm_Load);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.pnlToolbox.ResumeLayout(false);
            this.tbcToolbox.ResumeLayout(false);
            this.tbpFilter.ResumeLayout(false);
            this.tbpFreezeColumns.ResumeLayout(false);
            this.tbpAggregate.ResumeLayout(false);
            this.tbpOrder.ResumeLayout(false);
            this.tbpFind.ResumeLayout(false);
            this.tbpColumns.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private void tbrGrid_ButtonClick(object sender, ToolBarButtonClickEventArgs e) {
			if (e.Button == tbtCreate) CreateRecord();
			else if (e.Button == tbtUpdate) UpdateRecord();
			else if (e.Button == tbtDelete) DeleteRecord();
			else if (e.Button == tbtRetrieve) RetrieveRecord();
			else if (e.Button == tbtReload) RefreshDataSource();
			else if (e.Button == tbtMoveFirst) MoveFirst();
			else if (e.Button == tbtMoveBack) MoveBack();
			else if (e.Button == tbtMoveNext) MoveNext();
			else if (e.Button == tbtMoveLast) MoveLast();
			else if (e.Button == tbtExport) Export();
			else if (e.Button == tbtPrint) Print();
		}

		protected void CreateRecord() {
			CreateObject();
		}

		protected void UpdateRecord() {
			if (0 <= grdData.Row) {
				UpdateObject(grdData.GetRow(grdData.Row).DataRow);
			}
		}

        protected void SelectRecord()
        {
            if (0 <= grdData.Row)
            {
                SelectObject(grdData.GetRow(grdData.Row).DataRow);
            }
        }

		protected void DeleteRecord() {
			if (0 <= grdData.Row) {
				DeleteObject(grdData.GetRow(grdData.Row).DataRow);
			}
		}

		protected void RetrieveRecord() {
			if (0 <= grdData.Row) {
				RetrieveObject(grdData.GetRow(grdData.Row).DataRow);
			}
		}

		protected void ReloadGrid() {
			Reload();
		}

		protected void MoveFirst() {
			grdData.MoveFirst();
		}

		protected void MoveBack() {
			grdData.MovePrevious();
		}

		protected void MoveNext() {
			grdData.MoveNext();
		}

		protected void MoveLast() {
			grdData.MoveLast();
		}

		protected void Export() {
			GridUtils.ExportToExcel(grdData);
		}

		protected void Print() {
			MessageBox.Show("Print DataGrid");
		}

		private void mnuGrid_Create_Click(object sender, EventArgs e) {
			CreateRecord();
		}

		private void mnuGrid_Update_Click(object sender, EventArgs e) {
			UpdateRecord();
		}

		private void mnuGrid_Delete_Click(object sender, EventArgs e) {
			DeleteRecord();
		}

		private void mnuGrid_Retrieve_Click(object sender, EventArgs e) {
			RetrieveRecord();
		}

		private void tbcToolbox_SelectedIndexChanged(object sender, EventArgs e) {
			if (tbcToolbox.SelectedTab == tbpFilter) pnlToolbox.Height = 88;
			else if (tbcToolbox.SelectedTab == tbpAggregate) pnlToolbox.Height = 136;
			else if (tbcToolbox.SelectedTab == tbpOrder) pnlToolbox.Height = 184;
			else if (tbcToolbox.SelectedTab == tbpFreezeColumns) pnlToolbox.Height = 184;
			else if (tbcToolbox.SelectedTab == tbpFind) pnlToolbox.Height = 152;
			else if (tbcToolbox.SelectedTab == tbpColumns) pnlToolbox.Height = 184;
		}

		protected void HideToolbox() {
			pnlToolbox.Height = tbcToolbox.ItemSize.Height + 6 + pnlToolbox.DockPadding.Top + pnlToolbox.DockPadding.Bottom;
			tbcToolbox.SelectedTab = null;
		}

		private void GridForm_Load(object sender, EventArgs e) {
			HideToolbox();
		    RequireLoadFormLayout();
		}

		private void pnlToolbox_Leave(object sender, EventArgs e) {
			HideToolbox();
		}

		private void RequireLayoutLoad() {
			if (LoadLayout != null) {
				LoadLayout(grdData);
				RebindGridToolbox();
			}
		}

		private void RequireLayoutSave() {
			if (SaveLayout != null)
				SaveLayout(grdData);
		}

		private void RequireLayoutReset(Type type) {
			if (ResetLayout != null) {
				ResetLayout(grdData, type);
				grdData.RootTable.FilterCondition=null;
				RebindGridToolbox();
			}
		}

	    private void RequireLoadFormLayout() {
            if (LoadFormLayout != null) LoadFormLayout(this);
	    }

        private void RequireSaveFormLayout() {
            if (SaveFormLayout != null) SaveFormLayout(this);
        }
	    
        private void RebindGridToolbox() {
			gridOrderToolbox.Grid = gridFilterToolbox.Grid = gridAggregateToolbox.Grid =
				gridFreezeColumnsToolbox.Grid = gridFindToolbox.Grid = gridColumnsToolbox.Grid = this.grdData;
		}

		public void SetDataSource(object dataSource, bool retrieveStructure) {
			grdData.DataSource = dataSource;
			grdData.Refetch();

			if (retrieveStructure) {
				grdData.RetrieveStructure();

				RebindGridToolbox();
			}
		}

		public void SetDataSource(object dataSource) {
			SetDataSource(dataSource, false);
		}

		public void SetLayout(Type persistentType) {
			this.persistentType=persistentType;
			RequireLayoutReset(persistentType);
			RequireLayoutLoad();
		}

		public void RefreshDataSource() {
			grdData.Refresh();
		}

		private void GridForm_Closed(object sender, EventArgs e) {
			if (Exit != null) Exit(this);
			RequireLayoutSave();
		    RequireSaveFormLayout();
		}

		private void grdData_RowDoubleClick(object sender, RowActionEventArgs e) {
			SelectRecord();
		}

		private void mnuGrid_ResetLayout_Click(object sender, System.EventArgs e) {
			RequireLayoutReset(this.persistentType);
		}


		public string Title {
			get { return this.title; }
			set { this.title = this.Text = value; }
		}

	    public bool AllEnabled {
	        get { return allEnabled; }
	        set {
	            allEnabled = value;
                CreateEnabled = RetrieveEnabled = UpdateEnabled = DeleteEnabled = RefreshDataSourceEnabled = allEnabled;
                RetrieveLayoutEnabled = NavigationEnabled = ExportEnabled = allEnabled;
	        }
	    }

	    public bool CreateEnabled {
	        get { return createEnabled; }
	        set {
	            createEnabled = value;
                tbtCreate.Visible = mnuGrid_Create.Visible = value;
	        }
	    }

	    public bool RetrieveEnabled {
	        get { return retrieveEnabled; }
	        set {
	            retrieveEnabled = value;
                tbtRetrieve.Visible = mnuGrid_Retrieve.Visible = value;
	        }
	    }

	    public bool UpdateEnabled {
	        get { return updateEnabled; }
	        set {
	            updateEnabled = value;
                tbtUpdate.Visible = mnuGrid_Update.Visible = value;
	        }
	    }

	    public bool DeleteEnabled {
	        get { return deleteEnabled; }
	        set {
	            deleteEnabled = value;
	            tbtDelete.Visible = mnuGrid_Delete.Visible = value;
	        }
	    }

        public bool CRUDEnabled {
            get { return CreateEnabled || RetrieveEnabled || UpdateEnabled || DeleteEnabled; }
            set { CreateEnabled = RetrieveEnabled=UpdateEnabled=DeleteEnabled= value; }
        }

        public bool OnlyCRUDEnabled {
            get { return (CreateEnabled && RetrieveEnabled && UpdateEnabled && DeleteEnabled) && !false ; }
            set {
                if(value) {
                    CRUDEnabled = true;
                    ExportEnabled = false;
                }
            }
        }

	    public bool RefreshDataSourceEnabled {
	        get { return refreshDataSourceEnabled; }
	        set { 
	            refreshDataSourceEnabled = value;
                tbtReload.Visible = value;
	        }
	    }

	    public bool NavigationEnabled {
	        get { return navigationEnabled; }
	        set {
	            navigationEnabled = value;
                tbtMoveBack.Visible = tbtMoveFirst.Visible = tbtMoveLast.Visible = tbtMoveNext.Visible = value;
	        }
	    }

	    public bool RetrieveLayoutEnabled {
	        get { return retrieveLayoutEnabled; }
	        set {
	            retrieveLayoutEnabled = value;
                mnuGrid_ResetLayout.Visible = value;
	        }
	    }

	    public bool ExcelExportEnabled {
	        get { return excelExportEnabled; }
	        set {
	            excelExportEnabled = value;
                tbtExport.Visible = value;
	        }
	    }

	    public bool PrintEnabled {
	        get { return printEnabled; }
	        set {
	            printEnabled = value;
                tbtPrint.Visible = value;
	        }
	    }

	    public bool ExportEnabled {
            get { return ExcelExportEnabled && PrintEnabled; }
	        set { ExcelExportEnabled = PrintEnabled = value; }
	    }

	    public void SetFilter(String value)
        {
            Janus.Windows.GridEX.GridEXFilterCondition cond = null;
            Janus.Windows.GridEX.GridEXSortKey sort = null;
            Attribute[] columnAttributes = Attribute.GetCustomAttributes(persistentType);
            foreach (Attribute columnAttribute in columnAttributes)
            {
                if (columnAttribute is FilterColumnAttribute)
                {
                    cond = new GridEXFilterCondition();
                    cond.Column = grdData.RootTable.Columns[(columnAttribute as FilterColumnAttribute).Name];
                    cond.Value1 = value;
                    cond.ConditionOperator = Janus.Windows.GridEX.ConditionOperator.Contains;

                    sort = new GridEXSortKey();
                    sort.Column = grdData.RootTable.Columns[(columnAttribute as FilterColumnAttribute).Name];
                    sort.SortOrder = Janus.Windows.GridEX.SortOrder.Ascending; 
                }
            }

            if (value != String.Empty)
            {
                grdData.RootTable.ApplyFilter(cond);
                if (grdData.RowCount == 0)
                    grdData.RootTable.ApplyFilter(null);
            }
            else
                grdData.RootTable.ApplyFilter(null);

            
            grdData.RootTable.SortKeys.Clear();
            grdData.RootTable.SortKeys.Add (sort);
        }
    }

	public delegate void NonObjectEvent();

	public delegate void ObjectEvent(object obj);
}