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

var sum = 0;

foreach (var line in file)
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
