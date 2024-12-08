using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projetoPim
{
    public partial class telaDadosEmpresa : Form
    {
        public telaDadosEmpresa()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }
        private void Voltarbutton_Click(object sender, EventArgs e)
        {
            var Voltarbutton = new telaInicio();
            Voltarbutton.Show();
            this.Visible = false;
        }
    }
}
