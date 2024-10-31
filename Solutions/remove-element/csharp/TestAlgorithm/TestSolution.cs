using Algorithm;

namespace TestAlgorithm;

public class TestSolution {
    private readonly Solution _solution = new();

    [Theory]
    [InlineData(new int[] { }, 1, new int[] { }, 0)]
    [InlineData(new int[] { }, 10, new int[] { }, 0)]
    public void RemoveElement_GiveEmptyArray_ReturnEmptyArray(int[] nums, int val, int[] expectedArray,
        int expectedSize) {
        var actualSize = _solution.RemoveElement(nums, val);

        AssertArray(nums, expectedArray, expectedSize);
        Assert.Equal(expectedSize, actualSize);
    }

    private static void AssertArray(IEnumerable<int> nums, IEnumerable<int> expectedArray, int size) {
        var actualList = nums.Take(size).Order().ToList();
        var expectedList = expectedArray.Take(size).Order().ToList();
        Assert.Equal(expectedList, actualList);
    }

    [Theory]
    [InlineData(new[] { 1 }, 2, new[] { 1 }, 1)]
    [InlineData(new[] { 1, 2, 3 }, 10, new[] { 1, 2, 3 }, 3)]
    public void RemoveElement_ValNotExists_ReturnSameArray(int[] nums, int val, int[] expectedArray,
        int expectedSize) {
        var actualSize = _solution.RemoveElement(nums, val);

        AssertArray(nums, expectedArray, expectedSize);
        Assert.Equal(expectedSize, actualSize);
    }

    [Theory]
    [InlineData(new[] { 1 }, 1, new[] { 1 }, 0)]
    [InlineData(new[] { 1, 1, 1, 1 }, 1, new[] { 1, 1, 1, 1 }, 0)]
    [InlineData(new[] { 1, 2, 3 }, 1, new[] { 2, 3, 1 }, 2)]
    [InlineData(new[] { 2, 1, 3 }, 1, new[] { 2, 3, 1 }, 2)]
    [InlineData(new[] { 2, 3, 1 }, 1, new[] { 2, 3, 1 }, 2)]
    [InlineData(new[] { 2, 2, 3 }, 2, new[] { 3, 2, 2 }, 1)]
    [InlineData(new[] { 2, 3, 3 }, 2, new[] { 3, 3, 2 }, 2)]
    public void RemoveElement_GiveNormalInputs_ReturnResult(int[] nums, int val, int[] expectedArray,
        int expectedSize) {
        var actualSize = _solution.RemoveElement(nums, val);

        AssertArray(nums, expectedArray, expectedSize);
        Assert.Equal(expectedSize, actualSize);
    }
}