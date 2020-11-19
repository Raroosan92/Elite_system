using Elite_system.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Elite_system
{
    public partial class Procedures : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DDL_Specialization.DataSource = Cls_Codes.Fill_DDL(2);
                DDL_Specialization.DataBind();
                DDL_Specialization.Items.Insert(0, new ListItem("--اختر--", "0"));

                DDL_Specialization2.DataSource = Cls_Codes.Fill_DDL(2);
                DDL_Specialization2.DataBind();
                DDL_Specialization2.Items.Insert(0, new ListItem("--اختر--", "0"));

                
            }
        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            if (DDL_Specialization.SelectedValue == "0")
            {
                Lbl_Result1.Text = "يرجى إختيار التخصص";
                return;
            }

            if (Txt_ProcedureDesc.Text == "")
            {
                Lbl_Result1.Text = "يرجى ادخال الإجراء";
                return;

            }

            Cls_Procedures Procedure = new Cls_Procedures();
            try
            {

                Procedure._Points = decimal.Parse(Txt_Points.Text);

            }
            catch (Exception)
            {
                Lbl_Result1.Text = "يرجى ادخال النقاط بشكل صحيح";
                return;
            }

            
            string Result;
                                                       
            Procedure._Specialization = int.Parse(DDL_Specialization.SelectedValue);
            Procedure._ProcedureDesc = Txt_ProcedureDesc.Text;
            Result = Procedure.Insert_Procedure();
            ////////////////////////////////       Log        /////////////////////////////////////////////
            Cls_Log log = new Cls_Log();
            log._Log_Event = "إضافة على الإجراءات : " +Txt_ProcedureDesc.Text ;
            log.Insert_Log();
            ////////////////////////////////   End Of Log        /////////////////////////////////////////////
            Lbl_Result1.Text = Result;

            Txt_ProcedureDesc.Text = "";
            Txt_Points.Text = "";

            DataTable dt = new DataTable();
            dt = Cls_Procedures.Get_Procedures(int.Parse(DDL_Specialization.SelectedValue));
            GV.DataSource = dt;
            GV.DataBind();
            Lbl_Specialization.Text = DDL_Specialization.SelectedItem.Text;
        }
        protected void Btn_Delete_Click(object sender, EventArgs e)
        {
            if (DDL_ProcedureDesc.SelectedValue == "0")
            {
                Lbl_Result2.Text = "يرجى إختيار الإجراء";
                return;
            }

            Cls_Procedures Procedure = new Cls_Procedures();

            Procedure._ID = int.Parse(DDL_ProcedureDesc.SelectedValue);
            string Result;
            Result = Procedure.Delete_Procedure();

            Txt_ProcedureDesc2.Text = "";
            Txt_Points2.Text = "";
            DDL_ProcedureDesc.DataSource = Cls_Procedures.Get_Procedures(int.Parse(DDL_Specialization2.SelectedValue));
            DDL_ProcedureDesc.DataBind();
            DDL_ProcedureDesc.Items.Insert(0, new ListItem("--اختر--", "0"));

            ////////////////////////////////       Log        /////////////////////////////////////////////
            Cls_Log log = new Cls_Log();
            log._Log_Event = "حذف الإجراء : " + DDL_ProcedureDesc.SelectedItem.Text;
            log.Insert_Log();
            ////////////////////////////////   End Of Log        /////////////////////////////////////////////
            Lbl_Result2.Text = Result;

            DDL_ProcedureDesc.SelectedValue = "0";
            Txt_ProcedureDesc2.Text = "";
            Txt_Points2.Text = "";

            DataTable dt = new DataTable();
            dt = Cls_Procedures.Get_Procedures(int.Parse(DDL_Specialization2.SelectedValue));
            GV.DataSource = dt;
            GV.DataBind();
            Lbl_Specialization.Text = DDL_Specialization2.SelectedItem.Text;
        }

        protected void Btn_Update_Click(object sender, EventArgs e)
        {
            if (DDL_Specialization2.SelectedValue == "0")
            {
                Lbl_Result2.Text = "يرجى إختيار التخصص";
                return;
            }

            if (DDL_ProcedureDesc.SelectedValue == "0")
            {
                Lbl_Result2.Text = "يرجى إختيار الإجراء";
                return;
            }

            if (Txt_ProcedureDesc2.Text == "")
            {
                Lbl_Result2.Text = "يرجى ادخال الإجراء";
                return;

            }

            Cls_Procedures Procedure = new Cls_Procedures();
            try
            {

                Procedure._Points = decimal.Parse(Txt_Points2.Text);

            }
            catch (Exception)
            {
                Lbl_Result2.Text = "يرجى ادخال النقاط بشكل صحيح";
                return;
            }


            string Result;

            Procedure._ID =int.Parse( DDL_ProcedureDesc.SelectedValue);
            Procedure._Specialization = int.Parse(DDL_Specialization2.SelectedValue);
            Procedure._ProcedureDesc = Txt_ProcedureDesc2.Text;
            Result = Procedure.Update_Procedure();
            ////////////////////////////////       Log        /////////////////////////////////////////////
            Cls_Log log = new Cls_Log();
            log._Log_Event = "تعديل على الإجراء : " + DDL_ProcedureDesc.SelectedItem.Text;
            log.Insert_Log();
            ////////////////////////////////   End Of Log        /////////////////////////////////////////////
            Lbl_Result2.Text = Result;

            DDL_ProcedureDesc.SelectedValue = "0";
            Txt_ProcedureDesc2.Text = "";
            Txt_Points2.Text = "";

            DataTable dt = new DataTable();
            dt = Cls_Procedures.Get_Procedures(int.Parse(DDL_Specialization2.SelectedValue));           
            GV.DataSource = dt;
            GV.DataBind();

            Lbl_Specialization.Text = DDL_Specialization2.SelectedItem.Text;
        }

        protected void DDL_Specialization2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt= Cls_Procedures.Get_Procedures(int.Parse(DDL_Specialization2.SelectedValue));
            DDL_ProcedureDesc.DataSource = dt;
            DDL_ProcedureDesc.DataBind();
            DDL_ProcedureDesc.Items.Insert(0, new ListItem("--اختر--", "0"));

            GV.DataSource = dt;
            GV.DataBind();

            Lbl_Specialization.Text = DDL_Specialization2.SelectedItem.Text;
        }

        protected void DDL_Specialization_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = Cls_Procedures.Get_Procedures(int.Parse(DDL_Specialization.SelectedValue));          
            GV.DataSource = dt;
            GV.DataBind();
            Lbl_Specialization.Text = DDL_Specialization.SelectedItem.Text;
        }

        protected void DDL_ProcedureDesc_SelectedIndexChanged(object sender, EventArgs e)
        {
            Txt_ProcedureDesc2.Text = DDL_ProcedureDesc.SelectedItem.Text;
        }
    }
}