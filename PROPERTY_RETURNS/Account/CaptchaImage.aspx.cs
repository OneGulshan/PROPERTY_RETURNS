using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROPERTY_RETURNS.Account
{
    public partial class CaptchaImage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Generate a captcha code if not already in session
            //if (Session["CaptchaCode"] == null)
            //    Session["CaptchaCode"] = GenerateRandomCode();

            //string captchaCode = Session["CaptchaCode"].ToString();

            //using (Bitmap bmp = new Bitmap(130, 40))
            //using (Graphics g = Graphics.FromImage(bmp))
            //{
            //    g.Clear(Color.White);
            //    using (Font font = new Font("Arial", 20, FontStyle.Bold))
            //    {
            //        g.DrawString(captchaCode, font, Brushes.Black, new PointF(10, 5));
            //    }

            //    Response.Clear();
            //    Response.ContentType = "image/png";
            //    bmp.Save(Response.OutputStream, ImageFormat.Png);
            //    Response.End();
            //}
            string captchaText = GenerateRandomCode();
            Session["CaptchaCode"] = captchaText;
            Bitmap bitmap = new Bitmap(130, 50);
            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);

            Random rnd = new Random();
            // Set font and position
            Font font = new Font("Arial", 20, FontStyle.Bold);
            PointF position = new PointF(10, 10);

            // Measure the size of the text
            SizeF textSize = g.MeasureString(captchaText, font);

            // Draw background rectangle
            g.FillRectangle(Brushes.LightGoldenrodYellow, position.X, position.Y, textSize.Width, textSize.Height);

            g.DrawString(captchaText, font, Brushes.Green, position);

            // Add random lines for noise
            for (int i = 0; i < 35; i++)
            {
                Pen pen = new Pen(Color.Gray);
                g.DrawLine(pen, rnd.Next(0, 120), rnd.Next(0, 50), rnd.Next(0, 120), rnd.Next(0, 50));
            }

            bitmap.Save(Response.OutputStream, ImageFormat.Png);
            bitmap.Dispose();
        }

        private string GenerateRandomCode()
        {
            var chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            var rand = new Random();
            var code = new char[5];

            for (int i = 0; i < code.Length; i++)
            {
                code[i] = chars[rand.Next(chars.Length)];
            }

            return new string(code);
        }
        private string GenerateRandomText(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                                        .Select(s => s[random.Next(s.Length)])
                                        .ToArray());
        }
    }
}