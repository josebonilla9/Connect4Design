namespace prueba
{
    internal static class MainProgram
    {
        [STAThread]
        static async Task Main()
        {
            Application.Run(new Form1());

            Program iaProgram =  new Program();
            await iaProgram.gameInit();
        }
    }
}