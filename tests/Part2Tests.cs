using ProblemSolving.Part2;
using Xunit;

public class Part2Tests
{
    [Fact]
    public void ContactManager_CRUD()
    {
        var manager = new ContactManager();
        manager.Add(new Contact("An", "0901", "an@test.com"));
        Assert.Equal("0901", manager.Find("an")!.Phone);
        manager.Update("AN", "0902", "new@test.com");
        Assert.Equal("0902", manager.Find("An")!.Phone);
        Assert.True(manager.Remove("an"));
        Assert.Null(manager.Find("An"));
    }

    [Fact]
    public void Lru_EvictsLeastRecentlyUsed()
    {
        var cache = new LruCache<int, string>(2);
        cache.Put(1, "A");
        cache.Put(2, "B");
        Assert.True(cache.TryGet(1, out _)); // 1 becomes recent
        cache.Put(3, "C");                   // evicts 2
        Assert.False(cache.TryGet(2, out _));
        Assert.True(cache.TryGet(1, out var value));
        Assert.Equal("A", value);
    }

    [Fact]
    public void PriorityQueue_HighPriorityFirst()
    {
        var q = new TaskPriorityQueue();
        q.Enqueue("low", 1);
        q.Enqueue("high", 10);
        q.Enqueue("medium", 5);
        Assert.Equal("high", q.Dequeue().Name);
        Assert.Equal("medium", q.Dequeue().Name);
    }
}
