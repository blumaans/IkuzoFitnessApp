using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkuzoFitnessApp.Shared.Domain
{
    public class Goal : BaseDomainModel, IValidatableObject
    {
        [Required]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Metric must contain only alphabet characters")]
        public string? TargetMetric { get; set; }
        [Required]
        public double? TargetValue { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public int? CustomerId { get; set; } 
        public virtual Customer? Customer { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //throw new NotImplementedException();
            if(StartDate >= EndDate)
            {
                yield return new ValidationResult("End Date must be greater than Start Date", new[] { "EndDate" });
            }
        }
    }
}
