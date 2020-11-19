using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Elite_system
{
    public partial class Employees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
            Btn_Update.Visible = HttpContext.Current.User.IsInRole("Update");
            Btn_Save.Visible = HttpContext.Current.User.IsInRole("Add");
            if (HttpContext.Current.User.IsInRole("Admin"))
            {
                Btn_Update.Visible = true;
                Btn_Save.Visible = true;
               
            }
            if (!Page.IsPostBack)
            {
                DDL_Employee.DataSource = Cls_Employees.Get_Employee();
                DDL_Employee.DataBind();
                DDL_Employee.SelectedValue = "15";
            }
        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {           
            Cls_Employees Employee = new Cls_Employees();
            string Result;
            Employee._Employee_Name = Txt_Employee_Name.Text;
            Result = Employee.Insert_Employees();
            ////////////////////////////////       Log        /////////////////////////////////////////////
            Cls_Log log = new Cls_Log();
            log._Log_Event = "إضافة موظف جديد  : " + Txt_Employee_Name.Text;
            log.Insert_Log();
            ////////////////////////////////   End Of Log        /////////////////////////////////////////////
            Lbl_Result1.Text = Result;
            DDL_Employee.DataSource = Cls_Employees.Get_Employee();
            DDL_Employee.DataBind();
            DDL_Employee.SelectedValue = "15";

        }

        protected void DDL_Employee_SelectedIndexChanged(object sender, EventArgs e)
        {
            Txt_Employee_Name2.Text = DDL_Employee.SelectedItem.Text;
        }

        protected void Btn_Update_Click(object sender, EventArgs e)
        {
            Cls_Employees Employee = new Cls_Employees();
            string Result;
            Employee._ID = int.Parse(DDL_Employee.SelectedValue.ToString());
            Employee._Employee_Name = Txt_Employee_Name2.Text;
            Result = Employee.Update_Employees();
            ////////////////////////////////       Log        /////////////////////////////////////////////
            Cls_Log log = new Cls_Log();
            log._Log_Event = "تعديل على الموظف   : " + DDL_Employee.SelectedItem.Text;
            log.Insert_Log();
            ////////////////////////////////   End Of Log        /////////////////////////////////////////////
            Lbl_Result2.Text = Result;
            DDL_Employee.DataSource = Cls_Employees.Get_Employee();
            DDL_Employee.DataBind();
            DDL_Employee.SelectedValue = "15";
            Txt_Employee_Name2.Text="";
        }

        protected void Btn_Delete_Click(object sender, EventArgs e)
        {
            Cls_Employees Employee = new Cls_Employees();
            string Result;
            string Emp = DDL_Employee.SelectedItem.Text;
            Employee._ID = int.Parse(DDL_Employee.SelectedValue.ToString());
            Employee._Employee_Name = Txt_Employee_Name2.Text;
            Result = Employee.Delete_Employees();
            ////////////////////////////////       Log        /////////////////////////////////////////////
            Cls_Log log = new Cls_Log();
            log._Log_Event = "حذف الموظف   : " + Emp;
            log.Insert_Log();
            ////////////////////////////////   End Of Log        /////////////////////////////////////////////
            Lbl_Result2.Text = Result;
            DDL_Employee.DataSource = Cls_Employees.Get_Employee();
            DDL_Employee.DataBind();
            DDL_Employee.SelectedValue = "15";
            Txt_Employee_Name2.Text = "";
        }
    }
}