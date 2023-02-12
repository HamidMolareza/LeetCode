/**
 Do not return anything, modify nums1 in-place instead.
 */
function merge(nums1: number[], m: number, nums2: number[], n: number): void {
    if (n === 0) return;
    if (m === 0) {
        copy(nums2, nums1);
        return;
    }

    let mi = 0, ni = 0, result: number[] = [];
    for (let i = 0; i < nums1.length; i++) {
        if (nums1[mi] <= nums2[ni]) {
            result.push(nums1[mi]);
            mi++;
        } else {
            result.push(nums2[ni]);
            ni++;
        }
        if (mi >= m || ni >= n) break;
    }

    let remainNumbers = mi < m ? nums1.slice(mi, m) : nums2.slice(ni, n);
    result = [...result, ...remainNumbers];
    copy(result, nums1);
}

function copy(from: number[], to: number[]): void {
    for (let i = 0; i < from.length; i++)
        to[i] = from[i];
}

let nums1 = [1, 2, 3, 0, 0, 0];
merge(nums1, 3, [2, 5, 6], 3);
console.log(nums1);

nums1 = [1];
merge(nums1, 1, [], 0);
console.log(nums1);

nums1 = [0];
merge(nums1, 0, [1], 1);
console.log(nums1);

nums1 = [1, 0];
merge(nums1, 1, [2], 1);
console.log(nums1);

nums1 = [2, 0];
merge(nums1, 1, [1], 1);
console.log(nums1);

