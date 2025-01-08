namespace ValueObjects;

public class Kg : ValueObject
{
    public float Value { get; }

    private Kg(float m)
    {
        Value = m;
    }

    public static Kg Create(float input)
    {
        if (input < 0)
            throw new ArgumentException("Kg as mass cannot be negative");
        return new Kg(input);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
