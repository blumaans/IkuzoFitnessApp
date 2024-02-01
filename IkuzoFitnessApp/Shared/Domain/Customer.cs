using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkuzoFitnessApp.Shared.Domain
{
    public class Customer: BaseDomainModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set;}
        [Required]
        public string? Gender { get; set; }
        [Required]
        public decimal Weight { get; set; }
        [Required]
        public decimal Height { get; set; }
        public virtual Payment? Payment { get; set; }
        public int? PaymentId { get; set; }

    }
}
