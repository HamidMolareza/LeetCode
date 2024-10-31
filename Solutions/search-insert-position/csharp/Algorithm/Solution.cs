namespace Algorithm;

public class Solution {
    public int SearchInsert(int[] nums, int target) {
        return nums.Length switch {
            0 => 0,
            1 => nums.First() < target ? 1 : 0,
            _ => BinarySearch(nums, target)
        };
    }

    private static int BinarySearch(IReadOnlyList<int> nums, int target) {
        int begin = 0, end = nums.Count - 1;
        while (end - begin >= 0) {
            var middle = (begin + end) / 2;
            if (nums[middle] == target) return middle;
            if (nums[middle] < target) {
                begin = middle + 1;
            }
            else {
                end = middle - 1;
            }
        }

        return begin;
    }
}