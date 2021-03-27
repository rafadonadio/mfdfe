namespace FrameWork.CRUDModel.Windows.UI.Grid {
	/// <summary>
	/// Summary description for IGridForm.
	/// </summary>
	public interface IGridForm : IGridControl {
		event PersistLayoutEvent LoadLayout , SaveLayout;
        event FormLayoutEvent LoadFormLayout, SaveFormLayout;
	}
}