using System;
using System.Collections;
using System.Windows.Forms;
using FrameWork.DataBusinessModel.BusinessModel;
using FrameWork.DataBusinessModel.DataModel;

namespace FrameWork.DataBusinessModel.DataModel
{
    public interface IFiltrable
    {
        void SetFilterObject(Persistent filterObject);
    }
}
