using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using SortOrder = Janus.Windows.GridEX.SortOrder;

namespace FrameWork.CRUDModel.Windows.UI.Grid {
	/// <summary>
	/// Summary description for GridOrderToolbox.
	/// </summary>
	internal class GridOrderToolbox : UserControl {
		private GridEX grdSortKeys;
		private Button btnAccept;
		private Button btnDown;
		private Button btnUp;
		private Button btnRemove;
		private Button btnAdd;
		private ListBox lstAvailableColumns;
		private IContainer components;

		protected GridEX grid;
		protected ArrayList availableColumns;
		private ImageList imlButtons;
		protected ArrayList sortKeys;

		public GridOrderToolbox() {
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof (GridOrderToolbox));
			this.grdSortKeys = new Janus.Windows.GridEX.GridEX();
			this.btnAccept = new System.Windows.Forms.Button();
			this.btnDown = new System.Windows.Forms.Button();
			this.btnUp = new System.Windows.Forms.Button();
			this.btnRemove = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.lstAvailableColumns = new System.Windows.Forms.ListBox();
			this.imlButtons = new System.Windows.Forms.ImageList(this.components);
			((System.ComponentModel.ISupportInitialize) (this.grdSortKeys)).BeginInit();
			this.SuspendLayout();
			// 
			// grdSortKeys
			// 
			this.grdSortKeys.ColumnHeaders = Janus.Windows.GridEX.InheritableBoolean.False;
			this.grdSortKeys.ColumnSetHeaders = Janus.Windows.GridEX.InheritableBoolean.False;
			this.grdSortKeys.GridLines = Janus.Windows.GridEX.GridLines.None;
			this.grdSortKeys.GroupByBoxVisible = false;
			this.grdSortKeys.Location = new System.Drawing.Point(224, 8);
			this.grdSortKeys.Name = "grdSortKeys";
			this.grdSortKeys.Size = new System.Drawing.Size(184, 121);
			this.grdSortKeys.TabIndex = 14;
			this.grdSortKeys.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
			// 
			// btnAccept
			// 
			this.btnAccept.Location = new System.Drawing.Point(416, 104);
			this.btnAccept.Name = "btnAccept";
			this.btnAccept.Size = new System.Drawing.Size(72, 24);
			this.btnAccept.TabIndex = 13;
			this.btnAccept.Text = "Aceptar";
			this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
			// 
			// btnDown
			// 
			this.btnDown.ImageIndex = 3;
			this.btnDown.ImageList = this.imlButtons;
			this.btnDown.Location = new System.Drawing.Point(184, 104);
			this.btnDown.Name = "btnDown";
			this.btnDown.Size = new System.Drawing.Size(32, 23);
			this.btnDown.TabIndex = 12;
			this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
			// 
			// btnUp
			// 
			this.btnUp.ImageIndex = 2;
			this.btnUp.ImageList = this.imlButtons;
			this.btnUp.Location = new System.Drawing.Point(184, 72);
			this.btnUp.Name = "btnUp";
			this.btnUp.Size = new System.Drawing.Size(32, 23);
			this.btnUp.TabIndex = 11;
			this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
			// 
			// btnRemove
			// 
			this.btnRemove.ImageIndex = 1;
			this.btnRemove.ImageList = this.imlButtons;
			this.btnRemove.Location = new System.Drawing.Point(184, 40);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(32, 23);
			this.btnRemove.TabIndex = 10;
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.ImageIndex = 0;
			this.btnAdd.ImageList = this.imlButtons;
			this.btnAdd.Location = new System.Drawing.Point(184, 8);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(32, 23);
			this.btnAdd.TabIndex = 9;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// lstAvailableColumns
			// 
			this.lstAvailableColumns.Location = new System.Drawing.Point(24, 8);
			this.lstAvailableColumns.Name = "lstAvailableColumns";
			this.lstAvailableColumns.Size = new System.Drawing.Size(152, 121);
			this.lstAvailableColumns.TabIndex = 8;
			// 
			// imlButtons
			// 
			this.imlButtons.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
			this.imlButtons.ImageSize = new System.Drawing.Size(16, 16);
			this.imlButtons.ImageStream = ((System.Windows.Forms.ImageListStreamer) (resources.GetObject("imlButtons.ImageStream")));
			this.imlButtons.TransparentColor = System.Drawing.Color.White;
			// 
			// GridOrderToolbox
			// 
			this.Controls.Add(this.grdSortKeys);
			this.Controls.Add(this.btnAccept);
			this.Controls.Add(this.btnDown);
			this.Controls.Add(this.btnUp);
			this.Controls.Add(this.btnRemove);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.lstAvailableColumns);
			this.Name = "GridOrderToolbox";
			this.Size = new System.Drawing.Size(512, 136);
			((System.ComponentModel.ISupportInitialize) (this.grdSortKeys)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private void btnAdd_Click(object sender, EventArgs e) {
			GridEXColumn column;
			column = (GridEXColumn) lstAvailableColumns.SelectedItem;
			if (column != null) {
				availableColumns.Remove(column);
				sortKeys.Add(new CustomSortKey(column));
				RebindControls();
			}
		}

		private void btnRemove_Click(object sender, EventArgs e) {
			if (grdSortKeys.SelectedItems.Count > 0) {
				CustomSortKey sortKey = (CustomSortKey) grdSortKeys.SelectedItems[0].GetRow().DataRow;
				if (grdSortKeys.Row == sortKeys.Count - 1) grdSortKeys.Row = (sortKeys.Count - 2 > 0) ? (sortKeys.Count - 2) : 0;
				availableColumns.Add(sortKey.Column);
				grdSortKeys.SelectedItems.Clear();
				grdSortKeys.SelectedItems.Add(sortKeys.Count - 1);
				sortKeys.Remove(sortKey);
				RebindControls();
			}
		}

		private void btnUp_Click(object sender, EventArgs e) {
			if (grdSortKeys.SelectedItems.Count > 0) {
				CustomSortKey sortKey = (CustomSortKey) grdSortKeys.SelectedItems[0].GetRow().DataRow;
				int index = sortKeys.IndexOf(sortKey);
				if (index > 0) {
					sortKeys.RemoveAt(index);
					sortKeys.Insert(index - 1, sortKey);
					RebindControls();
					grdSortKeys.SelectedItems.Clear();
					grdSortKeys.SelectedItems.Add(index - 1);
				}
			}
		}

		private void btnDown_Click(object sender, EventArgs e) {
			if (grdSortKeys.SelectedItems.Count > 0) {
				CustomSortKey sortKey = (CustomSortKey) grdSortKeys.SelectedItems[0].GetRow().DataRow;
				int index = sortKeys.IndexOf(sortKey);
				if (index < sortKeys.Count - 1) {
					sortKeys.RemoveAt(index);
					sortKeys.Insert(index + 1, sortKey);
					RebindControls();
					grdSortKeys.SelectedItems.Clear();
					grdSortKeys.SelectedItems.Add(index + 1);
				}
			}
		}

		public GridEX Grid {
			set {
				if (value != null) {
					grid = value;
					grid.SortKeysChanged += new EventHandler(this.SortKeysChanged);
					Rebind();
				}
				else {
					grid.SortKeysChanged -= new EventHandler(this.SortKeysChanged);
					grid = null;
				}
			}
		}

		public void Rebind() {
			availableColumns = new ArrayList();
			sortKeys = new ArrayList();

			InitializeGridSortKeys();
			foreach (GridEXColumn column in grid.RootTable.Columns)
				availableColumns.Add(column);

			foreach (GridEXSortKey sortKey in grid.RootTable.SortKeys) {
				availableColumns.Remove(sortKey.Column);
				sortKeys.Add(new CustomSortKey(sortKey));
			}

			RebindControls();
		}

		private void RebindControls() {
			lstAvailableColumns.Items.Clear();
			lstAvailableColumns.ValueMember = "Caption";

			foreach (GridEXColumn column in availableColumns)
				lstAvailableColumns.Items.Add(column);

			this.grdSortKeys.SelectedItems.Clear();
			//if(this.grdSortKeys.Row>=sortKeys.Count) this.grdSortKeys.Row=sortKeys.Count-1;
			this.grdSortKeys.Refetch();
		}

		private void InitializeGridSortKeys() {
			GridEXColumn newColumn = null;

			this.grdSortKeys.DataSource = sortKeys;
			this.grdSortKeys.RetrieveStructure();
			this.grdSortKeys.RootTable.Columns.Clear();
			newColumn = this.grdSortKeys.RootTable.Columns.Add("ColumnCaption", ColumnType.Text);
			newColumn.EditType = EditType.NoEdit;
			newColumn.Width = 100;
			newColumn = this.grdSortKeys.RootTable.Columns.Add("SortOrder", ColumnType.Text);
			newColumn.EditType = EditType.DropDownList;
			newColumn.Width = 82;
			newColumn.EditValueList = new GridEXValueListItemCollection();
			newColumn.EditValueList.Add(new GridEXValueListItem(SortOrder.Ascending, SortOrder.Ascending.ToString()));
			newColumn.EditValueList.Add(new GridEXValueListItem(SortOrder.Descending, SortOrder.Descending.ToString()));
		}

		private void SetOrder() {
			grid.RootTable.SortKeys.Clear();
			foreach (CustomSortKey sortKey in sortKeys)
				grid.RootTable.SortKeys.Add(sortKey);
		}

		private void btnAccept_Click(object sender, EventArgs e) {
			SetOrder();
		}

		private void SortKeysChanged(object sender, EventArgs e) {
			Rebind();
		}

		private class CustomSortKey : GridEXSortKey {
			public CustomSortKey(GridEXColumn column, SortOrder sortOrder) : base(column, sortOrder) {
			}

			public CustomSortKey(GridEXColumn column) : base(column) {
			}

			public CustomSortKey() : base() {
			}

			public CustomSortKey(GridEXSortKey sortKey) {
				this.Column = sortKey.Column;
				this.SortOrder = sortKey.SortOrder;
			}

			public string ColumnCaption {
				get { return this.Column.Caption; }
			}
		}

	}
}