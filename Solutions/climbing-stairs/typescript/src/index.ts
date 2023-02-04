const steps = [1, 2];
let history: { [key: number]: number } = {};

function climbStairs1(n: number): number {
    if (n <= 0) return 0;
    if (n <= 2) return n;
    if (history.hasOwnProperty(n)) return history[n];

    let sum = 0;
    steps.forEach(step => sum += climbStairs1(n - step));
    history[n] = sum;
    return sum;
}

// General solution for different steps.
function climbStairs2(n: number): number {
    if (n < steps[0]) return 0;
    if (n === steps[0]) return steps[0];
    if (history.hasOwnProperty(n)) return history[n];

    let sum = 0;
    steps.forEach(step => {
        let remainSteps = n - step;
        if (remainSteps === 0)
            sum++;
        else
            sum += climbStairs2(n - step)
    });
    history[n] = sum;
    return sum;
}

console.log(climbStairs2(0));
console.log(climbStairs2(1));
console.log(climbStairs2(2));
console.log(climbStairs2(3));
console.log(climbStairs2(44));
