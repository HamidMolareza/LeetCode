var solution = new Solution();
Console.WriteLine(solution.SearchInsert(new int[] {1, 3, 5, 6}, 5));
Console.WriteLine(solution.SearchInsert(new int[] {1, 3, 5, 6}, 2));
Console.WriteLine(solution.SearchInsert(new int[] {1, 3, 5, 6}, 7));


public class Solution {
    public int SearchInsert(int[] nums, int target) {
        var findIndex = nums.ToList().FindIndex(num => num >= target);
        return findIndex >= 0 ? findIndex : nums.Length;
    }
}