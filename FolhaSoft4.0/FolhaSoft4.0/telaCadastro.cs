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
    public partial class telaCadastro : Form
    {
        public telaCadastro()
        {
            InitializeComponent();
        }

        private void includeButton_Click(object sender, EventArgs e)
        {
            // abre o a página do menu.
            var includeButton = new telaCadastroIncluir();
            includeButton.Show();
            this.Visible = false;
        }

        private void alterarButton_Click(object sender, EventArgs e)
        {
            // abre o a página do menu.
            var cadastroAlterar = new telaCadastroAlterar();
            cadastroAlterar.Show();
            this.Visible = false;
        }

        private void excluirButton_Click(object sender, EventArgs e)
        {
            // abre o a página do menu.
            var cadastroExcluir = new telaCadastroExcluir();
            cadastroExcluir.Show();
            this.Visible = false;
        }

        private void listarButton_Click(object sender, EventArgs e)
        {
            // abre o a página do menu.
            var cadastroListar = new telaCadastroListar();
            cadastroListar.Show();
            this.Visible = false;
        }

        private void Voltarbutton_Click(object sender, EventArgs e)
        {
            var Voltarbutton = new telaInicio();
            Voltarbutton.Show();
            this.Visible = false;
        }
    }
}
