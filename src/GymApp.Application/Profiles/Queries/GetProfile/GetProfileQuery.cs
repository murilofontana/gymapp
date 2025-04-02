using GymApp.Application.Profiles.Common;
using GymApp.Domain.Profiles;
using ErrorOr;
using MediatR;

namespace GymApp.Application.Profiles.Queries.GetProfile;

public record GetProfileQuery(Guid UserId, ProfileType ProfileType) : IRequest<ErrorOr<Profile?>>;