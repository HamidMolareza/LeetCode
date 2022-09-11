using Solution;

namespace TestProgram;

public class UnitTest {
    [Theory]
    [InlineData("2 7 11 15", 9, "0 1")]
    [InlineData("3 2 4", 6, "1 2")]
    [InlineData("3 3", 6, "0 1")]
    public void TwoSum_StandardInput_ReturnCorrectAnswer(string numbers, int target, string result) {
        //Arrange
        var program = new Program();
        var nums = numbers.Split(" ")
            .Select(num => Convert.ToInt32(num))
            .ToArray();

        //Act
        var output = program.TwoSum(nums, target);
        var output2 = program.TwoSum2(nums, target);

        //Asset
        Assert.Equal(result, string.Join(" ", output));
        Assert.Equal(result, string.Join(" ", output2));
    }
}