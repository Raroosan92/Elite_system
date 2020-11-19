using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Elite_system.Admin
{
    public partial class AddRole : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DisplayRolesInGrid();
            }
        }
        private void DisplayRolesInGrid()
        {
            grdRoleList.DataSource = Roles.GetAllRoles();
            grdRoleList.DataBind();
        }
        protected void btnCreateRole_Click(object sender, EventArgs e)
        {
            string newRoleName = txtRoleName.Text.Trim();
            if (!Roles.RoleExists(newRoleName))
            {
                Roles.CreateRole(newRoleName);
                DisplayRolesInGrid();
            }
            txtRoleName.Text = string.Empty;
        }
        protected void grdRoleList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label RoleNameLabel = grdRoleList.Rows[e.RowIndex].FindControl("RoleNameLabel") as Label;
            Roles.DeleteRole(RoleNameLabel.Text, false);
            DisplayRolesInGrid();
        }

        protected void grdRoleList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdRoleList.PageIndex = e.NewPageIndex;
            grdRoleList.DataSource = Roles.GetAllRoles();
            grdRoleList.DataBind();
        }
    }
}