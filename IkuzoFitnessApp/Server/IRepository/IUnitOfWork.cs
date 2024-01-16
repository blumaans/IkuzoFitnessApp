using IkuzoFitnessApp.Shared.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IkuzoFitnessApp.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<Customer> Customers { get; }
        IGenericRepository<CustomerRoutine> CustomerRoutines { get; }
        IGenericRepository<Exercise> Exercises { get; }
        IGenericRepository<Goal> Goals { get; }
        IGenericRepository<Payment> Payments { get; }
        IGenericRepository<ProgressTrack> ProgressTracks { get; }
        IGenericRepository<Routine> Routines { get; }
        IGenericRepository<Subscription> Subscriptions { get; }
        IGenericRepository<Workout> Workouts { get; }

    }
}