using System;
using System.Text;
using System.Web;


namespace Elite_system
{
    public partial class Test2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

        }

        //ForDownLoadContact
        protected void Button2_Click(object sender, EventArgs e)
        {

            //generate the vCard text
            string vCard = BuildvCard();

            //create the filename the user will download the file as
            string filename = HttpUtility.UrlEncode("Contact.vcf", System.Text.Encoding.UTF8);

            //get a reference to the response
            HttpResponse response = HttpContext.Current.Response;

            //clear the response and write our own one.
            response.Clear();
            response.ContentType = "text/x-vcard";
            response.AddHeader("Content-Disposition", "attachment; filename=" + filename + ";");
            response.Write(vCard);
            response.End();


        }
        public string BuildvCard()
        {
            //byte[] Img = File.ReadAllBytes(Server.MapPath("assets/img/Images/ui-zac.jpg"));
            string FName = "RRRR",
                   LName = "OOOO",
                   Address = "Amman",
                   Mobile = "0000000000",
                   Email = "Rami_Roosan07@yahoo.com";
            var strvCardBuilder = new StringBuilder();
            strvCardBuilder.AppendLine("BEGIN:VCARD");
            strvCardBuilder.AppendLine("VERSION:2.1");
            strvCardBuilder.AppendLine("N:" + LName + ";" + FName);
            strvCardBuilder.AppendLine("FN:" + FName + " " + LName);
            strvCardBuilder.Append("ADR;HOME;PREF:;;");
            strvCardBuilder.Append(Address + ";");
            strvCardBuilder.AppendLine("TEL;HOME;VOICE:" + Mobile);
            strvCardBuilder.AppendLine("TEL;CELL;VOICE:" + Mobile);
            strvCardBuilder.AppendLine("EMAIL;PREF;INTERNET:" + Email);
            //strvCardBuilder.AppendLine("PHOTO;ENCODING=BASE64;TYPE=JPEG:");
            //strvCardBuilder.AppendLine(Convert.ToBase64String(Img));
            strvCardBuilder.AppendLine(string.Empty);
            strvCardBuilder.AppendLine(string.Empty);
            strvCardBuilder.AppendLine(string.Empty);
            strvCardBuilder.AppendLine("END:VCARD");
            return strvCardBuilder.ToString();
        }

        //ForDownLoadContact
    }
}