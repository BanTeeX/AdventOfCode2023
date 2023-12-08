using static SharedFunctions.SharedFunctions;

if (!GetFileNameFromArgs(args, out string fileName))
{
    return;
}

if (!GetContentFromFile(fileName, out string content))
{
    return;
}

var lines = content.Split(Environment.NewLine);
var sum = 0;

foreach (var line in lines)
{
    var numbersSets = line.Split(":")[1].Split("|");

    var winnig = GetNumbersFromString(numbersSets[0]);
    var choosen = GetNumbersFromString(numbersSets[1]);

    var result = 1;
    foreach (var number in choosen)
    {
        if (winnig.Contains(number))
        {
            result *= 2;
        }
    }

    sum += result / 2;
}

Console.WriteLine(sum);

static IEnumerable<string> GetNumbersFromString(string numbers)
{
    return numbers.Trim().Split(" ").Where(s => !string.IsNullOrWhiteSpace(s));
}
