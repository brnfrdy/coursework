using coursework.GameAccounts;

namespace coursework.Repository;

public interface IGameAccountRepository
{
    void CreateGameAccount(GameAccount account);
    GameAccount GetGameAccountByID(int id);
    GameAccount GetGameAccountByUsername(string username);
    List<GameAccount> ReadAllGameAccounts();
    void UpdateGameAccount(GameAccount account);
    void DeleteGameAccount(GameAccount account);
    void PrintStats(GameAccount user);
}
