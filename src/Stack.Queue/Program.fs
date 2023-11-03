type MyQueue() =
    let mutable stack1 = []
    let mutable stack2 = []

    member this.Push(x) =
        stack1 <- x :: stack1

    member this.Pop() =
        if stack2.Length = 0 then
            while stack1.Length > 0 do
                let top = List.head stack1
                stack1 <- List.tail stack1
                stack2 <- top :: stack2
        let top = List.head stack2
        stack2 <- List.tail stack2
        top

    member this.Peek() =
        if stack2.Length = 0 then
            while stack1.Length > 0 do
                let top = List.head stack1
                stack1 <- List.tail stack1
                stack2 <- top :: stack2
        List.head stack2

    member this.Empty() =
        stack1.Length = 0 && stack2.Length = 0

let queue = MyQueue()
queue.Push(1)
queue.Push(2)
queue.Peek() |> printfn "%A"
queue.Pop() |> printfn "%A"
queue.Empty() |> printfn "%A"
