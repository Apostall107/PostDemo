using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PostDemo.DAL.Models.DTOs {
    public class PackageDTO {

        [DisplayName("Package Title:")]
        public string Title { get; set; }
        [DisplayName("Package weight:")]
        public int Kilos { get; set; }

        [DisplayName("Description:")]
        public string Description { get; set; }

        [DisplayName("Package send date:")]
        public DateTime sendDate { get; set; } = DateTime.UtcNow;
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
    }
}
