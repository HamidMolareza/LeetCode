using Algorithm;

namespace TestAlgorithm;

public class TestSolution {
    private readonly Solution _solution = new();

    [Theory]
    [InlineData("Hello World", 5)]
    [InlineData("   fly me   to   the moon  ", 4)]
    [InlineData("luffy is still joyboy", 6)]
    [InlineData("a", 1)]
    [InlineData("abc", 3)]
    public void Method_GiveNumber_ReturnSameNumber(string s, int expected) {
        var actual = _solution.LengthOfLastWord(s);

        Assert.Equal(expected, actual);
    }
}