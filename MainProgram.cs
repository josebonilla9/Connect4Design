using Connect4Design;

namespace prueba
{
    /// <summary>
    /// Clase principal del programa.
    /// </summary>
    internal static class MainProgram
    {
        /// <summary>
        /// Punto de entrada principal para la aplicaci�n.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Habilita estilos visuales para la aplicaci�n.
            Application.EnableVisualStyles();

            // Establece la representaci�n de texto compatible por defecto.
            Application.SetCompatibleTextRenderingDefault(false);

            // Inicia la ejecuci�n del formulario principal del juego.
            Application.Run(new GameForm());
        }
    }
}
