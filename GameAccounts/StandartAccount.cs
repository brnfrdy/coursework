using coursework.Games;

namespace coursework.GameAccounts;

public class StandartAccount : GameAccount
{
    public StandartAccount(string username, string password, string passwordSalt, int startingRating = 1) : base(username, password, passwordSalt,startingRating)
    { }

    public override void LoseGame(Game game)
    {
        CurrentRating -= game.CalculateRating();
    }
}
