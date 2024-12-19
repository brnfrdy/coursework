using coursework.GameAccounts;
using coursework.Games;
using coursework.Repository;
using coursework.Service.Interface;
using coursework.Service.Security;
using System.ComponentModel;

namespace coursework.Service;

public class GameAccountService : IGameAccountService
{
    private readonly IGameAccountRepository _accountRepository;
    private GameAccount? _loginAccount;

    public GameAccountService(IGameAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public void CreateGameAccount(string accountType, string username, string password, int startingRating = 100)
    {
        var salt = SecurityHelper.GenerateSalt();
        var pswrd = SecurityHelper.HashPassword(password, salt);
        var account = Factory.CreateGameAccount(accountType, username, pswrd, salt, startingRating);
        _accountRepository.CreateGameAccount(account);
        return;
    }
    public List<GameAccount> ReadAllGameAccounts()
    {
        return _accountRepository.ReadAllGameAccounts();
    }

    public GameAccount GetGameAccountByID(int id)
    {
        return _accountRepository.GetGameAccountByID(id);
    }
    public GameAccount GetGameAccountByUsername(string username)
    {
        return _accountRepository.GetGameAccountByUsername(username);
    }
    public bool LoginToAccount(string username, string password)
    {
        var account = GetGameAccountByUsername(username);
        if (account == null)
        {
            throw new Exception("Account does not exist.");
        }
        if (SecurityHelper.VerifyPassword(password, account.Password, account.PasswordSalt))
        {
            _loginAccount = account;
            return true;
        }
        else
        {
            throw new Exception("Wrong password.");
        }
        return false;
    }

    public GameAccount? GetLoginedAccount()
    {
        var res = _loginAccount;
        _loginAccount = null;
        return res;
    }

    public bool LogoutFromAccount()
    {
        throw new Exception("Logout succesfully.");
    }
    public void UpdateGameAccount(GameAccount account, string newUsername)
    {
        if (account != null)
        {
            account.Username = newUsername;
            _accountRepository.UpdateGameAccount(account);
        }
        else
        {
            throw new Exception("There is no account to update.");
        }
    }
    

    public void DeleteGameAccount(GameAccount account)
    {
        if (account != null)
        {
            _accountRepository.DeleteGameAccount(account);
        }
        else
        {
            throw new Exception("There is no account to delete.");
        }
    }

    public List<Game> PrintStats(GameAccount user)
    {
        var context = _accountRepository.PrintStats(user);
        var tmp = context.FindAll(g => g.Player1 == user || g.Player2 == user);
        if (tmp == null)
        {
            throw new Exception("No games found.");
        }
        return tmp;
    }
}
