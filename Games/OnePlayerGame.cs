using coursework.GameAccounts;

namespace coursework.Games;

public class OnePlayerGame : Game
{
    public OnePlayerGame(GameAccount player1, int rating, bool isWin) : base(player1, null, rating, isWin)
    { }
}
