namespace birthday_greeting;

public sealed class Employee(string firstName, string lastName, DateTime birthday, string email)
{
    public string FirstName { get; } = firstName;
    public string LastName { get; } = lastName;
    private DateTime Birthday { get; } = birthday;
    public string Email { get; } = email;
    public bool IsBirthday() => Now.Day == Birthday.Day && Now.Month == Birthday.Month;
}