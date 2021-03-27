using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsControls {
	/// <summary>
	/// Summary description for FormMultiSelectList.
	/// </summary>
	internal class FormMultiSelectList : Form {
		private CheckedListBox chkMultipleValuesSelect;
		private Panel pnlToolBar;
		private Button btnSelectAll;
		private Button btnSelectNone;
		private Button btnSelectInverse;
		private Button btnAccept;
		private Button btnCancel;
		private Panel pnlControl;
		private Panel pnlList;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		protected bool[] checkedList;
		protected Point originalLocation;

		public FormMultiSelectList() {
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
			this.chkMultipleValuesSelect = new System.Windows.Forms.CheckedListBox();
			this.pnlControl = new System.Windows.Forms.Panel();
			this.btnAccept = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.pnlToolBar = new System.Windows.Forms.Panel();
			this.btnSelectAll = new System.Windows.Forms.Button();
			this.btnSelectInverse = new System.Windows.Forms.Button();
			this.btnSelectNone = new System.Windows.Forms.Button();
			this.pnlList = new System.Windows.Forms.Panel();
			this.pnlControl.SuspendLayout();
			this.pnlToolBar.SuspendLayout();
			this.pnlList.SuspendLayout();
			this.SuspendLayout();
			// 
			// chkMultipleValuesSelect
			// 
			this.chkMultipleValuesSelect.Dock = System.Windows.Forms.DockStyle.Fill;
			this.chkMultipleValuesSelect.Location = new System.Drawing.Point(8, 8);
			this.chkMultipleValuesSelect.Name = "chkMultipleValuesSelect";
			this.chkMultipleValuesSelect.Size = new System.Drawing.Size(160, 64);
			this.chkMultipleValuesSelect.TabIndex = 12;
			// 
			// pnlControl
			// 
			this.pnlControl.Controls.Add(this.btnAccept);
			this.pnlControl.Controls.Add(this.btnCancel);
			this.pnlControl.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlControl.Location = new System.Drawing.Point(0, 112);
			this.pnlControl.Name = "pnlControl";
			this.pnlControl.Size = new System.Drawing.Size(176, 32);
			this.pnlControl.TabIndex = 13;
			// 
			// btnAccept
			// 
			this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnAccept.Location = new System.Drawing.Point(8, 4);
			this.btnAccept.Name = "btnAccept";
			this.btnAccept.TabIndex = 0;
			this.btnAccept.Text = "Aceptar";
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(96, 4);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancelar";
			// 
			// pnlToolBar
			// 
			this.pnlToolBar.Controls.Add(this.btnSelectAll);
			this.pnlToolBar.Controls.Add(this.btnSelectInverse);
			this.pnlToolBar.Controls.Add(this.btnSelectNone);
			this.pnlToolBar.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.pnlToolBar.Location = new System.Drawing.Point(0, 80);
			this.pnlToolBar.Name = "pnlToolBar";
			this.pnlToolBar.Size = new System.Drawing.Size(176, 32);
			this.pnlToolBar.TabIndex = 14;
			// 
			// btnSelectAll
			// 
			this.btnSelectAll.Location = new System.Drawing.Point(16, 4);
			this.btnSelectAll.Name = "btnSelectAll";
			this.btnSelectAll.Size = new System.Drawing.Size(24, 23);
			this.btnSelectAll.TabIndex = 0;
			this.btnSelectAll.Text = "A";
			this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
			// 
			// btnSelectInverse
			// 
			this.btnSelectInverse.Location = new System.Drawing.Point(80, 4);
			this.btnSelectInverse.Name = "btnSelectInverse";
			this.btnSelectInverse.Size = new System.Drawing.Size(24, 23);
			this.btnSelectInverse.TabIndex = 2;
			this.btnSelectInverse.Text = "I";
			this.btnSelectInverse.Click += new System.EventHandler(this.btnSelectInverse_Click);
			// 
			// btnSelectNone
			// 
			this.btnSelectNone.Location = new System.Drawing.Point(48, 4);
			this.btnSelectNone.Name = "btnSelectNone";
			this.btnSelectNone.Size = new System.Drawing.Size(24, 23);
			this.btnSelectNone.TabIndex = 1;
			this.btnSelectNone.Text = "N";
			this.btnSelectNone.Click += new System.EventHandler(this.btnSelectNone_Click);
			// 
			// pnlList
			// 
			this.pnlList.Controls.Add(this.chkMultipleValuesSelect);
			this.pnlList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlList.DockPadding.All = 8;
			this.pnlList.Location = new System.Drawing.Point(0, 0);
			this.pnlList.Name = "pnlList";
			this.pnlList.Size = new System.Drawing.Size(176, 80);
			this.pnlList.TabIndex = 15;
			// 
			// FormMultiSelectList
			// 
			this.AcceptButton = this.btnAccept;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(176, 144);
			this.ControlBox = false;
			this.Controls.Add(this.pnlList);
			this.Controls.Add(this.pnlToolBar);
			this.Controls.Add(this.pnlControl);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(184, 152);
			this.Name = "FormMultiSelectList";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Resize += new System.EventHandler(this.FormMultiSelectList_Resize);
			this.VisibleChanged += new System.EventHandler(this.FormMultiSelectList_VisibleChanged);
			this.pnlControl.ResumeLayout(false);
			this.pnlToolBar.ResumeLayout(false);
			this.pnlList.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		public void Bind(IList list) {
			chkMultipleValuesSelect.DataSource = list;
			checkedList = new bool[chkMultipleValuesSelect.Items.Count];
		}

        public void Bind(IList list, IList selectedItems) {
            chkMultipleValuesSelect.DataSource = list;
            checkedList = new bool[chkMultipleValuesSelect.Items.Count];
            foreach (object item in selectedItems) {
                if(list.Contains(item)) checkedList[list.IndexOf(item)] = true;
            }
            for (int i = 0; i < chkMultipleValuesSelect.Items.Count; i++)
                chkMultipleValuesSelect.SetItemChecked(i, checkedList[i]);
        }

        public void UnBind() {
			chkMultipleValuesSelect.DataSource = null;
		}

		public IList SelectedItems {
			get { return new ArrayList(chkMultipleValuesSelect.CheckedItems); }
		}

		public int SelectedItemsCount {
			get { return chkMultipleValuesSelect.CheckedItems.Count; }
		}

		public object FirstSelectedItem {
			get { return (SelectedItemsCount == 0) ? null : chkMultipleValuesSelect.CheckedItems[0]; }
		}

		private void btnSelectAll_Click(object sender, EventArgs e) {
			for (int i = 0; i < chkMultipleValuesSelect.Items.Count; i++)
				chkMultipleValuesSelect.SetItemChecked(i, true);
		}

		private void btnSelectNone_Click(object sender, EventArgs e) {
			for (int i = 0; i < chkMultipleValuesSelect.Items.Count; i++)
				chkMultipleValuesSelect.SetItemChecked(i, false);
		}

		private void btnSelectInverse_Click(object sender, EventArgs e) {
			for (int i = 0; i < chkMultipleValuesSelect.Items.Count; i++)
				chkMultipleValuesSelect.SetItemChecked(i, !chkMultipleValuesSelect.GetItemChecked(i));
		}

		private void FormMultiSelectList_VisibleChanged(object sender, EventArgs e) {
			if (this.Visible) {
				originalLocation = new Point(Left, Top);
				for (int i = 0; i < chkMultipleValuesSelect.Items.Count; i++)
					chkMultipleValuesSelect.SetItemChecked(i, checkedList[i]);
			}
			else {
				if (this.DialogResult != DialogResult.OK)
					for (int i = 0; i < chkMultipleValuesSelect.Items.Count; i++)
						chkMultipleValuesSelect.SetItemChecked(i, checkedList[i]);
				else
					for (int i = 0; i < chkMultipleValuesSelect.Items.Count; i++)
						checkedList[i] = chkMultipleValuesSelect.GetItemChecked(i);
			}
		}

		private void FormMultiSelectList_Resize(object sender, EventArgs e) {
			if (Visible) this.Location = originalLocation;
		}
	}
}