# Intuition

The problem involves checking if a binary tree is symmetric around its center, which means that the left subtree is a mirror reflection of the right subtree. This can be intuitively thought of as comparing the left and right subtrees node by node.

# Approach

1. **Recursive Method:**

   - Define a helper function that takes two nodes (`left` and `right`).
   - If both nodes are `null`, return `true` (both sides are empty).
   - If one node is `null` and the other is not, return `false` (the tree is not symmetric).
   - Compare the values of the two nodes. If they are not equal, return `false`.
   - Recursively check the following pairs of subtrees:
     - The left child of the left node and the right child of the right node.
     - The right child of the left node and the left child of the right node.
   - Return `true` only if both recursive calls return `true`.

2. **Iterative Method:**
   - Use a queue to compare nodes level by level. Initialize the queue with the left and right children of the root.
   - While the queue is not empty:
     - Dequeue two nodes.
     - If both are `null`, continue (this means we’ve reached the end of both branches).
     - If one is `null` and the other is not, return `false`.
     - If the values of the nodes are not equal, return `false`.
     - Enqueue the left and right children of both nodes in the correct order to maintain symmetry.
   - Return `true` at the end.

Both methods ensure that we efficiently check for tree symmetry.

# Complexity

- Time complexity:  
  `O(n)` – We visit each node exactly once, where `n` is the number of nodes in the tree.

- Space complexity:
  - Recursive approach: `O(h)` – where `h` is the height of the tree (for the recursion stack).
  - Iterative approach: `O(w)` – where `w` is the maximum width of the tree (for the queue).

# Other Solutions

- **Using Serialization:** We could serialize the tree into a string and check if it reads the same forwards and backwards, but this is less efficient and more complex.
- **In-order or Pre-order Traversal:** These methods do not directly help in checking symmetry since they do not compare nodes in a mirrored fashion.

# Pseudo Code

## Recursive Approach

1. Define a function `isSymmetric(left, right)`:
   - If both `left` and `right` are `null`, return `true`.
   - If one is `null` or their values are not equal, return `false`.
   - Return `isSymmetric(left.left, right.right) && isSymmetric(left.right, right.left)`.

## Iterative Approach

1. Initialize a queue.
2. Enqueue the left and right children of the root.
3. While the queue is not empty:
   - Dequeue the nodes `left` and `right`.
   - If both are `null`, continue.
   - If one is `null` or their values are not equal, return `false`.
   - Enqueue `left.left`, `right.right` and `left.right`, `right.left`.
4. Return `true` at the end.

---

> This text is written by ChatGPT.
