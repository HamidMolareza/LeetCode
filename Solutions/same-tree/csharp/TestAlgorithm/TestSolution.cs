using Algorithm;

namespace TestAlgorithm;

public class TestSolution {
    private readonly Solution _solution = new();

    public static IEnumerable<object[]> SameTreeTestData =>
        new List<object[]> {
            new object[] { new int?[] { 1, 2, 3 }, new int?[] { 1, 2, 3 } },
            new object[] { new int?[] { 1, null, 3 }, new int?[] { 1, null, 3 } },
            new object[] { new int?[] { 1, 2 }, new int?[] { 1, 2 } },
            new object[] { Array.Empty<int?>(), Array.Empty<int?>() }
        };

    public static IEnumerable<object[]> DifferentTreeTestData =>
        new List<object[]> {
            new object[] { new int?[] { 1, 2, 3 }, new int?[] { 1, 2, 4 } },
            new object[] { new int?[] { 1, null, 3 }, new int?[] { 1, 3, null } },
            new object[] { new int?[] { 1, 2 }, new int?[] { 1, 2, 3 } },
            new object[] { new int?[] { 1 }, new int?[] { 2 } }
        };

    [Theory]
    [MemberData(nameof(SameTreeTestData))]
    public void IsSameTree_GiveSameNodes_ReturnTrue(int?[] leftArray, int?[] rightArray) {
        var p = BinaryTreeBuilder.BuildBinaryTreeFromArray(leftArray);
        var q = BinaryTreeBuilder.BuildBinaryTreeFromArray(rightArray);

        var actual = _solution.IsSameTree(p, q);

        const bool expected = true;
        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(DifferentTreeTestData))]
    public void IsSameTree_GiveDifferentNodes_ReturnFalse(int?[] leftArray, int?[] rightArray) {
        var p = BinaryTreeBuilder.BuildBinaryTreeFromArray(leftArray);
        var q = BinaryTreeBuilder.BuildBinaryTreeFromArray(rightArray);

        var actual = _solution.IsSameTree(p, q);

        const bool expected = false;
        Assert.Equal(expected, actual);
    }
}