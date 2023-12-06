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

var numbers = GetNumbers(lines);
var stars = GetStars(lines);

var sum = stars
    .Select(star =>
        new
        {
            Numbers = numbers
                .Where(number => number.Indexes.Any(index => star.AdjacentIndexes.Contains(index)))
                .Select(number => number.Value)
        })
    .Where(x => x.Numbers.Count() == 2)
    .Sum(x => x.Numbers.Aggregate((number1, number2) => number1 * number2));

Console.WriteLine(sum);

static List<Star> GetStars(string[] lines)
{
    var stars = new List<Star>();
    var adjacentIndexes = new List<(int, int)>();

    for (int row = 0; row < lines.Length; row++)
    {
        for (int col = 0; col < lines[row].Length; col++)
        {
            var character = lines[row][col];

            if (character != '*')
            {
                continue;
            }

            adjacentIndexes.Clear();

            for (int i = -1; i < 2; i++)
            {
                var adjacentRow = row + i;

                if (adjacentRow < 0 || adjacentRow >= lines.Length)
                {
                    continue;
                }

                for (int j = -1; j < 2; j++)
                {
                    var adjacentCol = col + j;

                    if (adjacentCol < 0 || adjacentCol >= lines[row].Length)
                    {
                        continue;
                    }

                    adjacentIndexes.Add((adjacentRow, adjacentCol));
                }
            }

            stars.Add
            (
                new Star
                {
                    Index = (row, col),
                    AdjacentIndexes = adjacentIndexes.ToArray()
                }
            );
        }
    }

    return stars;
}

static List<Number> GetNumbers(string[] lines)
{
    var numbers = new List<Number>();
    var indexes = new List<(int, int)>();
    var isLastDigit = false;
    var number = string.Empty;

    for (int row = 0; row < lines.Length; row++)
    {
        if (number.Length > 0)
        {
            AddNumber(numbers, indexes, ref number);
        }

        isLastDigit = false;
        number = string.Empty;
        indexes.Clear();

        for (int col = 0; col < lines[row].Length; col++)
        {
            var character = lines[row][col];
            var isDigit = char.IsDigit(character);

            if (isDigit)
            {
                number += character;
                indexes.Add((row, col));
            }
            else if (isLastDigit)
            {
                AddNumber(numbers, indexes, ref number);
            }

            isLastDigit = isDigit;
        }
    }

    return numbers;
}

static void AddNumber(List<Number> numbers, List<(int, int)> indexes, ref string number)
{
    numbers.Add
    (
        new Number
        {
            Value = int.Parse(number),
            Indexes = indexes.ToArray(),
        }
    );

    number = string.Empty;
    indexes.Clear();
}

struct Number
{
    public int Value;
    public (int, int)[] Indexes;
}

struct Star
{
    public (int, int) Index;
    public (int, int)[] AdjacentIndexes;
}
