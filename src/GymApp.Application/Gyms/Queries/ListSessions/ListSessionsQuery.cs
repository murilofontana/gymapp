using GymApp.Domain.SessionAggregate;
using ErrorOr;
using MediatR;

namespace GymApp.Application.Gyms.Queries.ListSessions;

public record ListSessionsQuery(
    Guid SubscriptionId,
    Guid GymId,
    DateTime? StartDateTime = null,
    DateTime? EndDateTime = null,
    List<SessionCategory>? Categories = null) : IRequest<ErrorOr<List<Session>>>;