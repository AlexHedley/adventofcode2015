using System.Security.Cryptography;

Console.WriteLine("Day 4");

// string[] lines = System.IO.File.ReadAllLines(@"input-sample.txt");
string[] lines = System.IO.File.ReadAllLines(@"input.txt");

foreach(var line in lines)
{   
    Console.WriteLine($"{line}");
    var part1 = CalculateAnswer(line);
    Console.WriteLine(part1);
}

// Part 2
Console.WriteLine("Part 2.");

foreach(var line in lines)
{
    Console.WriteLine($"{line}");
    var part2 = CalculateAnswer(line, 6, true);
    Console.WriteLine(part2);
}

Console.WriteLine("Press any key to exit.");
System.Console.ReadKey();

/// --- --- --- ---

// // Testing
// string hash1 = Md5("abcdef609043");  // 000001dbbfa
// Console.WriteLine(hash1);            // 000001DBBFA3A5C83A2D506429C7B00E

// string hash11 = Md5("abcdef1");  // 
// Console.WriteLine(hash11);       // 5F8B62A2DCED0CD28946A9C891FF3E5E

// string hash2 = Md5("pqrstuv1048970");    // 000006136ef
// Console.WriteLine(hash2);                // 000006136EF2FF3B291C85725F17325C

/// <summary>
/// Calculate Answer
/// </summary>
/// <param name="secretKey">The input key</param>
/// <param name="numberOfZeros">The number of zeros the hash must begin with</param>
/// <param name="printProgress"></param>
/// <returns>The number required to add to the secret</returns>
public int CalculateAnswer(string secretKey, int numberOfZeros = 5, bool printProgress = false)
{
    var x = 0;
    while (true)
    {
        var input = $"{secretKey}{x}"; 
        // Console.WriteLine(input);

        string hash = Md5(input);
        var start = hash.Substring(0, numberOfZeros);
        // Console.WriteLine($"Start: {start}");
        if (start == "00000") {
            Console.WriteLine($"{secretKey} {x} => {hash}");
            
            return x;
        }
        x++;

        if (printProgress)
            if (x % 100000 == 0) Console.WriteLine(x);
    }
}

/// <summary>
/// Md5
/// </summary>
/// <param name="input"></param>
/// <param name="isLowercase"></param>
/// <returns>A an MD5 hash of the input</returns>
public static string Md5(string input, bool isLowercase = false)
{
    using (var md5 = MD5.Create())
    {
        var byteHash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
        var hash = BitConverter.ToString(byteHash).Replace("-", "");
        return (isLowercase) ? hash.ToLower() : hash;
    }
}
