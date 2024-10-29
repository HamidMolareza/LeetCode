using Algorithm;

namespace TestAlgorithm;

public class TestSolution {
    private readonly Solution _solution = new();

    [Theory]
    [InlineData("11", "1", "100")]
    [InlineData("1", "11", "100")]
    [InlineData("1010", "1011", "10101")]
    [InlineData("0", "0", "0")]
    [InlineData("1111", "1111", "11110")]
    public void AddBinary_GiveBinaries_ReturnSumOfThem(string a, string b, string expected) {
        var actual = _solution.AddBinary(a, b);

        Assert.Equal(expected, actual);
    }
}