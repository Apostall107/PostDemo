using PostDemo.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostDemo.BL.Extentions {
    public static class PackageExtensions {
        public static void ChangeKilosInLoop(this Package package) {

            var counter = 0;
            for (int i = 1; i <= package.Kilos; i++) {
                counter++;
                counter++;

            }
            if (counter <= 100) {
                package.Kilos = counter;
            }
        }
        public static void SetEmptyFieldsToNotSet(this Package package) {
            if (string.IsNullOrEmpty(package.Title))
                package.Title = "Not set";
            if (string.IsNullOrEmpty(package.Description))
                package.Description = "Not set";
        }
    }
}
