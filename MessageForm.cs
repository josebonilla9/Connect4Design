using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connect4Design
{
    public partial class MessageForm : Form
    {
        public MessageForm()
        {
            InitializeComponent();
        }

        private void messageForm_Load(object sender, EventArgs e)
        {

        }
        public void changeMessage(int index)
        {
            if (index == 0)
            {
                congratsLabel.Text = "¡Felicidades!";
                congratsLabel.ForeColor = Color.Lime;
                messageLabel.Text = "El jugador humano ha ganado";
                messageLabel.ForeColor = Color.Lime;
            }
            else if (index == 1)
            {
                congratsLabel.Text = "La IA ha ganado";
                congratsLabel.ForeColor = Color.Red;
                messageLabel.Text = "¡Mejor suerte la próxima vez!";
                messageLabel.ForeColor = Color.Red;
            }
            else
            {
                congratsLabel.Text = "¡Vaya!";
                congratsLabel.ForeColor = Color.Blue;
                messageLabel.Text = "¡Es un empate!";
                messageLabel.ForeColor = Color.Blue;
            }
        }
    }
}
