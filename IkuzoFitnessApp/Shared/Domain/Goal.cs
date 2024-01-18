using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkuzoFitnessApp.Shared.Domain
{
    public class Goal : BaseDomainModel
    {
        public string? TargetMetric { get; set; }
        public double TargetValue { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? TimeFrame { get; set; }
        public int CustomerId { get; set; } 
        public virtual Customer? Customer { get; set; } 
    }
}
