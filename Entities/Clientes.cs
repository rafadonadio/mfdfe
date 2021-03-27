using System;
using System.Collections.Generic;
using System.Text;
using FrameWork.DataBusinessModel.DataModel;

namespace Entities
{
    [ColumnAttributes("Cliente", true, 1, 5),
     ColumnAttributes("Nombre", true, 2, 20),
    ColumnAttributes("CUIT", true, 3, 10)]
    [FilterColumnAttribute("Nombre")]
    public class Clientes : Persistent
    {
        //private string cliente;
        private bool isChanged;
        private string nombre;
        private string cuit;
        private string email;
        private Usuarios  userUpd;
        private Clases clase;
        private Boolean filtraClase;
        private TiposContribuyentes tipoContribuyente;
        private TiposPago tipoPago;
        private Boolean iibbExento;

        private string domicilio;
        private string localidad;
        private Provincias provincia;
        private Paises pais;
        private string telefonos;
        private string codigoPostal;
		private Boolean enDolares;

        public string Cliente
        {
            get { return (Id>0)?String.Format("{0}", Id) : "<Sin Asignar>"; }
        }

        public override string ToString()
        {
            return nombre ;
        }

        public string GridDescription
        {
            get { return nombre; }
        }
        
        public string Nombre
        {
            get { return nombre; }
            set {nombre = value; }
        }
        
        public string CUIT
        {
            get { return cuit ; }
            set {cuit = value; }
        }

        public string Email
        {
            get { return email; }
            set {email = value; }
        }

        public Usuarios UserUpd
        {
            get { return userUpd; }
            set {userUpd = value; }
        }
        public Clases Clase
        {
            get { return clase; }
            set {clase = value; }
        }
        public TiposContribuyentes TipoContribuyente
        {
            get { return tipoContribuyente; }
            set {tipoContribuyente = value; }
        }
        public Boolean IibbExento
        {
            get { return iibbExento; }
            set {iibbExento = value; }
        }
        public Boolean FiltraClase
        {
            get { return filtraClase; }
            set {filtraClase = value; }
        }
        public TiposPago TipoPago
        {
            get { return tipoPago ; }
            set {tipoPago = value; }
        }

        public string Domicilio
        {
            get { return domicilio; }
            set {domicilio = value; }
        }

        public string Localidad
        {
            get { return localidad; }
            set {localidad = value; }
        }

        public Provincias Provincia
        {
            get { return provincia; }
            set {provincia = value; }
        }

        public Paises Pais
        {
            get { return pais; }
            set {pais = value; }
        }

        public string Telefonos
        {
            get { return telefonos; }
            set {telefonos = value; }
        }

        public string CodigoPostal
        {
            get { return codigoPostal ; }
            set {codigoPostal = value; }
        }

		public Boolean EnDolares
		{
			get { return enDolares; }
			set { enDolares = value; }
		}
	}
}
