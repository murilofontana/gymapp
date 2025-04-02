using GymApp.Application.Common.Interfaces;
using GymApp.Domain.RoomAggregate;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Infrastructure.Persistence.Repositories;

public class RoomsRepository : IRoomsRepository
{
    private readonly GymAppDbContext _dbContext;

    public RoomsRepository(GymAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddRoomAsync(Room room)
    {
        await _dbContext.Rooms.AddAsync(room);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Room?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Rooms.FirstOrDefaultAsync(room => room.Id == id);
    }

    public async Task<List<Room>> ListByGymIdAsync(Guid gymId)
    {
        return await _dbContext.Rooms
            .AsNoTracking()
            .Where(room => room.GymId == gymId)
            .ToListAsync();
    }

    public async Task RemoveAsync(Room room)
    {
        _dbContext.Rooms.Remove(room);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Room room)
    {
        _dbContext.Rooms.Update(room);
        await _dbContext.SaveChangesAsync();
    }
}
