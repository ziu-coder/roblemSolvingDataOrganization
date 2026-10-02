namespace ProblemSolving.Part2;

public record ScheduledTask(string Name, int Priority);

public class TaskPriorityQueue
{
    private readonly PriorityQueue<ScheduledTask, int> queue = new();

    public int Count => queue.Count;

    public void Enqueue(string name, int priority)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Tên task không được để trống.");
        queue.Enqueue(new ScheduledTask(name, priority), -priority);
    }

    public ScheduledTask Dequeue()
    {
        if (queue.Count == 0) throw new InvalidOperationException("Queue rỗng.");
        return queue.Dequeue();
    }

    public ScheduledTask Peek()
    {
        if (queue.Count == 0) throw new InvalidOperationException("Queue rỗng.");
        return queue.Peek();
    }
}
