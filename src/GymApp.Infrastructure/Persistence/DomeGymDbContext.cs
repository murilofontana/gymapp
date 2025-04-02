using System.Reflection;

using GymApp.Domain.AdminAggregate;
using GymApp.Domain.GymAggregate;
using GymApp.Domain.ParticipantAggregate;
using GymApp.Domain.RoomAggregate;
using GymApp.Domain.SessionAggregate;
using GymApp.Domain.SubscriptionAggregate;
using GymApp.Domain.TrainerAggregate;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Infrastructure.Persistence;

public class GymAppDbContext : DbContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public DbSet<Subscription> Subscriptions { get; set; } = null!;
    public DbSet<Gym> Gyms { get; set; } = null!;
    public DbSet<Room> Rooms { get; set; } = null!;
    public DbSet<Session> Sessions { get; set; } = null!;
    public DbSet<Trainer> Trainers { get; set; } = null!;
    public DbSet<Participant> Participants { get; set; } = null!;
    public DbSet<Admin> Admins { get; set; } = null!;

    public GymAppDbContext(DbContextOptions options, IHttpContextAccessor httpContextAccessor) : base(options)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}