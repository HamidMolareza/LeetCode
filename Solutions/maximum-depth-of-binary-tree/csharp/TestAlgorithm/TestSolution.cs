using Algorithm;

namespace TestAlgorithm;

public class TestSolution {
    private readonly Solution _solution = new();

    public static IEnumerable<object[]> TreeTestData =>
        new List<object[]> {
            new object[] { new int?[] { 3, 9, 20, null, null, 15, 7 }, 3 },
            new object[] { new int?[] { 1, null, 2 }, 2 },
            new object[] { Array.Empty<int?>(), 0 }
        };

    [Theory]
    [MemberData(nameof(TreeTestData))]
    public void IsSameTree_GiveSameNodes_ReturnTrue(int?[] treeArray, int expectedDepth) {
        var tree = BinaryTreeBuilder.BuildBinaryTreeFromArray(treeArray);

        var actualDepth = _solution.MaxDepth(tree);

        Assert.Equal(expectedDepth, actualDepth);
    }
}