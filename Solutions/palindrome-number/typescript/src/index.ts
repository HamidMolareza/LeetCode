console.log(isPalindrome2(121))
console.log(isPalindrome2(1))
console.log(isPalindrome2(-121))
console.log(isPalindrome2(10))

function isPalindrome1(x: number): boolean {
    let number = x.toString();
    if(number.length <= 1) return true;
    for (let i = 0; i < number.length / 2; i++) {
        if(number[i] != number[number.length - 1 - i])
            return false;
    }
    return true;
}

function isPalindrome2(x: number): boolean {
    if(x < 0) return false;
    if(x < 10) return true;

    const number = x;
    let reverse = 0;
    while (x > 0){
        let remain = x % 10;
        reverse = reverse * 10 + remain;
        x = Math.floor(x / 10);
    }

    return reverse == number;
}
