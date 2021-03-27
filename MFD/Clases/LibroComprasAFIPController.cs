using System;
using System.Collections;
using System.IO;
using System.Text;
using BusinessLogic;
using Entities;
using MFD.Clases.Adapters;

namespace MFD.Clases {
    class LibroComprasAFIPController {
        private LibroIVAComprasBL libroIVAComprasBL;
        private EmpresasBL empresasBL;

        public LibroComprasAFIPController(ComprobantesComprasBL comprobantesComprasBL, EmpresasBL empresasBL) {
            libroIVAComprasBL = new LibroIVAComprasBL(comprobantesComprasBL);
            this.empresasBL = empresasBL;
        }

        public void Generar() {
            MesYEmpresa form=new MesYEmpresa();
            form.Exit+=new MesYEmpresa.ExitMesYEmpresaEvent(Emitir);
            form.PropertyValueListNeeded += new FrameWork.CRUDModel.Windows.UI.PropertyValueListNeeded(form_PropertyValueListNeeded);
            form.Open("Generar Libro IVA Compras AFIP");
        }

        IList form_PropertyValueListNeeded(string propertyName, FrameWork.DataBusinessModel.DataModel.Persistent persistentObject) {
            IList result = null;
            if (propertyName == "Empresa") result = empresasBL.GetDataSource();
            return result;
        }
        
        private void Emitir(Empresas empresa, int anio, int mes) {
            LibroIVACompras libroIVACompras = libroIVAComprasBL.GetLibroIVACompras(empresa, anio, mes);
            String fileName = GetFolder()+libroIVAComprasBL.GetFileName(libroIVACompras);

			TextWriter tw = new StreamWriter(fileName, false, Encoding.Default);

            tw.Write(new LibroIVAComprasAdapter(libroIVACompras).GetLibroComprasAFIPStream());
            tw.Close();
            tw.Dispose();
        }

        private string GetFolder() {
			DirectoryInfo folderInfo = new DirectoryInfo(GeneralSettings.Instance.FilesFolder + @"\COMPRAS");
			if (!folderInfo.Exists)
			{
				folderInfo.Create();
			}
			return folderInfo.FullName + @"\";
        }
    }
}
