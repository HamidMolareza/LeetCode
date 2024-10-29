namespace Algorithm;

public class Solution2 {
    private readonly List<int> _cacheResults = [0, 1, 2, 3];
    private readonly List<int> _steps = [1, 2];

    public int ClimbStairs(int n) {
        if (n < _cacheResults.Count) return _cacheResults[n];

        var sum = _steps.Sum(step => ClimbStairs(n - step));
        _cacheResults.Add(sum);
        return sum;
    }
}