using System;
using System.Collections;
using Janus.Windows.GridEX;
//using Excel;

namespace FrameWork.CRUDModel.Windows.UI.Grid {
	/// <summary>
	/// Summary description for GridHelper.
	/// </summary>
	public class GridUtils {
		public GridUtils() {
		}

		public static void ExportToExcel(GridEX grid) {
//			ApplicationClass xls=new ApplicationClass();
//			Workbook wkb=xls.Workbooks.Add(Type.Missing);
//			Worksheet wks=(Worksheet) wkb.ActiveSheet;
//
//			int row=1;
//			int col=1;
//
//			((Range) wks.Cells[row,col]).Value2="Titulo";
//
//			row++;
//			col=1;
//			IList usedColumns=new ArrayList();
//			//Export the captions of the columns
//			foreach(GridEXColumn column in grid.RootTable.Columns)
//				if(column.Visible) {
//					((Range)wks.Cells[row,col++]).Value2=column.Caption;
//					usedColumns.Add(column);
//				}
//			
//			//Export the values of the columns
//			foreach(GridEXRow gridRow in grid.GetRows()) {
//				row++;
//				col=1;
//				foreach(GridEXColumn column in usedColumns)
//					((Range)wks.Cells[row,col++]).Value2=gridRow.Cells[column].Value;
//			}
//
//			FormatWorksheet(wks, grid.RowCount, usedColumns.Count, 1, 2);
//			xls.Visible=true;
		}

		protected static void FormatWorksheet( /*Worksheet*/ object worksheet, int dataRows, int dataColumns, int titleRow, int columnHeadersRow) {
//			Excel.Range range;
//			int lastRow=columnHeadersRow+dataRows;
//
//			worksheet.Columns.AutoFit();
//
//			range=worksheet.get_Range(worksheet.Cells[titleRow,1],worksheet.Cells[lastRow,dataColumns]);
//			range.Borders[XlBordersIndex.xlInsideHorizontal].Weight=range.Borders[XlBordersIndex.xlInsideVertical].Weight=XlBorderWeight.xlThin;
//			range.Borders[XlBordersIndex.xlEdgeBottom].Weight=range.Borders[XlBordersIndex.xlEdgeTop].Weight=
//				range.Borders[XlBordersIndex.xlEdgeLeft].Weight=range.Borders[XlBordersIndex.xlEdgeRight].Weight=
//				XlBorderWeight.xlMedium;
//
//			range=worksheet.get_Range(worksheet.Cells[titleRow,1],worksheet.Cells[titleRow,dataColumns]);
//			range.Merge(Type.Missing);
//			range.HorizontalAlignment=XlHAlign.xlHAlignCenter;
//			range.Font.Bold=true;
//
//			range=worksheet.get_Range(worksheet.Cells[columnHeadersRow,1],worksheet.Cells[columnHeadersRow,dataColumns]);
//			range.HorizontalAlignment=XlHAlign.xlHAlignCenter;
//			range.Font.Bold=range.Font.Italic=true;
//			range.Borders[XlBordersIndex.xlEdgeBottom].Weight=range.Borders[XlBordersIndex.xlEdgeTop].Weight=
//				range.Borders[XlBordersIndex.xlEdgeLeft].Weight=range.Borders[XlBordersIndex.xlEdgeRight].Weight=
//				XlBorderWeight.xlMedium;
		}

		public enum ColumnType {
			Void,
			Text,
			Numeric,
			DateTime,
			DataObject
		} ;

		public static ColumnType ToColumnType(Type type) {
			ColumnType result = ColumnType.Void;
			if (type == typeof (int) || type == typeof (Int16) || type == typeof (Int32) || type == typeof (Int64) ||
				type == typeof (UInt16) || type == typeof (UInt32) || type == typeof (UInt64) ||
				type == typeof (Double) || type == typeof (Single))
				result = ColumnType.Numeric;
			else if (type == typeof (string) || type == typeof (String))
				result = ColumnType.Text;
			else if (type == typeof (DateTime) || type == typeof (TimeSpan))
				result = ColumnType.DateTime;
			else result = ColumnType.DataObject;
			return result;
		}

		public static NumericEditValueType ToNumericEditValueType(Type type) {
			NumericEditValueType result = NumericEditValueType.Int32;
			if (type == typeof (Byte)) result = NumericEditValueType.Byte;
			else if (type == typeof (Decimal)) result = NumericEditValueType.Decimal;
			else if (type == typeof (Double)) result = NumericEditValueType.Double;
			else if (type == typeof (Int16)) result = NumericEditValueType.Int16;
			else if (type == typeof (Int32)) result = NumericEditValueType.Int32;
			else if (type == typeof (Int64)) result = NumericEditValueType.Int64;
			else if (type == typeof (SByte)) result = NumericEditValueType.SByte;
			else if (type == typeof (Single)) result = NumericEditValueType.Single;
			else if (type == typeof (UInt16)) result = NumericEditValueType.UInt16;
			else if (type == typeof (UInt32)) result = NumericEditValueType.UInt32;
			else if (type == typeof (UInt64)) result = NumericEditValueType.UInt64;
			return result;
		}

