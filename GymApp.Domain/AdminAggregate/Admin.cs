using GymApp.Domain.Common;

namespace GymApp.Domain.AdminAggregate;

public class Admin : AggregateRoot
{
    private readonly Guid _userId;

    private readonly Guid _subscriptionId;

    public Admin(Guid userId, Guid subscriptionId, Guid? id) : base(id ?? Guid.NewGuid())
    {
        _userId = userId;
        _subscriptionId = subscriptionId;
    }
}
