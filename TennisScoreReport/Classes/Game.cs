namespace Tennis.Classes
{
    public class Game
    {
        private int pointsA;
        private int pointsB;
        public int PointsA
        {
            get { return pointsA; }
            set
            {
                pointsA = value;
                checkDeuceStatus();
            }
        }
        public int PointsB
        {
            get { return pointsB; }
            set
            {
                pointsB = value;
                checkDeuceStatus();
            }
        }
        public GameStatus Status { get; set; }
        public List<bool> Scoresheet { get; set; }
        public Game(List<bool> scoresheet)
        {
            Scoresheet = scoresheet;
            Status = GameStatus.Playing;
        }
        public string ProcessGame()
        {
            while (Status == GameStatus.Playing || Status == GameStatus.Deuce)
            {
                if (Scoresheet.Count == 0)
                {
                    Console.WriteLine("--> Something seems wrong with the scoresheet.");
                }
                var point = Scoresheet[0];
                Scoresheet.RemoveAt(0);

                if (point) PointsA++;
                else PointsB++;

                var diff = PointsA - PointsB;
                if ((PointsA > 3 || PointsB > 3) && (diff > 1 || diff < -1))
                {
                    if (diff > 1)
                    {
                        Status = GameStatus.PlayerAWins;
                        return "PlayerA";
                    }
                    else
                    {
                        Status = GameStatus.PlayerBWins;
                        return "PlayerB";
                    }
                }
            }
            return "Unclear";
        }
        private void checkDeuceStatus()
        {
            if (pointsA > 2 && pointsB > 2) Status = GameStatus.Deuce;
        }
    }
}