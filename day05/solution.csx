using System.Text.RegularExpressions;

Console.WriteLine("Day 5");

// string[] lines = System.IO.File.ReadAllLines(@"input-sample.txt");
string[] lines = System.IO.File.ReadAllLines(@"input.txt");

// Console.Write($"Lines #: {lines.Count()}");

var niceCount = 0;
foreach (var line in lines)
{
    var isNice = CheckString(line);
    Console.WriteLine($"{line}: {isNice}");
    niceCount += isNice ? 1 : 0;
}

Console.WriteLine($"Lines #: {lines.Count()}");
Console.WriteLine(niceCount);

// Part 2
// Console.WriteLine("Part 2.");


Console.WriteLine("Press any key to exit.");
System.Console.ReadKey();

/// --- --- --- ---

/// <summary>
/// Check String
/// </summary>
/// <param name="input">The input</param>
/// <returns>T = Nice | F = Naughty</returns>
public bool CheckString(string input)
{
    Console.WriteLine($"Input: {input}");

    var requiredVowels = CountVowels(input);
    Console.WriteLine($"Vowels: {requiredVowels}");
    if (requiredVowels < 3) return false;

    var requiredDouble = ContainsDouble(input);
    Console.WriteLine($"Doubled: {requiredDouble}");
    if (!requiredDouble) return false;

    var containsBadStrings = ContainsBadStrings(input);
    Console.WriteLine($"Contains Bad Strings: {containsBadStrings}");

    return !containsBadStrings;
}

/// <summary>
/// Count Vowels
/// </summary>
/// <param name="input">The input</param>
/// <returns>The number of vowels in a string</returns>
public int CountVowels(string input)
{
    return Regex.Matches(input, @"[AEIOUaeiou]").Count;
}

/// <summary>
/// Contains Double
/// </summary>
/// <param name="input">The input</param>
/// <returns>T/F whether it contains duplicates</returns>
public bool ContainsDouble(string input)
{
    return input.Where( (c,i) => i > 0 && c == input[i-1] )
                                        .Cast<char?>()
                                        .FirstOrDefault() != null
                                        ;
}

/// <summary>
/// Contains Bad Strings
/// </summary>
/// <param name="input">The input</param>
/// <returns>T/F whether it contains bad strings</returns>
public bool ContainsBadStrings(string input)
{
    var badStrings = new string[] { "ab", "cd", "pq", "xy" };
    // return Array.Exists(badStrings, s => s == input);
    return badStrings.Any(s => input.Contains(s));
}