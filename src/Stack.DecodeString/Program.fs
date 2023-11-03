open System.Collections.Generic

let decodeString (s: string) : string =
    let stack = Stack<string>()
    let numStack = Stack<int>()
    let mutable num = 0
    let mutable res = ""
    for c in s do
        if System.Char.IsDigit(c) then
            num <- num * 10 + int(System.Char.GetNumericValue(c))
        elif c = '[' then
            numStack.Push(num)
            stack.Push(res)
            num <- 0
            res <- ""
        elif c = ']' then
            let mutable temp = stack.Pop()
            let count = numStack.Pop()
            for _ in 1..count do
                temp <- temp + res
            res <- temp
        else
            res <- res + c.ToString()
    res

// Приклад 1:
// Input: s = "3[a]2[bc]" Output: "aaabcbc"
//
// Приклад 2:
// Input: s = "3[a2[c]]" Output: "accaccacc"
//
// Приклад 3:
// Input: s = "2[abc]3[cd]ef" Output: "abcabccdcdcdef"

let s1 = "3[a]2[bc]"
let s2 = "3[a2[c]]"
let s3 = "2[abc]3[cd]ef"

printfn $"%s{decodeString s1}"
printfn $"%s{decodeString s2}"
printfn $"%s{decodeString s3}"
