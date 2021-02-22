using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Elite_system
{
    public partial class DelivereMail : System.Web.UI.Page
    {
      

        public void MSG(string Text)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('" + Text + "')</script>", false);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DDL_Medical_Name.DataSource = Cls_Main_Claims.Get_Medical_Types2();
                DDL_Medical_Name.DataBind();
                DDL_Medical_Name.Items.Insert(0, new ListItem("--اختر--", "0"));


                DDL_Mail_Type.DataSource = Cls_Codes.Fill_DDL(6);
                DDL_Mail_Type.DataBind();
                DDL_Mail_Type.Items.Insert(0, new ListItem("--اختر--", "0"));

                DDL_Main_Company.DataSource = Cls_Main_Claims.Get_Companies();
                DDL_Main_Company.DataBind();
                DDL_Main_Company.Items.Insert(0, new ListItem("--اختر--", "0"));
            }
        }
        protected void DDL_Medical_Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetMails();
        }

        protected void DDL_Main_Company_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetMails();
        }

        protected void DDL_Mail_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetMails();
        }
        protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                Medical_Name.Text = GridView.SelectedRow.Cells[2].Text;
                Send_To.Text = GridView.SelectedRow.Cells[1].Text;
                Mail_type.Text = GridView.SelectedRow.Cells[3].Text;
                Mail_ID.Text = GridView.SelectedRow.Cells[5].Text;
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
                if (Medical_Name.Text != "" && Send_To.Text != null && Mail_type.Text != null)
                {

                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                    con = Cls_Connection._con;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    string dt1 = DateTimeOffset.UtcNow.AddHours(2).ToString("yyyy-MM-dd");
                    cmd.CommandText = "UPDATE [dbo].[Main_Mail] SET [Delivery_Date] = '"+dt1+"' ,Delivered = '1' where ID = "+Mail_ID.Text+" ";
                    Cls_Connection.open_connection();
                    cmd.ExecuteNonQuery();
                    Cls_Connection.close_connection();
                    Medical_Name.Text = null;
                    Send_To.Text = null;
                    Mail_type.Text = null;
                    Mail_ID.Text = null;
                    GetMails();
                    MSG("تم تسليم البريد");


                }
                else
                {
                    MSG("يجب اختيار بريد اولاً");
                }
            }
            catch (Exception ex)
            {

                Cls_Connection.close_connection();
            }

        }

        protected void GetMails()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Get_V_Mails_Delivered";
                string Medical_Name = DDL_Medical_Name.SelectedValue;
                string Main_Company = DDL_Main_Company.SelectedValue;
                string Mail_Type = DDL_Mail_Type.SelectedValue;
                //if (DDL_Medical_Name.SelectedValue=="0")
                //{
                //    Medical_Name = null;
                //}
                //if (DDL_Main_Company.SelectedValue == "0")
                //{
                //    Main_Company = null;
                //}

                //if (DDL_Mail_Type.SelectedValue == "0")
                //{
                //    Mail_Type = null;
                //}
                cmd.Parameters.AddWithValue("@Medical_Name", Medical_Name);
                cmd.Parameters.AddWithValue("@Main_Company", Main_Company);
                cmd.Parameters.AddWithValue("@Mail_Type", Mail_Type);

                Cls_Connection.open_connection();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                GridView.DataSource = dt;
                GridView.DataBind();
                GridView.Visible = true;
                lbl_count.Text = dt.Rows.Count.ToString();
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