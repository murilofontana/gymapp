using GymApp.Domain.Common.Interfaces;

namespace GymApp.Infrastructure.Services;

public class SystemDateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
