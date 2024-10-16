using System;
using System.Collections.Generic;
using System.Text;
using TicTacToeRendererLib.Enums;
using TicTacToeRendererLib.Renderer;

namespace TicTacToeSubmissionConole
{
    public class TicTacToe
    {
        private TicTacToeConsoleRenderer _boardRenderer;
        private PlayerEnum?[,] board;
        private PlayerEnum currentPlayer;

        public TicTacToe()
        {
            _boardRenderer = new TicTacToeConsoleRenderer(10,6);
            currentPlayer = PlayerEnum.X;
            board = new PlayerEnum?[3, 3];
            _boardRenderer.Render();
        }


        public void Run()
        {
            bool gameOver = false;

            while (!gameOver)
            {

                // FOR ILLUSTRATION CHANGE TO YOUR OWN LOGIC TO DO TIC TAC TOE

                Console.SetCursorPosition(2, 19);

                Console.Write("Player " + currentPlayer);

                Console.SetCursorPosition(2, 20);

                Console.Write("Please Enter Row: ");
                int row = GetValidInput(0, 2);

                Console.SetCursorPosition(2, 22);


                Console.Write("Please Enter Column: ");
                int column = GetValidInput(0, 2);


                // THIS JUST DRAWS THE BOARD (NO TIC TAC TOE LOGIC)
                if (board[row, column] == null)
                {
                    board[row, column] = currentPlayer;
                    _boardRenderer.AddMove(row, column, currentPlayer, true);

                    if (CheckWin(row, column))
                    {
                        Console.SetCursorPosition(2, 24);
                        Console.WriteLine("Player " + currentPlayer + " wins!");
                        gameOver = true;
                    }
                    else if (IsBoardFull())
                    {
                        Console.SetCursorPosition(2, 24);
                        Console.WriteLine("It's a draw!");
                        gameOver = true;
                    }
                    else
                    {
                        currentPlayer = SwitchPlayer(currentPlayer);
                    }
                }
                else
                {
                    Console.SetCursorPosition(2, 24);
                    Console.WriteLine("That cell is already occupied. Try again.");
                }

            }
        }
        private int GetValidInput(int min, int max)
        {
            int input;
            bool valid = false;
            do
            {
                if (int.TryParse(Console.ReadLine(), out input) && input >= min && input <= max)
                {
                    valid = true;
                }
                else
                {
                    Console.SetCursorPosition(2, 24);
                    Console.Write("Invalid input. Please enter a number between " + min + " and " + max + ": ");
                }
            } while (!valid);
            return input;
        }
        private bool CheckWin(int row, int column)
        {
            // Row check
            if (board[row, 0] == currentPlayer && board[row, 1] == currentPlayer && board[row, 2] == currentPlayer)
                return true;

            // Column check
            if (board[0, column] == currentPlayer && board[1, column] == currentPlayer && board[2, column] == currentPlayer)
                return true;

            // Diagonal checks
            if ((board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer) ||
                (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer))
                return true;

            return false;
        }
        private bool IsBoardFull()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == null)
                        return false;
                }
            }
            return true;
        }
        private PlayerEnum SwitchPlayer(PlayerEnum current)
        {
            switch (current)
            {
                case PlayerEnum.X:
                    return PlayerEnum.O;
                case PlayerEnum.O:
                    return PlayerEnum.X;
                default:
                    return PlayerEnum.X;
            }
        }
    }
}
