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
    public partial class Companies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
   
            Btn_Update.Visible = HttpContext.Current.User.IsInRole("Update");
            Btn_Save.Visible = HttpContext.Current.User.IsInRole("Add");

            //--rami لتغيير التاريخ من لوحة المفاتيح--
            Txt_Contract_Date.Attributes.Add("onkeydown", "DateField_KeyDown(this,'" + CalendarExtender1.ClientID + "')");
            Txt_Contract_Date2.Attributes.Add("onkeydown", "DateField_KeyDown(this,'" + CalendarExtender2.ClientID + "')");
            //--rami لتغيير التاريخ من لوحة المفاتيح-- 

            if (HttpContext.Current.User.IsInRole("Admin"))
            {
                Btn_Update.Visible = true;
                Btn_Save.Visible = true;
      
            }

            if (!Page.IsPostBack)
            {
                DDL_Main_Company.DataSource = Cls_Main_Claims.Get_Companies();
                DDL_Main_Company.DataBind();
                DDL_Main_Company.Items.Insert(0, new ListItem("--اختر--", "0"));

                //Get_Companies_ForUpdate();
            }
        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            Cls_Medical_Types_And_Companies Medical_Type = new Cls_Medical_Types_And_Companies();


            Medical_Type._Address = Txt_Address.Text;


            if (Txt_Contract_Date.Text != "")
            {
                Medical_Type._Contract_Date = DateTime.Parse(Txt_Contract_Date.Text);
            }

            Medical_Type._Fax = Txt_Fax.Text;

            Medical_Type._Mobile = Txt_Mobile.Text;
            Medical_Type._Name = Txt_Name.Text;
            Medical_Type._Phone = Txt_Phone.Text;

            Medical_Type._P_O_Box = Txt_P_O_Box.Text;

            if (RB_Stamps.SelectedValue == "1")
            {
                Medical_Type._Stamps = 306;
            }
            else
            {
                Medical_Type._Stamps = 307;
            }

            if (CBL_Contracting_Type.Items[0].Selected)
            {
                Medical_Type._Contracting_Type1 = int.Parse(CBL_Contracting_Type.Items[0].Value);
            }
            else
            {
                Medical_Type._Contracting_Type1 = 282;
            }

            if (CBL_Contracting_Type.Items[1].Selected)
            {
                Medical_Type._Contracting_Type2 = int.Parse(CBL_Contracting_Type.Items[1].Value);
            }
            else
            {
                Medical_Type._Contracting_Type2 = 282;
            }

            if (CBL_Contracting_Type.Items[2].Selected)
            {
                Medical_Type._Contracting_Type3 = int.Parse(CBL_Contracting_Type.Items[2].Value);
            }
            else
            {
                Medical_Type._Contracting_Type3 = 282;
            }
            string Result = "";

            Result = Medical_Type.Insert_Companies();
            ////////////////////////////////       Log        /////////////////////////////////////////////
            Cls_Log log = new Cls_Log();
            log._Log_Event = "إضافة شركة  : " + Txt_Name.Text;
            log.Insert_Log();
            ////////////////////////////////   End Of Log        /////////////////////////////////////////////
            Label2.Text = Result;
            DDL_Main_Company.DataSource = Cls_Main_Claims.Get_Companies();
            DDL_Main_Company.DataBind();
            DDL_Main_Company.Items.Insert(0, new ListItem("--اختر--", "0"));

            ClearFields(Form.Controls);
        }

        protected void Btn_Update_Click(object sender, EventArgs e)
        {
            Cls_Medical_Types_And_Companies Medical_Type = new Cls_Medical_Types_And_Companies();

            Medical_Type._ID = int.Parse(DDL_Main_Company.SelectedValue);
            Medical_Type._Address = Txt_Address2.Text;


            if (Txt_Contract_Date2.Text != "")
            {
                Medical_Type._Contract_Date = DateTime.Parse(Txt_Contract_Date2.Text);
            }

            Medical_Type._Fax = Txt_Fax2.Text;

            Medical_Type._Mobile = Txt_Mobile2.Text;
            Medical_Type._Name = Txt_Name2.Text;
            Medical_Type._Phone = Txt_Phone2.Text;

            Medical_Type._P_O_Box = Txt_P_O_Box2.Text;

            if (RB_Stamps2.SelectedValue == "1")
            {
                Medical_Type._Stamps = 306;
            }
            else
            {
                Medical_Type._Stamps = 307;
            }

            if (CBL_Contracting_Type2.Items[0].Selected)
            {
                Medical_Type._Contracting_Type1 = int.Parse(CBL_Contracting_Type2.Items[0].Value);
            }
            else
            {
                Medical_Type._Contracting_Type1 = 282;
            }

            if (CBL_Contracting_Type2.Items[1].Selected)
            {
                Medical_Type._Contracting_Type2 = int.Parse(CBL_Contracting_Type2.Items[1].Value);
            }
            else
            {
                Medical_Type._Contracting_Type2 = 282;
            }

            if (CBL_Contracting_Type2.Items[2].Selected)
            {
                Medical_Type._Contracting_Type3 = int.Parse(CBL_Contracting_Type2.Items[2].Value);
            }
            else
            {
                Medical_Type._Contracting_Type3 = 282;
            }
            string Result = "";

            Result = Medical_Type.Update_Companies();
            ////////////////////////////////       Log        /////////////////////////////////////////////
            Cls_Log log = new Cls_Log();
            log._Log_Event = "تعديل على شركة  : " + DDL_Main_Company.SelectedItem.Text ;
            log.Insert_Log();
            ////////////////////////////////   End Of Log        /////////////////////////////////////////////
            Label5.Text = Result;

            ClearFields(Form.Controls);
        }


        public void Get_Companies_ForUpdate()
        {
            try
            {

                SqlConnection con = new SqlConnection();

                con.ConnectionString = ConfigurationManager.ConnectionStrings["CONN"].ToString();
                con = Cls_Connection._con;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Get_Companies_ForUpdate";
                cmd.Parameters.AddWithValue("@ID", Int64.Parse(DDL_Main_Company.SelectedValue.ToString()));
                Cls_Connection.open_connection();
                SqlDataReader dr = cmd.ExecuteReader();
                bool Result;
                string Contract_Date;
                DateTime Contract_Date2;
                int Contracting_Type1 = 282;
                int Contracting_Type2 = 282;
                int Contracting_Type3 = 282;

                while (dr.Read())
                {


                    Txt_Address2.Text = dr.GetValue(dr.GetOrdinal("Address")).ToString();
                    Txt_Fax2.Text = dr.GetValue(dr.GetOrdinal("Fax")).ToString();
                    Txt_Mobile2.Text = dr.GetValue(dr.GetOrdinal("Mobile")).ToString();
                    Txt_Name2.Text = dr.GetValue(dr.GetOrdinal("Name")).ToString();
                    Txt_Phone2.Text = dr.GetValue(dr.GetOrdinal("Phone")).ToString();
                    Txt_P_O_Box2.Text = dr.GetValue(dr.GetOrdinal("P_O_Box")).ToString();
                    string Stamps = dr.GetValue(dr.GetOrdinal("Stamps")).ToString();
                    if (Stamps == "306")
                    {
                        RB_Stamps2.SelectedValue = "1";
                        
                    }
                    else
                    {
                        RB_Stamps2.SelectedValue = "0";
                    }
                    RB_Stamps2.SelectedValue = dr.GetValue(dr.GetOrdinal("Stamps")).ToString();

                    int.TryParse(dr.GetValue(dr.GetOrdinal("Contracting_Type1")).ToString(), out Contracting_Type1);
                    int.TryParse(dr.GetValue(dr.GetOrdinal("Contracting_Type2")).ToString(), out Contracting_Type2);
                    int.TryParse(dr.GetValue(dr.GetOrdinal("Contracting_Type3")).ToString(), out Contracting_Type3);

                    if (Contracting_Type1 == 279)
                    {
                        CBL_Contracting_Type2.Items[0].Selected = true;
                    }

                    if (Contracting_Type2 == 280)
                    {
                        CBL_Contracting_Type2.Items[1].Selected = true;
                    }

                    if (Contracting_Type3 == 281)
                    {
                        CBL_Contracting_Type2.Items[2].Selected = true;
                    }
                    Contract_Date = dr.GetValue(dr.GetOrdinal("Contract_Date")).ToString();
                    Result = DateTime.TryParse(Contract_Date, out Contract_Date2);
                    if (Result)
                    {
                        Txt_Contract_Date2.Text = Contract_Date2.ToString("yyyy-MM-dd");
                    }



                }

                Cls_Connection.close_connection();


            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                Cls_Connection.close_connection();


            }

        }

        protected void DDL_Main_Company_SelectedIndexChanged(object sender, EventArgs e)
        {
            Get_Companies_ForUpdate();
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

        protected void Btn_Delete_Click(object sender, EventArgs e)
        {
            Cls_Medical_Types_And_Companies Medical_Type = new Cls_Medical_Types_And_Companies();
            string Com = DDL_Main_Company.SelectedItem.Text;
            Medical_Type._ID = int.Parse(DDL_Main_Company.SelectedValue);
            string Result;
            Result = Medical_Type.Delete_Companies();
            ////////////////////////////////       Log        /////////////////////////////////////////////
            Cls_Log log = new Cls_Log();
            log._Log_Event = "حذف شركة  : " + Com;
            log.Insert_Log();
            ////////////////////////////////   End Of Log        /////////////////////////////////////////////
            DDL_Main_Company.DataSource = null;
            DDL_Main_Company.DataSource = Cls_Main_Claims.Get_Companies();
            DDL_Main_Company.DataBind();
            DDL_Main_Company.Items.Insert(0, new ListItem("--اختر--", "0"));
            Label5.Text = Result;

            ClearFields(Form.Controls);
        }
    }
}