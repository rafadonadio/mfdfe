using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Janus.Windows.GridEX;

namespace FrameWork.CRUDModel.Windows.UI.Grid {
    public partial class GridCRUDControlAux : UserControl, IGridControl {
        #region View Class

        private class View : ArrayList, IBindingList {
            public View(ICollection c)
                : base(c) {
            }

            public View(int capacity)
                : base(capacity) {
            }

            public View()
                : base() {
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

        private const int BUTTON_PADDING_DEFAULT = 8;
        private const int IMAGE_PADDING = 15;

        private IList dataSource;
        private Type itemType;
        private int buttonPadding;
        private ActionType actionType;
        
        public GridCRUDControlAux() {
            InitializeComponent();
            ButtonPadding = BUTTON_PADDING_DEFAULT;
            ActionButtonVisible = CreateButtonVisible = RetrieveButtonVisible =
            UpdateButtonVisible = DeleteButtonVisible = ButtonsVisible = true;
            ResizeButtons();
            ArrangeButtons();
            ActionType = Grid.ActionType.Create;
        }

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
                if (0 <= grdData.Row) result = grdData.GetRow(grdData.Row).DataRow;
                return result;
            }
        }

        public bool AllowColumnDrag {
            get { return grdData.AllowColumnDrag; }
            set { grdData.AllowColumnDrag = value; }
        }

        public bool AutomaticSort {
            get { return grdData.AutomaticSort; }
            set { grdData.AutomaticSort = value; }
        }

        public bool AlternatingColors {
            get { return grdData.AlternatingColors; }
            set { grdData.AlternatingColors = value; }
        }

        private bool createButtonVisible, updateButtonVisible, deleteButtonVisible, retrieveButtonVisible, actionButtonVisible, buttonsVisible;
        public bool CreateButtonVisible {
            get { return createButtonVisible; }
            set { createButtonVisible = value; UpdateVisibleProperties(); }
        }

        public bool UpdateButtonVisible {
            get { return updateButtonVisible; }
            set { updateButtonVisible = value; UpdateVisibleProperties(); }
        }

        public bool DeleteButtonVisible {
            get { return deleteButtonVisible; }
            set { deleteButtonVisible = value; UpdateVisibleProperties(); }
        }

        public bool RetrieveButtonVisible {
            get { return retrieveButtonVisible; }
            set { retrieveButtonVisible = value; UpdateVisibleProperties(); }
        }

        public bool ActionButtonVisible {
            get { return actionButtonVisible; }
            set { actionButtonVisible = value; UpdateVisibleProperties(); }
        }

        public bool ButtonsVisible {
            get { return buttonsVisible; }
            set { buttonsVisible = value; UpdateVisibleProperties(); }
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

        public Image CreateButtonImage {
            get { return btnCreate.Image; }
            set { btnCreate.Image = value; }
        }

        public Image UpdateButtonImage {
            get { return btnUpdate.Image; }
            set { btnUpdate.Image = value; }
        }

        public Image DeleteButtonImage {
            get { return btnDelete.Image; }
            set { btnDelete.Image = value; }
        }

        public Image RetrieveButtonImage {
            get { return btnRetrieve.Image; }
            set { btnRetrieve.Image = value; }
        }

        public Image ActionButtonImage {
            get { return btnAction.Image; }
            set { btnAction.Image = value; }
        }

        public ActionType ActionType {
            get { return actionType; }
            set { actionType = value; }
        }

        public event ItemCreateEvent CreateItemRequired, CreateActionRequired;
        public event ObjectEvent UpdateItemRequired , DeleteItemRequired , RetrieveItemRequired, ActionItemRequired;
        public event ResetLayoutEvent ResetLayout;

        #endregion

        #region IGridControl Members

        public void SetDataSource(object dataSource, bool retrieveStructure) {
            if (dataSource is IList) {
                this.dataSource = dataSource as IList;
                Rebind();
            }
            else grdData.DataSource = dataSource;

            grdData.Refetch();

            if (retrieveStructure) {
                grdData.RetrieveStructure();
                if (ResetLayout != null) ResetLayout(grdData, ItemType);
            }
        }

        public void RefreshDataSource() {
            Rebind();
        }

        #endregion

        private void Rebind() {
            if (dataSource != null)
                grdData.DataSource = new View(dataSource);
        }

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

        private void btnAction_Click(object sender, EventArgs e) {
            RequireAction();
        }

        private void RequireCreate() {
            if (CreateItemRequired != null) CreateItemRequired(ItemType);
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
        
        private void RequireAction() {
            if (ActionType == Grid.ActionType.Modify) {
                object obj = SelectedItem;
                if ((obj != null) && (ActionItemRequired != null)) ActionItemRequired(obj);
            }
            else if ((ActionType == Grid.ActionType.Create) && (CreateActionRequired!=null)) CreateActionRequired(ItemType);
        }

        private void grdData_RowDoubleClick(object sender, RowActionEventArgs e) {
            RequireUpdate();
        }

        private void Button_TextChanged(object sender, EventArgs e) {
            ResizeButton(sender as Button);
        }
        
        private void ResizeButton(Button button) {
            if (button != null) {
                Graphics g = Graphics.FromImage(new Bitmap(1, 1));
                button.Width = (int)(g.MeasureString(button.Text, button.Font).Width + IMAGE_PADDING + ((button.Image == null) ? 0 : button.Image.Width));
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
            btnUpdate.Left = NextLeft(btnCreate);
            btnDelete.Left = NextLeft(btnUpdate);
            btnRetrieve.Left = NextLeft(btnDelete);
            btnAction.Left = pnlButtons.Width - btnAction.Width - btnCreate.Left;
        }

        private void ResizeButtons() {
            ResizeButton(btnCreate);
            ResizeButton(btnUpdate);
            ResizeButton(btnDelete);
            ResizeButton(btnRetrieve);
            ResizeButton(btnAction);
        }

        #endregion

        private void GridCRUDControlAux_VisibleChanged(object sender, EventArgs e){
            UpdateVisibleProperties();
        }
        
        private void UpdateVisibleProperties() {
            btnCreate.Visible = Visible && createButtonVisible;
            btnUpdate.Visible = Visible && updateButtonVisible;
            btnDelete.Visible = Visible && deleteButtonVisible;
            btnRetrieve.Visible = Visible && retrieveButtonVisible;
            btnAction.Visible = Visible && actionButtonVisible;
            pnlButtons.Visible = Visible && buttonsVisible;
        }
    }
    public enum ActionType {Create, Modify}
}