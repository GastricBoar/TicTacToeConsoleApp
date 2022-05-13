using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeConsoleApp2
{
    internal class TicTacToe
    {
        #region members
        int movesNum;
        int row;
        int col;
        bool gameEnd;
        #endregion

        #region strings
        string playerOne, playerTwo;
        string sign;
        string playerName;
        static string requestInput = " > ";
        #endregion

        #region public methods

        public void PlayGame(string[,] board)
        {
            gameEnd = false;
            sign = "X";
            playerName = playerOne;
            movesNum = 0;

            StartScreen();
            ChoosePlayerNames();

            InitializeBoard(board);

            while (gameEnd == false)
            {
                DisplayPlayerName(playerName);

                ChoosePosition(board);

                PrintSign(board);

                gameEnd = CheckForGameEnd(board, sign);

                SwitchTurn();
            }

        }
        #endregion

        #region private methods
        private static void StartScreen()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Welcome to TicTacToeConsoleApp! Press any key to start!\n\n\n\n\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(Figgle.FiggleFonts.Standard.Render("TicTacToe!"));

            Console.ResetColor();

            Console.ReadKey();
            Console.Clear();
        }
        private void ChoosePlayerNames()
        {
            Console.Write("Please insert player names:\n");

            Output("\nPLAYER 1 > ", ConsoleColor.Magenta);
            playerOne = Console.ReadLine().Trim();

            while (CheckName(playerOne) == false)
            {
                Output("Invalid player name!\n", ConsoleColor.Red);

                Output("\nPLAYER 1 > ", ConsoleColor.Magenta);
                playerOne = Console.ReadLine().Trim();
            }

            Output("\nPLAYER 2 > ", ConsoleColor.Green);
            playerTwo = Console.ReadLine().Trim();

            while (CheckName(playerTwo) == false | playerTwo == playerOne)
            {
                Output("Invalid player name!\n", ConsoleColor.Red);

                Output("\nPLAYER 2 > ", ConsoleColor.Green);
                playerTwo = Console.ReadLine().Trim();
            }
            playerName = playerOne;
        }
        private void InitializeBoard(string[,] board)
        {
            Console.Clear();

            Console.WriteLine("    1    2    3");
            for (row = 0; row < 3; row++)
            {
                Console.Write((row + 1) + " |");
                for (col = 0; col < 3; col++)
                {
                    board[row, col] = " ";
                    Console.Write(" " + board[row, col] + "  |");
                }
                Console.WriteLine();
            }
        }
        private void DisplayPlayerName(string playerName)
        {
            if (playerName == playerOne)
            {
                Output(playerName + "'s turn", ConsoleColor.Magenta);
            }
            else
            {
                Output(playerName + "'s turn", ConsoleColor.Green);
            }
        }

        private bool CheckName(string player)
        {
            while (player.Length > 30 | player.Length < 3)
            {
                return false;
            }
            return true;
        }
        private void ChoosePosition(string[,] board)
        {
        REPLAY:

            try
            {
                Console.Write("\n\nChoose your row: ");
                row = Convert.ToInt32(Console.ReadLine());

                Console.Write("Choose your column: ");
                col = Convert.ToInt32(Console.ReadLine());

                row = row - 1;
                col = col - 1;

                if (board[row, col] == "X" | board[row, col] == "O")
                {
                    Output("Please select a valid position!", ConsoleColor.Red);
                    goto REPLAY;
                }
            }
            catch (Exception)
            {
                Output("Please select a valid position!", ConsoleColor.Red);
                goto REPLAY;
            }
            Console.Clear();
        }
        private void PrintSign(string[,] board)
        {
            board[row, col] = sign;

            Console.WriteLine("    1    2    3");
            for (row = 0; row < 3; row++)
            {
                Console.Write((row + 1) + " |");
                for (col = 0; col < 3; col++)
                {
                    Console.Write(" " + board[row, col] + "  |");
                }
                Console.WriteLine();
            }
            movesNum++;
        }
        private void SwitchTurn()
        {
            sign = sign == "X" ? "O" : "X";
            playerName = playerName == playerOne ? playerTwo : playerOne;
        }
        private bool CheckForGameEnd(string[,] board, string sign)
        {
            if (movesNum < 5)
                return false;

            string winningStreak = sign + sign + sign;

            for (int i = 0; i < 3; i++)
            {   //horizontal checks                                            //vertical checks
                if (board[i, 0] + board[i, 1] + board[i, 2] == winningStreak | board[0, i] + board[1, i] + board[2, i] == winningStreak)
                {
                    Output(playerName + " wins", ConsoleColor.Blue);
                    return true;
                }
            }

            //diagonal checks
            if (board[0, 0] + board[1, 1] + board[2, 2] == winningStreak | board[2, 0] + board[1, 1] + board[0, 2] == winningStreak)
            {
                Output(playerName + " wins", ConsoleColor.Blue);
                return true;
            }

            if (movesNum == 9)
            {
                Output("\nIt's a draw!", ConsoleColor.Yellow);
                return true;
            }
            return false;
        }
        private void Output(string text, System.ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }

        #endregion
    }
}
