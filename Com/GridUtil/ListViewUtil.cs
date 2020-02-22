using System;
using System.Data;
using System.Windows.Forms;

namespace Com.GridUtil
{
	/// <summary>
	/// ListViewUtil 的摘要说明。
	/// </summary>
	public class ListViewUtil
	{
		public ListViewUtil()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public static void SetListViewByDataSet(ListView InitListView, DataSet Ds)
		{
			InitListView.Items.Clear();
			for (int num1 = 0; num1 < Ds.Tables[0].Rows.Count; num1++)
			{
				DataRow row1 = Ds.Tables[0].Rows[num1];
				ListViewItem item1 = new ListViewItem();
				for (int num2 = 1; num2 < InitListView.Columns.Count; num2++)
				{
					string text1 = InitListView.Columns[num2].GetType().Name;
					item1.SubItems.Add(row1[text1].ToString());
				}
				InitListView.Items.Add(item1);
			}
		}
 

	}
}
