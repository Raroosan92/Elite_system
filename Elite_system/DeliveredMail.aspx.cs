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
    public partial class DeliveredMail : System.Web.UI.Page
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
        
        int Exist;
        bool Result;


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Security", "CA2100:Review SQL queries for security vulnerabilities", Justification = "<Pending>")]
        public void SaveAssignNameToMail()
        {
            try
            {
                //Check If Exist
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select count(id) from  [dbo].[Main_Mail]  WHERE BarCode = '*" + Txt_BarCode.Text + "*'";
                Cls_Connection.open_connection();
                int Exist = int.Parse(cmd.ExecuteScalar().ToString());
                cmd.Parameters.Clear();
                cmd.CommandText = "select EmployeeName from  [dbo].[Main_Mail]  WHERE BarCode = '*" + Txt_BarCode.Text + "*'";
                empname = cmd.ExecuteScalar().ToString();
                Cls_Connection.close_connection();

                if (Exist == 1)
                {
                    if (empname != "")
                    {
                        //To Update Name in checkes
                        string dt1 = DateTimeOffset.UtcNow.AddHours(3).ToString("yyyy-MM-dd");
                        cmd.CommandText = "UPDATE [dbo].[Main_Mail] SET [Delivered] = " + 1 + ",Refunded=" + 0 + ",Delivery_Date= '" + dt1 + "' WHERE BarCode = '*" + Txt_BarCode.Text + "*'";
                        Cls_Connection.open_connection();
                        cmd.ExecuteNonQuery();
                        Cls_Connection.close_connection();
                        //InsertLog();
                        Result = true;
                    }
                    else
                    {
                        Result = false;
                        MSG("هذا البريد غير محال لموظف");

                    }
                }
                else
                {
                    Result = false;
                    MSG("هذا البريد غير مدخل من قبل");

                }


            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Cls_Connection.close_connection();
                MSG("هذا البريد غير مدخل من قبل");

            }
        }
        //public void SaveAssignNameToMail2()
        //{
        //    try
        //    {
        //        //Check If Exist
        //        SqlConnection con = new SqlConnection();
        //        con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
        //        con = Cls_Connection._con;
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = con;
        //        cmd.CommandText = "select count(id) from  [dbo].[Main_Mail]  WHERE Check_No = '" + Txt_CheckNo.Text + "'";
        //        Cls_Connection.open_connection();
        //        int Exist = int.Parse(cmd.ExecuteScalar().ToString());
        //        cmd.Parameters.Clear();
        //        cmd.CommandText = "select EmployeeName from  [dbo].[Main_Mail]  WHERE Check_No = '" + Txt_CheckNo.Text + "'";
        //        string empname = cmd.ExecuteScalar().ToString();
        //        Cls_Connection.close_connection();

        //        if (Exist == 1)
        //        {
        //            if (empname != "")
        //            {
        //                //To Update Name in checkes
        //                string dt1 = DateTimeOffset.UtcNow.AddHours(3).ToString("yyyy-MM-dd");
        //                cmd.CommandText = "UPDATE [dbo].[Main_Mail] SET [Delivered] = " + 1 + ",Refunded=" + 0 + ",Delivery_Date= '" + dt1 + "' WHERE Check_No = '" + Txt_CheckNo.Text + "'";
        //                Cls_Connection.open_connection();
        //                cmd.ExecuteNonQuery();
        //                Cls_Connection.close_connection();
        //                InsertLog();
        //                Result = true;
        //            }

        //            else
        //            {
        //                Result = false;
        //                MSG("هذا البريد غير محال لموظف");

        //            }
        //        }

        //        else if (Exist > 1)
        //        {
        //            if (DDL_Sent_To.SelectedValue == "0")
        //            {

        //                Result = false;
        //                MSG("يرجى اختيار الجهة الطبية");


        //            }

        //            else
        //            {

        //                if (empname != "")
        //                {
        //                    //To Update Name in checkes
        //                    string dt1 = DateTimeOffset.UtcNow.AddHours(3).ToString("yyyy-MM-dd");
        //                    cmd.CommandText = "UPDATE [dbo].[Main_Mail] SET [Delivered] = " + 1 + ",Refunded=" + 0 + ",Delivery_Date= '" + dt1 + "' WHERE Check_No = '" + Txt_CheckNo.Text + "' and Sent_To=" + long.Parse(DDL_Sent_To.SelectedValue);
        //                    Cls_Connection.open_connection();
        //                    cmd.ExecuteNonQuery();
        //                    CheckMore = true;
        //                    Cls_Connection.close_connection();
        //                    InsertLog();
        //                    Result = true;
        //                }

        //                else
        //                {
        //                    Result = false;
        //                    MSG("هذا البريد غير محال لموظف");

        //                }
        //            }
        //        }
        //        else
        //        {
        //            Result = false;
        //            MSG("هذا البريد غير مدخل من قبل");

        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Message.ToString();
        //        Cls_Connection.close_connection();
        //        MSG("هذا البريد غير مدخل من قبل");

        //    }
        //}

        //protected int CheckifDelivered()
        //{
        //    try
        //    {
        //        SqlConnection con = new SqlConnection();
        //        con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
        //        con = Cls_Connection._con;
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = con;
        //        cmd.CommandText = "select count(id) from  [dbo].[Main_Mail]  WHERE Delivered=" + 1 + " and Check_No = '" + Txt_CheckNo.Text + "'";
        //        Cls_Connection.open_connection();
        //        int Delivered = int.Parse(cmd.ExecuteScalar().ToString());
        //        Cls_Connection.close_connection();
        //        return Delivered;
        //    }
        //    catch
        //    {
        //        return 0;
        //    }

        //}
        //protected int CheckifRefunded()
        //{
        //    try
        //    {
        //        SqlConnection con = new SqlConnection();
        //        con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
        //        con = Cls_Connection._con;
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = con;
        //        cmd.CommandText = "select count(id) from  [dbo].[Main_Mail]  WHERE Refunded=" + 1 + " and Check_No = '" + Txt_CheckNo.Text + "'";
        //        Cls_Connection.open_connection();
        //        int Refunded = int.Parse(cmd.ExecuteScalar().ToString());
        //        Cls_Connection.close_connection();
        //        return Refunded;
        //    }
        //    catch
        //    {
        //        return 0;
        //    }

        //}

        protected int CheckifDelivered2()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select count(id) from  [dbo].[Main_Mail]  WHERE Delivered=" + 1 + " and BarCode = '*" + Txt_BarCode.Text + "*'";
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
        protected int CheckifRefunded2()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select count(id) from  [dbo].[Main_Mail]  WHERE Refunded=" + 1 + " and BarCode = '*" + Txt_BarCode.Text + "*'";
                Cls_Connection.open_connection();
                int Refunded = int.Parse(cmd.ExecuteScalar().ToString());
                Cls_Connection.close_connection();
                return Refunded;
            }
            catch
            {
                return 0;
            }

        }

        //protected void Btn_Save2_Click(object sender, EventArgs e)
        //{
        //    if (Txt_CheckNo.Text == "")
        //    {
        //        MSG("يرجى إدخال رقم البريد");
        //        return;
        //    }

        //    int Delivered = 0;
        //    Delivered = CheckifDelivered();
        //    if (Delivered > 0)
        //    {
        //        MSG("لقد تم تسليم هذا البريد مسبقا");
        //        return;
        //    }
        //    int Refunded = 0;
        //    Refunded = CheckifRefunded();
        //    if (Refunded > 0)
        //    {
        //        MSG("لقد تم ارجاع هذا البريد مسبقا");
        //        return;
        //    }
        //    CheckMore = false;
        //    Result = false;
        //    SaveAssignNameToMail2();
        //    if (Result == true)
        //    {
        //        ////////////////////////////////       Log        /////////////////////////////////////////////
        //        Cls_Log log = new Cls_Log();
        //        log._Log_Event = " تسليم البريد رقم   : " + Txt_CheckNo.Text;
        //        log.Insert_Log();
        //        ////////////////////////////////   End Of Log        /////////////////////////////////////////////
        //        Get_MainChecks_ForGridView();
        //    }
        //    Txt_CheckNo.Text = "";
        //    Txt_CheckNo.Focus();
        //}

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
                MSG("لقد تم تسليم هذا البريد مسبقا");
                return;
            }
            int Refunded = 0;
            Refunded = CheckifRefunded2();
            if (Refunded > 0)
            {
                MSG("لقد تم ارجاع هذا البريد مسبقا");
                return;
            }

            Result = false;
            SaveAssignNameToMail();
            if (Result == true)
            {
                ////////////////////////////////       Log        /////////////////////////////////////////////
                Cls_Log log = new Cls_Log();
                log._Log_Event = " تسليم البريد رقم الباركود  : " + Txt_BarCode.Text;
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
                string dt1 = DateTimeOffset.UtcNow.AddHours(3).ToString("yyyy-MM-dd");
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE [dbo].[Main_Mail] SET [Delivered] = " + 0 + ",Delivery_Date= NULL WHERE BarCode = '" + GV_ChecksAssigned.Rows[0].Cells[11].Text + "'";
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
            log._Log_Event = " تراجع عن تسليم البريد رقم الباركود   : " + GV_ChecksAssigned.Rows[0].Cells[12].Text;
            log.Insert_Log();
            ////////////////////////////////   End Of Log        /////////////////////////////////////////////
            Get_MainChecks_ForGridView();
        }

        protected void Btn_Delete_Click(object sender, EventArgs e)
        {
            ClearTempTable();
        }

        //public void InsertLog()
        //{
        //    try
        //    {
        //        Cls_ChecksLog clog = new Cls_ChecksLog();
        //        DataTable dt = new DataTable();
        //        SqlConnection con = new SqlConnection();
        //        con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
        //        con = Cls_Connection._con;
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = con;
        //        cmd.CommandText = "select * from V_Main_Check where Check_No = '" + Txt_BarCode.Text + "'";
        //        Cls_Connection.open_connection();
        //        SqlDataReader dr = cmd.ExecuteReader();

        //        while (dr.Read())
        //        {
        //            clog._Check_Date = (DateTime)dr.GetValue(dr.GetOrdinal("Check_Date"));
        //            clog._Check_Barcode = dr.GetValue(dr.GetOrdinal("BarCode")).ToString();
        //            clog._Check_EmpName = dr.GetValue(dr.GetOrdinal("EmployeeName")).ToString();
        //            clog._Check_MedicalName = dr.GetValue(dr.GetOrdinal("SentTo")).ToString();
        //            clog._Check_Number = dr.GetValue(dr.GetOrdinal("Check_No")).ToString();
        //            clog._Check_Type = 1;
        //            clog._Check_Company = dr.GetValue(dr.GetOrdinal("Company")).ToString();
        //            Cls_Connection.close_connection();
        //            clog.Insert_Log();
        //        }
        //        Cls_Connection.close_connection();
        //    }
        //    catch (Exception ex)
        //    {
        //        Cls_Connection.close_connection();
        //        return;
        //    }

        //}

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
                cmd.CommandText = "Get_MainMail_AssignMail5";
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