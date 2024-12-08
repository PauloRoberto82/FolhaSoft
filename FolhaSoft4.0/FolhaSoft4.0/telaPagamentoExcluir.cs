using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace projetoPim
{
    public partial class telaPagamentoExcluir : Form
    {
        public telaPagamentoExcluir()
        {
            InitializeComponent();
        }

        private void Voltarbutton_Click(object sender, EventArgs e)
        {
            // abre o a página do menu.
            var voltar = new telaFolhaPagamento();
            voltar.Show();
            this.Visible = false;
        }

        private void telaPagamentoExcluir_Load(object sender, EventArgs e)
        {
            // Exemplo de um DataTable como fonte de dados.
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("id_mes", typeof(int));
            dataTable.Columns.Add("mes", typeof(string));

            // Preencha o DataTable com dados de exemplo.
            dataTable.Rows.Add(1, "JANEIRO");
            dataTable.Rows.Add(2, "FEVEREIRO");
            dataTable.Rows.Add(3, "MARÇO");
            dataTable.Rows.Add(4, "ABRIL");
            dataTable.Rows.Add(5, "MAIO");
            dataTable.Rows.Add(6, "JUNHO");
            dataTable.Rows.Add(7, "JULHO");
            dataTable.Rows.Add(8, "AGOSTO");
            dataTable.Rows.Add(9, "SETEMBRO");
            dataTable.Rows.Add(10, "OUTUBRO");
            dataTable.Rows.Add(11, "NOVEMBRO");
            dataTable.Rows.Add(12, "DEZEMBRO");

            // Defina o DataSource do ComboBox.
            comboBox1.DataSource = dataTable;

            // Defina o ValueMember e o DisplayMember.
            comboBox1.ValueMember = "id_mes";     // Coluna para valores.
            comboBox1.DisplayMember = "mes";    // Coluna para exibição.


            var connectionString = ConfigurationManager.ConnectionStrings["FSConnectionString"].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();


            string query = "SELECT DISTINCT YEAR(data_pagamento) AS Ano FROM [projetoPIM].[dbo].[folha_pagamento]";
            SqlCommand cmd = new SqlCommand(query, sqlConn);
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);

            // Defina o DataSource do ComboBox.
            comboBox2.DataSource = dt;

            // Defina o ValueMember e o DisplayMember.
            comboBox2.ValueMember = "Ano";     // Coluna para valores.
            comboBox2.DisplayMember = "Ano";    // Coluna para exibição.

        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["FSConnectionString"].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            try
            {
                string query = "SELECT TOP(1) fun.id_funcionario,fun.nome,car.descricao_cargo,pag.valor_pagamento,pag.data_pagamento,pag.descricao_evento,pag.faltas FROM projetoPIM.dbo.funcionario fun LEFT JOIN projetoPIM.dbo.cargos car ON (fun.id_cargos = car.id_cargos) LEFT JOIN projetoPIM.dbo.folha_pagamento pag ON (fun.id_funcionario = pag.id_funcionario) WHERE fun.email='" + códigoFuncTextBox1.Text + "' AND MONTH(data_pagamento)=" + comboBox1.SelectedValue.ToString() + " AND YEAR(data_pagamento)=" + comboBox2.SelectedValue.ToString() + "";
                SqlCommand cmd = new SqlCommand(query, sqlConn);
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                var id = dt.Rows[0][0];
                var nome = dt.Rows[0][1];
                var cargo = dt.Rows[0][2];
                var salario = dt.Rows[0][3];
                var data_pagamento = dt.Rows[0][4];
                var evento = dt.Rows[0][5];
                var faltas = dt.Rows[0][6];
                CodigoTextBox4.Text = id.ToString();
                NomeTextBox5.Text = nome.ToString();
                CargoTextBox6.Text = cargo.ToString();
                SalarioTextBox9.Text = salario.ToString();
                datatext.Text = data_pagamento.ToString();
                descricaoText.Text = evento.ToString();
                FaltasText.Text = faltas.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("DIGITE UM USUÁRIO!",
                                "Aviso",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

        }

        private void ExcluirHoleritebutton12_Click(object sender, EventArgs e)
        {
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["FSConnectionString"].ConnectionString;
                SqlConnection sqlConn = new SqlConnection(connectionString);
                sqlConn.Open();

                string delete = "DELETE FROM[projetoPIM].[dbo].[folha_pagamento] WHERE data_pagamento = @data AND id_funcionario = @id";
                SqlCommand cmd_delete = new SqlCommand(delete, sqlConn);
                string data_f = DateTime.Parse(datatext.Text).ToString("dd-MM-yyyy");
                cmd_delete.Parameters.AddWithValue("@data", data_f);
                cmd_delete.Parameters.AddWithValue("@id", CodigoTextBox4.Text);
                cmd_delete.ExecuteNonQuery();

                MessageBox.Show("PAGAMENTO EXCLUÍDO",
                "FOLHA SOFT",
                MessageBoxButtons.OK,
                MessageBoxIcon.Asterisk);

                CodigoTextBox4.Clear();
                NomeTextBox5.Clear();
                CargoTextBox6.Clear();
                SalarioTextBox9.Clear();
                datatext.Clear();
                descricaoText.Clear();
                FaltasText.Clear();
                códigoFuncTextBox1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                "Aviso",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }


        }
    }
}
