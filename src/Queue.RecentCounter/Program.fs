open System.Collections.Generic

type RecentCounter() =
    let queue = Queue<int>()
    member this.Ping(t: int) =
        queue.Enqueue(t)
        while queue.Peek() < t - 3000 do
            queue.Dequeue() |> ignore
        queue.Count

let recentCounter = RecentCounter()
let result1 = recentCounter.Ping(1)
printfn $"Ping at 1: %d{result1}"
let result2 = recentCounter.Ping(100)
printfn $"Ping at 100: %d{result2}"
let result3 = recentCounter.Ping(3001)
printfn $"Ping at 3001: %d{result3}"
let result4 = recentCounter.Ping(3002)
printfn $"Ping at 3002: %d{result4}"
