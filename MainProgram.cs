using Connect4Design;

namespace prueba
{
    internal static class MainProgram
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Inicia la aplicación con el formulario principal
            Application.Run(new pruebaForm());
        }
    }
}
