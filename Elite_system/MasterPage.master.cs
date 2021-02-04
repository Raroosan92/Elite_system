using Elite_system;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
public partial class MasterPage : System.Web.UI.MasterPage
{


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            #region Elements
            HtmlControl claim = (HtmlControl)Page.Master.FindControl("Claims");
            claim.Attributes.Add("style", "display:none");

            HtmlControl Medical_Types = (HtmlControl)Page.Master.FindControl("Medical_Types");
            Medical_Types.Attributes.Add("style", "display:none");

            HtmlControl Mail = (HtmlControl)Page.Master.FindControl("Mail");
            Mail.Attributes.Add("style", "display:none");

            HtmlControl Employees = (HtmlControl)Page.Master.FindControl("Employees");
            Employees.Attributes.Add("style", "display:none");

            HtmlControl Receipt = (HtmlControl)Page.Master.FindControl("Receipt");
            Receipt.Attributes.Add("style", "display:none");

            HtmlControl RegisterUser = (HtmlControl)Page.Master.FindControl("RegisterUser");
            RegisterUser.Attributes.Add("style", "display:none");

            HtmlControl Checks = (HtmlControl)Page.Master.FindControl("Checks");
            Checks.Attributes.Add("style", "display:none");

            HtmlControl AssignCheck = (HtmlControl)Page.Master.FindControl("AssignCheck");
            AssignCheck.Attributes.Add("style", "display:none");

            HtmlControl DeliveredChecks = (HtmlControl)Page.Master.FindControl("DeliveredChecks");
            DeliveredChecks.Attributes.Add("style", "display:none");

            HtmlControl RefundedCheckes = (HtmlControl)Page.Master.FindControl("RefundedCheckes");
            RefundedCheckes.Attributes.Add("style", "display:none");

            HtmlControl Accounting_Tree = (HtmlControl)Page.Master.FindControl("Accounting_Tree");
            Accounting_Tree.Attributes.Add("style", "display:none");

            HtmlControl Accounting_Tree_Details = (HtmlControl)Page.Master.FindControl("Accounting_Tree_Details");
            Accounting_Tree_Details.Attributes.Add("style", "display:none");

            HtmlControl Main_Banks = (HtmlControl)Page.Master.FindControl("Main_Banks");
            Main_Banks.Attributes.Add("style", "display:none");

            HtmlControl Sub_Banks = (HtmlControl)Page.Master.FindControl("Sub_Banks");
            Sub_Banks.Attributes.Add("style", "display:none");

            HtmlControl Sub_Companies = (HtmlControl)Page.Master.FindControl("Sub_Companies");
            Sub_Companies.Attributes.Add("style", "display:none");

            HtmlControl Codes = (HtmlControl)Page.Master.FindControl("Codes");
            Codes.Attributes.Add("style", "display:none");

            HtmlControl Procedures = (HtmlControl)Page.Master.FindControl("Procedures");
            Procedures.Attributes.Add("style", "display:none");

            HtmlControl Medical_Types_Check = (HtmlControl)Page.Master.FindControl("Medical_Types_Check");
            Medical_Types_Check.Attributes.Add("style", "display:none");

            HtmlControl Rpt_Checks2 = (HtmlControl)Page.Master.FindControl("Rpt_Checks2");
            Rpt_Checks2.Attributes.Add("style", "display:none");

            HtmlControl Rpt_Claims2 = (HtmlControl)Page.Master.FindControl("Rpt_Claims2");
            Rpt_Claims2.Attributes.Add("style", "display:none");

            HtmlControl Rpt_Claims = (HtmlControl)Page.Master.FindControl("Rpt_Claims");
            Rpt_Claims.Attributes.Add("style", "display:none");

            HtmlControl Rpt_Claims3 = (HtmlControl)Page.Master.FindControl("Rpt_Claims3");
            Rpt_Claims3.Attributes.Add("style", "display:none");

            HtmlControl Rpt_Checks = (HtmlControl)Page.Master.FindControl("Rpt_Checks");
            Rpt_Checks.Attributes.Add("style", "display:none");

            HtmlControl Rpt_Checks3 = (HtmlControl)Page.Master.FindControl("Rpt_Checks3");
            Rpt_Checks3.Attributes.Add("style", "display:none");

            HtmlControl Rpt_Mails = (HtmlControl)Page.Master.FindControl("Rpt_Mails");
            Rpt_Mails.Attributes.Add("style", "display:none");

