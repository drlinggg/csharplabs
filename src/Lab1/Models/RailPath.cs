using Common;
using ResultTypes;
using ValueObjects;

namespace Models;

public class RailPath : Segment
{
    protected Newton Force { get; init; }

    protected override Km Distance { get; init; }

    public RailPath(Km distance)
    {
        Force = Newton.Create(0);
        Distance = distance;
    }

    public override TryPassResult TryPass(IPassengerTrain transport)
    {
        return Rider.Ride(this, transport);
    }

    public static class Rider
    {
        public static TryPassResult Ride(RailPath seg, IPushable transport)
        {
            var passedDist = Km.Create(0);

            while (passedDist.Value < seg.Distance.Value)
            {
                var tickPassedDist = Km.Create(transport.ApplyForce(seg.Force).Value);
                if (tickPassedDist.Value <= 0)
                    return new TryPassResult.InabilityToOvercomeDist();

                passedDist = Km.Create(passedDist.Value + tickPassedDist.Value);
            }

            return new TryPassResult.Success();
        }
    }
}
