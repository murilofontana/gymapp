using GymApp.Domain.GymAggregate;
using ErrorOr;
using MediatR;

namespace GymApp.Application.Gyms.CreateGym;

public record CreateGymCommand(string Name, Guid SubscriptionId) : IRequest<ErrorOr<Gym>>;