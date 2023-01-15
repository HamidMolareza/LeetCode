var solution = new Solution();

Console.WriteLine(solution.RemoveDuplicates(new[] {1, 1, 2}));
Console.WriteLine(solution.RemoveDuplicates(new[] {0, 0, 1, 1, 1, 2, 2, 3, 3, 4}));
Console.WriteLine(solution.RemoveDuplicates(new[] {1, 2}));


public class Solution {
    public int RemoveDuplicates(int[] nums) {
        var lastValidIndex = 0;
        for (var i = 1; i < nums.Length; i++) {
            if (nums[i] <= nums[lastValidIndex])
                continue;
            nums[lastValidIndex + 1] = nums[i];
            lastValidIndex++;
        }

        return lastValidIndex + 1;
    }
}