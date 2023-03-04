using PostDemo.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PostDemo.BL.Helpers.PackageHelpers {
    public static class PackageValidator {
        public static bool ValidatePackage(Package package) {
            return IsSenderReceiverValid(package.SenderId, package.ReceiverId);
        }
        public static bool IsSenderReceiverValid(int senderId, int receiverId) {
            return senderId != receiverId;
        }

        public static void VerifyFileName(ref string fileName)
        {
            string invalideChars = "[?:\\/*\"<>|]";
            fileName = Regex.Replace(fileName, invalideChars, "");
        }
    }
}
