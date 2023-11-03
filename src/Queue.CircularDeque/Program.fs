open System.Collections.Generic

type MyCircularDeque(k: int) =
    let queue1 = Queue<int>()
    let queue2 = Queue<int>()
    let mutable size = 0

    member this.InsertFront(value: int) =
        if size < k then
            queue1.Enqueue(value)
            size <- size + 1
            true
        else
            false

    member this.InsertLast(value: int) =
        if size < k then
            queue2.Enqueue(value)
            size <- size + 1
            true
        else
            false

    member this.DeleteFront() =
        if queue1.Count > 0 then
            ignore(queue1.Dequeue())
            size <- size - 1
            true
        else
            false

    member this.DeleteLast() =
        if queue2.Count > 0 then
            ignore(queue2.Dequeue())
            size <- size - 1
            true
        else
            false

    member this.GetFront() =
        if queue1.Count > 0 then 
            queue1.Peek()
        else 
            -1

    member this.GetRear() =
        if queue2.Count > 0 then 
            queue2.Peek()
        else 
            -1

    member this.IsEmpty() = (size = 0)

    member this.IsFull() = (size = k)


let myCircularDeque = MyCircularDeque(3)
printfn $"%A{myCircularDeque.InsertLast(1)}"  // Outputs: true
printfn $"%A{myCircularDeque.InsertLast(2)}"  // Outputs: true
printfn $"%A{myCircularDeque.InsertFront(3)}" // Outputs: true
printfn $"%A{myCircularDeque.InsertFront(4)}" // Outputs: false, the queue is full.
printfn $"%A{myCircularDeque.GetRear()}"      // Outputs: 1
printfn $"%A{myCircularDeque.IsFull()}"       // Outputs: true
printfn $"%A{myCircularDeque.DeleteLast()}"   // Outputs: true
printfn $"%A{myCircularDeque.InsertFront(4)}" // Outputs: true
printfn $"%A{myCircularDeque.GetFront()}"     // Outputs: 3
