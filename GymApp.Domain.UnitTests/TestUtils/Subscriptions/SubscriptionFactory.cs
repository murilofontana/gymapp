using GymApp.Domain.UnitTests.TestConstants;

namespace GymApp.Domain.UnitTests.TestUtils.Subscriptions;

public class SubscriptionFactory
{
    public static Subscription CreateSubscription(Guid? id = null)
    {
        return new Subscription(
            id ?? Constants.Subscriptions.Id, Constants.Subscriptions.MaxGymsFreeTier);
    }
}
