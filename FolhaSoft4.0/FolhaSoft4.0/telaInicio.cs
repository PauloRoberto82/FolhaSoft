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
    public partial class telaInicio : Form
    {
        public telaInicio()
        {
            InitializeComponent();
        }

        private void telaInicio_Load(object sender, EventArgs e)
        {

        }

        private void dadosEmpresaButton_Click(object sender, EventArgs e)
        {
            // abre o a página do menu.
            var dadosEmpresa = new telaDadosEmpresa();
            dadosEmpresa.Show();
            this.Visible = false;
        }

        private void encargosImpostosButton_Click(object sender, EventArgs e)
        {
            // abre o a página do menu.
            var encargosImpostos = new telaEncargosImpostos();
            encargosImpostos.Show();
            this.Visible = false;
        }

        private void cargosBeneficiosButton_Click(object sender, EventArgs e)
        {
            // abre o a página do menu.
            var cargosBeneficios = new telaCargosBeneficios();
            cargosBeneficios.Show();
            this.Visible = false;
        }

        private void cadastroButton_Click(object sender, EventArgs e)
        {
            var cadastroButton = new telaCadastro();
            cadastroButton.Show();
            this.Visible = false;
        }

        private void holeritesButton_Click(object sender, EventArgs e)
        {
            var holeritesButton = new telaHolerites();
            holeritesButton.Show();
            this.Visible = false;
        }

        private void folhaPagamenButton_Click(object sender, EventArgs e)
        {
            var folhaPagamento = new telaFolhaPagamento();
            folhaPagamento.Show();
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var login = new telaLogin();
            login.Show();
            this.Visible = false;
        }
    }
}
