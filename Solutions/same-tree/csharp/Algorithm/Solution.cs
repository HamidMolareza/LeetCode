namespace Algorithm;

public class Solution {
    private readonly Queue<(TreeNode, TreeNode)> _queue = new();

    public bool IsSameTree(TreeNode p, TreeNode q) {
        _queue.Enqueue((p, q));
        while (_queue.Count > 0) {
            var (tree1, tree2) = _queue.Dequeue();
            if (tree1 == null && tree2 == null) continue;
            if (tree1 == null || tree2 == null) return false;
            if (tree1.val != tree2.val) return false;

            _queue.Enqueue((tree1.left, tree2.left));
            _queue.Enqueue((tree1.right, tree2.right));
        }

        return true;
    }
}