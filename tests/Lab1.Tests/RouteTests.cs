using Common;
using Models;
using ResultTypes;
using System.Collections.ObjectModel;
using ValueObjects;
using Xunit;

namespace Tests;

public class RouteTests
{
    [Fact]
    public void TryPass_ShouldReturnTrue_WhenSpeedBelowMaxRouteLimit()
    {
        // Arrange
        var segments = new Collection<Segment>();
        segments.Add(new PoweredRailPath(Km.Create(10), Newton.Create(50)));
        segments.Add(new RailPath(Km.Create(10)));
        var train = new Train(Kg.Create(10), Newton.Create(100), Hour.Create(0.00016f));
        var route = new Route(segments, train, KmH.Create(10000));

        // Act
        TryPassResult result = route.TryPass();

        // Assert
        Assert.Equal(result, new TryPassResult.Success());
    }

    [Fact]
    public void TryPass_ShouldReturnFalse_WhenSpeedAboveRouteLimit()
    {
        // Arrange
        var segments = new Collection<Segment>();
        segments.Add(new PoweredRailPath(Km.Create(10), Newton.Create(50)));
        segments.Add(new RailPath(Km.Create(10)));
        var train = new Train(Kg.Create(10), Newton.Create(100), Hour.Create(0.00016f));
        var route = new Route(segments, train, KmH.Create(1));

        // Act
        TryPassResult result = route.TryPass();

        // Assert
        Assert.Equal(result, new TryPassResult.MaxSpeedExceeded(35.9986f));
    }

    [Fact]
    public void TryPass_ShouldReturnTrue_WhenSpeedBelowMaxRouteAndStationLimit()
    {
        // Arrange
        var segments = new Collection<Segment>();
        segments.Add(new PoweredRailPath(Km.Create(10), Newton.Create(50)));
        segments.Add(new RailPath(Km.Create(10)));
        segments.Add(new Station(0, KmH.Create(100)));
        var train = new Train(Kg.Create(10), Newton.Create(100), Hour.Create(0.00016f));
        var route = new Route(segments, train, KmH.Create(100));

        // Act
        TryPassResult result = route.TryPass();

        // Assert
        Assert.Equal(result, new TryPassResult.Success());
    }

    [Fact]
    public void TryPass_ShouldReturnFalse_WhenSpeedAboveStationLimit()
    {
        // Arrange
        var segments = new Collection<Segment>();
        segments.Add(new PoweredRailPath(Km.Create(10), Newton.Create(50)));
        segments.Add(new Station(0, KmH.Create(4)));
        var train = new Train(Kg.Create(10), Newton.Create(100), Hour.Create(0.00016f));
        var route = new Route(segments, train, KmH.Create(100));

        // Act
        TryPassResult result = route.TryPass();

        // Assert
        Assert.Equal(result, new TryPassResult.MaxSpeedExceeded(35.9986f));
    }

    [Fact]
    public void TryPass_ShouldReturnFalse_WhenSpeedBelowStationLimitAboveRouteLimit()
    {
        // Arrange
        var segments = new Collection<Segment>();
        segments.Add(new PoweredRailPath(Km.Create(10), Newton.Create(50)));
        segments.Add(new Station(0, KmH.Create(1000)));
        var train = new Train(Kg.Create(10), Newton.Create(100), Hour.Create(0.00016f));
        var route = new Route(segments, train, KmH.Create(10));

        // Act
        TryPassResult result = route.TryPass();

        // Assert
        Assert.Equal(result, new TryPassResult.MaxSpeedExceeded(35.9986f));
    }

    [Fact]
    public void TryPass_ShouldReturnTrue()
    {
        // Arrange
        var segments = new Collection<Segment>();
        segments.Add(new PoweredRailPath(Km.Create(10), Newton.Create(50)));
        segments.Add(new RailPath(Km.Create(10)));
        segments.Add(new PoweredRailPath(Km.Create(10), Newton.Create(-25)));
        segments.Add(new Station(0, KmH.Create(26)));
        segments.Add(new RailPath(Km.Create(10)));
        segments.Add(new PoweredRailPath(Km.Create(10), Newton.Create(50)));
        segments.Add(new RailPath(Km.Create(10)));
        segments.Add(new PoweredRailPath(Km.Create(10), Newton.Create(-55)));
        var train = new Train(Kg.Create(10), Newton.Create(100), Hour.Create(0.00016f));
        var route = new Route(segments, train, KmH.Create(25));

        // Act
        TryPassResult result = route.TryPass();

        // Assert
        Assert.Equal(result, new TryPassResult.Success());
    }

    [Fact]
    public void TryPass_ShouldReturnFalse_WhenNoAccelerationAtStart()
    {
        // Arrange
        var segments = new Collection<Segment>();
        segments.Add(new RailPath(Km.Create(10)));
        var train = new Train(Kg.Create(10), Newton.Create(100), Hour.Create(0.00016f));
        var route = new Route(segments, train, KmH.Create(1));

        // Act
        TryPassResult result = route.TryPass();

        // Assert
        Assert.Equal(result, new TryPassResult.InabilityToOvercomeDist());
    }

    [Fact]
    public void TryPass_ShouldReturnFalse_WhenInsufficientForce()
    {
        // Arrange
        var segments = new Collection<Segment>();
        segments.Add(new PoweredRailPath(Km.Create(10), Newton.Create(50)));
        segments.Add(new PoweredRailPath(Km.Create(10), Newton.Create(-100)));
        var train = new Train(Kg.Create(10), Newton.Create(100), Hour.Create(0.00016f));
        var route = new Route(segments, train, KmH.Create(1));

        // Act
        TryPassResult result = route.TryPass();

        // Assert
        Assert.Equal(result, new TryPassResult.InabilityToOvercomeDist());
    }
}
