internal abstract class PuzzleBase
{
    public abstract string Solve();
}

static class CharExtensions
{
    public static int ToInt(this char c)
    {
        return c - '0';
    }
}