using static SharedFunctions.SharedFunctions;

if (!GetFileNameFromArgs(args, out string fileName))
{
    return;
}

if (!GetContentFromFile(fileName, out string content))
{
    return;
}

var width = content.IndexOf(Environment.NewLine);
content = content.Replace(Environment.NewLine, "");
var height = content.Length / width;

var currentNumber = string.Empty;
var sum = 0;

var isLastDigit = false;
var isCurrentPart = false;

for (int currentIndex = 0; currentIndex < content.Length; currentIndex++)
{
    var currentCharacter = content[currentIndex];
    var isCurrentDigit = char.IsDigit(content[currentIndex]);

    if (isCurrentDigit)
    {
        currentNumber += currentCharacter;

        if (!isCurrentPart)
        {
            isCurrentPart = CheckIfIsPart(currentIndex, content, width, height);
        }
    }
    else if (isLastDigit)
    {
        if (isCurrentPart)
        {
            sum += int.Parse(currentNumber);
        }

        currentNumber = string.Empty;
        isCurrentPart = false;
    }

    isLastDigit = isCurrentDigit;
}

Console.WriteLine(sum);

static bool CheckIfIsPart(int index, string content, int width, int height)
{
    var row = index / width;
    var col = index % width;

    for (var i = -1; i < 2; i++)
    {
        var newRow = row + i;

        for (int j = -1; j < 2; j++)
        {
            var newCol = col + j;

            if (newRow < 0 || newRow >= height || newCol < 0 || newCol >= width)
            {
                continue;
            }

            var newIndex = newRow * width + newCol;

            if (content[newIndex] != '.' && !char.IsDigit(content[newIndex]))
            {
                return true;
            }
        }
    }

    return false;
}
