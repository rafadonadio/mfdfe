using System;
using System.IO;
using System.Text;
using System.Xml;
using Entities;
using MFDService.ar.gov.afip.wswhomo;
using Tools.XML.Generator;

namespace MFD.Clases.Adapters {
    public class ComprobantesAdapter {
        private Comprobantes comprobante;

        public ComprobantesAdapter(Comprobantes comprobante) {
            this.comprobante = comprobante;
        }

        #region Formatting Functions
        protected static string FormatDate(DateTime? fecha) {
            if (fecha != null) return FormatDate(fecha.Value);
            else return "        ";
        }

        protected static string FormatDate(DateTime fecha) {
            return String.Format("{0:yyyyMMdd}", fecha);
        }

        protected static string FormatInt(int number) {
            return FormatInt(number, 8);
        }

        protected static string FormatInt(int number, int length) {
            return FormatDouble((double)number, length, 0);
        }

        protected static string FormatDouble(double number) {
            return FormatDouble(number, 15);
        }

        protected static string FormatDouble(double number, int length) {
            return FormatDouble(number, length, 2);
        }

        protected static string FormatDouble(double number, int length, int precision) {
            string formatter = String.Empty.PadLeft(length - precision, '0') + "." + String.Empty.PadLeft(precision, '0');
            return number.ToString(formatter).Replace(".", "").Replace(",", "");
        }
        #endregion

		//public FERequest GenerarFERequest(long idCabecera) {
		//    //Cabecera
		//    FECabeceraRequest cabecera = new FECabeceraRequest();
		//    cabecera.id = idCabecera;
		//    cabecera.cantidadreg = 1;
		//    cabecera.presta_serv = 1; //TODO: por ahora todo lo que se facturan son servicios

		//    //Detalle
		//    FEDetalleRequest detalle = new FEDetalleRequest();
		//    //TODO: Liberar de la base
		//    detalle.tipo_doc = Convert.ToInt32(GeneralSettings.Instance.CodigoCUIT);
		//    detalle.nro_doc = Convert.ToInt64(comprobante.Cliente.CUIT.Replace("-",""));
		//    detalle.tipo_cbte = Convert.ToInt32(comprobante.Tipo.Codigo);
		//    detalle.punto_vta = Convert.ToInt32(comprobante.NroCbante.Substring(0, 4));
		//    detalle.cbt_desde = Convert.ToInt64(comprobante.NroCbante.Substring(5, 8));
		//    detalle.cbt_hasta = Convert.ToInt64(comprobante.NroCbante.Substring(5, 8));
		//    detalle.imp_total = comprobante.Total;
		//    detalle.imp_tot_conc = 0;
		//    detalle.imp_neto = comprobante.SubtotalNeto;
		//    detalle.impto_liq = comprobante.Iva1 + comprobante.Iva2;
		//    detalle.impto_liq_rni = 0;
		//    detalle.imp_op_ex = 0;
		//    detalle.fecha_serv_desde = FormatDate(comprobante.Emision); //TODO: verificar que sea la fecha correcta
		//    detalle.fecha_serv_hasta = FormatDate(comprobante.Emision); //TODO: verificar que sea la fecha correcta
		//    detalle.fecha_cbte = FormatDate(comprobante.Emision);
		//    detalle.fecha_venc_pago = FormatDate(comprobante.Emision);//TODO: verificar que sea la fecha correcta

		//    //Armado del FERequest
		//    FERequest result = new FERequest();
		//    result.Fecr = cabecera;
		//    result.Fedr = new FEDetalleRequest[1];
		//    result.Fedr[0] = detalle;

		//    return result;
		//}

		//public FELastCMPtype GenerarFELastCMPtype() {
		//    FELastCMPtype feLastCMPtype = new FELastCMPtype();
		//    feLastCMPtype.TipoCbte = Convert.ToInt32(comprobante.Tipo.Codigo);
		//    feLastCMPtype.PtoVta = Convert.ToInt32(comprobante.NroCbante.Substring(0, 4));
		//    return feLastCMPtype;

