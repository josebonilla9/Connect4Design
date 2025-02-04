using Connect4Design;

namespace prueba
{
    /// <summary>
    /// Clase principal del programa.
    /// </summary>
    internal static class MainProgram
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Habilita estilos visuales para la aplicación.
            Application.EnableVisualStyles();

            // Establece la representación de texto compatible por defecto.
            Application.SetCompatibleTextRenderingDefault(false);

            // Inicia la ejecución del formulario principal del juego.
            Application.Run(new GameForm());
        }
    }
}
