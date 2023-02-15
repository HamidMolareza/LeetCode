public class Solution {
    public IList<int> Solution1(TreeNode root) {
        var result = new List<int>();
        if (root is null) return result;
        result.AddRange(Solution1(root.left));
        result.Add(root.val);
        result.AddRange(Solution1(root.right));
        return result;
    }

    public IList<int> Solotion2(TreeNode root) {
        List<int> result = new List<int>();
        Stack<TreeNode> stack = new Stack<TreeNode>();
        while (stack.Count > 0 || root != null) {
            while (root != null) {
                stack.Push(root);

                root = root.left;
            }

            root = stack.Pop();
            result.Add(root.val);
            root = root.right;
        }

        return result;
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