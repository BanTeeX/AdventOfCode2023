using static SharedFunctions.SharedFunctions;

if (!GetFileNameFromArgs(args, out string fileName))
{
    return;
}

if (!GetContentFromFile(fileName, out string content))
{
    return;
}

var sum = 0;

foreach (var line in content.Split(Environment.NewLine))
{
    var left = line.FirstOrDefault(char.IsDigit);

    if (left == default)
    {
        continue;
    }

    var right = line.LastOrDefault(char.IsDigit);

    var number = int.Parse($"{left}{right}");
    sum += number;
}

Console.WriteLine($"Result: {sum}");
