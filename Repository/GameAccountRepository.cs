using coursework.GameAccounts;
using coursework.Games;

namespace coursework.Repository;

public class GameAccountRepository : IGameAccountRepository
{
    private readonly DbContext _dbContext;

    public GameAccountRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void CreateGameAccount(GameAccount account)
    {
       _dbContext.Accounts.Add(account);
    }

    public GameAccount GetGameAccountByID(int id)
    {
        return _dbContext.Accounts.FirstOrDefault(a => a.Id == id);
    }

    public GameAccount GetGameAccountByUsername(string username)
    {
        return _dbContext.Accounts.FirstOrDefault(a => a.Username == username);
    }
    public List<GameAccount> ReadAllGameAccounts()
    {
        return _dbContext.Accounts;
    }


    public void UpdateGameAccount(GameAccount account)
    {
        var existingAccount = _dbContext.Accounts.FirstOrDefault(a => a.Id == account.Id);
        if (existingAccount != null)
        {
            existingAccount.Username = account.Username;
        }
    }

    public void DeleteGameAccount(GameAccount account)
    {
            _dbContext.Accounts.Remove(account);
    }

    public List<Game> PrintStats(GameAccount user)
    {
        return _dbContext.Games;
    }
}