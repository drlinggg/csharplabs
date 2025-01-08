namespace ValueObjects;

/*
This simulation uses vector velocity, force and distance,
where positive value refers to the direction of the end.

Example: moved forward by 5
Km x = 5
moved backwards:
x -= 5
Force along the path:
Force x = 10
Against the path:
x -= 10
*/

public class KmH : ValueObject
{
    public float Value { get; }

    private KmH(float km)
    {
        Value = km;
    }

    public static KmH Create(float input)
    {
        return new KmH(input);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
