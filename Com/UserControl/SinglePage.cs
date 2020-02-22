using System;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

namespace Com.UserControl
{
	/// <summary>
	/// SinglePage 的摘要说明。
	/// </summary>
	public class SinglePage: CommonUserControl
	{
		public DataSet DataSource;
		public string[] HeaderText;
		public int IdColNumber;
		public bool IfShowIdCol;
		public string SelectedItem;
		public int SelectedRow;
		public string SelectRowDataString;

		public SinglePage()
		{
			this.IdColNumber = 1;
			this.SelectedItem = "";
			this.SelectedRow = 1;
			this.SelectRowDataString = "";
			this.IfShowIdCol = true;
		}
		protected override void CreateChildControls()
		{
			DataGrid grid1 = new DataGrid();
			base.SetControlStyle(grid1, this.style);
			grid1.AllowPaging = false;
			grid1.AllowSorting = false;
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
			ButtonColumn column1 = new ButtonColumn();
			column1.Text = "\u9009\u62e9";
			column1.CommandName = "Select";
			column1.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
			column1.HeaderStyle.Wrap = false;
			column1.ItemStyle.Wrap = false;
			grid1.Columns.Add(column1);
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
					column2.HeaderStyle.Wrap = false;
					column2.ItemStyle.Wrap = false;
					grid1.Columns.Add(column2);
				}
			}
			grid1.SelectedIndexChanged += new EventHandler(this.DataGridSelectedIndexChanged);
			grid1.CurrentPageIndex = 0;
			grid1.DataSource = this.DataSource;
			if (this.SelectedItem != null)
			{
				grid1.SelectedIndex = this.SelectedRow;
			}
			if (!this.IfShowIdCol)
			{
				grid1.Columns[1].Visible = false;
			}
			grid1.EnableViewState = false;
			grid1.DataBind();
			this.Controls.Add(grid1);
		}
 
		private void DataGridSelectedIndexChanged(object sender, EventArgs e)
		{
			this.SelectedItem = ((DataGrid) sender).SelectedItem.Cells[this.IdColNumber].Text;
			this.SelectedRow = ((DataGrid) sender).SelectedIndex;
			this.SelectRowDataString = ((DataGrid) sender).SelectedItem.Cells[0].Text;
			for (int num1 = 1; num1 < ((DataGrid) sender).SelectedItem.Cells.Count; num1++)
			{
				this.SelectRowDataString = this.SelectRowDataString + "," + ((DataGrid) sender).SelectedItem.Cells[num1].Text;
			}
			((DataGrid) sender).DataBind();
			this.SaveStatus();
		}
 
		public void LoadStatus(HttpRequest oRequest)
		{
			this.SelectedRow = Convert.ToInt16(oRequest.Params.Get("SelectedIndex"));
			this.SelectedItem = oRequest.Params.Get("SelectedItem");
			this.SelectRowDataString = oRequest.Params.Get("__SelectedRowData");
		}
 
		public void SaveStatus()
		{
			this.Page.RegisterHiddenField("SelectedIndex", this.SelectedRow.ToString());
			this.Page.RegisterHiddenField("SelectedItem", this.SelectedItem);
			this.Page.RegisterHiddenField("__SelectedRowData", this.SelectRowDataString);
		}
 

	}
}
