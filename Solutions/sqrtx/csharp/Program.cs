var solution = new Solution();
Console.WriteLine(solution.MySqrt(4));
Console.WriteLine(solution.MySqrt(8));
Console.WriteLine(solution.MySqrt(2));
Console.WriteLine(solution.MySqrt(1073741823));


public class Solution {
    //Newton–Raphson Method
    public int MySqrt(int x) {
        var guess = GetInitialGuess(x);
        while (true) {
            var newGuess = (x * 1.0 / guess + guess) / 2;
            if (Math.Abs(newGuess - guess) < 0.01)
                return (int)newGuess;
            guess = newGuess;
        }
    }

    private static double GetInitialGuess(int number) =>
        (int) Math.Pow(10, (int) (number.ToString().Length / 2));
}