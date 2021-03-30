using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using IDAutomation;
using System.Diagnostics;
using System.Net;

namespace Elite_system
{
    public partial class Checks : System.Web.UI.Page
    {
        int Attch_Id;
        byte[] byteImage;
        string barCode;
        public void MSG(string Text)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('" + Text + "')</script>", false);
        }

        private static bool isRun = false;
        private static readonly object syncLock = new object();

        public void MyMethod()
        {
            lock (syncLock)
            {
                if (!isRun)
                {
                    installFont();
                    isRun = true;
                }
            }
        }

        public void installFont()
        {
            string fontName = "IDAutomationC128XS";
            float fontSize = 12;

            using (Font fontTester = new Font(
                   fontName,
                   fontSize,
                   FontStyle.Regular,
                   GraphicsUnit.Pixel))
            {
                if (fontTester.Name == fontName)
                {
                    // Font exists
                }
                else
                {
                    Response.Redirect("DownloadFont.ashx");
                }
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //--rami لتغيير التاريخ من لوحة المفاتيح--
            Txt_Check_Date.Attributes.Add("onkeydown", "DateField_KeyDown(this,'" + CalendarExtender5.ClientID + "')");
            Txt_Entry_Date.Attributes.Add("onkeydown", "DateField_KeyDown(this,'" + CalendarExtender3.ClientID + "')");
            Txt_Received_Date.Attributes.Add("onkeydown", "DateField_KeyDown(this,'" + CalendarExtender2.ClientID + "')");
            Txt_Delivery_Date.Attributes.Add("onkeydown", "DateField_KeyDown(this,'" + CalendarExtender1.ClientID + "')");
            //--rami لتغيير التاريخ من لوحة المفاتيح-- 

            if (!Page.IsPostBack)
            {
                // MyMethod();
                //rami
                slider.Visible = false;
                Btn_Update1.Visible = HttpContext.Current.User.IsInRole("Update");
                BtnDelete.Visible = HttpContext.Current.User.IsInRole("Delete");
                Btn_Save1.Visible = HttpContext.Current.User.IsInRole("Add");
                if (HttpContext.Current.User.IsInRole("Admin"))
                {
                    Btn_Save1.Visible = true;
                    Btn_Update1.Visible = true;
                    BtnDelete.Visible = true;
                }
                //rami

                //rami
                if (HttpContext.Current.User.IsInRole("Doctor"))
                {
                    Btn_Search.Visible = false;
                    DDL_Company_Search.Visible = false;
                    Get_MainChecks_ForGridView(HttpContext.Current.User.Identity.Name);
                }
                else
                {
                    //Get_MainChecks_ForGridView();
                }
                //rami

                DDL_Company.DataSource = Cls_Main_Claims.Get_Companies();
                DDL_Company.DataBind();
                DDL_Company.Items.Insert(0, new ListItem("--اختر--", "0"));
                //DDL_Company.SelectedValue = "6822";

                DDL_Company_Search.DataSource = Cls_Main_Claims.Get_Companies();
                DDL_Company_Search.DataBind();
                DDL_Company_Search.Items.Insert(0, new ListItem("--اختر--", "0"));
                //DDL_Company.SelectedValue = "6822";

                DDL_Bank.DataSource = Cls_Main_Banks.Get_Main_Banks();
                DDL_Bank.DataBind();
                DDL_Bank.Items.Insert(0, new ListItem("--اختر--", "0"));
                //DDL_Bank.SelectedValue = "24";

                DDL_Sent_To.DataSource = Cls_Main_Claims.Get_Medical_Types2();
                DDL_Sent_To.DataBind();
                DDL_Sent_To.Items.Insert(0, new ListItem("--اختر--", "0"));
                //DDL_Sent_To.SelectedValue = "6819";

                //Get_MainChecks_ForUpdate();
                //Get_SubChecks_ForGridView();
                Txt_Entry_Date.Text = DateTime.Parse(DateTimeOffset.UtcNow.AddHours(2).ToString()).ToString("yyyy-MM-dd");
                Txt_Check_Date.Text = DateTime.Parse(DateTimeOffset.UtcNow.AddHours(2).ToString()).ToString("yyyy-MM-dd");
                //Txt_Delivery_Date.Text = DateTimeOffset.UtcNow.AddHours(2).ToString("yyyy-MM-dd");
                Txt_Received_Date.Text = DateTime.Parse(DateTimeOffset.UtcNow.AddHours(2).ToString()).ToString("yyyy-MM-dd");
                DDL_Company.Focus();


            }
        }


        //rami
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
                cmd.CommandText = "Get_MainChecks_ForGridView";
                Cls_Connection.open_connection();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                GV_Main_Check.DataSource = dt;

                GV_Main_Check.DataBind();
                Cls_Connection.close_connection();

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Cls_Connection.close_connection();


            }

        }
        public void Get_MainChecks_ForGridView(string UName)
        {
            try
            {

                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Get_MainChecks_ForGridViewByUName";
                cmd.Parameters.AddWithValue("@UName", UName);
                Cls_Connection.open_connection();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);
                GV_Main_Check.DataSource = dt;
                GV_Main_Check.DataBind();

                Cls_Connection.close_connection();

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Cls_Connection.close_connection();


            }

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
                    //GV_Main_Check.DataSource = SqlDataSource_Checks;
                    //GV_Main_Check.DataBind();

                    //rami
                    if (HttpContext.Current.User.IsInRole("Doctor"))
                    {
                        Get_MainChecks_ForGridView(HttpContext.Current.User.Identity.Name);
                    }
                    else
                    {
                        Get_MainChecks_ForGridView();
                    }
                    //rami

                }
                else
                {
                    if (HttpContext.Current.User.IsInRole("Doctor"))
                    {
                        cmd.CommandText = "SELECT [ID] as 'التسلسل' ,[Company] as 'اسم الشركة', [Check_Date] as 'تاريخ الشيك',SentTo as 'الجهة الطبية',Value as 'المبلغ' ,Check_No as 'رقم الشيك' FROM[dbo].[V_Main_Check] where Company = N'" + DDL_Company_Search.SelectedItem.Text + "' and UName='" + HttpContext.Current.User.Identity.Name + "' ORDER BY [ID] DESC";
                    }
                    else
                    {
                        cmd.CommandText = "SELECT [ID] as 'التسلسل' ,[Company] as 'اسم الشركة',[Check_Date] as 'تاريخ الشيك',SentTo as 'الجهة الطبية',Value as 'المبلغ' ,Check_No as 'رقم الشيك' FROM[dbo].[V_Main_Check] where Company = N'" + DDL_Company_Search.SelectedItem.Text + "' ORDER BY [ID] DESC";
                    }




                    Cls_Connection.open_connection();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    GV_Main_Check.DataSourceID = null;
                    GV_Main_Check.DataSource = dt;
                    GV_Main_Check.DataBind();
                    Cls_Connection.close_connection();
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Cls_Connection.close_connection();


            }

        }

        protected void Btn_Search2_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                if (HttpContext.Current.User.IsInRole("Doctor"))
                {
                    cmd.CommandText = "SELECT [ID] as 'التسلسل' ,[Company] as 'اسم الشركة',[Check_Date] as 'تاريخ الشيك',SentTo as 'الجهة الطبية',Value as 'المبلغ' ,Check_No as 'رقم الشيك' FROM[dbo].[V_Main_Check] where Check_No = N'" + Txt_CheckNo.Text + "'  and UName='" + HttpContext.Current.User.Identity.Name + "' ORDER BY [ID] DESC";
                }
                else
                {
                    cmd.CommandText = "SELECT [ID] as 'التسلسل' ,[Company] as 'اسم الشركة', [Check_Date] as 'تاريخ الشيك',SentTo as 'الجهة الطبية',Value as 'المبلغ' ,Check_No as 'رقم الشيك' FROM[dbo].[V_Main_Check] where Check_No = N'" + Txt_CheckNo.Text + "' ORDER BY [ID] DESC";
                }




                Cls_Connection.open_connection();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                GV_Main_Check.DataSourceID = null;
                GV_Main_Check.DataSource = dt;
                GV_Main_Check.DataBind();
                Cls_Connection.close_connection();

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Cls_Connection.close_connection();


            }

        }

        protected void DDL_Bank_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cls_Sub_Banks Sub_Bank = new Cls_Sub_Banks();
            DDL_Bank_Branch.DataSource = Sub_Bank.Get_Sub_Banks(int.Parse(DDL_Bank.SelectedValue));
            DDL_Bank_Branch.DataBind();
            DDL_Bank_Branch.Items.Insert(0, new ListItem("--اختر--", "0"));
            DDL_Bank_Branch.Focus();
        }
        protected void BarCodeGenerate(string BarCodeBefore)
        {
            ////////////////// Generate BarCode /////////////////////
            Int32 barcodeHeight = 100, barcodeWidth = 300;
            Bitmap bmpBarcode;
            bmpBarcode = new Bitmap(barcodeWidth, barcodeHeight);
            bmpBarcode.SetResolution(100, 100);
            if (BarCodeBefore != "")
            {

                // draw the barcode and text to the bitmap
                clsBarCode barcodeGenerator = new clsBarCode();
                String barcodeReadyData = barcodeGenerator.Code128(BarCodeBefore, false);
                using (Font drawFont = new Font("IDAutomationC128XS", 24), readableFont = new Font("Arial", 12))
                {
                    using (SolidBrush drawBrush = new SolidBrush(Color.Black))
                    {
                        using (Graphics dc = Graphics.FromImage(bmpBarcode))
                        {
                            // paint the whole bitmap white
                            dc.FillRectangle(new SolidBrush(Color.White), new RectangleF(0, 0, bmpBarcode.Width, bmpBarcode.Height));
                            // draw the barcode
                            dc.DrawString(barcodeReadyData, drawFont, drawBrush, new RectangleF(0, 0, barcodeWidth, barcodeHeight - 70));
                            // draw the human readable
                            dc.DrawString(BarCodeBefore, readableFont, drawBrush, new RectangleF(0, 30, barcodeWidth, barcodeHeight));
                        }
                    }
                }
                barCode = Txt_Check_No.Text;
                System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                //Bitmap bitMap = new Bitmap(barCode.Length * 20, 80);
                using (MemoryStream ms = new MemoryStream())
                {

                    bmpBarcode.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    byteImage = ms.ToArray();

                    Convert.ToBase64String(byteImage);
                    imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                    //imgBarCode.ImageUrl = Server.MapPath("Barcode/" + Convert.ToBase64String(byteImage) + ".png");


                    // Convert byte[] to Image
                    ms.Write(byteImage, 0, byteImage.Length);
                    System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
                    image.Save(Server.MapPath("~/Barcode/" + Txt_Check_No.Text + ".Bmp"), System.Drawing.Imaging.ImageFormat.Bmp);





                }
                //PlaceHolder1.Controls.Add(imgBarCode);



            }
            ////////////////End Of Generat BarCode  ////////////////
        }

        protected void BarCodeGenerateafter(string BarCodeAfter)
        {

            ////////////////// Generate BarCode /////////////////////

            Int32 barcodeHeight = 100, barcodeWidth = 300;
            Bitmap bmpBarcode;
            bmpBarcode = new Bitmap(barcodeWidth, barcodeHeight);
            bmpBarcode.SetResolution(100, 100);
            if (BarCodeAfter != "")
            {

                // draw the barcode and text to the bitmap
                clsBarCode barcodeGenerator = new clsBarCode();
                String barcodeReadyData = barcodeGenerator.Code128(BarCodeAfter, false);
                using (Font drawFont = new Font("IDAutomationC128XS", 24), readableFont = new Font("Arial", 12))
                {
                    using (SolidBrush drawBrush = new SolidBrush(Color.Black))
                    {
                        using (Graphics dc = Graphics.FromImage(bmpBarcode))
                        {
                            // paint the whole bitmap white
                            dc.FillRectangle(new SolidBrush(Color.White), new RectangleF(0, 0, bmpBarcode.Width, bmpBarcode.Height));
                            // draw the barcode
                            dc.DrawString(barcodeReadyData, drawFont, drawBrush, new RectangleF(0, 0, barcodeWidth, barcodeHeight - 70));
                            // draw the human readable
                            dc.DrawString(BarCodeAfter, readableFont, drawBrush, new RectangleF(0, 30, barcodeWidth, barcodeHeight));
                        }
                    }
                }
                barCode = Txt_Check_No.Text;
                System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                //Bitmap bitMap = new Bitmap(barCode.Length * 20, 80);
                using (MemoryStream ms = new MemoryStream())
                {

                    bmpBarcode.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    byteImage = ms.ToArray();

                    Convert.ToBase64String(byteImage);
                    imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                    //imgBarCode.ImageUrl = Server.MapPath("Barcode/" + Convert.ToBase64String(byteImage) + ".png");



                }
                //PlaceHolder1.Controls.Add(imgBarCode);
            }

            ////////////////End Of Generat BarCode  ////////////////
        }


        protected void Btn_Save1_Click(object sender, EventArgs e)
        {



            //rami
            if (DDL_Company.SelectedIndex != 0)
            {
                if (DDL_Sent_To.SelectedIndex != 0)
                {


                    // BarCodeGenerate(Txt_Check_No.Text);
                    Cls_Main_Check Main_Check = new Cls_Main_Check();
                    if (DDL_Company.SelectedValue != "")
                    {
                        Main_Check._Company = long.Parse(DDL_Company.SelectedValue);
                    }

                    if (Txt_Delivery_Date.Text != "")
                    {
                        Main_Check._Delivery_Date = DateTime.Parse(Txt_Delivery_Date.Text);
                    }

                    if (Txt_Check_Date.Text != "")
                    {
                        Main_Check._Check_Date = DateTime.Parse(Txt_Check_Date.Text);
                    }

                    Main_Check._Entry_Date = DateTime.Parse(DateTimeOffset.UtcNow.AddHours(2).ToString());

                    if (Txt_Received_Date.Text != "")
                    {
                        Main_Check._Received_Date = DateTime.Parse(Txt_Received_Date.Text);
                    }

                    if (DDL_Bank.SelectedValue != "")
                    {
                        Main_Check._Main_Bank = int.Parse(DDL_Bank.SelectedValue);
                    }

                    if (DDL_Bank_Branch.SelectedValue != "")
                    {
                        Main_Check._Sub_Bank = int.Parse(DDL_Bank_Branch.SelectedValue);
                    }

                    if (DDL_Sent_To.SelectedValue != "")
                    {
                        Main_Check._Sent_To = long.Parse(DDL_Sent_To.SelectedValue);
                    }

                    //if (Txt_Check_Date2.Text != "")
                    //{
                    //    Sub_Check._Check_Date = DateTime.Parse(Txt_Check_Date2.Text);
                    //}

                    Main_Check._Check_No = Txt_Check_No.Text;
                    Main_Check._Months = Txt_Months.Text;
                    Main_Check._Notes = Txt_Notes.Text;
                    Main_Check._Value = double.Parse(Txt_Value.Text);

                    Main_Check._BarCode = "*" + Txt_Check_No.Text + "*";

                    //if (RB_Delivered.SelectedValue == "1")
                    //{
                    //    Main_Check._Delivered = true;
                    //}
                    //else
                    //{
                    //    Main_Check._Delivered = false;
                    //}


                    // Main_Check._BarCode_Image = byteImage;
                    string Result;
                    Main_Check._Check_No = Txt_Check_No.Text;
                    Main_Check._Value = Double.Parse(Txt_Value.Text);

                    if (Main_Check.Check_Main_Checks() == "False")
                    {
                        Result = Main_Check.Insert_Main_Check();


                        ////////////////////////////////       Log        /////////////////////////////////////////////
                        Cls_Log log = new Cls_Log();
                        log._Log_Event = "إضافة شيك من الشركة: " + DDL_Company.SelectedItem.Text + " للجهة الطبية " + DDL_Sent_To.SelectedItem.Text + " رقم الشيك  " + Txt_Check_No.Text;
                        log.Insert_Log();
                        ////////////////////////////////   End Of Log        /////////////////////////////////////////////
                        GV_Main_Check.DataBind();
                        //rami
                        int attach_type = 500;
                        string attach_place_store;
                        SqlDataAdapter da = new SqlDataAdapter();
                        SqlCommand cmd = new SqlCommand();
                        DataSet ds = new DataSet();
                        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CONN"].ConnectionString);
                        conn.Open();
                        cmd.Connection = conn;

                        cmd.CommandText = "Select IDENT_CURRENT('Main_Check')";
                        int strImageName = int.Parse(cmd.ExecuteScalar().ToString());

                        DateTime datevalue = (DateTime.Parse(DateTimeOffset.UtcNow.AddHours(2).ToString()));
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
                                                attach_place_store = "\\\\Checks" + "\\\\" + yy + "\\\\" + mm + "\\\\" + dd + "\\\\" + Attch_Id + ".jpg";
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

                                            System.IO.Directory.CreateDirectory(Server.MapPath("\\UploadedImages\\Checks\\" + yy + "\\" + mm + "\\" + dd + "\\"));
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
                    }
                    else
                    {
                        Result = "هذا الشيك مدخل من قبل";
                    }
                    MSG(Result);

                    //ClearFields(Form.Controls);
                    Txt_Check_No.Text = "";
                    //Txt_Months.Text = "";
                    Txt_Notes.Text = "";
                    Txt_Value.Text = "";
                    DDL_Sent_To.SelectedValue = "0";
                    DDL_Sent_To.Focus();
                    Cls_Sub_Banks Sub_Bank = new Cls_Sub_Banks();
                    DDL_Bank_Branch.DataSource = Sub_Bank.Get_Sub_Banks(int.Parse(DDL_Bank.SelectedValue));
                    DDL_Bank_Branch.DataBind();
                    DDL_Bank_Branch.Items.Insert(0, new ListItem("--اختر--", "0"));
                    DDL_Bank_Branch.SelectedValue = Main_Check._Sub_Bank.ToString();
                }
                else
                {
                    MSG("يرجى ادخال الجهة المرسل اليها ");
                }
            }
            else
            {
                MSG("يرجى ادخال تفاصيل المعاملة");
            }
            //rami
            if (HttpContext.Current.User.IsInRole("Doctor"))
            {
                Get_MainChecks_ForGridView(HttpContext.Current.User.Identity.Name);
            }
            else
            {
                Search();
                //Get_MainChecks_ForGridView();
            }
            //rami
            //rami


        }

        protected void Btn_Save2_Click(object sender, EventArgs e)
        {
            string Result;
            Cls_Sub_Check Sub_Check = new Cls_Sub_Check();

            try
            {

                Sub_Check._Main_Check_ID = Convert.ToInt64(GV_Main_Check.SelectedRow.Cells[1].Text);

                if (DDL_Sent_To.SelectedValue != "")
                {
                    Sub_Check._Sent_To = long.Parse(DDL_Sent_To.SelectedValue);
                }

                //if (Txt_Check_Date2.Text != "")
                //{
                //    Sub_Check._Check_Date = DateTime.Parse(Txt_Check_Date2.Text);
                //}

                Sub_Check._Check_No = Txt_Check_No.Text;
                Sub_Check._Months = Txt_Months.Text;
                Sub_Check._Notes = Txt_Notes.Text;
                Sub_Check._Value = double.Parse(Txt_Value.Text);

                //if (RB_Delivered.SelectedValue == "1")
                //{
                //    Sub_Check._Delivered = true;
                //}
                //else
                //{
                //    Sub_Check._Delivered = false;
                //}

                Result = Sub_Check.Insert_Sub_Check();
                ////////////////////////////////       Log        /////////////////////////////////////////////
                Cls_Log log = new Cls_Log();
                log._Log_Event = "إضافة على الشيكات الفرعية على الجهة الطبية: " + DDL_Sent_To.SelectedItem.Text;
                log.Insert_Log();
                ////////////////////////////////   End Of Log        /////////////////////////////////////////////
                //Get_SubChecks_ForMainChecks();
                MSG(Result);

                ClearFields(Form.Controls);
                Txt_Check_No.Text = "";
                //Txt_Months.Text = "";
                Txt_Notes.Text = "";
                Txt_Value.Text = "";
                DDL_Company.Focus();
                Cls_Sub_Banks Sub_Bank = new Cls_Sub_Banks();
                DDL_Bank_Branch.DataSource = Sub_Bank.Get_Sub_Banks(int.Parse(DDL_Bank.SelectedValue));
                DDL_Bank_Branch.DataBind();
                DDL_Bank_Branch.Items.Insert(0, new ListItem("--اختر--", "0"));
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void Btn_Update1_Click(object sender, EventArgs e)
        {
            try
            {


                Cls_Main_Check Main_Check = new Cls_Main_Check();
                if (DDL_Company.SelectedValue != "")
                {
                    Main_Check._Company = long.Parse(DDL_Company.SelectedValue);
                }

                if (Txt_Delivery_Date.Text != "")
                {
                    Main_Check._Delivery_Date = DateTime.Parse(Txt_Delivery_Date.Text);
                }

                if (Txt_Check_Date.Text != "")
                {
                    Main_Check._Check_Date = DateTime.Parse(Txt_Check_Date.Text);
                }

                if (Txt_Entry_Date.Text != "")
                {
                    Main_Check._Entry_Date = DateTime.Parse(Txt_Entry_Date.Text);
                }


                if (Txt_Received_Date.Text != "")
                {
                    Main_Check._Received_Date = DateTime.Parse(Txt_Received_Date.Text);
                }

                if (DDL_Bank.SelectedValue != "")
                {
                    Main_Check._Main_Bank = int.Parse(DDL_Bank.SelectedValue);
                }

                if (DDL_Bank_Branch.SelectedValue != "")
                {
                    Main_Check._Sub_Bank = int.Parse(DDL_Bank_Branch.SelectedValue);
                }

                Main_Check._ID = Convert.ToInt64(GV_Main_Check.SelectedRow.Cells[1].Text);

                if (DDL_Sent_To.SelectedValue != "")
                {
                    Main_Check._Sent_To = long.Parse(DDL_Sent_To.SelectedValue);
                }

                Main_Check._Check_No = Txt_Check_No.Text;
                Main_Check._BarCode = "*" + Txt_Check_No.Text + "*";
                Main_Check._Months = Txt_Months.Text;
                Main_Check._Notes = Txt_Notes.Text;
                Main_Check._Value = double.Parse(Txt_Value.Text);
                //if (RB_Delivered.SelectedValue == "1")
                //{
                //    Main_Check._Delivered = true;
                //}
                //else
                //{
                //    Main_Check._Delivered = false;
                //}


                string Result;
                Result = Main_Check.Update_Main_Check();
                ////////////////////////////////       Log        /////////////////////////////////////////////
                Cls_Log log = new Cls_Log();
                log._Log_Event = " تعديل على الشيك رقم  " + Txt_Check_No.Text + " للجهة الطبية " + DDL_Sent_To.SelectedItem.Text;
                log.Insert_Log();
                ////////////////////////////////   End Of Log        /////////////////////////////////////////////
                GV_Main_Check.DataBind();

                //rami
                int attach_type = 500;
                string attach_place_store;

                //string x = GV_Main_Check.SelectedRow.Cells[1].Text;
                //int strImageName = Convert.ToInt16(x);
                //int strImageName = Convert.ToInt16(GV_Main_Check.SelectedRow.Cells[1].Text);

                long strImageName = Main_Check._ID;

                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand();
                DataSet ds = new DataSet();
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CONN"].ConnectionString);
                cmd.Connection = conn;
                conn.Open();
                DateTime datevalue = (DateTime.Parse(DateTimeOffset.UtcNow.AddHours(2).ToString()));
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

                                    attach_place_store = "\\\\Checks" + "\\\\" + yy + "\\\\" + mm + "\\\\" + dd + "\\\\" + Attch_Id + ".jpg";
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

                                        System.IO.Directory.CreateDirectory(Server.MapPath("\\UploadedImages\\Checks\\" + yy + "\\" + mm + "\\" + dd + "\\"));
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


                //Get_MainChecks_ForUpdate();
                MSG(Result);

                //ClearFields(Form.Controls);
                Txt_Check_No.Text = "";
                //Txt_Months.Text = "";
                Txt_Notes.Text = "";
                Txt_Value.Text = "";
                DDL_Sent_To.SelectedValue = "0";
                DDL_Company.Focus();
                Cls_Sub_Banks Sub_Bank = new Cls_Sub_Banks();
                DDL_Bank_Branch.DataSource = Sub_Bank.Get_Sub_Banks(int.Parse(DDL_Bank.SelectedValue));
                DDL_Bank_Branch.DataBind();
                DDL_Bank_Branch.Items.Insert(0, new ListItem("--اختر--", "0"));
                DDL_Bank_Branch.SelectedValue = Main_Check._Sub_Bank.ToString();
            }
            catch (Exception)
            {

                MSG("حدث خطأ, يرجى اختيار الشيك المراد نعديله");
            }
            //rami
            if (HttpContext.Current.User.IsInRole("Doctor"))
            {
                Get_MainChecks_ForGridView(HttpContext.Current.User.Identity.Name);
            }
            else
            {
                Get_MainChecks_ForGridView();
            }
            //rami
            //rami
        }

        protected void Btn_Update2_Click(object sender, EventArgs e)
        {
            string Result;

            Cls_Sub_Check Sub_Check = new Cls_Sub_Check();

            Sub_Check._Main_Check_ID = Convert.ToInt64(GV_Main_Check.SelectedRow.Cells[1].Text);


            if (DDL_Sent_To.SelectedValue != "")
            {
                Sub_Check._Sent_To = long.Parse(DDL_Sent_To.SelectedValue);
            }

            //if (Txt_Check_Date2.Text != "")
            //{
            //    Sub_Check._Check_Date = DateTime.Parse(Txt_Check_Date2.Text);
            //}

            Sub_Check._Check_No = Txt_Check_No.Text;
            Sub_Check._Months = Txt_Months.Text;
            Sub_Check._Notes = Txt_Notes.Text;
            Sub_Check._Value = double.Parse(Txt_Value.Text);

            //Sub_Check._ID = Convert.ToInt64(GV_SubChecks.SelectedRow.Cells[1].Text);
            Result = Sub_Check.Update_Sub_Check();
            ////////////////////////////////       Log        /////////////////////////////////////////////
            Cls_Log log = new Cls_Log();
            log._Log_Event = "تعديل على الشيكات الفرعية على الجهة الطبية: " + DDL_Sent_To.SelectedItem.Text;
            log.Insert_Log();
            ////////////////////////////////   End Of Log        /////////////////////////////////////////////
            //Get_SubChecks_ForMainChecks();
            MSG(Result);

            ClearFields(Form.Controls);
            Txt_Check_No.Text = "";
            //Txt_Months.Text = "";
            Txt_Notes.Text = "";
            Txt_Value.Text = "";
            DDL_Company.Focus();
            Cls_Sub_Banks Sub_Bank = new Cls_Sub_Banks();
            DDL_Bank_Branch.DataSource = Sub_Bank.Get_Sub_Banks(int.Parse(DDL_Bank.SelectedValue));
            DDL_Bank_Branch.DataBind();
            DDL_Bank_Branch.Items.Insert(0, new ListItem("--اختر--", "0"));
        }

        object result;
        public void Get_MainChecks_ForUpdate()
        {
            try
            {

                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                //Rami
                //ID = Convert.ToInt64(GV_Main_Check.SelectedRow.Cells[1].Text);
                cmd.CommandText = "select Checked from Main_Check where ID = " + Convert.ToInt64(GV_Main_Check.SelectedRow.Cells[1].Text) + "";


                Cls_Connection.open_connection();
                result = cmd.ExecuteScalar();
                Cls_Connection.close_connection();
                if (HttpContext.Current.User.IsInRole("Admin"))
                {
                    if (bool.Parse(result.ToString()) == true)
                    {
                        Btn_Update1.Visible = false;
                        BtnDelete.Visible = false;
                    }
                    else
                    {
                        Btn_Update1.Visible = true;
                        BtnDelete.Visible = true;
                    }

                }
                cmd.Parameters.Clear();
                //Rami

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Get_MainChecks_ForUpdate";
                cmd.Parameters.AddWithValue("@ID", Convert.ToInt64(GV_Main_Check.SelectedRow.Cells[1].Text));
                Cls_Connection.open_connection();
                SqlDataReader dr = cmd.ExecuteReader();
                bool Result;
                string Check_Date;
                DateTime Check_Date2;
                string Entry_Date;
                DateTime Entry_Date2;
                string Received_Date;
                DateTime Received_Date2;
                string Sub_Bank = "";
                string Delivery_Date;
                DateTime Delivery_Date2;

                while (dr.Read())
                {


                    if (!dr.IsDBNull(dr.GetOrdinal("Company")))
                    {
                        DDL_Company.SelectedValue = dr.GetValue(dr.GetOrdinal("Company")).ToString();
                    }


                    Check_Date = dr.GetValue(dr.GetOrdinal("Check_Date")).ToString();
                    Result = DateTime.TryParse(Check_Date, out Check_Date2);
                    if (Result)
                    {
                        Txt_Check_Date.Text = Check_Date2.ToString("yyyy-MM-dd");
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

                    if (!dr.IsDBNull(dr.GetOrdinal("Main_Bank")))
                    {
                        DDL_Bank.SelectedValue = dr.GetValue(dr.GetOrdinal("Main_Bank")).ToString();
                    }

                    if (!dr.IsDBNull(dr.GetOrdinal("Sub_Bank")))
                    {
                        Sub_Bank = dr.GetValue(dr.GetOrdinal("Sub_Bank")).ToString();
                    }

                    if (!dr.IsDBNull(dr.GetOrdinal("Sent_To")))
                    {
                        DDL_Sent_To.SelectedValue = dr.GetValue(dr.GetOrdinal("Sent_To")).ToString();
                    }

                    Txt_Value.Text = dr.GetValue(dr.GetOrdinal("Value")).ToString();
                    Txt_Check_No.Text = dr.GetValue(dr.GetOrdinal("Check_No")).ToString();

                    Txt_Months.Text = dr.GetValue(dr.GetOrdinal("Months")).ToString();

                    Txt_Notes.Text = dr.GetValue(dr.GetOrdinal("Notes")).ToString();
                    //if (dr.GetValue(dr.GetOrdinal("Delivered")).ToString() == "True")
                    //{
                    //    RB_Delivered.SelectedValue = "1";
                    //}
                    //else
                    //{
                    //    RB_Delivered.SelectedValue = "0";
                    //}

                    //BarCodeGenerateafter(dr.GetValue(dr.GetOrdinal("BarCode")).ToString());
                    LblBarcode.Text = (dr.GetValue(dr.GetOrdinal("BarCode")).ToString());

                }



                //rami
                dr.Close();
                SqlDataAdapter da2 = new SqlDataAdapter();
                DataSet ds2 = new DataSet();
                SqlCommand cmd2 = new SqlCommand();

                cmd2.Connection = con;
                cmd2.CommandText = "select attach_Path,Attach_Id from Attachments where attach_doc_id=" + Convert.ToInt64(GV_Main_Check.SelectedRow.Cells[1].Text) + "";
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

                if (Sub_Bank != "")
                {
                    Cls_Sub_Banks Sub_Bank2 = new Cls_Sub_Banks();
                    DDL_Bank_Branch.DataSource = Sub_Bank2.Get_Sub_Banks(int.Parse(DDL_Bank.SelectedValue));
                    DDL_Bank_Branch.DataBind();

                    DDL_Bank_Branch.SelectedValue = Sub_Bank;

                }


            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Cls_Connection.close_connection();


            }

        }


        //public void Get_SubChecks_ForUpdate()
        //{
        //    try
        //    {

        //        SqlConnection con = new SqlConnection();

        //        con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
        //        con = Cls_Connection._con;
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = con;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "Get_SubChecks_ForUpdate";
        //        cmd.Parameters.AddWithValue("@ID", Convert.ToInt64(GV_SubChecks.SelectedRow.Cells[1].Text));
        //        Cls_Connection.open_connection();
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        bool Result;
        //        string Check_Date;
        //        DateTime Check_Date2;


        //        while (dr.Read())
        //        {


        //            if (!dr.IsDBNull(dr.GetOrdinal("Sent_To")))
        //            {
        //                DDL_Sent_To.SelectedValue = dr.GetValue(dr.GetOrdinal("Sent_To")).ToString();
        //            }

        //            Txt_Value.Text = dr.GetValue(dr.GetOrdinal("Value")).ToString();
        //            Txt_Check_No.Text = dr.GetValue(dr.GetOrdinal("Check_No")).ToString();


        //            Check_Date = dr.GetValue(dr.GetOrdinal("Check_Date")).ToString();
        //            Result = DateTime.TryParse(Check_Date, out Check_Date2);
        //            if (Result)
        //            {
        //                Txt_Check_Date2.Text = Check_Date2.ToShortDateString();
        //            }

        //            Txt_Months.Text = dr.GetValue(dr.GetOrdinal("Months")).ToString();

        //            Txt_Notes.Text = dr.GetValue(dr.GetOrdinal("Notes")).ToString();

        //            //Txt_ID.Text = "1";


        //        }

        //        Cls_Connection.close_connection();




        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Message.ToString();
        //        Cls_Connection.close_connection();


        //    }

        //}

        protected void Btn_InsertAll_Click(object sender, EventArgs e)
        {
            string StrQuery;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
            con = Cls_Connection._con;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                for (int i = 0; i < GV_Main_Check.Rows.Count; i++)
                {
                    StrQuery = @"UPDATE [dbo].[Main_Check] SET [Checked] = 1 WHERE ID="
                        + GV_Main_Check.Rows[i].Cells[1].Text + "";
                    cmd.CommandText = StrQuery;
                    cmd.ExecuteNonQuery();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                MSG("تم حفظ جميع المدخلات");

                GV_Main_Check.DataSource = null;
                GV_Main_Check.DataBind();
                Page.Response.Redirect(Page.Request.Url.ToString(), true);

            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }


            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        public DataTable Get_SubCheck()
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
                cmd.CommandText = "Get_SubChecks_View";
                cmd.Parameters.AddWithValue("@CompanyID", int.Parse(DDL_Company.SelectedValue));
                cmd.Parameters.AddWithValue("@Check_Date", DateTime.Parse(Txt_Check_Date.Text));
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


        //public void Get_SubChecks_ForGridView()
        //{
        //    try
        //    {

        //        SqlConnection con = new SqlConnection();

        //        con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
        //        con = Cls_Connection._con;
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = con;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "Get_SubChecks_ForGridView";
        //        Cls_Connection.open_connection();
        //        DataTable dt = new DataTable();
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        da.Fill(dt);
        //        GV_SubChecks.DataSource = dt;
        //        GV_SubChecks.DataBind();
        //        Cls_Connection.close_connection();
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Message.ToString();
        //        Cls_Connection.close_connection();


        //    }

        //}

        //public void Get_SubChecks_ForMainChecks()
        //{
        //    try
        //    {

        //        SqlConnection con = new SqlConnection();

        //        con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
        //        con = Cls_Connection._con;
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = con;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "Get_SubChecks_ForMainChecks";
        //        cmd.Parameters.AddWithValue("@Main_Check_ID", Convert.ToInt64(GV_Main_Check.SelectedRow.Cells[1].Text));
        //        Cls_Connection.open_connection();
        //        DataTable dt = new DataTable();
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        da.Fill(dt);
        //        GV_SubChecks.DataSource = dt;
        //        GV_SubChecks.DataBind();
        //        Cls_Connection.close_connection();
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Message.ToString();
        //        Cls_Connection.close_connection();


        //    }

        //}

        protected void GV_Main_Check_SelectedIndexChanged(object sender, EventArgs e)
        {
            Get_MainChecks_ForUpdate();
            //Get_SubChecks_ForMainChecks();

        }


        //rami

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
                    Get_MainChecks_ForUpdate();
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
            //rami
            if (HttpContext.Current.User.IsInRole("Doctor"))
            {
                Get_MainChecks_ForGridView(HttpContext.Current.User.Identity.Name);
            }
            else
            {
                Get_MainChecks_ForGridView();
            }
            //rami
        }

        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }



        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Cls_Main_Check Main_Check = new Cls_Main_Check();
                Main_Check._ID = Convert.ToInt64(GV_Main_Check.SelectedRow.Cells[1].Text);
                string Result = "";
                Result = Main_Check.Delete_Main_Check();

                ////////////////////////////////       Log        /////////////////////////////////////////////
                Cls_Log log = new Cls_Log();
                log._Log_Event = " : حذف الشيك رقم  " + Txt_Check_No.Text + " للجهة الطبية " + DDL_Sent_To.SelectedItem.Text;
                log.Insert_Log();
                ////////////////////////////////   End Of Log        /////////////////////////////////////////////

                MSG(Result);
                GV_Main_Check.DataBind();

                //ClearFields(Form.Controls);
                Txt_Check_No.Text = "";
                //Txt_Months.Text = "";
                Txt_Notes.Text = "";
                Txt_Value.Text = "";
                DDL_Sent_To.SelectedValue = "0";
                Cls_Sub_Banks Sub_Bank = new Cls_Sub_Banks();
                DDL_Bank_Branch.DataSource = Sub_Bank.Get_Sub_Banks(int.Parse(DDL_Bank.SelectedValue));
                DDL_Bank_Branch.DataBind();
                DDL_Bank_Branch.Items.Insert(0, new ListItem("--اختر--", "0"));
                DDL_Company.Focus();

            }
            catch (Exception)
            {

                MSG("حدث خطأ يرجى اختيار الشيك المراد حذفه");
            }
            //rami
            if (HttpContext.Current.User.IsInRole("Doctor"))
            {
                Get_MainChecks_ForGridView(HttpContext.Current.User.Identity.Name);
            }
            else
            {
                Get_MainChecks_ForGridView();
            }
            //rami
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

        protected void GV_Main_Check_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //rami
            if (HttpContext.Current.User.IsInRole("Doctor"))
            {
                Get_MainChecks_ForGridView(HttpContext.Current.User.Identity.Name);
            }
            else
            {
                Get_MainChecks_ForGridView();
            }
            //rami
            GV_Main_Check.PageIndex = e.NewPageIndex;
            GV_Main_Check.DataBind();
        }

        public void Search()
        {
            try
            {

                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                if (DDL_Company.SelectedItem.Text == "--اختر--")
                {
                    //GV_Main_Check.DataSource = SqlDataSource_Checks;
                    //GV_Main_Check.DataBind();

                    //rami
                    if (HttpContext.Current.User.IsInRole("Doctor"))
                    {
                        Get_MainChecks_ForGridView(HttpContext.Current.User.Identity.Name);
                    }
                    else
                    {
                        Get_MainChecks_ForGridView();
                    }
                    //rami

                }
                else
                {
                    if (HttpContext.Current.User.IsInRole("Doctor"))
                    {

                        cmd.CommandText = "SELECT [ID] as 'التسلسل' ,[Company] as 'اسم الشركة', [Check_Date] as 'تاريخ الشيك',SentTo as 'الجهة الطبية',Value as 'المبلغ' ,Check_No as 'رقم الشيك' FROM [dbo].[V_Main_Check] where Company = N'" + DDL_Company.SelectedItem.Text + "' and UName='" + HttpContext.Current.User.Identity.Name + "' ORDER BY [ID] DESC";

                        //cmd.CommandText = "SELECT[ID] ,[Company],[Check_Date],SentTo,Value,Check_No FROM[dbo].[V_Main_Check] where Company = N'" + DDL_Company.SelectedItem.Text + "' and UName='" + HttpContext.Current.User.Identity.Name + "' ORDER BY [ID] DESC";
                    }
                    else
                    {
                        cmd.CommandText = "SELECT [ID] as 'التسلسل' ,[Company] as 'اسم الشركة', [Check_Date] as 'تاريخ الشيك',SentTo as 'الجهة الطبية',Value as 'المبلغ' ,Check_No as 'رقم الشيك' FROM [dbo].[V_Main_Check] where Company = N'" + DDL_Company.SelectedItem.Text + "' ORDER BY [ID] DESC";

                        //cmd.CommandText = "SELECT[ID] ,[Company],[Check_Date],SentTo,Value,Check_No FROM[dbo].[V_Main_Check] where Company = N'" + DDL_Company.SelectedItem.Text + "' ORDER BY [ID] DESC";
                    }




                    Cls_Connection.open_connection();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    GV_Main_Check.DataSourceID = null;
                    GV_Main_Check.DataSource = dt;
                    GV_Main_Check.DataBind();
                    Cls_Connection.close_connection();
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Cls_Connection.close_connection();


            }

        }



        protected void Btn_MedicalTypesChecks_Click(object sender, EventArgs e)
        {
            DDL_Sent_To.DataSource = Cls_Main_Claims.Get_Medical_Types3();
            DDL_Sent_To.DataBind();
            DDL_Sent_To.Items.Insert(0, new ListItem("--اختر--", "0"));

        }

        protected void Btn_companiesChecks_Click(object sender, EventArgs e)
        {
            DDL_Sent_To.DataSource = Cls_Main_Claims.Get_Medical_Types2();
            DDL_Sent_To.DataBind();
            DDL_Sent_To.Items.Insert(0, new ListItem("--اختر--", "0"));

        }

        protected void Font_Click(object sender, EventArgs e)
        {
            Response.Redirect("DownloadFont.ashx");
        }

        //rami
        //protected void GV_SubChecks_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Get_SubChecks_ForUpdate();
        //}

        //protected void GV_SubChecks_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    Get_SubChecks_ForGridView();
        //    GV_SubChecks.PageIndex = e.NewPageIndex;
        //    GV_SubChecks.DataBind();
        //}
    }
}