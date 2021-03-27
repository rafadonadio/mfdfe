using System;
using Janus.Windows.GridEX;

namespace FrameWork.CRUDModel.Windows.UI.Grid {
	/// <summary>
	/// Summary description for IGridLayoutManager.
	/// </summary>
	public interface IGridLayoutManager {
		void Reset(GridEX grid, Type type);
		void Save(GridEX grid, IGridLayoutKey key);
		void Load(GridEX grid, IGridLayoutKey key);
	}

	public delegate void PersistLayoutEvent(GridEX grid);

	public delegate void ResetLayoutEvent(GridEX grid, Type type);
}