internal class Day3
{
    public static int Solve()
    {
        var input = File.ReadAllLines("./Inputs/day3_input.txt");

        var teams = new List<string[]>();
        var team = new List<string>();
        for (int i = 0; i < input.Length; i++)
        {
            team.Add(input[i]);            

            if (team.Count == 3)
            {
                teams.Add(team.ToArray());
                team.Clear();
            }            
        }

        var prioritySum = 0;
        for (int i = 0; i < teams.Count; i++)
        {
            var badge = teams[i][0].Intersect(teams[i][1]).Intersect(teams[i][2]).Single();
            // var sack = input[i];
            // var half = sack.Length/2;
            // var comp1 = sack.Substring(0, half);
            // var comp2 = sack.Substring(half);
            //var sharedChar = comp1.First(c => comp2.IndexOf(c) > -1);
            var charValue = vals.IndexOf(badge) + 1;
            prioritySum += charValue;
        }

        return prioritySum;
    }

    const string vals = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
}