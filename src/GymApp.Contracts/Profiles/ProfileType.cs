using System.Text.Json.Serialization;

namespace GymApp.Contracts.Profiles;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ProfileType { Admin, Trainer, Participant }