using coursework.GameAccounts;
using coursework.Service;
using coursework.Service.Interface;
using coursework.UI.Commands.Interface;

namespace coursework.UI.Commands;

public class CreateGame : IUserInterface
{
    private readonly IGameAccountService _accountService;
    private readonly IGameService _gameService;
    public CreateGame(IGameAccountService accountService, IGameService gameService)
    {
        _accountService = accountService;
        _gameService = gameService;
    }
    public CommandResults Action(GameAccount? user)
    {
        string opponentName = "";
        while (true)
        {
            Console.WriteLine("Choose game type: \n1. Standart game\n2. Training game\n3. Single player game");
            var response2 = Console.ReadLine();
            if (response2 == "exit")
            {
                return CommandResults.Exit;
            }
            while (response2 == "3" ? false : true)
            {
                Console.WriteLine("Enter opponent username: ");
                opponentName = "" + Console.ReadLine();
                if (opponentName == "exit")
                {
                    return CommandResults.Exit;
                }
                if (_accountService.GetGameAccountByUsername(opponentName) == null)
                {
                    Console.WriteLine("Player not found.");
                    continue;
                }
                break;
            }
            switch (response2)
            {
                case "1":
                    _gameService.PlayGame("StandartGame", user, _accountService.GetGameAccountByUsername(opponentName));
                    break;
                case "2":
                    _gameService.PlayGame("TrainingGame", user, _accountService.GetGameAccountByUsername(opponentName));
                    break;
                case "3":
                    _gameService.PlayGame("OnePlayerGame", user, user);
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
        return "Play game.";
    }
}
