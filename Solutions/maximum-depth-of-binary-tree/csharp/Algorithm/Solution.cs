namespace Algorithm;

public class Solution {
    public int MaxDepth(TreeNode root) {
        if (root is null) return 0;

        var queue = new Queue<(TreeNode, int)>();
        queue.Enqueue((root, 1));

        var maxDepth = 0;
        while (queue.Count > 0) {
            var (node, depth) = queue.Dequeue();
            maxDepth = Math.Max(maxDepth, depth);

            if (node.left != null)
                queue.Enqueue((node.left, depth + 1));
            if (node.right != null)
                queue.Enqueue((node.right, depth + 1));
        }

        return maxDepth;
    }
}