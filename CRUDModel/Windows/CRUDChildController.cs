using System;
using System.Windows.Forms;
using FrameWork.CRUDModel.Windows.UI;
using FrameWork.DataBusinessModel;
using FrameWork.DataBusinessModel.BusinessModel;
using FrameWork.DataBusinessModel.DataModel;

namespace FrameWork.CRUDModel.Windows {
	/// <summary>
	/// Summary description for CRUDChildController.
	/// </summary>
	public class CRUDChildController : CRUDController {
		protected CRUDForm parentCRUDForm;

		public CRUDChildController(BusinessLogic businessLogic, string crudFormTitle, Type crudFormType) : base(businessLogic, "", crudFormTitle, crudFormType) {
		}

		protected override bool PersistOnCRUDDone {
			get { return false; }
		}

		protected void ShowCRUDForm(CRUDAction action, Persistent persistentParent, Persistent persistent) {
		    SetBusy();
			if (crudForm == null) {
                ErrorMessages msgError = new ErrorMessages();
			    
                if (!CRUDActionAllowed(action, persistentParent, persistent, msgError)) {
                    MessageBox.Show(msgError.GetAllMessages(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
			    
				CreateCRUDForm();

				if (crudForm is CRUDChildForm) (crudForm as CRUDChildForm).Open(action, persistentParent, persistent);
			}
			crudForm.Show();
			crudForm.BringToFront();
		    ClearBusy();
		}

	    protected virtual bool CRUDActionAllowed(CRUDAction action, Persistent persistentParent, Persistent persistent, ErrorMessages messages) {
	        SetBusy();
            bool result = CRUDActionAllowed(action, persistent, messages);
            if ((action == CRUDAction.Create) && !businessLogic.CreateAllowed(persistentParent, messages))
                result = false;
	        ClearBusy();
            return result;
	    }
	    
		public virtual void SetParentCRUDForm(CRUDForm parentCRUDForm) {
			this.parentCRUDForm = parentCRUDForm;
			this.parentCRUDForm.ChildCreateRequired += new ChildCreateEvent(CreateChild);
			this.parentCRUDForm.ChildUpdateRequired += new ChildModifyEvent(UpdateChild);
			this.parentCRUDForm.ChildDeleteRequired += new ChildModifyEvent(DeleteChild);
			this.parentCRUDForm.ChildRetrieveRequired += new ChildModifyEvent(RetrieveChild);
		    this.parentCRUDForm.ChildActionRequired += new ChildModifyEvent(ActionChild);
            this.parentCRUDForm.CreateActionRequired += new ChildCreateEvent(CreateAction);
		}

		protected override void RefreshGrid() {
		    SetBusy();
			parentCRUDForm.RefreshChildGrid(BusinessLogic.PersistentType);
		    ClearBusy();
		}

		protected override void ReloadGrid() {
		    SetBusy();
			parentCRUDForm.RefreshChildGrid(BusinessLogic.PersistentType);
		    ClearBusy();
		}

		protected void CreateChild(Persistent parent, Type childType) {
		    SetBusy();
			if (childType == businessLogic.PersistentType) {
				ShowCRUDForm(CRUDAction.Create, parent, businessLogic.GetNewInstance());
			}
		    ClearBusy();
		}

		protected void RetrieveChild(Persistent parent, Persistent child) {
		    SetBusy();
			if (child.GetType() == businessLogic.PersistentType) {
				ShowCRUDForm(CRUDAction.Retrieve, parent, child);
			}
		    ClearBusy();
		}

		protected void UpdateChild(Persistent parent, Persistent child) {
		    SetBusy();
			if (child.GetType() == businessLogic.PersistentType) {
				ShowCRUDForm(CRUDAction.Update, parent, child);
			}
		    ClearBusy();
		}

		protected void DeleteChild(Persistent parent, Persistent child) {
		    SetBusy();
			if (child.GetType() == businessLogic.PersistentType) {
				ShowCRUDForm(CRUDAction.Delete, parent, child);
			}
		    ClearBusy();
		}

        protected void ActionChild(Persistent parent, Persistent child) {
            SetBusy();
            if (child.GetType() == businessLogic.PersistentType) PerformActionChild(parent, child);
            ClearBusy();
        }

        protected void CreateAction(Persistent parent, Type childType) {
            SetBusy();
            if (childType == businessLogic.PersistentType)  PerformCreateAction(parent);
            ClearBusy();
        }
        
	    protected override void UpdateCancelled(Persistent persistentObject)
        {
		}
	    
	    protected virtual void PerformActionChild(Persistent parent, Persistent child) {
	    }

	    protected virtual void PerformCreateAction(Persistent parent) {
        }

	}
}