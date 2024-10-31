namespace Algorithm;

public class Solution {
    public int RemoveElement(int[] nums, int val) {
        if (nums.Length == 0) return 0;

        var j = LastIndex(nums, num => num != val);
        if (j < 0) return 0;

        int i;
        for (i = 0; i < j; i++) {
            if (nums[i] != val) continue;
            (nums[i], nums[j]) = (nums[j], nums[i]);
            
            j = LastIndex(nums, num => num != val, j - 1);
        }

        return j + 1;
    }

    public static int LastIndex<T>(T[] list, Func<T, bool> func, int? endIndex = null) {
        endIndex ??= list.Length - 1;
        for (var i = (int)endIndex; i >= 0; i--) {
            if (func(list[i])) return i;
        }

        return -1;
    }
}