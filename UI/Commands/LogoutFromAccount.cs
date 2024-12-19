using coursework.GameAccounts;
using coursework.Service;
using coursework.Service.Interface;
using coursework.UI.Commands.Interface;

namespace coursework.UI.Commands
{
    public class LogoutFromAccount : IUserInterface
    {
        private IGameAccountService _accountService;

        public LogoutFromAccount(IGameAccountService accountService)
        {
            _accountService = accountService;
        }

        public CommandResults Action(GameAccount? user)
        {
            try
            {
                var result = _accountService.LogoutFromAccount();
                return CommandResults.Failure;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return CommandResults.Error;
            }
        }
        public string ShowInfo()
        {
            return "Logout.";
        }
    }
}