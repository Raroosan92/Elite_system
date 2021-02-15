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
    public partial class Mail : System.Web.UI.Page
    {
        int Attch_Id;
        public void MSG(string Text)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('" + Text + "')</script>", false);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //--rami لتغيير التاريخ من لوحة المفاتيح--
            Txt_Received_Date.Attributes.Add("onkeydown", "DateField_KeyDown(this,'" + CalendarExtender2.ClientID + "')");
            Txt_Entry_Date.Attributes.Add("onkeydown", "DateField_KeyDown(this,'" + CalendarExtender3.ClientID + "')");
            Txt_Delivery_Date.Attributes.Add("onkeydown", "DateField_KeyDown(this,'" + CalendarExtender1.ClientID + "')");
            //--rami لتغيير التاريخ من لوحة المفاتيح-- 



            if (!Page.IsPostBack)
            {
                //rami
                slider.Visible = false;

                Btn_Save.Visible = HttpContext.Current.User.IsInRole("Add");
                Btn_Update.Visible = HttpContext.Current.User.IsInRole("Update");
                BtnDelete.Visible = HttpContext.Current.User.IsInRole("Delete");
                if (HttpContext.Current.User.IsInRole("Admin"))
                {
                    Btn_Update.Visible = true;
                    Btn_Save.Visible = true;
                    BtnDelete.Visible = true;
                }
                //rami


                DDL_Company.DataSource = Cls_Main_Claims.Get_Companies();
                DDL_Company.DataBind();
                DDL_Company.Items.Insert(0, new ListItem("--اختر--", "0"));
                //DDL_Company.SelectedValue = "6822";

                DDL_Sent_To.DataSource = Cls_Main_Claims.Get_Medical_Types2();
                DDL_Sent_To.DataBind();
                DDL_Sent_To.Items.Insert(0, new ListItem("--اختر--", "0"));
                //DDL_Sent_To.SelectedValue = "6819";


                DDL_Mail_Type.DataSource = Cls_Codes.Fill_DDL(6);
                DDL_Mail_Type.DataBind();
                DDL_Mail_Type.Items.Insert(0, new ListItem("--اختر--", "0"));
                //DDL_Mail_Type.SelectedValue = "295";

                DDL_Company_Search.DataSource = Cls_Main_Claims.Get_Companies();
                DDL_Company_Search.DataBind();
                DDL_Company_Search.Items.Insert(0, new ListItem("--اختر--", "0"));

                //Get_MainMail_ForUpdate();
                //Get_SubMails_ForGridView();
                Txt_Entry_Date.Text = DateTimeOffset.UtcNow.AddHours(2).ToString("yyyy-MM-dd");
                Txt_Received_Date.Text = DateTimeOffset.UtcNow.AddHours(2).ToString("yyyy-MM-dd");
                DDL_Company.Focus();

                if (DDL_Company.SelectedValue == "0")
                {
                    GetMails();
                }
                else
                {
                    GetMails2();
                }

            }

            
        }

        public void Get_MainMail_ForUpdate()
        {
            try
            {

                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Get_MainMail_ForUpdate";
                cmd.Parameters.AddWithValue("@ID", Convert.ToInt64(GridView_Mails.SelectedRow.Cells[1].Text));
                Cls_Connection.open_connection();
                SqlDataReader dr = cmd.ExecuteReader();
                bool Result;

                string Entry_Date;
                DateTime Entry_Date2;
                string Received_Date;
                DateTime Received_Date2;
                string Delivery_Date;
                DateTime Delivery_Date2;


                while (dr.Read())
                {

                    Txt_MainMailID.Text = dr.GetValue(dr.GetOrdinal("ID")).ToString();
                    if (!dr.IsDBNull(dr.GetOrdinal("Company")))
                    {
                        DDL_Company.SelectedValue = dr.GetValue(dr.GetOrdinal("Company")).ToString();
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

                    Delivery_Date = dr.GetValue(dr.GetOrdinal("Delivery_Date")).ToString();
                    Result = DateTime.TryParse(Delivery_Date, out Delivery_Date2);
                    if (Result)
                    {
                        Txt_Delivery_Date.Text = Delivery_Date2.ToString("yyyy-MM-dd");
                    }


                    if (!dr.IsDBNull(dr.GetOrdinal("Sent_To")))
                    {
                        DDL_Sent_To.SelectedValue = dr.GetValue(dr.GetOrdinal("Sent_To")).ToString();
                    }


                    if (!dr.IsDBNull(dr.GetOrdinal("Mail_Type")))
                    {
                        DDL_Mail_Type.SelectedValue = dr.GetValue(dr.GetOrdinal("Mail_Type")).ToString();
                    }


                    Txt_Mails_Count.Text = dr.GetValue(dr.GetOrdinal("Mails_Count")).ToString();
                    Txt_Notes.Text = dr.GetValue(dr.GetOrdinal("Notes")).ToString();

                    RB_Delivered.SelectedValue = dr.GetValue(dr.GetOrdinal("Delivered")).ToString();


                }

                dr.Close();





                //rami
                SqlDataAdapter da2 = new SqlDataAdapter();
                DataSet ds2 = new DataSet();
                SqlCommand cmd2 = new SqlCommand();

                cmd2.Connection = con;
                cmd2.CommandText = "select attach_Path,Attach_Id from Attachments where attach_doc_id=" + Convert.ToInt64(GridView_Mails.SelectedRow.Cells[1].Text) + "";
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


            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Cls_Connection.close_connection();


            }
            //MainMailID = Convert.ToInt64(GridView_Mails.SelectedRow.Cells[1].Text);
        }

        protected void GridView_Mails_SelectedIndexChanged(object sender, EventArgs e)
        {
            Get_MainMail_ForUpdate();
            //Get_SubMailForMainMail();
        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            string Result;
            //rami
            if (DDL_Company.SelectedIndex != 0)
            {
                Cls_Main_Mail Main_Mail = new Cls_Main_Mail();
                if (DDL_Company.SelectedValue != "")
                {
                    Main_Mail._Company = long.Parse(DDL_Company.SelectedValue);
                }

                if (Txt_Delivery_Date.Text != "")
                {
                    Main_Mail._Delivery_Date = DateTime.Parse(Txt_Delivery_Date.Text);
                }

                if (Txt_Entry_Date.Text != "")
                {
                    Main_Mail._Entry_Date = DateTime.UtcNow.AddHours(2);
                }

                if (Txt_Received_Date.Text != "")
                {
                    Main_Mail._Received_Date = DateTime.Parse(Txt_Received_Date.Text);
                }

                Main_Mail._Mails_Count = int.Parse(Txt_Mails_Count.Text);
                if (DDL_Mail_Type.SelectedValue != "")
                {
                    Main_Mail._Mail_Type = int.Parse(DDL_Mail_Type.SelectedValue); ;
                }
                Main_Mail._Notes = Txt_Notes.Text;

                Main_Mail._Sent_To = long.Parse(DDL_Sent_To.SelectedValue);

                if (RB_Delivered.SelectedValue == "1")
                {
                    Main_Mail._Delivered = true;
                }
                else
                {
                    Main_Mail._Delivered = false;
                }


                Result = Main_Mail.Insert_Main_Mail();
                ////////////////////////////////       Log        /////////////////////////////////////////////
                Cls_Log log = new Cls_Log();
                log._Log_Event = "إضافة البريد  للشركة: " + DDL_Company.SelectedItem.Text + " للجهة الطبية: " + DDL_Sent_To.SelectedItem.Text;
                log.Insert_Log();
                ////////////////////////////////   End Of Log        /////////////////////////////////////////////
                GridView_Mails.DataBind();



                //rami
                int attach_type = 700;
                string attach_place_store;
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand();
                DataSet ds = new DataSet();
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CONN"].ConnectionString);
                conn.Open();
                cmd.Connection = conn;

                cmd.CommandText = "Select IDENT_CURRENT('Main_Mail')";
                int strImageName = int.Parse(cmd.ExecuteScalar().ToString());

                DateTime datevalue = (DateTime.UtcNow.AddHours(2));
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
                                        attach_place_store = "\\\\Mail" + "\\\\" + yy + "\\\\" + mm + "\\\\" + dd + "\\\\" + Attch_Id + ".jpg";
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

                                    System.IO.Directory.CreateDirectory(Server.MapPath("\\UploadedImages\\Mail\\" + yy + "\\" + mm + "\\" + dd + "\\"));
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
                string CompanyValue = DDL_Company.SelectedValue;
                ClearFields(Form.Controls);
                Txt_Mails_Count.Text = "";
                Txt_Notes.Text = "";
                //Cls_Sub_Banks Sub_Bank = new Cls_Sub_Banks();
                DDL_Company.SelectedValue = CompanyValue;
                DDL_Sent_To.Focus();

                GetMails2();

            }
            else
            {
                MSG("يرجى ادخال تفاصيل المعاملة");
            }

            //rami

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
                    Get_MainMail_ForUpdate();
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

        protected void Btn_Update_Click(object sender, EventArgs e)
        {
            try
            {


                string Result;
                Cls_Main_Mail Main_Mail = new Cls_Main_Mail();
                if (DDL_Company.SelectedValue != "")
                {
                    Main_Mail._Company = long.Parse(DDL_Company.SelectedValue);
                }

                if (Txt_Delivery_Date.Text != "")
                {
                    Main_Mail._Delivery_Date = DateTime.Parse(Txt_Delivery_Date.Text);
                }

                if (Txt_Entry_Date.Text != "")
                {
                    Main_Mail._Entry_Date = DateTime.Parse(Txt_Entry_Date.Text);
                }

                if (Txt_Received_Date.Text != "")
                {
                    Main_Mail._Received_Date = DateTime.Parse(Txt_Received_Date.Text);
                }

                Main_Mail._ID = long.Parse(Txt_MainMailID.Text);

                Main_Mail._Mails_Count = int.Parse(Txt_Mails_Count.Text);
                if (DDL_Mail_Type.SelectedValue != "")
                {
                    Main_Mail._Mail_Type = int.Parse(DDL_Mail_Type.SelectedValue); ;
                }
                Main_Mail._Notes = Txt_Notes.Text;
                Main_Mail._Sent_To = long.Parse(DDL_Sent_To.SelectedValue);

                if (RB_Delivered.SelectedValue == "1")
                {
                    Main_Mail._Delivered = true;
                }
                else
                {
                    Main_Mail._Delivered = false;
                }
                Result = Main_Mail.Update_Main_Mail();

                ////////////////////////////////       Log        /////////////////////////////////////////////
                Cls_Log log = new Cls_Log();
                log._Log_Event = "تعديل البريد  للشركة: " + DDL_Company.SelectedItem.Text + " للجهة الطبية: " + DDL_Sent_To.SelectedItem.Text;
                log.Insert_Log();
                ////////////////////////////////   End Of Log        /////////////////////////////////////////////
                GridView_Mails.DataBind();



                //rami
                int attach_type = 700;
                string attach_place_store;
                int strImageName = int.Parse(GridView_Mails.SelectedRow.Cells[1].Text);


                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand();
                DataSet ds = new DataSet();
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CONN"].ConnectionString);
                cmd.Connection = conn;
                conn.Open();
                DateTime datevalue = (DateTime.UtcNow.AddHours(2));
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

                                    attach_place_store = "\\\\Mail" + "\\\\" + yy + "\\\\" + mm + "\\\\" + dd + "\\\\" + Attch_Id + ".jpg";
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

                                        System.IO.Directory.CreateDirectory(Server.MapPath("\\UploadedImages\\Mail\\" + yy + "\\" + mm + "\\" + dd + "\\"));
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
                Get_MainMail_ForUpdate();
                MSG(Result);
                ClearFields(Form.Controls);
                Txt_Mails_Count.Text = "";
                Txt_Notes.Text = "";
                DDL_Company.Focus();
            }
            catch (Exception)
            {
                MSG("حدث خطأ يرجى اختيار البريد المراد تعديله والمحاولة مرة أخرى");

            }
            //rami
        }

        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                if (DDL_Company_Search.SelectedItem.Text == "--اختر--")
                {
                    GridView_Mails.DataSource = SqlDataSource_Mails;
                    GridView_Mails.DataBind();
                }
                else
                {
                    cmd.CommandText = "SELECT [ID],[Company],[CompanyDesc],[Entry_Date],[Received_Date],[Delivery_Date],[Sent_To],[Sent_To_Desc],[Mail_Type],[Mail_Type_Desc],[Mails_Count],[Notes],[Delivered] FROM [dbo].[V_Mails] WHERE CompanyDesc = N'" + DDL_Company_Search.SelectedItem.Text + "' ORDER BY [ID] DESC";
                    Cls_Connection.open_connection();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    GridView_Mails.DataSourceID = null;
                    GridView_Mails.DataSource = dt;
                    GridView_Mails.DataBind();
                    Cls_Connection.close_connection();
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Cls_Connection.close_connection();


            }

        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Cls_Main_Mail Main_Mail = new Cls_Main_Mail();
                Main_Mail._ID = long.Parse(Txt_MainMailID.Text);
                string Result = "";
                Result = Main_Mail.Delete_Main_Mail();

                ////////////////////////////////       Log        /////////////////////////////////////////////
                Cls_Log log = new Cls_Log();
                log._Log_Event = "حذف البريد  للشركة: " + DDL_Company.SelectedItem.Text + " للجهة الطبية: " + DDL_Sent_To.SelectedItem.Text;
                log.Insert_Log();
                ////////////////////////////////   End Of Log        /////////////////////////////////////////////



                MSG(Result);
                GridView_Mails.DataBind();
                ClearFields(Form.Controls);

                Txt_Mails_Count.Text = "";
                Txt_Notes.Text = "";
                DDL_Company.Focus();

            }
            catch (Exception)
            {

                MSG("حدث خطأ, يرجى اختيار البريد المراد حذفه");
            }

        }

        public static void ClearFields(ControlCollection pageControls)
        {
            foreach (Control contl in pageControls)
            {
                string strCntName = (contl.GetType()).Name;

                switch (strCntName)
                {
                    //case "TextBox":
                    //    TextBox tbSource = (TextBox)contl;
                    //    tbSource.Text = "";
                    //    break;
                    case "RadioButtonList":
                        RadioButtonList rblSource = (RadioButtonList)contl;
                        rblSource.SelectedIndex = -1;
                        break;
                    case "DropDownList":
                       
                        DropDownList ddlSource = (DropDownList)contl;
                        //if (ddlSource.i== "DDL_Mail_Type")
                        //{
                        //    break;
                        //}
                        ddlSource.SelectedIndex = -1;
                        break;
                    case "ListBox":
                        ListBox lbsource = (ListBox)contl;
                        lbsource.SelectedIndex = -1;
                        break;
                }
                ClearFields(contl.Controls);
            }


        }


        protected void Btn_InsertAll_Click(object sender, EventArgs e)
        {

            ClearFields(Form.Controls);
            Txt_Mails_Count.Text = "";
            Txt_Notes.Text = "";
            Txt_Entry_Date.Text = DateTimeOffset.UtcNow.AddHours(2).ToString("yyyy-MM-dd");
            Txt_Received_Date.Text = DateTimeOffset.UtcNow.AddHours(2).ToString("yyyy-MM-dd");
            DDL_Company.Focus();

            GridView_Mails.DataSource = null;
            GridView_Mails.DataBind();
            Page.Response.Redirect(Page.Request.Url.ToString(), true);

        }

        public void GetMails()
        {
            GridView_Mails.DataSourceID = null;

            GridView_Mails.DataBind();

        }


        public void GetMails2()
        {

            try
            {

                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "SELECT [ID],[Company],[CompanyDesc],[Entry_Date],[Received_Date],[Delivery_Date],[Sent_To],[Sent_To_Desc],[Mail_Type],[Mail_Type_Desc],[Mails_Count],[Notes],[Delivered] FROM [dbo].[V_Mails] WHERE CompanyDesc = N'" + DDL_Company.SelectedItem.Text + "' ORDER BY [ID] DESC";
                Cls_Connection.open_connection();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                GridView_Mails.DataSourceID = null;
                GridView_Mails.DataSource = dt;
                GridView_Mails.DataBind();
                Cls_Connection.close_connection();

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Cls_Connection.close_connection();


            }
        }

        //protected void Btn_Save_Submail_Click(object sender, EventArgs e)
        //{
        //    string Result;
        //    Cls_Sub_Mail Sub_Mail = new Cls_Sub_Mail();
        //    if (Txt_MainMailID.Text == "" || Txt_MainMailID.Text == null)
        //    {
        //        MSG("يجب اختيار البريد الرئيسي");
        //        return;
        //    }
        //    Sub_Mail._Main_Mail_ID = Int64.Parse(Txt_MainMailID.Text);
        //    Sub_Mail._Mails_Count = int.Parse(Txt_Mails_Count.Text);
        //    if (DDL_Mail_Type.SelectedValue != "")
        //    {
        //        Sub_Mail._Mail_Type = int.Parse(DDL_Mail_Type.SelectedValue); ;
        //    }
        //    Sub_Mail._Notes = Txt_Notes.Text;
        //    Sub_Mail._Received_Date = DateTime.Parse(Txt_Received_Date2.Text);
        //    Sub_Mail._Sent_To = long.Parse(DDL_Sent_To.SelectedValue);

        //    if (RB_Delivered.SelectedValue == "1")
        //    {
        //        Sub_Mail._Delivered = true;
        //    }
        //    else
        //    {
        //        Sub_Mail._Delivered = false;
        //    }
        //    Result = Sub_Mail.Insert_Sub_Mail();
        //    ////////////////////////////////       Log        /////////////////////////////////////////////
        //    Cls_Log log = new Cls_Log();
        //    log._Log_Event = "إضافة على البريد الفرعي على الشركة: " + DDL_Company.SelectedItem.Text + " للجهة الطبية : " + DDL_Sent_To.SelectedItem.Text;
        //    log.Insert_Log();
        //    ////////////////////////////////   End Of Log        /////////////////////////////////////////////
        //    Get_SubMailForMainMail();
        //    MSG(Result);
        //}

        //protected void Btn_Update_Submail_Click(object sender, EventArgs e)
        //{
        //    string Result;
        //    Cls_Sub_Mail Sub_Mail = new Cls_Sub_Mail();
        //    if (Txt_MainMailID.Text == "" || Txt_MainMailID.Text == null)
        //    {
        //        MSG("يجب اختيار البريد الرئيسي");
        //        return;
        //    }
        //    Sub_Mail._Main_Mail_ID = Int64.Parse(Txt_MainMailID.Text);
        //    Sub_Mail._Mails_Count = int.Parse(Txt_Mails_Count.Text);
        //    if (DDL_Mail_Type.SelectedValue != "")
        //    {
        //        Sub_Mail._Mail_Type = int.Parse(DDL_Mail_Type.SelectedValue); ;
        //    }
        //    Sub_Mail._Notes = Txt_Notes.Text;
        //    Sub_Mail._Received_Date = DateTime.Parse(Txt_Received_Date2.Text);
        //    Sub_Mail._Sent_To = long.Parse(DDL_Sent_To.SelectedValue);
        //    Sub_Mail._ID = Int64.Parse(Txt_ID.Text);
        //    if (RB_Delivered.SelectedValue == "1")
        //    {
        //        Sub_Mail._Delivered = true;
        //    }
        //    else
        //    {
        //        Sub_Mail._Delivered = false;
        //    }
        //    Result = Sub_Mail.Update_Sub_Mail();



        //    ////////////////////////////////       Log        /////////////////////////////////////////////
        //    Cls_Log log = new Cls_Log();
        //    log._Log_Event = "تعديل على البريد الفرعي على الشركة: " + DDL_Company.SelectedItem.Text + " للجهة الطبية : " + DDL_Sent_To.SelectedItem.Text;
        //    log.Insert_Log();
        //    ////////////////////////////////   End Of Log        /////////////////////////////////////////////



        //    Get_SubMailForMainMail();
        //    MSG(Result);
        //}
        //public void Get_SubMailForMainMail()
        //{
        //    try
        //    {

        //        SqlConnection con = new SqlConnection();

        //        con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
        //        con = Cls_Connection._con;
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = con;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "Get_SubMails_ForMainMail";
        //        cmd.Parameters.AddWithValue("@Main_Mail_ID", Int64.Parse(Txt_MainMailID.Text));
        //        Cls_Connection.open_connection();
        //        DataTable dt = new DataTable();
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        da.Fill(dt);
        //        GridView_SubMails.DataSource = dt;
        //        GridView_SubMails.DataBind();
        //        Cls_Connection.close_connection();
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Message.ToString();
        //        Cls_Connection.close_connection();


        //    }

        //}
        //public void Get_SubMails_ForGridView()
        //{
        //    try
        //    {

        //        SqlConnection con = new SqlConnection();

        //        con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
        //        con = Cls_Connection._con;
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = con;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "Get_subMails_ForGridView";
        //        Cls_Connection.open_connection();
        //        DataTable dt = new DataTable();
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        da.Fill(dt);
        //        GridView_SubMails.DataSource = dt;
        //        GridView_SubMails.DataBind();
        //        Cls_Connection.close_connection();
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Message.ToString();
        //        Cls_Connection.close_connection();


        //    }

        //}


        //public void Get_SubMail_ForUpdate()
        //{
        //    try
        //    {

        //        SqlConnection con = new SqlConnection();

        //        con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
        //        con = Cls_Connection._con;
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = con;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "Get_SubMail_ForUpdate";
        //        cmd.Parameters.AddWithValue("@ID", Convert.ToInt64(GridView_SubMails.SelectedRow.Cells[1].Text));
        //        Cls_Connection.open_connection();
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        bool Result;


        //        string Received_Date;
        //        DateTime Received_Date2;



        //        while (dr.Read())
        //        {


        //            if (!dr.IsDBNull(dr.GetOrdinal("Sent_To")))
        //            {
        //                DDL_Sent_To.SelectedValue = dr.GetValue(dr.GetOrdinal("Sent_To")).ToString();
        //            }


        //            if (!dr.IsDBNull(dr.GetOrdinal("Mail_Type")))
        //            {
        //                DDL_Mail_Type.SelectedValue = dr.GetValue(dr.GetOrdinal("Mail_Type")).ToString();
        //            }


        //            Received_Date = dr.GetValue(dr.GetOrdinal("Received_Date")).ToString();
        //            Result = DateTime.TryParse(Received_Date, out Received_Date2);
        //            if (Result)
        //            {
        //                Txt_Received_Date2.Text = Received_Date2.ToShortDateString();
        //            }

        //            Txt_Mails_Count.Text = dr.GetValue(dr.GetOrdinal("Mails_Count")).ToString();
        //            Txt_Notes.Text = dr.GetValue(dr.GetOrdinal("Notes")).ToString();
        //            Txt_ID.Text = dr.GetValue(dr.GetOrdinal("ID")).ToString();


        //        }

        //        Cls_Connection.close_connection();


        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Message.ToString();
        //        Cls_Connection.close_connection();


        //    }

        //}

        //protected void GridView_SubMails_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        //{
        //    Get_SubMails_ForGridView();
        //    GridView_SubMails.PageIndex = e.NewPageIndex;
        //    GridView_SubMails.DataBind();
        //}

    }
}