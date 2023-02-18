const currentDepth = 1

function maxDepth(root: TreeNode | null): number {
    if (!root) return 0;
    if (!root.left && !root.right) return currentDepth;
    return currentDepth + Math.max(maxDepth(root.left), maxDepth(root.right));
}

class TreeNode {
    val: number
    left: TreeNode | null
    right: TreeNode | null

    constructor(val?: number, left?: TreeNode | null, right?: TreeNode | null) {
        this.val = (val === undefined ? 0 : val)
        this.left = (left === undefined ? null : left)
        this.right = (right === undefined ? null : right)
    }
}

console.log(
    maxDepth(
        new TreeNode(3,
            new TreeNode(9),
            new TreeNode(20,
                new TreeNode(15),
                new TreeNode(7)
            )
        )
    )
);

console.log(
    maxDepth(
        new TreeNode(1,
            null,
            new TreeNode(2)
        )
    )
);
