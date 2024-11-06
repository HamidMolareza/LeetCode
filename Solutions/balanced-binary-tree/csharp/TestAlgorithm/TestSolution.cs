using Algorithm;

namespace TestAlgorithm;

public class TestSolution {
    private readonly Solution _solution = new();

    public static IEnumerable<object[]> TreeTestData =>
        new List<object[]> {
            new object[] { new int?[] { 3, 9, 20, null, null, 15, 7 }, true },
            new object[] { new int?[] { 1, 2, 2, 3, 3, null, null, 4, 4 }, false },
            new object[] { Array.Empty<int?>(), true }
        };

    [Theory]
    [MemberData(nameof(TreeTestData))]
    public void IsBalanced(int?[] treeArray, bool expected) {
        var tree = BinaryTreeBuilder.BuildBinaryTreeFromArray(treeArray);
        var actual = _solution.IsBalanced(tree);

        Assert.Equal(expected, actual);
    }
}