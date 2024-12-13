using coursework.GameAccounts;
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
            Console.WriteLine("Account does not exist.");
            return false;
        }
        if (SecurityHelper.VerifyPassword(password, account.Password, account.PasswordSalt))
        {
            Console.WriteLine("Succesfull login.");
            _loginAccount = account;
            return true;
        }
        else
        {
            Console.WriteLine("Wrong password.");
            return false;
        }
    }

    public GameAccount? GetLoginedAccount()
    {
        var res = _loginAccount;
        _loginAccount = null;
        return res;
    }

    public bool LogoutFromAccount()
    {
        Console.WriteLine("Logout succesfully.");
        return true;
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
            Console.WriteLine("There is no account to update.");
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
            Console.WriteLine("There is no account to delete.");
        }
    }

    public void PrintStats(GameAccount user)
    {
        _accountRepository.PrintStats(user);
    }
}
