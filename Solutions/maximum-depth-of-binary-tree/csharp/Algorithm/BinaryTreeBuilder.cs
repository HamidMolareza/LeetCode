namespace Algorithm;

public static class BinaryTreeBuilder {
    public static TreeNode? BuildBinaryTreeFromArray(int?[]? arr) {
        if (arr == null || arr.Length == 0 || arr[0] is null) return null;

        var root = new TreeNode(arr[0]!.Value);
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        var i = 1;
        while (i < arr.Length) {
            var current = queue.Dequeue();

            // Set left child
            if (i < arr.Length && arr[i] != null) {
                current.left = new TreeNode(arr[i]!.Value);
                queue.Enqueue(current.left);
            }

            i++;

            // Set right child
            if (i < arr.Length && arr[i] != null) {
                current.right = new TreeNode(arr[i]!.Value);
                queue.Enqueue(current.right);
            }

            i++;
        }

        return root;
    }
}