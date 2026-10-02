using System.Diagnostics;

namespace ProblemSolving.Part3;

public readonly record struct Point(int Row, int Col);

public record SearchResult(List<Point> Path, int VisitedNodes)
{
    public bool Found => Path.Count > 0;
}

public static class MazePathfinding
{
    private static readonly Point[] Directions =
    {
        new(-1, 0), new(1, 0), new(0, -1), new(0, 1)
    };

    public static SearchResult Bfs(int[,] maze, Point start, Point goal)
    {
        Validate(maze, start, goal);
        var queue = new Queue<Point>();
        var visited = new HashSet<Point> { start };
        var parent = new Dictionary<Point, Point>();
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            if (current == goal) return new(Reconstruct(parent, start, goal), visited.Count);

            foreach (var next in Neighbors(maze, current))
            {
                if (!visited.Add(next)) continue;
                parent[next] = current;
                queue.Enqueue(next);
            }
        }
        return new(new List<Point>(), visited.Count);
    }

    public static SearchResult AStar(int[,] maze, Point start, Point goal)
    {
        Validate(maze, start, goal);
        var open = new PriorityQueue<Point, int>();
        var g = new Dictionary<Point, int> { [start] = 0 };
        var parent = new Dictionary<Point, Point>();
        var closed = new HashSet<Point>();
        open.Enqueue(start, Heuristic(start, goal));

        while (open.Count > 0)
        {
            var current = open.Dequeue();
            if (!closed.Add(current)) continue;
            if (current == goal) return new(Reconstruct(parent, start, goal), closed.Count);

            foreach (var next in Neighbors(maze, current))
            {
                if (closed.Contains(next)) continue;
                int tentative = g[current] + 1;
                if (!g.TryGetValue(next, out int old) || tentative < old)
                {
                    g[next] = tentative;
                    parent[next] = current;
                    open.Enqueue(next, tentative + Heuristic(next, goal));
                }
            }
        }
        return new(new List<Point>(), closed.Count);
    }

    public static (double BfsMs, double AStarMs, SearchResult Bfs, SearchResult AStar)
        Benchmark(int[,] maze, Point start, Point goal, int iterations = 100)
    {
        SearchResult bfs = Bfs(maze, start, goal), astar = AStar(maze, start, goal);
        var sw = Stopwatch.StartNew();
        for (int i = 0; i < iterations; i++) bfs = Bfs(maze, start, goal);
        sw.Stop();
        double bfsMs = sw.Elapsed.TotalMilliseconds / iterations;

        sw.Restart();
        for (int i = 0; i < iterations; i++) astar = AStar(maze, start, goal);
        sw.Stop();
        double aStarMs = sw.Elapsed.TotalMilliseconds / iterations;
        return (bfsMs, aStarMs, bfs, astar);
    }

    private static IEnumerable<Point> Neighbors(int[,] maze, Point p)
    {
        foreach (var d in Directions)
        {
            var n = new Point(p.Row + d.Row, p.Col + d.Col);
            if (n.Row >= 0 && n.Row < maze.GetLength(0) &&
                n.Col >= 0 && n.Col < maze.GetLength(1) &&
                maze[n.Row, n.Col] == 0)
                yield return n;
        }
    }

    private static int Heuristic(Point a, Point b) =>
        Math.Abs(a.Row - b.Row) + Math.Abs(a.Col - b.Col);

    private static List<Point> Reconstruct(Dictionary<Point, Point> parent, Point start, Point goal)
    {
        var path = new List<Point> { goal };
        var current = goal;
        while (current != start)
        {
            current = parent[current];
            path.Add(current);
        }
        path.Reverse();
        return path;
    }

    private static void Validate(int[,] maze, Point start, Point goal)
    {
        ArgumentNullException.ThrowIfNull(maze);
        bool Inside(Point p) => p.Row >= 0 && p.Row < maze.GetLength(0) &&
                                p.Col >= 0 && p.Col < maze.GetLength(1);
        if (!Inside(start) || !Inside(goal)) throw new ArgumentOutOfRangeException();
        if (maze[start.Row, start.Col] != 0 || maze[goal.Row, goal.Col] != 0)
            throw new ArgumentException("Start và goal phải là ô có thể đi.");
    }
}
