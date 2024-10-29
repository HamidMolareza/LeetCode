using Algorithm;

namespace TestAlgorithm;

public class TestSolution {
    private readonly Solution _solution = new();

    [Theory]
    [InlineData(2, 2)]
    [InlineData(3, 3)]
    [InlineData(20, 10946)]
    [InlineData(25, 121393)]
    [InlineData(35, 14930352)]
    [InlineData(45, 1836311903)]
    public void ClimbStairs_GiveNumber_ReturnCountOfStates(int n, int expected) {
        var actual = _solution.ClimbStairs(n);

        Assert.Equal(expected, actual);
    }
}