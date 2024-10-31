namespace Algorithm;

public class Solution {
    public int LengthOfLastWord(string s) {
        for (var i = s.Length - 1; i >= 0; i--) {
            if (s[i] == ' ') continue;

            for (var wordLength = i; wordLength >= 0; wordLength--) {
                if (s[wordLength] == ' ') return i - wordLength;
            }

            return i + 1;
        }

        return -1;
    }
}