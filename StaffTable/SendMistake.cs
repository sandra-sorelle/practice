using StaffTable.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StaffTable
{
    public class SendMistake
    {
        public void SendMessage(string login, string pass, Exception error)
        {
            
            string ErrorMassage = error.Message;
            string ErroeSet = error.ToString();
            string m1 = "mamokac@mail.ru";
            string m2 = login;
            string m2SubPassword = pass;
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            SmtpClient mySmtpClient = new SmtpClient("smtp.mail.ru");
            mySmtpClient.Port = 587;
            mySmtpClient.UseDefaultCredentials = true;
            mySmtpClient.EnableSsl = true;
            System.Net.NetworkCredential basicAuthenticationInfo = new
            System.Net.NetworkCredential(m2, m2SubPassword);
            mySmtpClient.Credentials = basicAuthenticationInfo;
            MailAddress from = new MailAddress(m2, "Клиент приложения");
            MailAddress to;
            to = new MailAddress(m1, $"Команда разработки");
            MailMessage myMail = new MailMessage(from, to);
            myMail.Body = $"<p>Здравствуйте! </p><p>При работе с вашим приложением произошла ошибка: {ErrorMassage}<br> Полное описание: {ErroeSet}</p>";
            MailAddress replyTo = new MailAddress(m2);
            myMail.ReplyToList.Add(replyTo);
            // set subject and encoding
            myMail.Subject = ErrorMassage;
            myMail.Priority = MailPriority.High;
            myMail.SubjectEncoding = System.Text.Encoding.UTF8;
            myMail.BodyEncoding = Encoding.UTF8;
            // text or html
            myMail.IsBodyHtml = true;
            mySmtpClient.Send(myMail);
            
            MessageBox.Show("Сообщение об ошибке отправлено разработчику.");
        }
    }
}
