using GymApp.Domain.UnitTests.TestConstants;

namespace GymApp.Domain.UnitTests.TestUtils.Rooms;

public class RoomFactory
{
    public static Room CreateRoom(Guid? id = null)
    {
        return new Room(
            id ?? Constants.Room.Id);
    }
}
