using System;
using System.Windows.Forms;

namespace FrameWork.CRUDModel.Windows.UI {
	/// <summary>
	/// Summary description for Messages.
	/// </summary>
	public class Messages {
		protected Messages() {
		}

		private static Messages instance = null;

		public static Messages Instance {
			get {
				if (instance == null) instance = new Messages();
				return instance;
			}
		}

		protected virtual string SaveBeforeExitMainMessageDefault {
			get { return "¿Desea grabar antes de salir?"; }
		}

		public virtual DialogResult SaveBeforeExit() {
			return SaveBeforeExit(SaveBeforeExitMainMessageDefault);
		}

		public virtual DialogResult SaveBeforeExit(string mainMessage) {
			return SaveBeforeExit(mainMessage, null);
		}

		public virtual DialogResult SaveBeforeExit(string mainMessage, string additionalInformation) {
			string message = String.Format("{0}\n{1}", mainMessage, additionalInformation);
			return MessageBox.Show(message, Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
		}

		protected virtual string SureToDeleteMainMessageDefault {
			get { return "¿Está seguro que desea eliminar?"; }
		}

		public virtual DialogResult SureToDelete() {
			return SureToDelete(SureToDeleteMainMessageDefault);
		}

		public virtual DialogResult SureToDelete(string mainMessage) {
			return SureToDelete(mainMessage, null);
		}

		public virtual DialogResult SureToDelete(string mainMessage, string additionalInformation) {
			string message = String.Format("{0}\n{1}", mainMessage, additionalInformation);
			return MessageBox.Show(message, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
		}

		protected virtual string CantDeleteMainMessageDefault {
			get { return "No puede borrar el registro."; }
		}

		public void CantDelete() {
			CantDelete(CantDeleteMainMessageDefault);
		}

		public void CantDelete(string mainMessage) {
			CantDelete(mainMessage, null);
		}

		public void CantDelete(string mainMessage, string additionalInformation) {
			string message = String.Format("{0}\n{1}", mainMessage, additionalInformation);
			MessageBox.Show(message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}
}