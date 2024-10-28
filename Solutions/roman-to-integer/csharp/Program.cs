public class Solution {
    public int RomanToInt(string s) {
        var romanMap = new Dictionary<char, int> {
            {'I', 1}, {'V', 5}, {'X', 10}, 
            {'L', 50}, {'C', 100}, {'D', 500}, {'M', 1000}
        };

        int total = 0;
        for (int i = 0; i < s.Length; i++) {
            if (i < s.Length - 1 && romanMap[s[i]] < romanMap[s[i + 1]]) {
                total -= romanMap[s[i]];
            } else {
                total += romanMap[s[i]];
            }
        }
        return total;
    }
}