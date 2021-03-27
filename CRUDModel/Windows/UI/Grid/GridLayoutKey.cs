using System;
using System.Windows.Forms;
using Janus.Windows.GridEX;

namespace FrameWork.CRUDModel.Windows.UI.Grid {
	/// <summary>
	/// Summary description for GridLayoutKey.
	/// </summary>
	public class GridLayoutKey : IGridLayoutKey {
		private string keyValue;

		public GridLayoutKey(GridEX grid, Type type) {
			Form form = ParentForm(grid);

			keyValue = String.Format("{0}{1}{2}", form.GetType().Name, form.Text, type.Name);
		}

		private Form ParentForm(Control control) {
			if (control.Parent is Form) return (Form) control.Parent;
			else return ParentForm(control.Parent);
		}

		public string Value {
			get { return keyValue; }
		}
	}
}