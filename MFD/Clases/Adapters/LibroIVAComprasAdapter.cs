using System;
using System.Text;
using Entities;

namespace MFD.Clases.Adapters {
    class LibroIVAComprasAdapter {
        protected LibroIVACompras libroIVACompras;

        public LibroIVAComprasAdapter(LibroIVACompras libroIVACompras) {
            this.libroIVACompras = libroIVACompras;
        }

        public string GetLibroComprasAFIPStream() {
            StringBuilder builder = new StringBuilder();

            foreach (RegistroLibroIVACompras registro in libroIVACompras.Registros)
                builder.AppendLine(GetRegistro1LibroComprasAFIPStream(registro));

            builder.AppendLine(GetRegistro2LibroComprasAFIPStream());

            return builder.ToString();
        }

        protected string GetRegistro1LibroComprasAFIPStream(RegistroLibroIVACompras registro) {
            StringBuilder result = new StringBuilder();
            //Campo 1: Tipo de registro
            result.Append("1");
            //Campo 2: Fecha del comprobante
            result.Append(FieldFormatter.Instance.FormatDate(registro.FechaComprobante));
            //Campo 3: Tipo de Comprobante
            result.Append(registro.TipoComprobante.Substring(0, 2));
            //Campo 4: Controlador Fiscal 
            result.Append(" ");
            //Campo 5: Punto de Venta
            result.Append(registro.PuntoVenta.Substring(0, 4).PadLeft(4, '0'));
            //Campo 6: Número de Comprobante
            result.Append(registro.NumeroComprobante.Substring(0, 8).PadLeft(20, '0'));
            //Campo 7: Fecha Registracion Contable ???
            result.Append(FieldFormatter.Instance.FormatDate(registro.FechaComprobante));
            //Campo 8: Codigo de Aduana
            result.Append(FieldFormatter.Instance.FormatInt(registro.CodigoAduana, 2).PadLeft(3, '0'));
            if (registro.Importacion)
            {
                //Campo 9: Código de destinación
                result.Append(registro.CodigoDestinacion.PadLeft(4));
                //Campo 10: Número de despacho
                result.Append(registro.NumeroDespacho.PadLeft(6, '0')); 
                //Campo 11: Dígito verificador del número de despacho
                result.Append(registro.DigitoVerificadorNumeroDespacho.ToString());
            }
            else {
                //Campos 9 a 11 en blanco
                result.Append(FieldFormatter.Instance.Spaces(11)); 
            }
            //Campo 12: Código de documento identificatorio del Vendedor
            result.Append(GeneralSettings.Instance.CodigoCUIT.Substring(0, 2));
            //Campo 13: Número de identificación del vendedor
            result.Append(registro.CUITProveedor.Replace("-", "").PadLeft(11));
            //Campo 14: Apellido y nombres o denominación del vendedor
            result.Append(registro.NombreProveedor.PadRight(30));
            //Campo 15: Importe total de la operación
            result.Append(registro.ImporteTotal.ToString("#0.#0").Replace(".", "").Replace(",", "").PadLeft(15, '0'));
            //Campo 16: Importe total de conceptos que no integran el precio neto gravado
            result.Append(registro.ImporteNetoNoGravado.ToString("#0.#0").Replace(".", "").Replace(",", "").PadLeft(15, '0'));
            //Campo 17: Importe Neto Gravado
            result.Append(registro.ImporteNetoGravado.ToString("#0.#0").Replace(".", "").Replace(",", "").PadLeft(15, '0'));
            //Campo 18: Alícuota de IVA
            result.Append(registro.AlicuotaIVA.ToString("#0.#0").Replace(".", "").Replace(",", "").PadRight(4, '0'));
            //Campo 19: Impuesto liquidado
            result.Append(registro.ImpuestoLiquidado.ToString("#0.#0").Replace(".", "").Replace(",", "").PadLeft(15, '0'));
            //Campo 20: Importe de operaciones exentas
            result.Append(registro.ImporteOperacionesExentas.ToString("#0.#0").Replace(".", "").Replace(",", "").PadLeft(15, '0'));
            //Campo 21: Importe de percepciones o pagos a cuenta de impuestos nacionales
            result.Append("000000000000000");
            //Campo 22: Importe de percepciones o pagos a cuenta de otros impuestos nacionales
            result.Append(registro.ImportePercepcionesNacionales.ToString("#0.#0").Replace(".", "").Replace(",", "").PadLeft(15, '0'));
            //Campo 23: Importe de percepciones de Ingresos Brutos
            result.Append(registro.ImportePercepcionesIngresosBrutos.ToString("#0.#0").Replace(".", "").Replace(",", "").PadLeft(15, '0'));
            //Campo 24: Importe de percepciones de Impuestos Municipales
            result.Append(registro.ImportePercepcionesMunicipales.ToString("#0.#0").Replace(".", "").Replace(",", "").PadLeft(15, '0'));
            //Campo 25: Importe de Impuestos Internos
            result.Append(registro.ImporteImpuestosInternos.ToString("#0.#0").Replace(".", "").Replace(",", "").PadLeft(15, '0'));
            //Campo 26: Tipo de responsable
            result.Append(registro.TipoProveedor.Substring(0, 2).PadLeft(2));
            //Campo 27: Código de Moneda
            result.Append(GeneralSettings.Instance.CodigoMoneda.Substring(0, 3).PadLeft(3));
            //Campo 28: Tipo de Cambio
            result.Append("0001000000");
            //Campo 29: Cantidad de alícuotas de IVA
            result.Append(registro.CantidadAlicuotas); 
            //Campo 30: Código de operación
            result.Append(FieldFormatter.Instance.Spaces(1));
            //Campo 31: CAI
            result.Append((registro.CAI.Length>14)? registro.CAI.Substring(0, 14) : registro.CAI.PadLeft(14, '0')); 
            //Campo 32: Fecha de vencimiento del  C.A.I. o  C.A.E.
            result.Append(FieldFormatter.Instance.FormatDate(registro.FechaVencimientoCAI));
            //Campo 33: Información Adicional
            result.Append(FieldFormatter.Instance.Spaces(75)); 
            return result.ToString();
        }
        protected string GetRegistro2LibroComprasAFIPStream() {
            StringBuilder result = new StringBuilder();
            //Campo 1: Tipo de Registro
            result.Append("2");
            //Campo 2: Período
            result.Append(FieldFormatter.Instance.FormatInt(libroIVACompras.Anio, 4) + FieldFormatter.Instance.FormatInt(libroIVACompras.Mes, 2));
            //Campo 3: Relleno
            result.Append(FieldFormatter.Instance.Spaces(10));
            //Campo 4: Cantidad de Registros de tipo 1
            result.Append(libroIVACompras.Registros.Count.ToString().PadLeft(12,'0'));
            //Campo 5: Relleno
            result.Append(FieldFormatter.Instance.Spaces(31));
            //Campo 6: CUIT del informante
            result.Append(libroIVACompras.Empresa.Cuit.Replace("-", "").PadLeft(11));
            //Campo 7: Relleno
            result.Append(FieldFormatter.Instance.Spaces(30));
            //Campo 8: Importe total de la operación
            result.Append(FieldFormatter.Instance.FormatDouble(libroIVACompras.ImporteTotal));
            //Campo 9: Importe total de conceptos que no integran el precio neto gravado
            result.Append(FieldFormatter.Instance.FormatDouble(libroIVACompras.ImporteNetoNoGravado));
            //Campo 10: Importe Neto Gravado
            result.Append(FieldFormatter.Instance.FormatDouble(libroIVACompras.ImporteNetoGravado));
            //Campo 11: Relleno
            result.Append(FieldFormatter.Instance.Spaces(4));
            //Campo 12: Impuesto liquidado
            result.Append(FieldFormatter.Instance.FormatDouble(libroIVACompras.ImpuestoLiquidado));
            //Campo 13: Importe de operaciones exentas
            result.Append(FieldFormatter.Instance.FormatDouble(libroIVACompras.ImporteOperacionesExentas));
            //Campo 14: Importe de percepciones o pagos a cuenta de impuestos nacionales
            result.Append("000000000000000");
            //Campo 15: Importe de percepciones o pagos a cuenta de impuestos nacionales
            result.Append(FieldFormatter.Instance.FormatDouble(libroIVACompras.ImportePercepcionesNacionales));
            //Campo 16: Importe de percepciones de Ingresos Brutos
            result.Append(FieldFormatter.Instance.FormatDouble(libroIVACompras.ImportePercepcionesIngresosBrutos));
            //Campo 17: Importe de percepciones de Impuestos Municipales
            result.Append(FieldFormatter.Instance.FormatDouble(libroIVACompras.ImportePercepcionesMunicipales));
            //Campo 18: Importe de Impuestos Internos
            result.Append(FieldFormatter.Instance.FormatDouble(libroIVACompras.ImporteImpuestosInternos));
            //Campo 19: Relleno
            result.Append(FieldFormatter.Instance.Spaces(114));
            return result.ToString();
        }
    }
}
