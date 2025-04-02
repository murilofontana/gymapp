using GymApp.Application.Common.Interfaces;
using GymApp.Application.Profiles.Common;
using GymApp.Domain.AdminAggregate;
using GymApp.Domain.Profiles;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Infrastructure.Persistence.Repositories;

public class AdminsRepository : IAdminsRepository
{
    private readonly GymAppDbContext _dbContext;

    public AdminsRepository(GymAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAdminAsync(Admin admin)
    {
        await _dbContext.Admins.AddAsync(admin);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Profile?> GetProfileByUserIdAsync(Guid userId)
    {
        var admin = await _dbContext.Admins
            .AsNoTracking()
            .FirstOrDefaultAsync(admin => admin.UserId == userId);

        return admin is null ? null : new Profile(admin.Id, ProfileType.Admin);
    }

    public Task<Admin?> GetByIdAsync(Guid adminId)
    {
        return _dbContext.Admins.FirstOrDefaultAsync(admin => admin.Id == adminId);
    }

    public async Task UpdateAsync(Admin admin)
    {
        _dbContext.Update(admin);
        await _dbContext.SaveChangesAsync();
    }
}