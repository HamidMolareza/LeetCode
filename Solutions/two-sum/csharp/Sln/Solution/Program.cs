namespace Solution;

public partial class Program {
    public int[] TwoSum(int[] nums, int target) {
        var remains = new List<KeyValuePair<int, int>>();

        for (var i = 0; i < nums.Length; i++) {
            var index = remains.FindIndex(remain => remain.Key == nums[i]);
            if (index >= 0) 
                return new[] {index, i};
            
            var remain = target - nums[i];
            remains.Add(new KeyValuePair<int, int>(remain, i));
        }

        return Array.Empty<int>();
    }
}