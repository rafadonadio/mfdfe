using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using FrameWork.DataBusinessModel.DataModel;
using Janus.Windows.GridEX;

namespace FrameWork.CRUDModel.Windows.UI.Grid {
	/// <summary>
	/// Summary description for GridLayoutManager.
	/// </summary>
	public class GridLayoutManager : IGridLayoutManager {
		private string path;
		private MD5 md5;

		private GridLayoutManager() {
			md5 = MD5.Create();
			Path = ".\\";
		}

		private static GridLayoutManager instance = null;

		public static GridLayoutManager Instance {
			get {
				if (instance == null) instance = new GridLayoutManager();
				return instance;
			}
		}

		public string Path {
			get { return path; }
			set { path = value; }
		}

		private string KeyString(IGridLayoutKey key) {
			byte[] inputBytes = Encoding.ASCII.GetBytes(key.Value);
			byte[] hash = md5.ComputeHash(inputBytes);

			StringBuilder sb = new StringBuilder();
			foreach (byte b in hash) sb.Append(b.ToString("X2"));

			return sb.ToString();
		}

		private string LayoutFileName(IGridLayoutKey key) {
			return String.Format("{0}{1}.GridLayout.xml", Path, KeyString(key));
		}

		private class Comparer : IComparer {
			public int Compare(object x, object y) {
				int result = 1;
				if ((x is ColumnAttributes) && (y is ColumnAttributes)) result = (x as ColumnAttributes).CompareTo(y);
				else if ((x is ColumnAttributes) && (y is SortKeyAttributes)) result = -1;
				else if ((x is SortKeyAttributes) && (y is ColumnAttributes)) result = 1;
				else if ((x is SortKeyAttributes) && (y is SortKeyAttributes)) result = (x as SortKeyAttributes).CompareTo(y);
				return result;
			}
		}

		private ColumnType GetColumnType(PropertyInfo property) {
			ColumnType result = ColumnType.Text;

			if (property != null) {
				if (property.PropertyType == typeof (bool)) result = ColumnType.CheckBox;
				else if (property.PropertyType == typeof (Image)) result = ColumnType.BoundImage;
			}

			return result;
		}

		public void Reset(GridEX grid, Type type) {
			GridEXColumn column;
			Attribute[] attributes;
            ArrayList columnAttributes = new ArrayList() ;
            ArrayList sortKeyAttributes = new ArrayList();


			grid.RootTable.Columns.Clear();
			grid.RootTable.SortKeys.Clear();
			attributes = Attribute.GetCustomAttributes(type);

            foreach (Attribute attribute in attributes)
            {
                if (attribute is ColumnAttributes)
                    columnAttributes.Add(attribute);
                else if (attribute is SortKeyAttributes)
                    sortKeyAttributes.Add(attribute);
            }

            
            columnAttributes.Sort();

			foreach (Attribute columnAttribute in columnAttributes) {
				if (columnAttribute is ColumnAttributes) {
					column = grid.RootTable.Columns.Add(((ColumnAttributes) columnAttribute).Name,
					                                    GetColumnType(type.GetProperty(((ColumnAttributes) columnAttribute).Name)));
                    
                    column.Visible = ((ColumnAttributes) columnAttribute).Visible;
					column.Caption = ((ColumnAttributes) columnAttribute).Caption;
					column.Width = ((ColumnAttributes) columnAttribute).Width;
					column.Position = ((ColumnAttributes) columnAttribute).Index;
                    column.FormatString = ((ColumnAttributes)columnAttribute).Format ;
				    if(column.ColumnType==ColumnType.BoundImage) {
				        column.BoundImageSize=new Size(64,64);
                        column.AllowSort = column.AllowSize = false;
                        column.TextAlignment = TextAlignment.Center;
				    }
                }
            }
            foreach (Attribute columnAttribute in sortKeyAttributes) {
				if (columnAttribute is SortKeyAttributes) {
					column = grid.RootTable.Columns[((SortKeyAttributes) columnAttribute).Name];
					SortOrder sortOrder = (((SortKeyAttributes) columnAttribute).Ascending) ? SortOrder.Ascending : SortOrder.Descending;
					grid.RootTable.SortKeys.Add(new GridEXSortKey(column, sortOrder));
				}
			}
		}

		public void Save(GridEX grid, IGridLayoutKey key) {
			Stream stream = new FileStream(LayoutFileName(key), FileMode.Create);
			grid.SaveLayoutFile(stream);
			stream.Close();
		}

		public void Load(GridEX grid, IGridLayoutKey key) {
			try {
				Stream stream = new FileStream(LayoutFileName(key), FileMode.Open);
				grid.LoadLayoutFile(stream);
				stream.Close();
			}
			catch (FileNotFoundException) {
			}
		}
	}
}