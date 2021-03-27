using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using Janus.Windows.GridEX.EditControls;

namespace FrameWork.CRUDModel.Windows.UI.Grid {
	/// <summary>
	/// Summary description for GridFindToolbox.
	/// </summary>
	internal class GridFindToolbox : UserControl {
		private Button btnFind;
		private ComboBox cmbFindOperator;
		private TextBox txtTextFindValue;
		private Label lblFindCriteria;
		private Label lblFindValue;
		private DateTimePicker dtpDateTimeFindValue;
		private NumericEditBox txtNumberFindValue;
		private ComboBox cmbFindColumn;
		private Label lblFindColumn;
		private Container components = null;
		private ComboBox cmbFindObjectValue;

		protected GridEX grid;

		public GridFindToolbox() {
			InitializeComponent();
			LoadOperatorCombo();
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
			this.btnFind = new System.Windows.Forms.Button();
			this.cmbFindOperator = new System.Windows.Forms.ComboBox();
			this.txtTextFindValue = new System.Windows.Forms.TextBox();
			this.lblFindCriteria = new System.Windows.Forms.Label();
			this.lblFindValue = new System.Windows.Forms.Label();
			this.dtpDateTimeFindValue = new System.Windows.Forms.DateTimePicker();
			this.txtNumberFindValue = new Janus.Windows.GridEX.EditControls.NumericEditBox();
			this.cmbFindColumn = new System.Windows.Forms.ComboBox();
			this.lblFindColumn = new System.Windows.Forms.Label();
			this.cmbFindObjectValue = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// btnFind
			// 
			this.btnFind.Location = new System.Drawing.Point(376, 72);
			this.btnFind.Name = "btnFind";
			this.btnFind.TabIndex = 23;
			this.btnFind.Text = "Buscar";
			this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
			// 
			// cmbFindOperator
			// 
			this.cmbFindOperator.ItemHeight = 13;
			this.cmbFindOperator.Location = new System.Drawing.Point(128, 40);
			this.cmbFindOperator.Name = "cmbFindOperator";
			this.cmbFindOperator.Size = new System.Drawing.Size(153, 21);
			this.cmbFindOperator.TabIndex = 19;
			// 
			// txtTextFindValue
			// 
			this.txtTextFindValue.Location = new System.Drawing.Point(128, 72);
			this.txtTextFindValue.Name = "txtTextFindValue";
			this.txtTextFindValue.Size = new System.Drawing.Size(216, 20);
			this.txtTextFindValue.TabIndex = 20;
			this.txtTextFindValue.Text = "";
			// 
			// lblFindCriteria
			// 
			this.lblFindCriteria.Location = new System.Drawing.Point(24, 40);
			this.lblFindCriteria.Name = "lblFindCriteria";
			this.lblFindCriteria.TabIndex = 26;
			this.lblFindCriteria.Text = "Criterio :";
			// 
			// lblFindValue
			// 
			this.lblFindValue.Location = new System.Drawing.Point(24, 72);
			this.lblFindValue.Name = "lblFindValue";
			this.lblFindValue.TabIndex = 25;
			this.lblFindValue.Text = "Valor a Buscar :";
			// 
			// dtpDateTimeFindValue
			// 
			this.dtpDateTimeFindValue.Location = new System.Drawing.Point(128, 72);
			this.dtpDateTimeFindValue.Name = "dtpDateTimeFindValue";
			this.dtpDateTimeFindValue.Size = new System.Drawing.Size(216, 20);
			this.dtpDateTimeFindValue.TabIndex = 22;
			this.dtpDateTimeFindValue.Visible = false;
			// 
			// txtNumberFindValue
			// 
			this.txtNumberFindValue.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.txtNumberFindValue.AutoScrollMinSize = new System.Drawing.Size(0, 0);
			this.txtNumberFindValue.Location = new System.Drawing.Point(128, 72);
			this.txtNumberFindValue.Name = "txtNumberFindValue";
			this.txtNumberFindValue.Size = new System.Drawing.Size(216, 20);
			this.txtNumberFindValue.TabIndex = 21;
			this.txtNumberFindValue.Text = "0";
			this.txtNumberFindValue.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near;
			this.txtNumberFindValue.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32;
			// 
			// cmbFindColumn
			// 
			this.cmbFindColumn.Location = new System.Drawing.Point(128, 8);
			this.cmbFindColumn.Name = "cmbFindColumn";
			this.cmbFindColumn.Size = new System.Drawing.Size(216, 21);
			this.cmbFindColumn.TabIndex = 18;
			this.cmbFindColumn.SelectedIndexChanged += new System.EventHandler(this.cmbFindColumn_SelectedIndexChanged);
			// 
			// lblFindColumn
			// 
			this.lblFindColumn.Location = new System.Drawing.Point(24, 8);
			this.lblFindColumn.Name = "lblFindColumn";
			this.lblFindColumn.TabIndex = 24;
			this.lblFindColumn.Text = "Buscar por :";
			this.lblFindColumn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cmbFindObjectValue
			// 
			this.cmbFindObjectValue.Location = new System.Drawing.Point(128, 72);
			this.cmbFindObjectValue.Name = "cmbFindObjectValue";
			this.cmbFindObjectValue.Size = new System.Drawing.Size(216, 21);
			this.cmbFindObjectValue.TabIndex = 27;
			// 
			// GridFindToolbox
			// 
			this.Controls.Add(this.cmbFindObjectValue);
			this.Controls.Add(this.btnFind);
			this.Controls.Add(this.cmbFindOperator);
			this.Controls.Add(this.txtTextFindValue);
			this.Controls.Add(this.lblFindCriteria);
			this.Controls.Add(this.lblFindValue);
			this.Controls.Add(this.dtpDateTimeFindValue);
			this.Controls.Add(this.txtNumberFindValue);
			this.Controls.Add(this.cmbFindColumn);
			this.Controls.Add(this.lblFindColumn);
			this.Name = "GridFindToolbox";
			this.Size = new System.Drawing.Size(472, 104);
			this.ResumeLayout(false);

		}

