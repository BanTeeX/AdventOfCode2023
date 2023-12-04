namespace SharedFunctions;

public static class SharedFunctions
{
    public static bool GetFileNameFromArgs(string[] args, out string fileName)
    {
        if (args.Length != 1)
        {
            Console.WriteLine($"Program needs 1 argument: <filename>");
            fileName = string.Empty;
            return false;
        }

        fileName = args[0];
        return true;
    }

    public static bool GetContentFromFile(string fileName, out string content)
    {
        content = string.Empty;

        try
        {
            content = File.ReadAllText(fileName);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error while reading file:");
            Console.WriteLine(e.Message);
            return false;
        }

        return true;
    }
}