		//}
        public string GenerarStreamComprobantes() {
            string result = String.Empty;

            #region Registro Tipo 1
            //Registro Tipo 1
            //Campo 1: Tipo de registro
            result += "1";
            //Campo 2: Fecha del comprobante
            result += FormatDate(comprobante.Emision);
            //Campo 3: Tipo de comprobante
            result += comprobante.Tipo.Codigo.Substring(0, 2);
            //Campo 4: Controlador Fiscal (no corresponde a facturacion electronica)
            result += " ";
            //Campo 5: Punto de Venta
            result += comprobante.NroCbante.Substring(0, 4);
            //Campo 6: Número de comprobante
            result += comprobante.NroCbante.Substring(5, 8);
            //Campo 7: Número de comprobante Registrado
            result += comprobante.NroCbante.Substring(5, 8);
            //Campo 8: Cantidad de Hojas (no corresponde a facturacion electronica)
            result += "   ";
            //Campo 9: Código de documento identificatorio del compador
            result += comprobante.CUITCliente.Substring(0, 2);
            //Campo 10: Número de identificación del comprador
            result += comprobante.CUITCliente.Replace("-", "").PadRight(11, ' ');
            //Campo 11: Apellido y nombres o denominación del comprobanterador
            result += comprobante.NombreCliente.PadRight(30, ' ');
            //Campo 12: Importe total de la operación
            result += FormatDouble(comprobante.Total);
            //Campo 13: Importe total de conceptos que no integran el precio neto gravado
            result += FormatDouble(0);
            //Campo 14: Importe Neto Gravado
            result += FormatDouble(comprobante.SubtotalNeto);
            //Campo 15: Impuesto liquidado
            result += FormatDouble(comprobante.Iva1 + comprobante.Iva2);
            //Campo 16: Impuesto liquida    do a RNI o percepción a no categorizados
            //TODO: si el comprobanterador es no inscripto o no categorizado (campo 23 = 02 o 07), esto es el 50% del campo 15
            result += FormatDouble(0);
            //Campo 17: Importe de operaciones exentas
            result += FormatDouble(0);
            //Campo 18: Importe de percepciones o pagos a cuenta sobre impuestos nacionales
            result += FormatDouble(0);
            //Campo 19: Importe de percepción de ingresos brutos
            result += FormatDouble(comprobante.Percepciones);
            //Campo 20: Importe de percepciones por impuestos municipales
            result += FormatDouble(0);
            //Campo 21: Importe de impuestos internos
            result += FormatDouble(0);
            //Campo 22: Transporte (no corresponde a facturacion electronica)
            result += String.Empty.PadLeft(15);
            //Campo 23: Tipo de responsable
            result += comprobante.TipoCliente.Codigo.Substring(0, 2);
            //Campo 24: Códigos de Moneda (no corresponde a facturacion electronica)
            result += GeneralSettings.Instance.CodigoMoneda.Substring(0, 3);
            //Campo 25: Tipo de Cambio (no corresponde a facturacion electronica)
            result += String.Empty.PadLeft(10);
            //Campo 26: Cantidad de alícuotas de IVA (no corresponde a facturacion electronica)
            result += " ";
            //Campo 27: Código de operación
            result += " ";
            //Campo 28: CAI
            result += comprobante.Empresa.CAI.ToString().PadRight(14);
            //Campo 29: Fecha de vencimiento
            result += FormatDate(comprobante.Empresa.FechaVtoCAI);
            //Campo 30: Fecha anulación del comprobante
            result += FormatDate(comprobante.Anulacion);
            //Fin de registro
            result += "\r\n";
            #endregion

            #region Registro Tipo 2
            //Registro Tipo 2
            //Campo 1: Tipo de Registro
            result += "2";
            //Campo 2: Período
            result += comprobante.Emision.ToString("yyyyMM");
            //Campo 3: Relleno
            result += String.Empty.PadLeft(13);
            //Campo 4: Cantidad de Registros de tipo 1
            result += FormatInt(1);
            //Campo 5: Relleno
            result += String.Empty.PadLeft(17);
            //Campo 6: CUIT del informante
            result += comprobante.Empresa.Cuit.Replace("-", "").PadLeft(11);
            //Campo 7: Relleno
            result += String.Empty.PadLeft(22);
            //Campo 8: Importe total de la operación
            result += FormatDouble(comprobante.Total);
            //Campo 9: Importe total de conceptos que no integran el precio neto gravado
            result += FormatDouble(0);
            //Campo 10: Importe Neto Gravado
            result += FormatDouble(comprobante.SubtotalNeto);
            //Campo 11: Impuesto liquidado
            result += FormatDouble(comprobante.Iva1 + comprobante.Iva2);
            //Campo 12: Impuesto liquidado a RNI o percepción a no categorizados
            result += FormatDouble(0);
            //Campo 13: Importe de operaciones exentas
            result += FormatDouble(0);
            //Campo 14: Importe de percepciones o pagos a cuenta de impuestos nacionales
            result += FormatDouble(0);
            //Campo 15: Importe de percepción de ingresos brutos
            result += FormatDouble(comprobante.Percepciones);
            //Campo 16: Importe de percepción de impuestos municipales
            result += FormatDouble(0);
            //Campo 17: Importe de impuestos internos
            result += FormatDouble(0);
            //Campo 18: Relleno
            result += String.Empty.PadLeft(62);
            //Fin de registro
            result += "\r\n";
            #endregion

            return result;
        }

