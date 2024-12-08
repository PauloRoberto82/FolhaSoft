using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace projetoPim
{
    public partial class telaCadastroExcluir : Form
    {
        public telaCadastroExcluir()
        {
            InitializeComponent();
        }

        private void Voltarbutton_Click(object sender, EventArgs e)
        {
            var Voltarbutton = new telaCadastro();
            Voltarbutton.Show();
            this.Visible = false;
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["FSConnectionString"].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            //teto gerente
            string query = "SELECT * FROM [projetoPIM].[dbo].[funcionario] func LEFT JOIN [projetoPIM].[dbo].[cargos] cg on (func.id_cargos = cg.id_cargos) WHERE func.email = '" + textBox2.Text.ToString() + "'";
            SqlCommand cmd = new SqlCommand(query, sqlConn);
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            var id = dt.Rows[0][0];
            maskedTextBox1.Text = id.ToString();
            var nome = dt.Rows[0][1];
            textBox1.Text = nome.ToString();
            var telefone = dt.Rows[0][2];
            maskedTextBox8.Text = telefone.ToString().Replace("-", "");
            var data_nasc = dt.Rows[0][3];
            maskedTextBox6.Text = data_nasc.ToString();
            var cpf = dt.Rows[0][4];
            maskedTextBox3.Text = cpf.ToString();
            var rg = dt.Rows[0][5];
            maskedTextBox4.Text = rg.ToString();
            var email = dt.Rows[0][6];
            textBox8.Text = email.ToString();
            maskedTextBox9.Text = email.ToString();
            var sexo = dt.Rows[0][7];
            if (sexo.ToString() == "M                                                                                                   ")
            {
                sexo = "Masculino";
            }
            else
            {
                sexo = "Feminino";
            }
            maskedTextBox16.Text = sexo.ToString();
            var estado_civil = dt.Rows[0][8];
            maskedTextBox17.Text = estado_civil.ToString();
            var carteira_trabalho = dt.Rows[0][9];
            maskedTextBox2.Text = carteira_trabalho.ToString();
            var nis_pis = dt.Rows[0][10];
            maskedTextBox10.Text = nis_pis.ToString();
            var data_admissional = dt.Rows[0][11];
            maskedTextBox15.Text = data_admissional.ToString();
            var data_demissional = dt.Rows[0][12];
            maskedTextBox14.Text = data_demissional.ToString();
            var usuario = dt.Rows[0][13];
            textBox6.Text = usuario.ToString();
            var senha = dt.Rows[0][14];
            textBox7.Text = senha.ToString();
            var email_acesso = dt.Rows[0][15];
            textBox9.Text = email_acesso.ToString();
            var cargo = dt.Rows[0][18];
            maskedTextBox18.Text = cargo.ToString();
            var salario = dt.Rows[0][19];
            maskedTextBox11.Text = salario.ToString();
            var carga_horaria = dt.Rows[0][20];
            maskedTextBox12.Text = carga_horaria.ToString();
            sqlConn.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["FSConnectionString"].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();



            //nome
            try
            {
                string delete_pag = "DELETE FROM folha_pagamento WHERE id_funcionario = @NovoTeto";
                SqlCommand cmd_delete_pag = new SqlCommand(delete_pag, sqlConn);
                cmd_delete_pag.Parameters.AddWithValue("@NovoTeto", maskedTextBox1.Text);
                cmd_delete_pag.ExecuteNonQuery();

                string delete = "DELETE FROM funcionario WHERE id_funcionario = @NovoTeto";
                SqlCommand cmd_delete = new SqlCommand(delete, sqlConn);
                cmd_delete.Parameters.AddWithValue("@NovoTeto", maskedTextBox1.Text);
                cmd_delete.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                "Aviso",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            finally
            {
                sqlConn.Close();
            }
            //Confirmação que a alteração foi feita e salva

            MessageBox.Show("CADASTRO EXCLUÍDO !", "FOLHA SOFT", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Limpa todos os textBox após clicar no OK do MessageBox.Show

            textBox1.Clear();
            textBox2.Clear();
            maskedTextBox1.Clear();
            maskedTextBox8.Clear();
            maskedTextBox9.Clear();
            maskedTextBox3.Clear();
            maskedTextBox4.Clear();
            maskedTextBox6.Clear();
            maskedTextBox16.Clear();
            maskedTextBox17.Clear();
            maskedTextBox2.Clear();
            maskedTextBox10.Clear();
            maskedTextBox11.Clear();
            maskedTextBox12.Clear();
            maskedTextBox18.Clear();
            maskedTextBox15.Clear();
            maskedTextBox14.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();

            // DialogResult para saber se o usuário ira fazer outro cadastro

            DialogResult dialogResult = MessageBox.Show(" DESEJA FAZER OUTRA EXCLUSÃO ? ", " FOLHA SOFT ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {

            }
            else if (dialogResult == DialogResult.No)
            {
                var Voltarbutton = new telaCadastro();
                Voltarbutton.Show();
                this.Visible = false;
            }
        }
    }
}




