using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Janus.Windows.GridEX;

namespace FrameWork.CRUDModel.Windows.UI.Grid {
	/// <summary>
	/// Summary description for GridCRUDControl.
	/// </summary>
	public class GridCRUDControl : UserControl, IGridControl {
		#region View Class

		private class View : ArrayList, IBindingList {
			public View(ICollection c) : base(c) {
			}

			public View(int capacity) : base(capacity) {
			}

			public View() : base() {
			}

			public void AddIndex(PropertyDescriptor property) {
				// TODO:  Add View.AddIndex implementation
			}

			public bool AllowNew {
				get {
					// TODO:  Add View.AllowNew getter implementation
					return false;
				}
			}

			public void ApplySort(PropertyDescriptor property, ListSortDirection direction) {
				// TODO:  Add View.ApplySort implementation
			}

			public PropertyDescriptor SortProperty {
				get {
					// TODO:  Add View.SortProperty getter implementation
					return null;
				}
			}

			public int Find(PropertyDescriptor property, object key) {
				// TODO:  Add View.Find implementation
				return 0;
			}

			public bool SupportsSorting {
				get {
					// TODO:  Add View.SupportsSorting getter implementation
					return false;
				}
			}

			public bool IsSorted {
				get {
					// TODO:  Add View.IsSorted getter implementation
					return false;
				}
			}

			public bool AllowRemove {
				get {
					// TODO:  Add View.AllowRemove getter implementation
					return false;
				}
			}

			public bool SupportsSearching {
				get {
					// TODO:  Add View.SupportsSearching getter implementation
					return false;
				}
			}

			public ListSortDirection SortDirection {
				get {
					// TODO:  Add View.SortDirection getter implementation
					return new ListSortDirection();
				}
			}

			public event ListChangedEventHandler ListChanged;

			public bool SupportsChangeNotification {
				get {
					// TODO:  Add View.SupportsChangeNotification getter implementation
					return false;
				}
			}

			public void RemoveSort() {
				// TODO:  Add View.RemoveSort implementation
			}

			public object AddNew() {
				// TODO:  Add View.AddNew implementation
				return null;
			}

			public bool AllowEdit {
				get {
					// TODO:  Add View.AllowEdit getter implementation
					return false;
				}
			}

			public void RemoveIndex(PropertyDescriptor property) {
				// TODO:  Add View.RemoveIndex implementation
			}
		}

		#endregion

		private Panel pnlButtons;
		private GridEX grdItems;
		private Button btnCreate;
		private Button btnUpdate;
		private Button btnDelete;
		private Button btnRetrieve;
		private Button btnAction;
		private ImageList imlIcons;
		private IContainer components;

		private IList dataSource;
		private Type itemType;
		private int buttonPadding;
		private ImageList imageList;
		private bool imageListDefault;

