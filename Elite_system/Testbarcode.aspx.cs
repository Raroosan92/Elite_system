using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Elite_system
{
    public partial class Testbarcode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bmpBarcode = new Bitmap(barcodeWidth, barcodeHeight);
            bmpBarcode.SetResolution(100, 100);

        }
        private Int32 barcodeHeight = 100, barcodeWidth = 600;
        private Bitmap bmpBarcode;

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (StringToConvertTextBox.Text == "") return;
            // draw the barcode and text to the bitmap
            clsBarCode barcodeGenerator = new clsBarCode();
            String barcodeReadyData = barcodeGenerator.Code128(StringToConvertTextBox.Text, false);
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
                        dc.DrawString(StringToConvertTextBox.Text, readableFont, drawBrush, new RectangleF(0, 30, barcodeWidth, barcodeHeight));
                    }
                }
            }
            //string barCode = StringToConvertTextBox.Text;
            byte[] byteImage;
            System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
            //Bitmap bitMap = new Bitmap(barCode.Length * 20, 80);
            using (MemoryStream ms = new MemoryStream())
            {

                bmpBarcode.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                byteImage = ms.ToArray();

                Convert.ToBase64String(byteImage);
                imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);

            }
            BarcodePictureBox.Controls.Add(imgBarCode);
            


        }
    }
}