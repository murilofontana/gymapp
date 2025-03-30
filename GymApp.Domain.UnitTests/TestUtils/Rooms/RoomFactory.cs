using GymApp.Domain.UnitTests.TestConstants;

namespace GymApp.Domain.UnitTests.TestUtils.Rooms;

public class RoomFactory
{
    public static Room CreateRoom(int maxDailySessions = Constants.Subscriptions.MaxDailySessionsFreeTier, Guid? gymId = null , Guid? id = null)
    {
        return new Room(
            id ?? Constants.Room.Id,
            gymId ?? Constants.Gym.Id,
            maxDailySessions);
    }
}
