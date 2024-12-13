using coursework.GameAccounts;
using coursework.Service.Interface;
using coursework.UI.Commands.Interface;

namespace coursework.UI.Commands;

public class CreateGameAccount : IUserInterface
{
    private readonly IGameAccountService _accountService;
    public CreateGameAccount(IGameAccountService accountService)
    {
        _accountService = accountService;
    }
    public CommandResults Action(GameAccount? user)
    {
        Console.WriteLine("Enter player name: ");
        var username = "" + Console.ReadLine();
        if (_accountService.GetGameAccountByUsername(username) != null)
        {
            Console.WriteLine("Username already used.");
            return CommandResults.Failure;
        }
        Console.WriteLine("Enter password: ");
        var password = "" + Console.ReadLine();
        Console.WriteLine("Choose account type.");
        while (true)
        {
            Console.WriteLine("1. Standart\n2. Bonus streak\n3. Half rating lose");
            var response = Console.ReadLine();
            switch (response)
            {
                case "1":
                    _accountService.CreateGameAccount("StandartAccount", username, password);
                    break;
                case "2":
                    _accountService.CreateGameAccount("StreakAccount", username, password);
                    break;
                case "3":
                    _accountService.CreateGameAccount("HalfLossAccount", username, password);
                    break;
                default:
                    Console.WriteLine("Invalid input.");
                    continue;
            }
            return CommandResults.Success;
        }
    }
    public string ShowInfo()
    {
        return "Create account.";
    }
}
