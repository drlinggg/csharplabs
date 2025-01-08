namespace Presentation.Scenarios.Common;

public interface IScenario
{
    string Name { get; }

    void Run();
}
