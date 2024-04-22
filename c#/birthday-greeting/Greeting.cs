namespace birthday_greeting;

public class Greeting(IMessage message)
{
    public void LoadFile()
    {
        const string fileName = "employees.txt";

        try
        {
            // Chargement fichier
            var lines = File.ReadAllLines(fileName);

            Console.WriteLine("Reading file...");
            ProcessFile(lines.ToList());

            Console.WriteLine("Batch job done.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Unable to open file '{fileName}'");
        }
        catch (IOException)
        {
            Console.WriteLine($"Error reading file '{fileName}'");
        }

        Console.ReadLine();
    }

    private void ProcessFile(IList<string> lines)
    {
        RemoveFirstLine(lines);

        foreach (var line in lines)
        {
            try
            {
                ProcessLine(line);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }

    private static void RemoveFirstLine(IList<string> lines)
    {
        lines.RemoveAt(0);
    }

    private void ProcessLine(string line)
    {
        var employee = CreateEmployeeFromLineFile(line);

        if (employee.IsBirthday())
        {
            message.Send(employee.Email, employee.FirstName);
        }
    }

    private static Employee CreateEmployeeFromLineFile(string line)
    {
        var tokens = GetElementsLine(line);

        return new Employee(tokens[0], tokens[1], ConvertStringToDateTime(tokens[2]), tokens[3]);
    }

    private static DateTime ConvertStringToDateTime(string token)
    {
        try
        {
            return Convert.ToDateTime(token);
        }
        catch (FormatException)
        {
            throw new Exception("Invalid file format");
        }
    }

    private static string[] GetElementsLine(string line)
    {
        var tokens = line.Split(',').Select(l => l.Trim()).ToArray();
        if (IsTokensLengthValid(tokens))
        {
            return tokens;
        }

        throw new Exception("Invalid file format");
    }

    private static bool IsTokensLengthValid(IReadOnlyCollection<string> tokens) => tokens.Count == 4;

}