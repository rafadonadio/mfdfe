using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using FrameWork.DataBusinessModel;
using FrameWork.DataBusinessModel.DataModel;
using Janus.Windows.GridEX;

namespace FrameWork.CRUDModel.Windows.UI.Grid {
    /// <summary>
    /// Summary description for GridOnLineForm.
    /// </summary>
    public class GridOnLineForm : Form, ICRUDForm, IGridForm {
        private GridEX grdData;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private Container components = null;

        public event PersistLayoutEvent LoadLayout , SaveLayout;
        public event ResetLayoutEvent ResetLayout;
        public event CRUDActionDone CRUDActionDone;
        public event UpdateCancelled UpdateCancelled;
        public event ExitEvent Exit;
        public event PropertyValueListNeeded PropertyValueListNeeded;
        public event CreateObjectEvent CreatePersistent;
        public event FormLayoutEvent LoadFormLayout, SaveFormLayout;

        private ErrorMessages errorMessages;
        private Persistent persistent;
        private ContextMenu mnuGrid;
        private MenuItem mnuGrid_ResetLayout;
        private Type persistentType;
        ////<BugFix>
        private bool bugFix = false;
        ////</BugFix>

        public GridOnLineForm() {
            InitializeComponent();
            errorMessages = new ErrorMessages();
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
            this.grdData = new Janus.Windows.GridEX.GridEX();
            this.mnuGrid = new System.Windows.Forms.ContextMenu();
            this.mnuGrid_ResetLayout = new System.Windows.Forms.MenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.SuspendLayout();
            // 
            // grdData
            // 
            this.grdData.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdData.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdData.AlternatingColors = true;
            this.grdData.ContextMenu = this.mnuGrid;
            this.grdData.DelayEditionOnClick = true;
            this.grdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdData.GridLineStyle = Janus.Windows.GridEX.GridLineStyle.Solid;
            this.grdData.GroupByBoxVisible = false;
            this.grdData.Location = new System.Drawing.Point(4, 4);
            this.grdData.Name = "grdData";
            this.grdData.Size = new System.Drawing.Size(284, 265);
            this.grdData.TabIndex = 0;
            this.grdData.TabKeyBehavior = Janus.Windows.GridEX.TabKeyBehavior.ControlNavigation;
            this.grdData.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            this.grdData.DeletingRecords += new System.ComponentModel.CancelEventHandler(this.grdData_DeletingRecords);
            this.grdData.UpdatingRecord += new System.ComponentModel.CancelEventHandler(this.grdData_UpdatingRecord);
            this.grdData.GetNewRow += new Janus.Windows.GridEX.GetNewRowEventHandler(this.grdData_GetNewRow);
            this.grdData.RecordUpdated += new System.EventHandler(this.grdData_RecordUpdated);
            this.grdData.RecordAdded += new System.EventHandler(this.grdData_RecordAdded);
            // 
            // mnuGrid
            // 
            this.mnuGrid.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuGrid_ResetLayout});
            // 
            // mnuGrid_ResetLayout
            // 
            this.mnuGrid_ResetLayout.Index = 0;
            this.mnuGrid_ResetLayout.Text = "Reset Layout";
            this.mnuGrid_ResetLayout.Click += new System.EventHandler(this.mnuGrid_ResetLayout_Click);
            // 
            // GridOnLineForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.grdData);
            this.Name = "GridOnLineForm";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.ShowInTaskbar = false;
            this.Text = "GridOnLineForm";
            this.Closed += new System.EventHandler(this.GridOnLineForm_Closed);
            this.Load += new System.EventHandler(this.GridOnLineForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private object SelectedItem {
            get {
                object result = null;
                if (grdData.SelectedItems.Count > 0) result = grdData.SelectedItems[0].GetRow().DataRow;
                return result;
            }
        }

        private void RequireLayoutLoad() {
            if (LoadLayout != null)
                LoadLayout(grdData);
        }

        private void RequireLayoutSave() {
            if (SaveLayout != null)
                SaveLayout(grdData);
        }

        private void RequireLayoutReset(Type type) {
            if (ResetLayout != null)
                ResetLayout(grdData, type);
        }

        private bool RequireCRUDActionDone(CRUDAction action, Persistent persistent) {
            bool result = false;
            if (CRUDActionDone != null)
                result = CRUDActionDone(this, action, persistent);
            return result;
        }

        private Persistent RequireCreatePersistent() {
            Persistent result = null;
            if (CreatePersistent != null) result = CreatePersistent();
            return result;
        }

        private void RequireUpdateCancelled(Persistent persistent) {
            if (UpdateCancelled != null) UpdateCancelled(persistent);
        }


        private void RequireLoadFormLayout() {
            if (LoadFormLayout != null) LoadFormLayout(this);
        }

        private void RequireSaveFormLayout() {
            if (SaveFormLayout != null) SaveFormLayout(this);
        }

        public void SetDataSource(object dataSource, bool retrieveStructure) {
            grdData.DataSource = dataSource;
            grdData.Refetch();

            if (retrieveStructure)
                grdData.RetrieveStructure();
            ////<BugFix>
            ////TODO: esto es para salvar el error de la Janus que no hace la asignación de los campos al objeto cuando el DataSource está vacio
            if ((grdData.RecordCount == 0) && (grdData.DataSource is IList)) {
                bugFix = true;
                (grdData.DataSource as IList).Add(RequireCreatePersistent());
            }
            ////</BugFix>
        }

        public void RefreshDataSource() {
            grdData.Refresh();
        }

        public void SetDataSource(object dataSource) {
            SetDataSource(dataSource, false);
        }

        ////<BugFix>
        ////TODO: esto es para salvar el error de la Janus que no hace la asignación de los campos al objeto cuando el DataSource está vacio
        private void SetBugFixFilter() {
            if (bugFix)
                grdData.RootTable.ApplyFilter(new GridEXFilterCondition(grdData.RootTable.Columns[0], ConditionOperator.NotEqual, 0));
        }
        ////</BugFix>

        public void SetLayout(Type persistentType)
        {
            this.persistentType = persistentType;
            RequireLayoutReset(persistentType);
            RequireLayoutLoad();
            ////<BugFix>
            ////TODO: esto es para salvar el error de la Janus que no hace la asignación de los campos al objeto cuando el DataSource está vacio
            SetBugFixFilter();
            ////</BugFix>
        }

        private void GridOnLineForm_Closed(object sender, EventArgs e) {
            RequireLayoutSave();
            RequireSaveFormLayout();
            if (Exit != null) Exit(this);
        }

        private void grdData_GetNewRow(object sender, GetNewRowEventArgs e) {
            e.NewRow = persistent = RequireCreatePersistent();
        }

        private void grdData_DeletingRecords(object sender, CancelEventArgs e) {
            persistent = (Persistent) SelectedItem;
            if (Messages.SureToDelete() == DialogResult.Yes) {
                if (!RequireCRUDActionDone(CRUDAction.Delete, persistent)) {
                    ShowErrorMessages();
                    e.Cancel = true;
                }
            }
            else e.Cancel = true;
        }

        private void grdData_RecordAdded(object sender, EventArgs e) {
            if (!RequireCRUDActionDone(CRUDAction.Create, persistent)) {
                ShowErrorMessages();
                RequireUpdateCancelled(persistent);
            }
        }

        private void grdData_RecordUpdated(object sender, EventArgs e) {
            if (!RequireCRUDActionDone(CRUDAction.Update, persistent)) {
                ShowErrorMessages();
                RequireUpdateCancelled(persistent);
            }
        }

        [Browsable(false)]
        protected virtual Messages Messages {
            get { return Messages.Instance; }
        }

        private void ShowErrorMessages() {
            MessageBox.Show(ErrorMessages.GetAllMessages(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public ErrorMessages ErrorMessages {
            get { return errorMessages; }
        }


        private void grdData_UpdatingRecord(object sender, CancelEventArgs e) {
            persistent = (Persistent) SelectedItem;
        }

        private void mnuGrid_ResetLayout_Click(object sender, EventArgs e) {
            RequireLayoutReset(persistentType);
        }

        public string Title {
            get { return Text; }
            set { Text = value; }
        }

        private void GridOnLineForm_Load(object sender, EventArgs e) {
            RequireLoadFormLayout();
        }


        public void ShowModal()
        {
            base.ShowDialog();
        }
    }

    public delegate Persistent CreateObjectEvent();
}