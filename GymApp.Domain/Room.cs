using ErrorOr;

namespace GymApp.Domain;

public class Room
{
    private readonly List<Guid> _sessionsId = new List<Guid>();

    private readonly Guid _gymId;

    public Schedule _schedule { get; } = Schedule.Empty();

    private readonly int maxDailySessions;

    public Guid Id { get; }

    public Room(Guid id, Guid gymId,int maxSessions = 0)
    {
        Id = id;
        _gymId = gymId;
        maxDailySessions = maxSessions;
    }

    public ErrorOr<Success> ScheduleSession(Session session)
    {
        if (_sessionsId.Contains(session.Id))
        {
            return Error.Conflict(description: "Sessions already exists in room");
        }

        if (_sessionsId.Count >= maxDailySessions)
        {
            return RoomErrors.CannotHaveMoreSessionsThanSubscriptionAllowed;
        }

        var addEventResult = _schedule.BookTimeSlot(session.Date, session.Time);

        if (addEventResult.IsError && addEventResult.FirstError.Type == ErrorType.Conflict)
        {
            return RoomErrors.CannotHaveTwoOrMoreOverlappingSessions;
        }

        _sessionsId.Add(session.Id);

        return Result.Success;
    }
}
