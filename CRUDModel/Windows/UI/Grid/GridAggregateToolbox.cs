using System;
using System.ComponentModel;
using System.Windows.Forms;
using Janus.Windows.GridEX;

namespace FrameWork.CRUDModel.Windows.UI.Grid {
	/// <summary>
	/// Summary description for GridAggregateToolbox.
	/// </summary>
	internal class GridAggregateToolbox : UserControl {
		private Label lblAggregateFunction;
		private ComboBox cmbAggregateFunction;
		private Label lblResult;
		private Button btnCalc;
		private Label lblResultLabel;
		private Label lblField;
		private ComboBox cmbField;
		private Container components = null;

		protected GridEX grid;

		public GridAggregateToolbox() {
			InitializeComponent();
			LoadAggregateFunctionCombo();
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
			this.lblAggregateFunction = new System.Windows.Forms.Label();
			this.cmbAggregateFunction = new System.Windows.Forms.ComboBox();
			this.lblResult = new System.Windows.Forms.Label();
			this.btnCalc = new System.Windows.Forms.Button();
			this.lblResultLabel = new System.Windows.Forms.Label();
			this.lblField = new System.Windows.Forms.Label();
			this.cmbField = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// lblAggregateFunction
			// 
			this.lblAggregateFunction.Location = new System.Drawing.Point(24, 8);
			this.lblAggregateFunction.Name = "lblAggregateFunction";
			this.lblAggregateFunction.TabIndex = 13;
			this.lblAggregateFunction.Text = "Función :";
			// 
			// cmbAggregateFunction
			// 
			this.cmbAggregateFunction.Location = new System.Drawing.Point(128, 8);
			this.cmbAggregateFunction.Name = "cmbAggregateFunction";
			this.cmbAggregateFunction.Size = new System.Drawing.Size(168, 21);
			this.cmbAggregateFunction.TabIndex = 7;
			// 
			// lblResult
			// 
			this.lblResult.Location = new System.Drawing.Point(128, 56);
			this.lblResult.Name = "lblResult";
			this.lblResult.Size = new System.Drawing.Size(168, 23);
			this.lblResult.TabIndex = 12;
			// 
			// btnCalc
			// 
			this.btnCalc.Location = new System.Drawing.Point(328, 56);
			this.btnCalc.Name = "btnCalc";
			this.btnCalc.TabIndex = 11;
			this.btnCalc.Text = "Calcular";
			this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
			// 
			// lblResultLabel
			// 
			this.lblResultLabel.Location = new System.Drawing.Point(24, 56);
			this.lblResultLabel.Name = "lblResultLabel";
			this.lblResultLabel.TabIndex = 10;
			this.lblResultLabel.Text = "Resultado :";
			// 
			// lblField
			// 
			this.lblField.Location = new System.Drawing.Point(24, 32);
			this.lblField.Name = "lblField";
			this.lblField.TabIndex = 8;
			this.lblField.Text = "Campo :";
			// 
			// cmbField
			// 
			this.cmbField.Location = new System.Drawing.Point(128, 32);
			this.cmbField.Name = "cmbField";
			this.cmbField.Size = new System.Drawing.Size(168, 21);
			this.cmbField.TabIndex = 9;
			// 
			// GridAggregateToolbox
			// 
			this.Controls.Add(this.lblAggregateFunction);
			this.Controls.Add(this.cmbAggregateFunction);
			this.Controls.Add(this.lblResult);
			this.Controls.Add(this.btnCalc);
			this.Controls.Add(this.lblResultLabel);
			this.Controls.Add(this.lblField);
			this.Controls.Add(this.cmbField);
			this.Name = "GridAggregateToolbox";
			this.Size = new System.Drawing.Size(424, 88);
			this.ResumeLayout(false);

		}

		#endregion

		public GridEX Grid {
			set {
				grid = value;
				Rebind();
			}
		}

		protected void Rebind() {
			cmbField.Items.Clear();
			foreach (GridEXColumn column in grid.RootTable.Columns)
				if (GridUtils.ToColumnType(column.Type) == GridUtils.ColumnType.Numeric)
					cmbField.Items.Add(column);
			cmbField.ValueMember = "Caption";
		}

		private void btnCalc_Click(object sender, EventArgs e) {
			if ((cmbField.SelectedItem == null) || (cmbAggregateFunction.SelectedItem == null)) return;

			lblResult.Text = Convert.ToString(grid.GetTotal(cmbField.SelectedItem as GridEXColumn, (AggregateFunction) cmbAggregateFunction.SelectedItem));
		}

		protected void LoadAggregateFunctionCombo() {
			cmbAggregateFunction.Items.Clear();
			cmbAggregateFunction.Items.Add(AggregateFunction.Average);
			cmbAggregateFunction.Items.Add(AggregateFunction.Count);
			cmbAggregateFunction.Items.Add(AggregateFunction.Max);
			cmbAggregateFunction.Items.Add(AggregateFunction.Min);
			cmbAggregateFunction.Items.Add(AggregateFunction.StdDeviation);
			cmbAggregateFunction.Items.Add(AggregateFunction.Sum);
		}
	}
}