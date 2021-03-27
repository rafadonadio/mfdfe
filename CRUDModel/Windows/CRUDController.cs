using System;
using Security;
using System.Collections;
using System.Windows.Forms;
using FrameWork.CRUDModel.Windows.UI;
using FrameWork.CRUDModel.Windows.UI.Grid;
using FrameWork.DataBusinessModel.BusinessModel;
using FrameWork.DataBusinessModel.DataModel;
using FrameWork.DataBusinessModel;

namespace FrameWork.CRUDModel.Windows {
	/// <summary>
	/// Summary description for CRUDController.
	/// </summary>
	public class CRUDController : AbstractCRUDController {
		protected GridForm gridForm;
		protected Type crudFormType;
		protected IList childControllers;
        protected IList selControllers;
        protected bool isSelectGrid = false;
        protected CRUDSelController parentController;
        private bool repeatCreate=false;
		public string GridTitle {
			get { return gridForm.Title; }
		}

		public override Type CRUDFormType {
			get { return crudFormType; }
		}
        
        public bool IsSelectGrid
        {
            get { return isSelectGrid; }
            set { isSelectGrid = value ; }
        }
		
	    public CRUDController(BusinessLogic businessLogic, string gridTitle, string crudFormTitle, Type crudFormType):this(businessLogic, gridTitle , crudFormTitle , crudFormType, false) {
		}
	    
        public CRUDController(BusinessLogic businessLogic, string gridTitle, string crudFormTitle, Type crudFormType, bool repeatCreate):base(businessLogic, crudFormTitle) {
			childControllers = new ArrayList();
            selControllers = new ArrayList();
			
            gridForm = new GridForm();
			InitializeGridForm(gridForm);
			gridForm.CreateObject += new NonObjectEvent(CreateObject);
			gridForm.RetrieveObject += new ObjectEvent(RetrieveObject);
			gridForm.UpdateObject += new ObjectEvent(UpdateObject);
			gridForm.DeleteObject += new ObjectEvent(DeleteObject);
            gridForm.SelectObject += new ObjectEvent(SelectObject);
            gridForm.Reload += new NonObjectEvent(ReloadGrid);
			gridForm.Exit += new ExitEvent(gridForm_Exit);
			gridForm.Title = gridTitle;
			gridForm.MdiParent = CRUDFormParent;

			this.crudFormType = crudFormType;
            this.repeatCreate = repeatCreate;
			gridForm.SetDataSource(businessLogic.GetDataSource(), true);
			gridForm.SetLayout(businessLogic.PersistentType);
		}

	    public CRUDController(BusinessLogic businessLogic, string crudFormTitle, Type crudFormType):this(businessLogic, crudFormTitle, crudFormType, false) {
	    }
		public CRUDController(BusinessLogic businessLogic, string crudFormTitle, Type crudFormType, bool repeatCreate):base(businessLogic, crudFormTitle) {
			childControllers = new ArrayList();

			gridForm = null;
			this.crudFormType = crudFormType;
            this.repeatCreate = repeatCreate;
		}

	    public CRUDController(BusinessLogic businessLogic, string gridTitle, string crudFormTitle, Type crudFormType, CRUDSelController parentController):this(businessLogic, gridTitle, crudFormTitle, crudFormType, parentController, false) {
	    }
        public CRUDController(BusinessLogic businessLogic, string gridTitle, string crudFormTitle, Type crudFormType, CRUDSelController parentController, bool repeatCreate):base(businessLogic, crudFormTitle) {
			childControllers = new ArrayList();
            selControllers = new ArrayList();
            this.parentController = parentController;
            isSelectGrid = true;
			
            gridForm = new GridForm();
			InitializeGridForm(gridForm);
			gridForm.CreateObject += new NonObjectEvent(CreateObject);
			gridForm.RetrieveObject += new ObjectEvent(RetrieveObject);
			gridForm.UpdateObject += new ObjectEvent(UpdateObject);
			gridForm.DeleteObject += new ObjectEvent(DeleteObject);
            gridForm.SelectObject += new ObjectEvent(SelectObject);
            gridForm.Reload += new NonObjectEvent(ReloadGrid);
			gridForm.Exit += new ExitEvent(gridForm_Exit);
			gridForm.Title = gridTitle;
			gridForm.MdiParent = CRUDFormParent;

			this.crudFormType = crudFormType;
            this.repeatCreate = repeatCreate;
			gridForm.SetDataSource(businessLogic.GetDataSource(), true); 
			gridForm.SetLayout(businessLogic.PersistentType);
			//gridForm.SetFilter("Inscripto");
			
			//
			
		}
        
