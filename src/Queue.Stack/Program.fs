open System.Collections.Generic

type Stack<'T>() =
    let mutable queue1 = Queue<'T>()
    let mutable queue2 = Queue<'T>()

    member this.Push(item: 'T) =
        queue2.Enqueue(item)
        while queue1.Count > 0 do
            queue2.Enqueue(queue1.Dequeue())
        let temp = queue1
        queue1 <- queue2
        queue2 <- temp

    member this.Pop() =
        if this.Empty() then
            failwith "Stack is empty"
        else
            queue1.Dequeue()

    member this.Top() =
        if this.Empty() then
            failwith "Stack is empty"
        else
            queue1.Peek()

    member this.Empty() =
        (queue1.Count = 0)

let myStack = Stack<int>()
myStack.Push(1)
myStack.Push(2)
let top = myStack.Top()
let popped = myStack.Pop()
let isEmpty = myStack.Empty()

printfn $"Top: %d{top}"
printfn $"Popped: %d{popped}"
printfn $"Is Empty: %b{isEmpty}"


