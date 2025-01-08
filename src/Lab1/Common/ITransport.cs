namespace Common;

public interface ITransport
{
    void BoardPassengers(float congestion);

    void DisembarkPassengers(float congestion);
}
