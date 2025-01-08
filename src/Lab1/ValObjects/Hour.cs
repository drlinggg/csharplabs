namespace ValueObjects;

public class Hour : ValueObject
{
    public float Value { get; }

    private Hour(float m)
    {
        Value = m;
    }

    public static Hour Create(float input)
    {
        if (input < 0)
            throw new ArgumentException("Hours as time type cannot be negative");
        return new Hour(input);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
