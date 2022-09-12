namespace Solution;

public class ListNode {
    public int val;
    public ListNode? next;

    public ListNode(int val = 0, ListNode? next = null) {
        this.val = val;
        this.next = next;
    }

    public static ListNode AddValues(params int[] values) {
        if (values.Length < 1)
            return new ListNode();

        var result = new ListNode(values[0]);
        var wrapper = new ListNode {
            next = result
        };
        for (var i = 1; i < values.Length; i++) {
            result.next = new ListNode(values[i]);
            result = result.next;
        }

        return wrapper.next;
    }

    public override string ToString() {
        var values = GetValues(this).ToList();
        return string.Join(" ", values);
    }

    public static IEnumerable<int> GetValues(ListNode? listNode) {
        var wrapperNode = new ListNode(0, listNode);

        while (wrapperNode.next != null) {
            yield return wrapperNode.next.val;
            wrapperNode = wrapperNode.next;
        }
    }

    public static bool Equals(ListNode? listNode1, ListNode? listNode2) {
        var isList1Null = listNode1 is null;
        var isList2Null = listNode2 is null;
        if (isList1Null != isList2Null)
            return false;
        if (isList1Null)
            return true;
        
        using var values1 = GetValues(listNode1).GetEnumerator();
        using var values2 = GetValues(listNode2).GetEnumerator();

        bool thisHasNext;
        do {
            if (values1.Current != values2.Current)
                return false;

            thisHasNext = values1.MoveNext();
            var objHasNext = values2.MoveNext();
            if (thisHasNext != objHasNext)
                return false;
        } while (thisHasNext);

        return true;
    }

    protected bool Equals(ListNode other) {
        return Equals(next, other.next);
    }
    
    public static bool operator ==(ListNode? left, ListNode? right) {
        return Equals(left, right);
    }

    public static bool operator !=(ListNode? left, ListNode? right) {
        return !Equals(left, right);
    }
    
    public override bool Equals(object? obj) {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((ListNode) obj);
    }

    public override int GetHashCode() {
        return HashCode.Combine(val, next);
    }
}