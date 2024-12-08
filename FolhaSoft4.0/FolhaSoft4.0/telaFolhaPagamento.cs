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
    public partial class telaFolhaPagamento : Form
    {
        public telaFolhaPagamento()
        {
            InitializeComponent();
        }

        private void Voltarbutton_Click(object sender, EventArgs e)
        {
            // abre o a página do menu.
            var voltar = new telaInicio();
            voltar.Show();
            this.Visible = false;
        }

        private void listarButton_Click(object sender, EventArgs e)
        {
            var listar = new telaPagamentoListar();
            listar.Show();
            this.Visible = false;
        }

        private void alterarButton_Click(object sender, EventArgs e)
        {
            var alterar = new telaPagamentoAlterar();
            alterar.Show();
            this.Visible = false;
        }

        private void includeButton_Click(object sender, EventArgs e)
        {
            var incluir = new telaPagamentoIncluir();
            incluir.Show();
            this.Visible = false;
        }

        private void excluirButton_Click(object sender, EventArgs e)
        {
            var incluir = new telaPagamentoExcluir();
            incluir.Show();
            this.Visible = false;
        }
    }
}
