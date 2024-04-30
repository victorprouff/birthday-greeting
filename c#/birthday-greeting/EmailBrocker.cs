namespace birthday_greeting;

public class EmailBrocker
{
    public string Email { get; private set; }
    public string Title { get; private set; }
    public string Body { get; private set; }
    public void SendEmail(string email, string title, string body)
    {
        Email = email;
        Title = title;
        Body = body;

        Console.WriteLine($"Sending email to : {email}");
        Console.WriteLine(title);
        Console.WriteLine($"Body: {body}");
        Console.WriteLine("-------------------------");
    }
}