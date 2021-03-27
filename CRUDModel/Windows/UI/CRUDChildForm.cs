using System;
using System.ComponentModel;
using FrameWork.DataBusinessModel.DataModel;

namespace FrameWork.CRUDModel.Windows.UI {
	/// <summary>
	/// Summary description for CRUDChildForm.
	/// </summary>
	public class CRUDChildForm : CRUDForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		protected Persistent persistentParent, persistentCopy;

		public CRUDChildForm() {
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing) {
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.Size = new System.Drawing.Size(300, 300);
			this.Text = "CRUDChildForm";
		}

		#endregion

		protected virtual void AssignToParent() {
			throw new NotImplementedException();
		}

		protected virtual void RemoveFromParent() {
			throw new NotImplementedException();
		}

		public void Open(CRUDAction action, Persistent persistentParent, Persistent persistent) {
			this.persistentParent = persistentParent;
			if ((action == CRUDAction.Update) && (persistent.Id == 0)) persistentCopy = persistent.Clone();
			this.Open(action, persistent);
		}

		protected override void FillObject() {
			base.FillObject();
			if (action == CRUDAction.Create) AssignToParent();
			else if (action == CRUDAction.Delete) RemoveFromParent();
		}

		private void UndoFillObject() {
			if (action == CRUDAction.Create) RemoveFromParent();
			else if (action == CRUDAction.Delete) AssignToParent();
			else if (action == CRUDAction.Update)
				if ((Persistent.Id == 0)) {
					RemoveFromParent();
					Persistent = persistentCopy;
					AssignToParent();
				}
		}

		protected override void CancelUpdate() {
			UndoFillObject();
			base.CancelUpdate();
		}

		protected override bool AcceptForm() {
			bool result = base.AcceptForm();
			if (!result) UndoFillObject();
			return result;
		}


		[Browsable(false)]
		public virtual Persistent PersistentParent {
			get { return persistent; }
			set { persistent = value; }
		}
	}
}