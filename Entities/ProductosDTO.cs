using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class ProductosDTO
    {
        public String identificacion;
        public String nombre;
        public Double impmc;
        public String tipoIva;
        public String rubro;
        public String clase;
        public Int64 cantidadVendida;

        public ProductosDTO()
        {

        }
        public ProductosDTO(Productos prod)
        {
            identificacion = prod.Identificacion ;
            nombre = prod.Nombre ;
            impmc = prod.Impmc ;
            tipoIva = prod.TipoIva.Descripcion;
            rubro = prod.Rubro.Descripcion ;
            clase = prod.Clase.Descripcion ;
        }    
    }
}
