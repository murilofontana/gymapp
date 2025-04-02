using GymApp.Application.Common.Interfaces;
using GymApp.Domain.GymAggregate;

using ErrorOr;

using Microsoft.EntityFrameworkCore;

namespace GymApp.Infrastructure.Persistence.Repositories;

public class GymsRepository : IGymsRepository
{
    private readonly GymAppDbContext _dbContext;

    public GymsRepository(GymAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddGymAsync(Gym gym)
    {
        await _dbContext.Gyms.AddAsync(gym);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _dbContext.Gyms.AsNoTracking().AnyAsync(gym => gym.Id == id);
    }

    public async Task<Gym?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Gyms.FirstOrDefaultAsync(gym => gym.Id == id);
    }

    public async Task<List<Gym>> ListSubscriptionGymsAsync(Guid subscriptionId)
    {
        return await _dbContext.Gyms
            .Where(gym => gym.SubscriptionId == subscriptionId)
            .ToListAsync();
    }

    public async Task UpdateAsync(Gym gym)
    {
        _dbContext.Update(gym);
        await _dbContext.SaveChangesAsync();
    }
}
