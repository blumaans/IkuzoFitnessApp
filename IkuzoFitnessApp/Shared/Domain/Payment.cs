using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkuzoFitnessApp.Shared.Domain
{
    public class Payment : BaseDomainModel
    {
        public double? PaymentAmount { get; set; }
        public string? PaymentType { get; set; }
    }
}
