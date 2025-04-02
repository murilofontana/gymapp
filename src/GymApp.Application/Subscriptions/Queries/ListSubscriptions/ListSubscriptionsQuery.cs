using GymApp.Domain.SubscriptionAggregate;
using ErrorOr;
using MediatR;

namespace GymApp.Application.Subscriptions.Queries.ListSubscriptions;

// TODO: add admin id, for now, return all
public record ListSubscriptionsQuery() : IRequest<ErrorOr<List<Subscription>>>;