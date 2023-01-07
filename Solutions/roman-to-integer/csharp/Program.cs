var solution = new Solution();

Console.WriteLine(solution.RomanToInt("III"));
Console.WriteLine(solution.RomanToInt("LVIII"));
Console.WriteLine(solution.RomanToInt("MCMXCIV"));


public class Solution {
    public int RomanToInt(string s) {
        s = s.ToLower();
        var sum = 0;

        for (var i = 0; i < s.Length; i++) {
            var isLastChar = i == s.Length - 1;
            if (isLastChar)
                sum += RomanToInt(s[i]);
            else
                switch (s[i]) {
                    case 'i' when s[i + 1] == 'v' || s[i + 1] == 'x':
                    case 'x' when s[i + 1] == 'l' || s[i + 1] == 'c':
                    case 'c' when s[i + 1] == 'd' || s[i + 1] == 'm':
                        sum += RomanToInt(s[i + 1]) - RomanToInt(s[i]);
                        i++;
                        break;
                    default:
                        sum += RomanToInt(s[i]);
                        break;
                }
        }

        return sum;
    }

    private static int RomanToInt(char romanChar) =>
        romanChar switch {
            'i' => 1,
            'v' => 5,
            'x' => 10,
            'l' => 50,
            'c' => 100,
            'd' => 500,
            'm' => 1000,
            _ => throw new ArgumentOutOfRangeException(nameof(romanChar))
        };
}