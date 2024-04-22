namespace birthday_greeting;

public class EmailMessage : IMessage
{
    public void Send(string to, string firstName)
    {
        Console.WriteLine($"Sending email to : {to}");
        Console.WriteLine($"Title: Joyeux Anniversaire !");
        Console.WriteLine($"Body: \nBonjour {firstName},\nJoyeux Anniversaire !\nA bientôt,");
        Console.WriteLine("-------------------------");
    }
}