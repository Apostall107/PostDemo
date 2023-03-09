using PostDemo.BL.Helpers.PackageHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostDemo.BL
{
    public class EmailService : IEmailService {
        public string FormatAttachmentName(string attachmentName, string receiverName, DateTime? date) {
            attachmentName = attachmentName.Replace("\\", "-").Replace("/", "-").Replace("\"", "\'");

            if (!string.IsNullOrEmpty(receiverName)) {
                receiverName = receiverName.Replace("\\", "-").Replace("/", "-").Replace("\"", "\'");
                receiverName = receiverName.Length > 0 ? receiverName + "_" : receiverName;
            }

            string dateString = date.HasValue ? date.Value.ToString("ddMMyyyy") : DateTime.Now.ToString("ddMMyyyy");
            dateString += "_" + (Environment.TickCount % 1000).ToString("000");

            string fullName = receiverName + attachmentName + "_" + dateString;
            PackageValidator.VerifyFileName(ref fullName);

            return fullName;
        }
    }
}
