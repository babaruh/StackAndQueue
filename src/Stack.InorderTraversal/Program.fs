open System.Collections.Generic

type TreeNode =
    | Null
    | Node of int * TreeNode * TreeNode

let inorderTraversal (root: TreeNode) =
    let mutable current = root
    let stack = Stack<TreeNode>()
    let res = ResizeArray<int>()

    while stack.Count > 0 || current <> Null do
        while current <> Null do
            stack.Push current
            match current with
            | Node(_, left, _) -> current <- left
            | _ -> ()
        let top = stack.Pop()
        match top with
        | Node(value, _, right) ->
            res.Add value
            current <- right
        | _ -> ()

    res.ToArray()

let root1 = Node(1, Null, Node(2, Node(3, Null, Null), Null))
let root2 = Null
let root3 = Node(1, Null, Null)

let res1 = inorderTraversal root1
let res2 = inorderTraversal root2
let res3 = inorderTraversal root3

printfn $"%A{res1}"

printfn $"%A{res2}"

printfn $"%A{res3}"
