namespace birthday_greeting;

public static class Program
{
    private static void Main()
    {
        const string fileName = "employees.txt";

        try
        {
            var lines = File.ReadAllLines(fileName);

            Console.WriteLine("Reading file...");
            var firstLine = true;
            foreach (var line in lines)
            {
                try
                {
                    if (firstLine)
                    {
                        firstLine = false;
                    }
                    else
                    {
                        var tokens = line.Split(',');
                        for (var token = 0; token < tokens.Length; token++)
                            tokens[token] = tokens[token].Trim();

                        if (tokens.Length == 4)
                        {
                            var date = tokens[2].Split('/');
                            if (date.Length == 3)
                            {
                                var cal = DateTime.Now;

                                if (cal.Day == int.Parse(date[0]) && cal.Month == int.Parse(date[1]))
                                {
                                    SendEmail(tokens[3], "Joyeux Anniversaire !",
                                        "Bonjour " + tokens[0] + ",\nJoyeux Anniversaire !\nA bientôt,");
                                }
                            }
                            else
                            {
                                throw new Exception("Cannot read birthdate for " + tokens[0] + " " + tokens[1]);
                            }
                        }
                        else
                        {
                            throw new Exception("Invalid file format");
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }

            Console.WriteLine("Batch job done.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Unable to open file '" + fileName + "'");
        }
        catch (IOException)
        {
            Console.WriteLine("Error reading file '" + fileName + "'");
        }

        Console.ReadLine();
    }

    private static void SendEmail(string to, string title, string body)
    {
        Console.WriteLine("Sending email to : " + to);
        Console.WriteLine("Title: " + title);
        Console.WriteLine("Body: Body\n" + body);
        Console.WriteLine("-------------------------");
    }
}