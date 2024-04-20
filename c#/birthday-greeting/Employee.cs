namespace birthday_greeting;

public sealed class Employee(string firstName, string lastName, Date birthday, string email)
{
    public string FirstName { get; } = firstName;
    public string LastName { get; } = lastName;
    public Date Birthday { get; } = birthday;
    public string Email { get; } = email;
}

public sealed class Date(string value)
{
    public string Value { get; } = value;
}