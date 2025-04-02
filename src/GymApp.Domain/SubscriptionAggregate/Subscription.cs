using GymApp.Domain.Common;
using GymApp.Domain.GymAggregate;

using ErrorOr;

namespace GymApp.Domain.SubscriptionAggregate;

public class Subscription : AggregateRoot
{
    private readonly List<Guid> _gymIds = new();
    private readonly int _maxGyms;
    private readonly Guid _adminId;

    public SubscriptionType SubscriptionType { get; } = default!;

    public Subscription(
        SubscriptionType subscriptionType,
        Guid adminId,
        Guid? id = null)
            : base(id ?? Guid.NewGuid())
    {
        SubscriptionType = subscriptionType;
        _maxGyms = GetMaxGyms();
        _adminId = adminId;
    }

    public int GetMaxGyms() => SubscriptionType.Name switch
    {
        nameof(SubscriptionType.Free) => 1,
        nameof(SubscriptionType.Starter) => 1,
        nameof(SubscriptionType.Pro) => 3,
        _ => throw new InvalidOperationException()
    };

    public int GetMaxRooms() => SubscriptionType.Name switch
    {
        nameof(SubscriptionType.Free) => 1,
        nameof(SubscriptionType.Starter) => 3,
        nameof(SubscriptionType.Pro) => int.MaxValue,
        _ => throw new InvalidOperationException()
    };

    public int GetMaxDailySessions() => SubscriptionType.Name switch
    {
        nameof(SubscriptionType.Free) => 4,
        nameof(SubscriptionType.Starter) => int.MaxValue,
        nameof(SubscriptionType.Pro) => int.MaxValue,
        _ => throw new InvalidOperationException()
    };

    public ErrorOr<Success> AddGym(Gym gym)
    {
        if (_gymIds.Contains(gym.Id))
        {
            return Error.Conflict(description: "Gym already exists");
        }

        if (_gymIds.Count >= _maxGyms)
        {
            return SubscriptionErrors.CannotHaveMoreGymsThanSubscriptionAllows;
        }

        _gymIds.Add(gym.Id);

        return Result.Success;
    }

    public bool HasGym(Guid gymId)
    {
        return _gymIds.Contains(gymId);
    }

    private Subscription() { }
}