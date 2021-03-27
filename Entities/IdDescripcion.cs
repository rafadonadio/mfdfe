using System;
using System.Collections.Generic;
using System.Text;
using FrameWork.DataBusinessModel.DataModel;

namespace Entities
{
    [ColumnAttributes("Descripcion", true, 1, 15)]
    [FilterColumnAttribute("Descripcion")]
    [Serializable]
    public class IdDescripcion : Persistent
    {
        private string descripcion;

        public override string ToString()
        {
            return descripcion;
        }

        public string Descripcion
        {
            get { return descripcion ; }
            set { descripcion = value; }
        }
    }

}
