using coursework.Games;

namespace coursework.GameAccounts;

public abstract class GameAccount
{
    private static int _id = 0;
    public int Id { get; }
    public string Username { get; set; }
    private int _rating;
    public int CurrentRating
    {
        get { return _rating; }
        set
        {
            if (value > 1) { _rating = value; }
            else { _rating = 1; }
        }
    }
    public string Password { get; set; }
    public string PasswordSalt { get; set; }

    public GameAccount(string username, string password, string passwordSalt, int startingRating = 1)
    {
        Id = ++_id;
        Username = username;
        Password = password;
        PasswordSalt = passwordSalt;
        _rating = startingRating;
    }

    public virtual void WinGame(Game game)
    {
        CurrentRating = CurrentRating + game.CalculateRating();
    }
    public virtual void LoseGame(Game game)
    {
        CurrentRating = CurrentRating - game.CalculateRating();
    }
}
