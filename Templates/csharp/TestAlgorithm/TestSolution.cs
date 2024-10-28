using Algorithm;

namespace TestAlgorithm;

public class TestSolution {
    private readonly Solution _solution = new();

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void Method_GiveNumber_ReturnSameNumber(int code) {
        var actual = _solution.Method(code);

        var expected = code;
        Assert.Equal(expected, actual);
    }
}