
using DataStructures.Arrays;

var arr = new Array<int>();
arr.Add(21);
arr.Add(32);
arr.Add(23);
arr.Add(43);
arr.Remove();
arr.Remove();
arr.Add(43);
arr.Add(43);
arr.Add(43);
arr.Remove();
arr.Remove();

foreach (var item in arr)
{
    Console.WriteLine(item);
}

Console.WriteLine($"{arr.Count} / {arr.Capacity}");