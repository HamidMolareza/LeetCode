console.log(isValid("()"))
console.log(isValid("()[]{}"))
console.log(isValid("(]"))
console.log(isValid("{"))
console.log(isValid("([)]"))
console.log(isValid("(("))

function isValid(s: string): boolean {
    if (s.length % 2 != 0) return false;
    if (s.length == 0) return true;

    const openChars = "({[";
    let stack = []
    for (let i = 0; i < s.length; i++) {
        if (openChars.includes(s[i]))
            stack.push(s[i]);
        else if (isValidOpenChar(stack[stack.length - 1], s[i]))
            stack.pop()
        else
            return false;
    }
    return stack.length == 0;
}

function isValidOpenChar(target: string, closeChar: string): boolean {
    switch (closeChar) {
        case ')':
            return target == '(';
        case ']':
            return target == '[';
        case '}':
            return target == '{';
        default:
            throw new Error("The character is not supported.");
    }
}
