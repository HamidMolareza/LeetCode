# Intuition

The problem requires finding the maximum depth of a binary tree, which is defined as the longest path from the root node down to the farthest leaf node. This can be approached by traversing the tree and calculating the depth at each node.

# Approach

1. **Recursive Method:**

   - Define a helper function that takes a node as input.
   - If the node is `null`, return `0` (base case).
   - Recursively calculate the depth of the left subtree and the right subtree.
   - The maximum depth at the current node will be `1 + max(depth of left subtree, depth of right subtree)`.
   - Return the calculated depth.

2. **Iterative Method:**
   - Use a stack to keep track of nodes along with their corresponding depths.
   - Start by pushing the root node with a depth of `1`.
   - While the stack is not empty:
     - Pop a node and its depth from the stack.
     - If the node is not `null`, update the maximum depth if the current depth is greater.
     - Push the left child (if it exists) with a depth of `current depth + 1`.
     - Push the right child (if it exists) with a depth of `current depth + 1`.
   - Return the maximum depth found.

Both methods effectively calculate the maximum depth of the binary tree.

# Complexity

- Time complexity:  
  `O(n)` – We visit each node exactly once, where `n` is the number of nodes in the tree.

- Space complexity:
  - Recursive approach: `O(h)` – where `h` is the height of the tree (for the recursion stack).
  - Iterative approach: `O(w)` – where `w` is the maximum width of the tree (for the stack).

# Other Solutions

- **Using Level Order Traversal:** We could implement a breadth-first search (BFS) using a queue to determine depth, which would yield the same time complexity but might be less intuitive for this specific problem.
- **Using Depth-First Search (DFS) with a List:** This approach can also be used, but it would involve more complexity in tracking the depth explicitly.

# Pseudo Code

## Recursive Approach

1. Define a function `maxDepth(node)`:
   - If `node` is `null`, return `0`.
   - Return `1 + max(maxDepth(node.left), maxDepth(node.right))`.

## Iterative Approach

1. Initialize a stack with a tuple of the root node and depth `1`.
2. Set `max_depth = 0`.
3. While the stack is not empty:
   - Pop a node and its depth.
   - If the node is not `null`, update `max_depth` if the current depth is greater.
   - Push the left child (if it exists) with `depth + 1`.
   - Push the right child (if it exists) with `depth + 1`.
4. Return `max_depth`.

---

> This text is written by ChatGPT.
