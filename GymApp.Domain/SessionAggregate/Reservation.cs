using GymApp.Domain.Common;

namespace GymApp.Domain.SessionAggregate;

public class Reservation : Entity
{
    public Guid ParticipantId;

    public Reservation(
        Guid participantId,
        Guid? id = null) : base(id ?? Guid.NewGuid())
    {
        ParticipantId = participantId;
    }

}
