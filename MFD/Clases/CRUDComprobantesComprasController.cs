using System;
using Entities;
using FrameWork.CRUDModel.Windows;
using FrameWork.CRUDModel.Windows.UI;

namespace MFD.Clases {
    class CRUDComprobantesComprasController:CRUDController {
        public CRUDComprobantesComprasController(FrameWork.DataBusinessModel.BusinessModel.BusinessLogic businessLogic,
                                          string gridTitle, string crudFormTitle, Type crudFormType)
            : base(businessLogic, gridTitle, crudFormTitle, crudFormType) {
        }

        public CRUDComprobantesComprasController(FrameWork.DataBusinessModel.BusinessModel.BusinessLogic businessLogic,
                                          string crudFormTitle, Type crudFormType)
            : base(businessLogic, crudFormTitle, crudFormType) {
        }

        public CRUDComprobantesComprasController(FrameWork.DataBusinessModel.BusinessModel.BusinessLogic businessLogic,
                                          string gridTitle, string crudFormTitle, Type crudFormType,
                                          CRUDSelController parentController)
            : base(businessLogic, gridTitle, crudFormTitle, crudFormType, parentController) {
        }

        protected override void AdditionalInitializeCRUDForm(ICRUDForm form) {
            base.AdditionalInitializeCRUDForm(form);
            (form as ComprobantesComprasCRUD).AnularComprobante += new ComprobanteCompraObjectEvent(AnularComprobante);
        }

        private string AnularComprobante(ComprobantesCompras obj) {
            obj.Anular();
            return "";
        }

    }
}
