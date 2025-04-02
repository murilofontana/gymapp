using GymApp.Domain.RoomAggregate;
using ErrorOr;
using MediatR;

namespace GymApp.Application.Rooms.Commands.CreateRoom;

public record CreateRoomCommand(
    Guid GymId,
    string RoomName) : IRequest<ErrorOr<Room>>;