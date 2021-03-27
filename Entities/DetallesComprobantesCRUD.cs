using System;
using System.Collections.Generic;
using System.Text;
using FrameWork.DataBusinessModel.DataModel;

namespace Entities
{
    [ColumnAttributes("Producto", true, 1, 10),
    ColumnAttributes("Cantidad", true, 2, 10),
    ColumnAttributes("ImpUnitarioForm", true, 3, 8, "Importe Unitario", "#0.#0"),
    ColumnAttributes("ImpTotalForm", true, 4, 8, "Importe Total", "#0.#0")]
    public class DetallesComprobantes : Persistent
    {
        Comprobantes comprobante;
        Productos producto;

        Int32 cantidad = 1;
        Double impunitario;
        Double imptotal;

        Double impunitariosistema;

        Ivas tipoiva;
        Usuarios userUpd;


        public Double ImpTotal
        {
            get
            {
				if (comprobante!= null && comprobante.Cliente != null)
                {
                    /*if (comprobante.Cliente.TipoContribuyente.DiscriminaIVA)
                        return imptotal;
                    else
                        return imptotal;*/
                    return imptotal;
                }
                else
                {
                    if (tipoiva != null)
                        return imptotal * (1 + tipoiva.Alicuota / 100);
                    else
                        return imptotal;
                }
            }
        }

		public Double ImpTotalForm
		{
			get
			{
				if (comprobante != null && comprobante.Cliente != null)
				{
					if (comprobante.Cliente.TipoContribuyente.ComputaIVA && !comprobante.Cliente.TipoContribuyente.DiscriminaIVA)
						return Math.Round(imptotal * (1 + tipoiva.Alicuota / 100), 2);
					else
						return Math.Round(imptotal,2 );
					
				}
				else
				{
					if (tipoiva != null)
						return Math.Round(imptotal * (1 + tipoiva.Alicuota / 100), 2);
					else
						return Math.Round(imptotal, 2);
				}
			}
		}

        /*public Double ImpUnitario
        {
            get
            {
                if (comprobante.Cliente != null)
                {
                    if (comprobante.Cliente.TipoContribuyente.DiscriminaIVA)
                        return impunitario;
                    else
                        return impunitario;
                }
                else
                    return impunitario * (1 + tipoiva.Alicuota / 100);
            }
        }*/

		public Double ImpUnitarioForm
		{
			get
			{
				if (comprobante != null && comprobante.Cliente != null)
				{
					if (comprobante.Cliente.TipoContribuyente.DiscriminaIVA)
						return Math.Round(impunitario, 2);
					else //No discrimina 
					{
						if (comprobante.Cliente.TipoContribuyente.ComputaIVA)
						{//No discrimina y computa
							return Math.Round(impunitario * (1 + tipoiva.Alicuota / 100), 2);
						}
						else
						{
							//No discrimina y no computa
							return Math.Round(impunitario, 2);
						}
					}

				}
				else
					if (tipoiva != null && tipoiva.Alicuota != null)
					{
						return Math.Round(impunitario * (1 + tipoiva.Alicuota / 100), 2);
					}
					else
						return Math.Round(impunitario, 2);
			}
		}


        public Comprobantes Comprobante
        {
            get { return comprobante; }
            set { comprobante = value; }
        }

        public Productos Producto
        {
            get { return producto; }
            set { producto = value; }
        }


        public Int32 Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

		public Double ImpUnitarioNeto
		{
			get { return impunitario; }
			set { impunitario = value; }
		}
		

        public Double ImpUnitarioNetoSistema
        {
            get { return impunitariosistema; }
            set { impunitariosistema = value; }
        }

        public Ivas TipoIva
        {
            get { return tipoiva; }
            set { tipoiva = value; }
        }

        public Double ImpTotalNeto
        {
            get { return imptotal; }
            set { imptotal = value; }
        }

        public Usuarios UserUpd
        {
            get { return userUpd; }
            set { userUpd = value; }
        }
    }
}
