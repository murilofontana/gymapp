using GymApp.Application.Reservations.Commands.CreateReservation;
using GymApp.Contracts.Reservations;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace GymApp.Api.Controllers;

[Route("sessions/{sessionId:guid}/reservations")]
public class ReservationsController : ApiController
{
    private readonly ISender _sender;

    public ReservationsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> CreateReservation(
        CreateReservationRequest request,
        Guid sessionId)
    {
        var command = new CreateReservationCommand(
            sessionId,
            request.ParticipantId);

        var createReservationResult = await _sender.Send(command);

        return createReservationResult.Match(_ => NoContent(), Problem);
    }
}