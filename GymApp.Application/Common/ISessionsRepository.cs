using GymApp.Domain.SessionAggregate;

namespace GymApp.Domain.Common.Interfaces;

public interface ISessionsRepository
{
    Task AddSessionAsync(Session session);
    Task UpdateSessionAsync(Session session);
}
