namespace birthday_greeting;

public class EmailMessage(EmailBrocker brocker) : IMessage
{
    public void Send(string to, string firstName)
    {
        brocker.SendEmail(
            to,
            "Title: Joyeux Anniversaire !",
            $"\nBonjour {firstName},\nJoyeux Anniversaire !\nA bientôt,");
    }
}