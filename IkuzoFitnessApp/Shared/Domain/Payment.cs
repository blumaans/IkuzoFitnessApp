using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkuzoFitnessApp.Shared.Domain
{
    public class Payment : BaseDomainModel, IValidatableObject
    {
        [Required]
        public string? PaymentType { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Holder Name must contain only alphabet characters")]
        public string? HolderName { get; set; }
        [Required]
        [StringLength(16,MinimumLength =16, ErrorMessage ="Card Number must be exactly 16 digits")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Card Number must contain only numeric digits, no spacing/alphabets")]
        public string? CardNumber { get; set; }
        [Required]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "CVV must be exactly 3 digits")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "CVV must contain only numeric digits")]
        public string? CVV { get; set; }
        [Required]
        public string? Plan { get; set; }
        [Required]
        public string? Month { get; set; }
        [Required]
        public string? Year { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            int currentMonth = DateTime.Today.Month;
            int currentYear = DateTime.Today.Year;  

            if (int.TryParse(Month, out int MonthInteger) && int.TryParse(Year, out int yearInteger))
            {
                if (MonthInteger < currentMonth &&  yearInteger <= currentYear)
                {
                    yield return new ValidationResult("Invalid month value", new[] { "Month" });
                }
            }
        }
    }
}
