using Common;
using ResultTypes;
using ValueObjects;

namespace Models;

public class Station : Segment
{
    protected int Congestion { get; init; }

    protected override Km Distance { get; init; }

    private readonly PowerModule stationPowerModule;

    public Station(int congestion, KmH speedLimit)
    {
        Distance = Km.Create(0);

        stationPowerModule = new PowerModule(speedLimit);
        Congestion = congestion;
    }

    public class PowerModule
    {
        private KmH SpeedLimit { get; init; }

        private KmH lastSavedSpeed = KmH.Create(0);

        public PowerModule(KmH speedLimit)
        {
            SpeedLimit = speedLimit;
        }

        public TryPassResult TryStopTransport(IPushable transport)
        {
            if (SpeedLimit.Value < transport.Speed.Value)
                return new TryPassResult.MaxSpeedExceeded(transport.Speed.Value);

            lastSavedSpeed = KmH.Create(transport.Speed.Value);
            Newton needForce = transport.CalculateForceToStop();
            transport.ApplyForce(needForce);
            return new TryPassResult.Success();
        }

        public void StartTransport(IPushable transport)
        {
            transport.ApplyForce(Newton.Create(transport.Weight.Value * lastSavedSpeed.Value / transport.Accurancy.Value / 12.96f));
        }
   }

    public override TryPassResult TryPass(IPassengerTrain transport)
    {
        TryPassResult result = stationPowerModule.TryStopTransport(transport);
        if (result is not TryPassResult.Success)
            return result;
        transport.DisembarkPassengers(Congestion);
        transport.BoardPassengers(Congestion);
        stationPowerModule.StartTransport(transport);
        return new TryPassResult.Success();
    }
}
