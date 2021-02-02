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

        public void MSG(string Text)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('" + Text + "')</script>", false);
        }
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
            }
        }
        protected void DDL_Medical_Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetClaims();
        }

        protected void DDL_Main_Company_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetClaims();
        }


        protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Sub_ClaimID.Text = GridView.SelectedRow.Cells[1].Text;
                main_ClaimID.Text = GridView.SelectedRow.Cells[2].Text;
                Patient_Name.Text = GridView.SelectedRow.Cells[8].Text;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Cls_Connection.close_connection();
            }
        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (Sub_ClaimID.Text != "" && main_ClaimID.Text != null && Patient_Name.Text != null)
                {
                    if (Txt_PayAmmount.Text != "")
                    {
                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                        con = Cls_Connection._con;
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;

                        cmd.CommandText = "update Sub_Claims set PatientRatio = '" + Txt_PayAmmount.Text + "' WHERE Main_Claims_ID= '" + main_ClaimID.Text + "' AND ID= '" + Sub_ClaimID.Text + "' AND patient_name = N'" + Patient_Name.Text + "'";
                        Cls_Connection.open_connection();
                        cmd.ExecuteNonQuery();
                        Cls_Connection.close_connection();
                        Sub_ClaimID.Text = null;
                        main_ClaimID.Text = null;
                        Patient_Name.Text = null;
                        Txt_PayAmmount.Text = "";
                        GetClaims();
                        MSG("تم دفع المبلغ");
                    }
                    else
                    {
                        MSG("حدد المبلغ المدفوع");
                    }
                }
                else
                {
                    MSG("يجب اختيار مريض اولاً");
                }
            }
            catch (Exception ex)
            {

                Cls_Connection.close_connection();
            }

        }

        protected void GetClaims()
        {
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
                GridView.DataSource = dt;
                GridView.DataBind();
                GridView.Visible = true;

                Cls_Connection.close_connection();

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Cls_Connection.close_connection();
            }
        }
    }
}