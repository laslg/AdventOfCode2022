internal class Day9 : PuzzleBase
{
    public override string Solve()
    {
        var input = File.ReadAllLines("./Inputs/day9_input.txt");
        
        Knot head = new(), tail = new();
        var tailCoordinates = new HashSet<KeyValuePair<int, int>> { new KeyValuePair<int, int>(tail.X, tail.Y) };

        for (int i = 0; i < input.Length; i++)
        {
            MakeMove(head, tail, input[i]);
        }

        return tailCoordinates.Count.ToString();
    }

    private void MakeMove(Knot head, Knot tail, string move)
    {
        var direction = move[0].ToDirection();
        var steps = int.Parse(move.Substring(2));
        switch (direction)
        {
            case Direction.Up:
                head.Y += steps;
                break;
            case Direction.Down:
                head.Y -= steps;
                break;
            case Direction.Left:
                head.X -= steps;
                break;
            case Direction.Right:
                head.X += steps;
                break;
        }

        if (!head.IsAdjecentTo(tail))
        {
            MoveTail(head, tail, direction);
        }

    }

    private static void MoveTail(Knot head, Knot tail, Direction direction)
    {
        if (head.Y == tail.Y) // Only Left/Right
        {
            if (tail.X < head.X)
                tail.X = head.X - 1;
            else
                tail.X = head.X + 1;
        }
        else if (head.X == tail.X) // Up/Down
        {
            if (tail.Y < head.Y)
                tail.Y = head.Y - 1;
            else
                tail.Y = head.Y + 1;
        }

        //TODO mangler når det er skråt!
    }

    private record Knot 
    {
        public int X { get; set; } = default!;
        public int Y { get; set; } = default!;
        public bool IsAdjecentTo(Knot other)
        {
            if (1 < Math.Abs(other.X - X) || 1 < Math.Abs(other.Y - Y))
            {
                return false;
            }
            return true;
        }
    }
}

enum Direction
{
    Up,
    Down,
    Left,
    Right
}