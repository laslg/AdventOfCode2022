internal class Day7 : PuzzleBase
{
    public override string Solve()
    {
        var input = File.ReadAllLines("./Inputs/day7_input.txt");

        var topDir = new Dir(@"/", null);
        var curDir = topDir;
        for (int i = 1; i < input.Length; i++)
        {
            var line = input[i];
            if (line.First() == '$') //Is command
            {
                switch (line.Substring(2,2))
                {
                    case "cd": //Change directory                                    
                        if (line.Substring(5,2) == "..") // Move up
                        {
                            curDir = curDir.Parent;
                        }
                        else // Move in
                        {
                            var newDirName = line.Substring(5);
                            curDir = curDir.Dirs.Single(d => d.Name == newDirName);                                                
                        }
                        break;

                    case "ls": // List                        
                        break;

                    default:
                        break;
                }
            }
            else // Is list of dir contents
            {
                if(line.Substring(0,3) == "dir")
                {
                    var dirName = line.Substring(4);
                    curDir.Dirs.Add(new Dir(dirName, curDir));
                }
                else // File
                {
                    var size = line.Substring(0, line.IndexOf(" "));
                    var fileName = line.Substring(line.IndexOf(" ") + 1);
                    curDir.Files.Add(new MyFile(fileName, int.Parse(size)));                    
                }                
            }
        }

        IEnumerable<Dir> all = Traverse<Dir>(topDir, d => d.Dirs);
        //var bigDirs = all.Where(d => d.GetTotalSize() <= 100000).ToList();
        //int v = bigDirs.Sum(d => d.GetTotalSize());

        var totalSpace = 70000000;
        var spaceNeeded = 30000000;
        int totalUsed = topDir.GetTotalSize();
        //System.Console.WriteLine($"Total size used: {totalUsed}");
        var remainderNeed = spaceNeeded - (totalSpace - totalUsed);

        var sacrificeDir = all.Where(d => d.GetTotalSize() >= remainderNeed).Min(d => d.GetTotalSize());

        return sacrificeDir.ToString();
    }

    private static IEnumerable<T> Traverse<T>(T item, Func<T, IEnumerable<T>> childSelector)
    {   
        var stack = new Stack<T>();
        stack.Push(item);
        while (stack.Any())
        {
            var next = stack.Pop();
            yield return next;
            foreach (var child in childSelector(next))
                stack.Push(child);
        }
    }
}

class Dir
{
    public List<Dir> Dirs { get; set; }
    public List<MyFile> Files { get; set; }
    public string Name { get; }
    public Dir? Parent { get; }

    public Dir(string name, Dir? parent)
    {
        Dirs = new List<Dir>();
        Files = new List<MyFile>();
        Name = name;
        Parent = parent;
    }

    public int GetTotalSize()
    {
        var totalFileSize = Files.Sum(f => f.Size);
        return totalFileSize + Dirs.Sum(d => d.GetTotalSize());
    }
}

public record MyFile(string Name, int Size);

