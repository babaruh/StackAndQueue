let longestValidParentheses (s: string) : int =
    let mutable maxLen = 0
    let mutable stack = [|-1|]
    for i in 0..s.Length-1 do
        if s[i] = '(' then
            stack <- Array.append stack [|i|]
        else
            stack <- stack[..stack.Length-2]
            if stack.Length = 0 then
                stack <- Array.append stack [|i|]
            else
                maxLen <- max maxLen (i - stack[stack.Length-1])
    maxLen

let s1 = "(()"
let s2 = ")()())"
let s3 = ""

printfn $"%A{longestValidParentheses s1}"
printfn $"%A{longestValidParentheses s2}"
printfn $"%A{longestValidParentheses s3}"
