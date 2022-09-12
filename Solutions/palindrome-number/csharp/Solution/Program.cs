namespace Solution;

public class Program {
    public bool IsPalindrome(int x) {
        if (x < 0)
            return false;

        var number = x.ToString();
        var condition = number.Length / 2;
        for (var i = 0; i < condition; i++) {
            if (number[i] != number[number.Length - i - 1])
                return false;
        }

        return true;
    }
}