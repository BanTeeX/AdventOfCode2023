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

    var isPossible = true;

    foreach (var round in game)
    {
        var results = round.Split(',');

        foreach (var result in results)
        {
            var color = result.Last();
            var number = int.Parse(result.SkipLast(1).ToArray());

            if (color == 'r' && number > 12
                || color == 'g' && number > 13
                || color == 'b' &&  number > 14)
            {
                isPossible = false;
                break;
            }
        }

		if (!isPossible)
		{
			break;
		}
	}

    if (isPossible)
    {
        sum += gameId;
    }
}

Console.WriteLine(sum);
