using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkuzoFitnessApp.Shared.Domain
{
    public class Customer: BaseDomainModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set;}
        public string? Gender { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public int GoalId { get; set; }
        public virtual Goal? Goal { get; set; }
        public virtual Payment? Payment { get; set; }
        public int PaymentId { get; set; }

    }
}
