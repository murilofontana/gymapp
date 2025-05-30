using GymApp.Application.Rooms.Commands.CreateRoom;
using GymApp.Application.Rooms.Commands.DeleteRoom;
using GymApp.Application.Rooms.Queries.GetRoom;
using GymApp.Application.Rooms.Queries.ListRooms;
using GymApp.Contracts.Rooms;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace GymApp.Api.Controllers;

[Route("gyms/{gymId:guid}/rooms")]
public class RoomsController : ApiController
{
    private readonly ISender _sender;

    public RoomsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> CreateRoom(
        CreateRoomRequest request,
        Guid gymId)
    {
        var command = new CreateRoomCommand(
            gymId,
            request.Name);

        var createRoomResult = await _sender.Send(command);

        return createRoomResult.Match(
            room => CreatedAtAction(
                nameof(GetRoom),
                new { gymId, RoomId = room.Id },
                new RoomResponse(room.Id, room.Name)),
            Problem);
    }

    [HttpDelete("{roomId:guid}")]
    public async Task<IActionResult> DeleteRoom(
        Guid gymId,
        Guid roomId)
    {
        var command = new DeleteRoomCommand(gymId, roomId);

        var deleteRoomResult = await _sender.Send(command);

        return deleteRoomResult.Match(_ => NoContent(), Problem);
    }

    [HttpGet("{roomId:guid}")]
    public async Task<IActionResult> GetRoom(
        Guid gymId,
        Guid roomId)
    {
        var query = new GetRoomQuery(gymId, roomId);

        var getRoomResult = await _sender.Send(query);

        return getRoomResult.Match(
            room => Ok(new RoomResponse(room.Id, room.Name)),
            Problem);
    }

    [HttpGet]
    public async Task<IActionResult> ListRooms(Guid gymId)
    {
        var query = new ListRoomsQuery(gymId);

        var listRoomsResult = await _sender.Send(query);

        return listRoomsResult.Match(
            rooms => Ok(rooms.ConvertAll(room => new RoomResponse(room.Id, room.Name))),
            Problem);
    }
}