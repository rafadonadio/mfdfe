using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsControls {
	/// <summary>
	/// Summary description for MultiSelectList.
	/// </summary>
	public class MultiSelectList : UserControl {
		public delegate void BindRequired();

		private Panel pnlBox;
		private Button btnExpand;
		private Label lblInfo;
		private Container components = null;

		private FormMultiSelectList formMultiSelectList;
		private bool binded;
		private string multipleItemsSelectedLegend;
		private string noneItemsSelectedLegend;

		public string MultipleItemsSelectedLegend {
			get { return multipleItemsSelectedLegend; }
			set {
				multipleItemsSelectedLegend = value;
				UpdateInfo();
			}
		}

		public string NoneItemsSelectedLegend {
			get { return noneItemsSelectedLegend; }
			set {
				noneItemsSelectedLegend = value;
				UpdateInfo();
			}
		}

		public event BindRequired OnBindRequired;

		public MultiSelectList() {
			InitializeComponent();
			formMultiSelectList = new FormMultiSelectList();
			binded = false;
			MultipleItemsSelectedLegend = "[Varios]";
			NoneItemsSelectedLegend = "[Ninguno]";
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
			this.pnlBox = new System.Windows.Forms.Panel();
			this.btnExpand = new System.Windows.Forms.Button();
			this.lblInfo = new System.Windows.Forms.Label();
			this.pnlBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlBox
			// 
			this.pnlBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlBox.Controls.Add(this.lblInfo);
			this.pnlBox.Controls.Add(this.btnExpand);
			this.pnlBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlBox.Location = new System.Drawing.Point(0, 0);
			this.pnlBox.Name = "pnlBox";
			this.pnlBox.Size = new System.Drawing.Size(96, 21);
			this.pnlBox.TabIndex = 0;
			// 
			// btnExpand
			// 
			this.btnExpand.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnExpand.Location = new System.Drawing.Point(75, 0);
			this.btnExpand.Name = "btnExpand";
			this.btnExpand.Size = new System.Drawing.Size(17, 17);
			this.btnExpand.TabIndex = 0;
			this.btnExpand.Text = "V";
			this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
			// 
			// lblInfo
			// 
			this.lblInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblInfo.Location = new System.Drawing.Point(0, 0);
			this.lblInfo.Name = "lblInfo";
			this.lblInfo.Size = new System.Drawing.Size(75, 17);
			this.lblInfo.TabIndex = 1;
			this.lblInfo.Text = "[Select]";
			this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// MultiSelectList
			// 
			this.Controls.Add(this.pnlBox);
			this.Name = "MultiSelectList";
			this.Size = new System.Drawing.Size(96, 21);
			this.pnlBox.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private void btnExpand_Click(object sender, EventArgs e) {
			if (!binded) OnBindRequired();
			Point p = this.PointToScreen(new Point(0, 0));
			p.Offset(0, this.Height);
			formMultiSelectList.Location = p;
			formMultiSelectList.Width = this.Width;
			formMultiSelectList.ShowDialog();
			UpdateInfo();
		}

		public void Bind(IList list) {
			formMultiSelectList.Bind(list);
			SetBinded();
            UpdateInfo();
		}

        public void Bind(IList list, IList selectedItems) {
            formMultiSelectList.Bind(list, selectedItems);
            SetBinded();
            UpdateInfo();
        }
        
	    public void ClearBinded() {
			binded = false;
			formMultiSelectList.UnBind();
			UpdateInfo();
		}

		public void SetBinded() {
			binded = true;
		}

		public IList SelectedItems {
			get { return formMultiSelectList.SelectedItems; }
		}

		private void UpdateInfo() {
			int count = formMultiSelectList.SelectedItemsCount;
			if (count <= 0) lblInfo.Text = NoneItemsSelectedLegend;
			else if (count == 1) lblInfo.Text = formMultiSelectList.FirstSelectedItem.ToString();
			else lblInfo.Text = MultipleItemsSelectedLegend;
		}
	}
}