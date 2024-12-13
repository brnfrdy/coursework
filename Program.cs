using coursework.Repository;
using coursework.Service;
using coursework.UI;
using coursework.UI.Commands;
using coursework.UI.Commands.Interface;

namespace coursework;

class Program
{
    public static string? username { get; set; }
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;
        
        var dbContext = new DbContext(); 
        var gameAccountRepo = new GameAccountRepository(dbContext);
        var gameRepo = new GameRepository(dbContext);

        var gameAccountService = new GameAccountService(gameAccountRepo);
        var gameService = new GameService(gameRepo);

        var userInterface = new ConsoleUI(gameAccountService, gameService);

        while (userInterface.Action());
    }
}