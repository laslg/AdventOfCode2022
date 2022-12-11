internal class Day3
{
    public static int Solve()
    {
        var input = File.ReadAllLines("./day3_input.txt");

        var prioritySum = 0;
        for (int i = 0; i < input.Length; i++)
        {
            var sack = input[i];
            var half = sack.Length/2;
            var comp1 = sack.Substring(0, half);
            var comp2 = sack.Substring(half);

            var sharedChar = comp1.First(c => comp2.IndexOf(c) > -1);
            var charValue = vals.IndexOf(sharedChar) + 1;
            prioritySum += charValue;
        }

        return prioritySum;
    }

    const string vals = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
}