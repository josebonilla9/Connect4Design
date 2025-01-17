namespace prueba
{
    internal static class MainProgram
    {
        [STAThread]
        static void Main()
        {
            Application.Run(new Form1());
            Program iaProgram = new Program();
            iaProgram.gameInit();
        }
    }
}