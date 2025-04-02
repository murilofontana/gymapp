
using GymApp.Application.Profiles.Common;
using GymApp.Domain.TrainerAggregate;

namespace GymApp.Application.Common.Interfaces;

public interface ITrainersRepository
{
    Task AddTrainerAsync(Trainer participant);
    Task<Trainer?> GetByIdAsync(Guid trainerId);
    Task<Profile?> GetProfileByUserIdAsync(Guid userId);
    Task UpdateAsync(Trainer trainer);
}