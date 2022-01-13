Console.WriteLine("Day 3");

// string[] lines = System.IO.File.ReadAllLines(@"input-sample.txt");
// string[] lines = System.IO.File.ReadAllLines(@"input-sample-2.txt");
string[] lines = System.IO.File.ReadAllLines(@"input.txt");

foreach(var line in lines)
{
    var directions = line.Select(x => new string(x, 1)).ToList();
    var locations = CalculateLocations(directions);
}

// Part 2
Console.WriteLine("Part 2.");

foreach(var line in lines)
{
    var directions = line.Select(x => new string(x, 1)).ToList();
    var odds = directions.Where((item, index) => index % 2 != 0).ToList();
    var evens = directions.Where((item, index) => index % 2 == 0).ToList();
    // Console.WriteLine(string.Join(" ", odds));
    // Console.WriteLine(string.Join(" ", evens));
    // Console.WriteLine();

    var oddLocations = CalculateLocations(odds);
    var evenLocations = CalculateLocations(evens);
    var allLocations = new HashSet<(int r, int c)>(oddLocations.Union(evenLocations));
    // var allLocations = oddLocations.UnionWith(evenLocations);
    Console.WriteLine(allLocations.Count);
}


/// <summary>
/// Calculate Locations
/// </summary>
/// <param name="directions">A list of directions (north (`^`), south (`v`), east (`>`), or west (`<`))</param>
/// <returns>A HashSet of locations</returns>
public HashSet<(int r, int c)> CalculateLocations(List<string> directions)
{
    int row = 0;
    int col = 0;
    // Console.WriteLine($"Row: {row} | Col: {col}");
    
    HashSet<(int r, int c)> locations = new HashSet<(int r, int c)>();
    var location = (row, col);
    locations.Add(location);

    foreach(var direction in directions)
    {
        // Console.WriteLine(direction);
        switch (direction) {
            case "^": // North
                row -= 1;
                break;
            case "v": // South
                row += 1;
                break;
            case ">": // East
                col += 1;
                break;
            case "<": // West
                col -= 1;
                break;
            default:
                break;
        }
        // Console.WriteLine($"Row: {row} | Col: {col}");
        locations.Add((row, col));
    }
    // Console.WriteLine("---");
    Console.WriteLine($"Locations #:{locations.Count}");
    return locations;
}

Console.WriteLine("Press any key to exit.");
System.Console.ReadKey();