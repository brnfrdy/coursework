using coursework.GameAccounts;
using coursework.Games;

namespace coursework.Repository;

public interface IGameAccountRepository
{
    void CreateGameAccount(GameAccount account);
    GameAccount GetGameAccountByID(int id);
    GameAccount GetGameAccountByUsername(string username);
    List<GameAccount> ReadAllGameAccounts();
    void UpdateGameAccount(GameAccount account);
    void DeleteGameAccount(GameAccount account);
    List<Game> PrintStats(GameAccount user);
}
