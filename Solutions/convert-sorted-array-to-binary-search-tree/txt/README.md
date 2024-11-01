# Intuition

The problem involves creating a height-balanced Binary Search Tree (BST) from a sorted array. In a height-balanced BST, the depth of the two subtrees of every node differs by at most one. To achieve this, we can use the middle element of the array as the root, recursively creating balanced subtrees from the left and right halves.

# Approach

1. **Recursive Division**:
   - Define a recursive function that takes the left and right bounds of the current subarray.
   - Select the middle element of the current subarray as the root node to ensure balanced depth.
   - Recursively apply the function to the left and right halves of the array to construct the left and right subtrees.
   - Continue until the base case is reached (when left > right), indicating there are no more elements to process in the current subarray.
2. **Base Case**:
   - When the left index exceeds the right index, return `null`, as it signifies an empty subtree.

This approach effectively constructs a balanced BST by dividing the array and selecting roots in a way that ensures even distribution of nodes.

# Complexity

- Time complexity:  
  `O(n)` – Each element in the array is processed exactly once to create nodes in the BST.

- Space complexity:  
  `O(log n)` – The recursion stack requires space proportional to the height of the tree, which is `log n` for a balanced BST.

# Other Solutions

- **Iterative Approach**: An iterative approach could use a stack to simulate the recursive process, but this is often more complex and less intuitive for this problem.
- **Randomized Root Selection**: Choosing random midpoints could still yield a balanced tree but does not leverage the sorted property of the array as efficiently as a midpoint-based recursive division.

---

> This text is written by ChatGPT.
