using System.Windows.Forms;
using FrameWork.CRUDModel.Windows.UI.Grid;

namespace FrameWork.CRUDModel.Windows.UI {
	/// <summary>
	/// Summary description for cFormsFactory.
	/// </summary>
	public class FormUtils {
		public class ControlEnablerClass {
			public ControlEnablerClass() {
			}

			protected void EnableControl(Control control, CRUDAction action) {
                if (!((control is GroupBox) || (control is Panel)))
                {
					control.Enabled = ((action == CRUDAction.Create) || (action == CRUDAction.Update));
				}
			}

			public void Enable(Form form, CRUDAction action) {
				foreach (Control control in form.Controls) {
					EnableControl(control, action);
					Enable(control, action);
				}
				if ((form.AcceptButton != null) && (form.AcceptButton is Control))
					((Control) form.AcceptButton).Enabled = true;
				if ((form.CancelButton != null) && (form.CancelButton is Control))
					((Control) form.CancelButton).Enabled = (action != CRUDAction.Retrieve);
			}

			public void Enable(Control control, CRUDAction action) {
				if (control.Controls.Count > 0) control.Enabled = true;

				foreach (Control childControl in control.Controls) {
					EnableControl(childControl, action);
					Enable(childControl, action);
				}
			}
            public void Enable(Form form, bool enabled)
            {
                foreach (Control control in form.Controls)
                {
                    EnableControl(control, enabled);
                    Enable(control, enabled);
                }
            }

            public void Enable(Control control, bool enabled)
            {
                if ((control.Controls.Count > 0) && !(control is CRUDModel.Windows.UI.Grid.GridCRUDControl)) control.Enabled = true;

                foreach (Control childControl in control.Controls)
                {
                    EnableControl(childControl, enabled);
                    Enable(childControl, enabled);
                }
            }

            protected void EnableControl(Control control, bool enabled)
            {
                if (!((control is GroupBox) || (control is Panel)))
                {
                    control.Enabled = enabled;
                }
            }
        }

		private Form mainForm;
		private IGridLayoutManager gridLayoutManager;
        private IFormLayoutManager formLayoutManager;
		private ControlEnablerClass controlEnabler;

		private FormUtils() {
			controlEnabler = new ControlEnablerClass();
		    SetFormLayoutManager(UI.FormLayoutManager.Instance);
		    SetGridLayoutManager(Grid.GridLayoutManager.Instance);
		}

		private static FormUtils instance = null;

		public static FormUtils Instance {
			get {
				if (instance == null) instance = new FormUtils();
				return instance;
			}
		}

		public void SetMainForm(Form form) {
			mainForm = form;
		}

		public Form MainForm {
			get { return mainForm; }
		}

		public void SetGridLayoutManager(IGridLayoutManager gridLayoutManager) {
			this.gridLayoutManager = gridLayoutManager;
		}

		public IGridLayoutManager GridLayoutManager {
			get { return gridLayoutManager; }
		}
	    
	    public void SetFormLayoutManager(IFormLayoutManager formLayoutManager) {
            this.formLayoutManager = formLayoutManager;
	    }
	    
	    public IFormLayoutManager FormLayoutManager {
            get { return formLayoutManager; }
	    }

		public ControlEnablerClass ControlEnabler {
			get { return controlEnabler; }
		}

	}
}