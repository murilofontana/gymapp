using GymApp.Domain.RoomAggregate;
using ErrorOr;
using MediatR;

namespace GymApp.Application.Rooms.Queries.GetRoom;

public record GetRoomQuery(
    Guid GymId,
    Guid RoomId) : IRequest<ErrorOr<Room>>;