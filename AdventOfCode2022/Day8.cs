internal class Day8
{
    internal static int Solve()
    {
        var input = File.ReadAllLines("./Inputs/day8_input.txt");
        var numX = input[0].Length;
        var numY = input.Length;

        var grid = new int[numY][];
        for (int i = 0; i < input.Length; i++)
        {
            grid[i] = new int[numX];
            for (int j = 0; j < input[i].Length; j++)
            {
                grid[i][j] = input[i][j].ToInt();
            }
        }

        var visibleCount = 0;
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (i == 0 || i == grid.Length || j == 0 || j == grid[i].Length) //Edges
                {
                    visibleCount++;
                }
                else
                {
                    var tree = grid[i][j];
                    bool isVisible = true;
                    // Venstre
                    for (int k = 0; k < i; k++)
                    {
                        if (tree <= grid[k][j])
                        {
                            isVisible = false;
                            break;
                        }
                    }
                    if (isVisible)
                    {
                        visibleCount++;                        
                        continue;
                    }
                    // Højre
                    for (int k = j+1; k < grid.Length; k++)
                    {
                        if (tree <= grid[k][j])
                        {
                            isVisible = false;
                            break;
                        }
                    }
                    if (isVisible)
                    {
                        visibleCount++;                        
                        continue;
                    }
                    // Oppe
                    for (int k = 0; k < j; k++)
                    {
                        if (tree <= grid[i][k])
                        {
                            isVisible = false;
                            break;
                        }
                    }
                    if (isVisible)
                    {
                        visibleCount++;                        
                        continue;
                    }
                    // Nede
                    for (int k = i+1; k < grid[i].Length; k++)
                    {
                        if (tree <= grid[i][k])
                        {
                            isVisible = false;
                            break;
                        }
                    }
                    if (isVisible)
                    {
                        visibleCount++;                        
                        continue;
                    }
                }
            }
            
        }
        

        return visibleCount;        
        
    }

}

static class CharExtensions
{
    public static int ToInt(this char c)
    {
        return (int)(c - '0');
    }    
}