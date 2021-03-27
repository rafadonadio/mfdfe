namespace FrameWork.CRUDModel.Windows.UI.Grid {
	public interface IGridControl {
		event ResetLayoutEvent ResetLayout;
		void SetDataSource(object dataSource, bool retrieveStructure);
		void RefreshDataSource();
	}
}