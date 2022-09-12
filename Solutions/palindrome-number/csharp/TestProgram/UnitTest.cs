using Solution;

namespace TestProgram;

public class UnitTest {
    [Theory]
    [InlineData(121)]
    [InlineData(11)]
    [InlineData(1234321)]
    public void IsPalindrome_ValidInput_ReturnTrue(int number) {
        var program = new Program();

        var isPalindrome = program.Program_ConvertToString(number);
        var isPalindrome2 = program.IsPalindrome_WithoutConvertToString(number);

        Assert.True(isPalindrome);
        Assert.True(isPalindrome2);
    }

    [Theory]
    [InlineData(-121)]
    [InlineData(10)]
    [InlineData(12343212)]
    public void IsPalindrome_InValidInput_ReturnFalse(int number) {
        var program = new Program();

        var isPalindrome = program.Program_ConvertToString(number);
        var isPalindrome2 = program.IsPalindrome_WithoutConvertToString(number);

        Assert.False(isPalindrome);
        Assert.False(isPalindrome2);
    }
}