            HtmlControl Rpt_Account = (HtmlControl)Page.Master.FindControl("Rpt_Account");
            Rpt_Account.Attributes.Add("style", "display:none");

            HtmlControl Rpt_Listing1 = (HtmlControl)Page.Master.FindControl("Rpt_Listing1");
            Rpt_Listing1.Attributes.Add("style", "display:none");

            HtmlControl Rep_Log = (HtmlControl)Page.Master.FindControl("Rep_Log");
            Rep_Log.Attributes.Add("style", "display:none");

            HtmlControl Companies = (HtmlControl)Page.Master.FindControl("Companies");
            Companies.Attributes.Add("style", "display:none");

            HtmlControl AllSettings = (HtmlControl)Page.Master.FindControl("AllSettings");
            AllSettings.Attributes.Add("style", "display:none");

            HtmlControl AllReports = (HtmlControl)Page.Master.FindControl("AllReports");
            AllReports.Attributes.Add("style", "display:none");

            HtmlControl AllChecks = (HtmlControl)Page.Master.FindControl("AllChecks");
            AllChecks.Attributes.Add("style", "display:none");

            HtmlControl AllAccounting = (HtmlControl)Page.Master.FindControl("AllAccounting");
            AllAccounting.Attributes.Add("style", "display:none");
            //**
            HtmlControl Rpt_GetContractingValue = (HtmlControl)Page.Master.FindControl("Rpt_GetContractingValue");
            Rpt_GetContractingValue.Attributes.Add("style", "display:none");
            //**
            HtmlControl Rpt_Stamps = (HtmlControl)Page.Master.FindControl("Rpt_Stamps");
            Rpt_Stamps.Attributes.Add("style", "display:none");
            //**
            HtmlControl Rpt_MedicalTypesWithNoClaims = (HtmlControl)Page.Master.FindControl("Rpt_MedicalTypesWithNoClaims");
            Rpt_MedicalTypesWithNoClaims.Attributes.Add("style", "display:none");


            HtmlControl Rpt_Claims4 = (HtmlControl)Page.Master.FindControl("Rpt_Claims4");
            Rpt_Claims3.Attributes.Add("style", "display:none");

            HtmlControl PaymentOfClaim = (HtmlControl)Page.Master.FindControl("PaymentOfClaim");
            PaymentOfClaim.Attributes.Add("style", "display:none");

            HtmlControl Rpt_Medical_Name_Main_Company = (HtmlControl)Page.Master.FindControl("Rpt_Medical_Name_Main_Company");
            PaymentOfClaim.Attributes.Add("style", "display:none");

            HtmlControl CompletionRate = (HtmlControl)Page.Master.FindControl("CompletionRate");
            PaymentOfClaim.Attributes.Add("style", "display:none");

            HtmlControl Claims_Report_Company = (HtmlControl)Page.Master.FindControl("Claims_Report_Company ");
            PaymentOfClaim.Attributes.Add("style", "display:none");
            #endregion

            if (Request.Cookies["UserName"] != null)
            {

            }
            else
            {
                FormsAuthentication.RedirectToLoginPage();

            }



