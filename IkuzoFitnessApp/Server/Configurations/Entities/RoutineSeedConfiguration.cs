using Humanizer;
using IkuzoFitnessApp.Server.Data;
using IkuzoFitnessApp.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Drawing;

namespace IkuzoFitnessApp.Server.Configurations.Entities
{
    public class RoutineSeedConfiguration : IEntityTypeConfiguration<Routine>
    {
        public void Configure(EntityTypeBuilder<Routine> builder)
        {
            //throw new NotImplementedException();
            builder.HasData(
            new Routine
            {
                Id = 1,
                RoutineName = "Muscle",
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                CreatedBy = "System",
                UpdatedBy = "System"
            },
            new Routine
            {
                Id = 2,
                RoutineName = "Cardio",
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                CreatedBy = "System",
                UpdatedBy = "System"
            },
            new Routine
            {
                Id = 3,
                RoutineName = "Calisthenics",
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now,
                CreatedBy = "System",
                UpdatedBy = "System"
            }
            );
        }
    }
}
