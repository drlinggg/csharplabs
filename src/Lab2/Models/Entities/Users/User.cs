namespace Users;

public class User : AbsUser
{
    public User(uint id, string name) : base(id, name) { }

    public static bool operator ==(User left, User right)
    {
        if (ReferenceEquals(left, right)) return true;
        if ((left is null) || (right is null)) return false;

        return left.Id == right.Id;
    }

    public static bool operator !=(User left, User right)
    {
        return !(left == right);
    }

    public override bool Equals(object? obj)
    {
        if (obj is not User other) return false;

        return Id == other.Id;
    }

    public override int GetHashCode()
    {
        return (int)Id;
    }
}