        public String GetStreamDetalle() {
            StringBuilder result = new StringBuilder();

            foreach (DetallesComprobantes item in comprobante.Items) {
                //Campo 1: Tipo de Comprobante
                result.Append(comprobante.Tipo.Codigo.Substring(0, 2));
                //Campo 2: Controlador Fiscal
                result.Append(" ");
                //Campo 3: Fecha del Comprobante
                result.Append(comprobante.Emision.ToString("yyyyMMdd"));
                //Campo 4: Punto de Venta
                result.Append(comprobante.NroCbante.Substring(0, 4));
                //Campo 5: Número de Comprobante
                result.Append(comprobante.NroCbante.Substring(5, 8));
                //Campo 6: Número de Comprobante Registrado
                result.Append(comprobante.NroCbante.Substring(5, 8));
                //Campo 7: Cantidad
                result.Append(FormatDouble(item.Cantidad, 12, 5));
                //Campo 8: Unidad de medida
                result.Append("07");  //UNIDAD
                //Campo 9: Precio unitario
                result.Append(FormatDouble((item.ImpUnitarioNeto * (1 - comprobante.Descuento / 100)), 16, 3));
                //Campo 10: Importe de bonificación
                result.Append(FormatDouble(0d, 16));
                //Campo 11: Subtotal por registro
                result.Append((item.ImpTotalNeto * (1 - comprobante.Descuento / 100)).ToString("#0.#0").Replace(".", "").Replace(",", "").PadLeft(15, '0'));
                //Campo 12: Alícuota de IVA aplicable
                result.Append(item.TipoIva.Alicuota.ToString("#0.#0").Replace(".", "").Replace(",", ""));
                //Campo 13: Indicación de exento o gravado
                if (item.TipoIva.Alicuota != 0) result.Append('G');
                else result.Append('E');
                //Campo 14: Indicación de anulación
                if (item.Comprobante.Estado == Comprobantes.EstadoAnulado) result.Append("A");
                else result.Append(" ");
                //Campo 15: Diseño libre (nombre del producto)
                result.Append(item.Producto.Nombre);
                //Fin de registro
                result.Append("\r\n");
            }
            return result.ToString();
        }

