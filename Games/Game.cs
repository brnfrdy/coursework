using coursework.GameAccounts;

namespace coursework.Games;

public abstract class Game
{
    private static int _id = 0;
    public int Id { get; }
    public GameAccount Player1 { get; }
    public GameAccount Player2 { get; }
    public bool IsPlayer1Win { get; }
    public int Rating { get; }

    public Game(GameAccount player1, GameAccount player2, int rating, bool isPlayer1Win)
    {
        Id = ++_id;
        Player1 = player1;
        Player2 = player2;
        Rating = rating;
        IsPlayer1Win = isPlayer1Win;
    }

    public int CalculateRating()
    {
        return Rating;
    }
}
