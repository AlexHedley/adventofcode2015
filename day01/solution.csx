Console.WriteLine("Day 1");

// string[] lines = System.IO.File.ReadAllLines(@"input-sample.txt");
string[] lines = System.IO.File.ReadAllLines(@"input.txt");

var directions = lines[0].Select(x => new string(x, 1)).ToArray();
// directions.ToList().ForEach(Console.WriteLine);
Console.WriteLine(string.Join(" ", directions));

var counter = 0;
var floor = 0;
foreach(var direction in directions)
{
    counter++;
    switch (direction)
    {
        case "(": // UP
            floor++;
            break;
        case ")": // DOWN
            floor--;
            break;
        default:
            break;
    }
    if (floor == -1) Console.WriteLine($"Position: {counter}");
}

Console.WriteLine($"Floor: {floor}");

// Part 2
// Console.WriteLine("Part 2.");

Console.WriteLine("Press any key to exit.");
System.Console.ReadKey();