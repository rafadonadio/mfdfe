using System;
using System.Collections ;
using FrameWork.DataBusinessModel;
using FrameWork.DataBusinessModel.BusinessModel;
using FrameWork.DataBusinessModel.DataModel;
using FrameWork.Tools.Validation;
using Entities;
using NHibernate;
using Security;
using NHibernate.Expression;

namespace BusinessLogic
{
    [Serializable]
    public class ModuloProductos : Modules
    {
        public ModuloProductos()
        { }
    }
    
    public class ProductosBL : FrameWork.DataBusinessModel.BusinessModel.BusinessLogic
    {
        public override bool RequiredFieldsValidator(Persistent persistentObject, ErrorMessages messages)
        {
            bool result = base.RequiredFieldsValidator(persistentObject, messages);
            Productos producto = persistentObject as Productos;
            result &= new RequiredFieldValidator(messages).Validate(producto.Identificacion, "Debe ingresar una Identificación");
            result &= new RequiredFieldValidator(messages).Validate(producto.Nombre, "Debe ingresar un Nombre");
             return result;
        }
        public override bool BusinessValidator(Persistent persistentObject, ErrorMessages messages)
        {
            bool result = base.BusinessValidator(persistentObject, messages);
            Productos producto = persistentObject as Productos;
            result &= new MinimumValidator(messages, false).Validate(producto.Impmc, 0.0, "El importe no es válido");
            return result;
        }
        public override Type PersistentType
        {
            get { return typeof(Productos); }
        }
        public override Type DTOType
        {
            get { return typeof(ProductosDTO); }
        }
        public override IList GetDTODataSource(DateTime fechaDesde, DateTime fechaHasta)
        {
            ProductosDTO prod;
            ArrayList DTOList = new ArrayList();
            IQuery query = DBConnection.Session.CreateQuery("select sum(Items.Cantidad), ItemProducto.Identificacion, ItemProducto.Nombre,RubroProducto.Descripcion, ClaseProducto.Descripcion from Entities.DetallesComprobantes Items inner join Items.Producto ItemProducto left join ItemProducto.Rubro RubroProducto left join ItemProducto.Clase ClaseProducto inner join Items.Comprobante Comprobante where Comprobante.Emision >= :FECHADESDE and Comprobante.Emision <= :FECHAHASTA group by  ItemProducto.Identificacion, ItemProducto.Nombre, RubroProducto.Descripcion, ClaseProducto.Descripcion order by 1 desc");
            query.SetDateTime("FECHADESDE", fechaDesde);
            query.SetDateTime("FECHAHASTA", fechaHasta ); 

            foreach (Object[] ret in query.List())
            {
                prod = new ProductosDTO();
                prod.cantidadVendida = Convert.ToInt64 (ret[0]);
                prod.identificacion = ret[1].ToString() ;
                prod.nombre = ret[2].ToString();
                prod.rubro = ret[3].ToString ();
                prod.clase = ret[4].ToString ();
                DTOList.Add(prod);
            }
            return DTOList;

        }
        public override bool DeleteAllowed(Persistent persistentObject, ErrorMessages messages)
        {
            bool result = base.DeleteAllowed(persistentObject, messages);

            if (HayComprobantes(persistentObject as Productos))
            {
                result = false;
                messages.Add("No se puede eliminar el producto porque existen comprobantes asociados");
            }
            return result;
        }

        private bool HayComprobantes(Productos  producto)
        {
            return DBConnection.Session.CreateCriteria(typeof(DetallesComprobantes)).Add(Expression.Eq("Producto", producto)).
                SetMaxResults(1).List().Count > 0;
        }

        public override object GetModule()
        {
            return new ModuloProductos(); 
        }
    }
}