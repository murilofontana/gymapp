using GymApp.Domain.SessionAggregate;

using ErrorOr;

using MediatR;

namespace GymApp.Application.Sessions.Queries.GetSession;

public record GetSessionQuery(Guid RoomId, Guid SessionId)
    : IRequest<ErrorOr<Session>>;