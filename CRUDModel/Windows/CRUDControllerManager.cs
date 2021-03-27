using System;
using System.Collections;
using FrameWork.CRUDModel.Windows.UI.Grid;
using FrameWork.DataBusinessModel;
using FrameWork.DataBusinessModel.BusinessModel;

namespace FrameWork.CRUDModel.Windows {
	/// <summary>
	/// Summary description for CRUDControllerManager.
	/// </summary>
	public class CRUDControllerManager {
		#region CRUDControllerIdentifier

		private class CRUDControllerIdentifier {
			private Type businessLogicType, crudFormType;
			private string gridTitle, crudFormTitle;

			public CRUDControllerIdentifier(Type businessLogicType, Type crudFormType, string gridTitle, string crudFormTitle) {
				this.businessLogicType = businessLogicType;
				this.crudFormType = crudFormType;
				this.gridTitle = gridTitle;
				this.crudFormTitle = crudFormTitle;
			}

			public CRUDControllerIdentifier(Type businessLogicType, Type crudFormType, string crudFormTitle):this(businessLogicType, crudFormType, null, crudFormTitle) {
				
			}

			public CRUDControllerIdentifier(AbstractCRUDController controller):this(controller.BusinessLogic.GetType(), controller.CRUDFormType, controller.CRUDFormTitle) {
			}

			public CRUDControllerIdentifier(CRUDController controller):this(controller.BusinessLogic.GetType(), controller.CRUDFormType, controller.GridTitle, controller.CRUDFormTitle) {
			}

			public override bool Equals(object obj) {
				if (obj is CRUDControllerIdentifier) {
					CRUDControllerIdentifier aux = (CRUDControllerIdentifier) obj;
					return ((businessLogicType == aux.businessLogicType) && (crudFormType == aux.crudFormType) && (gridTitle == aux.gridTitle) && (crudFormTitle == aux.crudFormTitle));
				}
				else return false;
			}

			public override int GetHashCode() {
				return base.GetHashCode();
			}
		}

		#endregion

		#region CRUDControllerList

		private class CRUDControllerList {
			protected class CRUDControllerListEntry {
				protected CRUDControllerIdentifier key;
				protected object value;

				public CRUDControllerListEntry(CRUDControllerIdentifier key, AbstractCRUDController value) {
					this.key = key;
					this.value = value;
				}

				public CRUDControllerIdentifier Key {
					get { return this.key; }
				}

				public AbstractCRUDController Value {
					get { return (AbstractCRUDController) this.value; }
				}

				public override bool Equals(object obj) {
					if (obj is CRUDControllerListEntry) return ((CRUDControllerListEntry) obj).Key.Equals(this.Key);
					else return false;
				}

				public override int GetHashCode() {
					return base.GetHashCode();
				}
			}

			protected IList innerList;

			public CRUDControllerList() {
				innerList = new ArrayList();
			}

			public void Add(CRUDControllerIdentifier key, AbstractCRUDController crudController) {
				if (!Contains(key)) innerList.Add(new CRUDControllerListEntry(key, crudController));
			}

			public void Remove(CRUDControllerIdentifier key) {
				if (Contains(key)) innerList.RemoveAt(IndexOf(key));
			}

			public bool Contains(CRUDControllerIdentifier key) {
				return innerList.Contains(new CRUDControllerListEntry(key, null as AbstractCRUDController));
			}

			public AbstractCRUDController this[CRUDControllerIdentifier key] {
				get {
					AbstractCRUDController result = null;
					for (int i = 0; (i < innerList.Count) && (result == null); i++)
						if (((CRUDControllerListEntry) innerList[i]).Key.Equals(key))
							result = ((CRUDControllerListEntry) innerList[i]).Value;
					return result;
				}
			}

			public int IndexOf(CRUDControllerIdentifier key) {
				int result = -1;
				for (int i = 0; (i < innerList.Count) && (result < 0); i++)
					if (((CRUDControllerListEntry) innerList[i]).Key.Equals(key))
						result = i;
				return result;
			}
		}

		#endregion

