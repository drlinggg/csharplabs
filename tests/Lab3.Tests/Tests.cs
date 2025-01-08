using Addressees;
using Importances;
using Loggers;
using Messages;
using Moq;
using Topics;
using Users;
using Xunit;

namespace Test;

public class Tests
{
    [Fact]
    public void ReceivedMessageShouldBeUnchecked()
    {
        var mark = new User();
        var addresseeMark = new AddresseeUser(mark);
        var topic = new Topic("Student's Club");
        var notion = new Message("Header", "Body", ImportanceLevel.Medium);

        topic.AddAddressee(addresseeMark);
        topic.Post(notion);
        IMessage? message = mark.FindMessage(notion.Id);

        Assert.Equal(notion, message);
    }

    [Fact]
    public void CheckingMessageShoudChangeMessageStatus()
    {
        var mark = new User();
        var addresseeMark = new AddresseeUser(mark);
        var topic = new Topic("Student's Club");
        var notion = new Message("Header", "Body", ImportanceLevel.Medium);

        topic.AddAddressee(addresseeMark);
        topic.Post(notion);
        MarkAsReadResult result = mark.MarkAsRead(notion.Id);

        Assert.Equal(new MarkAsReadResult.Success(), result);
    }

    [Fact]
    public void CheckingCheckedMessage_ShouldReturnFailure()
    {
        var mark = new User();
        var addresseeMark = new AddresseeUser(mark);
        var topic = new Topic("Student's Club");
        var notion = new Message("Header", "Body", ImportanceLevel.Medium);

        topic.AddAddressee(addresseeMark);
        topic.Post(notion);
        mark.MarkAsRead(notion.Id);
        MarkAsReadResult result = mark.MarkAsRead(notion.Id);

        Assert.Equal(new MarkAsReadResult.FailureHasAlreadyBeenRead(notion.Id), result);
    }

    [Fact]
    public void PostingMessageWithLessImportance_ShouldntBeGotten()
    {
        var mark = new User();
        var addresseeMark = new AddresseeUser(mark);
        var addresseeMarkProxy = new AddresseeProxy(addresseeMark, ImportanceLevel.High);
        var topic = new Topic("Student's Club");
        var mock = new Mock<IMessage>();
        mock.Setup(obj => obj.LevelOfImportance).Returns(ImportanceLevel.Medium);
        IMessage notion = mock.Object;

        topic.AddAddressee(addresseeMarkProxy);
        topic.Post(notion);
        IMessage? message = mark.FindMessage(notion.Id);

        Assert.Null(message);
    }

    [Fact]
    public void PostingMessageToTheAddresseesOfTheSameUser_ShouldBeFiltered()
    {
        var mark = new User();
        var addresseeMark = new AddresseeUser(mark);
        var addresseeMarkProxy2 = new AddresseeProxy(addresseeMark, ImportanceLevel.High);
        var notion = new Message("Header", "Body", ImportanceLevel.Medium);

        GetMessageResult firstGet = addresseeMark.GetMessage(notion);
        GetMessageResult secondGet = addresseeMarkProxy2.GetMessage(notion);

        Assert.Equal(new GetMessageResult.FailureImportanceBelowRequired(), secondGet);
    }

    [Fact]
    public void LoggingAddresseeDecoratorWhenGettingMessage_ShouldSaveLog()
    {
        var mark = new User();
        var addresseeMark = new AddresseeUser(mark);
        var mock = new Mock<ILogger>();
        var notion = new Message("Header", "Body", ImportanceLevel.Medium);
        mock.Setup(obj => obj.Log(It.IsAny<IMessage>()));
        ILogger logger = mock.Object;
        var loggingAddresseeMark = new LoggingAddresseeDecorator(addresseeMark, logger);
        var topic = new Topic("Student's Club");

        topic.AddAddressee(loggingAddresseeMark);
        topic.Post(notion);

        mock.Verify(obj => obj.Log(notion), Times.Once);
    }

    [Fact]
    public void MessengerPostTest()
    {
        var mockMessage = new Mock<IMessage>();
        mockMessage.Setup(m => m.Header).Returns("Test Header");
        mockMessage.Setup(m => m.Body).Returns("Test Body");
        mockMessage.Setup(m => m.LevelOfImportance).Returns(ImportanceLevel.Low);

        var messenger = new Messenger();

        var sw = new StringWriter();
        Console.SetOut(sw);
        GetMessageResult result = messenger.GetMessage(mockMessage.Object);
        string expectedOutput = "MESSENGER:\nTest Header\nTest Body\nLow\n\n";
        Assert.Equal(expectedOutput, sw.ToString());
    }
}
