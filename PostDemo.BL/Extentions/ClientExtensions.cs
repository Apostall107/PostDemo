using PostDemo.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostDemo.BL.Extentions {
    public static class ClientExtensions {
        public static void AddCountryCodeToPhoneNumber(this Client client) {
            if (string.IsNullOrEmpty(client.PhoneNumber)) {
                return;
            }

            if (client.PhoneNumber.StartsWith("+")) {
                return;
            }

            switch (client.Country) {
                case "Russia":
                client.PhoneNumber = "+7" + client.PhoneNumber;
                break;
                case "USA":
                client.PhoneNumber = "+1" + client.PhoneNumber;
                break;
                case "Germany":
                client.PhoneNumber = "+49" + client.PhoneNumber;
                break;
                case "Ukraine":
                client.PhoneNumber = "+38" + client.PhoneNumber;
                break;
                default:
                break;
            }
        }

        public static void SetEmptyFieldsToNotSet(this Client client) {
            if (string.IsNullOrEmpty(client.Name))
                client.Name = "Not set";
            if (string.IsNullOrEmpty(client.Email))
                client.Email = "Not set";
            if (string.IsNullOrEmpty(client.PhoneNumber))
                client.PhoneNumber = "Not set";
            if (string.IsNullOrEmpty(client.Country))
                client.Country = "Not set";
            if (string.IsNullOrEmpty(client.Region))
                client.Region = "Not set";
            if (string.IsNullOrEmpty(client.City))
                client.City = "Not set";
            if (string.IsNullOrEmpty(client.Address))
                client.Address = "Not set";
            if (string.IsNullOrEmpty(client.PostalCode))
                client.PostalCode = "Not set";
        }
    }

}