        public XmlDocument GenerarXml() {
            #region constants
            const string Comprobante = "comprobante";
            const string Cabecera = "cabecera";
            const string Detalle = "detalle";
            const string Resumen = "resumen";
            #endregion
            
            XmlQualifiedName qualifiedName = new XmlQualifiedName("factura");
            XMLGenerator generator = new XMLGenerator("Factura_v1.22.xsd", qualifiedName);
            Stream xmlStream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(xmlStream, Encoding.GetEncoding("iso-8859-1"));
            writer.Formatting = Formatting.Indented;
            generator.WriteXml(writer);
            XmlDocument document = new XmlDocument();
            xmlStream.Seek(0, SeekOrigin.Begin);
            XmlReader reader = new XmlTextReader(xmlStream);
            document.Load(reader);
            reader.Close();
			writer.Close();
            xmlStream.Close(); xmlStream.Dispose();

			//document.InsertAfter(document.CreateProcessingInstruction("xml-stylesheet", "type=\"text/xsl\" href=\"../../Factura_v1.22.xsl\""), document.ChildNodes[0]);/*Lote_Factura_Response_v1.0.xsl*/
			document.InsertAfter(document.CreateProcessingInstruction("xml-stylesheet", "type=\"text/xsl\" href=\"Factura_v1.22.xsl\""), document.ChildNodes[0]);
			CargarDatosCabecera(document[Comprobante][Cabecera]);
            CargarDatosDetalle(document[Comprobante][Detalle]);
            CargarDatosResumen(document[Comprobante][Resumen]);
			XmlNode nodoLogo = document.CreateNode(XmlNodeType.Element, "string", "logo","");
			XmlNode nodoUrl = document.CreateNode(XmlNodeType.Element, "url", "");
			CargarDatosExtensiones(document[Comprobante]["extensiones"], nodoLogo, nodoUrl);
            
			
			document[Comprobante].Attributes["xmlns"].Value="";
			XmlAttribute attns = document.CreateAttribute("xmlns:tns");
			attns.Value = "http://www.cace.org.ar/facturaelectronica/";
			document[Comprobante].Attributes.Append(attns);
			XmlAttribute atxsi = document.CreateAttribute("xmlns:xsi");
			atxsi.Value = "http://www.w3.org/2001/XMLSchema-instance";
			document[Comprobante].Attributes.Append(atxsi);
			return document;
        }
        
