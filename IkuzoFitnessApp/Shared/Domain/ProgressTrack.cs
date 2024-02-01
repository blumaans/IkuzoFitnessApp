using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkuzoFitnessApp.Shared.Domain
{
    public class ProgressTrack : BaseDomainModel
    {
        public double? Weights { get; set; }
        public int? Sets { get; set; }
        public int? Reps { get; set; }
        public int? ExerciseId { get; set; }
        public virtual Exercise? Exercise { get; set; }
    }
}
