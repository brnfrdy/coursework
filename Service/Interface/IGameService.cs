using coursework.GameAccounts;
using coursework.Games;

namespace coursework.Service;

public interface IGameService
{
    void PlayGame(string gameType, GameAccount player1, GameAccount player2);
    void DeleteGame(int id);
    Game ReadGame(int id);
    List<Game> ReadAllGames();
}
