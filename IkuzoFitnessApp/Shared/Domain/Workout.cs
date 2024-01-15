using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkuzoFitnessApp.Shared.Domain
{
    public class Workout : BaseDomainModel
    {
        public string? WorkoutName { get; set; }
        public int WorkoutNumber { get; set; }
        public int CustRoutId { get; set; }
        public virtual CustomerRoutine? CustomerRoutine { get; set; }    
    }
}
