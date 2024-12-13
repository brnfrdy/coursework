using coursework.GameAccounts;
using coursework.Games;

namespace coursework;

public static class Factory
{
    public static Game CreateGame(string gameType,GameAccount player1, GameAccount player2, int rating, bool isWin)
    {
        switch (gameType)
        {
            case "StandartGame":
                return new StandartGame(player1, player2, rating, isWin);

            case "TrainingGame":
                return new TrainingGame(player1, player2, isWin);

            case "OnePlayerGame":
                return new OnePlayerGame(player1, rating, isWin);

            default:
                throw new ArgumentException("Неправильний тип гри.");
        }
    }

    public static GameAccount CreateGameAccount(string accountType ,string username, string password, string passwordSalt, int startingRating = 100)
    {
        switch (accountType)
        {
            case "StandartAccount":
                return new StandartAccount(username,password, passwordSalt, startingRating);

            case "StreakAccount":
                return new BonusStreakAccount(username, password, passwordSalt, startingRating);

            case "HalfLossAccount":
                return new HalfLossAccount(username, password, passwordSalt, startingRating);

            default:
                throw new ArgumentException("Неправильний тип аккаунту.");
        }
    }
}
