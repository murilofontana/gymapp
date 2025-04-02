using GymApp.Domain.SubscriptionAggregate;
using ErrorOr;
using MediatR;

namespace GymApp.Application.Subscriptions.Commands.CreateSubscription;

public record CreateSubscriptionCommand(SubscriptionType SubscriptionType, Guid AdminId)
    : IRequest<ErrorOr<Subscription>>;