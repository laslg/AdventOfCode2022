static class CharExtensions
{
    public static int ToInt(this char c)
    {
        return c - '0';
    }

    public static Direction ToDirection(this char c)
    {
        return c switch
        {
            'U' => Direction.Up,
            'D' => Direction.Down,
            'L' => Direction.Left,
            'R' => Direction.Right,
            _ => throw new ArgumentException($"{c} is no good:-("),
        };
    }
}