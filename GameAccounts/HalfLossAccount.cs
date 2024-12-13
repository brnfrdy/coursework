using coursework.Games;

namespace coursework.GameAccounts;

public class HalfLossAccount : GameAccount
{
    public HalfLossAccount(string username, string password, string passwordSalt, int startingRating = 1) : base(username, password, passwordSalt, startingRating)
    { }

    public override void LoseGame(Game game)
    {
        CurrentRating -= game.CalculateRating() / 2;
    }
}
