using System.Collections;

namespace FrameWork.DataBusinessModel {
	/// <summary>
	/// Summary description for cErrMessages.
	/// </summary>
	public class ErrorMessages {
		ArrayList arrMessages = new ArrayList();

		public ErrorMessages() {
			//
			// TODO: Add constructor logic here
			//
		}

		public void Add(string message) {
		    if((message!=null)&&(message.Trim().Length>0)) arrMessages.Add(message);
		}

		public void Clear() {
			arrMessages.Clear();
		}

		public string GetAllMessages() {
			string res = "";
			int ind;

			for (ind = 0; ind <= arrMessages.Count - 1; ind++)
				res = res + arrMessages[ind].ToString() + "\n";

			return res;
		}

		public int Count() {
			return arrMessages.Count;
		}
	}
}