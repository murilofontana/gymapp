using GymApp.Domain.Common.ValueObjects;
using GymApp.Domain.SessionAggregate;

namespace GymApp.Domain.UnitTests.TestConstants;

public static partial class Constants
{
    public static class Session
    {
        public static readonly Guid Id = Guid.NewGuid();
        public static readonly DateOnly Date = DateOnly.FromDateTime(DateTime.UtcNow);
        public static readonly TimeRange Time = new(
            TimeOnly.MinValue.AddHours(8),
            TimeOnly.MinValue.AddHours(9));

        public static readonly List<SessionCategory> Categories = new();

        public const int MaxParticipants = 10;
        public const string Name = "Zoomba Session";
        public const string Description = "The best zoomba yay";
    }
}