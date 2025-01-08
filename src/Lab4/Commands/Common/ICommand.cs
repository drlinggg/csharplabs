using Flags.Common;
using ResultTypes.CommandResults;

namespace Commands.Common;

public interface ICommand
{
    public ExecuteResult Execute();

    public IFlag? Handle(IEnumerator<string> request);
}
