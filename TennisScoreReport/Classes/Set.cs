namespace Tennis.Classes
{
    public class Set
    {
        public List<bool> Scoresheet { get; set; }
        public int PlayerAGames { get; set; }
        public int PlayerBGames { get; set; }
        public SetStatus Status { get; set; }
        public List<Game> Games { get; set; } = new List<Game>();
        public Set(List<bool> scoresheet)
        {
            Scoresheet = scoresheet;
            Status = SetStatus.Playing;
        }
        public string ProcessSet()
        {
            while (Status == SetStatus.Playing)
            {
                var game = new Game(Scoresheet);
                var result = game.ProcessGame();
                if (result == "PlayerA")
                {
                    PlayerAGames++;
                }
                else if (result == "PlayerB")
                {
                    PlayerBGames++;
                }
                else
                {
                    Status = SetStatus.Unclear;
                    Console.WriteLine("--> Could not determine game winner.");
                }

                if (PlayerAGames == 6 && (PlayerAGames - PlayerBGames) > 1)
                {
                    Status = SetStatus.PlayerAWins;
                    return "PlayerA";
                }
                else if (PlayerBGames == 6 && (PlayerBGames - PlayerAGames) > 1)
                {
                    Status = SetStatus.PlayerBWins;
                    return "PlayerB";
                }
                else if (PlayerAGames == 6 && PlayerBGames == 6)
                {
                    Status = SetStatus.PlayingTieBreak;
                    //TODO: create tiebreak game
                    return "TODO: tiebreak";
                }
            }
            return "Undetermined";
        }
    }
}
