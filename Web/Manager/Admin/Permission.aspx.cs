using System;
using System.Collections.Generic;

using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Manager.Admin
{
    public partial class Permission : Business.ManageWeb
    {
        public int P_Group_id = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AdminCheck("Manager/Admin/Permission.aspx");
            string Group_id = this.QueryString("Group_id");
            if (!string.IsNullOrEmpty(Group_id))
            {
                this.P_Group_id = int.Parse(Com.Common.EncDec.Decrypt(Group_id, this.Encrypt_key));
            }
            else
            {
                this.btnSave.Visible = false;
                this.cblPermission.Visible = false;
                this.AlertScript("参数错误!");
            }
            if (!Page.IsPostBack)
            {
                this.BindData();
            }
        }
        private void BindData()
        {
            Entity.TEAMTOOL.ADMIN_FUNCTION admin_function = new Entity.TEAMTOOL.ADMIN_FUNCTION();
            admin_function.INNER_JOIN_ADMIN_MODULE = true;
            admin_function.SelectColumns = new string[] { admin_function._FUNCTION_ID,
                "'['+Module_name+']'+" + admin_function._FUNCTION_NAME + "+' '+" + admin_function._FUNCTION_URL + "+'('+CAST("+admin_function._FUNCTION_VIEW_COUNT+" AS VARCHAR(20))+')' AS " + admin_function._FUNCTION_NAME,
                admin_function._FUNCTION_URL, "Module_name" };
            admin_function.OrderBy = admin_function._FUNCTION_MODULE_ID;
            DataTable oDt_admin_function = admin_function.Select();
            this.cblPermission.DataSource = oDt_admin_function;
            this.cblPermission.DataValueField = admin_function._FUNCTION_ID;
            this.cblPermission.DataTextField = admin_function._FUNCTION_NAME;
            this.cblPermission.DataBind();

            Entity.TEAMTOOL.ADMIN_PERMISSION admin_permission = new Entity.TEAMTOOL.ADMIN_PERMISSION();
            admin_permission.PERMISSION_GROUP_ID = P_Group_id;
            DataTable oDt_admin_permission = admin_permission.Select();
            foreach (ListItem Item in cblPermission.Items)
            {
                DataRow[] oDrs = oDt_admin_permission.Select(admin_permission._PERMISSION_FUNCTION_ID + "=" + Item.Value);
                if (oDrs != null && oDrs.Length > 0)//有对应的权限
                {
                    Item.Text = "<font color=red>" + Item.Text + "</font>";
                    Item.Selected = true;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (this.cblPermission.SelectedIndex == -1)
            {
                this.AlertScript("至少选择一项!");
                return;
            }

            Entity.TEAMTOOL.ADMIN_PERMISSION admin_permission_delete = new Entity.TEAMTOOL.ADMIN_PERMISSION();
            admin_permission_delete.DeleteWhereSql = admin_permission_delete._PERMISSION_GROUP_ID + "=" + this.P_Group_id;
            if (!admin_permission_delete.Delete())
            {
                this.AlertScript("删除原始数据失败!");
                return;
            }
            int i = 0;
            foreach (ListItem Item in cblPermission.Items)
            {
                if (Item.Selected == true)
                {
                    Entity.TEAMTOOL.ADMIN_PERMISSION admin_permission_insert = new Entity.TEAMTOOL.ADMIN_PERMISSION();
                    admin_permission_insert.PERMISSION_GROUP_ID = this.P_Group_id;
                    admin_permission_insert.PERMISSION_FUNCTION_ID = int.Parse(Item.Value);
                    if (!admin_permission_insert.Insert())
                    {
                        i++;
                    }
                }
            }
            if (i == 0)
            {
                this.AlertScript("修改成功!");
                System.Web.Caching.Cache _cache = HttpRuntime.Cache;
                System.Collections.IDictionaryEnumerator CacheEnum = _cache.GetEnumerator();
                while (CacheEnum.MoveNext())
                {
                    string _key = CacheEnum.Key.ToString();
                    _cache.Remove(_key);
                }
            }
            else
            {
                this.AlertScript("修改" + i + "条数据失败!");
            }
        }
    }
}