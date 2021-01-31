using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Elite_system
{
    public partial class Payment_Of_Claims : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DDL_Medical_Name.DataSource = Cls_Main_Claims.Get_Medical_TypesForClaims();
                DDL_Medical_Name.DataBind();
                DDL_Medical_Name.Items.Insert(0, new ListItem("--اختر--", "0"));



                DDL_Main_Company.DataSource = Cls_Main_Claims.Get_Companies3();
                DDL_Main_Company.DataBind();
                DDL_Main_Company.Items.Insert(0, new ListItem("--اختر--", "0"));



                Cls_Sub_Companies Sub_Companies = new Cls_Sub_Companies();
                Sub_Companies._Main_Company = long.Parse(DDL_Main_Company.SelectedValue);
                DDL_Sub_Company.DataSource = Sub_Companies.Get_Sub_Companies();
                DDL_Sub_Company.DataBind();

            }
        }
        protected void DDL_Medical_Name_SelectedIndexChanged(object sender, EventArgs e)
        {

            //string Contracting_Value = Cls_Medical_Types_And_Companies.Get_Contracting_Value(long.Parse(DDL_Medical_Name.SelectedValue.ToString()));
            try
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Get_V_Payment_Of_Claims";

                cmd.Parameters.AddWithValue("@Medical_Name", DDL_Medical_Name.SelectedValue);
                cmd.Parameters.AddWithValue("@Main_Company", DDL_Main_Company.SelectedValue);

                Cls_Connection.open_connection();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                GridView_SubClaims.DataSource = dt;
                GridView_SubClaims.DataBind();
                GridView_SubClaims.Visible = true;

                Cls_Connection.close_connection();
               
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                
                Cls_Connection.close_connection();


            }



        }
  protected void DDL_Main_Company_SelectedIndexChanged(object sender, EventArgs e)
        {

            //string Contracting_Value = Cls_Medical_Types_And_Companies.Get_Contracting_Value(long.Parse(DDL_Medical_Name.SelectedValue.ToString()));
            try
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Get_V_Payment_Of_Claims";

                cmd.Parameters.AddWithValue("@Medical_Name", DDL_Medical_Name.SelectedValue);
                cmd.Parameters.AddWithValue("@Main_Company", DDL_Main_Company.SelectedValue);

                Cls_Connection.open_connection();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                GridView_SubClaims.DataSource = dt;
                GridView_SubClaims.DataBind();
                GridView_SubClaims.Visible = true;

                Cls_Connection.close_connection();
               
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                
                Cls_Connection.close_connection();


            }



        }

        protected void GridView_SubClaims_SelectedIndexChanged1(object sender, EventArgs e)
        {
            
        }

    }
}