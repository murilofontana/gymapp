using GymApp.Domain.ParticipantAggregate;
using GymApp.Domain.UnitTests.TestConstants;

namespace GymApp.Domain.UnitTests.TestUtils.Participants;

public static class ParticipantFactory
{
    public static Participant CreateParticipant(Guid? id = null, Guid? userId = null)
    {
        return new Participant(
            userId ?? Constants.User.Id,
            id ?? Constants.Participant.Id);
    }
}