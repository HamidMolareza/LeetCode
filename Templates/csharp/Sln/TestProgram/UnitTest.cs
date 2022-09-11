using Solution;

namespace TestProgram;

public class UnitTest
{
    [Fact]
    public void Test1() {
        var program = new Program();
    }
    
    [Theory]
    [InlineData()]
    public void Test2() {
        var program = new Program();
    }
}