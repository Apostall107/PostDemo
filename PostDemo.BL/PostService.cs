using PostDemo.BL.Helpers;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostDemo.BL
{
    public class PostService
    {
        private EmailService _emailService;
        private SMTPConfig _smtpConfig;

        public PostService(EmailService emailService, SMTPConfig smtp)
        {
            _emailService = emailService;
            _smtpConfig = smtp;
        }

        public void SendEmail(string recepient, string subject, string emailBody, string attachmentName, byte[] attachment)
        {
            if (string.IsNullOrEmpty(recepient))
            {
                throw new Exception("A recepient must be specified");
            }

            if (subject is null)
            {
                subject = string.Empty;
            }
            if (emailBody is null)
            {
                emailBody = string.Empty;
            }

            if (!string.IsNullOrEmpty(attachmentName))
            {
                attachmentName = _emailService.FormatAttachmentName(attachmentName, recepient, DateTime.Now);
            }

            try
            {
                using (var smtp = new SMTP())
                {
                    if (IsSMTPConfigured(true))
                    {
                        smtp.Send();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void SendEmailAsync(string recepient, string subject, string emailBody, string attachmentName, byte[] attachment)
        {
            ThreadPool.QueueUserWorkItem(delegate
            {
                if (attachment is not null)
                {
                    SendEmail(recepient, subject, emailBody, attachmentName, attachment);
                }
                else
                {
                    using (var stream = new MemoryStream(attachment))
                    {
                        SendEmail(recepient, subject, emailBody, attachmentName, attachment);
                    }
                }
            });
        }

        public bool IsSMTPConfigured(bool isConfigured)
        {
            _smtpConfig.IsConfigured = isConfigured; // :)
            return _smtpConfig.IsConfigured;
        }
    }
}
