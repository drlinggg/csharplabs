using Common;
using ResultTypes;
using ValueObjects;

namespace Models;

public class PoweredRailPath : RailPath
{
    public PoweredRailPath(Km distance, Newton force)
        : base(distance)
    {
        Force = force;
    }

    public override TryPassResult TryPass(IPassengerTrain transport)
    {
        if (Force.Value > transport.MaxForce.Value)
            return new TryPassResult.MaxForceExceeded(transport.MaxForce.Value);

        return Rider.Ride(this, transport);
    }
}
