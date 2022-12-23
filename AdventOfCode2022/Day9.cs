internal class Day9 : PuzzleBase
{
    public override string Solve()
    {
        var input = File.ReadAllLines("./Inputs/day9_input.txt");
        
        Knot head = new(), tail = new();
        var tailCoordinates = new HashSet<KeyValuePair<int, int>> { new KeyValuePair<int, int>(tail.X, tail.Y) };

        for (int i = 0; i < input.Length; i++)
        {
            MakeMove(head, tail, input[i], tailCoordinates);
        }

        return tailCoordinates.Count.ToString();
    }

    private void MakeMove(Knot head, Knot tail, string move, HashSet<KeyValuePair<int, int>> tailCoordinates)
    {
        var direction = move[0].ToDirection();
        var steps = int.Parse(move.Substring(2));

        for (int i = 0; i < steps; i++)
        {
            switch (direction)
            {
                case Direction.Up:
                    head.Y++;
                    break;
                case Direction.Down:
                    head.Y--;
                    break;
                case Direction.Left:
                    head.X--;
                    break;
                case Direction.Right:
                    head.X++;
                    break;
            }

            if (!head.IsAdjecentTo(tail))
            {
                MoveTail(head, tail, direction);
                tailCoordinates.Add(new KeyValuePair<int, int>(tail.X, tail.Y));
            }            
        }
    }

    private static void MoveTail(Knot head, Knot tail, Direction direction)
    {
        if (direction == Direction.Up || direction == Direction.Down)
        {
            tail.X = head.X;

            if (tail.Y < head.Y)
                tail.Y = head.Y - 1;
            else
                tail.Y = head.Y + 1;            
        }
        else
        {
            tail.Y = head.Y;

            if (tail.X < head.X)
                tail.X = head.X - 1;
            else
                tail.X = head.X + 1;
        }
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