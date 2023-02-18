var solution = new Solution2();
var node = new TreeNode(1,
    new TreeNode(3,
        new TreeNode(4,
            new TreeNode(6),
            null
        ),
        new TreeNode(5,
            new TreeNode(8),
            new TreeNode(9)
        )
    ),
    new TreeNode(3,
        new TreeNode(5,
            new TreeNode(9),
            new TreeNode(8)
        ),
        new TreeNode(4,
            new TreeNode(6),
            null
        )
    )
);
Console.WriteLine(solution.IsSymmetric(node));


public class Solution1 {
    public bool IsSymmetric(TreeNode root) =>
        root.left?.val == root.right?.val && IsSymmetric(root.left, root.right);

    private static bool IsSymmetric(TreeNode? left, TreeNode? right) {
        if (left is null || right is null) return true;
        if (left.left?.val != right.right?.val || left.right?.val != right.left?.val) return false;
        return IsSymmetric(left.left, right.right) && IsSymmetric(left.right, right.left);
    }
}

public class Solution2 {
    public bool IsSymmetric(TreeNode root) {
        if (root.left?.val != root.right?.val) return false;

        var stack = new Stack<NodeStacks>();
        stack.Push(new NodeStacks(root.left, root.right));
        while (stack.Any()) {
            var nodes = stack.Pop();
            if (nodes.Left is null && nodes.Right is null) continue;
            if (nodes.Left is null != nodes.Right is null) return false;
            if (nodes.Left!.left?.val != nodes.Right!.right?.val ||
                nodes.Left!.right?.val != nodes.Right!.left?.val) return false;
            
            if (nodes.Left?.left is not null && nodes.Right?.right is not null)
                stack.Push(new NodeStacks(nodes.Left?.left, nodes.Right?.right));
            if (nodes.Left?.right is not null && nodes.Right?.left is not null)
                stack.Push(new NodeStacks(nodes.Left?.right, nodes.Right?.left));
        }

        return true;
    }

    public class NodeStacks {
        public NodeStacks(TreeNode? left, TreeNode? right) {
            Left = left;
            Right = right;
        }

        public TreeNode? Left { get; set; }
        public TreeNode? Right { get; set; }
    }
}

public class TreeNode {
    public int val;
    public TreeNode? left;
    public TreeNode? right;

    public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}