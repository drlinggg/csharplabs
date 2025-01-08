using Common;
using ValueObjects;

namespace Models;

public class Train : IPassengerTrain
{
    public Newton MaxForce { get; init; }

    public Hour Accurancy { get; init; }

    public KmH Speed { get; protected set; }

    public Kg Weight { get; init; }

    protected float Acceleration { get; set; } // km/h^2

    public class RoutePassedTracker
    {
        public Km DistPassed { get; private set; }

        public Hour TimePassed { get; private set; }

        public void Update(Km tickPassedDist, Hour accurancy)
        {
            DistPassed = Km.Create(DistPassed.Value + tickPassedDist.Value);
            TimePassed = Hour.Create(TimePassed.Value + accurancy.Value);
        }

        public void Update(float congestion)
        {
            TimePassed = Hour.Create(TimePassed.Value + congestion);
        }

        public RoutePassedTracker()
        {
            DistPassed = Km.Create(0);
            TimePassed = Hour.Create(0);
        }
    }

    private readonly RoutePassedTracker routePassedTracker;

    public Km ApplyForce(Newton force)
    {
        float fromMetersPerSecondToKilometersPerMinute = 12.96f;
        Acceleration = force.Value / Weight.Value * fromMetersPerSecondToKilometersPerMinute;
        Speed = KmH.Create(Speed.Value + (Acceleration * Accurancy.Value));
        var tickPassedDist = Km.Create(Speed.Value * Accurancy.Value);
        routePassedTracker.Update(tickPassedDist, Accurancy);

        return tickPassedDist;
    }

    public void DisembarkPassengers(float congestion)
    {
        routePassedTracker.Update(congestion);
    }

    public void BoardPassengers(float congestion)
    {
        routePassedTracker.Update(congestion);
    }

    public Newton CalculateForceToStop()
    {
        float fromMetersPerSecondToKilometersPerMinute = 12.96f;
        return Newton.Create(-Speed.Value * Weight.Value / Accurancy.Value / fromMetersPerSecondToKilometersPerMinute);
    }

    public Train(Kg weight, Newton maxforce, Hour accurancy)
    {
        this.Speed = KmH.Create(0);
        this.Acceleration = 0;
        this.routePassedTracker = new RoutePassedTracker();

        this.Weight = Kg.Create(weight.Value);
        this.MaxForce = Newton.Create(maxforce.Value);
        this.Accurancy = Hour.Create(accurancy.Value);
    }
}
