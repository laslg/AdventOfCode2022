internal class Day5
{
    public static string Solve()
    {
        var input = File.ReadAllLines("./day5_input.txt");
        var moveInput = input.Where(l => l.IndexOf("move") > -1).ToArray();
        var stacks = GetStacks();

        foreach (var move in moveInput)
        {
            //move 11 from 1 to 8
            var cratesToMove = int.Parse(move.Substring(5, 2).Trim());
            var from = int.Parse(move.Substring(move.IndexOf("from ") + 5, 1));
            var to = int.Parse(move.Substring(move.Length - 1, 1));

            for (int i = 0; i < cratesToMove; i++)
            {
                var crate = stacks[from].Last();
                stacks[from].RemoveAt(stacks[from].LastIndexOf(crate));
                stacks[to].Add(crate);                
            }
        }
        var result = string.Join("",stacks.Values.Select(c => c.Last())).Replace("[","").Replace("]","");

        return result;
    }

    private static Dictionary<int,List<string>> GetStacks()
    {
        var stacks = new Dictionary<int,List<string>>();
        stacks.Add(1,new List<string>{"[S]","[C]","[V]","[N]"});
        stacks.Add(2,new List<string>{"[Z]","[M]","[J]","[H]","[N]","[S]"});
        stacks.Add(3,new List<string>{"[M]","[C]","[T]","[G]","[J]","[N]","[D]"});
        stacks.Add(4,new List<string>{"[T]","[D]","[F]","[J]","[W]","[R]","[M]"});
        stacks.Add(5,new List<string>{"[H]","[F]","[P]"});
        stacks.Add(6,new List<string>{"[C]","[T]","[Z]","[H]","[J]"});
        stacks.Add(7,new List<string>{"[D]","[P]","[R]","[Q]","[F]","[S]","[L]","[Z]"});
        stacks.Add(8,new List<string>{"[C]","[S]","[L]","[H]","[D]","[F]","[P]","[W]"});
        stacks.Add(9,new List<string>{"[D]","[S]","[M]","[P]","[F]","[N]","[G]","[Z]"});
        return stacks;
    }
    /*
                        [Z] [W] [Z]
        [D] [M]         [L] [P] [G]
    [S] [N] [R]         [S] [F] [N]
    [N] [J] [W]     [J] [F] [D] [F]
[N] [H] [G] [J]     [H] [Q] [H] [P]
[V] [J] [T] [F] [H] [Z] [R] [L] [M]
[C] [M] [C] [D] [F] [T] [P] [S] [S]
[S] [Z] [M] [T] [P] [C] [D] [C] [D]
 1   2   3   4   5   6   7   8   9     
    
    */
}