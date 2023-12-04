using static SharedFunctions.SharedFunctions;

if (!GetFileNameFromArgs(args, out string fileName))
{
    return;
}

if (!GetContentFromFile(fileName, out string content))
{
    return;
}

var clearedContent = content
        .Replace("Game", "")
        .Replace("ed", "")
        .Replace("reen", "")
        .Replace("lue", "")
        .Replace(" ", "");

var sum = 0;

foreach (var line in clearedContent.Split(Environment.NewLine))
{
    var splited = line.Split(':');
    var gameId = int.Parse(splited[0]);
    var game = splited[1].Split(';');

	var colors = new Dictionary<char, int>()
	{
		{ 'r', 0 },
		{ 'g', 0 },
		{ 'b', 0 }
	};

	foreach (var round in game)
    {
        var results = round.Split(',');

        foreach (var result in results)
        {
            var color = result.Last();
            var number = int.Parse(result.SkipLast(1).ToArray());

            colors[color] = int.Max(colors[color], number);
        }
    }

    sum += colors.Values.Aggregate((x, y) => x * y);
}

Console.WriteLine(sum);
