using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToeConsoleApp2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[,] board = new string[3, 3];
            string choice = String.Empty;
            bool gameOver = false;

            TicTacToe ticTacToe = new TicTacToe();

            while(gameOver == false)
            {
                ticTacToe.PlayGame(board);

                Console.WriteLine("\nWant to play another match? (Y/N)");
                choice = Console.ReadLine();

                while (choice.ToUpper() != "Y" && choice.ToUpper() != "N")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\nPlease, select a correct input!");
                    Console.ResetColor();

                    Console.WriteLine("\nWant to play another match? (Y/N)");
                    choice = Console.ReadLine();
                }

                switch (choice.ToUpper())
                {
                    case "Y":
                        gameOver = false;
                        break;

                    case "N":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nGoodbye, see you soon!");
                        Console.ResetColor();
                        Console.WriteLine("Shutting down...");
                        Environment.Exit(0);
                        break;
                }
            }




        }
    }
}
