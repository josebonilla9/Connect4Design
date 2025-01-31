using System.Text.RegularExpressions;
using Connect4Design;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace prueba
{
    public partial class GameForm : Form
    {
        GameChatForm ventanaEmergente = new GameChatForm();
        MessageForm messageForm = new MessageForm();
        private Game game;
        private bool isHumanTurn;
        private int currentPlayer;
        private bool gameOver;
        private AIProgram aiProgram;

        public GameForm()
        {
            InitializeComponent();
            InitLabelArray();

            game = new Game();
            isHumanTurn = true;
            currentPlayer = 1;
            gameOver = false;

            string apiKey = "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"; // Aquí va la API Key
            aiProgram = new AIProgram(apiKey);
        }

        public string AsignarCoordenadasBotones()
        {
            string coordenadas = "";

            foreach (var label in labelArray)
            {
                if (label.Tag is string coord)
                {
                    coordenadas += coord + " ";
                }
            }

            return coordenadas;
        }

        private void label_Click(object sender, EventArgs e)
        {
            Label label = sender as Label;

            if (label != null && label.Tag is string coordenada)
            {
                HandleLabelClick(coordenada);
                placeChoosingPlayer(int.Parse(coordenada));
            }
        }

        private void gameChatButton_Click(object sender, EventArgs e)
        {
            ventanaEmergente.Show();
        }

        public TextBox ChatBox => chatBox;

        private void Form1_Load(object sender, EventArgs e)
        {
            chatBox.Text = "Juego iniciado. Turno del jugador humano:";
        }
        private void HandleLabelClick(String coordenadas)
        {
            if (gameOver) return;

            if (isHumanTurn)
            {
                HandleHumanTurn(coordenadas);
            }
            else
            {
                HandleAITurn();
            }
        }

        private void HandleHumanTurn(String coordenadas)
        {
            if (int.TryParse(coordenadas, out int col) && col >= 0 && col <= 6)
            {
                if (game.Board.AddPiece(col, currentPlayer))
                {
                    if (game.CheckVictory(currentPlayer))
                    {
                        messageForm.changeMessage(0);
                        messageForm.Show();
                        chatBox.Text = "¡Felicidades! El jugador humano ha ganado.";
                        gameOver = true;
                        return;
                    }

                    SwitchTurn();
                    HandleAITurn();
                }
                else
                {
                    chatBox.Text = "Columna llena. Intenta de nuevo.";
                }
            }
            else
            {
                chatBox.Text = "Entrada inválida. Ingresa un número entre 0 y 6.";
            }
        }

        private async Task HandleAITurn()
        {
            string boardState = BoardToString(game.Board);
            string response = await aiProgram.GetAIResponseAsync(boardState);

            var match = Regex.Match(response, @"\d+");

            var matchNumber = int.Parse(match.Value);
            placeChoosingAI(matchNumber);

            if (int.TryParse(match.Value, out int col) && col >= 0 && col <= 6)
            {
                if (game.Board.AddPiece(col, currentPlayer))
                {
                    if (game.CheckVictory(currentPlayer))
                    {
                        messageForm.changeMessage(1);
                        messageForm.Show();
                        chatBox.Text = "La IA ha ganado. ¡Mejor suerte la próxima vez!";
                        gameOver = true;
                        return;
                    }

                    SwitchTurn();
                }
                else
                {
                    chatBox.Text = "La IA intentó jugar en una columna llena.";
                }
            }
            else
            {
                chatBox.Text = "La IA devolvió una columna no válida.";
            }
        }

        private void SwitchTurn()
        {
            isHumanTurn = !isHumanTurn;
            currentPlayer = isHumanTurn ? 1 : 2;

            if (game.Board.IsBoardFull())
            {
                chatBox.Text = "El tablero está lleno. ¡Es un empate!";
                gameOver = true;
                return;
            }

            chatBox.Text = isHumanTurn ? "Turno del jugador humano" : "Turno de la IA";
        }

        private Label[][] labels;

        private void placeChoosingAI(int index)
        {
            labels = new Label[][]
            {
                new Label[] { label1, label8, label15, label22, label29, label36 },
                new Label[] { label2, label9, label16, label23, label30, label37 },
                new Label[] { label3, label10, label17, label24, label31, label38 },
                new Label[] { label4, label11, label18, label25, label32, label39 },
                new Label[] { label5, label12, label19, label26, label33, label40 },
                new Label[] { label6, label13, label20, label27, label34, label41 },
                new Label[] { label7, label14, label21, label28, label35, label42 }
            };

            if (index >= 0 && index < labels.Length)
            {
                foreach (Label lbl in labels[index])
                {
                    if (lbl.BackColor != Color.Red && lbl.BackColor != Color.Yellow)
                    {
                        lbl.BackColor = Color.Yellow;
                        break;
                    }
                }
            }
        }

        private void placeChoosingPlayer(int index)
        {
            labels = new Label[][]
            {
                new Label[] { label1, label8, label15, label22, label29, label36 },
                new Label[] { label2, label9, label16, label23, label30, label37 },
                new Label[] { label3, label10, label17, label24, label31, label38 },
                new Label[] { label4, label11, label18, label25, label32, label39 },
                new Label[] { label5, label12, label19, label26, label33, label40 },
                new Label[] { label6, label13, label20, label27, label34, label41 },
                new Label[] { label7, label14, label21, label28, label35, label42 }
            };

            if (index >= 0 && index < labels.Length)
            {
                foreach (Label lbl in labels[index])
                {
                    if (lbl.BackColor != Color.Red && lbl.BackColor != Color.Yellow)
                    {
                        lbl.BackColor = Color.Red;
                        break;
                    }
                }
            }
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

        private void restartButton_Click(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void RestartGame()
        {
            game = new Game();
            isHumanTurn = true;
            currentPlayer = 1;
            gameOver = false;

            ResetLabelsBackColor(this);
            chatBox.Text = "Juego reiniciado. Turno del jugador humano:";
        }

        private void ResetLabelsBackColor(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is Label lbl && lbl.Tag is string)
                {
                    lbl.BackColor = Color.White;
                }
                else if (control.HasChildren)
                {
                    ResetLabelsBackColor(control);
                }
            }
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
