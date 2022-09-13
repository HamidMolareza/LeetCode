namespace Solution;

public partial class Program {
    public bool IsPalindrome_WithoutConvertToString(int x) {
        if (x < 0)
            return false;

        var mainNumber = x;
        var reverse = 0;
        while (x > 0) {
            var lastDigit = x % 10;
            x /= 10;
            reverse = reverse * 10 + lastDigit;
        }

        return mainNumber == reverse;
    }
}