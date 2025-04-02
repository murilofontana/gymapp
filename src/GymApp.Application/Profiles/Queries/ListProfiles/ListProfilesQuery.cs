using GymApp.Application.Profiles.Common;
using ErrorOr;
using MediatR;

namespace GymApp.Application.Profiles.Queries.ListProfilesQuery;

public record ListProfilesQuery(Guid UserId) : IRequest<ErrorOr<List<Profile>>>;