		public static string FilterConditionToString(GridEXFilterCondition condition) {
			string result = null;

			if (condition != null) {
				if (condition.IsComposite) {
					string operatorText;
					if (condition.Conditions.Count > 1)
						operatorText = condition.Conditions[1].LogicalOperator.ToString();
					else operatorText = condition.Conditions[0].LogicalOperator.ToString();

					result = "( ";
					result += FilterConditionToString(condition.Conditions[0]);
					for (int i = 1; i < condition.Conditions.Count; i++)
						result += " " + operatorText + " " + FilterConditionToString(condition.Conditions[i]);
					result += " )";
				}
				else {
					if (condition.Column != null)
						result = "([" + condition.Column.Caption + "] " + FilterOperatorListItem.FilterOperatorLabel(condition.ConditionOperator) + " " + condition.Value1.ToString() + ")";
					else result = "[VACIO]";
				}
			}

			return result;
		}
	}

	#region FilterOperatorListItem 

	class FilterOperatorListItem {
		string _label;
		ConditionOperator _operator;

		public static string FilterOperatorLabel(ConditionOperator operat) {
			string result = Convert.ToString(operat);
			switch (operat) {
				case ConditionOperator.BeginsWith:
					result = "Empieza con";
					break;
				case ConditionOperator.Between:
					result = "Entre";
					break;
				case ConditionOperator.Contains:
					result = "Contiene";
					break;
				case ConditionOperator.EndsWith:
					result = "Termina con";
					break;
				case ConditionOperator.Equal:
					result = "=";
					break;
				case ConditionOperator.GreaterThan:
					result = ">";
					break;
				case ConditionOperator.GreaterThanOrEqualTo:
					result = ">=";
					break;
				case ConditionOperator.IsEmpty:
					result = "Está vacio";
					break;
				case ConditionOperator.IsNull:
					result = "Es nulo";
					break;
				case ConditionOperator.LessThan:
					result = "<";
					break;
				case ConditionOperator.LessThanOrEqualTo:
					result = "<=";
					break;
				case ConditionOperator.NotBetween:
					result = "No entre";
					break;
				case ConditionOperator.NotContains:
					result = "No contiene";
					break;
				case ConditionOperator.NotEqual:
					result = "<>";
					break;
				case ConditionOperator.NotIsEmpty:
					result = "No está vacio";
					break;
				case ConditionOperator.NotIsNull:
					result = "No es nulo";
					break;
			}
			return result;
		}

		private FilterOperatorListItem(ConditionOperator operat) {
			_label = FilterOperatorLabel(operat);
			_operator = operat;
			Items.Add(this);
		}

		protected static IList _items = new ArrayList();

		public static IList Items {
			get { return _items; }
		}

		public string Label {
			get { return _label; }
		}

		public ConditionOperator Operator {
			get { return _operator; }
		}

		private static FilterOperatorListItem _equal = new FilterOperatorListItem(ConditionOperator.Equal);

		public static FilterOperatorListItem Equal {
			get { return _equal; }
		}

		private static FilterOperatorListItem _notEqual = new FilterOperatorListItem(ConditionOperator.NotEqual);

		public static FilterOperatorListItem NotEqual {
			get { return _notEqual; }
		}

		private static FilterOperatorListItem _greaterThan = new FilterOperatorListItem(ConditionOperator.GreaterThan);

		public static FilterOperatorListItem GreaterThan {
			get { return _greaterThan; }
		}

		private static FilterOperatorListItem _greaterThanOrEqualTo = new FilterOperatorListItem(ConditionOperator.GreaterThanOrEqualTo);

		public static FilterOperatorListItem GreaterThanOrEqualTo {
			get { return _greaterThanOrEqualTo; }
		}

		private static FilterOperatorListItem _lessThan = new FilterOperatorListItem(ConditionOperator.LessThan);

		public static FilterOperatorListItem LessThan {
			get { return _lessThan; }
		}

		private static FilterOperatorListItem _lessThanOrEqualTo = new FilterOperatorListItem(ConditionOperator.LessThanOrEqualTo);

		public static FilterOperatorListItem LessThanOrEqualTo {
			get { return _lessThanOrEqualTo; }
		}

		private static FilterOperatorListItem _contains = new FilterOperatorListItem(ConditionOperator.Contains);

		public static FilterOperatorListItem Contains {
			get { return _contains; }
		}

		private static FilterOperatorListItem _beginsWith = new FilterOperatorListItem(ConditionOperator.BeginsWith);

		public static FilterOperatorListItem BeginsWith {
			get { return _beginsWith; }
		}

		private static FilterOperatorListItem _endsWith = new FilterOperatorListItem(ConditionOperator.EndsWith);

		public static FilterOperatorListItem EndsWith {
			get { return _endsWith; }
		}
	}

	#endregion
}