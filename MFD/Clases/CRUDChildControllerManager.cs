using System;
using Entities;
using FrameWork.CRUDModel.Windows;
using FrameWork.DataBusinessModel;
using BusinessLogic;

namespace MFD.Clases {
    internal class CRUDChildControllerManager : ICRUDChildControllerManager {
        public void SetChildControllers(CRUDController controller) {
            Type persistentType = controller.BusinessLogic.PersistentType;
            DBase db = controller.BusinessLogic.DBConnection;

            if (persistentType == typeof(Comprobantes))
            {
                controller.AddChildController(CRUDControllerManager.Instance.GetCRUDController(db, typeof(DetallesComprobantesBL), typeof(DetallesComprobantesCRUD), "DetallesComprobantes"));
                controller.AddSelController(CRUDControllerManager.Instance.GetCRUDSelController(db, typeof(ClientesBL), typeof(ClientesCRUD), "Seleccionar Cliente","Clientes"));
            }
            if (persistentType == typeof(ComprobantesCompras)) {
                controller.AddChildController(CRUDControllerManager.Instance.GetCRUDController(db, typeof(DetallesComprobantesComprasBL), typeof(DetallesComprobantesComprasCRUD), "Detalles Comprobantes"));
                controller.AddSelController(CRUDControllerManager.Instance.GetCRUDSelController(db, typeof(TiposContribuyentesBL), typeof(TiposContribuyentesCRUD), "Seleccionar Tipo Contribuyente", "Tipos de Contribuyentes"));
            }
            if (persistentType == typeof(Clientes))
            {
                controller.AddSelController(CRUDControllerManager.Instance.GetCRUDSelController(db, typeof(ClasesBL), typeof(IdDescripcionCRUD), "Seleccionar Clase", "Clases"));
                controller.AddSelController(CRUDControllerManager.Instance.GetCRUDSelController(db, typeof(TiposContribuyentesBL), typeof(TiposContribuyentesCRUD), "Seleccionar Tipo Contribuyente", "Tipos de Contribuyentes"));
                controller.AddSelController(CRUDControllerManager.Instance.GetCRUDSelController(db, typeof(TiposPagoBL), typeof(IdDescripcionCRUD), "Seleccionar Tipo de Pago", "Tipos de Pago"));
                controller.AddSelController(CRUDControllerManager.Instance.GetCRUDSelController(db, typeof(ProvinciasBL), typeof(IdDescripcionCRUD), "Seleccionar Provincia", "Provincias"));
                controller.AddSelController(CRUDControllerManager.Instance.GetCRUDSelController(db, typeof(PaisesBL), typeof(IdDescripcionCRUD), "Seleccionar Paises", "Paises"));
            }
            if (persistentType == typeof(Productos))
            {
                controller.AddSelController(CRUDControllerManager.Instance.GetCRUDSelController(db, typeof(ClasesBL), typeof(IdDescripcionCRUD), "Seleccionar Clase", "Clases"));
                controller.AddSelController(CRUDControllerManager.Instance.GetCRUDSelController(db, typeof(RubrosBL), typeof(IdDescripcionCRUD), "Seleccionar Rubro", "Rubros"));
            }
            if (persistentType == typeof(DetallesComprobantes))
            {
                //controller.AddSelController(CRUDControllerManager.Instance.GetCRUDSelController(db, typeof(ProductosBL), typeof(ProductosCRUD), "Seleccionar Producto", "Productos"));
                controller.AddSelController(CRUDControllerManager.Instance.GetCRUDSelController(db, typeof(ProductosParaClienteBL), typeof(ProductosCRUD), "Seleccionar Producto", "Productos"));
            }
            if (persistentType == typeof(Empresas ))
            {
                controller.AddSelController(CRUDControllerManager.Instance.GetCRUDSelController(db, typeof(TiposContribuyentesBL), typeof(TiposContribuyentesCRUD), "Seleccionar Tipo Contribuyente", "Clases"));
            }
        }
    }
}