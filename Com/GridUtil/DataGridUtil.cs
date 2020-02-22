using System;
using System.Web.UI.WebControls;

namespace Com.GridUtil
{
	/// <summary>
	/// DataGridUtil 的摘要说明。
	/// </summary>
	public class DataGridUtil
	{
		public DataGridUtil()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public static string GetValueFromDataGridByText(DataGrid DbGrid, string FieldName)
		{
			for (int num1 = 0; num1 < DbGrid.Columns.Count; num1++)
			{
				if (DbGrid.Columns[num1] is BoundColumn)
				{
					BoundColumn column1 = (BoundColumn) DbGrid.Columns[num1];
					if (column1.DataField.ToLower() == FieldName.ToLower())
					{
						return DbGrid.SelectedItem.Cells[num1].Text;
					}
				}
			}
			return "";
		}
 
		public static void SetDataGridCellAttribute(DataGridItemEventArgs e)
		{
			for (int num1 = 0; num1 < e.Item.Cells.Count; num1++)
			{
				e.Item.Cells[num1].Wrap = false;
			}
		}
 

	}
}
