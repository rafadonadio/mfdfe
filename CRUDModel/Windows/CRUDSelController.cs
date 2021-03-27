using System;
using System.Collections;
using System.Windows.Forms;
using FrameWork.CRUDModel.Windows.UI;
using FrameWork.CRUDModel.Windows.UI.Grid;
using FrameWork.DataBusinessModel.BusinessModel;
using FrameWork.DataBusinessModel.DataModel;

namespace FrameWork.CRUDModel.Windows
{
    public class CRUDSelController {
        protected CRUDForm  parentCRUDForm;
        protected DataCombo dc;
        protected BusinessLogic businessLogic;
        protected string gridTitle;
        protected string crudFormTitle;
        protected Type crudFormType;
        protected CRUDController crudController;


        public CRUDSelController(BusinessLogic businessLogic, string gridTitle, string crudFormTitle, Type crudFormType)
        {
            this.businessLogic = businessLogic;
            this.gridTitle =gridTitle;
            this.crudFormTitle = crudFormTitle;
            this.crudFormType = crudFormType;
		}

        public void SetParentCRUDForm(CRUDForm parentCRUDForm)
        {
            this.parentCRUDForm = parentCRUDForm;
            this.parentCRUDForm.RelSelRequired += new RelSelEvent(RelSel);
		}

        protected void RelSel(DataCombo dc, Type relType, Persistent parent)
        {
            if (relType == businessLogic.PersistentType)
            {
                if (crudController!=null)
                    crudController.Dispose();

                if (businessLogic is IFiltrable)
                    ((IFiltrable)businessLogic).SetFilterObject(parent);

                this.dc = dc ;
                crudController = new CRUDController(businessLogic, gridTitle, crudFormTitle, crudFormType, this);
                CRUDControllerManager.Instance.GetCRUDChildControllerManager().SetChildControllers(crudController);
                
                if (dc.ValueChanged)
                    crudController.ShowGrid(dc.Text);
                else
                    crudController.ShowGrid("");
            }
        }

		protected void RelSelFilter(DataCombo dc, Type relType, Persistent parent, String filterValue)
		{
			if (relType == businessLogic.PersistentType)
			{
				if (crudController != null)
					crudController.Dispose();

				if (businessLogic is IFiltrable)
					((IFiltrable)businessLogic).SetFilterObject(parent);

				this.dc = dc;
				crudController = new CRUDController(businessLogic, gridTitle, crudFormTitle, crudFormType, this);
				CRUDControllerManager.Instance.GetCRUDChildControllerManager().SetChildControllers(crudController);

				crudController.ShowGrid(filterValue);
			}
		}
        
		public void SetValueSel(Persistent objSel)
        {
            this.dc.Selected = objSel;
            parentCRUDForm.Refresh();
            crudController.HideGrid();
        }
    }
}
