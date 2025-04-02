using GymApp.Application.Common.Interfaces;
using GymApp.Application.Profiles.Common;
using GymApp.Domain.Profiles;
using GymApp.Domain.TrainerAggregate;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Infrastructure.Persistence.Repositories;

public class TrainersRepository : ITrainersRepository
{
    private readonly GymAppDbContext _dbContext;

    public TrainersRepository(GymAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddTrainerAsync(Trainer trainer)
    {
        await _dbContext.Trainers.AddAsync(trainer);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Trainer?> GetByIdAsync(Guid trainerId)
    {
        return await _dbContext.Trainers.FirstOrDefaultAsync(trainer => trainer.Id == trainerId);
    }

    public async Task<Profile?> GetProfileByUserIdAsync(Guid userId)
    {
        var trainer = await _dbContext.Trainers
            .AsNoTracking()
            .FirstOrDefaultAsync(trainer => trainer.UserId == userId);

        return trainer is null ? null : new Profile(trainer.Id, ProfileType.Trainer);
    }

    public async Task UpdateAsync(Trainer trainer)
    {
        _dbContext.Trainers.Update(trainer);
        await _dbContext.SaveChangesAsync();
    }
}