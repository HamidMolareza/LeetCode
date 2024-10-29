namespace Algorithm;

public class Solution
{
    public int LengthOfLastWord(string s) {
        s = s.Trim(); // Trim leading and trailing spaces
        int lastSpaceIndex = s.LastIndexOf(' ');

        return lastSpaceIndex == -1 ? s.Length : s.Length - lastSpaceIndex - 1;
    }
}