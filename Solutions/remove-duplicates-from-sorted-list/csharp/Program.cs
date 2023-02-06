var solution = new Solution();
solution.DeleteDuplicates(new ListNode(new[] {1, 1, 2})).Print();
solution.DeleteDuplicates(new ListNode(new[] {1, 1, 2, 3, 3})).Print();
solution.DeleteDuplicates(new ListNode(Array.Empty<int>())).Print();

public class ListNode {
    public int val;
    public ListNode? next;

    public ListNode(int val = 0, ListNode? next = null) {
        this.val = val;
        this.next = next;
    }

    public ListNode(IReadOnlyList<int> values) {
        var node = this;
        for (var i = 0; i < values.Count; i++) {
            node!.val = values[i];
            if (i >= values.Count - 1) break;
            node.next ??= new ListNode();
            node = node.next;
        }
    }

    public void Print() {
        Console.WriteLine(string.Join(" ", SelectValues()));
    }

    public List<int> SelectValues() {
        var result = new List<int> {val};
        var node = next;
        while (node is not null) {
            result.Add(node.val);
            node = node.next;
        }

        return result;
    }
}

public class Solution {
    public ListNode DeleteDuplicates(ListNode? head) {
        if (head is null) return null;
        var currentNode = head;
        while (true) {
            var nextNode = currentNode.next;
            if (nextNode is null) return head;
            if (currentNode.val == nextNode.val)
                currentNode.next = nextNode.next;
            else
                currentNode = nextNode;
        }
    }
}