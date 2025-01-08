using ValueObjects;

namespace Common;

public interface IPushable
{
    Newton MaxForce { get; init; }

    Kg Weight { get; init; }

    Hour Accurancy { get; init; }

    KmH Speed { get; }

    Km ApplyForce(Newton force);

    Newton CalculateForceToStop();
}
