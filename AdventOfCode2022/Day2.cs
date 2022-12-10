internal class Day2
{
    const char elf_rock = 'A';
    const char elf_paper = 'B';
    const char elf_scissor = 'C';
    const char my_rock = 'X';
    const char my_paper = 'Y';
    const char my_scissor = 'Z';

    const int rockScore = 1;
    const int paperScore = 2;
    const int scissorScore = 3;
    const int drawScore = 3;
    const int winScore = 6;


    internal static int Solve()
    {
        var input = File.ReadAllLines("./day2_input.txt");

        var elves = new List<int>();
        var totalPoints = 0;
        for (int i = 0; i < input.Length; i++)
        {
            var round = input[i];
            var elf = round[0];
            var me = round[2];

            var isWinner = (me == my_rock && elf == elf_scissor)
                        || (me == my_paper && elf == elf_rock)
                        || (me == my_scissor && elf == elf_paper);

            if(isWinner)
            {
                totalPoints += (winScore + GetScore(me));
                continue;
            }

            var isDraw = (me == my_rock && elf == elf_rock)
                    || (me == my_paper && elf == elf_paper)
                    || (me == my_scissor && elf == elf_scissor);

            if (isDraw)
            {
                totalPoints += (drawScore + GetScore(me));
                continue;
            }
            
            totalPoints += GetScore(me);
                       
        }

        return totalPoints;
    }

    private static int GetScore(char me)
    {
        switch (me)
        {
            case my_rock:
                return rockScore;
            case my_paper:
                return paperScore;
            case my_scissor:
                return scissorScore;
            default:
                return 0;
        }
    }
}