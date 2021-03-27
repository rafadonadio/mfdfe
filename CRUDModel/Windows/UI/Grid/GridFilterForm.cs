using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using Janus.Windows.GridEX.EditControls;
using WindowsFormsControls;

namespace FrameWork.CRUDModel.Windows.UI.Grid {
	/// <summary>
	/// Summary description for FormGridFilter.
	/// </summary>
	internal class GridFilterForm : Form {
		private Panel pnlMain;
		private ComboBox cmbColumn;
		private Label lblFilterColumn;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		private RadioButton rbtAnd;
		private RadioButton rbtOr;
		private TreeView trvFilterCondition;
		private Button btnAddCondition;
		private Button btnRemoveCondition;
		private Button btnCleanFilter;
		private Button btnAccept;
		private Button btnCancel;
		private ComboBox cmbFilterOperator;
		private TextBox txtTextFilterValue;
		private Label label2;
		private Label label1;
		private DateTimePicker dtpDateTimeFilterValue;
		private NumericEditBox txtNumberFilterValue;
		private ComboBox cmbFilterObjectValue;
		private TextBox txtFilterCondition2;
		private MultiSelectList multiSelectList;
		private Label label3;
		private GroupBox grbCondition;
		private GroupBox grbLogicalOperator;
		private GroupBox grbMultiSelectList;
		private System.Windows.Forms.TabControl tbcCondition;
		private TabPage tbpCondition;
		private TabPage tbpMultiSelectList;

		public delegate void FilterSet(IList usedColumns);

		public event FilterSet OnFilterSet;

		protected GridEXFilterCondition filterCondition;
		protected bool accepted;
		protected GridUtils.ColumnType columnType;
		protected GridEX grid;
		protected IList usedColumns;
		protected bool comboBinded;

