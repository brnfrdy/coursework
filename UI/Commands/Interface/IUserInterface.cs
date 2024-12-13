using coursework.GameAccounts;

namespace coursework.UI.Commands.Interface;

public interface IUserInterface
{
    CommandResults Action(GameAccount? user);
    string ShowInfo();
}
