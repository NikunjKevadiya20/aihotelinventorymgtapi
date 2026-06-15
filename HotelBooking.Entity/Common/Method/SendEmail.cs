using System.Net.Mail;
using System.Text;
using System.Net.Http.Headers;
using HotelBooking.Entity.Common;



namespace HotelBooking.Entity.Entities
{
   
    public class SendEmail
    {

        #region Send mail
        public string MailSendSMTP(string toMail, string ccMail, string subject, string body, string strTrace)
        {
            try
            {
                string fromEmailAddress = CommonRepositoryConstants.EmailAddress;
                string displayName = CommonRepositoryConstants.EmailDisplayName;
                string smtpIpAddress = CommonRepositoryConstants.SMTPAddress;
                int smtpPort = Convert.ToInt16(CommonRepositoryConstants.SMTPPort);
                string password = CommonRepositoryConstants.EmailPassword;


                MailAddress from = new MailAddress(fromEmailAddress, displayName);
                MailMessage message = new MailMessage();
                SmtpClient client = new SmtpClient(smtpIpAddress, smtpPort);

                message.Subject = subject;
                message.Body = body;
                message.From = from;

                string[] strArrToMail = toMail.Split(';');
                for (int i = 0; i < strArrToMail.Count(); i++)
                    message.To.Add(strArrToMail[i]);

                if (ccMail != "")
                {
                    string[] strArrCCMail = ccMail.Split(';');
                    for (int i = 0; i < strArrCCMail.Count(); i++)
                        message.CC.Add(strArrCCMail[i]);
                }

                if (strTrace.Length > 0)
                {
                    System.Net.Mail.Attachment attachment;
                    attachment = new System.Net.Mail.Attachment(strTrace);
                    message.Attachments.Add(attachment);
                }


                message.BodyEncoding = Encoding.UTF8;
                message.IsBodyHtml = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(fromEmailAddress, password);
                client.EnableSsl = true;  

                client.Send(message);

                return "success";
            }
            catch (System.Exception ex)
            {
                return "SendMail-->MailSendSMTP :: " + ex.Message;
            }
        }
     
        #endregion "Send Mail"
    }
}