		#endregion

		public GridEX Grid {
			set {
				if (value != null) {
					grid = value;
					Rebind();
				}
				else {
					grid = null;
				}
			}
		}

		protected void Rebind() {
			//Load the columns
			cmbFindColumn.DataSource = grid.RootTable.Columns;
			cmbFindColumn.ValueMember = "Caption";
			if (grid.RootTable.SortKeys.Count > 0) cmbFindColumn.SelectedItem = grid.RootTable.SortKeys[0].Column;
		}

		protected void LoadOperatorCombo() {
			cmbFindOperator.DataSource = FilterOperatorListItem.Items;
			cmbFindOperator.ValueMember = "Label";
			cmbFindOperator.SelectedItem = null;
		}

		private void cmbFindColumn_SelectedIndexChanged(object sender, EventArgs e) {
			if (cmbFindColumn.SelectedItem != null) {
				GridEXColumn column = (GridEXColumn) cmbFindColumn.SelectedItem;
				GridUtils.ColumnType columnType = GridUtils.ToColumnType(column.Type);
				this.txtTextFindValue.Visible = (columnType == GridUtils.ColumnType.Text);
				this.txtNumberFindValue.Visible = (columnType == GridUtils.ColumnType.Numeric);
				this.dtpDateTimeFindValue.Visible = (columnType == GridUtils.ColumnType.DateTime);
				this.cmbFindObjectValue.Visible = (columnType == GridUtils.ColumnType.DataObject);

				if (columnType == GridUtils.ColumnType.Numeric)
					this.txtNumberFindValue.ValueType = GridUtils.ToNumericEditValueType(column.Type);
				if (columnType == GridUtils.ColumnType.DataObject)
					this.cmbFindObjectValue.DataSource = this.GetMemberList(column.DataMember);
			}
		}

		private void btnFind_Click(object sender, EventArgs e) {
			if ((cmbFindColumn.SelectedItem != null) && (cmbFindOperator.SelectedItem != null)) {
				GridEXFilterCondition condition = new GridEXFilterCondition((GridEXColumn) cmbFindColumn.SelectedItem, ((FilterOperatorListItem) cmbFindOperator.SelectedItem).Operator, GetFindValue());
				grid.Find(condition, -1, 1);
				grid.Focus();
			}
		}

		protected object GetFindValue() {
			object result = null;
			switch (GridUtils.ToColumnType(((GridEXColumn) cmbFindColumn.SelectedItem).Type)) {
				case GridUtils.ColumnType.Text:
					result = this.txtTextFindValue.Text;
					break;
				case GridUtils.ColumnType.Numeric:
					result = this.txtNumberFindValue.Value;
					break;
				case GridUtils.ColumnType.DateTime:
					result = this.dtpDateTimeFindValue.Value;
					break;
				case GridUtils.ColumnType.DataObject:
					result = this.cmbFindObjectValue.SelectedItem;
					break;
			}
			return result;
		}

		protected IList GetMemberList(string dataMember) {
			IList result = new ArrayList();
			if ((this.grid.DataSource is IList) && (((IList) this.grid.DataSource).Count > 0)) {
				Type type = (((IList) this.grid.DataSource)[0]).GetType();
				PropertyInfo member = type.GetProperty(dataMember);
				foreach (Object obj in ((IList) this.grid.DataSource)) {
					Object data = member.GetValue(obj, null);
					if (!result.Contains(data)) result.Add(data);
				}
			}
			return result;
		}
	}
}