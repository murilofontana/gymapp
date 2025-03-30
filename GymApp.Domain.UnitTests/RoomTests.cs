using FluentAssertions;
using GymApp.Domain.UnitTests.TestUtils.Rooms;
using GymApp.Domain.UnitTests.TestUtils.Sessions;

namespace GymApp.Domain.UnitTests;

public class RoomTests
{
    [Fact]
    public void ScheduleSession_WhenMoreThanSubscriptionAllows_ShouldFail()
    {
        // Arrange
        var sessionOne = SessionFactory.CreateSession(id: Guid.NewGuid());
        var sessionTwo = SessionFactory.CreateSession(id: Guid.NewGuid());
        var room = RoomFactory.CreateRoom(maxDailySessions: 1);

        // Act
        var sessionOneResult = room.ScheduleSession(sessionOne);
        var sessionTwoResult = room.ScheduleSession(sessionTwo);

        // Assert
        sessionOneResult.IsError.Should().BeFalse();

        sessionTwoResult.IsError.Should().BeTrue();
        sessionTwoResult.FirstError.Should().Be(RoomErrors.CannotHaveMoreSessionsThanSubscriptionAllowed);
    }
}
