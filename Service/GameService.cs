using coursework.GameAccounts;
using coursework.Games;
using coursework.Repository;

namespace coursework.Service;

public class GameService : IGameService
{
    private readonly IGameRepository _gameRepository;

    public GameService(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public void PlayGame(string gameType, GameAccount player1, GameAccount player2)
    {
        Random random = new Random();
        int rating = random.Next(1, 41);

        bool isWin = GameLogic.StartGame(player1.Username, player2.Username);

        var game = Factory.CreateGame(gameType, player1, player2, rating, isWin);

        if (isWin)
        {
            player1.WinGame(game);
            player2.LoseGame(game);
        }
        else
        {
            player2.WinGame(game);
            player1.LoseGame(game);
        }
        _gameRepository.CreateGame(game);
    }

    public Game ReadGame(int id)
    {
        return _gameRepository.ReadGame(id);
    }

    public List<Game> ReadAllGames()
    {
        return _gameRepository.ReadAllGames();
    }

    public void DeleteGame(int id)
    {
        var game = _gameRepository.ReadGame(id);

        if (game != null)
        {
            _gameRepository.DeleteGame(game); 
        }
        else
        {
            Console.WriteLine("Game not found.");
        }
    }
}
