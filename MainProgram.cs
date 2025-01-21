using Connect4Design;

namespace prueba
{
    internal static class MainProgram
    {
        [STAThread]
        static async Task Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            pruebaForm ventanaEmergente = new pruebaForm();
            ventanaEmergente.Show();

            Program iaProgram = new Program();
            await iaProgram.gameInit(ventanaEmergente);


        }
    }
}