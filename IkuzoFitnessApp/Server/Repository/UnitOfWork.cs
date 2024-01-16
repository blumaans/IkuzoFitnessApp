using IkuzoFitnessApp.Server.Data;
using IkuzoFitnessApp.Server.IRepository;
using IkuzoFitnessApp.Server.Models;
using IkuzoFitnessApp.Shared.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IkuzoFitnessApp.Server.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<Customer> _customers;
        private IGenericRepository<CustomerRoutine> _customerroutines;
        private IGenericRepository<Exercise> _exercises;
        private IGenericRepository<Goal> _goals;
        private IGenericRepository<Payment> _payments;
        private IGenericRepository<ProgressTrack> _progresstracks;
        private IGenericRepository<Routine> _routines;
        private IGenericRepository<Subscription> _subscriptions;
        private IGenericRepository<Workout> _workouts;

        private UserManager<ApplicationUser> _userManager;

        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IGenericRepository<Customer> Customers
            => _customers ??= new GenericRepository<Customer>(_context);
        public IGenericRepository<CustomerRoutine> CustomerRoutines
            => _customerroutines ??= new GenericRepository<CustomerRoutine>(_context);
        public IGenericRepository<Exercise> Exercises
            => _exercises ??= new GenericRepository<Exercise>(_context);
        public IGenericRepository<Goal> Goals
            => _goals ??= new GenericRepository<Goal>(_context);
        public IGenericRepository<Payment> Payments
            => _payments ??= new GenericRepository<Payment>(_context);
        public IGenericRepository<ProgressTrack> ProgressTracks
            => _progresstracks ??= new GenericRepository<ProgressTrack>(_context);
        public IGenericRepository<Routine> Routines
            => _routines ??= new GenericRepository<Routine>(_context);
        public IGenericRepository<Subscription> Subscriptions
            => _subscriptions ??= new GenericRepository<Subscription>(_context);
        public IGenericRepository<Workout> Workouts
            => _workouts ??= new GenericRepository<Workout>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save(HttpContext httpContext)
        {
            //To be implemented
            string user = "System";

            var entries = _context.ChangeTracker.Entries()
                .Where(q => q.State == EntityState.Modified ||
                    q.State == EntityState.Added);

            foreach (var entry in entries)
            {
                ((BaseDomainModel)entry.Entity).DateUpdated = DateTime.Now;
                ((BaseDomainModel)entry.Entity).UpdatedBy = user;
                if (entry.State == EntityState.Added)
                {
                    ((BaseDomainModel)entry.Entity).DateCreated = DateTime.Now;
                    ((BaseDomainModel)entry.Entity).CreatedBy = user;
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}