namespace birthday_greeting;

public static class EmailBroker
{
    public static void SendEmail(string to, string title, string body)
    {
        Console.WriteLine("Sending email to : " + to);
        Console.WriteLine("Title: " + title);
        Console.WriteLine("Body: Body\n" + body);
        Console.WriteLine("-------------------------");
    }
}