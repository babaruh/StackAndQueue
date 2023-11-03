type MinStack() =
    let mutable stack = []
    let mutable minStack = []

    member this.Push(value: int) =
        stack <- value :: stack
        match minStack with
        | [] -> minStack <- value :: minStack
        | h :: _ when value <= h -> minStack <- value :: minStack
        | _ -> ()

    member this.Pop() =
        match stack, minStack with
        | [], _ -> ()
        | h1 :: t1, h2 :: t2 when h1 = h2 -> 
            stack <- t1
            minStack <- t2
        | _ :: t1, _ -> stack <- t1

    member this.Top() =
        match stack with
        | [] -> failwith "Stack is empty"
        | h :: _ -> h

    member this.GetMin() =
        match minStack with
        | [] -> failwith "Stack is empty"
        | h :: _ -> h

let minStack = MinStack()
minStack.Push(-2)
minStack.Push(0)
minStack.Push(-3)
minStack.GetMin() |> printfn "%A"
minStack.Pop()
minStack.Top() |> printfn "%A"
minStack.GetMin() |> printfn "%A"
