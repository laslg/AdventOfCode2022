internal class Day1 : PuzzleBase
{
    public override string Solve()
    {
        var input = File.ReadAllLines("./Inputs/day1_input.txt");

        var elves = new List<int>();
        var calories = 0;
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] != string.Empty)
            {
                calories += int.Parse(input[i]);
            }
            else
            {
                elves.Add(calories);
                calories = 0;
            }
        }
        var ordered = elves.OrderByDescending(c => c);
        return ordered.Take(3).Sum().ToString();
    }
}