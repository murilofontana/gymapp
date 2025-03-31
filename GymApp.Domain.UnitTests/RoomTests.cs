using FluentAssertions;
using GymApp.Domain.UnitTests.TestConstants;
using GymApp.Domain.UnitTests.TestUtils.Common;
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

    [Theory]
    [InlineData(1, 3, 1, 3)] // exact overlap
    [InlineData(1, 3, 2, 3)] // second session inside first session
    [InlineData(1, 3, 2, 4)] // second session ends after session, but overlaps
    [InlineData(1, 3, 0, 2)] // second session starts before second session, but overlaps
    public void ScheduleSession_WhenTwoOrMoreOverlappingSessions_ShoudlFail(int startHourSession1,
        int endHourSession1,
        int startHourSession2,
        int endHourSession2)
    {
        // Arrange
        var room = RoomFactory.CreateRoom();
        var timeRangeOne = TimeRangeFactory.CreateFromHours(startHourSession1, endHourSession1);
        var timeRangeTwo = TimeRangeFactory.CreateFromHours(startHourSession2, endHourSession2);
        var sessionOne = SessionFactory.CreateSession(Constants.Session.Date,timeRangeOne, id: Guid.NewGuid());
        var sessionTwo = SessionFactory.CreateSession(Constants.Session.Date, timeRangeTwo, id: Guid.NewGuid());
        // Act

        var sessionOneResult = room.ScheduleSession(sessionOne);
        var sessionTwoResult = room.ScheduleSession(sessionTwo);

        // Assert

        sessionOneResult.IsError.Should().BeFalse();

        sessionTwoResult.IsError.Should().BeTrue();
        sessionTwoResult.FirstError.Should().Be(RoomErrors.CannotHaveTwoOrMoreOverlappingSessions);
    }
}
