using System;
using System.Collections;
using System.Reflection;
using System.Windows.Forms;
using FrameWork.CRUDModel.Windows.UI;
using FrameWork.CRUDModel.Windows.UI.Grid;
using FrameWork.DataBusinessModel;
using FrameWork.DataBusinessModel.BusinessModel;
using FrameWork.DataBusinessModel.DataModel;
using Janus.Windows.GridEX;

namespace FrameWork.CRUDModel.Windows {
	/// <summary>
	/// Summary description for AbstractCRUDController.
	/// </summary>
	public abstract class AbstractCRUDController:IDisposable {
		protected BusinessLogic businessLogic;
		protected ICRUDForm crudForm;
		protected string crudFormTitle;
        protected abstract bool PersistOnCRUDDone { get; }

		public AbstractCRUDController(BusinessLogic businessLogic, string crudFormTitle) {
			this.businessLogic=businessLogic;
			this.crudFormTitle=crudFormTitle;
			this.crudForm=null;
		}

		public abstract Type CRUDFormType { get; }
		public abstract Form CRUDFormParent { get; }
		
		public string CRUDFormTitle {
			get { return crudFormTitle; }
		}

		public BusinessLogic BusinessLogic {
			get { return businessLogic; }
		}

		protected void CreateCRUDForm() {
		    SetBusy();
			if(crudForm!=null) {
				crudForm.Dispose();
				crudForm=null;
			}

			crudForm=(ICRUDForm) Activator.CreateInstance(CRUDFormType);
			
			crudForm.CRUDActionDone += new CRUDActionDone(CRUDActionDone);
			crudForm.UpdateCancelled += new UpdateCancelled(UpdateCancelled);
		    crudForm.PropertyValueListNeeded += new PropertyValueListNeeded(PropertyValueListNeeded);
		    crudForm.LoadFormLayout +=new FormLayoutEvent(LoadFormLayout);
		    crudForm.SaveFormLayout +=new FormLayoutEvent(SaveFormLayout);
			crudForm.Exit += new ExitEvent(ClearCRUDForm);

			crudForm.Title = CRUDFormTitle;
			crudForm.MdiParent = CRUDFormParent;

			AdditionalInitializeCRUDForm(crudForm);
		    ClearBusy();
		}

		protected abstract void AdditionalInitializeCRUDForm(ICRUDForm form);

		protected virtual void InitializeGridForm(IGridForm form) {
		    SetBusy();
			form.LoadLayout += new PersistLayoutEvent(LoadGridLayout);
			form.SaveLayout += new PersistLayoutEvent(SaveGridLayout);
			form.ResetLayout += new ResetLayoutEvent(ResetGridLayout);
            form.LoadFormLayout += new FormLayoutEvent(LoadFormLayout);
            form.SaveFormLayout += new FormLayoutEvent(SaveFormLayout);
		    ClearBusy();
		}

		protected virtual bool ValidateCRUD(CRUDAction action, Persistent persistentObject, ErrorMessages messages) {
		    SetBusy();
			bool result = true;

			if ((action == CRUDAction.Create) || (action == CRUDAction.Update)) {
				if (businessLogic.RequiredFieldsValidator(persistentObject, messages)) {
					if (!businessLogic.BusinessValidator(persistentObject, messages))
						result = false;
				}
				else
					result = false;
			}
		    ClearBusy();
			return result;
		}

		protected virtual bool PersistCRUD(CRUDAction action, Persistent persistentObject, ErrorMessages messages) {
			bool result=true;
		    SetBusy();
			try {
				switch (action) {
					case CRUDAction.Create: result = businessLogic.Save(persistentObject); break;
					case CRUDAction.Retrieve: break;
                    case CRUDAction.Update: result = businessLogic.Update(persistentObject); break;
                    case CRUDAction.Delete: result = businessLogic.Delete(persistentObject); break;
				}
			}
			catch (Exception ex) {
				messages.Add(ex.Message);
				result = false;
			}
		    if(!result && (messages.Count()==0)) messages.Add("Couldn't perform operation.Uknown error");
		    ClearBusy();
			return result;
		}

		protected virtual void RefreshGridAfterCRUD(CRUDAction action) {
		    SetBusy();
			if((action==CRUDAction.Create)||(action==CRUDAction.Delete)) ReloadGrid();
			else if(action==CRUDAction.Update) RefreshGrid();
		    ClearBusy();
		}

		protected virtual bool CRUDActionDone(ICRUDForm form, CRUDAction action, Persistent persistentObject) {
		    SetBusy();
			bool result = ValidateCRUD(action, persistentObject, form.ErrorMessages);
			if(result) {
				if(PersistOnCRUDDone) result=PersistCRUD(action, persistentObject, form.ErrorMessages);
				if(result) RefreshGridAfterCRUD(action);
			}
		    ClearBusy();
			return result;
		}


        protected virtual IList PropertyValueListNeeded(string propertyName, Persistent persistentObject) {
            SetBusy();
            IList result=BusinessLogic.GetPropertyValueList(propertyName, persistentObject);
            ClearBusy();
            return result;
        }
        
	    protected virtual void UpdateCancelled(Persistent persistentObject) {
	        SetBusy();
			BusinessLogic.Evict(persistentObject);
	        ClearBusy();
		}

		protected abstract void ReloadGrid();

		protected abstract void RefreshGrid();

		protected void LoadGridLayout(GridEX grid) {
		    SetBusy();
			if (businessLogic.PersistentType.FullName != "Entities.Repeticiones")
				FormUtils.Instance.GridLayoutManager.Load(grid, new GridLayoutKey(grid, businessLogic.PersistentType));
		    ClearBusy();
		}

		protected void SaveGridLayout(GridEX grid) {
		    SetBusy();
			FormUtils.Instance.GridLayoutManager.Save(grid, new GridLayoutKey(grid, businessLogic.PersistentType));
		    ClearBusy();
		}

		protected void ResetGridLayout(GridEX grid, Type type) {
		    SetBusy();
			FormUtils.Instance.GridLayoutManager.Reset(grid, type);
		    ClearBusy();
		}

        void LoadFormLayout(Form form) {
            FormUtils.Instance.FormLayoutManager.Load(form);
        }

	    void SaveFormLayout(Form form) {
            FormUtils.Instance.FormLayoutManager.Save(form);
        }

		protected void ClearCRUDForm(Form form) {
			if(form==crudForm) {
				crudForm.Dispose();
				crudForm=null;
			}
		}

        Cursor oldCursor=null;
        int busyCount = 0;
	    protected void SetBusy() {
            lock (this) {
                if (busyCount==0) {
                    oldCursor = Cursor.Current;
                    Cursor.Current = Cursors.WaitCursor;
                }
                busyCount++;
            }
	    }
	    
	    protected void ClearBusy() {
            lock (this) {
                busyCount--;
                if (busyCount == 0) {
                    Cursor.Current = oldCursor;
                    oldCursor = null;
                }
            }
	    }
		public abstract void Dispose();
	}
}