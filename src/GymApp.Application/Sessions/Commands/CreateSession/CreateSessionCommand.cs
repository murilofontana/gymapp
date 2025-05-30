using GymApp.Domain.SessionAggregate;
using ErrorOr;
using MediatR;

namespace GymApp.Application.Sessions.Commands.CreateSession;

public record CreateSessionCommand(
    Guid RoomId,
    string Name,
    string Description,
    int MaxParticipants,
    DateTime StartDateTime,
    DateTime EndDateTime,
    Guid TrainerId,
    List<SessionCategory> Categories) : IRequest<ErrorOr<Session>>;