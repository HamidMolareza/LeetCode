namespace Solution;

public partial class Program {
    public int[] TwoSum2(int[] nums, int target) {
        for (var i = 0; i < nums.Length - 1; i++) {
            for (var j = i + 1; j < nums.Length; j++)
                if (nums[i] + nums[j] == target)
                    return new[] {i, j};
        }

        return Array.Empty<int>();
    }
}