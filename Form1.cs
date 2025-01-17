namespace prueba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitLabelArray();
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

            return coordenadas.Trim();
        }

        private void label_Click(object sender, EventArgs e)
        {
            Label label = sender as Label;

            if (label != null && label.Tag is string coordenada)
            {
                MessageBox.Show($"Coordenada del botón: {coordenada}");
            }
        }
    }
}
