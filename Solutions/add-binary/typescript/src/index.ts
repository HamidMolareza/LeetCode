console.log(addBinary("11", "1"));
console.log(addBinary("1010", "1011"));

function addBinary(a: string, b: string): string {
    const bigger = a.length >= b.length ? a : b;
    const smaller = a.length >= b.length ? b : a;
    const diffLength = bigger.length - smaller.length;

    const result: number[] = [];
    let remain = false;
    for (let biggerIndex = bigger.length - 1; biggerIndex >= 0; biggerIndex--) {
        let smallerIndex = biggerIndex - diffLength;

        let sum = +bigger[biggerIndex];
        if (smallerIndex >= 0)
            sum += +smaller[smallerIndex];
        if (remain) {
            sum += 1;
        }

        let value;
        if (sum <= 1) {
            value = sum;
            remain = false;
        } else if (sum == 2) {
            value = 0;
            remain = true;
        } else {
            value = 1;
            remain = true;
        }
        result.push(value);
    }

    if (remain)
        result.push(1);

    return result.reverse().join("");
}

