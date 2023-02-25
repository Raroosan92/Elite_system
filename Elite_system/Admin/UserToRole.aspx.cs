using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
                                select new { User = u, Role = r,r.Description }).ToList();
                grdUserRoles.DataSource = UserRole.ToArray();
                grdUserRoles.DataBind();
            }
        }
        private void BindList()
        {

            //foreach (var role in GetAllRoles())
            //{
            //    ddlRole.Items.Add(new ListItem(role, role));
            //}
            DataTable dt = new DataTable();
            dt = GetAllRoles();
            ddlRole.DataSource = dt;
            ddlRole.DataTextField = "Description";
            ddlRole.DataValueField = "RoleName";
            ddlRole.DataBind();
            ddlRole.Items.Insert(0, new ListItem("--اختر--", "0"));

            foreach (MembershipUser user in Membership.GetAllUsers())
            {
                ddlUser.Items.Add(new ListItem(user.UserName, user.UserName));
            }
        }
        protected void btnRoleAssign_Click(object sender, EventArgs e)
        {
            try
            {

           
            string roleName = ddlRole.SelectedValue;
            string userName = ddlUser.SelectedItem.Text;
            if ((!User.IsInRole(roleName)) || roleName=="Admin")
            {
                Roles.AddUserToRole(userName, roleName);
            }
           
            DisplayUserRolesInGrid();
            }
            catch (Exception)
            {
            }
        }


        protected void grdRoleList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label RoleNameLabel = grdUserRoles.Rows[e.RowIndex].FindControl("RoleNameLabel") as Label;
            Label UserNameLabel = grdUserRoles.Rows[e.RowIndex].FindControl("UserNameLabel") as Label;
            Roles.RemoveUserFromRole(UserNameLabel.Text, RoleNameLabel.Text);
            DisplayUserRolesInGrid();
        }

        public DataTable GetAllRoles()
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "aspnet_Roles_GetAllRoles2";
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                Cls_Connection.open_connection();
                adp.Fill(dt);
                Cls_Connection.close_connection();
                return dt;

            }
            catch (Exception)
            {
                Cls_Connection.close_connection();
                return dt;


            }

        }
        //public List<string> GetAllRoles()
        //{
        //    List<string> listRange = new List<string>();
        //    listRange.Add("q");
        //    listRange.Add("s");

        //    return listRange;
        //}
       
    }
}