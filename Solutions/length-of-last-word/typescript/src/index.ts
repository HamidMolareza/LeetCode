console.log(lengthOfLastWord("Hello World"))
console.log(lengthOfLastWord("   fly me   to   the moon  "))
console.log(lengthOfLastWord("luffy is still joyboy"))

function lengthOfLastWord(s: string): number {
    const wordMatches = [...s.matchAll(/[A-Za-z]+/g)];
    const lastWordMatch = wordMatches[wordMatches.length - 1];
    const lastWord = lastWordMatch[0];
    return lastWord.length;
}

function lengthOfLastWord2(s: string): number {
    return [...s.matchAll(/[A-Za-z]+/g)].pop()![0].length;
}

function lengthOfLastWord3(s: string): number {
    return s.trim().split(" ").pop()!.length
}

