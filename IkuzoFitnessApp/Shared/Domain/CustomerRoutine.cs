using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkuzoFitnessApp.Shared.Domain
{
    public class CustomerRoutine : BaseDomainModel
    {
        public int CustomerId { get; set; } 
        public virtual Customer? Customer { get; set; }
        public int RoutineId { get; set; }  
        public virtual Routine? Routine { get; set; }
    }
}
