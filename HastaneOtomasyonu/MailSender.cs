using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace HastaneOtomasyonu
{
    public static class MailSender
    {
        public static void Send(string mail, string message)
        {
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587;
            smtpClient.Credentials = new System.Net.NetworkCredential("odev441@gmail.com", "huwrjhngfwzyrlcd");
            smtpClient.EnableSsl = true;

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("odev441@gmail.com");
            mailMessage.To.Add(mail);
            mailMessage.Subject = "Hastane Otomasyonu";
            mailMessage.Body = message;

            smtpClient.Send(mailMessage);
        }
    }
}
