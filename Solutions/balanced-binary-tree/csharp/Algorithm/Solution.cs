namespace Algorithm;

public class Solution {
    public bool IsBalanced(TreeNode root) {
        if (root is null) return true;

        var stack = new Stack<TreeNode>();
        stack.Push(root);

        while (stack.Count > 0) {
            var node = stack.Pop();

            var leftDepth = GetDepth(node.left);
            var rightDepth = GetDepth(node.right);
            if (Math.Abs(leftDepth - rightDepth) > 1)
                return false;
            if (node.left is not null) stack.Push(node.left);
            if (node.right is not null) stack.Push(node.right);
        }

        return true;
    }

    private int GetDepth(TreeNode? node) {
        if (node is null) return 0;
        if (node.left is null && node.right is null) return 1;
        return Math.Max(GetDepth(node.left), GetDepth(node.right)) + 1;
    }
}