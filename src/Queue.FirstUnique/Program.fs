open System.Collections.Generic

let firstUniqChar (s: string) =
    let dict = Dictionary<char, int>()
    let queue = Queue<char>()
    
    for c in s do
        if dict.ContainsKey(c) then
            dict.[c] <- dict.[c] + 1
        else
            dict.[c] <- 1
            queue.Enqueue(c)
    
    while queue.Count > 0 && dict.[queue.Peek()] > 1 do
        queue.Dequeue() |> ignore
    
    if queue.Count = 0 then -1 else s.IndexOf(queue.Peek())

// Приклад 1:
// Input: s = "leopard" Output: 0
//
// Приклад 2:
// Input: s = "loveleopard" Output: 2
//
// Приклад 3:
// Input: s = "aabb" Output: -1 

let s1 = "leopard"
let s2 = "loveleopard"
let s3 = "aabb"

firstUniqChar s1 |> printfn "%d"
firstUniqChar s2 |> printfn "%d"
firstUniqChar s3 |> printfn "%d"