        private void CargarDatosCabecera(XmlNode cabecera) {
            #region constants
			#region InformacionComprobante
			const string InformacionComprobante = "informacion_comprobante";
            const string TipoComprobante = "tipo_de_comprobante";
            const string NumeroComprobante = "numero_comprobante";
            const string PuntoVenta = "punto_de_venta";
            const string FechaEmision = "fecha_emision";
            const string FechaVencimiento = "fecha_vencimiento";
			const string FechaServDesde = "fecha_serv_desde";
			const string FechaServHasta = "fecha_serv_hasta";
			const string CondicionPago = "condicion_de_pago";
			const string IvaComputable = "iva_computable";
			const string CodigoOperacion = "codigo_operacion";
			const string TipoCodigoAutorizacion = "Tipo_Codigo_Autorizacion";
			const string CAE = "cae";
			const string FechaVencimientoCAE = "fecha_vencimiento_cae";
            //const string Observaciones = "observaciones";
			const string fecha_obtencion_cae = "fecha_obtencion_cae";
			const string resultado = "resultado";
			const string motivo = "motivo";
			const string es_detalle_encriptado = "es_detalle_encriptado";
			const string referencias = "referencias";
			const string codigo_de_referencia = "codigo_de_referencia";
			const string dato_de_referencia = "dato_de_referencia";
			#endregion InformacionComprobante
			#region InformacionVendedor
			const string InformacionVendedor = "informacion_vendedor";
            const string RazonSocial = "razon_social";
            const string CondicionIVA = "condicion_IVA";
            const string CondicionIngresosBrutos = "condicion_ingresos_brutos";
			const string NumeroIngresosBrutos = "nro_ingresos_brutos";
			const string InicioActividades = "inicio_de_actividades";
            const string Contacto = "contacto";
			const string Direccion = "domicilio_calle";
			//TODO Completar toda la direccion
            const string Localidad = "localidad";
            const string Provincia = "provincia";
            const string CP = "cp";
            const string Email = "email";
            const string Telefono = "telefono";
            const string CUIT = "cuit";
			#endregion InformacionVendedor
            
            const string InformacionComprador = "informacion_comprador";
			const string CodigoDocumentoIdentificatorio = "codigo_doc_identificatorio";
			const string NumeroDocumentoIdentificatorio = "nro_doc_identificatorio";
            #endregion

            XmlNode informacionComprobante = cabecera[InformacionComprobante];
            XmlNode informacionVendedor = cabecera[InformacionVendedor];
            XmlNode informacionComprador = cabecera[InformacionComprador];
			try
			{
				informacionComprobante[TipoComprobante].InnerText = comprobante.Tipo.Codigo;
				informacionComprobante[NumeroComprobante].InnerText = comprobante.NroCbante.Substring(5);
				informacionComprobante[PuntoVenta].InnerText = comprobante.NroCbante.Substring(0, 4);
				informacionComprobante[FechaEmision].InnerText = XmlConvert.ToString(comprobante.Emision, "yyyy-MM-dd");
				informacionComprobante.RemoveChild(informacionComprobante[FechaVencimiento]);
				informacionComprobante.RemoveChild(informacionComprobante[FechaServDesde]);
				informacionComprobante.RemoveChild(informacionComprobante[FechaServHasta]);
				informacionComprobante.RemoveChild(informacionComprobante[CondicionPago]);
				informacionComprobante[IvaComputable].InnerText = "S";
				//informacionComprobante[TipoCodigoAutorizacion].InnerText = "CAI";
				informacionComprobante[CAE].InnerText = (comprobante.CAE == null) ? "27009112669083" : comprobante.CAE;
				informacionComprobante[FechaVencimientoCAE].InnerText = XmlConvert.ToString(comprobante.Emision.AddDays(10), "yyyy-MM-dd");; //TODO: Rafa: el vencimiento es la fecha de emisión + 10 dias 
				informacionComprobante["fecha_obtencion_cae"].InnerText = XmlConvert.ToString(comprobante.Emision, "yyyy-MM-dd");
				informacionComprobante["resultado"].InnerText = "";
				//informacionComprobante["motivo"].InnerText = "<!-- motivo AFIP -->";
				informacionComprobante.RemoveChild(informacionComprobante["motivo"]);
				informacionComprobante["es_detalle_encriptado"].InnerText = "N";
				//TODO: VEr si puedo poner referencia =""; codigo_de_referencia y dato_de_referencia
				informacionComprobante["referencias"].RemoveAll();
				informacionComprobante.RemoveChild(informacionComprobante["referencias"]);
				informacionComprobante["referencias"].RemoveAll();
				informacionComprobante.RemoveChild(informacionComprobante["referencias"]);
				informacionComprobante["referencias"].RemoveAll();
				informacionComprobante.RemoveChild(informacionComprobante["referencias"]);
				informacionComprobante["referencias"].RemoveAll();
				informacionComprobante.RemoveChild(informacionComprobante["referencias"]);
				informacionComprobante["referencias"].RemoveAll();
				informacionComprobante.RemoveChild(informacionComprobante["referencias"]);
					
				
				//informacionComprobante["referencias"].RemoveChild(informacionComprobante["referencias"].ChildNodes[1]);
				//informacionComprobante["referencias"].RemoveChild(informacionComprobante["referencias"].ChildNodes[2]);
				
				//TODO: Vero Ver donde van las observaciones
				//informacionComprobante[Observaciones].InnerText = comprobante.Observaciones;

				informacionVendedor[RazonSocial].InnerText = comprobante.Empresa.RazonSocial;
				informacionVendedor[CondicionIVA].InnerText = comprobante.Empresa.TipoContribuyente.Codigo;
				informacionVendedor[CondicionIngresosBrutos].InnerText = (comprobante.Empresa.IIBB)?"1":"0";// "1"; //TODO: VERO ver que hay que poner
				informacionVendedor[NumeroIngresosBrutos].InnerText = comprobante.Empresa.NroIIBB; //TODO: ver que hay que poner
				informacionVendedor[InicioActividades].InnerText = XmlConvert.ToString(comprobante.Empresa.Inicio, "yyy-MM-dd");
				informacionVendedor[Contacto].InnerText = ""; //TODO: ver si tenemos que agregar el campo contacto
				informacionVendedor[Direccion].InnerText = comprobante.Empresa.Direccion;
				informacionVendedor["domicilio_numero"].InnerText = "";
				informacionVendedor.RemoveChild(informacionVendedor["domicilio_piso"]);
				informacionVendedor["domicilio_depto"].InnerText = "";
				informacionVendedor["domicilio_sector"].InnerText = "";
				informacionVendedor["domicilio_torre"].InnerText = "";
				informacionVendedor["domicilio_manzana"].InnerText = "";
				informacionVendedor[Localidad].InnerText = "CABA"; //TODO: ver si tenemos que agregar el campo Localidad
				informacionVendedor[Provincia].InnerText = "Buenos Aires"; //TODO: ver si tenemos que agregar el campo Provincia
				informacionVendedor[CP].InnerText = comprobante.Empresa.CodigoPostal;
				informacionVendedor[Email].InnerText = comprobante.Empresa.Email;
				informacionVendedor[Telefono].InnerText = comprobante.Empresa.Telefono; //TODO: ver so tenemos que agregar el campo Telefono
				informacionVendedor[CUIT].InnerText = comprobante.Empresa.Cuit.Replace("-", "");
				informacionVendedor.RemoveChild(informacionVendedor["GLN"]);



				informacionVendedor.RemoveChild(informacionVendedor["codigo_interno"]);
				informacionComprador.RemoveChild(informacionComprador["inicio_de_actividades"]);
				informacionComprador["denominacion"].InnerText = comprobante.Cliente.Nombre;
				informacionComprador.RemoveChild(informacionComprador["GLN"]);
				informacionComprador[CondicionIVA].InnerText = comprobante.Cliente.TipoContribuyente.Codigo;
				informacionComprador.RemoveChild(informacionComprador[CondicionIngresosBrutos]);//TODO: ver que hay que poner
				informacionComprador.RemoveChild(informacionComprador[NumeroIngresosBrutos]); //TODO: ver que hay que poner
				informacionComprador.RemoveChild(informacionComprador[Contacto]);//TODO: ver si tenemos que agregar el campo contacto
				informacionComprador[Direccion].InnerText = comprobante.Cliente.Domicilio; //TODO: ver si tenemos que agregar el campo Direccion
				informacionComprador["domicilio_numero"].InnerText = "";
				informacionComprador.RemoveChild(informacionComprador["domicilio_piso"]);
				informacionComprador["domicilio_depto"].InnerText = "";
				informacionComprador["domicilio_sector"].InnerText = "";
				informacionComprador["domicilio_torre"].InnerText = "";
				informacionComprador["domicilio_manzana"].InnerText = "";
				
				informacionComprador[Localidad].InnerText = comprobante.Cliente.Localidad;
				informacionComprador[Provincia].InnerText = (comprobante.Cliente.Provincia != null) ? comprobante.Cliente.Provincia.Descripcion : "";
				informacionComprador[CP].InnerText = comprobante.Cliente.CodigoPostal;
				informacionComprador[Email].InnerText = comprobante.Cliente.Email;
				informacionComprador[Telefono].InnerText = comprobante.Cliente.Telefonos;
				informacionComprador[CodigoDocumentoIdentificatorio].InnerText = GeneralSettings.Instance.CodigoCUIT; //TODO ver que hay que poner
				informacionComprador[NumeroDocumentoIdentificatorio].InnerText = comprobante.Cliente.CUIT.Replace("-", ""); //TODO ver que hay que poner

			}
			catch (Exception ex) {
				string err = ex.Message;
			}
        }
        
