using ErrorOr;

namespace GymApp.Domain;

public static class RoomErrors
{
    public readonly static Error CannotHaveMoreSessionsThanSubscriptionAllowed = Error.Validation(
        code: "Room.CannotHaveMoreRoomsThanSubscriptionAllowed",
        description: "A room cannot have more sessions than the subscription allows");
}
