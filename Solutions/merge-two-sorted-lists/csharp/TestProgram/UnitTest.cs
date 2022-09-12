using Solution;

namespace TestProgram;

public class UnitTest {
    [Theory]
    [InlineData("1 2 4", "1 3 4", "1 1 2 3 4 4")]
    [InlineData("", "", "")]
    [InlineData("", "0", "0")]
    public void MethodName_ScenarioUnderBeingTested_ExpectedBehavior2(string list1, string list2, string result) {
        //Arrange
        var program = new Program();
        var listNode1 = ConvertToListNode(list1);
        var listNode2 = ConvertToListNode(list2);
        var resultNode = ConvertToListNode(result);

        //Act
        var outputNode = program.MergeTwoLists(listNode1, listNode2);

        //Asset
        Assert.True(ListNode.Equals(outputNode, resultNode));
    }

    private static ListNode? ConvertToListNode(string list) {
        if (string.IsNullOrEmpty(list))
            return null;
        
        var numbers = list.Split(" ")
            .Select(number => Convert.ToInt32(number))
            .ToArray();

        return ListNode.AddValues(numbers);
    }
}