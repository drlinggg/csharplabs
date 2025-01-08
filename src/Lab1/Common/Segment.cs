using ResultTypes;
using ValueObjects;

namespace Common;

public abstract class Segment
{
    protected abstract Km Distance { get; init; }

    public abstract TryPassResult TryPass(IPassengerTrain transport);
}
