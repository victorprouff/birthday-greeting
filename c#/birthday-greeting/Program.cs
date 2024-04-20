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
            Console.WriteLine("Unable to open file '" + fileName + "'");
        }
        catch (IOException)
        {
            Console.WriteLine("Error reading file '" + fileName + "'");
        }

        Console.ReadLine();
    }

    private static void ProcessFile(string[] lines)
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
                }
                else
                {
                    ProcessLine(line);
                }
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

        // Nettoie les éléments en supprimant les espaces
        for (var token = 0; token < tokens.Length; token++)
            tokens[token] = tokens[token].Trim();

        // S'il y a 4 éléments on fait le traitement sinon on throw une exception
        if (tokens.Length == 4)
        {
            // On récupère la date
            var date = tokens[2].Split('/');

            // Si la date ne contient pas 3 éléments on throw une exeption
            if (date.Length == 3)
            {
                // On récupère la date du jour
                var currentDate = DateTime.Now;

                // Si la date d'anniversaire correspond à la date du jour alors on envoie un email
                if (currentDate.Day == int.Parse(date[0]) && currentDate.Month == int.Parse(date[1]))
                {
                    EmailBroker.SendEmail(tokens[3], "Joyeux Anniversaire !",
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