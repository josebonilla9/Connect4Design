using System.Text.RegularExpressions;
using Connect4Design;

namespace prueba
{
    /// <summary>
    /// Representa el formulario principal del juego.
    /// </summary>
    public partial class GameForm : Form
    {
        GameChatForm ventanaEmergente = new GameChatForm();
        MessageForm messageForm = new MessageForm();
        private Game game;
        private bool isHumanTurn;
        private int currentPlayer;
        private bool gameOver;
        private AIProgram aiProgram;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="GameForm"/>.
        /// </summary>
        public GameForm()
        {
            InitializeComponent();
            InitLabelArray();

            game = new Game();
            isHumanTurn = true;
            currentPlayer = 1;
            gameOver = false;

            string apiKey = ""; // Aquí va la API Key
            aiProgram = new AIProgram(apiKey);
        }

        /// <summary>
        /// Asigna coordenadas a los botones del juego.
        /// </summary>
        /// <returns>Una cadena con las coordenadas asignadas.</returns>
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

        /// <summary>
        /// Maneja el evento de clic en una etiqueta.
        /// </summary>
        /// <param name="sender">El objeto que envía el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void label_Click(object sender, EventArgs e)
        {
            Label label = sender as Label;

            if (label != null && label.Tag is string coordenada)
            {
                HandleLabelClick(coordenada);
                placeChoosingPlayer(int.Parse(coordenada));
            }
        }

        /// <summary>
        /// Muestra la ventana emergente del chat del juego.
        /// </summary>
        /// <param name="sender">El objeto que envía el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void gameChatButton_Click(object sender, EventArgs e)
        {
            ventanaEmergente.Show();
        }

        /// <summary>
        /// Obtiene el cuadro de texto del chat.
        /// </summary>
        public TextBox ChatBox => chatBox;

        /// <summary>
        /// Maneja el evento de carga del formulario.
        /// </summary>
        /// <param name="sender">El objeto que envía el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            chatBox.Text = "Juego iniciado. Turno del jugador humano:";
        }

        /// <summary>
        /// Maneja el clic en una etiqueta.
        /// </summary>
        /// <param name="coordenadas">Las coordenadas de la etiqueta.</param>
        private void HandleLabelClick(string coordenadas)
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

        /// <summary>
        /// Maneja el turno del jugador humano.
        /// </summary>
        /// <param name="coordenadas">Las coordenadas de la etiqueta.</param>
        private void HandleHumanTurn(string coordenadas)
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

        /// <summary>
        /// Maneja el turno de la IA.
        /// </summary>
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

        /// <summary>
        /// Cambia el turno entre el jugador humano y la IA.
        /// </summary>
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

        /// <summary>
        /// Coloca la ficha de la IA en el tablero.
        /// </summary>
        /// <param name="index">El índice de la columna.</param>
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

        /// <summary>
        /// Coloca la ficha del jugador humano en el tablero.
        /// </summary>
        /// <param name="index">El índice de la columna.</param>
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

        /// <summary>
        /// Convierte el estado del tablero a una cadena.
        /// </summary>
        /// <param name="board">El tablero del juego.</param>
        /// <returns>Una cadena que representa el estado del tablero.</returns>
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

        /// <summary>
        /// Maneja el evento de clic en el botón de reinicio.
        /// </summary>
        /// <param name="sender">El objeto que envía el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void restartButton_Click(object sender, EventArgs e)
        {
            RestartGame();
        }

        /// <summary>
        /// Reinicia el juego.
        /// </summary>
        private void RestartGame()
        {
            game = new Game();
            isHumanTurn = true;
            currentPlayer = 1;
            gameOver = false;

            ResetLabelsBackColor(this);
            chatBox.Text = "Juego reiniciado. Turno del jugador humano:";
        }

        /// <summary>
        /// Restablece el color de fondo de las etiquetas.
        /// </summary>
        /// <param name="parent">El control padre.</param>
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

    /// <summary>
    /// Representa el tablero del juego.
    /// </summary>
    public class Board
    {
        private int[,] grid;
        private const int Rows = 6;
        private const int Cols = 7;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Board"/>.
        /// </summary>
        public Board()
        {
            grid = new int[Rows, Cols];
        }

        /// <summary>
        /// Agrega una pieza al tablero.
        /// </summary>
        /// <param name="col">La columna donde se agregará la pieza.</param>
        /// <param name="player">El jugador que agrega la pieza.</param>
        /// <returns>true si la pieza se agregó correctamente; de lo contrario, false.</returns>
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

        /// <summary>
        /// Obtiene la pieza en una posición específica del tablero.
        /// </summary>
        /// <param name="row">La fila de la pieza.</param>
        /// <param name="col">La columna de la pieza.</param>
        /// <returns>El valor de la pieza en la posición especificada.</returns>
        public int GetPiece(int row, int col)
        {
            return grid[row, col];
        }

        /// <summary>
        /// Imprime el estado actual del tablero en el cuadro de texto del chat.
        /// </summary>
        /// <param name="chatBox">El cuadro de texto del chat.</param>
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

        /// <summary>
        /// Determina si el tablero está lleno.
        /// </summary>
        /// <returns>true si el tablero está lleno; de lo contrario, false.</returns>
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

    /// <summary>
    /// Representa el juego.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Obtiene el tablero del juego.
        /// </summary>
        public Board Board { get; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Game"/>.
        /// </summary>
        public Game()
        {
            Board = new Board();
        }

        /// <summary>
        /// Verifica si un jugador ha ganado.
        /// </summary>
        /// <param name="player">El jugador a verificar.</param>
        /// <returns>true si el jugador ha ganado; de lo contrario, false.</returns>
        public bool CheckVictory(int player)
        {
            return CheckHorizontal(player) || CheckVertical(player) || CheckDiagonal(player);
        }

        /// <summary>
        /// Verifica si un jugador ha ganado horizontalmente.
        /// </summary>
        /// <param name="player">El jugador a verificar.</param>
        /// <returns>true si el jugador ha ganado horizontalmente; de lo contrario, false.</returns>
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

        /// <summary>
        /// Verifica si un jugador ha ganado verticalmente.
        /// </summary>
        /// <param name="player">El jugador a verificar.</param>
        /// <returns>true si el jugador ha ganado verticalmente; de lo contrario, false.</returns>
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

        /// <summary>
        /// Verifica si un jugador ha ganado diagonalmente.
        /// </summary>
        /// <param name="player">El jugador a verificar.</param>
        /// <returns>true si el jugador ha ganado diagonalmente; de lo contrario, false.</returns>
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
