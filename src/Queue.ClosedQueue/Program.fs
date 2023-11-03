type MyCircularQueue(k:int) =
    let queue = Array.zeroCreate k
    let mutable head = 0
    let mutable tail = 0
    let mutable count = 0

    member this.Front() =
        if this.isEmpty() then -1
        else queue.[head]

    member this.Rear() =
        if this.isEmpty() then -1
        else queue.[tail]

    member this.enQueue(value:int) =
        if this.isFull() then false
        else
            queue.[tail] <- value
            tail <- (tail + 1) % k
            count <- count + 1
            true

    member this.deQueue() =
        if this.isEmpty() then false
        else
            head <- (head + 1) % k
            count <- count - 1
            true

    member this.isEmpty() =
        count = 0

    member this.isFull() =
        count = k

let myCircularQueue = MyCircularQueue(3)

printfn $"%A{myCircularQueue.enQueue 1}" // returns true
printfn $"%A{myCircularQueue.enQueue 2}" // returns true
printfn $"%A{myCircularQueue.enQueue 3}" // returns true
printfn $"%A{myCircularQueue.enQueue 4}" // returns false
printfn $"%A{myCircularQueue.Rear()}" // returns 3
printfn $"%A{myCircularQueue.isFull()}" // returns true
printfn $"%A{myCircularQueue.deQueue()}" // returns true
printfn $"%A{myCircularQueue.enQueue(4)}" // returns true
printfn $"%A{myCircularQueue.Rear()}" // returns 4
