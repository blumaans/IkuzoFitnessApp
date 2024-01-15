using Duende.IdentityServer.EntityFramework.Options;
using IkuzoFitnessApp.Server.Configurations.Entities;
using IkuzoFitnessApp.Server.Models;
using IkuzoFitnessApp.Shared.Domain;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace IkuzoFitnessApp.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerRoutine> CustomersPrograms { get; set; }
        public DbSet<Exercise> Exercises { get; set;}
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Routine> Routines { get; set; }
        public DbSet<ProgressTrack> ProgressTracks { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Workout> Workouts { get; set; }    

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoutineSeedConfiguration());
        }
    }
}
