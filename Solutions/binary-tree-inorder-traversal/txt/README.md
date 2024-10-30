# Intuition

The problem requires traversing a binary tree in an in-order manner (left, root, right) and returning the values of the nodes in a list. This traversal method is particularly useful for binary search trees, as it visits nodes in non-decreasing order.

# Approach

1. **Recursive Method:**

   - Define a helper function that takes the current node and a result list.
   - Recursively traverse the left subtree.
   - Add the value of the current node to the result list.
   - Recursively traverse the right subtree.
   - Return the result list at the end.

2. **Iterative Method:**
   - Use a stack to keep track of nodes to visit.
   - Start from the root and push all left children onto the stack.
   - Pop from the stack to process nodes, adding their values to the result list.
   - If a node has a right child, push the right child onto the stack and repeat the process for its left children.

Both approaches ensure that nodes are visited in the correct order.

# Complexity

- Time complexity:  
  `O(n)` – We visit each node exactly once, where `n` is the number of nodes in the tree.

- Space complexity:
  - Recursive approach: `O(h)` – where `h` is the height of the tree (for the recursion stack).
  - Iterative approach: `O(h)` – where `h` is the height of the tree (for the stack).

# Other Solutions

- **Using Morris Traversal:** This approach modifies the tree structure temporarily to avoid using extra space for the stack. However, it can be complex to implement and understand.
- **Pre-order or Post-order Traversals:** While these are valid tree traversal methods, they do not satisfy the in-order requirement of this problem.

# Pseudo Code

## Recursive Approach

1. Initialize an empty list `result`.
2. Define a helper function that takes `node` and `result`:
   - If `node` is null, return.
   - Call the helper on `node.left`.
   - Append `node.val` to `result`.
   - Call the helper on `node.right`.
3. Call the helper on the root.
4. Return `result`.

## Iterative Approach

1. Initialize an empty stack and an empty list `result`.
2. Set `current = root`.
3. While `current` is not null or the stack is not empty:
   - While `current` is not null:
     - Push `current` onto the stack.
     - Set `current = current.left`.
   - Pop from the stack, set `current = stack.pop()`.
   - Append `current.val` to `result`.
   - Set `current = current.right`.
4. Return `result`.

---

> This text is written by ChatGPT.
