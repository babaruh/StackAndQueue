let validateBrackets (s: string) =
    let matchingBracket b =
        match b with
        | ')' -> Some '('
        | ']' -> Some '['
        | '}' -> Some '{'
        | _ -> None

    let isOpeningBracket b =
        b = '(' || b = '[' || b = '{'

    let rec loop stack chars =
        match chars, stack with
        | [], [] -> true
        | [], _ -> false
        | head::tail, _ when isOpeningBracket head -> loop (head::stack) tail
        | head::tail, top::rest when matchingBracket head = Some top -> loop rest tail
        | _ -> false

    loop [] (List.ofSeq s)

let test = validateBrackets "({[]})"
printfn $"%A{test}"
