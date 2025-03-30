namespace GymApp.Domain;

public class Subscription
{
    public Guid Id { get;}

    private readonly List<Guid> _gyms;

    public int MaxRooms { get; } = 0;

    public Subscription(Guid id, int maxRooms)
    {
        Id = id;
        MaxRooms = maxRooms;
    }
}
