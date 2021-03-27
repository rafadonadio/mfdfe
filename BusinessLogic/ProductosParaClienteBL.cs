using System;
using FrameWork.DataBusinessModel;
using FrameWork.DataBusinessModel.BusinessModel;
using FrameWork.DataBusinessModel.DataModel;
using FrameWork.Tools.Validation;
using Entities;
using NHibernate;

namespace BusinessLogic
{
    public class ProductosParaClienteBL : ProductosBL
    {
        protected Clientes cliente;

        protected override ICriteria CreateDataSourceCriteria()
        {
            ICriteria crit = DBConnection.Session.CreateCriteria(PersistentType);
            if (cliente != null)
            {
                if (cliente.FiltraClase )
                    crit.Add(new NHibernate.Expression.EqExpression("Clase", cliente.Clase));
            }
            return crit;
        }

        //Se elimino la posibilidad de filtrar por la clase padre porque requeria agregar al 
        //padre el hijo y esto probocaba que al listar los registros se realice un insert de un producto null
        //public void SetFilterObject(Persistent filterObject)
        //{
        //    DetallesComprobantes det = (filterObject as DetallesComprobantes);
        //    cliente = det.Comprobante.Cliente;
        //}
    }
}
