using GymApp.Api.Controllers.Common;
using GymApp.Application.Gyms.Commands.AddTrainer;
using GymApp.Application.Gyms.CreateGym;
using GymApp.Application.Gyms.Queries.GetGym;
using GymApp.Application.Gyms.Queries.ListGyms;
using GymApp.Application.Gyms.Queries.ListSessions;
using GymApp.Contracts.Gyms;
using GymApp.Contracts.Sessions;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace GymApp.Api.Controllers;

[Route("subscriptions/{subscriptionId:guid}/gyms")]
public class GymsController : ApiController
{
    private readonly ISender _sender;

    public GymsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> CreateGym(CreateGymRequest request, Guid subscriptionId)
    {
        var command = new CreateGymCommand(request.Name, subscriptionId);

        var createGymResult = await _sender.Send(command);

        return createGymResult.Match(
            gym => CreatedAtAction(
                nameof(GetGym),
                new { subscriptionId, GymId = gym.Id },
                new GymResponse(gym.Id, gym.Name)),
            Problem);
    }

    [HttpGet]
    public async Task<IActionResult> ListGyms(Guid subscriptionId)
    {
        var command = new ListGymsQuery(subscriptionId);

        var listGymsResult = await _sender.Send(command);

        return listGymsResult.Match(
            gyms => Ok(gyms.ConvertAll(gym => new GymResponse(gym.Id, gym.Name))),
            Problem);
    }

    [HttpGet("{gymId:guid}")]
    public async Task<IActionResult> GetGym(Guid subscriptionId, Guid gymId)
    {
        var command = new GetGymQuery(subscriptionId, gymId);

        var getGymResult = await _sender.Send(command);

        return getGymResult.Match(
            gym => Ok(new GymResponse(gym.Id, gym.Name)),
            Problem);
    }

    [HttpPost("{gymId:guid}/trainers")]
    public async Task<IActionResult> AddTrainer(AddTrainerRequest request, Guid subscriptionId, Guid gymId)
    {
        var command = new AddTrainerCommand(subscriptionId, gymId, request.TrainerId);

        var addTrainerResult = await _sender.Send(command);

        return addTrainerResult.Match(_ => Ok(), Problem);
    }

    [HttpGet("{gymId:guid}/sessions")]
    public async Task<IActionResult> ListSessions(
        Guid subscriptionId,
        Guid gymId,
        DateTime? startDateTime = null,
        DateTime? endDateTime = null,
        [FromQuery] List<string>? categories = null)
    {
        var categoriesToDomainResult = SessionCategoryUtils.ToDomain(categories);

        if (categoriesToDomainResult.IsError)
        {
            return Problem(categoriesToDomainResult.Errors);
        }

        var command = new ListSessionsQuery(
            subscriptionId,
            gymId,
            startDateTime,
            endDateTime,
            categoriesToDomainResult.Value);

        var listSessionsResult = await _sender.Send(command);

        return listSessionsResult.Match(
            sessions => Ok(sessions.ConvertAll(
                session => new SessionResponse(
                    session.Id,
                    session.Name,
                    session.Description,
                    session.NumParticipants,
                    session.MaxParticipants,
                    session.Date.ToDateTime(session.Time.Start),
                    session.Date.ToDateTime(session.Time.End),
                    session.Categories.Select(category => category.Name).ToList()))),
            Problem);
    }
}