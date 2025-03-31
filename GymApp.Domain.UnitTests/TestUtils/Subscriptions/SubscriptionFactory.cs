using GymApp.Domain.UnitTests.TestConstants;

namespace GymApp.Domain.UnitTests.TestUtils.Subscriptions;

public class SubscriptionFactory
{
    public static Subscription CreateSubscription(
        SubscriptionType? subscriptionType = null,
        Guid? adminId = null,
        Guid? id = null)
    {
        return new Subscription(
            subscriptionType: subscriptionType ?? Constants.Subscriptions.DefaultSubscriptionType,
            adminId ?? Constants.Admin.Id,
            id ?? Constants.Subscriptions.Id);
    }
}
