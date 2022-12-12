internal class Day4
{
    public static int Solve()
    {
        var input = File.ReadAllLines("./Inputs/day4_input.txt");

        var overlaps = 0;

        for (int i = 0; i < input.Length; i++)
        {
            string[] pair = input[i].Split(',');
            var m1 = GetSections(pair[0]);
            var m2 = GetSections(pair[1]);

            if (m1.Any(s => m2.Contains(s)) || m2.Any(s => m1.Contains(s)))
            {
                overlaps++;
            }
        }

        return overlaps;
    }

    private static int[] GetSections(string range)
    {
        var start = range.Substring(0, range.IndexOf('-'));
        var end = range.Substring(range.IndexOf('-') + 1);
        var sectionCount = int.Parse(end) - int.Parse(start);

        var sections = new List<int>();
        sections.Add(int.Parse(start));
        for (int i = 0; i < sectionCount; i++)
        {
            sections.Add(sections[i] + 1);
        }
        return sections.ToArray();
    }
}