open System.Collections.Generic

let maxSlidingWindow (nums: int array) (k: int): int array =
    let deq = LinkedList<int>()
    let res = ResizeArray()
    for i = 0 to nums.Length - 1 do
        if deq.Count > 0 && deq.First.Value < i - k + 1 then
            deq.RemoveFirst()

        while deq.Count > 0 && nums.[deq.Last.Value] < nums.[i] do
            deq.RemoveLast()
        deq.AddLast(i) |> ignore

        if i >= k - 1 then
            res.Add(nums.[deq.First.Value])
    res.ToArray()

let nums1 = [|1;3;-1;-3;5;3;6;7|]
let nums2 = [|1|]
let k1 = 3
let k2 = 1

printfn $"%A{maxSlidingWindow nums1 k1}"
printfn $"%A{maxSlidingWindow nums2 k2}"
