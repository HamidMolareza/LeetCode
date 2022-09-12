namespace Solution;

public class Program {
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        ListNode? resultListNode = null;

        while (list1 is not null && list2 is not null) {
            if (list1.val <= list2.val) {
                resultListNode = Add(resultListNode, list1.val);
                list1 = list1.next;
            }
            else {
                resultListNode = Add(resultListNode, list2.val);
                list2 = list2.next;
            }
        }

        var remainNodes = list1 != null ? list1 : list2;
        resultListNode = Add(resultListNode, remainNodes);

        return resultListNode;
    }

    private static ListNode Add(ListNode? source, int val) {
        if (source is null)
            return new ListNode(val);

        var lastNode = GetLastNode(source);
        lastNode.next = new ListNode(val);

        return source;
    }

    private static ListNode GetLastNode(ListNode listNode) {
        var lastNode = listNode;
        while (lastNode.next != null)
            lastNode = lastNode.next;
        return lastNode;
    }

    private static ListNode Add(ListNode? source, ListNode newNode) {
        if (source is null)
            return newNode;

        var lastNode = GetLastNode(source);

        do {
            lastNode.next = new ListNode(newNode.val);
            lastNode = lastNode.next;
            newNode = newNode.next;
        } while (newNode != null);

        return source;
    }
}