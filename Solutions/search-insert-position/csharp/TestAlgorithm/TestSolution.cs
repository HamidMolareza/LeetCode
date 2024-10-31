using Algorithm;

namespace TestAlgorithm;

public class TestSolution {
    private readonly Solution _solution = new();

    [Theory]
    [InlineData(new int[] { }, 1)]
    [InlineData(new int[] { }, -100)]
    public void SearchInsert_GiveEmptyArray_Return0(int[] nums, int target) {
        var actualIndex = _solution.SearchInsert(nums, target);

        const int expectedIndex = 0;
        Assert.Equal(expectedIndex, actualIndex);
    }

    [Theory]
    [InlineData(new [] { 1 }, 0, 0)]
    [InlineData(new [] { 1 }, 1, 0)]
    [InlineData(new [] { 1 }, 2, 1)]
    public void SearchInsert_SingleItem_ReturnIndex(int[] nums, int target, int expectedIndex) {
        var actualIndex = _solution.SearchInsert(nums, target);
        
        Assert.Equal(expectedIndex, actualIndex);
    }

    [Theory]
    [InlineData(new[] { 1, 3, 5, 6 }, 1, 0)]
    [InlineData(new[] { 1, 3, 5, 6 }, 3, 1)]
    [InlineData(new[] { 1, 3, 5, 6 }, 6, 3)]
    public void SearchInsert_TargetInArray_ReturnIndexOfTarget(int[] nums, int target, int expectedIndex) {
        var actualIndex = _solution.SearchInsert(nums, target);

        Assert.Equal(expectedIndex, actualIndex);
    }

    [Theory]
    [InlineData(new[] { 1, 3, 5, 6 }, 0, 0)]
    [InlineData(new[] { 1, 3, 5, 6 }, 2, 1)]
    [InlineData(new[] { 1, 3, 5, 6 }, 4, 2)]
    [InlineData(new[] { 1, 3, 5, 6 }, 7, 4)]
    public void SearchInsert_TargetNotInArray_ReturnIndex(int[] nums, int target, int expectedIndex) {
        var actualIndex = _solution.SearchInsert(nums, target);

        Assert.Equal(expectedIndex, actualIndex);
    }
}