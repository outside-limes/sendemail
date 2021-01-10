using System;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace emailApi.emailLogic
{
    public class sendemail
    {
        public void SendMail(string fromEmail, string toAddress,
                                    string subject, string body)
        {
            SendMail(new System.Net.Mail.MailAddress(fromEmail), toAddress, subject, body);
        }

        public void SendMail(System.Net.Mail.MailAddress fromAddress, string toAddress,
                                    string subject, string body)
        {
            //Read SMTP Server Name or IP from Config xml file
            //string SmtpServer = "smtp.office365.com";
            string SmtpServer = "smtp.gmail.com";

            //Read User Name from Config xml file
            //i have left out these details on purpose
            string SmtpUserName = "";

            //Read User Password from Config xml file
            string SmtpUserPass = "";

            //Read port setting from Config xml file
            string smtpPort = "587";

            //Domain name           

            

            System.Net.Mail.SmtpClient smtpSend = new System.Net.Mail.SmtpClient(SmtpServer);

            using (System.Net.Mail.MailMessage emailMessage = new System.Net.Mail.MailMessage())
            {
                emailMessage.To.Add(toAddress);


                emailMessage.From = fromAddress;
                emailMessage.Subject = subject;
                emailMessage.Body = body;
                emailMessage.IsBodyHtml = true;               




                if (!Regex.IsMatch(emailMessage.Body, @"^([0-9a-z!@#\$\%\^&\*\(\)\-=_\+])", RegexOptions.IgnoreCase) ||
                        !Regex.IsMatch(emailMessage.Subject, @"^([0-9a-z!@#\$\%\^&\*\(\)\-=_\+])", RegexOptions.IgnoreCase))
                {
                    emailMessage.BodyEncoding = Encoding.Unicode;
                }

                if (SmtpUserName != null && SmtpUserPass != null && smtpPort != null)
                {
                    smtpSend.EnableSsl = true;
                    smtpSend.Port = Convert.ToInt32(smtpPort);
                    smtpSend.Credentials = new System.Net.NetworkCredential(SmtpUserName, SmtpUserPass);
                    smtpSend.UseDefaultCredentials = false;
                }

                smtpSend.Send(emailMessage);
                                
            }
        }

        
    }
}
