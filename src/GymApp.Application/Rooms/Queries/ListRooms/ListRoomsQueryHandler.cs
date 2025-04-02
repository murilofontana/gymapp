using GymApp.Application.Common.Interfaces;
using GymApp.Domain.RoomAggregate;

using ErrorOr;

using MediatR;

namespace GymApp.Application.Rooms.Queries.ListRooms;

public class ListRoomsQueryHandler : IRequestHandler<ListRoomsQuery, ErrorOr<List<Room>>>
{
    private readonly IGymsRepository _gymsRepository;
    private readonly IRoomsRepository _roomsRepository;

    public ListRoomsQueryHandler(IRoomsRepository roomsRepository, IGymsRepository gymsRepository)
    {
        _roomsRepository = roomsRepository;
        _gymsRepository = gymsRepository;
    }

    public async Task<ErrorOr<List<Room>>> Handle(ListRoomsQuery query, CancellationToken cancellationToken)
    {
        if (!await _gymsRepository.ExistsAsync(query.GymId))
        {
            return Error.NotFound(description: "Gym not found");
        }

        return await _roomsRepository.ListByGymIdAsync(query.GymId);
    }
}
