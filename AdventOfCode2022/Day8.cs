internal class Day8
{
    internal static int Solve()
    {
        var input = File.ReadAllLines("./Inputs/day8_input.txt");
        int xCount = input[0].Length, yCount = input.Length;

        //Build grid array
        var grid = new int[yCount][];
        for (int i = 0; i < yCount; i++)
        {
            grid[i] = new int[xCount];
            for (int j = 0; j < xCount; j++)
            {
                grid[i][j] = input[i][j].ToInt();
            }
        }

        var visibleCount = 0;
        for (int i = 0; i < yCount; i++)
        {
            for (int j = 0; j < xCount; j++)
            {
                if (i == 0 || i == yCount || j == 0 || j == xCount) //Edges
                {
                    visibleCount++;
                }
                else
                {
                    var curTree = grid[i][j];
                    bool isVisible = true;
                    // Venstre
                    for (int k = 0; k < j; k++)
                    {
                        if (curTree <= grid[i][k])
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
                    isVisible = true;
                    for (int k = j+1; k < xCount; k++)
                    {
                        if (curTree <= grid[i][k])
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
                    isVisible = true;
                    for (int k = 0; k < i; k++)
                    {
                        if (curTree <= grid[k][j])
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
                    isVisible = true;
                    for (int k = i+1; k < yCount; k++)
                    {
                        if (curTree <= grid[k][j])
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
        return c - '0';
    }    
}