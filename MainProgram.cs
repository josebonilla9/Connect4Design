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

            Application.Run(new GameForm());
        }
    }
}
