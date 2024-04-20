namespace birthday_greeting;

public static class Program
{
    private static void Main()
    {
        const string fileName = "employees.txt";

        try
        {
            // Chargement fichier
            var lines = File.ReadAllLines(fileName);

            Console.WriteLine("Reading file...");
            ProcessFile(lines);

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

    private static void ProcessFile(IEnumerable<string> lines)
    {
        var firstLine = true;
        // Boucle sur toutes les lignes
        foreach (var line in lines)
        {
            try
            {
                // Si première ligne ne pas faire le traitement
                if (firstLine)
                {
                    firstLine = false;
                    continue;
                }

                ProcessLine(line);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }

    private static void ProcessLine(string line)
    {
        // Découpe chaque ligne en éléments
        var tokens = line.Split(',');

        CleanTokens(tokens);

        if (IsTokensLengthValid(tokens))
        {
            // On récupère la date
            var date = tokens[2].Split('/');

            if (IfDateValid(date))
            {
                if (IsBirthday(date))
                {
                    EmailBroker.SendMessage(
                        tokens[3],
                        "Joyeux Anniversaire !",
                        $"Bonjour {tokens[0]},\nJoyeux Anniversaire !\nA bientôt,");
                }
            }
            else
            {
                throw new Exception($"Cannot read birthdate for {tokens[0]} {tokens[1]}");
            }
        }
        else
        {
            throw new Exception("Invalid file format");
        }
    }

    private static void CleanTokens(IList<string> tokens)
    {
        for (var token = 0; token < tokens.Count; token++)
        {
            tokens[token] = tokens[token].Trim();
        }
    }

    private static bool IsTokensLengthValid(IReadOnlyCollection<string> tokens) => tokens.Count == 4;

    private static bool IsBirthday(IReadOnlyList<string> date) =>
        Now.Day == int.Parse(date[0]) && Now.Month == int.Parse(date[1]);

    private static bool IfDateValid(IReadOnlyCollection<string> date) => date.Count == 3;
}