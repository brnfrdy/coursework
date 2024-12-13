using coursework.GameAccounts;

namespace coursework.Games;

public class TrainingGame : Game
{
    public TrainingGame(GameAccount player1, GameAccount player2, bool isWin) : base(player1, player2, 0, isWin)
    { }
}
