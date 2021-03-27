using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FrameWork.CRUDModel.Windows.UI {
    public interface IFormLayoutManager {
        void Save(Form form);
        void Load(Form form);
    }
    public delegate void FormLayoutEvent(Form form);
}
