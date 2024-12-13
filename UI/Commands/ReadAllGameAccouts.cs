using coursework.GameAccounts;
using coursework.Service.Interface;
using coursework.UI.Commands.Interface;

namespace coursework.UI.Commands;

public class ReadAllGameAccouts : IUserInterface
{
    private readonly IGameAccountService _accountService;
    public ReadAllGameAccouts(IGameAccountService accountService)
    {
        _accountService = accountService;
    }
    public CommandResults Action(GameAccount? user)
    {
        _accountService.ReadAllGameAccounts().ForEach(a => Console.Write($"{a.Username,-18} |{a.CurrentRating,-5} \n"));
        return CommandResults.Success;
    }
    public string ShowInfo()
    {
        return "Print all users and their rating.";
    }
}