        public void AddChildController(CRUDChildController childController) {
			childControllers.Add(childController);
		}
        public void AddSelController(CRUDSelController selController)
        {
            selControllers.Add(selController);
        }

		public void ShowGrid() {
		    SetBusy();
			if (gridForm != null) {
                if ((IsSelectGrid)||(CRUDControllerManager.Instance.GetCRUDSecurityManager().HavePermissions(businessLogic.GetModule() as Modules, CRUDAction.Retrieve)))
                {
                    gridForm.Show();
                    gridForm.BringToFront();
                }
			}
		    ClearBusy();
		}

        public void ShowGrid(string filter) {
            SetBusy();
            if (gridForm != null) {
                gridForm.SetFilter(filter);
                ShowGrid();
            }
            ClearBusy();
        }

        public void HideGrid() {
			if (gridForm != null) 
				gridForm.Hide();
        }

		protected override bool PersistOnCRUDDone {
			get { return true; }
		}

		public override Form CRUDFormParent {
			get { return FormUtils.Instance.MainForm; }
		}

		protected override void AdditionalInitializeCRUDForm(ICRUDForm form) {
			//form.CRUDActionDone += new CRUDActionDone(CRUDActionDone);
			//form.UpdateCancelled += new UpdateCancelled(UpdateCancelled);
		    form.Exit += new ExitEvent(crudForm_Exit);
			if(form is CRUDForm) (form as CRUDForm).ChildGridResetLayout += new ResetLayoutEvent(ResetGridLayout);

			foreach (CRUDChildController childController in childControllers)
				childController.SetParentCRUDForm(form as CRUDForm);

            foreach (CRUDSelController selController in selControllers)
                selController.SetParentCRUDForm(form as CRUDForm);
        }

		protected override void ReloadGrid() {
		    SetBusy();
		    //si se cierra la grilla al salir del form CRUD se rompe
		    if(gridForm!=null)
			    gridForm.SetDataSource(businessLogic.GetDataSource());
		    ClearBusy();
		}

		protected override void RefreshGrid() {
		    SetBusy();
			gridForm.RefreshDataSource();
		    ClearBusy();
		}
	    
        private CRUDAction lastAction;
        private bool CRUDSuccedeed = false;

