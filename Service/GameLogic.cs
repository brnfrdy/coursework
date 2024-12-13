

using coursework.UI;

namespace coursework.Service;

public class GameLogic
{
    public static bool StartGame(string p1, string p2) 
    {
        List<List<char>> board = new List<List<char>>()
        {
            new List<char> { ' ', ' ', ' ' },
            new List<char> { ' ', ' ', ' ' },
            new List<char> { ' ', ' ', ' ' }
        };
        bool gameover = false;
        int turn = 0;
        do 
        {
            turn++;
            Console.Clear();
            GameUI.printgame(board, turn, p1, p2);
            MakeMove(ref board, ref turn);
            gameover = CheckBoard(board);
        } 
        while (!gameover);
        Console.Clear();
        GameUI.printgame(board, turn, p1, p2);
        return (turn % 2 == 1) ? true : false;
    }
    public static void MakeMove(ref List<List<char>> board, ref int turn)
    {
        while (true)
        {
            char player = ' ';
            if (turn % 2 == 1)
            {
                player = 'X';
            }
            else
            {
                player = 'O';
            }
            var move = GameUI.GetMove() - 1;
            if (move == 9) 
            {
                if (player == 'X')
                {
                    player = 'O';
                }
                else
                {
                    player = 'X';
                }
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        board[i][j] = player;
                    }
                }
                turn++;
                break;
            }
            int x = move / 3;
            int y = move % 3;
            if (board[x][y] == ' ')
            {
                board[x][y] = player;
                break;
            }
            else
            {
                Console.WriteLine("Invalid move. Try again.");
            }
        }
    }

    public static bool CheckBoard(List<List<char>> board)
    {
        for (int i = 0; i < 3; i++)
        {
            if (board[i][0] != ' ' && board[i][0] == board[i][1] && board[i][1] == board[i][2])
            {
                return true;
            }
            if (board[0][i] != ' ' && board[0][i] == board[1][i] && board[1][i] == board[2][i])
            {
                return true;
            }
        }
        if (board[0][0] != ' ' && board[0][0] == board[1][1] && board[1][1] == board[2][2])
        {
            return true;
        }
        if (board[0][2] != ' ' && board[0][2] == board[1][1] && board[1][1] == board[2][0])
        {
            return true;
        }
        return false;
    }
}
