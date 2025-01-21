using System.Text.Json.Nodes;
using Connect4Design;
using prueba;

class Program
{
    public async Task gameInit(pruebaForm ventanaEmergente)
    {
        Game game = new Game();
        Player humanPlayer = new Player();
        AIPlayer aiPlayer = new AIPlayer();
        bool isHumanTurn = true;
        int currentPlayer = 1;
        bool gameOver = false;

        string apiKey = ""; //Aquí va la API Key
        AIProgram aiProgram = new AIProgram(apiKey);

        game.Board.PrintBoard();

        while (!gameOver)
        {
            ventanaEmergente.ChatBox.AppendText(isHumanTurn ? "Turno del jugador humano (1):\n" : "Turno de la IA (2):\n");

            if (isHumanTurn)
            {
                ventanaEmergente.SendButton.Click += (sender, e) =>
                {
                    int col;
                    if (int.TryParse(ventanaEmergente.SendBox.Text, out col) && col >= 0 && col <= 6)
                    {
                        if (!game.Board.AddPiece(col, currentPlayer))
                        {
                            ventanaEmergente.ChatBox.AppendText("Columna llena. Intenta de nuevo.\n");
                        }
                        else
                        {
                            isHumanTurn = !isHumanTurn;
                            currentPlayer = isHumanTurn ? 1 : 2;
                        }
                    }
                    else
                    {
                        ventanaEmergente.ChatBox.AppendText("Entrada inválida. Ingresa un número entre 0 y 6.\n");
                    }
                    ventanaEmergente.SendBox.Clear();
                };
            }
            else
            {
                string boardState = BoardToString(game.Board);
                string response = await aiProgram.GetAIResponseAsync(boardState);
                ventanaEmergente.ChatBox.AppendText("IA Asistente: " + response + "\n");

                if (int.TryParse(response, out int col) && col >= 0 && col <= 6)
                {
                    if (!game.Board.AddPiece(col, currentPlayer))
                    {
                        continue;
                    }
                }
                else
                {
                    ventanaEmergente.ChatBox.AppendText("La IA devolvió una columna no válida.\n");
                    continue;
                }
            }

            game.Board.PrintBoard();

            if (game.CheckVictory(currentPlayer))
            {
                ventanaEmergente.ChatBox.AppendText(isHumanTurn ? "¡Felicidades! El jugador humano ha ganado.\n" : "La IA ha ganado. ¡Mejor suerte la próxima vez!\n");
                gameOver = true;
                break;
            }

            if (IsBoardFull(game.Board))
            {
                ventanaEmergente.ChatBox.AppendText("El tablero está lleno. ¡Es un empate!\n");
                gameOver = true;
            }
        }

        ventanaEmergente.ChatBox.AppendText("Juego terminado. Gracias por jugar.\n");
    }

    static bool IsBoardFull(Board board)
    {
        for (int col = 0; col < 7; col++)
        {
            if (board.GetPiece(0, col) == 0)
            {
                return false;
            }
        }
        return true;
    }

    private static string BoardToString(Board board)
    {
        var boardStr = "";
        for (int row = 0; row < 6; row++)
        {
            for (int col = 0; col < 7; col++)
            {
                boardStr += board.GetPiece(row, col) + " ";
            }
            boardStr += "\n";
        }
        return boardStr;
    }
}

public class Board
{
    private int[,] grid;
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
        return false;
    }

    public int GetPiece(int row, int col)
    {
        return grid[row, col];
    }

    public void PrintBoard()
    {
        Console.WriteLine("Tablero actual:");
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
    public void PlayTurn(Board board, int col)
    {
        if (!board.AddPiece(col, 2))
        {
            Console.WriteLine("Columna llena. Intenta otra vez.");
        }
    }
}

public class Game
{
    public Board Board { get; }

    public Game()
    {
        Board = new Board();
    }

    public bool CheckVictory(int player)
    {
        return CheckHorizontal(player) || CheckVertical(player) || CheckDiagonal(player);
    }

    private bool CheckHorizontal(int player)
    {
        for (int row = 0; row < 6; row++)
        {
            for (int col = 0; col <= 3; col++)
            {
                if (Board.GetPiece(row, col) == player && Board.GetPiece(row, col + 1) == player && Board.GetPiece(row, col + 2) == player && Board.GetPiece(row, col + 3) == player)
                {
                    return true;
                }
            }
        }
        return false;
    }

    private bool CheckVertical(int player)
    {
        for (int col = 0; col < 7; col++)
        {
            for (int row = 0; row <= 2; row++)
            {
                if (Board.GetPiece(row, col) == player &&  Board.GetPiece(row + 1, col) == player && Board.GetPiece(row + 2, col) == player && Board.GetPiece(row + 3, col) == player)
                {
                    return true;
                }
            }
        }
        return false;
    }

    private bool CheckDiagonal(int player)
    {
        for (int row = 0; row <= 2; row++)
        {
            for (int col = 0; col <= 3; col++)
            {
                if (Board.GetPiece(row, col) == player && Board.GetPiece(row + 1, col + 1) == player && Board.GetPiece(row + 2, col + 2) == player && Board.GetPiece(row + 3, col + 3) == player)
                {
                    return true;
                }
            }
        }

        for (int row = 0; row <= 2; row++)
        {
            for (int col = 3; col < 7; col++)
            {
                if (Board.GetPiece(row, col) == player && Board.GetPiece(row + 1, col - 1) == player && Board.GetPiece(row + 2, col - 2) == player && Board.GetPiece(row + 3, col - 3) == player)
                {
                    return true;
                }
            }
        }
        return false;
    }
}