using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    [Serializable]
    public class Ivas : IdDescripcion 
    {
        private Double  alicuota;

        public Double Alicuota
        {
            get { return alicuota; }
            set { alicuota = value; }
        }   
    }
}
