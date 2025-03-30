namespace GymApp.Domain;

public class Room
{
    public Guid Id { get; }

    private readonly List<Guid> _sessionsId = new List<Guid>();

    public Room(Guid id)
    {
        Id = id;
    }
}
