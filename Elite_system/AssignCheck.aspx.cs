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
    public partial class AssignCheck : System.Web.UI.Page
    {
        Boolean Check;
        Boolean CheckMore;
        int Exist;
        public void MSG(string Text)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('" + Text + "')</script>", false);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                Btn_Delete.Style.Add("Display", "None");
                //btnPrint.Style.Add("Display", "None");
                DDL_Employee.DataSource = Cls_Employees.Get_Employee();
                DDL_Employee.DataBind();
                DDL_Employee.SelectedValue = "15";

                DDL_Sent_To.DataSource = Cls_Main_Claims.Get_Medical_Types();
                DDL_Sent_To.DataBind();
                DDL_Sent_To.Items.Insert(0, new ListItem("--اختر--", "0"));
            }
        }
        public void Get_MainChecks_GridView()
        {
            try
            {


                //To Transmit Data To GridView
                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Get_MainChecks_AssignChecks";
                cmd.Parameters.AddWithValue("@BarCode", Txt_BarCode.Text);
                Cls_Connection.open_connection();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                GV_ChecksAssigned.DataSourceID = null;
                GV_ChecksAssigned.DataSource = dt;
                GV_ChecksAssigned.DataBind();
                Btn_Delete.Style.Add("Display", "inline-block");
                //btnPrint.Style.Add("Display", "inline-block");
                Cls_Connection.close_connection();



            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Cls_Connection.close_connection();


            }

        }

        public void Get_MainChecks_GridView2()
        {
            try
            {


                //To Transmit Data To GridView
                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                if (CheckMore == true)
                {
                    cmd.CommandText = "Get_MainChecks_AssignChecks3";
                    cmd.Parameters.AddWithValue("@Medical_Type", DDL_Sent_To.SelectedItem.Text);
                }
                else
                {
                    cmd.CommandText = "Get_MainChecks_AssignChecks2";
                }

                cmd.Parameters.AddWithValue("@Check_No", Txt_CheckNo.Text);
                Cls_Connection.open_connection();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                GV_ChecksAssigned.DataSourceID = null;
                GV_ChecksAssigned.DataSource = dt;
                GV_ChecksAssigned.DataBind();
                Btn_Delete.Style.Add("Display", "inline-block");
                //btnPrint.Style.Add("Display", "inline-block");
                Cls_Connection.close_connection();



            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Cls_Connection.close_connection();


            }

        }

        public void Get_MainChecks_GridViewTemp()
        {
            try
            {


                //To Transmit Data To GridView
                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Get_MainChecks_AssignChecksTemp";
                Cls_Connection.open_connection();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                GV_ChecksAssigned.DataSourceID = null;
                GV_ChecksAssigned.DataSource = dt;
                GV_ChecksAssigned.DataBind();
                Cls_Connection.close_connection();



            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Cls_Connection.close_connection();


            }

        }

        public void Get_MainChecks_ForGridView()
        {
            try
            {

                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Get_MainChecks_AssignChecks4";
                if (Txt_BarCode.Text != "")
                {
                    cmd.Parameters.AddWithValue("@CheckNo", Txt_BarCode.Text);
                }
                else if(Txt_CheckNo.Text!="")
                {
                    cmd.Parameters.AddWithValue("@CheckNo", Txt_CheckNo.Text);
                }
                Cls_Connection.open_connection();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                GV_ChecksAssigned.DataSourceID = null;
                GV_ChecksAssigned.DataSource = dt;
                GV_ChecksAssigned.DataBind();
                Cls_Connection.close_connection();

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Cls_Connection.close_connection();

            }

        }

        public void SaveAssignCheckedToTempTable()
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select count(id) from AssignChekesTemp where CheckNum='" + Txt_BarCode.Text + "'";
            Cls_Connection.open_connection();
            Exist = int.Parse(cmd.ExecuteScalar().ToString());
            Cls_Connection.close_connection();

            if (Exist == 0)
            {
                try
                {
                    if (GV_ChecksAssigned.Rows.Count != 0)
                    {
                        //To Save Data To Table Temporary

                        //Get the GridView Row.
                        GridViewRow row = GV_ChecksAssigned.Rows[0];

                        cmd.Parameters.Clear();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "[AssignChekes_Temp]";
                        cmd.Parameters.AddWithValue("@id", GV_ChecksAssigned.Rows[0].Cells[1].Text);
                        cmd.Parameters.AddWithValue("@CompanyName", GV_ChecksAssigned.Rows[0].Cells[2].Text);
                        cmd.Parameters.AddWithValue("@CheckDate", GV_ChecksAssigned.Rows[0].Cells[3].Text);
                        cmd.Parameters.AddWithValue("@BankName", GV_ChecksAssigned.Rows[0].Cells[4].Text);
                        cmd.Parameters.AddWithValue("@SentTo", GV_ChecksAssigned.Rows[0].Cells[5].Text);
                        cmd.Parameters.AddWithValue("@Value", GV_ChecksAssigned.Rows[0].Cells[6].Text);
                        cmd.Parameters.AddWithValue("@CheckNum", GV_ChecksAssigned.Rows[0].Cells[7].Text);
                        cmd.Parameters.AddWithValue("@Month", GV_ChecksAssigned.Rows[0].Cells[8].Text);
                        cmd.Parameters.AddWithValue("@Notes", GV_ChecksAssigned.Rows[0].Cells[9].Text);
                        cmd.Parameters.AddWithValue("@Address", GV_ChecksAssigned.Rows[0].Cells[10].Text);
                        cmd.Parameters.AddWithValue("@PhoneNumber", GV_ChecksAssigned.Rows[0].Cells[11].Text);
                        cmd.Parameters.AddWithValue("@BarCode", GV_ChecksAssigned.Rows[0].Cells[12].Text);
                        cmd.Parameters.AddWithValue("@EmpName", GV_ChecksAssigned.Rows[0].Cells[13].Text);
                        bool Delivered = (row.Cells[14].Controls[0] as CheckBox).Checked;
                        bool Refunded = (row.Cells[15].Controls[0] as CheckBox).Checked;
                        cmd.Parameters.AddWithValue("@Delivered", Delivered);
                        cmd.Parameters.AddWithValue("@Refunded", Refunded);
                        Cls_Connection.open_connection();
                        cmd.ExecuteNonQuery();
                        Cls_Connection.close_connection();
                    }

                }
                catch (Exception ex)
                {
                    Cls_Connection.close_connection();
                }
            }
            else
            {
                MSG("هذا الشيك تمت إحالته مسبقاً");
            }
        }

        public void SaveAssignCheckedToTempTable2()
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select count(id) from AssignChekesTemp where CheckNum='" + Txt_CheckNo.Text + "'";
            Cls_Connection.open_connection();
            Exist = int.Parse(cmd.ExecuteScalar().ToString());
            Cls_Connection.close_connection();

            if (Exist == 0)
            {
                try
                {
                    if (GV_ChecksAssigned.Rows.Count != 0)
                    {
                        //To Save Data To Table Temporary

                        //Get the GridView Row.
                        GridViewRow row = GV_ChecksAssigned.Rows[0];

                        cmd.Parameters.Clear();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "[AssignChekes_Temp]";
                        cmd.Parameters.AddWithValue("@id", GV_ChecksAssigned.Rows[0].Cells[1].Text);
                        cmd.Parameters.AddWithValue("@CompanyName", GV_ChecksAssigned.Rows[0].Cells[2].Text);
                        cmd.Parameters.AddWithValue("@CheckDate", GV_ChecksAssigned.Rows[0].Cells[3].Text);
                        cmd.Parameters.AddWithValue("@BankName", GV_ChecksAssigned.Rows[0].Cells[4].Text);
                        cmd.Parameters.AddWithValue("@SentTo", GV_ChecksAssigned.Rows[0].Cells[5].Text);
                        cmd.Parameters.AddWithValue("@Value", GV_ChecksAssigned.Rows[0].Cells[6].Text);
                        cmd.Parameters.AddWithValue("@CheckNum", GV_ChecksAssigned.Rows[0].Cells[7].Text);
                        cmd.Parameters.AddWithValue("@Month", GV_ChecksAssigned.Rows[0].Cells[8].Text);
                        cmd.Parameters.AddWithValue("@Notes", GV_ChecksAssigned.Rows[0].Cells[9].Text);
                        cmd.Parameters.AddWithValue("@Address", GV_ChecksAssigned.Rows[0].Cells[10].Text);
                        cmd.Parameters.AddWithValue("@PhoneNumber", GV_ChecksAssigned.Rows[0].Cells[11].Text);
                        cmd.Parameters.AddWithValue("@BarCode", GV_ChecksAssigned.Rows[0].Cells[12].Text);
                        cmd.Parameters.AddWithValue("@EmpName", GV_ChecksAssigned.Rows[0].Cells[13].Text);
                        bool Delivered = (row.Cells[14].Controls[0] as CheckBox).Checked;
                        bool Refunded = (row.Cells[15].Controls[0] as CheckBox).Checked;
                        cmd.Parameters.AddWithValue("@Delivered", Delivered);
                        cmd.Parameters.AddWithValue("@Refunded", Refunded);
                        Cls_Connection.open_connection();
                        cmd.ExecuteNonQuery();
                        Cls_Connection.close_connection();
                    }

                }
                catch (Exception ex)
                {
                    Cls_Connection.close_connection();
                }
            }
            else
            {
                cmd.CommandText = "select count(id) from AssignChekesTemp where CheckNum='" + Txt_CheckNo.Text + "' and SentTo='" + DDL_Sent_To.SelectedItem.Text + "'";
                Cls_Connection.open_connection();
                Exist = int.Parse(cmd.ExecuteScalar().ToString());
                Cls_Connection.close_connection();
                if (Exist == 0)
                {

                    GridViewRow row = GV_ChecksAssigned.Rows[0];

                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "[AssignChekes_Temp]";
                    cmd.Parameters.AddWithValue("@id", GV_ChecksAssigned.Rows[0].Cells[1].Text);
                    cmd.Parameters.AddWithValue("@CompanyName", GV_ChecksAssigned.Rows[0].Cells[2].Text);
                    cmd.Parameters.AddWithValue("@CheckDate", GV_ChecksAssigned.Rows[0].Cells[3].Text);
                    cmd.Parameters.AddWithValue("@BankName", GV_ChecksAssigned.Rows[0].Cells[4].Text);
                    cmd.Parameters.AddWithValue("@SentTo", GV_ChecksAssigned.Rows[0].Cells[5].Text);
                    cmd.Parameters.AddWithValue("@Value", GV_ChecksAssigned.Rows[0].Cells[6].Text);
                    cmd.Parameters.AddWithValue("@CheckNum", GV_ChecksAssigned.Rows[0].Cells[7].Text);
                    cmd.Parameters.AddWithValue("@Month", GV_ChecksAssigned.Rows[0].Cells[8].Text);
                    cmd.Parameters.AddWithValue("@Notes", GV_ChecksAssigned.Rows[0].Cells[9].Text);
                    cmd.Parameters.AddWithValue("@Address", GV_ChecksAssigned.Rows[0].Cells[10].Text);
                    cmd.Parameters.AddWithValue("@PhoneNumber", GV_ChecksAssigned.Rows[0].Cells[11].Text);
                    cmd.Parameters.AddWithValue("@BarCode", GV_ChecksAssigned.Rows[0].Cells[12].Text);
                    cmd.Parameters.AddWithValue("@EmpName", GV_ChecksAssigned.Rows[0].Cells[13].Text);
                    bool Delivered = (row.Cells[14].Controls[0] as CheckBox).Checked;
                    bool Refunded = (row.Cells[15].Controls[0] as CheckBox).Checked;
                    cmd.Parameters.AddWithValue("@Delivered", Delivered);
                    cmd.Parameters.AddWithValue("@Refunded", Refunded);
                    Cls_Connection.open_connection();
                    cmd.ExecuteNonQuery();
                    Cls_Connection.close_connection();

                }
                else
                {
                    MSG("هذا الشيك تمت إحالته مسبقاً");
                }


            }
        }
        public void SaveAssignNameToChecked()
        {
            try
            {
                //Check If Exist
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select count(id) from  [dbo].[Main_Check]  WHERE BarCode = '" + Txt_BarCode.Text + "'";
                Cls_Connection.open_connection();
                int Exist = int.Parse(cmd.ExecuteScalar().ToString());
                Cls_Connection.close_connection();
                if (Exist == 1)
                {
                    //To Update Name in checkes
                    cmd.CommandText = "UPDATE [dbo].[Main_Check] SET [EmployeeName] = N'" + DDL_Employee.SelectedItem.ToString() + "',[Refunded] = " + 0 + ",Delivered=" + 0 + ",Modified= SYSDATETIME() WHERE BarCode = '" + Txt_BarCode.Text + "'";
                    Cls_Connection.open_connection();
                    cmd.ExecuteNonQuery();
                    Cls_Connection.close_connection();
                }
                else
                {
                    MSG("هذا الشيك غير مدخل من قبل");
                }


            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Cls_Connection.close_connection();


            }
        }

        public void SaveAssignNameToChecked2()
        {

            try
            {
                //Check If Exist
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                cmd.Connection = con;
                cmd.CommandText = "select count(id) from  [dbo].[Main_Check]  WHERE Check_No = '" + Txt_CheckNo.Text + "'";
                Cls_Connection.open_connection();
                int Exist = int.Parse(cmd.ExecuteScalar().ToString());
                Cls_Connection.close_connection();
                if (Exist == 1)
                {
                    //To Update Name in checkes
                    cmd.CommandText = "UPDATE [dbo].[Main_Check] SET [EmployeeName] = N'" + DDL_Employee.SelectedItem.ToString() + "',[Refunded] = " + 0 + ",Delivered=" + 0 + ",Modified= SYSDATETIME() WHERE Check_No = '" + Txt_CheckNo.Text + "'";
                    Cls_Connection.open_connection();
                    cmd.ExecuteNonQuery();
                    Check = true;

                    Cls_Connection.close_connection();
                }
                else if (Exist > 1)
                {
                    if (DDL_Sent_To.SelectedValue == "0")
                    {
                        Check = false;
                        MSG("يرجى اختيار الجهة المرسل لها الشيك");
                        return;

                    }
                    else
                    {
                        //To Update Name in checkes
                        cmd.CommandText = "UPDATE [dbo].[Main_Check] SET [EmployeeName] = N'" + DDL_Employee.SelectedItem.ToString() + "',[Refunded] = " + 0 + ",Delivered=" + 0 + ",Modified= SYSDATETIME() WHERE Check_No = '" + Txt_CheckNo.Text + "' and Sent_To=" + long.Parse(DDL_Sent_To.SelectedValue);
                        Cls_Connection.open_connection();
                        cmd.ExecuteNonQuery();
                        Check = true;
                        CheckMore = true;

                        Cls_Connection.close_connection();

                    }
                }
                else
                {
                    Check = false;
                    MSG("هذا الشيك غير مدخل من قبل");
                }


            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Cls_Connection.close_connection();


            }
        }

        public string CheckIfAssigned()
        {
            try
            {
                //Check If Exist
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                if (DDL_Sent_To.SelectedValue == "0")
                {
                    cmd.CommandText = "select EmployeeName from  [dbo].[Main_Check]  WHERE Refunded=" + 0 + " and Check_No = '" + Txt_CheckNo.Text + "'";
                }
                else
                {
                    cmd.CommandText = "select EmployeeName from  [dbo].[Main_Check]  WHERERefunded=" + 0 + " and Check_No = '" + Txt_CheckNo.Text + "' and Sent_To=" + long.Parse(DDL_Sent_To.SelectedValue);
                }
                Cls_Connection.open_connection();
                string EmployeeName = cmd.ExecuteScalar().ToString();
                Cls_Connection.close_connection();
                return EmployeeName;
            }
            catch
            {
                return "";
            }
        }

        public string CheckIfAssigned2()
        {
            try
            {
                //Check If Exist
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;


                cmd.CommandText = "select EmployeeName from  [dbo].[Main_Check]  WHERE Refunded=" + 0 + " and BarCode = '" + Txt_BarCode.Text + "'";


                Cls_Connection.open_connection();
                string EmployeeName = cmd.ExecuteScalar().ToString();
                Cls_Connection.close_connection();
                return EmployeeName;
            }
            catch
            {
                return "";
            }
        }
        protected void Btn_Save1_Click(object sender, EventArgs e)
        {
            if (Txt_BarCode.Text == "")
            {
                MSG("يرجى إدخال البار كود");
                return;
            }

            string AssignedCheck = "";
            AssignedCheck = CheckIfAssigned2();
            if (AssignedCheck == "")
            {
                SaveAssignNameToChecked();
                ////////////////////////////////       Log        /////////////////////////////////////////////
                Cls_Log log = new Cls_Log();
                log._Log_Event = " إحالة الشيك رقم الباركود  : " + Txt_BarCode.Text + " إلى  " + DDL_Employee.SelectedItem.Text;
                log.Insert_Log();
                ////////////////////////////////   End Of Log        /////////////////////////////////////////////

                Get_MainChecks_ForGridView();
            }
            else
            {
                MSG(" هذا الشيك محال الى الموظف : " + AssignedCheck);
            }

            Txt_BarCode.Text = "";
            Txt_BarCode.Focus();
        }

        protected void Btn_Save2_Click(object sender, EventArgs e)
        {
            if (Txt_CheckNo.Text == "")
            {
                MSG("يرجى إدخال رقم الشيك");
                return;
            }
            Check = false;
            CheckMore = false;
            string AssignedCheck = "";
            AssignedCheck = CheckIfAssigned();
            if (AssignedCheck == "")
            {
                SaveAssignNameToChecked2();
                if (Check == true)
                {
                    ////////////////////////////////       Log        /////////////////////////////////////////////
                    Cls_Log log = new Cls_Log();
                    log._Log_Event = " إحالة الشيك رقم   : " + Txt_CheckNo.Text + " إلى  " + DDL_Employee.SelectedItem.Text;
                    log.Insert_Log();
                    ////////////////////////////////   End Of Log        /////////////////////////////////////////////

                    Get_MainChecks_ForGridView();
                }
            }
            else
            {
                MSG(" هذا الشيك محال الى الموظف : " + AssignedCheck);
            }
        }

        protected void ClearTempTable()
        {
            try
            {


                //To Update Name in checkes
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "delete from AssignChekesTemp";
                Cls_Connection.open_connection();
                cmd.ExecuteNonQuery();
                Cls_Connection.close_connection();


                Btn_Delete.Style.Add("Display", "None");
                //btnPrint.Style.Add("Display", "None");
                GV_ChecksAssigned.DataSourceID = null;
                GV_ChecksAssigned.DataSource = null;
                GV_ChecksAssigned.DataBind();

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Cls_Connection.close_connection();


            }


        }

        protected void GV_ChecksAssigned_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                cmd.Connection = con;
                cmd.CommandText = "UPDATE [dbo].[Main_Check] SET [EmployeeName] = NULL ,Modified= SYSDATETIME() WHERE BarCode = '" + GV_ChecksAssigned.Rows[0].Cells[12].Text + "'";
                Cls_Connection.open_connection();
                cmd.ExecuteNonQuery();


                Cls_Connection.close_connection();



            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Cls_Connection.close_connection();


            }
            ////////////////////////////////       Log        /////////////////////////////////////////////
            Cls_Log log = new Cls_Log();
            log._Log_Event = ": تراجع عن إحالة الشيك رقم الباركود" + GV_ChecksAssigned.Rows[0].Cells[12].Text + " إلى  " + DDL_Employee.SelectedItem.Text;
            log.Insert_Log();
            ////////////////////////////////   End Of Log        /////////////////////////////////////////////
            Get_MainChecks_ForGridView();
        }

        protected void Btn_Delete_Click(object sender, EventArgs e)
        {
            ClearTempTable();
        }


    }
}