		private ICRUDChildControllerManager childControllerManager;
        private ICRUDSecurityManager securityManager;
		private CRUDControllerList crudControllerList;

		private CRUDControllerManager() {
			crudControllerList = new CRUDControllerList();
		}

		private static CRUDControllerManager instance = null;

		public static CRUDControllerManager Instance {
			get {
				if (instance == null) instance = new CRUDControllerManager();
				return instance;
			}
		}

		public void SetCRUDChildControllerManager(ICRUDChildControllerManager childControllerManager) {
			this.childControllerManager = childControllerManager;
		}

        public ICRUDChildControllerManager GetCRUDChildControllerManager()
        {
            return this.childControllerManager;
        }

        public void SetCRUDSecurityManager(ICRUDSecurityManager securityManager)
        {
            this.securityManager = securityManager;
		}

        public ICRUDSecurityManager GetCRUDSecurityManager()
        {
            return this.securityManager ;
        }

		public CRUDChildController GetCRUDController(DBase db, Type businessLogicType, Type crudFormType, string crudFormTitle) {
			CRUDChildController result = null;
			CRUDControllerIdentifier key = new CRUDControllerIdentifier(businessLogicType, crudFormType, crudFormTitle);

			if (!crudControllerList.Contains(key)) {
				BusinessLogic businessLogic = BusinessLogicFactory.GetBusinessLogicInstance(db, businessLogicType);

				result = new CRUDChildController(businessLogic, crudFormTitle, crudFormType);
				childControllerManager.SetChildControllers(result);
				crudControllerList.Add(key, result);
			}
			else result = (CRUDChildController) crudControllerList[key];

			return result;
		}

		public CRUDOnlineController GetCRUDController(DBase db, Type businessLogicType, string gridTitle) {
			CRUDOnlineController result=null;
			CRUDControllerIdentifier key = new CRUDControllerIdentifier(businessLogicType, typeof(GridOnLineForm), gridTitle);
			if (!crudControllerList.Contains(key)) {
				BusinessLogic businessLogic = BusinessLogicFactory.GetBusinessLogicInstance(db, businessLogicType);

				result = new CRUDOnlineController(businessLogic, gridTitle);
				crudControllerList.Add(key, result);
			}
			else result = (CRUDOnlineController) crudControllerList[key];
			
			return result;
		}

        public CRUDController GetCRUDController(DBase db, Type businessLogicType, Type crudFormType, string gridTitle, string crudFormTitle) {
            return GetCRUDController(db, businessLogicType, crudFormType, gridTitle, crudFormTitle, false);
        }
	    
		public CRUDController GetCRUDController(DBase db, Type businessLogicType, Type crudFormType, string gridTitle, string crudFormTitle, bool repeatCreate) {
			CRUDController result = null;
			CRUDControllerIdentifier key = new CRUDControllerIdentifier(businessLogicType, crudFormType, gridTitle, crudFormTitle);

			if (!crudControllerList.Contains(key)) {
				BusinessLogic businessLogic = BusinessLogicFactory.GetBusinessLogicInstance(db, businessLogicType);

				result = new CRUDController(businessLogic, gridTitle, crudFormTitle, crudFormType, repeatCreate);
				childControllerManager.SetChildControllers(result);
				crudControllerList.Add(key, result);
			}
			else result = (CRUDController) crudControllerList[key];
			return result;
		}
        public CRUDSelController GetCRUDSelController(DBase db, Type businessLogicType, Type crudFormType, string gridTitle, string crudFormTitle)
        {
            CRUDSelController result;
            BusinessLogic businessLogic = BusinessLogicFactory.GetBusinessLogicInstance(db, businessLogicType);
            result = new CRUDSelController(businessLogic, gridTitle, crudFormTitle, crudFormType);
            return result;
        }
		public void UnloadCRUDController(AbstractCRUDController crudController) {
			CRUDControllerIdentifier key=null;
			
			if(crudController is CRUDController) key = new CRUDControllerIdentifier(crudController as CRUDController);
			else key = new CRUDControllerIdentifier(crudController);

			if (crudControllerList.Contains(key)) crudControllerList.Remove(key);
			crudController.Dispose();
		}
	}
}