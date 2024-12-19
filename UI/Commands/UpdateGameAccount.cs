using coursework.GameAccounts;
using coursework.Service.Interface;
using coursework.UI.Commands.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coursework.UI.Commands
{
    public class UpdateGameAccount : IUserInterface
    {
        private readonly IGameAccountService _accountService;
        public UpdateGameAccount(IGameAccountService accountService)
        {
            _accountService = accountService;
        }
        public CommandResults Action(GameAccount? user)
        {
            Console.WriteLine("Write new username: (write \'exit\' to cancel)");
            var response = Console.ReadLine();
            if (response == "cancel")
            {
                return CommandResults.Exit;
            }
            else
            {
                try{
                    _accountService.UpdateGameAccount(user, response);
                    return CommandResults.Success;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return CommandResults.Failure;
                }
            }
        }

        public string ShowInfo()
        {
            return "Change username.";
        }
    }
}
