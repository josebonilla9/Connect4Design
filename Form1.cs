namespace prueba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitButtonArray();
        }

        public string AsignarCoordenadasBotones()
        {
            string coordenadas = "";

            foreach (var button in buttonArray)
            {
                if (button.Tag is string coord)
                {
                    coordenadas += coord + " ";
                }
            }

            return coordenadas.Trim();
        }

        private void label_Click(object sender, EventArgs e)
        {
            Label button = sender as Label;

            if (button != null && button.Tag is string coordenada)
            {
                MessageBox.Show($"Coordenada del botón: {coordenada}");
            }
        }
    }
}
