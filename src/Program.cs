using ProblemSolving.Part1;
using ProblemSolving.Part2;
using ProblemSolving.Part3;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("=== PROBLEM SOLVING & DATA ORGANIZATION ===");
Console.WriteLine($"Số nguyên tố thứ 10: {BasicAlgorithms.FindNthPrime(10)}");
Console.WriteLine($"Đảo 'Hello': {BasicAlgorithms.ReverseString("Hello")}");
Console.WriteLine($"Palindrome: {BasicAlgorithms.IsPalindrome("A man, a plan, a canal: Panama!")}");

int[,] maze =
{
    {0,0,0,1,0,0},
    {1,1,0,1,0,1},
    {0,0,0,0,0,0},
    {0,1,1,1,1,0},
    {0,0,0,0,0,0}
};
var start = new Point(0,0);
var goal = new Point(4,5);
var benchmark = MazePathfinding.Benchmark(maze, start, goal, 1000);

Console.WriteLine("\n=== BENCHMARK MÊ CUNG ===");
Console.WriteLine($"BFS: {benchmark.BfsMs:F4} ms/lần | visited={benchmark.Bfs.VisitedNodes} | path={benchmark.Bfs.Path.Count}");
Console.WriteLine($"A*:  {benchmark.AStarMs:F4} ms/lần | visited={benchmark.AStar.VisitedNodes} | path={benchmark.AStar.Path.Count}");
