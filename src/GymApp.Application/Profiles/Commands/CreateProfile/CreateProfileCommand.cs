using GymApp.Domain.Profiles;
using ErrorOr;
using MediatR;

namespace GymApp.Application.Profiles.Commands.CreateProfile;

public record CreateProfileCommand(ProfileType ProfileType, Guid UserId)
    : IRequest<ErrorOr<Guid>>;
