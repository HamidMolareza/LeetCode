namespace Algorithm;

public class Solution {
    public TreeNode SortedArrayToBST(int[] nums) {
        return SortedArrayToBst(nums, 0, nums.Length - 1);
    }

    private static TreeNode? SortedArrayToBst(IReadOnlyList<int> nums, int leftIndex, int rightIndex) {
        if (leftIndex > rightIndex) return null;
        var middleIndex = (leftIndex + rightIndex) / 2;
        var node = new TreeNode(nums[middleIndex]) {
            left = SortedArrayToBst(nums, leftIndex, middleIndex - 1),
            right = SortedArrayToBst(nums, middleIndex + 1, rightIndex)
        };
        return node;
    }
}