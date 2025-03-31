using System.Linq;
using ErrorOr;
using GymApp.Domain.Common;
using GymApp.Domain.RoomAggregate;

namespace GymApp.Domain.GymAggregate;

public class Gym : AggregateRoot
{

    private readonly Guid _subscriptionId;
    private readonly int _maxRooms;

    private readonly List<Guid> _roomIds = new List<Guid>();

    public Gym(
       int maxRooms,
       Guid subscriptionId,
       Guid? id = null) : base(id ?? Guid.NewGuid())
    {
        _maxRooms = maxRooms;
        _subscriptionId = subscriptionId;
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
