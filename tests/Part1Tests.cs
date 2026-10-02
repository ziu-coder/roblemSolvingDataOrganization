using ProblemSolving.Part1;
using Xunit;

public class Part1Tests
{
    [Theory]
    [InlineData(1, 2)]
    [InlineData(5, 11)]
    [InlineData(10, 29)]
    public void NthPrime_Works(int n, int expected) =>
        Assert.Equal(expected, BasicAlgorithms.FindNthPrime(n));

    [Fact] public void NthPrime_Invalid() =>
        Assert.Throws<ArgumentOutOfRangeException>(() => BasicAlgorithms.FindNthPrime(0));

    [Theory]
    [InlineData("", "")]
    [InlineData("abc", "cba")]
    [InlineData("Hello", "olleH")]
    public void Reverse_Works(string input, string expected) =>
        Assert.Equal(expected, BasicAlgorithms.ReverseString(input));

    [Theory]
    [InlineData("A man, a plan, a canal: Panama!", true)]
    [InlineData("No lemon, no melon", true)]
    [InlineData("hello", false)]
    public void Palindrome_Works(string input, bool expected) =>
        Assert.Equal(expected, BasicAlgorithms.IsPalindrome(input));

    [Fact] public void KthLargest_Works() =>
        Assert.Equal(5, BasicAlgorithms.FindKthLargest(new[] {3,2,1,5,6,4}, 2));

    [Fact] public void CharacterCount_Works()
    {
        var result = BasicAlgorithms.CountCharacters("aab c");
        Assert.Equal(2, result['a']);
        Assert.Equal(1, result['b']);
        Assert.Equal(1, result[' ']);
    }
}
