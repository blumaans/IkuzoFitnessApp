using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkuzoFitnessApp.Shared.Domain
{
    public class Subscription : BaseDomainModel
    {
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? Duration { get; set; }
        public int PaymentId { get; set; }
        public virtual Payment? Payment { get; set; }
    }
}
