namespace Algorithm;

public class Solution {
    public int ClimbStairs(int n) {
        if (n <= 1) return 1;

        int first = 1, second = 1;

        for (var i = 2; i <= n; i++) {
            var temp = first + second;
            first = second;
            second = temp;
        }

        return second;
    }
}