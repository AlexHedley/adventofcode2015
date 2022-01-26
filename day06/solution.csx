Console.WriteLine("Day 6");

// string[] lines = System.IO.File.ReadAllLines(@"input-sample.txt");
string[] lines = System.IO.File.ReadAllLines(@"input.txt");

void Part1()
{
    int[,] matrix = new int[1000, 1000];
    // PrintMatrix(matrix);

    foreach(var line in lines)
    {
        var instructions = ParseInstructions(line);
        var coords = new List<(int row, int col)>();

        switch (instructions[1]) {
            case "on":
                coords = CalculateCoords(instructions[2], instructions[4]);

                foreach (var coord in coords)
                {
                    TurnOn(ref matrix, coord.row, coord.col);
                }
                break;
            case "off":
                coords = CalculateCoords(instructions[2], instructions[4]);

                foreach (var coord in coords)
                {
                    TurnOff(ref matrix, coord.row, coord.col);
                }
                break;
            default: // toggle
                coords = CalculateCoords(instructions[1], instructions[3]);

                foreach (var coord in coords)
                {
                    Toggle(ref matrix, coord.row, coord.col);
                }
                break;
        }
    }

    Console.WriteLine($"Matrix Count #:{matrix.Length}");
    var on = CountLights(matrix, 1);
    Console.WriteLine($"Number of lights on #:{on}");
    var off = CountLights(matrix, 0);
    Console.WriteLine($"Number of lights off #:{off}");
    Console.WriteLine($"Diff: {matrix.Length-on}");
}

Part1();

// Part 2
// Console.WriteLine("Part 2.");

// void Part2()
// {}

// Part2()



Console.WriteLine("Press any key to exit.");
System.Console.ReadKey();

// --- --- ---

/// <summary>
/// Parse Instructions
/// </summary>
/// <param name="line"></param>
/// <returns>An array of instructions</returns>
string[] ParseInstructions(string line)
{
    var instructions = line.Split(' ');
    // Console.WriteLine(String.Join(", ", instructions));
    return instructions;
}

/// <summary>
/// Print Matrix
/// </summary>
/// <param name="matrix"></param>
public void PrintMatrix(int[,] matrix)
{
    int rowLength = matrix.GetLength(0);
    int colLength = matrix.GetLength(1);

    for (int i = 0; i < rowLength; i++)
    {
        for (int j = 0; j < colLength; j++)
        {
            if (matrix[i, j] == 1)
                Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{matrix[i, j]} ");
            Console.ResetColor();
        }
        Console.Write(Environment.NewLine);
    }
}

/// <summary>
/// Count Lights
/// </summary>
/// <param name="matrix"></param>
/// <param name="position">on (1) | off (0)</param>
/// <returns>The number of lights in a given position</returns>
public int CountLights(int[,] matrix, int position)
{
    int counter = 0;
    int rowLength = matrix.GetLength(0);
    int colLength = matrix.GetLength(1);

    for (int i = 0; i < rowLength; i++)
    {
        for (int j = 0; j < colLength; j++)
        {
            if (matrix[i, j] == position)
                counter++;
        }
    }
    return counter;
}

/// <summary>
/// Turn On
/// </summary>
/// <param name="matrix"></param>
/// <param name="row"></param>
/// <param name="col"></param>
public void TurnOn(ref int[,] matrix, int row, int col)
{
    matrix[row, col] = 1;
}

/// <summary>
/// Turn Off
/// </summary>
/// <param name="matrix"></param>
/// <param name="row"></param>
/// <param name="col"></param>
public void TurnOff(ref int[,] matrix, int row, int col)
{
    matrix[row, col] = 0;
}

/// <summary>
/// Toggle
/// </summary>
/// <param name="matrix"></param>
/// <param name="row"></param>
/// <param name="col"></param>
public void Toggle(ref int[,] matrix, int row, int col)
{
    var currentValue = matrix[row, col];
    matrix[row, col] = (currentValue == 0) ? 1 : 0;
}

/// <summary>
/// Bounds Range
/// </summary>
/// <param name="lower"></param>
/// <param name="upper"></param>
/// <returns>A list of ints</returns>
List<int> BoundsRange(int lower, int upper)
{
    if (lower > upper)
        return Enumerable.Range(upper, lower-upper+1).ToList();
    return Enumerable.Range(lower, upper-lower+1).ToList();
}

/// <summary>
/// Calculate Coords
/// </summary>
/// <param name="pair1"></param>
/// <param name="pair2"></param>
/// <returns>A list of coords</returns>
public List<(int row, int col)> CalculateCoords(string pair1, string pair2)
{
    var coords = new List<(int row, int col)>();

    var start = pair1.Split(',');
    var end = pair2.Split(',');
    var start1 = Int32.Parse(start[0]);
    var start2 = Int32.Parse(end[0]);
    // Console.WriteLine($"Start 1: {start1} : Start 2: {start2}");
    var end1 = Int32.Parse(start[1]);
    var end2 = Int32.Parse(end[1]);
    // Console.WriteLine($"End 1: {end1} : End 2: {end2}");

    var lower = new List<int>();
    var upper = new List<int>();
    lower = BoundsRange(start1, start2);
    upper = BoundsRange(end1, end2);

    foreach (var l in lower)
    {
        foreach (var u in upper)
        {
            // Console.WriteLine($"{l},{u}");
            coords.Add((l, u));
        }
    }

    return coords;
}