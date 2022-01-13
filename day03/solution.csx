Console.WriteLine("Day 3");

// string[] lines = System.IO.File.ReadAllLines(@"input-sample.txt");
string[] lines = System.IO.File.ReadAllLines(@"input.txt");

foreach(var line in lines)
{
    int row = 0;
    int col = 0;
    // Console.WriteLine($"Row: {row} | Col: {col}");
    
    HashSet<(int r, int c)> locations = new HashSet<(int r, int c)>();
    var location = (row, col);
    locations.Add(location);

    var directions = line.Select(x => new string(x, 1)).ToArray();

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
}


// Part 2
// Console.WriteLine("Part 2.");


Console.WriteLine("Press any key to exit.");
System.Console.ReadKey();