		public void ShowCRUDForm(CRUDAction action, Persistent persistent) {
		    SetBusy();
            ErrorMessages msgError = new ErrorMessages ();

            if (crudForm == null) {
                lastAction = action;
                if (!CRUDActionAllowed(action, persistent, msgError)) {
                    MessageBox.Show(msgError.GetAllMessages(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                CreateCRUDForm();

				businessLogic.Refresh(persistent);
				if(crudForm is CRUDForm) (crudForm as CRUDForm).Open(action, persistent);
			}
            CRUDSuccedeed = false;
            crudForm.Show();
			crudForm.BringToFront();
		    ClearBusy();
		}
	    
	    protected virtual bool CRUDActionAllowed(CRUDAction action, Persistent persistent, ErrorMessages messages) {
	        SetBusy();
            bool result = true;
            switch (action) {
                case CRUDAction.Create:
                    if (!businessLogic.CreateAllowed(messages)) result = false;
                    break;
                case CRUDAction.Delete:
                    if (!businessLogic.DeleteAllowed(persistent, messages)) result = false;
                    break;
                case CRUDAction.Retrieve:
                    if (!businessLogic.RetrieveAllowed(persistent, messages)) result = false;
                    break;
                case CRUDAction.Update:
                    if (!businessLogic.UpdateAllowed(persistent, messages)) result = false;
                    break;
            }
	        ClearBusy();
            return result;
	    }
	    
        public void ShowCRUDForm() {
            SetBusy();
            CRUDAction action = CRUDAction.Create;
            Persistent persistent = businessLogic.GetNewInstance();

            ShowCRUDForm(action, persistent);
            ClearBusy();
        }

		protected virtual void CreateObject() {
		    SetBusy();
            if (CRUDControllerManager.Instance.GetCRUDSecurityManager() != null) {
                if(CRUDControllerManager.Instance.GetCRUDSecurityManager().HavePermissions(businessLogic.GetModule() as Modules, CRUDAction.Create))
                    ShowCRUDForm(CRUDAction.Create, businessLogic.GetNewInstance());
            }
            else
                ShowCRUDForm(CRUDAction.Create, businessLogic.GetNewInstance());
		    ClearBusy();
		}

		protected virtual void RetrieveObject(Object obj) {
		    SetBusy();
            if (CRUDControllerManager.Instance.GetCRUDSecurityManager() != null) {
                if (CRUDControllerManager.Instance.GetCRUDSecurityManager().HavePermissions(businessLogic.GetModule() as Modules, CRUDAction.Retrieve ))
                    ShowCRUDForm(CRUDAction.Retrieve, (Persistent)obj);
            }
            else 
                ShowCRUDForm(CRUDAction.Retrieve, (Persistent)obj);
		    ClearBusy();
		}

        protected virtual void UpdateObject(Object obj) {
            SetBusy();
            if (CRUDControllerManager.Instance.GetCRUDSecurityManager() != null) {
                if (CRUDControllerManager.Instance.GetCRUDSecurityManager().HavePermissions(businessLogic.GetModule() as Modules, CRUDAction.Update ))
                    ShowCRUDForm(CRUDAction.Update, (Persistent)obj);
            }
            else 
                ShowCRUDForm(CRUDAction.Update, (Persistent)obj);
            ClearBusy();
        }
        
        protected virtual void SelectObject(Object obj) {
            SetBusy();
            if (IsSelectGrid)
                parentController.SetValueSel((Persistent)obj);
            else
                UpdateObject(obj);
            ClearBusy();
		}

		protected virtual void DeleteObject(Object obj) {
		    SetBusy();
            if (CRUDControllerManager.Instance.GetCRUDSecurityManager() != null) {
                if (CRUDControllerManager.Instance.GetCRUDSecurityManager().HavePermissions(businessLogic.GetModule() as Modules, CRUDAction.Delete ))
                    ShowCRUDForm(CRUDAction.Delete, (Persistent)obj);
            }
            else 
                ShowCRUDForm(CRUDAction.Delete, (Persistent)obj);
		    ClearBusy();
		}

		public override void Dispose() {
            if (gridForm != null) {
                gridForm.Hide() ;
                gridForm = null;
            }
			//TODO: ver si hay que sobrecargarlo
		}

		private void gridForm_Exit(Form sender) {
            if (IsSelectGrid)
                parentController.SetValueSel(null);
            else
                CRUDControllerManager.Instance.UnloadCRUDController(this);
		}
	    
        void crudForm_Exit(Form sender) {
            if ((repeatCreate) && (lastAction == CRUDAction.Create) && (CRUDSuccedeed)) CreateObject();
        }

		protected override void UpdateCancelled(Persistent persistentObject) {
		    SetBusy();
			BusinessLogic.Evict(persistentObject);
			BusinessLogic.Refresh(persistentObject);
		    ClearBusy();
		}

	    protected override bool CRUDActionDone(ICRUDForm form, CRUDAction action, Persistent persistentObject) {
	        SetBusy();
            CRUDSuccedeed = base.CRUDActionDone(form, action, persistentObject);
	        ClearBusy();
            return CRUDSuccedeed;
        }
	}
}