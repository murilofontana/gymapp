using ErrorOr;
using GymApp.Domain.Common;
using GymApp.Domain.Common.Interfaces;
using GymApp.Domain.Common.ValueObjects;
using GymApp.Domain.ParticipantAggregate;

namespace GymApp.Domain.SessionAggregate;

public class Session : AggregateRoot
{
    private readonly Guid _trainerId;
    private readonly List<Reservation> _reservations = new();

    private readonly int _maxParticipants;

    public DateOnly Date { get; }

    public TimeRange Time { get; }

    public Session(
        DateOnly date,
        TimeRange time,
        int maxParticipants,
        Guid trainerId,
        Guid? id = null) : base(id ?? Guid.NewGuid())
    {
        Date = date;
        Time = time;
        _maxParticipants = maxParticipants;
        _trainerId = trainerId;
    }
    public ErrorOr<Success> ReserveSpot(Participant participant)
    {
        if (_reservations.Count >= _maxParticipants)
        {
            return SessionErrors.CannotHaveMoreReservationsThanParticipants;
        }

        if (_reservations.Any(reservation => reservation.Id == participant.Id))
        {
            return Error.Conflict(description: "Participant cannot reserve twice");
        }

        var reservation = new Reservation(participant.Id);

        _reservations.Add(reservation);

        return Result.Success;
    }

    public ErrorOr<Success> CancelReservation(Participant participant, IDateTimeProvider dateTimeProvider)
    {
        if (IsTooCloseToSession(dateTimeProvider.UtcNow))
        {
            return SessionErrors.CannotCancelReservationTooCloseToSession;
        }

        var reservation = _reservations.Find(reservation => reservation.Id == participant.Id);
        if (reservation == null)
        {
            return Error.NotFound(description: "Participant not found");
        }

        _reservations.Remove(reservation);

        return Result.Success;
    }

    private bool IsTooCloseToSession(DateTime utcNow)
    {
        const int MinHours = 24;

        return (Date.ToDateTime(Time.Start) - utcNow).TotalHours < MinHours;
    }
}
