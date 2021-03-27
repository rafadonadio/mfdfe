using System;
using System.Collections;
using System.Windows.Forms;
using FrameWork.DataBusinessModel;
using FrameWork.DataBusinessModel.DataModel;

namespace FrameWork.CRUDModel.Windows.UI {
	/// <summary>
	/// Summary description for ICRUDForm.
	/// </summary>
	public interface ICRUDForm : IDisposable {
		ErrorMessages ErrorMessages { get; }
		void Show();
        
		void BringToFront();
		event CRUDActionDone CRUDActionDone;
		event UpdateCancelled UpdateCancelled;
		event ExitEvent Exit;
        event PropertyValueListNeeded PropertyValueListNeeded;
        event FormLayoutEvent LoadFormLayout, SaveFormLayout;
		string Title { get; set; }
		Form MdiParent { get; set; }
	}

    public delegate void ActionNeeded(Persistent persistentObject);
	
    public delegate void UpdateCancelled(Persistent persistentObject);

	public delegate bool CRUDActionDone(ICRUDForm sender, CRUDAction action, Persistent persistentObject);

	public delegate void ExitEvent(Form sender);

    public delegate IList PropertyValueListNeeded(string propertyName, Persistent persistentObject);

}