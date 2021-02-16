﻿using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
        string Num;
        int Exist;
        public void MSG(string Text)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('" + Text + "')</script>", false);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                Get_MainChecks_GridView2();
                Btn_Delete.Style.Add("Display", "None");
                //btnPrint.Style.Add("Display", "None");
                DDL_Employee.DataSource = Cls_Employees.Get_Employee();
                DDL_Employee.DataBind();
                DDL_Employee.SelectedValue = "15";

                DDL_Sent_To.DataSource = Cls_Main_Claims.Get_Medical_Types();
                DDL_Sent_To.DataBind();
                DDL_Sent_To.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--اختر--", "0"));
            }
        }
        //public void Get_MainChecks_GridView()
        //{
        //    try
        //    {


        //        //To Transmit Data To GridView
        //        SqlConnection con = new SqlConnection();

        //        con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
        //        con = Cls_Connection._con;
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = con;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "Get_MainChecks_AssignChecks";
        //        cmd.Parameters.AddWithValue("@BarCode", Txt_BarCode.Text);
        //        Cls_Connection.open_connection();
        //        DataTable dt = new DataTable();
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        da.Fill(dt);
        //        GV_ChecksAssigned.DataSourceID = null;
        //        GV_ChecksAssigned.DataSource = dt;
        //        GV_ChecksAssigned.DataBind();
        //        Btn_Delete.Style.Add("Display", "inline-block");
        //        //btnPrint.Style.Add("Display", "inline-block");
        //        Cls_Connection.close_connection();



        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Message.ToString();
        //        Cls_Connection.close_connection();


        //    }

        //}

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
                string dt1 = DateTimeOffset.UtcNow.AddHours(2).ToString("yyyy-MM-dd");
                cmd.CommandText = "select ROW_NUMBER() OVER (ORDER BY [id] ASC) as 'التسلسل', SentTo 'الجهة الطبية',Company 'الشركة',[Value] 'القيمة',Check_No 'رقم الشيك',EmployeeName 'اسم الموظف المحال له' from V_Main_Check where Modified = '" + dt1 + "' order by ROW_NUMBER() OVER (ORDER BY [id] desc)";
                Cls_Connection.open_connection();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                GridView2.DataSourceID = null;
                GridView2.DataSource = dt;
                GridView2.DataBind();
                Cls_Connection.close_connection();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Cls_Connection.close_connection();


            }

        }

        //public void Get_MainChecks_GridViewTemp()
        //{
        //    try
        //    {


        //        //To Transmit Data To GridView
        //        SqlConnection con = new SqlConnection();

        //        con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
        //        con = Cls_Connection._con;
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = con;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "Get_MainChecks_AssignChecksTemp";
        //        Cls_Connection.open_connection();
        //        DataTable dt = new DataTable();
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        da.Fill(dt);
        //        GV_ChecksAssigned.DataSourceID = null;
        //        GV_ChecksAssigned.DataSource = dt;
        //        GV_ChecksAssigned.DataBind();
        //        Cls_Connection.close_connection();



        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Message.ToString();
        //        Cls_Connection.close_connection();


        //    }

        //}

        public void Get_MainChecks_ForGridView()
        {
            //if (Txt_BarCode.Text!="")
            //{
            Num = DDL_Employee.SelectedItem.Text;
            //}
            //else if (Txt_CheckNo.Text != "")
            //{
            //    Num = Txt_CheckNo.Text;
            //}
            try
            {

                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Get_MainChecks_AssignChecks4";
                cmd.Parameters.AddWithValue("@EmployeeName", Num);
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
            Get_MainChecks_GridView2();
        }

        //public void SaveAssignCheckedToTempTable()
        //{

        //    SqlConnection con = new SqlConnection();
        //    con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
        //    con = Cls_Connection._con;
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Connection = con;
        //    cmd.CommandText = "select count(id) from AssignChekesTemp where CheckNum='" + Txt_BarCode.Text + "'";
        //    Cls_Connection.open_connection();
        //    Exist = int.Parse(cmd.ExecuteScalar().ToString());
        //    Cls_Connection.close_connection();

        //    if (Exist == 0)
        //    {
        //        try
        //        {
        //            if (GV_ChecksAssigned.Rows.Count != 0)
        //            {
        //                //To Save Data To Table Temporary

        //                //Get the GridView Row.
        //                GridViewRow row = GV_ChecksAssigned.Rows[0];

        //                cmd.Parameters.Clear();
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.CommandText = "[AssignChekes_Temp]";
        //                cmd.Parameters.AddWithValue("@id", GV_ChecksAssigned.Rows[0].Cells[1].Text);
        //                cmd.Parameters.AddWithValue("@CompanyName", GV_ChecksAssigned.Rows[0].Cells[2].Text);
        //                cmd.Parameters.AddWithValue("@CheckDate", GV_ChecksAssigned.Rows[0].Cells[3].Text);
        //                cmd.Parameters.AddWithValue("@BankName", GV_ChecksAssigned.Rows[0].Cells[4].Text);
        //                cmd.Parameters.AddWithValue("@SentTo", GV_ChecksAssigned.Rows[0].Cells[5].Text);
        //                cmd.Parameters.AddWithValue("@Value", GV_ChecksAssigned.Rows[0].Cells[6].Text);
        //                cmd.Parameters.AddWithValue("@CheckNum", GV_ChecksAssigned.Rows[0].Cells[7].Text);
        //                cmd.Parameters.AddWithValue("@Month", GV_ChecksAssigned.Rows[0].Cells[8].Text);
        //                cmd.Parameters.AddWithValue("@Notes", GV_ChecksAssigned.Rows[0].Cells[9].Text);
        //                cmd.Parameters.AddWithValue("@Address", GV_ChecksAssigned.Rows[0].Cells[10].Text);
        //                cmd.Parameters.AddWithValue("@PhoneNumber", GV_ChecksAssigned.Rows[0].Cells[11].Text);
        //                cmd.Parameters.AddWithValue("@BarCode", GV_ChecksAssigned.Rows[0].Cells[12].Text);
        //                cmd.Parameters.AddWithValue("@EmpName", GV_ChecksAssigned.Rows[0].Cells[13].Text);
        //                bool Delivered = (row.Cells[14].Controls[0] as CheckBox).Checked;
        //                bool Refunded = (row.Cells[15].Controls[0] as CheckBox).Checked;
        //                cmd.Parameters.AddWithValue("@Delivered", Delivered);
        //                cmd.Parameters.AddWithValue("@Refunded", Refunded);
        //                Cls_Connection.open_connection();
        //                cmd.ExecuteNonQuery();
        //                Cls_Connection.close_connection();
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            Cls_Connection.close_connection();
        //        }
        //    }
        //    else
        //    {
        //        MSG("هذا الشيك تمت إحالته مسبقاً");
        //    }
        //}

        public void InsertLog()
        {
            try
            {


                Cls_ChecksLog clog = new Cls_ChecksLog();

                DataTable dt = new DataTable();

                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from V_Main_Check where Check_No = '" + Txt_BarCode.Text + "'";
                Cls_Connection.open_connection();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    clog._Check_Date = (DateTime)dr.GetValue(dr.GetOrdinal("Check_Date"));
                    clog._Check_Barcode = dr.GetValue(dr.GetOrdinal("BarCode")).ToString();
                    clog._Check_EmpName = DDL_Employee.SelectedItem.Text;
                    clog._Check_MedicalName = dr.GetValue(dr.GetOrdinal("SentTo")).ToString();
                    clog._Check_Number = dr.GetValue(dr.GetOrdinal("Check_No")).ToString();
                    clog._Check_Type = 0;
                    clog._Check_Company = dr.GetValue(dr.GetOrdinal("Company")).ToString();
                    Cls_Connection.close_connection();
                    clog.Insert_Log();
                }
                Cls_Connection.close_connection();
            }
            catch (Exception ex)
            {
                Cls_Connection.close_connection();
                return;
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
                Cls_Connection.close_connection();
                if (Exist == 1)
                {
                    //To Update Name in checkes
                    string dt1 = DateTimeOffset.UtcNow.AddHours(2).ToString("yyyy-MM-dd");
                    cmd.CommandText = "UPDATE [dbo].[Main_Check] SET [EmployeeName] = N'" + DDL_Employee.SelectedItem.ToString() + "',[Refunded] = " + 0 + ",Delivered=" + 0 + ",Modified= '" + dt1 + "' WHERE BarCode = '*" + Txt_BarCode.Text + "*'";
                    Cls_Connection.open_connection();
                    cmd.ExecuteNonQuery();
                    Cls_Connection.close_connection();
                    InsertLog();
                }
                else
                {
                    MSG("هذا الشيك غير مدخل من قبل");
                }


            }
            catch (Exception ex)
            {

                throw ex;
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
                    string dt1 = DateTimeOffset.UtcNow.AddHours(2).ToString("yyyy-MM-dd");
                    cmd.CommandText = "UPDATE [dbo].[Main_Check] SET [EmployeeName] = N'" + DDL_Employee.SelectedItem.ToString() + "',[Refunded] = " + 0 + ",Delivered=" + 0 + ",Modified= '" + dt1 + "' WHERE Check_No = '" + Txt_CheckNo.Text + "'";
                    Cls_Connection.open_connection();
                    cmd.ExecuteNonQuery();
                    Check = true;
                    InsertLog();
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
                        string dt1 = DateTimeOffset.UtcNow.AddHours(2).ToString("yyyy-MM-dd");
                        cmd.CommandText = "UPDATE [dbo].[Main_Check] SET [EmployeeName] = N'" + DDL_Employee.SelectedItem.ToString() + "',[Refunded] = " + 0 + ",Delivered=" + 0 + ",Modified= " + dt1 + " WHERE Check_No = '" + Txt_CheckNo.Text + "' and Sent_To=" + long.Parse(DDL_Sent_To.SelectedValue);
                        Cls_Connection.open_connection();
                        cmd.ExecuteNonQuery();
                        Check = true;
                        CheckMore = true;

                        Cls_Connection.close_connection();
                        InsertLog();
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


                cmd.CommandText = "select EmployeeName from  [dbo].[Main_Check]  WHERE Refunded=" + 0 + " and BarCode = '*" + Txt_BarCode.Text + "*'";


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
            try
            {
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
            }
            catch (Exception EX)
            {
                MSG(EX.Message.ToString());
                //throw EX;
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
            Txt_CheckNo.Text = "";
            Txt_CheckNo.Focus();
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
                string dt1 = DateTimeOffset.UtcNow.AddHours(2).ToString("yyyy-MM-dd");
                cmd.CommandText = "UPDATE [dbo].[Main_Check] SET [EmployeeName] = NULL ,Modified= '" + dt1 + "' WHERE BarCode = '" + GV_ChecksAssigned.Rows[0].Cells[12].Text + "'";
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

        
        //private void PrintPDF()
        //{
        //    using (StringWriter sw = new StringWriter())
        //    {
        //        using (HtmlTextWriter hw = new HtmlTextWriter(sw))
        //        {

        //            StringReader sr = new StringReader(sw.ToString());
                    
                    
        //            Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
        //            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        //            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        //            pdfDoc.Open();
                    
        //            htmlparser.Parse(sr);
        //            pdfDoc.Close();
        //             GridView2.RenderControl(hw);
        //            Response.ContentType = "application/pdf";
        //            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.pdf");
        //            Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //            Response.Write(pdfDoc);
        //            Response.End();
        //        }
        //    }
        //}
    

        //public override void VerifyRenderingInServerForm(Control control)
        //{
        //    return;
        //}
        //protected void OnPaging(object sender, GridViewPageEventArgs e)
        //{
        //    GV_ChecksAssigned.PageIndex = e.NewPageIndex;
        //    GV_ChecksAssigned.DataBind();
        //}

        //protected void Button2_Click(object sender, EventArgs e)
        //{
        //    PrintPDF();
        //}

    }
}