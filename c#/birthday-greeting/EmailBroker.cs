namespace birthday_greeting;

public class EmailBroker
{
    public void SendMessage(string to, string title, string body)
    {
        Console.WriteLine($"Sending email to : {to}");
        Console.WriteLine($"Title: {title}");
        Console.WriteLine($"Body: Body\n{body}");
        Console.WriteLine("-------------------------");
    }
}