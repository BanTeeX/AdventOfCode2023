if (args.Length != 1)
{
	Console.WriteLine($"Program needs 1 argument: <filename>");
	return;
}

string[] file;

try
{
	file = File.ReadAllLines(args[0]);
}
catch (Exception e)
{
	Console.WriteLine("Error while reading file:");
	Console.WriteLine(e.Message);
	return;
}

var digitsToWord = new Dictionary<string, int>
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
	{ "nine", 9 }
};

var sum = 0;

foreach (var line in file)
{
	var left = line.FirstOrDefault(char.IsDigit);
	var right = line.LastOrDefault(char.IsDigit);

	if (left == default || right == default)
	{
		continue;
	}

	var number = int.Parse($"{left}{right}");
	sum += number;
}

Console.WriteLine($"Result: {sum}");