		public GridFilterForm() {
			accepted = false;
			comboBinded = false;
			usedColumns = new ArrayList();

			InitializeComponent();
			this.LoadFilterOperatorCombo();
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
			this.pnlMain = new System.Windows.Forms.Panel();
			this.tbcCondition = new System.Windows.Forms.TabControl();
			this.tbpCondition = new System.Windows.Forms.TabPage();
			this.grbCondition = new System.Windows.Forms.GroupBox();
			this.cmbFilterObjectValue = new System.Windows.Forms.ComboBox();
			this.cmbFilterOperator = new System.Windows.Forms.ComboBox();
			this.txtTextFilterValue = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.dtpDateTimeFilterValue = new System.Windows.Forms.DateTimePicker();
			this.txtNumberFilterValue = new Janus.Windows.GridEX.EditControls.NumericEditBox();
			this.tbpMultiSelectList = new System.Windows.Forms.TabPage();
			this.grbMultiSelectList = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.multiSelectList = new MultiSelectList();
			this.txtFilterCondition2 = new System.Windows.Forms.TextBox();
			this.btnCleanFilter = new System.Windows.Forms.Button();
			this.btnRemoveCondition = new System.Windows.Forms.Button();
			this.btnAddCondition = new System.Windows.Forms.Button();
			this.grbLogicalOperator = new System.Windows.Forms.GroupBox();
			this.rbtOr = new System.Windows.Forms.RadioButton();
			this.rbtAnd = new System.Windows.Forms.RadioButton();
			this.trvFilterCondition = new System.Windows.Forms.TreeView();
			this.cmbColumn = new System.Windows.Forms.ComboBox();
			this.lblFilterColumn = new System.Windows.Forms.Label();
			this.btnAccept = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.pnlMain.SuspendLayout();
			this.tbcCondition.SuspendLayout();
			this.tbpCondition.SuspendLayout();
			this.grbCondition.SuspendLayout();
			this.tbpMultiSelectList.SuspendLayout();
			this.grbMultiSelectList.SuspendLayout();
			this.grbLogicalOperator.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlMain
			// 
			this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
				| System.Windows.Forms.AnchorStyles.Left)
				| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlMain.Controls.Add(this.tbcCondition);
			this.pnlMain.Controls.Add(this.txtFilterCondition2);
			this.pnlMain.Controls.Add(this.btnCleanFilter);
			this.pnlMain.Controls.Add(this.btnRemoveCondition);
			this.pnlMain.Controls.Add(this.btnAddCondition);
			this.pnlMain.Controls.Add(this.grbLogicalOperator);
			this.pnlMain.Controls.Add(this.trvFilterCondition);
			this.pnlMain.Controls.Add(this.cmbColumn);
			this.pnlMain.Controls.Add(this.lblFilterColumn);
			this.pnlMain.Location = new System.Drawing.Point(0, 0);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Size = new System.Drawing.Size(521, 360);
			this.pnlMain.TabIndex = 2;
			// 
			// tbcCondition
			// 
			this.tbcCondition.Controls.Add(this.tbpCondition);
			this.tbcCondition.Controls.Add(this.tbpMultiSelectList);
			this.tbcCondition.Location = new System.Drawing.Point(16, 48);
			this.tbcCondition.Name = "tbcCondition";
			this.tbcCondition.SelectedIndex = 0;
			this.tbcCondition.Size = new System.Drawing.Size(344, 106);
			this.tbcCondition.TabIndex = 1;
			// 
			// tbpCondition
			// 
			this.tbpCondition.Controls.Add(this.grbCondition);
			this.tbpCondition.Location = new System.Drawing.Point(4, 22);
			this.tbpCondition.Name = "tbpCondition";
			this.tbpCondition.Size = new System.Drawing.Size(336, 80);
			this.tbpCondition.TabIndex = 0;
			this.tbpCondition.Text = "Condición";
			// 
			// grbCondition
			// 
			this.grbCondition.Controls.Add(this.cmbFilterObjectValue);
			this.grbCondition.Controls.Add(this.cmbFilterOperator);
			this.grbCondition.Controls.Add(this.txtTextFilterValue);
			this.grbCondition.Controls.Add(this.label2);
			this.grbCondition.Controls.Add(this.label1);
			this.grbCondition.Controls.Add(this.dtpDateTimeFilterValue);
			this.grbCondition.Controls.Add(this.txtNumberFilterValue);
			this.grbCondition.Location = new System.Drawing.Point(0, 0);
			this.grbCondition.Name = "grbCondition";
			this.grbCondition.Size = new System.Drawing.Size(336, 80);
			this.grbCondition.TabIndex = 9;
			this.grbCondition.TabStop = false;
			// 
			// cmbFilterObjectValue
			// 
			this.cmbFilterObjectValue.Location = new System.Drawing.Point(96, 16);
			this.cmbFilterObjectValue.Name = "cmbFilterObjectValue";
			this.cmbFilterObjectValue.Size = new System.Drawing.Size(232, 21);
			this.cmbFilterObjectValue.TabIndex = 2;
			this.cmbFilterObjectValue.DropDown += new System.EventHandler(this.cmbFilterObjectValue_DropDown);
			// 
			// cmbFilterOperator
			// 
			this.cmbFilterOperator.Location = new System.Drawing.Point(96, 49);
			this.cmbFilterOperator.Name = "cmbFilterOperator";
			this.cmbFilterOperator.Size = new System.Drawing.Size(129, 21);
			this.cmbFilterOperator.TabIndex = 6;
			// 
			// txtTextFilterValue
			// 
			this.txtTextFilterValue.Location = new System.Drawing.Point(96, 16);
			this.txtTextFilterValue.Name = "txtTextFilterValue";
			this.txtTextFilterValue.Size = new System.Drawing.Size(232, 20);
			this.txtTextFilterValue.TabIndex = 4;
			this.txtTextFilterValue.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 49);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 23);
			this.label2.TabIndex = 11;
			this.label2.Text = "Criterio :";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 23);
			this.label1.TabIndex = 10;
			this.label1.Text = "Valor a Filtrar :";
			// 
			// dtpDateTimeFilterValue
			// 
			this.dtpDateTimeFilterValue.Location = new System.Drawing.Point(96, 16);
			this.dtpDateTimeFilterValue.Name = "dtpDateTimeFilterValue";
			this.dtpDateTimeFilterValue.Size = new System.Drawing.Size(232, 20);
			this.dtpDateTimeFilterValue.TabIndex = 5;
			this.dtpDateTimeFilterValue.Visible = false;
			// 
			// txtNumberFilterValue
			// 
			this.txtNumberFilterValue.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.txtNumberFilterValue.AutoScrollMinSize = new System.Drawing.Size(0, 0);
			this.txtNumberFilterValue.Location = new System.Drawing.Point(96, 16);
			this.txtNumberFilterValue.Name = "txtNumberFilterValue";
			this.txtNumberFilterValue.Size = new System.Drawing.Size(232, 20);
			this.txtNumberFilterValue.TabIndex = 3;
			this.txtNumberFilterValue.Text = "0";
			this.txtNumberFilterValue.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near;
			this.txtNumberFilterValue.ValueType = Janus.Windows.GridEX.NumericEditValueType.Int32;
			// 
			// tbpMultiSelectList
			// 
			this.tbpMultiSelectList.Controls.Add(this.grbMultiSelectList);
			this.tbpMultiSelectList.Location = new System.Drawing.Point(4, 22);
			this.tbpMultiSelectList.Name = "tbpMultiSelectList";
			this.tbpMultiSelectList.Size = new System.Drawing.Size(336, 80);
			this.tbpMultiSelectList.TabIndex = 1;
			this.tbpMultiSelectList.Text = "Elegir de una Lista";
			// 
			// grbMultiSelectList
			// 
			this.grbMultiSelectList.Controls.Add(this.label3);
			this.grbMultiSelectList.Controls.Add(this.multiSelectList);
			this.grbMultiSelectList.Location = new System.Drawing.Point(0, 0);
			this.grbMultiSelectList.Name = "grbMultiSelectList";
			this.grbMultiSelectList.Size = new System.Drawing.Size(336, 80);
			this.grbMultiSelectList.TabIndex = 12;
			this.grbMultiSelectList.TabStop = false;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 17);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 23);
			this.label3.TabIndex = 15;
			this.label3.Text = "Valores :";
			// 
			// multiSelectList
			// 
			this.multiSelectList.Location = new System.Drawing.Point(96, 16);
			this.multiSelectList.MultipleItemsSelectedLegend = "[Varios]";
			this.multiSelectList.Name = "multiSelectList";
			this.multiSelectList.NoneItemsSelectedLegend = "[Ninguno]";
			this.multiSelectList.Size = new System.Drawing.Size(232, 21);
			this.multiSelectList.TabIndex = 7;
			this.multiSelectList.OnBindRequired += new MultiSelectList.BindRequired(this.BindMultiSelectList);
			// 
			// txtFilterCondition2
			// 
			this.txtFilterCondition2.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtFilterCondition2.Location = new System.Drawing.Point(16, 296);
			this.txtFilterCondition2.Multiline = true;
			this.txtFilterCondition2.Name = "txtFilterCondition2";
			this.txtFilterCondition2.ReadOnly = true;
			this.txtFilterCondition2.Size = new System.Drawing.Size(487, 56);
			this.txtFilterCondition2.TabIndex = 13;
			this.txtFilterCondition2.TabStop = false;
			this.txtFilterCondition2.Text = "";
			// 
			// btnCleanFilter
			// 
			this.btnCleanFilter.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCleanFilter.Location = new System.Drawing.Point(368, 200);
			this.btnCleanFilter.Name = "btnCleanFilter";
			this.btnCleanFilter.Size = new System.Drawing.Size(136, 30);
			this.btnCleanFilter.TabIndex = 12;
			this.btnCleanFilter.Text = "Quitar Todo";
			this.btnCleanFilter.Click += new System.EventHandler(this.btnCleanFilter_Click);
			// 
			// btnRemoveCondition
			// 
			this.btnRemoveCondition.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRemoveCondition.Location = new System.Drawing.Point(368, 160);
			this.btnRemoveCondition.Name = "btnRemoveCondition";
			this.btnRemoveCondition.Size = new System.Drawing.Size(136, 30);
			this.btnRemoveCondition.TabIndex = 11;
			this.btnRemoveCondition.Text = "Quitar";
			this.btnRemoveCondition.Click += new System.EventHandler(this.btnRemoveCondition_Click);
			// 
			// btnAddCondition
			// 
			this.btnAddCondition.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAddCondition.Location = new System.Drawing.Point(368, 120);
			this.btnAddCondition.Name = "btnAddCondition";
			this.btnAddCondition.Size = new System.Drawing.Size(136, 30);
			this.btnAddCondition.TabIndex = 9;
			this.btnAddCondition.Text = "Agregar";
			this.btnAddCondition.Click += new System.EventHandler(this.btnAddCondition_Click);
			// 
			// grbLogicalOperator
			// 
			this.grbLogicalOperator.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.grbLogicalOperator.Controls.Add(this.rbtOr);
			this.grbLogicalOperator.Controls.Add(this.rbtAnd);
			this.grbLogicalOperator.Location = new System.Drawing.Point(368, 70);
			this.grbLogicalOperator.Name = "grbLogicalOperator";
			this.grbLogicalOperator.Size = new System.Drawing.Size(136, 42);
			this.grbLogicalOperator.TabIndex = 8;
			this.grbLogicalOperator.TabStop = false;
			// 
			// rbtOr
			// 
			this.rbtOr.Location = new System.Drawing.Point(88, 16);
			this.rbtOr.Name = "rbtOr";
			this.rbtOr.Size = new System.Drawing.Size(40, 16);
			this.rbtOr.TabIndex = 1;
			this.rbtOr.Text = "OR";
			// 
			// rbtAnd
			// 
			this.rbtAnd.Checked = true;
			this.rbtAnd.Location = new System.Drawing.Point(8, 16);
			this.rbtAnd.Name = "rbtAnd";
			this.rbtAnd.Size = new System.Drawing.Size(56, 16);
			this.rbtAnd.TabIndex = 0;
			this.rbtAnd.TabStop = true;
			this.rbtAnd.Text = "AND";
			// 
			// trvFilterCondition
			// 
			this.trvFilterCondition.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
				| System.Windows.Forms.AnchorStyles.Left)
				| System.Windows.Forms.AnchorStyles.Right)));
			this.trvFilterCondition.ImageIndex = -1;
			this.trvFilterCondition.Location = new System.Drawing.Point(16, 160);
			this.trvFilterCondition.Name = "trvFilterCondition";
			this.trvFilterCondition.SelectedImageIndex = -1;
			this.trvFilterCondition.Size = new System.Drawing.Size(344, 128);
			this.trvFilterCondition.TabIndex = 10;
			// 
			// cmbColumn
			// 
			this.cmbColumn.Location = new System.Drawing.Point(120, 8);
			this.cmbColumn.Name = "cmbColumn";
			this.cmbColumn.Size = new System.Drawing.Size(232, 21);
			this.cmbColumn.TabIndex = 0;
			this.cmbColumn.SelectedIndexChanged += new System.EventHandler(this.cmbColumn_SelectedIndexChanged);
			// 
			// lblFilterColumn
			// 
			this.lblFilterColumn.Location = new System.Drawing.Point(40, 8);
			this.lblFilterColumn.Name = "lblFilterColumn";
			this.lblFilterColumn.Size = new System.Drawing.Size(72, 23);
			this.lblFilterColumn.TabIndex = 2;
			this.lblFilterColumn.Text = "Filtrar por :";
			this.lblFilterColumn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnAccept
			// 
			this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnAccept.Location = new System.Drawing.Point(8, 368);
			this.btnAccept.Name = "btnAccept";
			this.btnAccept.TabIndex = 14;
			this.btnAccept.Text = "Aceptar";
			this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(438, 368);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 15;
			this.btnCancel.Text = "Cancelar";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// GridFilterForm
			// 
			this.AcceptButton = this.btnAccept;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(522, 399);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnAccept);
			this.Controls.Add(this.pnlMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "GridFilterForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Definir Filtro";
			this.pnlMain.ResumeLayout(false);
			this.tbcCondition.ResumeLayout(false);
			this.tbpCondition.ResumeLayout(false);
			this.grbCondition.ResumeLayout(false);
			this.tbpMultiSelectList.ResumeLayout(false);
			this.grbMultiSelectList.ResumeLayout(false);
			this.grbLogicalOperator.ResumeLayout(false);
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

		public IList UsedColumns {
			get { return usedColumns; }
		}

		protected void Rebind() {
			if (grid.RootTable.FilterCondition != null) filterCondition = (GridEXFilterCondition) grid.RootTable.FilterCondition.FilterCondition.Clone();
			else filterCondition = null;

			this.LoadConditionTreeView();
			OnFilterSet(usedColumns);

			this.cmbColumn.DataSource = grid.RootTable.Columns;
			this.cmbColumn.ValueMember = "Caption";
		}

		protected void LoadFilterOperatorCombo() {
			this.cmbFilterOperator.DataSource = FilterOperatorListItem.Items;
			this.cmbFilterOperator.ValueMember = "Label";
		}

		public void EditFilter() {
			this.accepted = false;

			this.Rebind();
			this.ShowDialog();

			if (accepted) {
				grid.RootTable.ApplyFilter(filterCondition);
				OnFilterSet(usedColumns);
			}
		}

		private TreeNode FilterConditionToTreeNode(GridEXFilterCondition condition) {
			TreeNode result = null;

			if (condition != null) {
				result = new TreeNode();
				if (condition.IsComposite) {
					if (condition.Conditions.Count > 1)
						result.Text = condition.Conditions[1].LogicalOperator.ToString();
					else result.Text = condition.Conditions[0].LogicalOperator.ToString();
					foreach (GridEXFilterCondition childCondition in condition.Conditions) {
						TreeNode childNode = FilterConditionToTreeNode(childCondition);
						result.Nodes.Add(childNode);
					}
				}
				else {
					result.Text = GridUtils.FilterConditionToString(condition);
					if (!usedColumns.Contains(condition.Column)) usedColumns.Add(condition.Column);
				}
				result.Tag = condition;
				result.Expand();
			}

			return result;
		}

		private void LoadConditionTreeView() {
			usedColumns.Clear();
			this.trvFilterCondition.Nodes.Clear();
			TreeNode root = FilterConditionToTreeNode(this.filterCondition);
			if (root != null) this.trvFilterCondition.Nodes.Add(root);
			this.txtFilterCondition2.Text = GridUtils.FilterConditionToString(filterCondition);
		}

		private void btnAddCondition_Click(object sender, EventArgs e) {
			if ((cmbColumn.SelectedItem == null) || (cmbFilterOperator.SelectedItem == null)) return;

			if (filterCondition == null) filterCondition = new GridEXFilterCondition();
			LogicalOperator logicalOperator;
			if (this.rbtAnd.Checked) logicalOperator = LogicalOperator.And;
			else logicalOperator = LogicalOperator.Or;

			GridEXFilterCondition cond = null;
			if (tbcCondition.SelectedTab == tbpCondition)
				cond = new GridEXFilterCondition((GridEXColumn) this.cmbColumn.SelectedItem, ((FilterOperatorListItem) this.cmbFilterOperator.SelectedItem).Operator, this.GetFilterValue());
			else if (tbcCondition.SelectedTab == tbpMultiSelectList) {
				IList list = multiSelectList.SelectedItems;

				cond = new GridEXFilterCondition();
				GridEXFilterCondition childCondition;

				cond.AddCondition(new GridEXFilterCondition((GridEXColumn) this.cmbColumn.SelectedItem, ConditionOperator.Equal, list[0]));
				for (int i = 1; i < list.Count; i++) {
					childCondition = new GridEXFilterCondition((GridEXColumn) this.cmbColumn.SelectedItem, ConditionOperator.Equal, list[i]);
					cond.AddCondition(LogicalOperator.Or, childCondition);
				}
			}
			else return;

			if ((this.trvFilterCondition.Nodes.Count > 0) && (this.trvFilterCondition.SelectedNode != null) && (this.trvFilterCondition.SelectedNode.Parent != null)) {
				GridEXFilterCondition parentCondition, siblingCondition, compositeCondition;
				siblingCondition = (GridEXFilterCondition) this.trvFilterCondition.SelectedNode.Tag;
				parentCondition = (GridEXFilterCondition) this.trvFilterCondition.SelectedNode.Parent.Tag;
				if ((parentCondition.Conditions.Count == 1) || (parentCondition.Conditions[1].LogicalOperator == logicalOperator)) {
					parentCondition.AddCondition(logicalOperator, cond);
				}
				else {
					LogicalOperator auxLogicalOperator = parentCondition.Conditions[1].LogicalOperator;
					parentCondition.RemoveCondition(siblingCondition);
					compositeCondition = new GridEXFilterCondition();
					compositeCondition.AddCondition(siblingCondition);
					compositeCondition.AddCondition(logicalOperator, cond);
					parentCondition.AddCondition(auxLogicalOperator, compositeCondition);
				}
			}
			else {
				filterCondition.AddCondition(logicalOperator, cond);
			}
			this.LoadConditionTreeView();
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void btnAccept_Click(object sender, EventArgs e) {
			this.accepted = true;
			this.Close();
		}

		private void btnCleanFilter_Click(object sender, EventArgs e) {
			filterCondition = null;
			this.LoadConditionTreeView();
		}

		private void btnRemoveCondition_Click(object sender, EventArgs e) {
			if (this.trvFilterCondition.SelectedNode != null) {
				GridEXFilterCondition parentCondition, condition;
				condition = (GridEXFilterCondition) this.trvFilterCondition.SelectedNode.Tag;
				if (this.trvFilterCondition.SelectedNode.Parent != null)
					parentCondition = (GridEXFilterCondition) this.trvFilterCondition.SelectedNode.Parent.Tag;
				else
					parentCondition = filterCondition;

				parentCondition.RemoveCondition(condition);
				this.LoadConditionTreeView();
			}
		}

		private void cmbColumn_SelectedIndexChanged(object sender, EventArgs e) {
			if (cmbColumn.SelectedValue != null) {
				GridEXColumn column = (GridEXColumn) cmbColumn.SelectedItem;
				columnType = GridUtils.ToColumnType(column.Type);
				this.txtTextFilterValue.Visible = (columnType == GridUtils.ColumnType.Text);
				this.txtNumberFilterValue.Visible = (columnType == GridUtils.ColumnType.Numeric);
				this.dtpDateTimeFilterValue.Visible = (columnType == GridUtils.ColumnType.DateTime);
				this.cmbFilterObjectValue.Visible = (columnType == GridUtils.ColumnType.DataObject);

				if (columnType == GridUtils.ColumnType.Numeric)
					this.txtNumberFilterValue.ValueType = GridUtils.ToNumericEditValueType(((GridEXColumn) cmbColumn.SelectedItem).Type);
//				if(columnType==GridUtils.ColumnType.DataObject)
//					this.cmbFilterObjectValue.DataSource=this.GetMemberList(column.DataMember);

				comboBinded = false;
				cmbFilterObjectValue.SelectedItem = null;
				multiSelectList.ClearBinded();
			}
		}

		protected object GetFilterValue() {
			object result = null;
			switch (columnType) {
				case GridUtils.ColumnType.Text:
					result = this.txtTextFilterValue.Text;
					break;
				case GridUtils.ColumnType.Numeric:
					result = this.txtNumberFilterValue.Value;
					break;
				case GridUtils.ColumnType.DateTime:
					result = this.dtpDateTimeFilterValue.Value;
					break;
				case GridUtils.ColumnType.DataObject:
					result = this.cmbFilterObjectValue.SelectedItem;
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

		private void BindMultiSelectList() {
			multiSelectList.Bind(GetMemberList(((GridEXColumn) cmbColumn.SelectedItem).DataMember));
		}

		private void cmbFilterObjectValue_DropDown(object sender, EventArgs e) {
			if (!comboBinded) {
				this.cmbFilterObjectValue.DataSource = this.GetMemberList(((GridEXColumn) cmbColumn.SelectedItem).DataMember);
				comboBinded = true;
			}
		}
	}
}