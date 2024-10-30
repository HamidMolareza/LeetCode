# Intuition

This problem involves merging two sorted linked lists into a single sorted linked list. Since both input lists are already sorted, we can achieve the merging efficiently by using a two-pointer technique, comparing elements one by one from both lists.

# Approach

We create a dummy node to serve as the starting point of the merged list. Using two pointers, we compare the values from both lists and attach the smaller value to the merged list. We move the corresponding pointer forward. This continues until we reach the end of one list.  
At the end, if one list still has remaining elements, we link them directly to the merged list.

This approach ensures we maintain the order without requiring additional space for a new list.

# Complexity

- Time complexity:  
  `O(n + m)` – where `n` and `m` are the lengths of the two input lists. We traverse both lists once.

- Space complexity:  
  `O(1)` – The space used is constant since we only modify the existing nodes without creating new ones (besides the dummy node).

# Other Solutions

- **Recursive approach:** A recursive solution is elegant but comes with a stack overhead. For very long lists, it may lead to stack overflow. An iterative approach is generally preferred for this type of problem.

# Pseudo Code

1. Create a dummy node to act as the head of the merged list.
2. Initialize `current` to point to the dummy node.
3. While both lists are not empty:
   - If `list1.val <= list2.val`, attach `list1` to `current` and move `list1` forward.
   - Otherwise, attach `list2` to `current` and move `list2` forward.
   - Move `current` forward.
4. If one list is not empty, attach the remaining elements to `current`.
5. Return `dummy.next` as the head of the merged list.

---

> This text is written by ChatGPT.
