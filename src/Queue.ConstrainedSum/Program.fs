open System
open System.Collections.Generic

let constrainedSubsetSum (nums: int[]) (k: int) : int =
    let dp = Array.zeroCreate nums.Length
    let q = Queue<int>()
    let mutable res = Int32.MinValue
    for i = 0 to nums.Length - 1 do
        if q.Count > 0 && q.Peek() < i - k then
            q.Dequeue() |> ignore
            
        dp[i] <- nums[i] + (if q.Count > 0 then dp[q.Peek()] else 0)
        
        while q.Count > 0 && dp[i] > dp[q.Peek()] do
            q.Dequeue() |> ignore
            
        if dp[i] > 0 then
            q.Enqueue(i)
            
        res <- max res dp[i]
    res

constrainedSubsetSum [|10;2;-10;5;20|] 2 |> printfn "%A"
constrainedSubsetSum [|-1;-2;-3|] 1 |> printfn "%A"
constrainedSubsetSum [|10;-2;-10;-5;20|] 2 |> printfn "%A"
