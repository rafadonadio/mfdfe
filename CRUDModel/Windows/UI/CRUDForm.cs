using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using FrameWork.CRUDModel.Windows.UI.Grid;
using FrameWork.DataBusinessModel;
using FrameWork.DataBusinessModel.DataModel;
using Janus.Windows.GridEX;

namespace FrameWork.CRUDModel.Windows.UI {
	public delegate void FillGrid();

	/// <summary>
	/// Formulario básico 
	/// </summary>
	public class CRUDForm : Form, ICRUDForm {
		public event CRUDActionDone CRUDActionDone;
		public event UpdateCancelled UpdateCancelled;
		public event ExitEvent Exit;
	    public event PropertyValueListNeeded PropertyValueListNeeded;
	    public event ChildCreateEvent ChildCreateRequired, CreateActionRequired;
		public event ChildModifyEvent ChildUpdateRequired , ChildDeleteRequired , ChildRetrieveRequired, ChildActionRequired;
		public event ResetLayoutEvent ChildGridResetLayout;
		public event RelSelEvent RelSelRequired;
		public event FormLayoutEvent LoadFormLayout, SaveFormLayout;

		protected CRUDAction action;
		protected Persistent persistent;
		protected ErrorMessages errorMessages;
		private bool accepted;
	    protected bool persistentChanged;
        protected bool refreshingControls;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		public CRUDForm() {
			InitializeComponent();
			errorMessages = new ErrorMessages();
			persistentChanged = accepted = false;
		}

		//TODO: quizas no es necesario y se puede borrar
		public void SetParameters(string title, Persistent parentPersistent) {
			Title = title;

			Persistent.Parent = parentPersistent;

			Refresh();
			LoadGrids();
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
			// 
			// CRUDForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(424, 173);
			this.Name = "CRUDForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "CRUDForm";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.CRUDForm_Closing);
			this.Closed += new System.EventHandler(this.CRUDForm_Closed);

		}

		#endregion

		public virtual void EnableControls() {
			FormUtils.Instance.ControlEnabler.Enable(this, action);
		}

		protected virtual void FillObject() {
			persistentChanged = true;
		}

		protected virtual void FillControls() {
		}

		protected virtual void RefreshControls() {
		}

		public virtual void RefreshChildGrid(Type childType) {
			persistentChanged = true;
		}


		protected void CRUDForm_Closed(object sender, EventArgs e) {
			if (Exit != null) Exit(this);
			RequireUpdateCancelled();
		    RequireSaveLayout();
		}

		protected virtual bool AcceptForm() {
			bool result = true;

			if ((action == CRUDAction.Delete) && (Messages.SureToDelete() != DialogResult.Yes)) result = false;

			if (result) {
				if ((action == CRUDAction.Create) || (action == CRUDAction.Update) || (action == CRUDAction.Delete)) FillObject();
				if (!CRUDActionDone(this, action, persistent)) {
					result = false;
					MessageBox.Show(ErrorMessages.GetAllMessages(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else accepted = true;
			}
			return result;
		}

		protected virtual void LoadGrids() {
		}

		[Browsable(false)]
		public virtual Persistent Persistent {
			get { return persistent; }
			set { persistent = value; }
		}

		[Browsable(false)]
		public string Title {
			get { return Text; }
			set { Text = value; }
		}

		[Browsable(false)]
		protected virtual Messages Messages {
			get { return Messages.Instance; }
		}

		[Browsable(false)]
		public ErrorMessages ErrorMessages {
			get { return errorMessages; }
		}

		public void Open(CRUDAction action, Persistent persistent) {
			this.action = action;
			Persistent = persistent;
		    
            refreshingControls = true;
			RefreshControls();

		    Show();
            RequireLoadLayout();
		    
            FillControls();
            refreshingControls = false;
            EnableControls();
		}
        public virtual void SetPersistentChanged() {
            persistentChanged = true;
        }

		private void CRUDForm_Closing(object sender, CancelEventArgs e) {
            SetPersistentChanged();
            if ((action != CRUDAction.Delete) && (action != CRUDAction.Retrieve) && persistentChanged)
				switch (Messages.SaveBeforeExit()) {
					case DialogResult.Yes:
						if (!AcceptForm()) e.Cancel = true;
						break;

					case DialogResult.Cancel:
						e.Cancel = true;
						break;
				}
		}

		protected void RequireChildCreate(Type childType) {
			if (ChildCreateRequired != null) {
			    FillObject();
			    ChildCreateRequired(Persistent, childType);
			}
		}

		protected void RequireChildUpdate(Persistent child) {
			if (ChildUpdateRequired != null) {
                FillObject();
			    ChildUpdateRequired(Persistent, child);
			}
		}

		protected void RequireChildDelete(Persistent child) {
			if (ChildDeleteRequired != null) {
			    FillObject();
			    ChildDeleteRequired(Persistent, child);
			}
		}

		protected void RequireChildRetrieve(Persistent child) {
			if (ChildRetrieveRequired != null) ChildRetrieveRequired(Persistent, child);
		}

        protected void RequireChildAction(Persistent child) {
            if (ChildActionRequired != null) {
                FillObject();
                ChildActionRequired(Persistent, child);
            }
        }

        protected void RequireCreateAction(Type childType) {
            if (CreateActionRequired != null) {
                FillObject();
                CreateActionRequired(Persistent, childType);
            }
        }

	    protected void RequireChildGridResetLayout(GridEX grid, Type type) {
			if (ChildGridResetLayout != null) ChildGridResetLayout(grid, type);
		}

		protected void RequireUpdateCancelled() {
			if (persistentChanged && !accepted)
				CancelUpdate();
		}
		protected void RequireGridSel(DataCombo dc, Type dataType)
		{
			//FillObject();
			if (RelSelRequired != null)
				RelSelRequired(dc, dataType, Persistent);
		}
		

		

		protected virtual void CancelUpdate() {
			if ((UpdateCancelled != null) && (action == CRUDAction.Update)) UpdateCancelled(Persistent);
		}

        protected virtual IList RequirePropertyValueList(string propertyName)
        {
            IList result = null;
            if (PropertyValueListNeeded != null) {
                if(!refreshingControls) FillObject();
                result = PropertyValueListNeeded(propertyName, Persistent);
            }
            return result;
        }
	    
	    protected void RequireLoadLayout() {
            if (LoadFormLayout != null) LoadFormLayout(this);
	    }

        protected void RequireSaveLayout() {
            if (SaveFormLayout != null) SaveFormLayout(this);
        }
	    
	    /// <summary>
	    /// Allows to simulate Tab Key Behaviour
	    /// </summary>
        protected void SimulateTabNavigation() {
            Control control;
            do {
                control = GetNextControl(ActiveControl, true);
                if (control != null) control.Focus();
            } while ((control != null) && (!control.TabStop));
        }


    }

	public delegate void ChildCreateEvent(Persistent parent, Type childType);

	public delegate void ChildModifyEvent(Persistent parent, Persistent child);

	public delegate void RelSelEvent(DataCombo dc, Type relType, Persistent parent);
}