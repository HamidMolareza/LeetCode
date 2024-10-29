using System.Text;

namespace Algorithm;

public class Solution {
    public string AddBinary(string a, string b) {
        var (larger, smaller) = a.Length > b.Length ? (a, b) : (b, a);

        var result = new StringBuilder();
        var carry = 0;
        for (var i = 0; i < larger.Length; i++) {
            var sum = GetLastDigitOrDefault(smaller, i + 1) + GetLastDigitOrDefault(larger, i + 1) + carry;
            carry = sum / 2;
            sum %= 2;

            result.Insert(0, sum);
        }

        if (carry > 0)
            result.Insert(0, '1');

        return result.ToString();
    }

    private static int GetLastDigitOrDefault(string number, int index) {
        if (index < 1 || index > number.Length) return 0; // Default value
        return number[^index] - '0';
    }
}