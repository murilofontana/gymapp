namespace GymApp.Domain.Common;

public abstract class Entity
{
    public Guid Id { get; set; }
    protected Entity(Guid id)
    {
        Id = id;
    }
    public override bool Equals(object? obj)
    {
        if (obj == null || obj.GetType() != GetType())
        {
            return false;
        }

        return ((Entity)obj).Id == Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
