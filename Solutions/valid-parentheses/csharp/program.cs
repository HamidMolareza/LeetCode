public class Solution {
    public bool IsValid(string s) {
        var stack = new Stack<char>();
        var bracketMap = new Dictionary<char, char> {
            {')', '('}, {']', '['}, {'}', '{'}
        };

        foreach (var ch in s) {
            if (bracketMap.ContainsKey(ch)) {
                if (stack.Count == 0 || stack.Pop() != bracketMap[ch]) {
                    return false;
                }
            } else {
                stack.Push(ch);
            }
        }

        return stack.Count == 0;
    }
}