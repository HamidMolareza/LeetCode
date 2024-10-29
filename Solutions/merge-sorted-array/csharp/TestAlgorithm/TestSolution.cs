using Algorithm;

namespace TestAlgorithm;

public class TestSolution {
    private readonly Solution _solution = new();

    [Theory]
    [InlineData(new[] { 0 }, 0, new[] { 1 }, 1, new[] { 1 })]
    [InlineData(new[] { 1 }, 1, new[] { 0 }, 0, new[] { 1 })]
    [InlineData(new[] { 1 }, 1, new int[] { }, 0, new[] { 1 })]
    public void Merge_OneOfThemEmpty_ReturnResult(int[] nums1, int m, int[] nums2, int n, int[] expected) {
        _solution.Merge(nums1, m, nums2, n);

        Assert.Equal(expected, nums1);
    }

    [Theory]
    [InlineData(new[] { 1, 2, 3, 0, 0, 0 }, 3, new[] { 2, 5, 6 }, 3, new[] { 1, 2, 2, 3, 5, 6 })]
    [InlineData(new[] { 2,0 }, 1, new[] { 1 }, 1, new[] { 1, 2 })]
    public void Merge_GiveNormalInput_ReturnResult(int[] nums1, int m, int[] nums2, int n, int[] expected) {
        _solution.Merge(nums1, m, nums2, n);

        Assert.Equal(expected, nums1);
    }
}