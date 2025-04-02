using GymApp.Domain.GymAggregate;
using ErrorOr;
using MediatR;

namespace GymApp.Application.Gyms.Queries.ListGyms;

public record ListGymsQuery(Guid SubscriptionId) : IRequest<ErrorOr<List<Gym>>>;