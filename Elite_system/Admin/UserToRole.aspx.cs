using System;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Elite_system.Admin
{
    public partial class UserToRole : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindList();
                DisplayUserRolesInGrid();
            }
        }
        private void DisplayUserRolesInGrid()
        {
            using (CustomMembershipEntities dataContext = new CustomMembershipEntities())
            {
                var UserRole = (from u in dataContext.aspnet_Users.Include("aspnet_Roles")
                                from r in u.aspnet_Roles
                                where r != null
                                select new { User = u, Role = r }).ToList();
                grdUserRoles.DataSource = UserRole.ToArray();
                grdUserRoles.DataBind();
            }
        }
        private void BindList()
        {
            foreach (var role in Roles.GetAllRoles())
            {
                ddlRole.Items.Add(new ListItem(role, role));
            }
            foreach (MembershipUser user in Membership.GetAllUsers())
            {
                ddlUser.Items.Add(new ListItem(user.UserName, user.UserName));
            }
        }
        protected void btnRoleAssign_Click(object sender, EventArgs e)
        {
            string roleName = ddlRole.SelectedItem.Text;
            string userName = ddlUser.SelectedItem.Text;
            if (!User.IsInRole(roleName))
            {
                Roles.AddUserToRole(userName, roleName);
            }
            DisplayUserRolesInGrid();
        }


        protected void grdRoleList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label RoleNameLabel = grdUserRoles.Rows[e.RowIndex].FindControl("RoleNameLabel") as Label;
            Label UserNameLabel = grdUserRoles.Rows[e.RowIndex].FindControl("UserNameLabel") as Label;
            Roles.RemoveUserFromRole(UserNameLabel.Text, RoleNameLabel.Text);
            DisplayUserRolesInGrid();
        }
    }
}