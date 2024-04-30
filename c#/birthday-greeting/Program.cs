namespace birthday_greeting;

public static class Program
{
    private static void Main()
    {
        var greeting = new Greeting(new EmailMessage(new EmailBrocker()));
        greeting.LoadFile();
    }
}