# Intuition

The problem requires removing duplicates from a sorted linked list, ensuring that each element appears only once. Since the list is sorted, duplicates will always be adjacent. This allows us to traverse the list once and remove duplicates efficiently.

# Approach

1. Initialize a pointer, `current`, to the head of the linked list.
2. Iterate through the list:
   - If the value of `current` is equal to the value of the next node (`current.next`), it means a duplicate is found. We skip the next node by setting `current.next = current.next.next`.
   - If no duplicate is found, simply move the `current` pointer to the next node.
3. Continue this process until `current` is `null`.
4. Return the modified head of the list.

This method modifies the list in place without requiring extra space for storing values.

# Complexity

- Time complexity:  
  `O(n)` – We traverse the entire list once, where `n` is the number of nodes.

- Space complexity:  
  `O(1)` – We use a constant amount of extra space for pointers.

# Other Solutions

- **Using a Set:** We could maintain a set to track seen values and create a new list without duplicates. However, this would require additional space and isn't necessary given the sorted nature of the list.
- **Recursive Approach:** A recursive solution could traverse the list and handle duplicates, but it would also use additional stack space, making it less efficient.

# Pseudo Code

1. Set `current = head`.
2. While `current` is not null:
   - If `current.next` is not null and `current.val == current.next.val`:
     - Set `current.next = current.next.next` (skip the duplicate).
   - Else:
     - Move `current` to `current.next`.
3. Return `head`.

---

> This text is written by ChatGPT.
