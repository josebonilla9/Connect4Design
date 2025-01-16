using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prueba.Modelo
{
    public class Board
    {
        private readonly int[,] grid; // 0: vacío, 1: rojo, 2: amarillo
        private const int Rows = 6;
        private const int Cols = 7;

        public Board()
        {
            grid = new int[Rows, Cols];
        }

        public bool AddPiece(int col, int player)
        {
            for (int row = Rows - 1; row >= 0; row--)
            {
                if (grid[row, col] == 0)
                {
                    grid[row, col] = player;
                    return true;
                }
            }
            return false; // Columna llena
        }

        public int GetPiece(int row, int col)
        {
            return grid[row, col];
        }

        public void PrintBoard()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Cols; col++)
                {
                    Console.Write(grid[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }

    public class Player
    {
        public void PlayTurn(Board board, int col)
        {
            if (!board.AddPiece(col, 1))
            {
                Console.WriteLine("Columna llena. Intenta otra vez.");
            }
        }
    }

    public class AIPlayer
    {
        public void PlayTurn(Board board)
        {
            Random random = new Random();
            int col;
            do
            {
                col = random.Next(0, 7); // Escoge una columna aleatoria
            } while (!board.AddPiece(col, 2));

            Console.WriteLine($"La IA coloca una ficha en la columna {col}.");
        }
    }

    public class Game
    {
        private readonly Board board;
        private readonly Player player;
        private readonly AIPlayer aiPlayer;

        public Game()
        {
            board = new Board();
            player = new Player();
            aiPlayer = new AIPlayer();
        }

        public void Start()
        {
            bool gameOver = false;
            while (!gameOver)
            {
                Console.WriteLine("Turno del jugador (elige columna del 0 al 6):");
                int playerCol = int.Parse(Console.ReadLine());
                player.PlayTurn(board, playerCol);

                board.PrintBoard();
                if (CheckVictory(1))
                {
                    Console.WriteLine("¡Ganaste!");
                    break;
                }

                aiPlayer.PlayTurn(board);
                board.PrintBoard();
                if (CheckVictory(2))
                {
                    Console.WriteLine("¡Perdiste!");
                    break;
                }
            }
        }

        private bool CheckVictory(int player)
        {
            // Aquí llamas a los métodos para revisar "4 en raya"
            return false; // Placeholder
        }

        private bool CheckHorizontal(int player)
        {
            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col <= 3; col++) // Solo hasta la 4ª columna
                {
                    if (board.GetPiece(row, col) == player &&
                        board.GetPiece(row, col + 1) == player &&
                        board.GetPiece(row, col + 2) == player &&
                        board.GetPiece(row, col + 3) == player)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }



}
