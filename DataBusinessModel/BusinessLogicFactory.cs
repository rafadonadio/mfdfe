using System;
using System.Reflection;
using FrameWork.DataBusinessModel.BusinessModel;

namespace FrameWork.DataBusinessModel {
	/// <summary>
	/// Summary description for BusinessLogicFactory.
	/// </summary>
	public class BusinessLogicFactory {
		private static Type[] types = {typeof (DBase)};

		public static BusinessLogic GetBusinessLogicInstance(DBase db, Type businessLogicType) {
			BusinessLogic result = null;
			object[] parameters = {db};

			ConstructorInfo constructor = businessLogicType.GetConstructor(types);
			if (constructor != null) result = (BusinessLogic) constructor.Invoke(parameters);
			else {
				result = (BusinessLogic) Activator.CreateInstance(businessLogicType);
				result.SetParameters(db);
			}
			return result;
		}
	}
}