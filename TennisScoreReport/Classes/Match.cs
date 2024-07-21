using System.Text;

namespace Tennis.Classes
{
    public class Match
    {
        public List<bool> Scoresheet { get; set; }
        public MatchStatus Status { get; set; }
        public List<Set> Sets { get; set; } = new List<Set>();
        public int MaxSets { get; set; }
        public int SetsToWin { get { return MaxSets / 2 + 1; } }
        public int PlayerASets { get; set; }
        public int PlayerBSets { get; set; }
        public Match(List<bool> scoresheet, int maxSets)
        {
            Scoresheet = scoresheet;
            Status = MatchStatus.Playing;
            MaxSets = maxSets;
        }

        public void ProcessScoresheet()
        {
            PrintInitialScoresheet(Scoresheet);
            while (Status == MatchStatus.Playing)
            {
                var set = new Set(Scoresheet);
                Sets.Add(set);
                var result = set.ProcessSet();
                if (result == "PlayerA")
                {
                    PlayerASets++;
                    if (PlayerASets == SetsToWin)
                    {
                        Status = MatchStatus.PlayerAWins;
                        Console.WriteLine("--> Player A wins the match!");
                    }
                }
                else if (result == "PlayerB")
                {
                    PlayerBSets++;
                    if (PlayerBSets == SetsToWin)
                    {
                        Status = MatchStatus.PlayerBWins;
                        Console.WriteLine("--> Player B wins the match!");
                    }
                }
                else
                {
                    Status = MatchStatus.Unclear;
                    Console.WriteLine("--> Could not determine set winner.");
                }
            }
        }
        private void PrintInitialScoresheet(List<bool> scoresheet)
        {
            var score = new StringBuilder();
            score.Append("--> Scoresheet: ");

            for (int i = 0; i < scoresheet.Count - 1; i++)
            {
                score.Append(scoresheet[i] ? "1, " : "0, ");
            }
            score.Append(scoresheet[scoresheet.Count - 1] ? "1" : "0");
            Console.WriteLine(score);
        }
    }
}