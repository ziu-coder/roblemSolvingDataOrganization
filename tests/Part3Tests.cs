using ProblemSolving.Part3;
using Xunit;

public class Part3Tests
{
    [Fact]
    public void BfsAndAStar_FindSameShortestLength()
    {
        int[,] maze =
        {
            {0,0,0,1,0},
            {1,1,0,1,0},
            {0,0,0,0,0},
            {0,1,1,1,0},
            {0,0,0,0,0}
        };
        var start = new Point(0,0);
        var goal = new Point(4,4);
        var bfs = MazePathfinding.Bfs(maze, start, goal);
        var astar = MazePathfinding.AStar(maze, start, goal);
        Assert.True(bfs.Found);
        Assert.True(astar.Found);
        Assert.Equal(bfs.Path.Count, astar.Path.Count);
    }

    [Fact]
    public void NoPath_ReturnsEmptyPath()
    {
        int[,] maze = {{0,1},{1,0}};
        Assert.False(MazePathfinding.Bfs(maze, new Point(0,0), new Point(1,1)).Found);
    }
}
