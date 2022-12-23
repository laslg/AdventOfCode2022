internal class Day6 : PuzzleBase
{
    public override string Solve()
    {
        var input = File.ReadAllText("./Inputs/day6_input.txt");

        int index = 0;
        var chars = new char[14];
        for (index = 0; index < input.Length; index++)
        {
            for (int i = 0; i < 14; i++)
            {
                chars[i] = input[index + i];
            }

            if (CheckArray(chars))
            {
                break;
            }

            //chars[0] = input[index];
            //chars[1] = input[index + 1];
            //chars[2] = input[index + 2];
            //chars[3] = input[index + 3];
            //if (chars[0] != chars[1]
            //    && chars[0] != chars[2]
            //    && chars[0] != chars[3]
            //    && chars[1] != chars[2]
            //    && chars[1] != chars[3]
            //    && chars[2] != chars[3])
            //{
            //    break;
            //}
        }

        int numberOfChars = index + 14;
        return numberOfChars.ToString();
    }

    private static bool CheckArray(char[] chars)
    {
        var hs = new HashSet<char>(chars);
        return hs.Count == chars.Length;
    }
}