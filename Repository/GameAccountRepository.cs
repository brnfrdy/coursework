using coursework.GameAccounts;

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

    public void PrintStats(GameAccount user)
    {
        var context = _dbContext.Games;
        var tmp = context.FindAll(g => g.Player1 == user || g.Player2 == user);
        if (tmp == null)
        {
            return;
        }
        Console.WriteLine($"Game history of {user.Username}:");
        Console.WriteLine("__________________________________________________");
        Console.WriteLine("|Game Id|Opponent    |Result|R.B. |Game type     |");
        Console.WriteLine("__________________________________________________");
        for (int i = 0; i < tmp.Count(); i++)
        {
            var opponentUsername = tmp[i].Player1 == user ? tmp[i].Player2?.Username ?? "-" : tmp[i].Player1?.Username ?? "-";
            var result = tmp[i].Player1 == user ? (tmp[i].IsPlayer1Win ? "Win   " : "Lose ") : (tmp[i].IsPlayer1Win ? "Lose   " : "Win  ");
            Console.WriteLine($"|{tmp[i].Id,-7}|{opponentUsername,-12}|{result,-6}|{tmp[i].Rating,-5}|{tmp[i].GetType().Name,-14}|");
        }
        Console.WriteLine("__________________________________________________");
        Console.WriteLine($"Total games: {tmp.Count()}, Rating: {user.CurrentRating}\n");
    }
}