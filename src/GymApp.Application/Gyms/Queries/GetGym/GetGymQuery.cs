using GymApp.Domain.GymAggregate;
using ErrorOr;
using MediatR;

namespace GymApp.Application.Gyms.Queries.GetGym;

public record GetGymQuery(Guid SubscriptionId, Guid GymId) : IRequest<ErrorOr<Gym>>;