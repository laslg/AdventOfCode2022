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

        var scenicScore = 0;
        for (int i = 0; i < yCount; i++)
        {
            for (int j = 0; j < xCount; j++)
            {
                if (i == 0 || i == yCount-1 || j == 0 || j == xCount-1) //Edges
                {
                    continue;
                }
                else
                {
                    int scoreLeft = 0, scoreRight = 0, scoreTop = 0, scoreBottom = 0;
                    var curTree = grid[i][j];
                    // Venstre
                    for (int k = j - 1; k >= 0; k--)
                    {
                        scoreLeft++;
                        if (curTree <= grid[i][k])
                            break;                        
                    }
                    // Højre
                    for (int k = j + 1; k < xCount; k++)
                    {
                        scoreRight++;
                        if (curTree <= grid[i][k])
                            break;                        
                    }
                    // Oppe
                    for (int k = i - 1; k >= 0; k--)
                    {
                        scoreTop++;
                        if (curTree <= grid[k][j])
                            break;                        
                    }
                    // Nede
                    for (int k = i + 1; k < yCount; k++)
                    {
                        scoreBottom++;
                        if (curTree <= grid[k][j])
                            break;                        
                    }
                    var score = scoreLeft * scoreRight * scoreTop * scoreBottom;
                    if (scenicScore < score)
                    {
                        scenicScore = score;
                    }
                }
            }            
        }

        return scenicScore;
    }

}

static class CharExtensions
{
    public static int ToInt(this char c)
    {
        return c - '0';
    }    
}