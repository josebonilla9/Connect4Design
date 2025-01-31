using System;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Connect4Design
{
    public partial class GameChatForm : Form
    {
        private Game game;
        private bool isHumanTurn;
        private int currentPlayer;
        private bool gameOver;
        private AIProgram aiProgram;

        public GameChatForm()
        {
            InitializeComponent();
            game = new Game();
            isHumanTurn = true;
            currentPlayer = 1;
            gameOver = false;

            string apiKey = "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"; // Aquí va la API Key
            aiProgram = new AIProgram(apiKey);
        }

        public TextBox ChatBox => chatBox;
        public TextBox SendBox => sendBox;
        public Button SendButton => sendButton;

        private void pruebaForm_Load(object sender, EventArgs e)
        {
            game.Board.PrintBoardToChatBox(ChatBox);
            AppendToChatBox("Juego iniciado. Turno del jugador humano:");

            SendButton.Click += (senderButton, args) =>
            {
                if (gameOver) return;

                if (isHumanTurn)
                {
                    HandleHumanTurn();
                }
                else
                {
                    HandleAITurn();
                }
            };
        }

        private void HandleHumanTurn()
        {
            if (int.TryParse(SendBox.Text, out int col) && col >= 0 && col <= 6)
            {
                if (game.Board.AddPiece(col, currentPlayer))
                {
                    game.Board.PrintBoardToChatBox(ChatBox);
                    if (game.CheckVictory(currentPlayer))
                    {
                        AppendToChatBox("¡Felicidades! El jugador humano ha ganado.");
                        gameOver = true;
                        return;
                    }

                    SwitchTurn();
                    HandleAITurn();
                }
                else
                {
                    AppendToChatBox("Columna llena. Intenta de nuevo.");
                }
            }
            else
            {
                AppendToChatBox("Entrada inválida. Ingresa un número entre 0 y 6.");
            }
        }

        private async Task HandleAITurn()
        {
            string boardState = BoardToString(game.Board);
            string response = await aiProgram.GetAIResponseAsync(boardState);

            var match = Regex.Match(response, @"\d+");

            if (int.TryParse(match.Value, out int col) && col >= 0 && col <= 6)
            {
                if (game.Board.AddPiece(col, currentPlayer))
                {
                    game.Board.PrintBoardToChatBox(ChatBox);
                    if (game.CheckVictory(currentPlayer))
                    {
                        AppendToChatBox("La IA ha ganado. ¡Mejor suerte la próxima vez!");
                        gameOver = true;
                        return;
                    }

                    SwitchTurn();
                }
                else
                {
                    AppendToChatBox("La IA intentó jugar en una columna llena.");
                }
            }
            else
            {
                AppendToChatBox("La IA devolvió una columna no válida.");
            }
        }

        private void SwitchTurn()
        {
            isHumanTurn = !isHumanTurn;
            currentPlayer = isHumanTurn ? 1 : 2;

            if (game.Board.IsBoardFull())
            {
                AppendToChatBox("El tablero está lleno. ¡Es un empate!");
                gameOver = true;
                return;
            }

            AppendToChatBox(isHumanTurn ? "Turno del jugador humano:" : "Turno de la IA:");
        }

        private void AppendToChatBox(string message)
        {
            ChatBox.AppendText(message + Environment.NewLine);
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

        public void PrintBoardToChatBox(TextBox chatBox)
        {
            chatBox.AppendText("Tablero actual:" + Environment.NewLine);
            for (int row = 0; row < Rows; row++)
            {
                string line = "";
                for (int col = 0; col < Cols; col++)
                {
                    line += (grid[row, col] == 0 ? "\u25A1" : (grid[row, col] == 1 ? "X" : "O")) + " ";
                }
                chatBox.AppendText(line + Environment.NewLine);
            }
        }

        public bool IsBoardFull()
        {
            for (int col = 0; col < Cols; col++)
            {
                if (GetPiece(0, col) == 0)
                {
                    return false;
                }
            }
            return true;
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
                    if (Board.GetPiece(row, col) == player &&
                        Board.GetPiece(row, col + 1) == player &&
                        Board.GetPiece(row, col + 2) == player &&
                        Board.GetPiece(row, col + 3) == player)
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
                    if (Board.GetPiece(row, col) == player &&
                        Board.GetPiece(row + 1, col) == player &&
                        Board.GetPiece(row + 2, col) == player &&
                        Board.GetPiece(row + 3, col) == player)
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
                    if (Board.GetPiece(row, col) == player &&
                        Board.GetPiece(row + 1, col + 1) == player &&
                        Board.GetPiece(row + 2, col + 2) == player &&
                        Board.GetPiece(row + 3, col + 3) == player)
                    {
                        return true;
                    }
                }
            }

            for (int row = 0; row <= 2; row++)
            {
                for (int col = 3; col < 7; col++)
                {
                    if (Board.GetPiece(row, col) == player &&
                        Board.GetPiece(row + 1, col - 1) == player &&
                        Board.GetPiece(row + 2, col - 2) == player &&
                        Board.GetPiece(row + 3, col - 3) == player)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
