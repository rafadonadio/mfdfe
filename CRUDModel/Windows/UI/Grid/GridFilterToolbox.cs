using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Janus.Windows.GridEX;

namespace FrameWork.CRUDModel.Windows.UI.Grid {
	/// <summary>
	/// Summary description for GridFilterToolbox.
	/// </summary>
	internal class GridFilterToolbox : UserControl {
		private Button btnSetFilter;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		private GridEX grid;
		private Label lblUsedColumns;
		private Label lblUsedColumnsLabel;
		private Label lblRecordCountLabel;
		private Label lblRecordCount;
		protected GridFilterForm filterForm;

		public GridFilterToolbox() {
			InitializeComponent();
			filterForm = new GridFilterForm();
			filterForm.OnFilterSet += new GridFilterForm.FilterSet(filterForm_OnFilterSet);
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
			this.btnSetFilter = new System.Windows.Forms.Button();
			this.lblUsedColumns = new System.Windows.Forms.Label();
			this.lblUsedColumnsLabel = new System.Windows.Forms.Label();
			this.lblRecordCountLabel = new System.Windows.Forms.Label();
			this.lblRecordCount = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnSetFilter
			// 
			this.btnSetFilter.Location = new System.Drawing.Point(16, 8);
			this.btnSetFilter.Name = "btnSetFilter";
			this.btnSetFilter.TabIndex = 1;
			this.btnSetFilter.Text = "Filtrar";
			this.btnSetFilter.Click += new System.EventHandler(this.btnSetFilter_Click);
			// 
			// lblUsedColumns
			// 
			this.lblUsedColumns.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblUsedColumns.Location = new System.Drawing.Point(176, 8);
			this.lblUsedColumns.Name = "lblUsedColumns";
			this.lblUsedColumns.Size = new System.Drawing.Size(112, 16);
			this.lblUsedColumns.TabIndex = 2;
			this.lblUsedColumns.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblUsedColumnsLabel
			// 
			this.lblUsedColumnsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte) (0)));
			this.lblUsedColumnsLabel.Location = new System.Drawing.Point(104, 8);
			this.lblUsedColumnsLabel.Name = "lblUsedColumnsLabel";
			this.lblUsedColumnsLabel.Size = new System.Drawing.Size(72, 16);
			this.lblUsedColumnsLabel.TabIndex = 3;
			this.lblUsedColumnsLabel.Text = "Filtrado por :";
			this.lblUsedColumnsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblRecordCountLabel
			// 
			this.lblRecordCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte) (0)));
			this.lblRecordCountLabel.Location = new System.Drawing.Point(104, 24);
			this.lblRecordCountLabel.Name = "lblRecordCountLabel";
			this.lblRecordCountLabel.Size = new System.Drawing.Size(72, 16);
			this.lblRecordCountLabel.TabIndex = 4;
			this.lblRecordCountLabel.Text = "Registros :";
			this.lblRecordCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblRecordCount
			// 
			this.lblRecordCount.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblRecordCount.Location = new System.Drawing.Point(176, 24);
			this.lblRecordCount.Name = "lblRecordCount";
			this.lblRecordCount.Size = new System.Drawing.Size(112, 16);
			this.lblRecordCount.TabIndex = 5;
			this.lblRecordCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// GridFilterToolbox
			// 
			this.Controls.Add(this.lblRecordCount);
			this.Controls.Add(this.lblRecordCountLabel);
			this.Controls.Add(this.lblUsedColumnsLabel);
			this.Controls.Add(this.lblUsedColumns);
			this.Controls.Add(this.btnSetFilter);
			this.Name = "GridFilterToolbox";
			this.Size = new System.Drawing.Size(296, 40);
			this.ResumeLayout(false);

		}

		#endregion

		private void btnSetFilter_Click(object sender, EventArgs e) {
			filterForm.EditFilter();
		}

		public GridEX Grid {
			set {
				grid = value;
				filterForm.Grid = grid;
				if (value != null) lblRecordCount.Text = Convert.ToString(value.RecordCount);
			}
		}

		private void filterForm_OnFilterSet(IList usedColumns) {
			lblUsedColumns.Text = "";
			if (usedColumns.Count > 0) {
				if (usedColumns[0] != null) lblUsedColumns.Text += ((GridEXColumn) usedColumns[0]).Caption;
				for (int i = 1; i < usedColumns.Count; i++)
					lblUsedColumns.Text += ", " + ((GridEXColumn) usedColumns[i]).Caption;
			}
			lblRecordCount.Text = Convert.ToString(grid.RecordCount);
		}
	}
}