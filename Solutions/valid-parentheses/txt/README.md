# Intuition

The problem asks us to determine if a string containing only parentheses is valid. A string is valid if all open brackets are closed by the same type of bracket and in the correct order. This is a classic problem that can be solved using a stack, where we push opening brackets and pop them when we encounter matching closing brackets.

# Approach

We use a stack to track opening brackets. When encountering a closing bracket, we check if it matches the top of the stack. If it does, we pop the top element. If it doesn't match or the stack is empty when encountering a closing bracket, the string is invalid.  
At the end, if the stack is empty, the string is valid; otherwise, it's invalid.

# Complexity

- Time complexity:  
  `O(n)` – We traverse the string once, where `n` is the length of the string.

- Space complexity:  
  `O(n)` – In the worst case, the stack will contain all opening brackets.

# Other Solutions

- **Without a stack:** Use counters for each bracket type, but it becomes complex to handle the correct order. A stack is the simplest and most effective approach.
- **Recursive approach:** Recursion can be used to match brackets, but it introduces overhead and risks stack overflow for long inputs.

# Pseudo Code

1. Create an empty stack.
2. Create a dictionary to map closing brackets to their corresponding opening brackets:

   `bracket_map = {')': '(', '}': '{', ']': '['}`

3. Iterate over each character in the input string:

- If the character is an opening bracket, push it onto the stack.
- If it's a closing bracket:
  - If the stack is empty or the top of the stack doesn't match the corresponding opening bracket, return `false`.
  - Otherwise, pop the top of the stack.

4. At the end, return `true` if the stack is empty, otherwise `false`.

---

> This text is written by ChatGPT.
