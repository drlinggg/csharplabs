using Common;
using ResultTypes;
using System.Collections.ObjectModel;
using ValueObjects;

namespace Models;

public class Route
{
    private readonly Collection<Segment> segments;

    private IPassengerTrain Tr { get; init; }

    public Route(Collection<Segment> segments, IPassengerTrain transport, KmH speedLimitAtEnd)
    {
        segments.Add(new Station(0, speedLimitAtEnd));
        this.segments = segments;
        this.Tr = transport;
    }

    public TryPassResult TryPass()
    {
        foreach (Segment seg in segments)
        {
            TryPassResult result = seg.TryPass(Tr);
            if (result is not TryPassResult.Success)
                return result;
        }

        return new TryPassResult.Success();
    }
}
