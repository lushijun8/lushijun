using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

namespace Com.UserControl
{
	/// <summary>
	/// WebDataGrid 的摘要说明。
	/// </summary>
	public class WebDataGrid: CommonUserControl
	{
		public bool AllowPaging;
		public bool AllowSorting;
		public DataSet DataSource;
		public string[] HeaderText;
		public int IdColNumber;
		public bool IsMultiBreak;
		public int MultiNumber;
		public bool NeedSelectCol;
		public int PageIndex;
		public int PageSize;
		public string SelectedItem;
		public int SelectedPage;
		public int SelectedRow;
		public string SortExpression;

		public WebDataGrid()
		{
			this.AllowPaging = true;
			this.AllowSorting = true;
			this.IdColNumber = 1;
			this.IsMultiBreak = false;
			this.MultiNumber = 1;
			this.NeedSelectCol = true;
			this.PageIndex = 1;
			this.PageSize = 10;
			this.SelectedItem = "";
			this.SelectedPage = 0;
			this.SelectedRow = 1;
			this.SortExpression = "";
		}
		protected override void CreateChildControls()
		{
			DataGrid grid1 = new DataGrid();
			base.SetControlStyle(grid1, this.style);
			grid1.AllowPaging = this.AllowPaging;
			if (this.AllowPaging)
			{
				grid1.PageSize = this.PageSize;
				grid1.PagerStyle.PrevPageText = "\u4e0a\u4e00\u9875";
				grid1.PagerStyle.NextPageText = "\u4e0b\u4e00\u9875";
				grid1.PagerStyle.Mode = PagerMode.NextPrev;
				grid1.PagerStyle.HorizontalAlign = HorizontalAlign.Center;
			}
			grid1.AllowSorting = this.AllowSorting;
			grid1.AlternatingItemStyle.CssClass = "gridEvenRow";
			grid1.SelectedItemStyle.CssClass = "gridSelectedHighlight";
			grid1.ItemStyle.BorderStyle = BorderStyle.Solid;
			grid1.ItemStyle.CssClass = "gridOddRow";
			grid1.HeaderStyle.CssClass = "gridHead";
			grid1.FooterStyle.CssClass = "gridFooter";
			grid1.CellPadding = 3;
			grid1.AutoGenerateColumns = false;
			grid1.GridLines = GridLines.Vertical;
			grid1.BorderColor = Color.Black;
			grid1.BorderStyle = BorderStyle.None;
			grid1.BackColor = Color.White;
			grid1.BorderWidth = Unit.Pixel(1);
			if (this.NeedSelectCol)
			{
				ButtonColumn column1 = new ButtonColumn();
				column1.Text = "\u9009\u62e9";
				column1.CommandName = "Select";
				column1.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
				grid1.Columns.Add(column1);
			}
			if (this.HeaderText.Length == this.DataSource.Tables[0].Columns.Count)
			{
				for (int num1 = 0; num1 < this.HeaderText.Length; num1++)
				{
					BoundColumn column2 = new BoundColumn();
					column2.HeaderText = this.HeaderText[num1];
					column2.DataField = this.DataSource.Tables[0].Columns[num1].ColumnName;
					column2.SortExpression = column2.DataField;
					if (this.DataSource.Tables[0].Columns[num1].DataType.Name == "DateTime")
					{
						column2.DataFormatString = "{0:D}";
					}
					column2.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
					grid1.Columns.Add(column2);
				}
			}
			grid1.SelectedIndexChanged += new EventHandler(this.DataGridSelectedIndexChanged);
			grid1.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridPageIndexChanged);
			grid1.SortCommand += new DataGridSortCommandEventHandler(this.DataGridSortCommand);
			grid1.CurrentPageIndex = this.PageIndex;
			grid1.DataSource = this.DataSource;
			if (this.SelectedItem != null)
			{
				grid1.SelectedIndex = this.SelectedRow;
			}
			if ((this.SelectedItem == null) || this.SelectedItem.Equals(""))
			{
				grid1.DataBind();
			}
			this.Controls.Add(grid1);
		}
 
