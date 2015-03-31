using EmailSender.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace EmailSender.Utils
{
    public class SMTPGmail
    {
        internal Tuple<bool, string> SendEmail(Email email)
        {
            try
            {


                MailAddress oFromAddress = new MailAddress(ReadAppSettings("GmailUser"), "Email From " + email.From);
                MailAddress oToAddress = new MailAddress(email.To, "Email To " + email.To);
                string fromPassword = ReadAppSettings("GmailPassword");
                string subject = email.Subject;
                string body = email.Text;

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(oFromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(oFromAddress, oToAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                    return new Tuple<bool, string>(true, String.Empty);
                }
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, ex.Message);

            }
        }

        private string ReadAppSettings(string key)
        {
            string value = ConfigurationManager.AppSettings[key];
            if (!String.IsNullOrEmpty(value))
            {
                return value;
            }
            else
                throw new Exception("Gmail User or Password not found");
        }
    }
}
