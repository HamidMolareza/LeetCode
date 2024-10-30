# Intuition

The task is to determine if two binary trees are identical. This means that both trees must have the same structure and the same values at each corresponding node. A straightforward way to approach this is to traverse both trees simultaneously and compare nodes as we go.

# Approach

1. **Recursive Method:**

   - Define a helper function that takes two nodes (`p` and `q`).
   - If both nodes are `null`, return `true` (both trees are empty at this position).
   - If one node is `null` and the other is not, return `false` (one tree has a node where the other does not).
   - Compare the values of `p` and `q`. If they are not equal, return `false`.
   - Recursively check the left subtrees and the right subtrees. Return `true` only if both are true.

2. **Iterative Method:**
   - Use a stack to compare nodes. Initialize the stack with the root nodes of both trees.
   - While the stack is not empty:
     - Pop two nodes from the stack.
     - If both nodes are `null`, continue (this means we’ve reached the end of both branches).
     - If one node is `null` and the other is not, return `false`.
     - If the values of the nodes are not equal, return `false`.
     - Push the left and right children of both nodes onto the stack to compare them in subsequent iterations.

Both methods efficiently check for tree equality.

# Complexity

- Time complexity:  
  `O(n)` – We visit each node exactly once, where `n` is the number of nodes in the trees.

- Space complexity:
  - Recursive approach: `O(h)` – where `h` is the height of the tree (for the recursion stack).
  - Iterative approach: `O(h)` – where `h` is the height of the tree (for the stack).

# Other Solutions

- **Using Serialization:** We could serialize both trees into strings and compare them. However, this method may introduce unnecessary complexity and inefficiency.
- **In-order or Pre-order Traversal:** While these are traversal methods, they do not directly address the problem of checking for tree equality as effectively as the above approaches.

# Pseudo Code

## Recursive Approach

1. Define a function `isSameTree(p, q)`:
   - If both `p` and `q` are `null`, return `true`.
   - If one is `null` or their values are not equal, return `false`.
   - Return `isSameTree(p.left, q.left) && isSameTree(p.right, q.right)`.

## Iterative Approach

1. Initialize a stack.
2. Push the root nodes of both trees onto the stack.
3. While the stack is not empty:
   - Pop the nodes `p` and `q`.
   - If both are `null`, continue.
   - If one is `null` or their values are not equal, return `false`.
   - Push `p.left`, `q.left` and `p.right`, `q.right` onto the stack.
4. Return `true` at the end.

---

> This text is written by ChatGPT.
