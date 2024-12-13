using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coursework.UI
{
    public static class GameUI
    {
        public static void printgame(List<List<char>> board, int turn, string p1, string p2)
        {
            /// Tic-Tac-Toe game board
            Console.Write($"Turn {turn}. ");
            if (turn % 2 == 1)
            {
                Console.WriteLine($"{p1}'s turn:");
            }
            else
            {
                Console.WriteLine($"{p2}'s turn\n");
            }
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {board[2][0]}  |  {board[2][1]}  |  {board[2][2]}");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {board[1][0]}  |  {board[1][1]}  |  {board[1][2]}");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {board[0][0]}  |  {board[0][1]}  |  {board[0][2]}");
            Console.WriteLine("     |     |      ");
        }

        public static int GetMove() 
        {
            while (true)
            {
                Console.WriteLine("Enter your move (1-9): (Enter 0 to see numbers layout)");
                var response = Console.ReadLine() + "";
                if (response.ToLower() == "exit" || response.ToLower() == "resign") 
                {
                    return 10;
                }
                int.TryParse(response, out int move);
                if (move < 0 || move > 9)
                {
                    Console.WriteLine("Invalid move. Try again.");
                }
                else if (move == 0)
                {
                    Console.WriteLine("Numbers layout:");
                    Console.WriteLine("7 | 8 | 9");
                    Console.WriteLine("--+---+--");
                    Console.WriteLine("4 | 5 | 6");
                    Console.WriteLine("--+---+--");
                    Console.WriteLine("1 | 2 | 3");
                }
                else
                {
                    return move;
                }
            }
        }
    }
}
