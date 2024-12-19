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
        if (user == null)
        {
            Console.WriteLine("You are not logged in.");
            return CommandResults.NotLogined;
        }
        try{
            var games = _accountService.PrintStats(user);
            Console.WriteLine($"Game history of {user.Username}:");
            Console.WriteLine("__________________________________________________");
            Console.WriteLine("|Game Id|Opponent    |Result|R.B. |Game type     |");
            Console.WriteLine("__________________________________________________");
            for (int i = 0; i < games.Count(); i++)
            {
                var opponentUsername = games[i].Player1 == user ? games[i].Player2?.Username ?? "-" : games[i].Player1?.Username ?? "-";
                var result = games[i].Player1 == user ? (games[i].IsPlayer1Win ? "Win   " : "Lose ") : (games[i].IsPlayer1Win ? "Lose   " : "Win  ");
                Console.WriteLine($"|{games[i].Id,-7}|{opponentUsername,-12}|{result,-6}|{games[i].Rating,-5}|{games[i].GetType().Name,-14}|");
            }
            Console.WriteLine("__________________________________________________");
            Console.WriteLine($"Total games: {games.Count()}, Rating: {user.CurrentRating}\n");
            return CommandResults.Success;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return CommandResults.Error;
        }
        
    }
    public string ShowInfo()
    {
        return "Print user statistics.";
    }
}
