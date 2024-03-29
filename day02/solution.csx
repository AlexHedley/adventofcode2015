Console.WriteLine("Day 2");

// string[] lines = System.IO.File.ReadAllLines(@"input-sample.txt");
string[] lines = System.IO.File.ReadAllLines(@"input.txt");

// var sum = 0;
// // var items = new List<int>();

// foreach(var line in lines)
// {
//     (int l, int w, int h) dimensions = line.Split("x") switch { var a => (Int32.Parse(a[0]), Int32.Parse(a[1]), Int32.Parse(a[2])) };
//     var total = PaperOrder(dimensions.l, dimensions.w, dimensions.h);
//     // items.Add(total);
//     sum += total;
// }

// Console.WriteLine(sum);
// // Console.WriteLine(items.Sum());

// Testing

// var l = 0; // length 
// var w = 0; // width
// var h = 0; // height

// // 2*l*w + 2*w*h + 2*h*l
// // smallestSide = new[] { (l*w),(w*h),(h*l) }.Min();

// l = 2;
// w = 3;
// h = 4;

// var total = PaperOrder(l, w, h);
// Console.WriteLine($"Total: {total}");

// l = 1;
// w = 1;
// h = 10;

// total = PaperOrder(l, w, h);
// Console.WriteLine($"Total: {total}");

// Paper Order
public int PaperOrder(int l, int w, int h)
{
    var surfaceArea = (2*l*w) + (2*w*h) + (2*h*l);
    Console.WriteLine($"Surface Area: {surfaceArea}");

    var smallestSide = new[] { (l*w),(w*h),(h*l) }.Min();
    Console.WriteLine($"Smallest Side: {smallestSide}");

    var total = surfaceArea + smallestSide;
    Console.WriteLine($"Total: {total}");

    return total;
}

// Part 2
Console.WriteLine("Part 2.");

// // Testing
// var l = 2;
// var w = 3;
// var h = 4;

// var total = RibbonOrder(l, w, h);
// Console.WriteLine($"Total: {total}");

var sum = 0;
// var items = new List<int>();

foreach(var line in lines)
{
    (int l, int w, int h) dimensions = line.Split("x") switch { var a => (Int32.Parse(a[0]), Int32.Parse(a[1]), Int32.Parse(a[2])) };
    var total = RibbonOrder(dimensions.l, dimensions.w, dimensions.h);
    // items.Add(total);
    sum += total;
}

Console.WriteLine(sum);
// Console.WriteLine(items.Sum());

// Ribbon Order
public int RibbonOrder(int l, int w, int h)
{
    var dimensions = new List<int>{ l, w, h };
    var min = dimensions.Min();
    Console.WriteLine($"Min: {min}");
    dimensions.Remove(min);
    var secondMin = dimensions.Min();
    Console.WriteLine($"Second Min: {secondMin}");

    var ribbon = (min*2)+(secondMin*2);
    Console.WriteLine($"Ribbon: {ribbon}");

    var bow = l*w*h;
    Console.WriteLine($"Bow: {bow}");

    var total = ribbon + bow;
    Console.WriteLine($"Total: {total}");

    return total;
}

Console.WriteLine("Press any key to exit.");
System.Console.ReadKey();