var solution = new Solution();
var result = solution.MovesToStamp("abc", "ababc");
Console.WriteLine(string.Join(", ", result));

var result1 = solution.MovesToStamp("abca", "aabcaca");
Console.WriteLine(string.Join(", ", result1));

internal class Solution
{
    public IEnumerable<int> MovesToStamp(string stamp, string target)
    {
        var t = target.ToCharArray();
        var s = stamp.ToCharArray();
        var res = new Queue<int>();
        var visited = new bool[t.Length];
        var stars = 0;

        while (stars < t.Length)
        {
            var doneReplace = false;
            for (var i = 0; i <= t.Length - s.Length; i++)
            {
                if (visited[i] || !canReplace(t, i, s))
                    continue;

                stars = doReplace(t, i, s.Length, stars);
                doneReplace = true;
                visited[i] = true;
                res.Enqueue(i); // Changed this line to use Queue
                if (stars == t.Length)
                    return res.ToArray();
            }

            if (!doneReplace)
                return Array.Empty<int>();
        }

        return res.ToArray();
    }

    private bool canReplace(IReadOnlyList<char> t, int p, IEnumerable<char> s)
    {
        return !s.Where((t1, i) => t[i + p] != '*' && t[i + p] != t1).Any();
    }

    private int doReplace(IList<char> t, int p, int len, int count)
    {
        for (var i = 0; i < len; i++)
        {
            if (t[i + p] == '*')
                continue;

            t[i + p] = '*';
            count++;
        }

        return count;
    }
}
