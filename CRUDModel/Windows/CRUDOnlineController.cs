using System;
using System.Windows.Forms;
using FrameWork.CRUDModel.Windows.UI;
using FrameWork.CRUDModel.Windows.UI.Grid;
using FrameWork.DataBusinessModel.BusinessModel;

namespace FrameWork.CRUDModel.Windows {
	/// <summary>
	/// Summary description for CRUDOnlineController.
	/// </summary>
	public class CRUDOnlineController:AbstractCRUDController {
		public CRUDOnlineController(BusinessLogic businessLogic, string gridTitle):base(businessLogic, gridTitle) {
		}

		protected override bool PersistOnCRUDDone {
			get { return true; }
		}

		public override Type CRUDFormType {
			get { return typeof(GridOnLineForm); }
		}

		public override Form CRUDFormParent {
			get { return FormUtils.Instance.MainForm; }
		}

		protected override void AdditionalInitializeCRUDForm(ICRUDForm form) {
			GridOnLineForm gridForm=(form as GridOnLineForm);
			if(gridForm!=null) {
				InitializeGridForm(gridForm);
				
				gridForm.CreatePersistent += new CreateObjectEvent(BusinessLogic.GetNewInstance);
				gridForm.SetDataSource(businessLogic.GetDataSource(), true);
				gridForm.SetLayout(businessLogic.PersistentType);
			}
		}

		public void ShowGrid() {
		    SetBusy();
			if(crudForm==null) CreateCRUDForm();
			crudForm.Show();
			crudForm.BringToFront();
		    ClearBusy();
		}

		protected override void ReloadGrid() {}

		protected override void RefreshGrid() {}

		public override void Dispose() {
			//TODO: ver si tiene q sobrecargarlo!!!
		}

		protected override void UpdateCancelled(FrameWork.DataBusinessModel.DataModel.Persistent persistentObject) {
		    SetBusy();
			base.UpdateCancelled (persistentObject);
			(crudForm as GridOnLineForm).SetDataSource(businessLogic.GetDataSource(), false);
		    ClearBusy();
		}
	}
}