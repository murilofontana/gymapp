using GymApp.Application.Profiles.Common;
using GymApp.Domain.AdminAggregate;

namespace GymApp.Application.Common.Interfaces;

public interface IAdminsRepository
{
    Task AddAdminAsync(Admin participant);
    Task<Profile?> GetProfileByUserIdAsync(Guid userId);
    Task<Admin?> GetByIdAsync(Guid adminId);
    Task UpdateAsync(Admin admin);
}