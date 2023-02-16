using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PostDemo.DAL.Models.DTOs {
    internal class ClientDTO {
        [Key]
        [DisplayName("Client Id:")]
        public int Id { get; set; }
        [Required]
        [DisplayName("Client Name:")]
        public string Name { get; set; }

        [DisplayName("Client Email:")]
        public string Email { get; set; }

        [DisplayName("Client PhoneNumber:")]
        public string PhoneNumber { get; set; }

        [Required]
        [DisplayName("Client Country:")]
        public string Country { get; set; }
        [Required]
        [DisplayName("Client Region:")]
        public string Region { get; set; }
        [Required]
        [DisplayName("Client City:")]
        public string City { get; set; }

        [Required]
        [DisplayName("Client Address:")]
        public string Address { get; set; }

        [Required]
        [DisplayName("Client PostalCode:")]
        public string PostalCode { get; set; }
    }
}
