using System.Linq;
using ErrorOr;

namespace GymApp.Domain;

public class Gym
{
    
    private readonly Guid _subscriptionId;
    private readonly int _maxRooms;

    private readonly List<Guid> _roomIds = new List<Guid>();

    public Guid Id { get; }

    public Gym(
       int maxRooms,
       Guid subscriptionId,
       Guid? id = null)
    {
        _maxRooms = maxRooms;
        _subscriptionId = subscriptionId;
        Id = id ?? Guid.NewGuid();
    }


    public ErrorOr<Success> AddRoom(Room room)
    {
        if (_roomIds.Contains(room.Id))
        {
            return Error.Conflict(description: "Room already exists in gym");
        }

        if (_roomIds.Count >= _maxRooms)
        {
            return GymErrors.CannotHaveMoreRoomsThanSubscriptionAllowed;
        }

        _roomIds.Add(room.Id);

        return Result.Success;

    }
}
