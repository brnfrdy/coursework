using coursework.GameAccounts;
using coursework.Games;

namespace coursework.Service.Interface;

public interface IGameAccountService
{
    void CreateGameAccount(string accountType, string username, string password, int startingRating = 100);
    bool LoginToAccount(string username, string password);
    bool LogoutFromAccount();
    List<GameAccount> ReadAllGameAccounts();
    GameAccount GetGameAccountByID(int id);
    GameAccount GetGameAccountByUsername(string username);
    GameAccount? GetLoginedAccount();
    void UpdateGameAccount(GameAccount account, string newUsername);
    void DeleteGameAccount(GameAccount account);
    List<Game> PrintStats(GameAccount user);
}
