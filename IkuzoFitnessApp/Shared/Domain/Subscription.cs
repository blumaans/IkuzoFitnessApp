using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkuzoFitnessApp.Shared.Domain
{
    public class Subscription : BaseDomainModel, IValidatableObject
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public int? PaymentId { get; set; }
        public virtual Payment? Payment { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //throw new NotImplementedException();
            if (StartDate >= EndDate)
            {
                yield return new ValidationResult("End Date must be greater than Start Date", new[] { "EndDate" });
            }
        }
    }
}
