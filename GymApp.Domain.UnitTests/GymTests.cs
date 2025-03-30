using FluentAssertions;
using GymApp.Domain.UnitTests.TestUtils.Gyms;
using GymApp.Domain.UnitTests.TestUtils.Rooms;
using GymApp.Domain.UnitTests.TestUtils.Subscriptions;

namespace GymApp.Domain.UnitTests;

public class GymTests
{
    [Fact]
    public void AddRoom_WhenMoreThanSubscriptionAllows_ShoudlFail()
    {
        // Arrange
        var gym = GymFactory.CreateGym();
        var roomOne = RoomFactory.CreateRoom(Guid.NewGuid());
        var roomTwo = RoomFactory.CreateRoom(Guid.NewGuid());


        // Act
        // Quando adicionar a segunda room, deve dar erro.
        var gymAddRoomOneResult = gym.AddRoom(roomOne);
        var gymAddRoomTwoResult = gym.AddRoom(roomTwo);

        // Assert
        gymAddRoomOneResult.IsError.Should().BeFalse();

        gymAddRoomTwoResult.IsError.Should().BeTrue();
        gymAddRoomTwoResult.FirstError.Should().Be(GymErrors.CannotHaveMoreRoomsThanSubscriptionAllowed);
    }
}
