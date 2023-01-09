using System.Text;

var solution = new Solution();

Console.WriteLine(solution.LongestCommonPrefix(new[] {"flower", "flow", "flight"}));
Console.WriteLine(solution.LongestCommonPrefix(new[] {"dog", "racecar", "car"}));
Console.WriteLine(solution.LongestCommonPrefix(null));
Console.WriteLine(solution.LongestCommonPrefix(new[] {""}));
Console.WriteLine(solution.LongestCommonPrefix(Array.Empty<string>()));


public class Solution {
    public string LongestCommonPrefix(string[] strs) {
        var commonPrefix = new StringBuilder();
        for (var i = 0;; i++) {
            if (IsCommon(strs, i))
                commonPrefix.Append(strs[0][i]);
            else
                return commonPrefix.ToString();
        }
    }

    private static bool IsCommon(string[]? words, int charIndex) {
        if (charIndex < 0 || words is null || !words.Any()) return false;
        var firstWord = words.First();
        if (charIndex >= firstWord.Length) return false;
        
        var commonChar = words.First()[charIndex];
        for (var wordIndex = 1; wordIndex < words.Length; wordIndex++) {
            if (charIndex >= words[wordIndex].Length) return false;
            if (commonChar != words[wordIndex][charIndex]) return false;
        }

        return true;
    }
}