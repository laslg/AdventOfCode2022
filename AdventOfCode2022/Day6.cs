internal class Day6
{
    internal static object Solve()
    {
        var input = File.ReadAllText("./day6_input.txt");

        int index = 0;
        var chars = new char[4];
        for (index = 0; index < input.Length; index++)
        {
            chars[0] = input[index];
            chars[1] = input[index + 1];
            chars[2] = input[index + 2];
            chars[3] = input[index + 3];
            if (chars[0] != chars[1]
                && chars[0] != chars[2]
                && chars[0] != chars[3]
                && chars[1] != chars[2]
                && chars[1] != chars[3]
                && chars[2] != chars[3])
            {
                break;
            }
        }

        int numberOfChars = index + 4;
        return numberOfChars;
    }
}