        private void CargarDatosDetalle(XmlNode detalle) {
            #region Constants Node Names
            //const string Linea = "linea";
            const string NumeroLinea = "numeroLinea";
			const string CodigoInterno = "codigo_producto_vendedor";
            const string Descripcion = "descripcion";
            const string Cantidad = "cantidad";
            const string Unidad = "unidad";
			const string ImporteUnitario = "precio_unitario";
			const string ImporteTotal = "importe_total_articulo";
            const string AlicuotaIva = "alicuota_iva";
            const string ImporteIva = "codigo_impuesto";

			const string Descuentos = "descuentos";
			const string PorcentajeDescuento = "porcentaje_descuento";
            #endregion

            XmlNode lineaTemplate = detalle.ChildNodes[0];
			XmlNode comentarioNode = detalle["comentarios"].CloneNode(true);
            detalle.RemoveAll();
            double numeroLinea = 0;
			Double importeDescuento, importeUnitarioConDescuento;
            foreach (DetallesComprobantes detalleComprobante in comprobante.Items) {
                XmlNode linea = lineaTemplate.CloneNode(true);
				try
				{
					importeDescuento = (detalleComprobante.ImpUnitarioNeto * (comprobante.Descuento / 100));
					importeUnitarioConDescuento = detalleComprobante.ImpUnitarioNeto - importeDescuento;
					linea.Attributes[NumeroLinea].Value = XmlConvert.ToString(++numeroLinea);
					linea.RemoveChild(linea["GTIN"]);
					linea.RemoveChild(linea["codigo_producto_comprador"]);
					linea[CodigoInterno].InnerText = detalleComprobante.Producto.Identificacion;
					linea[Descripcion].InnerText = detalleComprobante.Producto.Nombre;
					linea[Cantidad].InnerText = XmlConvert.ToString(detalleComprobante.Cantidad);
					linea[Unidad].InnerText = "uni"; //TODO: ver si se puede mejorar
					//linea[ImporteUnitario].InnerText = importeUnitarioConDescuento.ToString("#0.#0");
					linea[ImporteUnitario].InnerText = detalleComprobante.ImpUnitarioNeto.ToString("#0.#0");
					linea[ImporteTotal].InnerText = (importeUnitarioConDescuento + (importeUnitarioConDescuento * detalleComprobante.TipoIva.Alicuota / 100)).ToString("#0.#0");
					linea["alicuota_iva"].InnerText = detalleComprobante.TipoIva.Alicuota.ToString("#0.#0");
					linea["importe_iva"].InnerText = (importeUnitarioConDescuento * detalleComprobante.TipoIva.Alicuota / 100).ToString("#0.#0");
					linea.RemoveChild(linea["indicacion_exento_gravado"]);
					linea["descuentos"].RemoveAll(); 
					linea.RemoveChild(linea["descuentos"]);
					linea["descuentos"].RemoveAll();
					linea.RemoveChild(linea["descuentos"]);
					linea["descuentos"].RemoveAll();
					linea.RemoveChild(linea["descuentos"]);
					linea["descuentos"].RemoveAll();
					linea.RemoveChild(linea["descuentos"]);
					if (comprobante.Descuento == 0)
					{
						linea["descuentos"].RemoveAll();
						linea.RemoveChild(linea["descuentos"]);
						linea.RemoveChild(linea["importe_totaldescuentos"]);
						
					}
					else {
						linea["descuentos"]["descripcion_descuento"].InnerText = "Descuento";
						linea["descuentos"]["porcentaje_descuento"].InnerText = comprobante.Descuento.ToString("#0.#0");
						linea["descuentos"]["importe_descuento"].InnerText = (importeDescuento * detalleComprobante.Cantidad).ToString("#0.#0");
						linea["descuentos"]["importe_descuento_moneda_origen"].InnerText = ((detalleComprobante.ImpUnitarioNeto * (comprobante.Descuento / 100)) * detalleComprobante.Cantidad).ToString("#0.#0");
						linea["importe_total_descuentos"].InnerText = (importeDescuento * detalleComprobante.Cantidad).ToString("#0.#0");
					}
					linea.RemoveChild(linea["impuestos"]);
					linea.RemoveChild(linea["impuestos"]);
					linea.RemoveChild(linea["impuestos"]);
					linea.RemoveChild(linea["impuestos"]);
					linea.RemoveChild(linea["impuestos"]);
					linea.RemoveChild(linea["importe_total_impuestos"]);
					linea.RemoveChild(linea["importes_moneda_origen"]);
					
					/* TODO VERO Sacar
					linea[PorcentajesImpuestos].InnerText = detalleComprobante.TipoIva.Alicuota.ToString("#0.#0");
					linea[PorcentajesImpuestos][CodigoImpuesto].InnerText = ""; //TODO: ver si tenemos que poner el codigo
					linea[PorcentajesImpuestos][PorcentajeImpuesto].InnerText = detalleComprobante.TipoIva.Alicuota.ToString("#0.#0");
					linea[Descuentos][PorcentajeDescuento].InnerText = ""; //TODO: ver como ponemos el descuento
					*/
					/*TODO: Ver si el Descuento se aplica a todos los items en otro lugar
					 */
					detalle.AppendChild(linea);
				}
				catch (Exception ex) {
					string err = ex.Message;
				}
            }
			comentarioNode.InnerText = comprobante.Observaciones;
			detalle.AppendChild(comentarioNode);
			//detalle["comentarios"].InnerText= comprobante.Observaciones;
        }

