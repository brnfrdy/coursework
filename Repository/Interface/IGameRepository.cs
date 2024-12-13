using coursework.Games;

namespace coursework.Repository;

public interface IGameRepository
{
    void CreateGame(Game game);
    Game ReadGame(int id);
    List<Game> ReadAllGames();
    void DeleteGame(Game game);

}