namespace birthday_greeting.Tests;

public class EmailMessageTest
{
    private readonly EmailMessage _emailMessage;
    private readonly EmailBrocker _brocker;

    public EmailMessageTest()
    {
        _brocker = new EmailBrocker();
        _emailMessage = new EmailMessage(_brocker);
    }

    [Fact]
    public void SendMail()
    {
        _emailMessage.Send("email@test.fr", "Victor");

        Assert.Equal("email@test.fr", _brocker.Email);
        Assert.Equal("Title: Joyeux Anniversaire !", _brocker.Title);
        Assert.Equal("\nBonjour Victor,\nJoyeux Anniversaire !\nA bientôt,", _brocker.Body);
    }
}