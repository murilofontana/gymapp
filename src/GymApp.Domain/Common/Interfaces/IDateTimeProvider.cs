namespace GymApp.Domain.Common.Interfaces;

public interface IDateTimeProvider
{
    public DateTime UtcNow { get; }
}