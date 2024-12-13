using coursework.GameAccounts;
using coursework.Service.Interface;
using coursework.UI.Commands.Interface;

namespace coursework.UI.Commands;

public class PrintStats : IUserInterface
{
    private readonly IGameAccountService _accountService;
    public PrintStats(IGameAccountService accountService)
    {
        _accountService = accountService;
    }
    public CommandResults Action(GameAccount? user)
    {
        _accountService.PrintStats(user);
        return CommandResults.Success;
    }
    public string ShowInfo()
    {
        return "Print user statistics.";
    }
}
