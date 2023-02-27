using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PostDemo.DAL.Models.DTOs {
    public class ClientDTO {
        [DisplayName("Client Id:")]
        public int Id { get; set; }
        [DisplayName("Client Name:")]
        public string Name { get; set; }

        [DisplayName("Client Email:")]
        public string Email { get; set; }

        [DisplayName("Client PhoneNumber:")]
        public string PhoneNumber { get; set; }

        [DisplayName("Client Country:")]
        public string Country { get; set; }
        [DisplayName("Client Region:")]
        public string Region { get; set; }
        [DisplayName("Client City:")]
        public string City { get; set; }

        [DisplayName("Client Address:")]
        public string Address { get; set; }

        [DisplayName("Client PostalCode:")]
        public string PostalCode { get; set; }
    }
}
