using System.ComponentModel;
using System.Windows.Forms;
using Janus.Windows.GridEX;

namespace FrameWork.CRUDModel.Windows.UI.Grid {
	/// <summary>
	/// Summary description for GridColumnsToolbox.
	/// </summary>
	internal class GridColumnsToolbox : UserControl {
		private GridEX grdColumns;
		private Container components = null;

		protected GridEX grid;

		public GridColumnsToolbox() {
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
			this.grdColumns = new Janus.Windows.GridEX.GridEX();
			((System.ComponentModel.ISupportInitialize) (this.grdColumns)).BeginInit();
			this.SuspendLayout();
			// 
			// grdColumns
			// 
			this.grdColumns.ColumnAutoResize = true;
			this.grdColumns.ColumnHeaders = Janus.Windows.GridEX.InheritableBoolean.False;
			this.grdColumns.ColumnSetHeaders = Janus.Windows.GridEX.InheritableBoolean.False;
			this.grdColumns.GridLines = Janus.Windows.GridEX.GridLines.None;
			this.grdColumns.GroupByBoxVisible = false;
			this.grdColumns.Location = new System.Drawing.Point(16, 8);
			this.grdColumns.Name = "grdColumns";
			this.grdColumns.Size = new System.Drawing.Size(184, 121);
			this.grdColumns.TabIndex = 0;
			this.grdColumns.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
			this.grdColumns.CellValueChanged += new Janus.Windows.GridEX.ColumnActionEventHandler(this.grdColumns_CellValueChanged);
			// 
			// GridColumnsToolbox
			// 
			this.Controls.Add(this.grdColumns);
			this.Name = "GridColumnsToolbox";
			this.Size = new System.Drawing.Size(216, 136);
			((System.ComponentModel.ISupportInitialize) (this.grdColumns)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private void InitializeGridColumns() {
			GridEXColumn newColumn = null;

			this.grdColumns.DataSource = grid.RootTable.Columns;
			this.grdColumns.RetrieveStructure();
			this.grdColumns.RootTable.Columns.Clear();
			newColumn = this.grdColumns.RootTable.Columns.Add("Caption", ColumnType.Text);
			newColumn.EditType = EditType.NoEdit;
			newColumn = this.grdColumns.RootTable.Columns.Add("Visible", ColumnType.CheckBox);
			newColumn.EditType = EditType.CheckBox;
		}

		private void Rebind() {
			InitializeGridColumns();
		}

		private void grdColumns_CellValueChanged(object sender, ColumnActionEventArgs e) {
			grdColumns.UpdateData();
		}

		public GridEX Grid {
			set {
				grid = value;
				if (value != null) {
					Rebind();
				}
			}
		}

	}
}