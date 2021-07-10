/// Yahoo!	smtp.mail.yahoo.com	587	Yes
/// GMail smtp.gmail.com  587	Yes
/// Hotmail smtp.live.com   587	Yes

using BillingSoftware.ClassModels;
using BillingSoftware.ClassServices.Email;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace BillingSoftware.ClassServices.Email
{
    public class EmailManager 
    {
        public EmailManager()
        {

        }

        public static void SendUserActivationMail(NewUserRegister newUserRegister)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("<h4>Welcome to Deyak</h4>");
            stringBuilder.AppendLine(string.Format("<h3>Your account has been activated.  Please login with your User Id:{0}</h3>",newUserRegister.Email));
            Email(stringBuilder.ToString(), newUserRegister.Email);
        }

        private static void Email(string htmlString, string ToEmail)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("kar.mks@gmail.com");
                message.To.Add(new MailAddress(ToEmail));
                message.Subject = "Account Activation Email";
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = htmlString;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("kar.mks@gmail.com", "Mksklt@061984");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception ex) 
            {

            }
        }     
    }
}
