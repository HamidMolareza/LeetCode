# Intuition

The problem asks us to remove duplicates from a sorted array in-place, meaning we should modify the input array without using extra space. Since the array is already sorted, all duplicates will be adjacent to each other. This allows us to use a two-pointer technique to efficiently modify the array.

# Approach

We use two pointers:

1. `i` – Tracks the position where the next unique element should go.
2. `j` – Iterates through the array.

We start with `i` at 0, assuming the first element is unique. As `j` moves through the array, we check if the current element is different from the previous unique element (located at `i`). If it is, we increment `i` and copy the current element to the `i`-th position. After finishing the iteration, the first `i + 1` elements of the array will contain the unique elements.

# Complexity

- Time complexity:  
  `O(n)` – We traverse the array once, where `n` is the length of the input array.

- Space complexity:  
  `O(1)` – No extra space is used since the modification is done in-place.

# Other Solutions

- **Using a Set:** We could use a set to collect unique elements and then copy them back into the array. However, this requires extra space, which violates the problem constraints.

# Pseudo Code

1. If the array is empty, return 0.
2. Initialize `i` to 0.
3. Iterate `j` from 1 to the end of the array:
   - If `nums[j] != nums[i]`:
     - Increment `i`.
     - Set `nums[i] = nums[j]`.
4. Return `i + 1` as the length of the unique elements array.

---

> This text is written by ChatGPT.
