using coursework.GameAccounts;
using coursework.Service.Interface;
using coursework.UI.Commands.Interface;

namespace coursework.UI.Commands;

public class LoginToAccount : IUserInterface
{
    private readonly IGameAccountService _accountService;
    public LoginToAccount(IGameAccountService accountService)
    {
        _accountService = accountService;
    }
    public CommandResults Action(GameAccount? user)
    {
        Console.WriteLine("Enter username: ");
        var username = "" + Console.ReadLine();
        Console.WriteLine("Enter password: ");
        var password = "" + Console.ReadLine();
        try{
            var result = _accountService.LoginToAccount(username, password);
            return result ? CommandResults.Success : CommandResults.Failure;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return CommandResults.Error;
        }
    }
    public string ShowInfo()
    {
        return "Login to account.";
    }
}