		public GridCRUDControl() {
			InitializeComponent();
			ButtonPadding = 8;
			ImageList = this.imlIcons;
			ImageListDefault = true;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GridCRUDControl));
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnAction = new System.Windows.Forms.Button();
            this.imlIcons = new System.Windows.Forms.ImageList(this.components);
            this.btnRetrieve = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.grdItems = new Janus.Windows.GridEX.GridEX();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnAction);
            this.pnlButtons.Controls.Add(this.btnRetrieve);
            this.pnlButtons.Controls.Add(this.btnDelete);
            this.pnlButtons.Controls.Add(this.btnUpdate);
            this.pnlButtons.Controls.Add(this.btnCreate);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(8, 240);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(440, 32);
            this.pnlButtons.TabIndex = 1;
            // 
            // btnAction
            // 
            this.btnAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAction.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAction.ImageList = this.imlIcons;
            this.btnAction.Location = new System.Drawing.Point(352, 8);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(56, 23);
            this.btnAction.TabIndex = 4;
            this.btnAction.Text = "Action";
            this.btnAction.Visible = false;
            this.btnAction.TextChanged += new System.EventHandler(this.Button_TextChanged);
            // 
            // imlIcons
            // 
            this.imlIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlIcons.ImageStream")));
            this.imlIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imlIcons.Images.SetKeyName(0, "");
            this.imlIcons.Images.SetKeyName(1, "");
            this.imlIcons.Images.SetKeyName(2, "");
            this.imlIcons.Images.SetKeyName(3, "");
            // 
            // btnRetrieve
            // 
            this.btnRetrieve.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRetrieve.ImageIndex = 3;
            this.btnRetrieve.ImageList = this.imlIcons;
            this.btnRetrieve.Location = new System.Drawing.Point(232, 8);
            this.btnRetrieve.Name = "btnRetrieve";
            this.btnRetrieve.Size = new System.Drawing.Size(75, 23);
            this.btnRetrieve.TabIndex = 3;
            this.btnRetrieve.Text = "Retrieve";
            this.btnRetrieve.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRetrieve.VisibleChanged += new System.EventHandler(this.Button_VisibleChanged);
            this.btnRetrieve.Click += new System.EventHandler(this.btnRetrieve_Click);
            this.btnRetrieve.TextChanged += new System.EventHandler(this.Button_TextChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.ImageIndex = 2;
            this.btnDelete.ImageList = this.imlIcons;
            this.btnDelete.Location = new System.Drawing.Point(160, 8);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(64, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.VisibleChanged += new System.EventHandler(this.Button_VisibleChanged);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnDelete.TextChanged += new System.EventHandler(this.Button_TextChanged);
            // 
            // btnUpdate
            // 
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.ImageIndex = 1;
            this.btnUpdate.ImageList = this.imlIcons;
            this.btnUpdate.Location = new System.Drawing.Point(80, 8);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(72, 23);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.VisibleChanged += new System.EventHandler(this.Button_VisibleChanged);
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            this.btnUpdate.TextChanged += new System.EventHandler(this.Button_TextChanged);
            // 
            // btnCreate
            // 
            this.btnCreate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreate.ImageIndex = 0;
            this.btnCreate.ImageList = this.imlIcons;
            this.btnCreate.Location = new System.Drawing.Point(8, 8);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(64, 23);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "Create";
            this.btnCreate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCreate.VisibleChanged += new System.EventHandler(this.Button_VisibleChanged);
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            this.btnCreate.TextChanged += new System.EventHandler(this.Button_TextChanged);
            // 
            // grdItems
            // 
            this.grdItems.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdItems.AlternatingColors = true;
            this.grdItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdItems.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.grdItems.GroupByBoxVisible = false;
            this.grdItems.Location = new System.Drawing.Point(8, 8);
            this.grdItems.Name = "grdItems";
            this.grdItems.Size = new System.Drawing.Size(440, 232);
            this.grdItems.TabIndex = 2;
            this.grdItems.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.grdItems.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            this.grdItems.RowDoubleClick += new Janus.Windows.GridEX.RowActionEventHandler(this.grdItems_RowDoubleClick);
            // 
            // GridCRUDControl
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.grdItems);
            this.Controls.Add(this.pnlButtons);
            this.Name = "GridCRUDControl";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Size = new System.Drawing.Size(456, 280);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdItems)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		#region Public Properties

		[Browsable(false)]
		public Type ItemType {
			get { return itemType; }
			set { itemType = value; }
		}

		public int ButtonPadding {
			get { return buttonPadding; }
			set {
				buttonPadding = value;
				ArrangeButtons();
			}
		}

		[Browsable(false)]
		public object SelectedItem {
			get {
				object result = null;
				if (0 <= grdItems.Row) result = grdItems.GetRow(grdItems.Row).DataRow;
				return result;
			}
		}

		public bool AllowColumnDrag {
			get { return grdItems.AllowColumnDrag; }
			set { grdItems.AllowColumnDrag = value; }
		}

		public bool AutomaticSort {
			get { return grdItems.AutomaticSort; }
			set { grdItems.AutomaticSort = value; }
		}

		public bool AlternatingColors {
			get { return grdItems.AlternatingColors; }
			set { grdItems.AlternatingColors = value; }
		}

		public bool CreateButtonVisible {
			get { return btnCreate.Visible; }
			set { btnCreate.Visible = value; }
		}

		public bool UpdateButtonVisible {
			get { return btnUpdate.Visible; }
			set { btnUpdate.Visible = value; }
		}

		public bool DeleteButtonVisible {
			get { return btnDelete.Visible; }
			set { btnDelete.Visible = value; }
		}

		public bool RetrieveButtonVisible {
			get { return btnRetrieve.Visible; }
			set { btnRetrieve.Visible = value; }
		}

		public bool ActionButtonVisible {
			get { return btnAction.Visible; }
			set { btnAction.Visible = value; }
		}

		public bool ButtonsVisible {
			get { return pnlButtons.Visible; }
			set { pnlButtons.Visible = value; }
		}

		public bool ImageListDefault {
			get { return imageListDefault; }
			set {
				if (value) ImageList = imlIcons;
				imageListDefault = value;
			}
		}

		public ImageList ImageList {
			get { return imageList; }
			set {
				if (!ImageListDefault)
					this.btnCreate.ImageList = this.btnUpdate.ImageList = this.btnDelete.ImageList =
						this.btnRetrieve.ImageList = this.btnAction.ImageList = imageList = value;
			}
		}

		public string CreateButtonText {
			get { return btnCreate.Text; }
			set { btnCreate.Text = value; }
		}

		public string UpdateButtonText {
			get { return btnUpdate.Text; }
			set { btnUpdate.Text = value; }
		}

		public string DeleteButtonText {
			get { return btnDelete.Text; }
			set { btnDelete.Text = value; }
		}

		public string RetrieveButtonText {
			get { return btnRetrieve.Text; }
			set { btnRetrieve.Text = value; }
		}

		public string ActionButtonText {
			get { return btnAction.Text; }
			set { btnAction.Text = value; }
		}

		public int CreateButtonImageIndex {
			get { return btnCreate.ImageIndex; }
			set { btnCreate.ImageIndex = value; }
		}

		public int UpdateButtonImageIndex {
			get { return btnUpdate.ImageIndex; }
			set { btnUpdate.ImageIndex = value; }
		}

		public int DeleteButtonImageIndex {
			get { return btnDelete.ImageIndex; }
			set { btnDelete.ImageIndex = value; }
		}

		public int RetrieveButtonImageIndex {
			get { return btnRetrieve.ImageIndex; }
			set { btnRetrieve.ImageIndex = value; }
		}

		public int ActionButtonImageIndex {
			get { return btnAction.ImageIndex; }
			set { btnAction.ImageIndex = value; }
		}

		public event ItemCreateEvent CreateItemRequired;
		public event ObjectEvent UpdateItemRequired , DeleteItemRequired , RetrieveItemRequired;
		public event ResetLayoutEvent ResetLayout;
		public IList DataSource
		{
			get { return dataSource; }
			
		}
		#endregion

		private void Rebind() {
			if (dataSource != null)
				grdItems.DataSource = new View(dataSource);
		}

		#region IGridControl Members

		public void SetDataSource(object dataSource, bool retrieveStructure) {
			if (dataSource is IList) {
				this.dataSource = dataSource as IList;
				Rebind();
			}
			else grdItems.DataSource = dataSource;

			grdItems.Refetch();

			if (retrieveStructure) {
				grdItems.RetrieveStructure();
				if (ResetLayout != null) ResetLayout(grdItems, ItemType);
			}
		}

		public void RefreshDataSource() {
			Rebind();
		}

		#endregion

		#region Private Methods

		private void btnCreate_Click(object sender, EventArgs e) {
			RequireCreate();
		}

		private void btnUpdate_Click(object sender, EventArgs e) {
			RequireUpdate();
		}

		private void btnDelete_Click(object sender, EventArgs e) {
			RequireDelete();
		}

		private void btnRetrieve_Click(object sender, EventArgs e) {
			RequireRetrieve();
		}

		private void RequireCreate() {
			if (CreateItemRequired != null) CreateItemRequired(this.ItemType);
		}

		private void RequireUpdate() {
			if (UpdateItemRequired != null) {
				object obj = SelectedItem;
				if (obj != null) UpdateItemRequired(obj);
			}
		}

		private void RequireDelete() {
			if (DeleteItemRequired != null) {
				object obj = SelectedItem;
				if (obj != null) DeleteItemRequired(obj);
			}

		}

		private void RequireRetrieve() {
			if (RetrieveItemRequired != null) {
				object obj = SelectedItem;
				if (obj != null) RetrieveItemRequired(obj);
			}
		}

		private void grdItems_RowDoubleClick(object sender, RowActionEventArgs e) {
			RequireUpdate();
		}

		private void Button_TextChanged(object sender, EventArgs e) {
			Button button = sender as Button;
			if (button != null) {
				Graphics g = Graphics.FromImage(new Bitmap(1, 1));
				button.Width = (int) (g.MeasureString(button.Text, button.Font).Width + 24);
				g.Dispose();
				g = null;
				ArrangeButtons();
			}
		}

		private void Button_VisibleChanged(object sender, EventArgs e) {
			ArrangeButtons();
		}

		private int NextLeft(Button button) {
			return (button.Left + ((button.Visible ? 1 : 0)*(button.Width + ButtonPadding)));
		}

		private void ArrangeButtons() {
//			btnUpdate.Left = btnCreate.Left + btnCreate.Width + ButtonPadding;
//			btnDelete.Left = btnUpdate.Left + btnUpdate.Width + ButtonPadding;
//			btnRetrieve.Left = btnDelete.Left + btnDelete.Width + ButtonPadding;
			btnUpdate.Left = NextLeft(btnCreate);
			btnDelete.Left = NextLeft(btnUpdate);
			btnRetrieve.Left = NextLeft(btnDelete);

		}

		#endregion
	}

	public delegate void ItemCreateEvent(Type itemType);
}