using coursework.Games;

namespace coursework.GameAccounts;

public class BonusStreakAccount : GameAccount
{
    private int _countGames = 0;
    public BonusStreakAccount(string username, string password, string passwordSalt, int startingRating = 1) : base(username, password, passwordSalt, startingRating)
    { }
    private int CountWins()
    {
        if (_countGames == 3)
        { 
            _countGames = 0;
            return 2;
        }
        else
        {
            _countGames++;
            return 0;
        }
    }
    public override void WinGame(Game game)
    {
        CurrentRating += game.CalculateRating() + CountWins(); 
    }
}
