using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Janus.Windows.GridEX;

namespace FrameWork.CRUDModel.Windows.UI.Grid {
	/// <summary>
	/// Summary description for GridFreezeColumnsToolboxC.
	/// </summary>
	internal class GridFreezeColumnsToolbox : UserControl {
		private Button btnAccept;
		private Button btnDown;
		private Button btnUp;
		private Button btnRemove;
		private Button btnAdd;
		private ListBox lstUsedColumns;
		private ListBox lstAvailableColumns;
		private IContainer components;

		protected GridEX grid;
		protected ArrayList availableColumns, usedColumns;
		private ImageList imlButtons;

		public GridFreezeColumnsToolbox() {
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof (GridFreezeColumnsToolbox));
			this.btnAccept = new System.Windows.Forms.Button();
			this.btnDown = new System.Windows.Forms.Button();
			this.btnUp = new System.Windows.Forms.Button();
			this.btnRemove = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.lstUsedColumns = new System.Windows.Forms.ListBox();
			this.lstAvailableColumns = new System.Windows.Forms.ListBox();
			this.imlButtons = new System.Windows.Forms.ImageList(this.components);
			this.SuspendLayout();
			// 
			// btnAccept
			// 
			this.btnAccept.Location = new System.Drawing.Point(399, 104);
			this.btnAccept.Name = "btnAccept";
			this.btnAccept.TabIndex = 13;
			this.btnAccept.Text = "Aceptar";
			this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
			// 
			// btnDown
			// 
			this.btnDown.ImageIndex = 3;
			this.btnDown.ImageList = this.imlButtons;
			this.btnDown.Location = new System.Drawing.Point(183, 104);
			this.btnDown.Name = "btnDown";
			this.btnDown.Size = new System.Drawing.Size(32, 23);
			this.btnDown.TabIndex = 11;
			this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
			// 
			// btnUp
			// 
			this.btnUp.ImageIndex = 2;
			this.btnUp.ImageList = this.imlButtons;
			this.btnUp.Location = new System.Drawing.Point(183, 72);
			this.btnUp.Name = "btnUp";
			this.btnUp.Size = new System.Drawing.Size(32, 23);
			this.btnUp.TabIndex = 10;
			this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
			// 
			// btnRemove
			// 
			this.btnRemove.ImageIndex = 1;
			this.btnRemove.ImageList = this.imlButtons;
			this.btnRemove.Location = new System.Drawing.Point(183, 40);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(32, 23);
			this.btnRemove.TabIndex = 9;
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.ImageIndex = 0;
			this.btnAdd.ImageList = this.imlButtons;
			this.btnAdd.Location = new System.Drawing.Point(183, 8);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(32, 23);
			this.btnAdd.TabIndex = 8;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// lstUsedColumns
			// 
			this.lstUsedColumns.Location = new System.Drawing.Point(223, 8);
			this.lstUsedColumns.Name = "lstUsedColumns";
			this.lstUsedColumns.Size = new System.Drawing.Size(152, 121);
			this.lstUsedColumns.TabIndex = 12;
			// 
			// lstAvailableColumns
			// 
			this.lstAvailableColumns.Location = new System.Drawing.Point(23, 8);
			this.lstAvailableColumns.Name = "lstAvailableColumns";
			this.lstAvailableColumns.Size = new System.Drawing.Size(152, 121);
			this.lstAvailableColumns.TabIndex = 7;
			// 
			// imlButtons
			// 
			this.imlButtons.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
			this.imlButtons.ImageSize = new System.Drawing.Size(16, 16);
			this.imlButtons.ImageStream = ((System.Windows.Forms.ImageListStreamer) (resources.GetObject("imlButtons.ImageStream")));
			this.imlButtons.TransparentColor = System.Drawing.Color.White;
			// 
			// GridFreezeColumnsToolbox
			// 
			this.Controls.Add(this.btnAccept);
			this.Controls.Add(this.btnDown);
			this.Controls.Add(this.btnUp);
			this.Controls.Add(this.btnRemove);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.lstUsedColumns);
			this.Controls.Add(this.lstAvailableColumns);
			this.Name = "GridFreezeColumnsToolbox";
			this.Size = new System.Drawing.Size(496, 136);
			this.ResumeLayout(false);

		}

		#endregion

		private void btnAdd_Click(object sender, EventArgs e) {
			if (lstAvailableColumns.SelectedItem != null) {
				usedColumns.Add(lstAvailableColumns.SelectedItem);
				availableColumns.Remove(lstAvailableColumns.SelectedItem);
				RebindControls();
			}
		}

		private void btnRemove_Click(object sender, EventArgs e) {
			if (lstUsedColumns.SelectedItem != null) {
				availableColumns.Add(lstUsedColumns.SelectedItem);
				usedColumns.Remove(lstUsedColumns.SelectedItem);
				RebindControls();
			}
		}

		private void btnUp_Click(object sender, EventArgs e) {
			GridEXColumn column = (GridEXColumn) this.lstUsedColumns.SelectedItem;

			if (column != null) {
				int index = usedColumns.IndexOf(column);
				if (index > 0) {
					usedColumns.RemoveAt(index);
					usedColumns.Insert(index - 1, column);
					RebindControls();
					lstUsedColumns.SelectedIndex = index - 1;
				}
			}
		}

		private void btnDown_Click(object sender, EventArgs e) {
			GridEXColumn column = (GridEXColumn) this.lstUsedColumns.SelectedItem;

			if (column != null) {
				int index = usedColumns.IndexOf(column);
				if (index < usedColumns.Count - 1) {
					usedColumns.RemoveAt(index);
					usedColumns.Insert(index + 1, column);
					RebindControls();
					lstUsedColumns.SelectedIndex = index + 1;
				}
			}
		}

		public GridEX Grid {
			set {
				grid = value;
				Rebind();
			}
		}

		public void Rebind() {
			availableColumns = new ArrayList();
			usedColumns = new ArrayList();

			foreach (GridEXColumn column in grid.RootTable.Columns) {
				if (column.Position < grid.FrozenColumns)
					usedColumns.Add(column);
				else
					availableColumns.Add(column);
			}
			RebindControls();
		}

		private void RebindControls() {
			lstAvailableColumns.Items.Clear();
			lstUsedColumns.Items.Clear();
			lstAvailableColumns.ValueMember = lstUsedColumns.ValueMember = "Caption";

			foreach (GridEXColumn column in availableColumns)
				lstAvailableColumns.Items.Add(column);
			foreach (GridEXColumn column in usedColumns)
				lstUsedColumns.Items.Add(column);
		}

		protected void FreezeColumns() {
			grid.FrozenColumns = 0;
			foreach (GridEXColumn column in usedColumns) {
				column.Position = grid.FrozenColumns++;
			}
		}

		private void btnAccept_Click(object sender, EventArgs e) {
			FreezeColumns();
		}
	}
}