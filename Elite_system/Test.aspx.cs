using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Elite_system
{
    public partial class Test : System.Web.UI.Page
    {
        double Stamp;
        double Value;
        double Count;
        int Attch_Id;
        DataTable dt_Claims_GV2 = new DataTable();
        DataTable dt_Claims_GV1 = new DataTable();
        public void MSG(string Text)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('" + Text + "')</script>", false);
        }
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!Page.IsPostBack)
            {
                //rami
                slider.Visible = false;
                //Btn_Update_SubClaims.Visible = HttpContext.Current.User.IsInRole("Admin");
                Btn_Update.Visible = HttpContext.Current.User.IsInRole("Admin");
                //rami
                // ------------- Get MonthYear ----------------------
                string MonthYear;
                int Month = int.Parse(DateTime.Now.Month.ToString());
                int Year = int.Parse(DateTime.Now.Year.ToString());
                if (Month > 1)
                {
                    MonthYear = (Month - 1).ToString() + "/" + Year.ToString();
                }
                else
                {
                    Year = Year - 1;
                    MonthYear = "12/" + (Year).ToString();
                }
                Txt_Month_Year.Text = MonthYear;
                // ------------------------------------------------
                DDL_Medical_Name.DataSource = Cls_Main_Claims.Get_Medical_Types();
                DDL_Medical_Name.DataBind();
                DDL_Medical_Name.Items.Insert(0, new ListItem("--اختر--", "0"));

                DDL_Medical_Name_Search.DataSource = Cls_Main_Claims.Get_Medical_Types();
                DDL_Medical_Name_Search.DataBind();
                DDL_Medical_Name_Search.Items.Insert(0, new ListItem("--اختر--", "0"));



                DDL_Receiver_Employee.DataSource = Cls_Employees.Get_Employee();
                DDL_Receiver_Employee.DataBind();
                DDL_Receiver_Employee.Items.Insert(0, new ListItem("--اختر--", "0"));


                DDL_Main_Company.DataSource = Cls_Main_Claims.Get_Companies();
                DDL_Main_Company.DataBind();
                DDL_Main_Company.Items.Insert(0, new ListItem("--اختر--", "0"));

                Txt_Entry_Date.Text = DateTime.Now.ToString("yyyy-MM-dd");

                Fill_Claims_GV2();
            }

        }
        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            //rami
            if (DDL_Medical_Name.SelectedIndex != 0)
            {
                string Result;
                Cls_Main_Claims Main_Claims = new Cls_Main_Claims();
                Main_Claims._Batch_No = int.Parse(Txt_Batch_No.Text);

                Main_Claims._Entry_Date = DateTime.Now;

                if (DDL_Medical_Name.SelectedValue != "")
                {
                    Main_Claims._Medical_Name = int.Parse(DDL_Medical_Name.SelectedValue);
                }

                Main_Claims._Month_Year = Txt_Month_Year.Text;
                if (Txt_Received_Date.Text != "")
                {
                    Main_Claims._Received_Date = DateTime.Parse(Txt_Received_Date.Text);
                }

                if (DDL_Receiver_Employee.SelectedValue != "")
                {
                    Main_Claims._Receiver_Employee = int.Parse(DDL_Receiver_Employee.SelectedValue);
                }

                if (DDL_Main_Company.SelectedValue != "")
                {
                    Main_Claims._Main_Company = long.Parse(DDL_Main_Company.SelectedValue);
                }

                //------------- Calculate Stamps ----------------------------------------
                //Value = double.Parse(Txt_Value.Text);
                ////Count = double.Parse(Txt_Claims_Count.Text);
                //Stamp = ((Value * 0.006) + 0.5);
                //Txt_Stamps.Text =( Math.Ceiling(Stamp * 10) / 10).ToString();
                //------------------------------------------------------------------------
                Main_Claims._Stamps = decimal.Parse(Txt_Stamps.Text);
                if (DDL_Sub_Company.SelectedValue != "")
                {
                    Main_Claims._Sub_Company = long.Parse(DDL_Sub_Company.SelectedValue);
                }
                Main_Claims._Claims_Count = int.Parse(Txt_Claims_Count.Text);
                Main_Claims._Value = double.Parse(Txt_Value.Text);

                if (RB_Delivered.SelectedValue == "1")
                {
                    Main_Claims._Delivered = true;
                }
                else
                {
                    Main_Claims._Delivered = false;
                }


                Result = Main_Claims.Insert_Main_Claims();
                ////////////////////////////////       Log        /////////////////////////////////////////////
                Cls_Log log = new Cls_Log();
                log._Log_Event = "إضافة على المطالبات الرئيسية على الجهة الطبية: " + DDL_Medical_Name.SelectedItem.Text;
                log.Insert_Log();
                ////////////////////////////////   End Of Log        /////////////////////////////////////////////
                //GridView2.DataBind();



                //rami
                int attach_type = 300;
                string attach_place_store;
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand();
                DataSet ds = new DataSet();
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CONN"].ConnectionString);
                conn.Open();
                cmd.Connection = conn;

                cmd.CommandText = "Select IDENT_CURRENT('Main_claims')";
                int strImageName = int.Parse(cmd.ExecuteScalar().ToString());

                DateTime datevalue = (DateTime.Now);
                string dd = datevalue.Day.ToString();
                string mm = datevalue.Month.ToString();
                string yy = datevalue.Year.ToString();

                try
                {
                    HttpFileCollection flImages = Request.Files;

                    for (int i = 0; i < flImages.Count; i++)
                    {
                        HttpPostedFile userPostedFile = flImages[i];

                        cmd.Parameters.Clear();
                        cmd.CommandText = "Select IDENT_CURRENT('Attachments')";
                        Attch_Id = int.Parse(cmd.ExecuteScalar().ToString()) + 1;
                        cmd.Parameters.Clear();

                        try
                        {
                            if (userPostedFile.ContentLength > 0)

                            {
                                if (System.IO.Path.GetExtension(userPostedFile.FileName).ToLower() == ".jpeg" || System.IO.Path.GetExtension(userPostedFile.FileName).ToLower() == ".jpg" || System.IO.Path.GetExtension(userPostedFile.FileName).ToLower() == ".png" || System.IO.Path.GetExtension(userPostedFile.FileName).ToLower() == ".bmp")
                                {
                                    string strConnString = ConfigurationManager.ConnectionStrings["CONN"].ConnectionString;

                                    using (SqlConnection con = new SqlConnection(strConnString))
                                    {
                                        //////////////////////////////////////////////////
                                        attach_place_store = "\\\\Claims" + "\\\\" + yy + "\\\\" + mm + "\\\\" + dd + "\\\\" + Attch_Id + ".jpg";
                                        using (SqlCommand cmd1 = new SqlCommand())
                                        {
                                            cmd1.CommandType = CommandType.StoredProcedure;
                                            cmd1.CommandText = "SP_Attachments";
                                            cmd1.Parameters.AddWithValue("@attach_type", attach_type);
                                            cmd1.Parameters.AddWithValue("@attach_Path", attach_place_store);
                                            cmd1.Parameters.AddWithValue("@attach_doc_id", strImageName);
                                            cmd1.Parameters.AddWithValue("@check", "i");
                                            cmd1.Connection = con;
                                            con.Open();
                                            cmd1.ExecuteNonQuery();
                                            con.Close();
                                        }
                                    }

                                    System.IO.Directory.CreateDirectory(Server.MapPath("\\UploadedImages\\Claims\\" + yy + "\\" + mm + "\\" + dd + "\\"));
                                    userPostedFile.SaveAs(Server.MapPath("\\UploadedImages\\" + attach_place_store));
                                }
                                else
                                {
                                    MSG("الملف الذي قمت بإدخاله غير صالح");
                                }
                            }

                        }
                        catch (Exception)
                        {
                            MSG("يوجد خطأ يرجى مراجعة مسؤول النظام");
                        }

                    }
                }
                catch (Exception)
                {

                    MSG("يرجى مراجعة مسؤول النظام");
                }

                MSG(Result);
            }
            else
            {
                MSG("يرجى ادخال تفاصيل المعاملة");
            }

            //rami

            Fill_Claims_GV2();
            Fill_Claims_GV1(DDL_Medical_Name.SelectedItem.Text, Txt_Month_Year.Text);

        }
        protected void Txt_Value_TextChanged(object sender, EventArgs e)
        {
            Value = double.Parse(Txt_Value.Text);
            //Count = double.Parse(Txt_Claims_Count.Text);
            Stamp = ((Value * 0.006) + 0.5);
            Txt_Stamps.Text = (Math.Ceiling(Stamp * 10) / 10).ToString();

        }

        protected void Btn_Delete_Click(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.IsInRole("Admin"))
            {

                LinkButton btn = (LinkButton)sender;
                int attch_id = Convert.ToInt16(btn.CommandArgument);
                SqlConnection con = new SqlConnection();
                try
                {
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                    con = Cls_Connection._con;
                    SqlCommand cmd = new SqlCommand();
                    //cmd.CommandText = "select attach_Path from Attachments where  Attach_Id = " + DDl_Images.SelectedValue + "";
                    cmd.CommandText = "select attach_Path from Attachments where  Attach_Id = " + attch_id + "";
                    cmd.Connection = con;
                    con.Open();
                    string fileName = cmd.ExecuteScalar().ToString();
                    cmd.Parameters.Clear();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_Attachments";
                    cmd.Parameters.AddWithValue("@Attach_Id", attch_id);
                    cmd.Parameters.AddWithValue("@check", "d");

                    cmd.ExecuteNonQuery();


                    con.Close();

                    //string dd = "C:\\Users\\Rami\\Desktop\\Rami&Shadi 13-1-2020\\Elite_system\\Elite_system\\UploadedImages" + fileName.Replace("\\\\","\\");
                    string dd = "\\UploadedImages" + fileName.Replace("\\\\", "\\");
                    string sss = Server.MapPath(dd);
                    if (File.Exists(sss))
                    {
                        File.Delete(sss);
                    }

                    //Fill_DDL_Images(Convert.ToInt16(GridView2.SelectedRow.Cells[1].Text));
                    Get_MainClaims_ForUpdate2();
                    MSG("تم حذف الصورة بنجاح");
                }
                catch
                {
                    con.Close();
                    MSG("يوجد خطأ في حذف الصورة");
                }
            }
            else
            {
                MSG("انت لست مخول لحذف الصورة يرجى مراجعة مسؤول النظام");
            }
        }

        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            if (DDL_Medical_Name_Search.SelectedItem.Text == "--اختر--")
            {
                Fill_Claims_GV2();
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
            else
            {
                Search_Claims_GV2(DDL_Medical_Name_Search.SelectedItem.Text);
                GridView1.DataSource = null;
                GridView1.DataBind();
            }

        }

  

        public void Get_MainClaims_ForUpdate2()
        {
            try
            {

                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Get_MainClaims_ForUpdate";
                cmd.Parameters.AddWithValue("@ID", Convert.ToInt64(GridView1.SelectedRow.Cells[1].Text));
                Cls_Connection.open_connection();
                SqlDataReader dr = cmd.ExecuteReader();
                bool Result;

                string Entry_Date;
                DateTime Entry_Date2;
                string Received_Date;
                DateTime Received_Date2;
                string Sub_Company = "";

                while (dr.Read())
                {

                    Txt_Batch_No.Text = dr.GetValue(dr.GetOrdinal("Batch_No")).ToString();
                    Txt_ID.Text = dr.GetValue(dr.GetOrdinal("ID")).ToString();
                    Txt_Month_Year.Text = dr.GetValue(dr.GetOrdinal("Month_Year")).ToString();

                    if (!dr.IsDBNull(dr.GetOrdinal("Medical_Name")))
                    {
                        DDL_Medical_Name.SelectedValue = dr.GetValue(dr.GetOrdinal("Medical_Name")).ToString();
                    }


                    Entry_Date = dr.GetValue(dr.GetOrdinal("Entry_Date")).ToString();
                    Result = DateTime.TryParse(Entry_Date, out Entry_Date2);
                    if (Result)
                    {
                        Txt_Entry_Date.Text = Entry_Date2.ToString("yyyy-MM-dd");
                    }

                    Received_Date = dr.GetValue(dr.GetOrdinal("Received_Date")).ToString();
                    Result = DateTime.TryParse(Received_Date, out Received_Date2);
                    if (Result)
                    {
                        Txt_Received_Date.Text = Received_Date2.ToString("yyyy-MM-dd");
                    }

                    if (!dr.IsDBNull(dr.GetOrdinal("Receiver_Employee")))
                    {
                        DDL_Receiver_Employee.SelectedValue = dr.GetValue(dr.GetOrdinal("Receiver_Employee")).ToString();
                    }

                    Txt_Claims_Count.Text = dr.GetValue(dr.GetOrdinal("Claims_Count")).ToString();

                    Txt_Value.Text = dr.GetValue(dr.GetOrdinal("Value")).ToString();
                    Txt_Stamps.Text = dr.GetValue(dr.GetOrdinal("Stamps")).ToString();
                    //Txt_Stamps.Text = Math.Round(double.Parse(Txt_Stamps.Text)).ToString();
                    if (!dr.IsDBNull(dr.GetOrdinal("Main_Company")))
                    {
                        DDL_Main_Company.SelectedValue = dr.GetValue(dr.GetOrdinal("Main_Company")).ToString();
                    }

                    if (!dr.IsDBNull(dr.GetOrdinal("Sub_Company")))
                    {
                        Sub_Company = dr.GetValue(dr.GetOrdinal("Sub_Company")).ToString();
                    }
                    RB_Delivered.SelectedValue = dr.GetValue(dr.GetOrdinal("Delivered")).ToString();
                }

                dr.Close();

                Cls_Connection.close_connection();

                if (Sub_Company != "")
                {
                    Cls_Sub_Companies Sub_Companies = new Cls_Sub_Companies();
                    Sub_Companies._Main_Company = long.Parse(DDL_Main_Company.SelectedValue);
                    DDL_Sub_Company.DataSource = Sub_Companies.Get_Sub_Companies();
                    DDL_Sub_Company.DataBind();
                    DDL_Sub_Company.Items.Insert(0, new ListItem("--اختر--", "0"));
                    DDL_Sub_Company.SelectedValue = Sub_Company;

                }
                else
                {
                    DDL_Sub_Company.Items.Clear();
                    DDL_Sub_Company.DataBind();
                }



                //rami
                SqlDataAdapter da2 = new SqlDataAdapter();
                DataSet ds2 = new DataSet();
                SqlCommand cmd2 = new SqlCommand();

                cmd2.Connection = con;
                cmd2.CommandText = "select attach_Path,Attach_Id from Attachments where attach_doc_id=" + Convert.ToInt64(GridView1.SelectedRow.Cells[1].Text) + "";
                Cls_Connection.open_connection();
                cmd2.ExecuteNonQuery();
                da2.SelectCommand = cmd2;
                da2.Fill(ds2, "Attachments");

                if (ds2.Tables[0].Rows.Count > 0)
                {
                    slider.Visible = true;
                    RP_ImagesLi.DataSource = ds2;
                    RP_ImagesLi.DataMember = "Attachments";
                    RP_ImagesLi.DataBind();

                    RP_Image.DataSource = ds2;
                    RP_Image.DataMember = "Attachments";
                    RP_Image.DataBind();

                    //Fill_DDL_Images(Convert.ToInt16(GridView2.SelectedRow.Cells[1].Text));

                }
                else
                {
                    slider.Visible = false;
                    RP_ImagesLi.DataSource = ds2;
                    RP_ImagesLi.DataMember = "Attachments";
                    RP_ImagesLi.DataBind();

                    RP_Image.DataSource = ds2;
                    RP_Image.DataMember = "Attachments";
                    RP_Image.DataBind();
                }
                //rami

                Cls_Connection.close_connection();

                //LoadScannedImage();
                //idcookie.Value = null;
                //attachcookie.Value = null;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Cls_Connection.close_connection();


            }

        }
        protected void DDL_Main_Company_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cls_Sub_Companies Sub_Companies = new Cls_Sub_Companies();
            Sub_Companies._Main_Company = long.Parse(DDL_Main_Company.SelectedValue);
            DDL_Sub_Company.DataSource = Sub_Companies.Get_Sub_Companies();
            DDL_Sub_Company.DataBind();
            DDL_Sub_Company.Items.Insert(0, new ListItem("--اختر--", "0"));


        }

        protected void Btn_Update_Click(object sender, EventArgs e)
        {

            string Result;
            Cls_Main_Claims Main_Claims = new Cls_Main_Claims();
            Main_Claims._Batch_No = int.Parse(Txt_Batch_No.Text);
            if (Txt_Entry_Date.Text != "")
            {
                Main_Claims._Entry_Date = DateTime.Parse(Txt_Entry_Date.Text);
            }
            if (DDL_Medical_Name.SelectedValue != "")
            {
                Main_Claims._Medical_Name = int.Parse(DDL_Medical_Name.SelectedValue);
            }

            Main_Claims._Month_Year = Txt_Month_Year.Text;
            if (Txt_Received_Date.Text != "")
            {
                Main_Claims._Received_Date = DateTime.Parse(Txt_Received_Date.Text);
            }

            if (DDL_Receiver_Employee.SelectedValue != "")
            {
                Main_Claims._Receiver_Employee = int.Parse(DDL_Receiver_Employee.SelectedValue);
            }

            if (DDL_Main_Company.SelectedValue != "")
            {
                Main_Claims._Main_Company = long.Parse(DDL_Main_Company.SelectedValue);
            }

            //------------- Calculate Stamps ----------------------------------------
            //Value = double.Parse(Txt_Value.Text);
            ////Count = double.Parse(Txt_Claims_Count.Text);
            //Stamp = ((Value * 0.006) + 0.5);
            //Txt_Stamps.Text = (Math.Ceiling(Stamp * 10) / 10).ToString();
            //------------------------------------------------------------------------
            Main_Claims._Stamps = decimal.Parse(Txt_Stamps.Text);
            if (DDL_Sub_Company.SelectedValue != "")
            {
                Main_Claims._Sub_Company = long.Parse(DDL_Sub_Company.SelectedValue);
            }
            Main_Claims._Claims_Count = int.Parse(Txt_Claims_Count.Text);
            Main_Claims._Value = double.Parse(Txt_Value.Text);

            if (RB_Delivered.SelectedValue == "1")
            {
                Main_Claims._Delivered = true;
            }
            else
            {
                Main_Claims._Delivered = false;
            }



            Main_Claims._ID = Convert.ToInt64(GridView2.SelectedRow.Cells[1].Text);
            Result = Main_Claims.Update_Main_Claims();
            ////////////////////////////////       Log        /////////////////////////////////////////////
            Cls_Log log = new Cls_Log();
            log._Log_Event = "تعديل على المطالبات الرئيسية على الجهة الطبية: " + DDL_Medical_Name.SelectedItem.Text;
            log.Insert_Log();
            ////////////////////////////////   End Of Log        /////////////////////////////////////////////

            //GridView2.DataBind();



            //rami
            int attach_type = 300;
            string attach_place_store;
            int strImageName = Convert.ToInt16(GridView1.SelectedRow.Cells[1].Text);


            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CONN"].ConnectionString);
            cmd.Connection = conn;
            conn.Open();
            DateTime datevalue = (DateTime.Now);
            string dd = datevalue.Day.ToString();
            string mm = datevalue.Month.ToString();
            string yy = datevalue.Year.ToString();

            try
            {
                HttpFileCollection flImages = Request.Files;

                for (int i = 0; i < flImages.Count; i++)
                {

                    cmd.CommandText = "Select IDENT_CURRENT('Attachments')";
                    Attch_Id = int.Parse(cmd.ExecuteScalar().ToString()) + 1;

                    HttpPostedFile userPostedFile = flImages[i];
                    if (userPostedFile.ContentLength > 0)
                    {
                        if (System.IO.Path.GetExtension(userPostedFile.FileName).ToLower() == ".jpeg" || System.IO.Path.GetExtension(userPostedFile.FileName).ToLower() == ".jpg" || System.IO.Path.GetExtension(userPostedFile.FileName).ToLower() == ".png" || System.IO.Path.GetExtension(userPostedFile.FileName).ToLower() == ".bmp")

                        {
                            string strConnString = ConfigurationManager.ConnectionStrings["CONN"].ConnectionString;

                            using (SqlConnection con = new SqlConnection(strConnString))
                            {

                                attach_place_store = "\\\\Claims" + "\\\\" + yy + "\\\\" + mm + "\\\\" + dd + "\\\\" + Attch_Id + ".jpg";
                                using (SqlCommand cmd1 = new SqlCommand())
                                {
                                    cmd1.CommandType = CommandType.StoredProcedure;
                                    cmd1.CommandText = "SP_Attachments";
                                    cmd1.Parameters.AddWithValue("@attach_type", attach_type);
                                    cmd1.Parameters.AddWithValue("@attach_Path", attach_place_store);
                                    cmd1.Parameters.AddWithValue("@attach_doc_id", strImageName);
                                    cmd1.Parameters.AddWithValue("@check", "i");
                                    cmd1.Connection = con;
                                    con.Open();
                                    cmd1.ExecuteNonQuery();
                                    con.Close();

                                    System.IO.Directory.CreateDirectory(Server.MapPath("\\UploadedImages\\Claims\\" + yy + "\\" + mm + "\\" + dd + "\\"));
                                    userPostedFile.SaveAs(Server.MapPath("\\UploadedImages\\" + attach_place_store));

                                }
                            }


                        }
                        else
                        {
                            MSG("الملف الذي قمت بإدخاله غير صالح");
                        }
                    }

                }
                conn.Close();
            }

            catch (Exception)
            {

                MSG("يرجى مراجعة مسؤول النظام");
            }

            //Fill_DDL_Images(Convert.ToInt16(GridView2.SelectedRow.Cells[1].Text));
            //Get_MainClaims_ForUpdate();
            Fill_Claims_GV1(DDL_Medical_Name.SelectedItem.Text, Txt_Month_Year.Text);
            MSG(Result);
            //rami
        }


        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fill_Claims_GV1(GridView2.SelectedRow.Cells[2].Text, GridView2.SelectedRow.Cells[3].Text);


        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Get_MainClaims_ForUpdate2();

        }


        public void Fill_Claims_GV2()
        {
            try
            {


                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Fill_Claims_GV2";

                //cmd.Parameters.AddWithValue("@From", dt1);
                //cmd.Parameters.AddWithValue("@To", dt2);

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                Cls_Connection.open_connection();
                adp.Fill(dt_Claims_GV2);
                Cls_Connection.close_connection();
                GridView2.DataSourceID = null;
                GridView2.DataSource = dt_Claims_GV2;
                GridView2.DataBind();

            }
            catch (Exception ex)
            {
                string x = ex.Message.ToString();
            }
        }

        public void Search_Claims_GV2(string Medical_Name)
        {
            try
            {


                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Search_Claims_GV2";

                cmd.Parameters.AddWithValue("@Medical_Name", Medical_Name);
                //cmd.Parameters.AddWithValue("@To", dt2);

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                Cls_Connection.open_connection();
                adp.Fill(dt_Claims_GV2);
                Cls_Connection.close_connection();
                GridView2.DataSourceID = null;
                GridView2.DataSource = dt_Claims_GV2;
                GridView2.DataBind();

            }
            catch (Exception ex)
            {
                string x = ex.Message.ToString();
            }
        }


        public void Fill_Claims_GV1(string Medical_Name, string Month_Year)
        {
            try
            {


                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Fill_Claims_GV1";

                cmd.Parameters.AddWithValue("@Medical_Name", Medical_Name);
                cmd.Parameters.AddWithValue("@Month_Year", Month_Year);

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                Cls_Connection.open_connection();
                adp.Fill(dt_Claims_GV1);
                Cls_Connection.close_connection();
                GridView1.DataSourceID = null;
                GridView1.DataSource = dt_Claims_GV1;
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                string x = ex.Message.ToString();
            }
        }
    }
}