        private void CargarDatosResumen(XmlNode resumen) {
            #region Constants Node Names
			//const string ImporteBruto = "importe_total_factura";
			const string ImporteNeto = "importe_total_neto_gravado";
			const string ImporteTotal = "importe_total_factura";
            
            const string ImportesDescuentos = "importes_descuentos";
            const string CodigoDescuento = "codigo_descuento";
            const string Importe = "importe";

			const string ImportesImpuestos = "impuesto_liq";
            const string CodigoImpuesto = "codigo_impuesto";
            #endregion

            //resumen[ImporteBruto].InnerText = comprobante.Subtotal.ToString("#0.#0");
            resumen[ImporteNeto].InnerText = comprobante.SubtotalNeto.ToString("#0.#0");
            resumen[ImporteTotal].InnerText = comprobante.Total.ToString("#0.#0");
			resumen.RemoveChild(resumen["descuentos"]);
			resumen.RemoveChild(resumen["descuentos"]);
			resumen.RemoveChild(resumen["descuentos"]);
			resumen.RemoveChild(resumen["descuentos"]);
			resumen.RemoveChild(resumen["descuentos"]);
			resumen.RemoveChild(resumen["impuestos"]);
			resumen.RemoveChild(resumen["impuestos"]);
			resumen.RemoveChild(resumen["impuestos"]);
			resumen.RemoveChild(resumen["impuestos"]);
			resumen.RemoveChild(resumen["impuestos"]);
			/*resumen[ImportesDescuentos][CodigoDescuento].InnerText = ""; //TODO: ver si hay que poner un codigo de descuento
			resumen[ImportesDescuentos][Importe].InnerText = comprobante.Descuento.ToString("#0.#0");
			*/
            resumen[ImportesImpuestos].InnerText = (comprobante.Iva1 + comprobante.Iva2).ToString("#0.#0");
			resumen.RemoveChild(resumen["tipo_de_cambio"]);
			resumen["codigo_moneda"].InnerText = "PES";
			resumen.RemoveChild(resumen["observaciones"]);
			
        }
		private void CargarDatosExtensiones(XmlNode extensiones, XmlNode nodoLogo, XmlNode nodoUrl) {
			if (!String.IsNullOrEmpty(comprobante.Empresa.LogoEmpresaFileName))
			{
				//string nodos = "<logo>" + comprobante.Empresa.LogoEmpresaFileName + "</logo>";
				nodoLogo.InnerText = comprobante.Empresa.LogoEmpresaFileName;
				extensiones["extensiones_datos_marketing"].AppendChild(nodoLogo);
				if (!String.IsNullOrEmpty(comprobante.Empresa.SitioWeb))
				{
					//nodos += Environment.NewLine + "<url>" + comprobante.Empresa.SitioWeb + "</url>";
					nodoUrl.InnerText = comprobante.Empresa.SitioWeb;
					extensiones["extensiones_datos_marketing"].AppendChild(nodoUrl);
				}
				//extensiones["extensiones_datos_marketing"].InnerText = nodos;
			}
			else {
				//extensiones["extensiones_datos_marketing"].InnerText = "";
			}
		}
    }
}
