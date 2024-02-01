using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkuzoFitnessApp.Shared.Domain
{
    public class Exercise : BaseDomainModel
    {
        public string? ExerciseName { get; set; }   
        public int? WokroutId { get; set; }
        public virtual Workout? Workout { get; set; }
    }
}
