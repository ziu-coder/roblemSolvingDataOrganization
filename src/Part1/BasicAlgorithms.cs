namespace ProblemSolving.Part1;

public static class BasicAlgorithms
{
    public static int FindNthPrime(int n)
    {
        if (n <= 0) throw new ArgumentOutOfRangeException(nameof(n));
        int count = 0, value = 1;
        while (count < n)
        {
            value++;
            if (IsPrime(value)) count++;
        }
        return value;
    }

    private static bool IsPrime(int n)
    {
        if (n < 2) return false;
        if (n == 2) return true;
        if (n % 2 == 0) return false;
        for (int i = 3; i <= n / i; i += 2)
            if (n % i == 0) return false;
        return true;
    }

    public static string ReverseString(string input)
    {
        ArgumentNullException.ThrowIfNull(input);
        char[] result = new char[input.Length];
        for (int i = 0; i < input.Length; i++)
            result[i] = input[input.Length - 1 - i];
        return new string(result);
    }

    public static bool IsPalindrome(string input)
    {
        ArgumentNullException.ThrowIfNull(input);
        int left = 0, right = input.Length - 1;
        while (left < right)
        {
            while (left < right && !char.IsLetterOrDigit(input[left])) left++;
            while (left < right && !char.IsLetterOrDigit(input[right])) right--;
            if (char.ToLowerInvariant(input[left]) != char.ToLowerInvariant(input[right]))
                return false;
            left++; right--;
        }
        return true;
    }

    public static int FindKthLargest(int[] numbers, int k)
    {
        ArgumentNullException.ThrowIfNull(numbers);
        if (k < 1 || k > numbers.Length) throw new ArgumentOutOfRangeException(nameof(k));
        var heap = new PriorityQueue<int, int>();
        foreach (int n in numbers)
        {
            heap.Enqueue(n, n);
            if (heap.Count > k) heap.Dequeue();
        }
        return heap.Peek();
    }

    public static Dictionary<char, int> CountCharacters(string input)
    {
        ArgumentNullException.ThrowIfNull(input);
        var counts = new Dictionary<char, int>();
        foreach (char c in input)
            counts[c] = counts.GetValueOrDefault(c) + 1;
        return counts;
    }
}