            if (!HttpContext.Current.User.IsInRole("Admin"))
            {
                if (HttpContext.Current.User.IsInRole("Claims"))
                {
                    claim.Attributes.Add("style", "display:Block");
                }

                if (HttpContext.Current.User.IsInRole("Medical_Types"))
                {
                    Medical_Types.Attributes.Add("style", "display:Block");
                }

                if (HttpContext.Current.User.IsInRole("Companies"))
                {
                    Companies.Attributes.Add("style", "display:Block");
                }

                if (HttpContext.Current.User.IsInRole("Mail"))
                {
                    Mail.Attributes.Add("style", "display:Block");
                }

                if (HttpContext.Current.User.IsInRole("Employees"))
                {
                    Employees.Attributes.Add("style", "display:Block");
                }

                if (HttpContext.Current.User.IsInRole("Receipt"))
                {
                    Receipt.Attributes.Add("style", "display:Block");
                }

                if (HttpContext.Current.User.IsInRole("RegisterUser"))
                {
                    RegisterUser.Attributes.Add("style", "display:Block");
                }

                if (HttpContext.Current.User.IsInRole("Enter_Checks"))
                {
                    AllChecks.Attributes.Add("style", "display:Block");
                    Checks.Attributes.Add("style", "display:Block");
                }

                if (HttpContext.Current.User.IsInRole("AssignCheck"))
                {
                    AssignCheck.Attributes.Add("style", "display:Block");
                }

                if (HttpContext.Current.User.IsInRole("DeliveredChecks"))
                {
                    AllChecks.Attributes.Add("style", "display:Block");
                    DeliveredChecks.Attributes.Add("style", "display:Block");
                }

                if (HttpContext.Current.User.IsInRole("RefundedCheckes"))
                {
                    AllChecks.Attributes.Add("style", "display:Block");
                    RefundedCheckes.Attributes.Add("style", "display:Block");
                }

                if (HttpContext.Current.User.IsInRole("RefundedCheckes"))
                {
                    AllChecks.Attributes.Add("style", "display:Block");
                    RefundedCheckes.Attributes.Add("style", "display:Block");
                }

                if (HttpContext.Current.User.IsInRole("Accounting_Tree_Details"))
                {
                    AllAccounting.Attributes.Add("style", "display:Block");
                    Accounting_Tree_Details.Attributes.Add("style", "display:Block");
                }

                if (HttpContext.Current.User.IsInRole("Accounting_Tree"))
                {
                    AllAccounting.Attributes.Add("style", "display:Block");
                    Accounting_Tree.Attributes.Add("style", "display:Block");
                }

                if (HttpContext.Current.User.IsInRole("Main_Banks"))
                {
                    AllSettings.Attributes.Add("style", "display:Block");
                    Main_Banks.Attributes.Add("style", "display:Block");
                }

                if (HttpContext.Current.User.IsInRole("Sub_Banks"))
                {
                    AllSettings.Attributes.Add("style", "display:Block");
                    Sub_Banks.Attributes.Add("style", "display:Block");
                }

                if (HttpContext.Current.User.IsInRole("Sub_Companies"))
                {
                    AllSettings.Attributes.Add("style", "display:Block");
                    Sub_Companies.Attributes.Add("style", "display:Block");
                }

                if (HttpContext.Current.User.IsInRole("Codes"))
                {
                    AllSettings.Attributes.Add("style", "display:Block");
                    Codes.Attributes.Add("style", "display:Block");
                }

                if (HttpContext.Current.User.IsInRole("Procedures"))
                {
                    AllSettings.Attributes.Add("style", "display:Block");
                    Procedures.Attributes.Add("style", "display:Block");
                }

                if (HttpContext.Current.User.IsInRole("Medical_Types_Check"))
                {
                    AllSettings.Attributes.Add("style", "display:Block");
                    Medical_Types_Check.Attributes.Add("style", "display:Block");
                }

                if (HttpContext.Current.User.IsInRole("Checks_Report_Contract"))
                {
                    AllReports.Attributes.Add("style", "display:Block");
                    Rpt_Checks2.Attributes.Add("style", "display:Block");
                }

                if (HttpContext.Current.User.IsInRole("Claims_Report_Medical"))
                {
                    AllReports.Attributes.Add("style", "display:Block");
                    Rpt_Claims2.Attributes.Add("style", "display:Block");
                }

                if (HttpContext.Current.User.IsInRole("Claims_Report_Company"))
                {
                    AllReports.Attributes.Add("style", "display:Block");
                    Rpt_Claims.Attributes.Add("style", "display:Block");
                }

                if (HttpContext.Current.User.IsInRole("Claims_Checking"))
                {
                    AllReports.Attributes.Add("style", "display:Block");
                    Rpt_Claims3.Attributes.Add("style", "display:Block");
                }

                if (HttpContext.Current.User.IsInRole("Checks_Report"))
                {
                    AllReports.Attributes.Add("style", "display:Block");
                    Rpt_Checks.Attributes.Add("style", "display:Block");
                }

                if (HttpContext.Current.User.IsInRole("All_Checks_Report"))
                {
                    AllReports.Attributes.Add("style", "display:Block");
                    Rpt_Checks3.Attributes.Add("style", "display:Block");
                }

                if (HttpContext.Current.User.IsInRole("Mails_Report"))
                {
                    AllReports.Attributes.Add("style", "display:Block");
                    Rpt_Mails.Attributes.Add("style", "display:Block");
                }

                if (HttpContext.Current.User.IsInRole("Account_Report"))
                {
                    AllReports.Attributes.Add("style", "display:Block");
                    Rpt_Account.Attributes.Add("style", "display:Block");
                }

                if (HttpContext.Current.User.IsInRole("Bond_Report"))
                {
                    AllReports.Attributes.Add("style", "display:Block");
                    Rpt_Listing1.Attributes.Add("style", "display:Block");
                }

                if (HttpContext.Current.User.IsInRole("Rep_Log"))
                {
                    AllReports.Attributes.Add("style", "display:Block");
                    Rep_Log.Attributes.Add("style", "display:Block");
                }

                if (HttpContext.Current.User.IsInRole("Rpt_GetContractingValue"))
                {
                    AllReports.Attributes.Add("style", "display:Block");
                    Rpt_GetContractingValue.Attributes.Add("style", "display:Block");
                }

                if (HttpContext.Current.User.IsInRole("Rpt_Stamps"))
                {
                    AllReports.Attributes.Add("style", "display:Block");
                    Rpt_Stamps.Attributes.Add("style", "display:Block");
                }

                if (HttpContext.Current.User.IsInRole("Rpt_MedicalTypesWithNoClaims"))
                {
                    AllReports.Attributes.Add("style", "display:Block");
                    Rpt_MedicalTypesWithNoClaims.Attributes.Add("style", "display:Block");
                }
                if (HttpContext.Current.User.IsInRole("Payment_Of_Claims"))
                {
                    PaymentOfClaim.Attributes.Add("style", "display:Block");
                }

                if (HttpContext.Current.User.IsInRole("Claims_Report_Company "))
                {
                    Claims_Report_Company.Attributes.Add("style", "display:Block");
                }

                if (HttpContext.Current.User.IsInRole("CompletionRate"))
                {
                    CompletionRate.Attributes.Add("style", "display:Block");
                }

                if (HttpContext.Current.User.IsInRole("Rpt_Medical_Name_Main_Company"))
                {
                    Rpt_Medical_Name_Main_Company.Attributes.Add("style", "display:Block");
                }
            }
            else
            {
                Claims_Report_Company.Attributes.Add("style", "display:Block");
                CompletionRate.Attributes.Add("style", "display:Block");
                Rpt_Medical_Name_Main_Company.Attributes.Add("style", "display:Block");
                PaymentOfClaim.Attributes.Add("style", "display:Block");
                claim.Attributes.Add("style", "display:Block");
                Medical_Types.Attributes.Add("style", "display:Block");
                Mail.Attributes.Add("style", "display:Block");
                Employees.Attributes.Add("style", "display:Block");
                Receipt.Attributes.Add("style", "display:Block");
                RegisterUser.Attributes.Add("style", "display:Block");
                Checks.Attributes.Add("style", "display:Block");
                AssignCheck.Attributes.Add("style", "display:Block");
                DeliveredChecks.Attributes.Add("style", "display:Block");
                RefundedCheckes.Attributes.Add("style", "display:Block");
                Accounting_Tree.Attributes.Add("style", "display:Block");
                Accounting_Tree_Details.Attributes.Add("style", "display:Block");
                Main_Banks.Attributes.Add("style", "display:Block");
                Sub_Banks.Attributes.Add("style", "display:Block");
                Sub_Companies.Attributes.Add("style", "display:Block");
                Codes.Attributes.Add("style", "display:Block");
                Procedures.Attributes.Add("style", "display:Block");
                Medical_Types_Check.Attributes.Add("style", "display:Block");
                Rpt_Checks2.Attributes.Add("style", "display:Block");
                Rpt_Claims2.Attributes.Add("style", "display:Block");
                Rpt_Claims.Attributes.Add("style", "display:Block");
                Rpt_Claims3.Attributes.Add("style", "display:Block");
                Rpt_Checks.Attributes.Add("style", "display:Block");
                Rpt_Checks3.Attributes.Add("style", "display:Block");
                Rpt_Mails.Attributes.Add("style", "display:Block");
                Rpt_Account.Attributes.Add("style", "display:Block");
                Rpt_Listing1.Attributes.Add("style", "display:Block");
                Rep_Log.Attributes.Add("style", "display:Block");
                Companies.Attributes.Add("style", "display:Block");
                AllSettings.Attributes.Add("style", "display:Block");
                AllReports.Attributes.Add("style", "display:Block");
                AllChecks.Attributes.Add("style", "display:Block");
                AllAccounting.Attributes.Add("style", "display:Block");
                Rpt_GetContractingValue.Attributes.Add("style", "display:Block");
                Rpt_Stamps.Attributes.Add("style", "display:Block");
                Rpt_MedicalTypesWithNoClaims.Attributes.Add("style", "display:Block");
            }
        }

    }

}
