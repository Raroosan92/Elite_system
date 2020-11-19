using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Providers.Entities;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Elite_system
{
    public partial class Accounting_Tree : System.Web.UI.Page
    {
        public void MSG(string Text)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>alert('" + Text + "')</script>", false);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Btn_Update.Visible = HttpContext.Current.User.IsInRole("Update");
            Btn_Delete.Visible = HttpContext.Current.User.IsInRole("Delete");
            Btn_Save.Visible = HttpContext.Current.User.IsInRole("Add");

            if (HttpContext.Current.User.IsInRole("Admin"))
            {
                Btn_Update.Visible = true;
                Btn_Save.Visible = true;
                Btn_Delete.Visible = true;
            }
            //if (!Page.IsPostBack)
            //{
                Tree_Load();
            //}

        }
        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            Create_Nodes();
            Tree_Load();
        }
        protected void Btn_Update_Click(object sender, EventArgs e)
        {
            Update_Nodes();
            Tree_Load();
        }
        protected void Btn_Delete_Click(object sender, EventArgs e)
        {
            
            Delete_Nodes();
            Tree_Load();
        }
        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {
            Session ["TreeNode_Value"] = TreeView1.SelectedValue;
        }


        protected void Tree_Load()
        {
            TreeView1.Nodes.Add(new TreeNode("0"));
            TreeNode currentNode = TreeView1.Nodes[0];
            for (int i = 0; i < 2; i++)
            {
                currentNode.ChildNodes.Add(new TreeNode(i.ToString()));
                currentNode = currentNode.ChildNodes[0];
            }


            DataSet ds1 = new DataSet();
            DataTable dt1 = new DataTable();
            ds1 = loadalllist();
            dt1 = ds1.Tables[0];
            TreeView1.Nodes.Clear();

            foreach (DataRow item in dt1.Rows)
            {

                TreeNode tn = new TreeNode();
                tn.Text = item[1].ToString();
                tn.Value = item[0].ToString();
                string p = item[2].ToString();

                if (item[2].ToString() == "0")
                {
                    TreeView1.Nodes.Add(tn);
                    TreeView1.Nodes.IndexOf(tn);
                }
                else
                {
                    rec(tn.Text, item[2].ToString(), tn.Value, TreeView1);
                }
            }

            TreeView1.ExpandAll();
        }
        public void Update_Nodes()
        {
            if (Txt_AddFileName.Text != "")
            {
                Cls_Accounting_Tree Account = new Cls_Accounting_Tree();
                //Account._ID = int.Parse(TreeView1.SelectedValue.ToString());
                Account._ID = int.Parse(Session["TreeNode_Value"].ToString());
                Account._Description = Txt_AddFileName.Text;
                string Result = Account.Update_Account();
                ////////////////////////////////       Log        /////////////////////////////////////////////
                Cls_Log log = new Cls_Log();
                log._Log_Event = " تعديل على الشجرة المحاسبية على الحساب : " + Session["TreeNode_Value"].ToString() + " تغير الى " + Txt_AddFileName.Text;
                log.Insert_Log();
                ////////////////////////////////   End Of Log        /////////////////////////////////////////////
                MSG("تم التعديل بنجاح");
            }
            else
            {
                MSG("يجب كتابة اسم الحساب");
            }

        }
        public void Delete_Nodes()
        {
            if (GetChiledNode() ==0)
            {
            Cls_Accounting_Tree Account = new Cls_Accounting_Tree();
            Account._ID = int.Parse(Session["TreeNode_Value"].ToString());
            string Result = Account.Delete_Account();

            ////////////////////////////////       Log        /////////////////////////////////////////////
            Cls_Log log = new Cls_Log();
            log._Log_Event = " حذف  من الشجرة المحاسبية الحساب : " + Session["TreeNode_Value"].ToString();
            log.Insert_Log();
                ////////////////////////////////   End Of Log        /////////////////////////////////////////////
                MSG("تم الحذف بنجاح");
            }
            else
            {
                MSG("هذا الحساب مرتبط به اكثر من حساب فرعي");
            }
        }
        public void Create_Nodes()
        {
            if (Txt_AddFileName.Text !="")
            {
                if (Ch_MainAccount.Checked == true)
                {
                    Session["TreeNode_Value"] = 0;
                }
                Cls_Accounting_Tree Account = new Cls_Accounting_Tree();
                string Result;
                Account._Description = Txt_AddFileName.Text;
                Account._Parent = int.Parse(Session["TreeNode_Value"].ToString());
                Result = Account.Insert_Account();
                ////////////////////////////////       Log        /////////////////////////////////////////////
                Cls_Log log = new Cls_Log();
                log._Log_Event = " إضافة على الشجرة المحاسبية على : " + Txt_AddFileName.Text;
                log.Insert_Log();
                ////////////////////////////////   End Of Log        /////////////////////////////////////////////
                Ch_MainAccount.Checked = false;
                MSG("تم الاضافة بنجاح");
            }
            else
            {
                MSG("يجب كتابة اسم الحساب");
            }
        }
        public DataSet loadalllist()
        {

            string c = ConfigurationManager.ConnectionStrings["CONN"].ConnectionString.ToString();
            SqlConnection con = new SqlConnection(c);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "load_list";
            cmd.Connection = con;

            da.Fill(ds);
            con.Close();
            return ds;
        }

        public int GetChiledNode()
        {
            string c = ConfigurationManager.ConnectionStrings["CONN"].ConnectionString.ToString();
            SqlConnection con = new SqlConnection(c);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select count(id) from Accounting_Tree where parent = "+ Session["TreeNode_Value"] + "";
            cmd.Connection = con;
            int xx = int.Parse(cmd.ExecuteScalar().ToString());
            con.Close();
            return xx;
        }
        protected void rec(string NameChild, string NoPerant, string NoChild, TreeView TreeName, TreeNode node = null)
        {

            Boolean bol = false;
            if (node == null)
            {
                TreeNode childtn = new TreeNode();
                foreach (TreeNode item in TreeName.Nodes)
                {
                    if (item.Value == NoPerant)
                    {
                        childtn.Text = NameChild;
                        childtn.Value = NoChild;
                        item.ChildNodes.Add(childtn);
                        bol = true;
                    }
                    else
                    {
                        if (item.ChildNodes.Count > 0)
                        {
                            rec(NameChild, NoPerant, NoChild, TreeView1, item);
                        }
                    }
                }

            }
            else
            {
                TreeNode childtn = new TreeNode();
                foreach (TreeNode item in node.ChildNodes)
                {
                    if (item.Value == NoPerant)
                    {
                        childtn.Text = NameChild;
                        childtn.Value = NoChild;
                        item.ChildNodes.Add(childtn);
                        bol = true;
                    }
                    else
                    {
                        if (item.ChildNodes.Count > 0)
                        {
                            rec(NameChild, NoPerant, NoChild, TreeView1, item);
                        }
                    }
                }
            }

        }

        public void fill_CBL_Tmp(string xmlfile)
        {
            
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(Server.MapPath(xmlfile));
            XmlNodeList nlist = xmldoc.SelectNodes("/template/Temp");
            //foreach (XmlNode xn in nlist)
            //{
            //    string id = xn["id"].InnerText;
            //    string desc = xn["Name"].InnerText;
            //    if (id == TreeView1.SelectedValue)
            //    {

            //        foreach (ListItem item in RBL_TmpFOLDER.Items)
            //        {

            //            if (item.Value == desc)
            //            {
            //                item.Selected = true;
            //            }
            //            else
            //            {
            //                item.Selected = false;
            //            }

            //        }
            //    }
            //}
           
        }
    }
}