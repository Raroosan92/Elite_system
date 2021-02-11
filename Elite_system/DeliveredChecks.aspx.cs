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
    public partial class DeliveredChecks : System.Web.UI.Page
    {
        Boolean CheckMore;
        string empname;
        public void MSG(string Text)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('" + Text + "')</script>", false);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Btn_Delete.Style.Add("Display", "None");

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
        int Exist;
        bool Result;
        public void SaveAssignCheckedToTempTable()
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select count(id) from AssignChekesTemp where BarCode='" + Txt_BarCode.Text + "'";
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
                catch
                {
                    Cls_Connection.close_connection();
                }
            }
            else
            {
                MSG("هذا الشيك تم تسليمه مسبقاً");
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
                catch
                {
                    Cls_Connection.close_connection();
                }
            }

            else
            {

                cmd.CommandText = "select count(id) from AssignChekesTemp where CheckNum='" + Txt_CheckNo.Text + "'" + " and SentTo='" + DDL_Sent_To.SelectedItem.Text + "'";
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
                    catch
                    {
                        Cls_Connection.close_connection();
                    }
                }

                else
                {
                    MSG("هذا الشيك تم تسليمه مسبقاً");
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
                cmd.CommandText = "select count(id) from  [dbo].[Main_Check]  WHERE BarCode = '*" + Txt_BarCode.Text + "*'";
                Cls_Connection.open_connection();
                int Exist = int.Parse(cmd.ExecuteScalar().ToString());
                cmd.Parameters.Clear();
                cmd.CommandText = "select EmployeeName from  [dbo].[Main_Check]  WHERE BarCode = '*" + Txt_BarCode.Text + "*'";
                empname = cmd.ExecuteScalar().ToString();
                Cls_Connection.close_connection();

                if (Exist == 1)
                {
                    if (empname != "")
                    {
                        //To Update Name in checkes
                        cmd.CommandText = "UPDATE [dbo].[Main_Check] SET [Delivered] = " + 1 + ",Refunded=" + 0 + ",Modified= " + DateTime.UtcNow + " WHERE BarCode = '*" + Txt_BarCode.Text + "*'";
                        Cls_Connection.open_connection();
                        cmd.ExecuteNonQuery();
                        Cls_Connection.close_connection();
                        Result = true;
                    }
                    else
                    {
                        Result = false;
                        MSG("هذا الشيك غير محال لموظف");

                    }
                }
                else
                {
                    Result = false;
                    MSG("هذا الشيك غير مدخل من قبل");

                }


            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Cls_Connection.close_connection();
                MSG("هذا الشيك غير مدخل من قبل");

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
                cmd.Connection = con;
                cmd.CommandText = "select count(id) from  [dbo].[Main_Check]  WHERE Check_No = '" + Txt_CheckNo.Text + "'";
                Cls_Connection.open_connection();
                int Exist = int.Parse(cmd.ExecuteScalar().ToString());
                cmd.Parameters.Clear();
                cmd.CommandText = "select EmployeeName from  [dbo].[Main_Check]  WHERE Check_No = '" + Txt_CheckNo.Text + "'";
                string empname = cmd.ExecuteScalar().ToString();
                Cls_Connection.close_connection();

                if (Exist == 1)
                {
                    if (empname != "")
                    {
                        //To Update Name in checkes
                        cmd.CommandText = "UPDATE [dbo].[Main_Check] SET [Delivered] = " + 1 + ",Refunded=" + 0 + ",Modified= " + DateTime.UtcNow + " WHERE Check_No = '" + Txt_CheckNo.Text + "'";
                        Cls_Connection.open_connection();
                        cmd.ExecuteNonQuery();
                        Cls_Connection.close_connection();
                        Result = true;
                    }

                    else
                    {
                        Result = false;
                        MSG("هذا الشيك غير محال لموظف");

                    }
                }

                else if (Exist > 1)
                {
                    if (DDL_Sent_To.SelectedValue == "0")
                    {

                        Result = false;
                        MSG("يرجى اختيار الجهة الطبية");


                    }

                    else
                    {

                        if (empname != "")
                        {
                            //To Update Name in checkes
                            cmd.CommandText = "UPDATE [dbo].[Main_Check] SET [Delivered] = " + 1 + ",Refunded=" + 0 + ",Modified= " + DateTime.UtcNow + " WHERE Check_No = '" + Txt_CheckNo.Text + "' and Sent_To=" + long.Parse(DDL_Sent_To.SelectedValue);
                            Cls_Connection.open_connection();
                            cmd.ExecuteNonQuery();
                            CheckMore = true;
                            Cls_Connection.close_connection();
                            Result = true;
                        }

                        else
                        {
                            Result = false;
                            MSG("هذا الشيك غير محال لموظف");

                        }
                    }
                }
                else
                {
                    Result = false;
                    MSG("هذا الشيك غير مدخل من قبل");

                }


            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Cls_Connection.close_connection();
                MSG("هذا الشيك غير مدخل من قبل");

            }
        }

        protected int CheckifDelivered()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select count(id) from  [dbo].[Main_Check]  WHERE Delivered=" + 1 + " and Check_No = '" + Txt_CheckNo.Text + "'";
                Cls_Connection.open_connection();
                int Delivered = int.Parse(cmd.ExecuteScalar().ToString());
                Cls_Connection.close_connection();
                return Delivered;
            }
            catch
            {
                return 0;
            }

        }

        protected int CheckifDelivered2()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select count(id) from  [dbo].[Main_Check]  WHERE Delivered=" + 1 + " and BarCode = '*" + Txt_BarCode.Text + "*'";
                Cls_Connection.open_connection();
                int Delivered = int.Parse(cmd.ExecuteScalar().ToString());
                Cls_Connection.close_connection();
                return Delivered;
            }
            catch
            {
                return 0;
            }

        }

        protected void Btn_Save2_Click(object sender, EventArgs e)
        {
            if (Txt_CheckNo.Text == "")
            {
                MSG("يرجى إدخال رقم الشيك");
                return;
            }

            int Delivered = 0;
            Delivered = CheckifDelivered();
            if (Delivered > 0)
            {
                MSG("لقد تم تسليم هذا الشيك مسبقا");
                return;
            }

            CheckMore = false;
            Result = false;
            SaveAssignNameToChecked2();
            if (Result == true)
            {
                ////////////////////////////////       Log        /////////////////////////////////////////////
                Cls_Log log = new Cls_Log();
                log._Log_Event = " تسليم الشيك رقم   : " + Txt_CheckNo.Text;
                log.Insert_Log();
                ////////////////////////////////   End Of Log        /////////////////////////////////////////////
                Get_MainChecks_ForGridView();
            }
            Txt_CheckNo.Text = "";
            Txt_CheckNo.Focus();
        }

        protected void Btn_Save1_Click(object sender, EventArgs e)
        {
            if (Txt_BarCode.Text == "")
            {
                MSG("يرجى إدخال البار كود");
                return;
            }

            int Delivered = 0;
            Delivered = CheckifDelivered2();
            if (Delivered > 0)
            {
                MSG("لقد تم تسليم هذا الشيك مسبقا");
                return;
            }

            Result = false;
            SaveAssignNameToChecked();
            if (Result == true)
            {
                ////////////////////////////////       Log        /////////////////////////////////////////////
                Cls_Log log = new Cls_Log();
                log._Log_Event = " تسليم الشيك رقم الباركود  : " + Txt_BarCode.Text;
                log.Insert_Log();
                ////////////////////////////////   End Of Log        /////////////////////////////////////////////

                Get_MainChecks_ForGridView();

            }
            Txt_BarCode.Text = "";
            Txt_BarCode.Focus();

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
                cmd.Connection = con;
                cmd.CommandText = "UPDATE [dbo].[Main_Check] SET [Delivered] = " + 0 + ",Modified= " + DateTime.UtcNow + " WHERE BarCode = '" + GV_ChecksAssigned.Rows[0].Cells[12].Text + "'";
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
            log._Log_Event = " تراجع عن تسليم الشيك رقم الباركود   : " + GV_ChecksAssigned.Rows[0].Cells[12].Text;
            log.Insert_Log();
            ////////////////////////////////   End Of Log        /////////////////////////////////////////////
            Get_MainChecks_ForGridView();
        }

        protected void Btn_Delete_Click(object sender, EventArgs e)
        {
            ClearTempTable();
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
                cmd.CommandText = "Get_MainChecks_AssignChecks5";
                cmd.Parameters.AddWithValue("@EmployeeName", empname);
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
    }
}