		private void DataGridPageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			this.PageIndex = e.NewPageIndex;
			((DataGrid) source).CurrentPageIndex = this.PageIndex;
			if (this.SelectedPage != this.PageIndex)
			{
				((DataGrid) source).SelectedIndex = this.PageSize + 1;
			}
			else
			{
				((DataGrid) source).SelectedIndex = this.SelectedRow;
			}
			if ((this.SortExpression == null) || this.SortExpression.Equals(""))
			{
				((DataGrid) source).DataBind();
			}
			else
			{
				DataView view1 = this.DataSource.Tables[0].DefaultView;
				view1.Sort = this.SortExpression;
				((DataGrid) source).DataSource = view1;
				((DataGrid) source).DataBind();
			}
			this.SaveStatus();
		}
 
		private void DataGridSelectedIndexChanged(object sender, EventArgs e)
		{
			this.SelectedItem = ((DataGrid) sender).SelectedItem.Cells[this.IdColNumber].Text;
			this.SelectedRow = ((DataGrid) sender).SelectedIndex;
			this.SelectedPage = ((DataGrid) sender).CurrentPageIndex;
			if ((this.SortExpression == null) || this.SortExpression.Equals(""))
			{
				((DataGrid) sender).DataBind();
			}
			else
			{
				DataView view1 = this.DataSource.Tables[0].DefaultView;
				view1.Sort = this.SortExpression;
				((DataGrid) sender).DataSource = view1;
				((DataGrid) sender).DataBind();
			}
			this.SaveStatus();
		}
 
		private void DataGridSortCommand(object source, DataGridSortCommandEventArgs e)
		{
			DataView view1 = this.DataSource.Tables[0].DefaultView;
			view1.Sort = e.SortExpression;
			this.SortExpression = e.SortExpression;
			((DataGrid) source).DataSource = view1;
			((DataGrid) source).SelectedIndex = this.PageSize + 1;
			((DataGrid) source).DataBind();
			this.SaveStatus();
		}
 
		public DataSet GenTableHeader(DataSet oData, string TableName, string[] Header)
		{
			DataSet set2;
			DataSet set1 = oData.Copy();
			try
			{
				DataTable table1;
				if (TableName.Equals(""))
				{
					table1 = oData.Tables[0];
				}
				else
				{
					table1 = oData.Tables[TableName];
				}
				if (Header.Length == table1.Columns.Count)
				{
					DataRow row1 = table1.NewRow();
					for (int num1 = 0; num1 < Header.Length; num1++)
					{
						row1[num1] = Header[num1];
					}
					table1.Rows.InsertAt(row1, 0);
					return oData;
				}
				set2 = set1;
			}
			catch (Exception)
			{
				set2 = set1;
			}
			return set2;
		}
 
		public void LoadStatus(HttpRequest oRequest)
		{
			this.SelectedRow = Convert.ToInt16(oRequest.Params.Get("SelectedIndex"));
			this.SelectedItem = oRequest.Params.Get("SelectedItem");
			this.PageIndex = Convert.ToInt16(oRequest.Params.Get("PageIndex"));
			this.SelectedPage = Convert.ToInt16(oRequest.Params.Get("SelectedPage"));
			this.SortExpression = oRequest.Params.Get("SortExpression");
		}
 
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);
		}
 
		protected override void Render(HtmlTextWriter writer)
		{
			this.RenderChildren(writer);
		}
 
		public void SaveStatus()
		{
			this.Page.RegisterHiddenField("SelectedIndex", this.SelectedRow.ToString());
			this.Page.RegisterHiddenField("SelectedItem", this.SelectedItem);
			this.Page.RegisterHiddenField("PageIndex", this.PageIndex.ToString());
			this.Page.RegisterHiddenField("SelectedPage", this.SelectedPage.ToString());
			this.Page.RegisterHiddenField("SortExpression", this.SortExpression);
		}
 

	}
}
