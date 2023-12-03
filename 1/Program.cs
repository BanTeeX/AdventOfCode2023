var file = new string[]
{
	"1abc2",
	"pqr3stu8vwx",
	"a1b2c3d4e5f",
	"treb7uchet"
};

var sum = 0;

foreach (var line in file)
{
	var left = line.First(character => char.IsDigit(character));
	var right = line.Last(character => char.IsDigit(character));
	var number = int.Parse($"{left}{right}");
	sum += number;
}

Console.WriteLine(sum);

return sum;
