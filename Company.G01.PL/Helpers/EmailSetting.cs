using System.Net;
using System.Net.Mail;

namespace Company.G01.PL.Helpers
{
    public static class EmailSetting
    {
        public static bool SendEmail(Email email)
        {
            //Mail Server: Gmail
            //SMTP
            try
            {
                var client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("aaayaalaa2020@gmail.com", "njekoyvazwsgwxyp");//Sender
                client.Send("aaayaalaa2020@gmail.com", email.To, email.Subject, email.Body);

                return true;
            }
            catch (Exception e)
            { 
                return false;   
            }
        }

    }
}
