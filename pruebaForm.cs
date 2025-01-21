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
    public partial class pruebaForm : Form
    {
        public pruebaForm()
        {
            InitializeComponent();
        }

        public TextBox ChatBox => chatBox;
        public TextBox SendBox => sendBox;
        public Button SendButton => sendButton;

        private void pruebaForm_Load(object sender, EventArgs e)
        {

        }
    }
}
