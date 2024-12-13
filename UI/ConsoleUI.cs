using coursework.GameAccounts;
using coursework.Service;
using coursework.Service.Interface;
using coursework.UI.Commands;
using coursework.UI.Commands.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace coursework.UI;

public class ConsoleUI
{
    private GameAccount? _user;
    private readonly List<IUserInterface> _unloginedCommands;
    private readonly List<IUserInterface> _loginedCommands;
    private readonly IGameAccountService _accountService;
    private readonly IGameService _gameService;

    public ConsoleUI(GameAccountService accountService, GameService gameService)
    {
        _accountService = accountService;
        _gameService = gameService;
        _unloginedCommands = new List<IUserInterface>
        {
            new LoginToAccount(_accountService),
            new CreateGameAccount(_accountService)
        };
        _loginedCommands = new List<IUserInterface>
        {
            new CreateGame(_accountService, _gameService),
            new ReadAllGameAccouts(_accountService),
            new PrintStats(_accountService),
            new LogoutFromAccount(_accountService),
            new UpdateGameAccount(_accountService),
            new DeleteAccount(_accountService)
        };
    }

    public bool Action()
    {
        var count = ((_user != null) ? _loginedCommands : _unloginedCommands).Count;
        for (int i = 0; i < count; i++)
        {
            Console.Write($"{i + 1}. {((_user != null) ? _loginedCommands : _unloginedCommands)[i].ShowInfo()}\n");
            if (i == count - 1)
            {
                Console.WriteLine($"{i + 2}. Exit");
            }
        }
        int.TryParse(Console.ReadLine() + "", out int response);
        if (response > 0 && response <= count)
        {
            var result = ((_user != null) ? _loginedCommands : _unloginedCommands)[response - 1].Action(_user);
            if (result == CommandResults.Failure) { _user = null; }
            if (result == CommandResults.Success && _user == null) { _user = _accountService.GetLoginedAccount(); }
            return true;
        }
        else if (response == count + 1)
        {
            Console.Write("Goodbye!");
            return false;
        }
        else
        {
            Console.WriteLine("Invalid input.");
            return true;
        }
    }
}
