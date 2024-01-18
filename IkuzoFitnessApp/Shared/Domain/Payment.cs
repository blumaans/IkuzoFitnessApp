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
        public string? HolderName { get; set; }
        public string? CardNumber { get; set; }
        public int CVV { get; set; }
        public string? Plan { get; set; }
        public string? Month { get; set; }
        public DateTime Year { get; set; }
    }
}
