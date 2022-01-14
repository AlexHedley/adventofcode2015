using System.Security.Cryptography;

Console.WriteLine("Day 4");

// string[] lines = System.IO.File.ReadAllLines(@"input-sample.txt");
string[] lines = System.IO.File.ReadAllLines(@"input.txt");

foreach(var line in lines)
{   
    Console.WriteLine($"{line}");
    var x = 0;
    while (true)
    {
        var input = $"{line}{x}"; 
        // Console.WriteLine(input);

        string hash = Md5(input);
        var start = hash.Substring(0, 5);
        // Console.WriteLine($"Start: {start}");
        if (start == "00000") {
            Console.WriteLine($"{line} {x} => {hash}");
            break;
        }
        x++;

        if (x % 100000 == 0) Console.WriteLine(x);
    }
}

// // Testing
// string hash1 = Md5("abcdef609043");  // 000001dbbfa
// Console.WriteLine(hash1);            // 000001DBBFA3A5C83A2D506429C7B00E

// string hash11 = Md5("abcdef1");  // 
// Console.WriteLine(hash11);       // 5F8B62A2DCED0CD28946A9C891FF3E5E

// string hash2 = Md5("pqrstuv1048970");    // 000006136ef
// Console.WriteLine(hash2);                // 000006136EF2FF3B291C85725F17325C

/// <summary>
/// Md5
/// </summary>
/// <param name="input"></param>
/// <param name="isLowercase"></param>
/// <returns>A HashSet of locations</returns>
public static string Md5(string input, bool isLowercase = false)
{
    using (var md5 = MD5.Create())
    {
        var byteHash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
        var hash = BitConverter.ToString(byteHash).Replace("-", "");
        return (isLowercase) ? hash.ToLower() : hash;
    }
}

// Part 2
// Console.WriteLine("Part 2.");


Console.WriteLine("Press any key to exit.");
System.Console.ReadKey();