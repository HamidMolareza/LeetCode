let nums = [2, 7, 11, 15];
let target = 9;

let result = twoSum(nums, target);
console.log(result)

function twoSum(nums: number[], target: number): number[] {
    let remains: number[] = []
    for (let i = 0; i < nums.length; i++) {
        let foundIndex = remains.findIndex(remain => remain == nums[i]);
        if (foundIndex >= 0)
            return [foundIndex, i];
        remains = [...remains, target - nums[i]]
    }
    return [];
}

