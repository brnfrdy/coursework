using coursework.GameAccounts;

namespace coursework.Games;

public class StandartGame : Game
{
    public StandartGame(GameAccount player1, GameAccount player2, int rating, bool isWin) : base(player1, player2, rating, isWin)
    { }
}
