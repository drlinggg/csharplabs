using Domain.Accounts.Common;
using Domain.Accounts.Models;
using Domain.Contracts.Accounts;
using Domain.Currencies.Models;
using Domain.Operations.Models;
using Domain.Operations.ResultTypes;
using Moq;
using Xunit;

namespace Tests.Domain.Operations;

public class AccountOperationsTests
{
    [Fact]
    public void CheckBalanceOperation_Success()
    {
        // Arrange
        var mockAccountService = new Mock<IAccountService>();
        var account = new Account(1, Currency.Ruble, 1000);
        mockAccountService.Setup(x => x.GetAccount("usernametest", "testPassword")).Returns(account);
        var mockReceiver = new Mock<IAccount>();
        mockReceiver.Setup(x => x.ShowBalance()).Verifiable();
        var operation = new CheckBalanceOperation(mockReceiver.Object);

        // Act
        ExecuteResult result = operation.Execute();

        // Assert
        Assert.IsType<ExecuteResult.Success>(result);
        mockReceiver.Verify(x => x.ShowBalance(), Times.Once);
    }
}
