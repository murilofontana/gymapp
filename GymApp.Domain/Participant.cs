namespace GymApp.Domain;

public class Participant
{
    
    private readonly Guid _userId;
    private readonly List<Guid> _sessionsId = new List<Guid>();

    public Guid Id { get; }

    public Participant(Guid userId, Guid? id = null)
    {
        _userId = userId;
        Id = id ?? Guid.NewGuid();
    }
}
