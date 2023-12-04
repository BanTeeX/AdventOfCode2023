using static SharedFunctions.SharedFunctions;

if (!GetFileNameFromArgs(args, out string fileName))
{
    return;
}

if (!GetContentFromFile(fileName, out string content))
{
    return;
}

var wordToDigit = new Dictionary<string, int>
{
    { "zero", 0 },
    { "one", 1 },
    { "two", 2 },
    { "three", 3 },
    { "four", 4 },
    { "five", 5 },
    { "six", 6 },
    { "seven", 7 },
    { "eight", 8 },
    { "nine", 9 },
    { "0", 0 },
    { "1", 1 },
    { "2", 2 },
    { "3", 3 },
    { "4", 4 },
    { "5", 5 },
    { "6", 6 },
    { "7", 7 },
    { "8", 8 },
    { "9", 9 }
};

var sum = 0;

foreach (var line in content.Split(Environment.NewLine))
{
    var leftIndex = int.MaxValue;
    var rightIndex = int.MinValue;
    var left = -1;
    var right = -1;
    
    foreach (var item in wordToDigit)
    {
        var firstIndex = line.IndexOf(item.Key);

        if (firstIndex == -1)
        {
            continue;
        }

        var lastIndex = line.LastIndexOf(item.Key);

        if (leftIndex > firstIndex)
        {
            leftIndex = firstIndex;
            left = item.Value;
        }

        if (rightIndex < lastIndex)
        {
            rightIndex = lastIndex;
            right = item.Value;
        }
    }

    if (left == -1)
    {
        continue;
    }

    sum += left * 10 + right;
}

Console.WriteLine($"Result: {sum}");
