using GymApp.Domain.Profiles;

namespace GymApp.Application.Profiles.Common;

public record Profile(Guid Id, ProfileType ProfileType);