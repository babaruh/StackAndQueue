open System.Collections.Generic

let evalRPN (tokens: string list) : int =
    let stack = Stack<int>()
    let operators = ["+"; "-"; "*"; "/"]
    
    let applyOperation op a b =
        match op with
        | "+" -> a + b
        | "-" -> a - b
        | "*" -> a * b
        | "/" -> a / b
        | _ -> failwith "Unknown operator"
    
    for token in tokens do
        if operators |> List.contains token then
            let b = stack.Pop()
            let a = stack.Pop()
            stack.Push(applyOperation token a b)
        else
            stack.Push(int token)
    
    stack.Pop()

let tokens1 = ["2";"1";"+";"3";"*"]
printfn $"%d{evalRPN tokens1}"  // Output: 9

let tokens2 = ["4";"13";"5";"/";"+"]
printfn $"%d{evalRPN tokens2}"  // Output: 6

let tokens3 = ["10";"6";"9";"3";"+";"-11";"*";"/";"*";"17";"+";"5";"+"]
printfn $"%d{evalRPN tokens3}"  // Output: 22
