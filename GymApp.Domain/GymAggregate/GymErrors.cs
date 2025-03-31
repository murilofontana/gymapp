using ErrorOr;

namespace GymApp.Domain;

public static class GymErrors
{
    public readonly static Error CannotHaveMoreRoomsThanSubscriptionAllowed= Error.Validation(
        code: "Gym.CannotHaveMoreRoomsThanSubscriptionAllowed",
        description: "A gym cannot have more rooms than the subscription allows");
}
