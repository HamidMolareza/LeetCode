function removeElement(nums: number[], val: number): number {
    let index = 0;
    for (let i = 0; i < nums.length; i++) {
        if (nums[i] !== val) {
            if (index !== i) {
                nums[index] = nums[i];
                nums[i] = val;
            }

            index++;
        }
    }
    return index;
}

let nums = [3, 2, 2, 3];
console.log(removeElement(nums, 3));
console.log(nums);

nums = [0, 1, 2, 2, 3, 0, 4, 2];
console.log(removeElement(nums, 2));
console.log(nums);


