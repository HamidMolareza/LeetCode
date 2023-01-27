var solution = new Solution();
Solution.Print(solution.PlusOne(new[] {1, 2, 3}));
Solution.Print(solution.PlusOne(new[] {4, 3, 2, 1}));
Solution.Print(solution.PlusOne(new[] {9}));
Solution.Print(solution.PlusOne(new[] {9, 9}));

public class Solution {
    public int[] PlusOne(int[] digits) {
        var digitList = digits.ToList();
        var hasRemain = true;
        for (var i = digitList.Count - 1; i >= 0; i--) {
            var sum = digitList[i] + 1;
            if (sum < 10) {
                digitList[i] = sum;
                hasRemain = false;
                break;
            }

            digitList[i] = 0;
        }

        if (hasRemain)
            digitList.Insert(0, 1);
        return digitList.ToArray();
    }

    public static void Print(IEnumerable<int> digits) {
        Console.WriteLine(string.Join("", digits));
    }
}