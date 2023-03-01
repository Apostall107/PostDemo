using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PostDemo.DAL.Models.Entities {
    public class Package {
        [Key]
        [DisplayName("Package Id:")]
        public int Id { get; set; }
        [Required]
        [DisplayName("Package Title:")]
        public string Title { get; set; }
        [Required]
        [DisplayName("Package weight:")]
        [Range(1, 100, ErrorMessage = "Weight must be in range from 1 to 100 kilos")]
        public int Kilos { get; set; }

        [DisplayName("Description:")]
        public string Description { get; set; }

        [DisplayName("Package send date:")]
        [ValidateSendDate(ErrorMessage = "Send date should be less than or equal to today's date")]
        public DateTime sendDate { get; set; } = DateTime.UtcNow;
        [Required]
        public int SenderId { get; set; }
        [Required]
        public int ReceiverId { get; set; }


        //navigation property

        public virtual Client? Sender { get; set; }
        public virtual Client? Receiver { get; set; }




    }

        //custom validation attribute for SendDate
    public class ValidateSendDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var sendDate = (DateTime)value;
            if (sendDate.Date > DateTime.UtcNow.Date)
            {
                return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }

}
