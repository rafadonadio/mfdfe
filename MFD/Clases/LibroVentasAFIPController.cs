using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using BusinessLogic;
using Entities;

namespace MFD.Clases
{
    class LibroVentasAFIPController {
        private ComprobantesBL comprobantesBL;
        private EmpresasBL empresasBL;
        public LibroVentasAFIPController(ComprobantesBL comprobantesBL, EmpresasBL empresasBL) {
            this.comprobantesBL = comprobantesBL;
            this.empresasBL = empresasBL;
        }

        public void Generar() {
            MesYEmpresa form=new MesYEmpresa();
            form.Exit+=new MesYEmpresa.ExitMesYEmpresaEvent(Emitir);
            form.PropertyValueListNeeded += new FrameWork.CRUDModel.Windows.UI.PropertyValueListNeeded(form_PropertyValueListNeeded);
            form.Open("Generar Libro IVA Ventas AFIP");
        }

        IList form_PropertyValueListNeeded(string propertyName, FrameWork.DataBusinessModel.DataModel.Persistent persistentObject) {
            IList result = null;
            if (propertyName == "Empresa") result = empresasBL.GetDataSource();
            return result;
        }
        
        private void Emitir(Empresas empresa, int anio, int mes) {
            String fileName = GetFolder()+comprobantesBL.GetFileNameVentas(empresa, anio, mes);
			TextWriter tw = new StreamWriter(fileName, false, Encoding.Default);
            
            tw.Write(comprobantesBL.GetStreamVentas(empresa, anio, mes));
            tw.Close();
            tw.Dispose();
        }

        private string GetFolder() {
			DirectoryInfo folderInfo = new DirectoryInfo(GeneralSettings.Instance.FilesFolder + @"\VENTAS");
			if (!folderInfo.Exists)
			{
				folderInfo.Create();
			}
			return folderInfo.FullName + @"\";
        }
    }
}
