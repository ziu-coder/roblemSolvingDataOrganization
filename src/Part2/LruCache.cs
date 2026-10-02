namespace ProblemSolving.Part2;

public class LruCache<TKey, TValue> where TKey : notnull
{
    private readonly int capacity;
    private readonly Dictionary<TKey, LinkedListNode<(TKey Key, TValue Value)>> map = new();
    private readonly LinkedList<(TKey Key, TValue Value)> order = new();

    public LruCache(int capacity)
    {
        if (capacity <= 0) throw new ArgumentOutOfRangeException(nameof(capacity));
        this.capacity = capacity;
    }

    public int Count => map.Count;

    public bool TryGet(TKey key, out TValue? value)
    {
        if (!map.TryGetValue(key, out var node))
        {
            value = default;
            return false;
        }
        order.Remove(node);
        order.AddFirst(node);
        value = node.Value.Value;
        return true;
    }

    public void Put(TKey key, TValue value)
    {
        if (map.TryGetValue(key, out var existing))
        {
            existing.Value = (key, value);
            order.Remove(existing);
            order.AddFirst(existing);
            return;
        }

        var node = order.AddFirst((key, value));
        map[key] = node;

        if (map.Count > capacity)
        {
            var last = order.Last!;
            map.Remove(last.Value.Key);
            order.RemoveLast();
        }
    }
}
