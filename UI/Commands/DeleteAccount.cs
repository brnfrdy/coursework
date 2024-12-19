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
    public class DeleteAccount : IUserInterface
    {
        private readonly IGameAccountService _accountService;
        public DeleteAccount(IGameAccountService accountService)
        {
            _accountService = accountService;
        }
        public CommandResults Action(GameAccount? user)
        {
            Console.WriteLine("Are you sure you want to delete your account?\nThis cant be undone. (yes/no)");
            var response = Console.ReadLine();
            if (response == "yes")
            {
                try
                {
                    _accountService.DeleteGameAccount(user);
                    return CommandResults.Success;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return CommandResults.Failure;
                }
            }
            else
            {
                return CommandResults.Success;
            }
        }

        public string ShowInfo()
        {
            return "Delete account.";
        }
    }
}
