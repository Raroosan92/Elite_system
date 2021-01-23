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
    public partial class Medical_Types : System.Web.UI.Page
    {
        int Attch_Id;
        public void MSG(string Text)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('" + Text + "')</script>", false);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //--rami لتغيير التاريخ من لوحة المفاتيح--
            Txt_Contract_Date.Attributes.Add("onkeydown", "DateField_KeyDown(this,'" + CalendarExtender1.ClientID + "')");
            Txt_ContractExpiryDate.Attributes.Add("onkeydown", "DateField_KeyDown(this,'" + CalendarExtender2.ClientID + "')");
            Txt_Accounting_Date.Attributes.Add("onkeydown", "DateField_KeyDown(this,'" + CalendarExtender3.ClientID + "')");
            Txt_Contract_Date2.Attributes.Add("onkeydown", "DateField_KeyDown(this,'" + CalendarExtender11.ClientID + "')");
            Txt_ContractExpiryDate2.Attributes.Add("onkeydown", "DateField_KeyDown(this,'" + CalendarExtender22.ClientID + "')");
            Txt_Accounting_Date2.Attributes.Add("onkeydown", "DateField_KeyDown(this,'" + CalendarExtender33.ClientID + "')");
            //--rami لتغيير التاريخ من لوحة المفاتيح-- 
            if (!Page.IsPostBack)
            {
                //rami
                slider.Visible = false;

                Btn_Update1.Visible = HttpContext.Current.User.IsInRole("Update");
                Btn_Save1.Visible = HttpContext.Current.User.IsInRole("Add");
                Btn_Delete.Visible = HttpContext.Current.User.IsInRole("Delete");

                Btn_Save2.Visible = HttpContext.Current.User.IsInRole("Add");
                Btn_Update2.Visible = HttpContext.Current.User.IsInRole("Update");
                
                if (HttpContext.Current.User.IsInRole("Admin"))
                {
                    Btn_Update1.Visible = true;
                    Btn_Save1.Visible = true;
                    Btn_Delete.Visible = true;
                    Btn_Update2.Visible = true;
                    Btn_Save2.Visible = true;

                }

                GetTotal();

                DDL_Type.DataSource = Cls_Codes.Fill_DDL(1);
                DDL_Type.DataBind();
                DDL_Type.Items.Insert(0, new ListItem("--اختر--", "0"));

                DDL_Specialization.DataSource = Cls_Codes.Fill_DDL(2);
                DDL_Specialization.DataBind();
                DDL_Specialization.Items.Insert(0, new ListItem("--اختر--", "0"));


                DDL_Place.DataSource = Cls_Codes.Fill_DDL(311);
                DDL_Place.DataBind();
                DDL_Place.Items.Insert(0, new ListItem("--اختر--", "0"));

                //DDL_Medical_Status.DataSource = Cls_Codes.Fill_DDL(4);
                //DDL_Medical_Status.DataBind();
                //DDL_Medical_Status.Items.Insert(0, new ListItem("--اختر--", "0"));

                DDL_Contracting_Status.DataSource = Cls_Codes.Fill_DDL(5);
                DDL_Contracting_Status.DataBind();
                DDL_Contracting_Status.Items.Insert(0, new ListItem("--اختر--", "0"));


                DDL_Employee.DataSource = Cls_Employees.Get_Employee();
                DDL_Employee.DataBind();
                DDL_Employee.Items.Insert(0, new ListItem("--اختر--", "0"));


                DDL_Bank.DataSource = Cls_Main_Banks.Get_Main_Banks();
                DDL_Bank.DataBind();
                DDL_Bank.Items.Insert(0, new ListItem("--اختر--", "0"));

                DDL_Region1.DataSource = Cls_Codes.Fill_DDL(3);
                DDL_Region1.DataBind();
                DDL_Region1.Items.Insert(0, new ListItem("--اختر--", "0"));

                //-------------------------------------

                DDL_Medical_Name.DataSource = Cls_Main_Claims.Get_Medical_Types2();
                DDL_Medical_Name.DataBind();
                DDL_Medical_Name.Items.Insert(0, new ListItem("--اختر--", "0"));

                DDL_Type2.DataSource = Cls_Codes.Fill_DDL(1);
                DDL_Type2.DataBind();
                DDL_Type2.Items.Insert(0, new ListItem("--اختر--", "0"));

                DDL_Specialization2.DataSource = Cls_Codes.Fill_DDL(2);
                DDL_Specialization2.DataBind();
                DDL_Specialization2.Items.Insert(0, new ListItem("--اختر--", "0"));


                DDL_Place2.DataSource = Cls_Codes.Fill_DDL(311);
                DDL_Place2.DataBind();
                DDL_Place2.Items.Insert(0, new ListItem("--اختر--", "0"));

                //DDL_Medical_Status2.DataSource = Cls_Codes.Fill_DDL(4);
                //DDL_Medical_Status2.DataBind();
                //DDL_Medical_Status2.Items.Insert(0, new ListItem("--اختر--", "0"));

                DDL_Contracting_Status2.DataSource = Cls_Codes.Fill_DDL(5);
                DDL_Contracting_Status2.DataBind();
                DDL_Contracting_Status2.Items.Insert(0, new ListItem("--اختر--", "0"));


                DDL_Employee2.DataSource = Cls_Employees.Get_Employee();
                DDL_Employee2.DataBind();
                DDL_Employee2.Items.Insert(0, new ListItem("--اختر--", "0"));


                DDL_Bank2.DataSource = Cls_Main_Banks.Get_Main_Banks();
                DDL_Bank2.DataBind();
                DDL_Bank2.Items.Insert(0, new ListItem("--اختر--", "0"));

                DDL_Region2.DataSource = Cls_Codes.Fill_DDL(3);
                DDL_Region2.DataBind();
                DDL_Region2.Items.Insert(0, new ListItem("--اختر--", "0"));
                Get_Medical_Types_ForUpdate();

                Hide_Controls1();
                Hide_Controls2();
                Txt_Name.Focus();

            }

        }

        protected void DDL_Bank_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cls_Sub_Banks Sub_Bank = new Cls_Sub_Banks();
            DDL_Bank_Branch.DataSource = Sub_Bank.Get_Sub_Banks(int.Parse(DDL_Bank.SelectedValue));
            DDL_Bank_Branch.DataBind();
            DDL_Bank_Branch.Focus();
        }

        protected void DDL_Bank2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cls_Sub_Banks Sub_Bank = new Cls_Sub_Banks();
            DDL_Bank_Branch2.DataSource = Sub_Bank.Get_Sub_Banks(int.Parse(DDL_Bank2.SelectedValue));
            DDL_Bank_Branch2.DataBind();
            DDL_Bank_Branch2.Focus();
        }


        protected void DDL_Medical_Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            Get_Medical_Types_ForUpdate();
            Txt_Name2.Focus();
        }
        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            Cls_Medical_Types_And_Companies Medical_Type = new Cls_Medical_Types_And_Companies();
            if (Txt_Name.Text != "" && DDL_Specialization.SelectedIndex != 0)
            {

                //Random random = new Random();
                //int num = random.Next(9000);
                Medical_Type._Acounting_NO = Txt_Acounting_NO.Text;


                Medical_Type._Address = Txt_Address.Text;
                //Medical_Type._Authorization_NO = Txt_Authorization_NO.Text;
                if (DDL_Bank.SelectedValue != "")
                {
                    Medical_Type._Bank = int.Parse(DDL_Bank.SelectedValue);
                }

                if (DDL_Bank_Branch.SelectedValue != "")
                {
                    Medical_Type._Bank_Branch = int.Parse(DDL_Bank_Branch.SelectedValue);
                }

                //Medical_Type._Building = Txt_Building.Text;
                if (Txt_ContractExpiryDate.Text != "")
                {
                    Medical_Type._ContractExpiryDate = DateTime.Parse(Txt_ContractExpiryDate.Text);
                }

                if (Txt_Contract_Date.Text != "")
                {
                    Medical_Type._Contract_Date = DateTime.Parse(Txt_Contract_Date.Text);
                }
                if (Txt_Accounting_Date.Text != "")
                {
                    Medical_Type._Accounting_Date = DateTime.Parse(Txt_Accounting_Date.Text);
                }
                //Medical_Type._Contracting_NO = Txt_Contracting_NO.Text;
                if (DDL_Contracting_Status.SelectedValue != "")
                {
                    Medical_Type._Contracting_Status = int.Parse(DDL_Contracting_Status.SelectedValue);
                }

                Medical_Type._Contracting_Value = Txt_Contracting_Value.Text;


                Medical_Type._Email = Txt_Email.Text;

                if (DDL_Employee.SelectedValue != "")
                {
                    Medical_Type._Employee = int.Parse(DDL_Employee.SelectedValue);
                }

                Medical_Type._Fax = Txt_Fax.Text;
                //if (DDL_Medical_Status.SelectedValue != "")
                //{
                //    Medical_Type._Medical_Status = int.Parse(DDL_Medical_Status.SelectedValue);
                //}

                Medical_Type._Mobile = Txt_Mobile.Text;
                Medical_Type._Name = Txt_Name.Text;
                Medical_Type._Phone = Txt_Phone.Text;

                if (DDL_Place.SelectedValue != "")
                {
                    Medical_Type._Place = int.Parse(DDL_Place.SelectedValue);
                }

                Medical_Type._P_O_Box = Txt_P_O_Box.Text;
                Medical_Type._P_O_Box2 = Txt_P_O_Box2.Text;
                //Medical_Type._Reason = Txt_Reason.Text;

                if (DDL_Region1.SelectedValue != "")
                {
                    Medical_Type._Region = int.Parse(DDL_Region1.SelectedValue);
                }


                if (DDL_Specialization.SelectedValue != "")
                {
                    Medical_Type._Specialization = int.Parse(DDL_Specialization.SelectedValue);
                }

                if (RB_Stamps.SelectedValue == "1")
                {
                    Medical_Type._Stamps = 306;
                }
                else
                {
                    Medical_Type._Stamps = 307;
                }

                Medical_Type._Tax_NO = Txt_Tax_NO.Text;
                if (DDL_Type.SelectedValue != "")
                {
                    Medical_Type._Type = int.Parse(DDL_Type.SelectedValue);
                }

                string Result = "";
                //------------------ assign Contract_NO --------------------------------
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select IDENT_CURRENT('Medical_Types_And_Companies')";
                int Contract_NO;
                Cls_Connection.open_connection();
                Contract_NO = int.Parse(cmd.ExecuteScalar().ToString()) + 1;
                Cls_Connection.close_connection();
                Txt_Contract_NO.Text = Contract_NO.ToString();
                // -------------------------- end of Contract_NO -------------------------

                Medical_Type._Contract_NO = int.Parse(Txt_Contract_NO.Text);

                //if (Txt_TransactionPrice.Text != "")
                //{
                //    Medical_Type._TransactionPrice = decimal.Parse(Txt_TransactionPrice.Text);
                //}

                //if (Txt_CheckPrice.Text != "")
                //{
                //    Medical_Type._CheckPrice = decimal.Parse(Txt_CheckPrice.Text);
                //}

                //if (Txt_DiscountRatio.Text != "")
                //{
                //    Medical_Type._DiscountRatio = decimal.Parse(Txt_DiscountRatio.Text);
                //}


                Result = Medical_Type.Insert_Medical_Types();
                ////////////////////////////////       Log        /////////////////////////////////////////////
                Cls_Log log = new Cls_Log();
                log._Log_Event = "إضافة جهة طبية جديدة  : " + Txt_Name.Text;
                log.Insert_Log();
                ////////////////////////////////   End Of Log        /////////////////////////////////////////////


                //rami
                int attach_type = 600;
                string attach_place_store;
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd11 = new SqlCommand();
                DataSet ds = new DataSet();
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CONN"].ConnectionString);
                conn.Open();
                cmd11.Connection = conn;

                cmd11.CommandText = "Select IDENT_CURRENT('Medical_Types_And_Companies')";
                int strImageName = int.Parse(cmd11.ExecuteScalar().ToString());

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

                        cmd11.Parameters.Clear();
                        cmd11.CommandText = "Select IDENT_CURRENT('Attachments')";
                        Attch_Id = int.Parse(cmd11.ExecuteScalar().ToString()) + 1;
                        cmd11.Parameters.Clear();

                        try
                        {
                            if (userPostedFile.ContentLength > 0)

                            {
                                if (System.IO.Path.GetExtension(userPostedFile.FileName).ToLower() == ".jpeg" || System.IO.Path.GetExtension(userPostedFile.FileName).ToLower() == ".jpg" || System.IO.Path.GetExtension(userPostedFile.FileName).ToLower() == ".png" || System.IO.Path.GetExtension(userPostedFile.FileName).ToLower() == ".bmp")
                                {
                                    string strConnString = ConfigurationManager.ConnectionStrings["CONN"].ConnectionString;

                                    using (SqlConnection con1 = new SqlConnection(strConnString))
                                    {
                                        //////////////////////////////////////////////////
                                        attach_place_store = "\\\\Medical_Types" + "\\\\" + yy + "\\\\" + mm + "\\\\" + dd + "\\\\" + Attch_Id + ".jpg";
                                        using (SqlCommand cmd1 = new SqlCommand())
                                        {
                                            cmd1.CommandType = CommandType.StoredProcedure;
                                            cmd1.CommandText = "SP_Attachments";
                                            cmd1.Parameters.AddWithValue("@attach_type", attach_type);
                                            cmd1.Parameters.AddWithValue("@attach_Path", attach_place_store);
                                            cmd1.Parameters.AddWithValue("@attach_doc_id", strImageName);
                                            cmd1.Parameters.AddWithValue("@check", "i");
                                            cmd1.Connection = con1;
                                            con1.Open();
                                            cmd1.ExecuteNonQuery();
                                            con1.Close();
                                        }
                                    }

                                    System.IO.Directory.CreateDirectory(Server.MapPath("\\UploadedImages\\Medical_Types\\" + yy + "\\" + mm + "\\" + dd + "\\"));
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
                //Response.Redirect(Request.Url.AbsoluteUri);
                GetTotal();
                MSG(Result);

            }
            else
            {
                MSG("يرجى ادخال تفاصيل المعاملة");
            }

            //rami

            ClearFields(Form.Controls);
            Cls_Sub_Banks Sub_Bank = new Cls_Sub_Banks();
            DDL_Bank_Branch.DataSource = Sub_Bank.Get_Sub_Banks(int.Parse(DDL_Bank.SelectedValue));
            DDL_Bank_Branch.DataBind();
            DDL_Bank_Branch.Items.Insert(0, new ListItem("--اختر--", "0"));

            Hide_Controls1();

        }

        public void Get_Medical_Types_ForUpdate()
        {
            try
            {
                string Bank_Branch = "";
                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Get_Medical_Types_ForUpdate";
                cmd.Parameters.AddWithValue("@ID", Int64.Parse(DDL_Medical_Name.SelectedValue.ToString()));
                Cls_Connection.open_connection();
                SqlDataReader dr = cmd.ExecuteReader();
                bool Result;
                string ContractExpiryDate;
                DateTime ContractExpiryDate2;
                string Accounting_Date;
                DateTime Accounting_Date2;
                string Contract_Date;
                DateTime Contract_Date2;

                while (dr.Read())
                {
                    Accounting_Date = dr.GetValue(dr.GetOrdinal("Accounting_Date")).ToString();
                    Result = DateTime.TryParse(Accounting_Date, out Accounting_Date2);
                    if (Result)
                    {
                        Txt_Accounting_Date2.Text = Accounting_Date2.ToString("yyyy-MM-dd");
                    }


                    Txt_Acounting_NO2.Text = dr.GetValue(dr.GetOrdinal("Acounting_NO")).ToString();
                    Txt_Address2.Text = dr.GetValue(dr.GetOrdinal("Address")).ToString();
                    //Txt_Authorization_NO2.Text = dr.GetValue(dr.GetOrdinal("Authorization_NO")).ToString();
                    //Txt_Building2.Text = dr.GetValue(dr.GetOrdinal("Building")).ToString();
                    //Txt_ContractExpiryDate.Text =DateTime.Parse( dr.GetValue(dr.GetOrdinal("ContractExpiryDate")).ToString()).ToString();


                    //Txt_Contracting_NO2.Text = dr.GetValue(dr.GetOrdinal("Contracting_NO")).ToString();
                    Txt_Contracting_Value2.Text = dr.GetValue(dr.GetOrdinal("Contracting_Value")).ToString();

                    Contract_Date = dr.GetValue(dr.GetOrdinal("Contract_Date")).ToString();
                    Result = DateTime.TryParse(Contract_Date, out Contract_Date2);
                    if (Result)
                    {
                        Txt_Contract_Date2.Text = Contract_Date2.ToString("yyyy-MM-dd");
                    }


                    Txt_Contract_NO2.Text = dr.GetValue(dr.GetOrdinal("Contract_NO")).ToString();
                    Txt_Email2.Text = dr.GetValue(dr.GetOrdinal("Email")).ToString();
                    Txt_Fax2.Text = dr.GetValue(dr.GetOrdinal("Fax")).ToString();
                    Txt_Mobile2.Text = dr.GetValue(dr.GetOrdinal("Mobile")).ToString();
                    Txt_Name2.Text = dr.GetValue(dr.GetOrdinal("Name")).ToString();
                    Txt_Phone2.Text = dr.GetValue(dr.GetOrdinal("Phone")).ToString();
                    Txt_P_O_Box3.Text = dr.GetValue(dr.GetOrdinal("P_O_Box")).ToString();
                    Txt_P_O_Box4.Text = dr.GetValue(dr.GetOrdinal("P_O_Box2")).ToString();
                    //Txt_Reason2.Text = dr.GetValue(dr.GetOrdinal("Reason")).ToString();
                    Txt_Tax_NO2.Text = dr.GetValue(dr.GetOrdinal("Tax_NO")).ToString();

                    if (!dr.IsDBNull(dr.GetOrdinal("Type")))
                    {
                        DDL_Type2.SelectedValue = dr.GetValue(dr.GetOrdinal("Type")).ToString();
                    }

                    if (!dr.IsDBNull(dr.GetOrdinal("Specialization")))
                    {
                        DDL_Specialization2.SelectedValue = dr.GetValue(dr.GetOrdinal("Specialization")).ToString();
                    }
                    if (!dr.IsDBNull(dr.GetOrdinal("Place")))
                    {
                        DDL_Place2.SelectedValue = dr.GetValue(dr.GetOrdinal("Place")).ToString();
                    }

                    if (!dr.IsDBNull(dr.GetOrdinal("Region")))
                    {
                        DDL_Region2.SelectedValue = dr.GetValue(dr.GetOrdinal("Region")).ToString();
                    }
                    //if (!dr.IsDBNull(dr.GetOrdinal("Medical_Status")))
                    //{
                    //    DDL_Medical_Status2.SelectedValue = dr.GetValue(dr.GetOrdinal("Medical_Status")).ToString();
                    //}
                    if (!dr.IsDBNull(dr.GetOrdinal("Employee")))
                    {
                        DDL_Employee2.SelectedValue = dr.GetValue(dr.GetOrdinal("Employee")).ToString();
                    }
                    if (!dr.IsDBNull(dr.GetOrdinal("Contracting_Status")))
                    {
                        DDL_Contracting_Status2.SelectedValue = dr.GetValue(dr.GetOrdinal("Contracting_Status")).ToString();
                    }
                    if (!dr.IsDBNull(dr.GetOrdinal("Bank")))
                    {
                        DDL_Bank2.SelectedValue = dr.GetValue(dr.GetOrdinal("Bank")).ToString();

                    }
                    if (!dr.IsDBNull(dr.GetOrdinal("Bank_Branch")))
                    {
                        Bank_Branch = dr.GetValue(dr.GetOrdinal("Bank_Branch")).ToString();
                    }
                    string Stamps = dr.GetValue(dr.GetOrdinal("Stamps")).ToString();
                    if (Stamps == "306")
                    {
                        RB_Stamps2.SelectedValue = "1";
                    }
                    else
                    {
                        RB_Stamps2.SelectedValue = "0";
                    }


                    ContractExpiryDate = dr.GetValue(dr.GetOrdinal("ContractExpiryDate")).ToString();
                    Result = DateTime.TryParse(ContractExpiryDate, out ContractExpiryDate2);
                    if (Result)
                    {
                        Txt_ContractExpiryDate2.Text = ContractExpiryDate2.ToString("yyyy-MM-dd");
                    }


                }

                if (DDL_Contracting_Status2.SelectedValue == "267")
                {
                    UnHide_Controls2();
                }
                else
                {
                    Hide_Controls2();
                }

                //rami
                SqlDataAdapter da2 = new SqlDataAdapter();
                DataSet ds2 = new DataSet();
                SqlCommand cmd2 = new SqlCommand();
                con.Close();
                cmd2.Connection = con;
                con.Open();
                cmd2.CommandText = "select attach_Path,Attach_Id from Attachments where attach_doc_id=" + Convert.ToInt64(DDL_Medical_Name.SelectedValue) + "";
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

                    //Fill_DDL_Images(Convert.ToInt16(DDL_Medical_Name.SelectedValue));

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
                if (Bank_Branch != "")
                {
                    Cls_Sub_Banks Sub_Bank = new Cls_Sub_Banks();
                    DDL_Bank_Branch2.DataSource = Sub_Bank.Get_Sub_Banks(int.Parse(DDL_Bank2.SelectedValue));
                    DDL_Bank_Branch2.DataBind();

                    DDL_Bank_Branch2.SelectedValue = Bank_Branch;

                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Cls_Connection.close_connection();


            }

        }

        //rami
        //protected void Fill_DDL_Images(int attach_doc_id)
        //{
        //    DataTable ds = new DataTable();
        //    try
        //    {
        //        SqlConnection con = new SqlConnection();
        //        con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
        //        con = Cls_Connection._con;
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = con;
        //        cmd.CommandText = "select Attach_Id from Attachments where attach_doc_id = " + attach_doc_id + "";
        //        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        //        if (!IsPostBack)
        //        {
        //            con.Open();
        //        }

        //        adp.Fill(ds);
        //        Cls_Connection.close_connection();
        //        DDl_Images.DataSource = ds;
        //        DDl_Images.DataTextField = "Attach_Id";
        //        DDl_Images.DataValueField = "Attach_Id";
        //        DDl_Images.DataBind();
        //        DDl_Images.Items.Insert(0, new ListItem("--اختر--", "0"));

        //    }
        //    catch (Exception)
        //    {
        //        Cls_Connection.close_connection();
        //    }


        //}
        //rami

        //rami
        //protected void CH_DeleteImage_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (CH_DeleteImage.Checked)
        //    {
        //        Btn_Delete.Enabled = true;
        //        DDl_Images.Enabled = true;
        //    }
        //    else
        //    {
        //        Btn_Delete.Enabled = false;
        //        DDl_Images.Enabled = false;
        //    }
        //}


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
                    Get_Medical_Types_ForUpdate();
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

        //rami

        protected void Btn_Update_Click(object sender, EventArgs e)
        {
            Cls_Medical_Types_And_Companies Medical_Type = new Cls_Medical_Types_And_Companies();


            Medical_Type._Acounting_NO = Txt_Acounting_NO2.Text;
            Medical_Type._Address = Txt_Address2.Text;
            //Medical_Type._Authorization_NO = Txt_Authorization_NO2.Text;
            if (DDL_Bank2.SelectedValue != "")
            {
                Medical_Type._Bank = int.Parse(DDL_Bank2.SelectedValue);
            }

            if (DDL_Bank_Branch2.SelectedValue != "")
            {
                Medical_Type._Bank_Branch = int.Parse(DDL_Bank_Branch2.SelectedValue);
            }

            //Medical_Type._Building = Txt_Building2.Text;
            if (Txt_ContractExpiryDate2.Text != "")
            {
                Medical_Type._ContractExpiryDate = DateTime.Parse(Txt_ContractExpiryDate2.Text);
            }

            if (Txt_Contract_Date2.Text != "")
            {
                Medical_Type._Contract_Date = DateTime.Parse(Txt_Contract_Date2.Text);
            }
            if (Txt_Accounting_Date2.Text != "")
            {
                Medical_Type._Accounting_Date = DateTime.Parse(Txt_Accounting_Date2.Text);
            }
            //Medical_Type._Contracting_NO = Txt_Contracting_NO2.Text;


            if (DDL_Contracting_Status2.SelectedValue != "")
            {
                Medical_Type._Contracting_Status = int.Parse(DDL_Contracting_Status2.SelectedValue);
            }
            Medical_Type._Contracting_Value = Txt_Contracting_Value2.Text;
            if (Txt_Contract_NO2.Text != "")
            {
                Medical_Type._Contract_NO = int.Parse(Txt_Contract_NO2.Text);
            }

            if (Txt_Email2.Text != "")
            {
                Medical_Type._Email = Txt_Email2.Text;
            }


            if (DDL_Employee2.SelectedValue != "")
            {
                Medical_Type._Employee = int.Parse(DDL_Employee2.SelectedValue);
            }

            Medical_Type._Fax = Txt_Fax2.Text;
            //if (DDL_Medical_Status2.SelectedValue != "")
            //{
            //    Medical_Type._Medical_Status = int.Parse(DDL_Medical_Status2.SelectedValue);
            //}

            Medical_Type._Mobile = Txt_Mobile2.Text;
            Medical_Type._Name = Txt_Name2.Text;
            Medical_Type._Phone = Txt_Phone2.Text;
            if (DDL_Place2.SelectedValue != "")
            {
                Medical_Type._Place = int.Parse(DDL_Place2.SelectedValue);
            }

            Medical_Type._P_O_Box = Txt_P_O_Box3.Text;
            Medical_Type._P_O_Box2 = Txt_P_O_Box4.Text;
            //Medical_Type._Reason = Txt_Reason2.Text;
            if (DDL_Region2.SelectedValue != "")
            {
                Medical_Type._Region = int.Parse(DDL_Region2.SelectedValue);
            }
            if (DDL_Specialization2.SelectedValue != "")
            {
                Medical_Type._Specialization = int.Parse(DDL_Specialization2.SelectedValue);
            }

            if (RB_Stamps2.SelectedValue == "1")
            {
                Medical_Type._Stamps = 306;
            }
            else
            {
                Medical_Type._Stamps = 307;
            }

            Medical_Type._Tax_NO = Txt_Tax_NO2.Text;
            if (DDL_Type.SelectedValue != "")
            {
                Medical_Type._Type = int.Parse(DDL_Type2.SelectedValue);
            }

            Medical_Type._ID = Int64.Parse(DDL_Medical_Name.SelectedValue.ToString());

            //if (Txt_TransactionPrice2.Text != "")
            //{
            //    Medical_Type._TransactionPrice = decimal.Parse(Txt_TransactionPrice2.Text);
            //}

            //if (Txt_CheckPrice2.Text != "")
            //{
            //    Medical_Type._CheckPrice = decimal.Parse(Txt_CheckPrice2.Text);
            //}

            //if (Txt_DiscountRatio2.Text != "")
            //{
            //    Medical_Type._DiscountRatio = decimal.Parse(Txt_DiscountRatio2.Text);
            //}

            string Result = "";

            Result = Medical_Type.Update_Medical_Types();

            ////////////////////////////////       Log        /////////////////////////////////////////////
            Cls_Log log = new Cls_Log();
            log._Log_Event = "تعديل على الجهة طبية   : " + DDL_Medical_Name.SelectedItem.Text;
            log.Insert_Log();
            ////////////////////////////////   End Of Log        /////////////////////////////////////////////

            //rami
            int attach_type = 600;
            string attach_place_store;
            int strImageName = int.Parse(DDL_Medical_Name.SelectedValue);


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

                                attach_place_store = "\\\\Medical_Types" + "\\\\" + yy + "\\\\" + mm + "\\\\" + dd + "\\\\" + Attch_Id + ".jpg";
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

                                    System.IO.Directory.CreateDirectory(Server.MapPath("\\UploadedImages\\Medical_Types\\" + yy + "\\" + mm + "\\" + dd + "\\"));
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

            //Fill_DDL_Images(Convert.ToInt16(DDL_Medical_Name.SelectedValue));
            //Get_Medical_Types_ForUpdate();
            //Response.Redirect(Request.Url.AbsoluteUri);
            GetTotal();
            MSG(Result);

            ClearFields(Form.Controls);
            Cls_Sub_Banks Sub_Bank = new Cls_Sub_Banks();
            DDL_Bank_Branch2.DataSource = Sub_Bank.Get_Sub_Banks(int.Parse(DDL_Bank.SelectedValue));
            DDL_Bank_Branch2.DataBind();
            DDL_Bank_Branch2.Items.Insert(0, new ListItem("--اختر--", "0"));
            Hide_Controls2();

            //rami
        }


        public static void ClearFields(ControlCollection pageControls)
        {
            foreach (Control contl in pageControls)
            {
                string strCntName = (contl.GetType()).Name;

                switch (strCntName)
                {
                    case "TextBox":
                        TextBox tbSource = (TextBox)contl;
                        tbSource.Text = "";
                        break;
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


        public void GetTotal()
        {
            SqlConnection con22 = new SqlConnection(ConfigurationManager.ConnectionStrings["CONN"].ToString());
            SqlCommand cmd1 = new SqlCommand("select Count(ID)  from Medical_Types_And_Companies where [Contracting_Status]=267 and [Entry_Type]=1", con22);
            con22.Open();
            string Total = cmd1.ExecuteScalar().ToString();
            Lbl_Total.Text = Total;
            con22.Close();

        }

        public void Hide_Controls1()
        {
            Txt_Contract_NO.Visible = false;
            LblContract_NO.Visible = false;
            Txt_Contract_Date.Visible = false;
            lblTxt_Contract_Date.Visible = false;
            Txt_ContractExpiryDate.Visible = false;
            lblTxt_ContractExpiryDate.Visible = false;
            Txt_Accounting_Date.Visible = false;
            lblTxt_Accounting_Date.Visible = false;
            Txt_Contracting_Value.Visible = false;
            lblTxt_Contracting_Value.Visible = false;
            RB_Stamps.Visible = false;
            lblRB_Stamps.Visible = false;
            DDL_Employee.Visible = false;
            lblDDL_Employee.Visible = false;
            DDL_Bank.Visible = false;
            lblDDL_Bank.Visible = false;
            DDL_Bank_Branch.Visible = false;
            lblDDL_Bank_Branch.Visible = false;
            Txt_Acounting_NO.Visible = false;
            lblTxt_Acounting_NO.Visible = false;
            Txt_P_O_Box2.Visible = false;
            lblTxt_P_O_Box2.Visible = false;
            Txt_Tax_NO.Visible = false;
            lblTxt_Tax_NO.Visible = false;
            fileImages.Visible = false;
            lblfileImages.Visible = false;
            Btn_Save2.Visible = false;
            Btn_Save1.Visible = true;

            //Txt_TransactionPrice.Visible = false;
            //Txt_CheckPrice.Visible = false;
            //Txt_DiscountRatio.Visible = false;

            //Lbl_TransactionPrice.Visible = false;
            //Lbl_CheckPrice.Visible = false;
            //Lbl_DiscountRatio.Visible = false;

        }

        public void UnHide_Controls1()
        {
            Txt_Contract_NO.Visible = true;
            LblContract_NO.Visible = true;
            Txt_Contract_Date.Visible = true;
            lblTxt_Contract_Date.Visible = true;
            Txt_ContractExpiryDate.Visible = true;
            lblTxt_ContractExpiryDate.Visible = true;
            Txt_Accounting_Date.Visible = true;
            lblTxt_Accounting_Date.Visible = true;
            Txt_Contracting_Value.Visible = true;
            lblTxt_Contracting_Value.Visible = true;
            RB_Stamps.Visible = true;
            lblRB_Stamps.Visible = true;
            DDL_Employee.Visible = true;
            lblDDL_Employee.Visible = true;
            DDL_Bank.Visible = true;
            lblDDL_Bank.Visible = true;
            DDL_Bank_Branch.Visible = true;
            lblDDL_Bank_Branch.Visible = true;
            Txt_Acounting_NO.Visible = true;
            lblTxt_Acounting_NO.Visible = true;
            Txt_P_O_Box2.Visible = true;
            lblTxt_P_O_Box2.Visible = true;
            Txt_Tax_NO.Visible = true;
            lblTxt_Tax_NO.Visible = true;
            fileImages.Visible = true;
            lblfileImages.Visible = true;
            Btn_Save2.Visible = true;
            //Txt_TransactionPrice.Visible = true;
            //Txt_CheckPrice.Visible = true;
            //Txt_DiscountRatio.Visible = true;

            //Lbl_TransactionPrice.Visible = true;
            //Lbl_CheckPrice.Visible = true;
            //Lbl_DiscountRatio.Visible = true;

            Btn_Save1.Visible = false;
        }


        public void Hide_Controls2()
        {
            Txt_Contract_NO2.Visible = false;
            lblContract_NO2.Visible = false;
            Txt_Contract_Date2.Visible = false;
            lblTxt_Contract_Date2.Visible = false;
            Txt_ContractExpiryDate2.Visible = false;
            lblTxt_ContractExpiryDate2.Visible = false;
            Txt_Accounting_Date2.Visible = false;
            lblTxt_Accounting_Date2.Visible = false;
            Txt_Contracting_Value2.Visible = false;
            lblTxt_Contracting_Value2.Visible = false;
            RB_Stamps2.Visible = false;
            lblRB_Stamps2.Visible = false;
            DDL_Employee2.Visible = false;
            lblDDL_Employee2.Visible = false;
            DDL_Bank2.Visible = false;
            lblDDL_Bank2.Visible = false;
            DDL_Bank_Branch2.Visible = false;
            lblDDL_Bank_Branch2.Visible = false;
            Txt_Acounting_NO2.Visible = false;
            lblTxt_Acounting_NO2.Visible = false;
            Txt_P_O_Box4.Visible = false;
            lblTxt_P_O_Box4.Visible = false;
            Txt_Tax_NO2.Visible = false;
            lblTxt_Tax_NO2.Visible = false;
            FileUpload1.Visible = false;
            lblFileUpload1.Visible = false;
            Btn_Update2.Visible = false;
            Btn_Delete2.Visible = false;

            //Txt_TransactionPrice2.Visible = false;
            //Txt_CheckPrice2.Visible = false;
            //Txt_DiscountRatio2.Visible = false;

            //Lbl_TransactionPrice2.Visible = false;
            //Lbl_CheckPrice2.Visible = false;
            //Lbl_DiscountRatio2.Visible = false;

            Btn_Update1.Visible = true;
            Btn_Delete.Visible = true;

        }

        public void UnHide_Controls2()
        {
            Txt_Contract_NO2.Visible = true;
            lblContract_NO2.Visible = true;
            Txt_Contract_Date2.Visible = true;
            lblTxt_Contract_Date2.Visible = true;
            Txt_ContractExpiryDate2.Visible = true;
            lblTxt_ContractExpiryDate2.Visible = true;
            Txt_Accounting_Date2.Visible = true;
            lblTxt_Accounting_Date2.Visible = true;
            Txt_Contracting_Value2.Visible = true;
            lblTxt_Contracting_Value2.Visible = true;
            RB_Stamps2.Visible = true;
            lblRB_Stamps2.Visible = true;
            DDL_Employee2.Visible = true;
            lblDDL_Employee2.Visible = true;
            DDL_Bank2.Visible = true;
            lblDDL_Bank2.Visible = true;
            DDL_Bank_Branch2.Visible = true;
            lblDDL_Bank_Branch2.Visible = true;
            Txt_Acounting_NO2.Visible = true;
            lblTxt_Acounting_NO2.Visible = true;
            Txt_P_O_Box4.Visible = true;
            lblTxt_P_O_Box4.Visible = true;
            Txt_Tax_NO2.Visible = true;
            lblTxt_Tax_NO2.Visible = true;
            FileUpload1.Visible = true;
            lblFileUpload1.Visible = true;
            Btn_Update2.Visible = true;
            Btn_Delete2.Visible = true;
            //Txt_TransactionPrice2.Visible = true;
            //Txt_CheckPrice2.Visible = true;
            //Txt_DiscountRatio2.Visible = true;
            //Lbl_TransactionPrice2.Visible = true;
            //Lbl_CheckPrice2.Visible = true;
            //Lbl_DiscountRatio2.Visible = true;

            Btn_Update1.Visible = false;
            Btn_Delete.Visible = false;

        }

        protected void DDL_Contracting_Status_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDL_Contracting_Status.SelectedValue == "267")
            {
                UnHide_Controls1();
                Txt_Contract_Date.Focus();
            }
            else
            {
                Hide_Controls1();
                Btn_Save1.Focus();
            }


        }
        protected void DDL_Contracting_Status2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDL_Contracting_Status2.SelectedValue == "267")
            {
                UnHide_Controls2();
                Txt_Contract_Date2.Focus();
            }
            else
            {
                Hide_Controls2();
                Btn_Update1.Focus();
            }
        }

        protected void Btn_Delete_Click1(object sender, EventArgs e)
        {
            string Result = "";
            Cls_Medical_Types_And_Companies Medical_Type = new Cls_Medical_Types_And_Companies();
            if (Txt_Name2.Text != "" && DDL_Medical_Name.SelectedIndex != 0)
            {

                Medical_Type._ID = int.Parse(DDL_Medical_Name.SelectedValue);
                Result = Medical_Type.Delete_Medical_Types();
                ////////////////////////////////       Log        /////////////////////////////////////////////
                Cls_Log log = new Cls_Log();
                log._Log_Event = "حذف جهة طبية   : " + Txt_Name.Text;
                log.Insert_Log();
                ////////////////////////////////   End Of Log        /////////////////////////////////////////////


                //rami
                int attach_type = 600;
                string attach_place_store;
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd11 = new SqlCommand();
                DataSet ds = new DataSet();
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CONN"].ConnectionString);
                conn.Open();
                cmd11.Connection = conn;

                cmd11.CommandText = "Select IDENT_CURRENT('Medical_Types_And_Companies')";
                int strImageName = int.Parse(cmd11.ExecuteScalar().ToString());

                DateTime datevalue = (DateTime.Now);
                string dd = datevalue.Day.ToString();
                string mm = datevalue.Month.ToString();
                string yy = datevalue.Year.ToString();

                try
                {
                    HttpFileCollection flImages = Request.Files;


                    for (int i = 0; i < flImages.Count - 1; i++)
                    {
                        HttpPostedFile userPostedFile = flImages[i];

                        cmd11.Parameters.Clear();
                        cmd11.CommandText = "Select IDENT_CURRENT('Attachments')";
                        Attch_Id = int.Parse(cmd11.ExecuteScalar().ToString()) + 1;
                        cmd11.Parameters.Clear();

                        try
                        {
                            if (userPostedFile.ContentLength > 0)

                            {
                                if (System.IO.Path.GetExtension(userPostedFile.FileName).ToLower() == ".jpeg" || System.IO.Path.GetExtension(userPostedFile.FileName).ToLower() == ".jpg" || System.IO.Path.GetExtension(userPostedFile.FileName).ToLower() == ".png" || System.IO.Path.GetExtension(userPostedFile.FileName).ToLower() == ".bmp")
                                {
                                    string strConnString = ConfigurationManager.ConnectionStrings["CONN"].ConnectionString;

                                    using (SqlConnection con1 = new SqlConnection(strConnString))
                                    {
                                        //////////////////////////////////////////////////
                                        attach_place_store = "\\\\Medical_Types" + "\\\\" + yy + "\\\\" + mm + "\\\\" + dd + "\\\\" + Attch_Id + ".jpg";
                                        using (SqlCommand cmd1 = new SqlCommand())
                                        {
                                            cmd1.CommandType = CommandType.StoredProcedure;
                                            cmd1.CommandText = "SP_Attachments";
                                            cmd1.Parameters.AddWithValue("@attach_type", attach_type);
                                            cmd1.Parameters.AddWithValue("@attach_Path", attach_place_store);
                                            cmd1.Parameters.AddWithValue("@attach_doc_id", strImageName);
                                            cmd1.Parameters.AddWithValue("@check", "d");
                                            cmd1.Connection = con1;
                                            con1.Open();
                                            cmd1.ExecuteNonQuery();
                                            con1.Close();
                                        }
                                    }

                                    System.IO.Directory.CreateDirectory(Server.MapPath("\\UploadedImages\\Medical_Types\\" + yy + "\\" + mm + "\\" + dd + "\\"));
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
                //Response.Redirect(Request.Url.AbsoluteUri);
                GetTotal();
                MSG(Result);

            }
            else
            {
                MSG("يرجى ادخال تفاصيل المعاملة");
            }

            //rami

            ClearFields(Form.Controls);
            Cls_Sub_Banks Sub_Bank = new Cls_Sub_Banks();
            DDL_Bank_Branch.DataSource = Sub_Bank.Get_Sub_Banks(int.Parse(DDL_Bank.SelectedValue));
            DDL_Bank_Branch.DataBind();
            DDL_Bank_Branch.Items.Insert(0, new ListItem("--اختر--", "0"));

            Hide_Controls1();
        }

        //protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
        //{

        //    if (TabContainer1.ActiveTabIndex == 1)
        //    {

        //    }
        //    else
        //    {

        //    }
        //}
    }
}
