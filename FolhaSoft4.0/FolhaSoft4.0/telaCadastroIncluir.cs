using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projetoPim
{
    public partial class telaCadastroIncluir : Form
    {
        public telaCadastroIncluir()
        {
            InitializeComponent();
        }

        public void Voltarbutton_Click(object sender, EventArgs e)
        {
            var Voltarbutton = new telaCadastro();
            Voltarbutton.Show();
            this.Visible = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["FSConnectionString"].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            var id = 0;
            switch (comboBox1.Text)
            {
                case "Gerente":
                    id = 1;
                    break;

                case "Analista":
                    id = 2;
                    break;

                case "UX Design":
                    id = 3;
                    break;

                case "Desenvolvedor":
                    id = 4;
                    break;

                case "Gerente de projetos":
                    id = 5;
                    break;
            }

            string insert_func = "";
            //nome
            if (maskedTextBox14.Text == "")
            {
                insert_func = "INSERT INTO funcionario (nome, telefone, data_nasc, cpf, rg, email, sexo, estado_civil, carteira_trabalho, nis_pis, data_admissional, data_demissional, usuario, senha, email_acesso, id_cargos) VALUES ('" + textBox1.Text.ToString() + "', '" + maskedTextBox8.Text.ToString() + "', '" + maskedTextBox6.Text.ToString() + "', '" + maskedTextBox3.Text.ToString() + "', '" + maskedTextBox4.Text.ToString() + "', '" + maskedTextBox9.Text.ToString() + "', '" + maskedTextBox5.Text.ToString() + "', '" + maskedTextBox16.Text.ToString() + "', '" + maskedTextBox2.Text.ToString() + "', '" + maskedTextBox10.Text.ToString() + "', '" + maskedTextBox15.Text.ToString() + "', @nulo, '" + textBox6.Text.ToString() + "', '" + textBox7.Text.ToString() + "', '" + textBox9.Text.ToString() + "', " + id + ")";
                SqlCommand cmd_insert_func = new SqlCommand(insert_func, sqlConn);
                cmd_insert_func.Parameters.AddWithValue("@nulo", DBNull.Value); // Define o valor como NULL
                cmd_insert_func.ExecuteNonQuery();
                sqlConn.Close();

            }
            else
            {
                insert_func = "INSERT INTO funcionario (nome, telefone, data_nasc, cpf, rg, email, sexo, estado_civil, carteira_trabalho, nis_pis, data_admissional, data_demissional, usuario, senha, email_acesso, id_cargos) VALUES ('" + textBox1.Text.ToString() + "', '" + maskedTextBox8.Text.ToString() + "', '" + maskedTextBox6.Text.ToString() + "', '" + maskedTextBox3.Text.ToString() + "', '" + maskedTextBox4.Text.ToString() + "', '" + maskedTextBox9.Text.ToString() + "', '" + maskedTextBox5.Text.ToString() + "', '" + maskedTextBox16.Text.ToString() + "', '" + maskedTextBox2.Text.ToString() + "', '" + maskedTextBox10.Text.ToString() + "', '" + maskedTextBox15.Text.ToString() + "', '" + maskedTextBox14.Text.ToString() + "', '" + textBox6.Text.ToString() + "', '" + textBox7.Text.ToString() + "', '" + textBox9.Text.ToString() + "', " + id + ")";
                SqlCommand cmd_insert_func = new SqlCommand(insert_func, sqlConn);
                cmd_insert_func.ExecuteNonQuery();
                sqlConn.Close();
            }

            // Mensagem que o cadastro foi feito e salvo 

            MessageBox.Show("CADASTRO CONCLUÍDO !", "FOLHA SOFT", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Limpa todos os textBox após clicar no OK do MessageBox.Show

            textBox1.Clear();
            maskedTextBox8.Clear();
            maskedTextBox9.Clear();
            maskedTextBox3.Clear();
            maskedTextBox4.Clear();
            maskedTextBox6.Clear();
            maskedTextBox5.Clear();
            maskedTextBox16.Clear();
            maskedTextBox2.Clear();
            maskedTextBox10.Clear();
            maskedTextBox11.Clear();
            maskedTextBox12.Clear();
            comboBox1.ResetText();
            maskedTextBox15.Clear();
            maskedTextBox14.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();

            // DialogResult para saber se o usuário ira fazer outro cadastro

            DialogResult dialogResult = MessageBox.Show(" DESEJA FAZER OUTRO CADASTRO ? ", "FOLHA SOFT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

        private void telaCadastroIncluir_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'projetoPIMDataSet.cargos'. Você pode movê-la ou removê-la conforme necessário.
            this.cargosTableAdapter.Fill(this.projetoPIMDataSet.cargos);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["FSConnectionString"].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();


            //salario
            string query_salario = "select salario from cargos where descricao_cargo = '"+comboBox1.Text+"'";
            SqlCommand cmd_salario = new SqlCommand(query_salario, sqlConn);
            SqlDataAdapter dataAdapter_salario = new SqlDataAdapter();
            dataAdapter_salario.SelectCommand = cmd_salario;
            DataTable dt_salario = new DataTable();
            dataAdapter_salario.Fill(dt_salario);
            var salario = dt_salario.Rows[0][0];
            maskedTextBox11.Text = salario.ToString();


            //carga horaria
            string query_horas = "select carga_horaria_sem from cargos where descricao_cargo = '"+comboBox1.Text+"'";
            SqlCommand cmd_horas = new SqlCommand(query_horas, sqlConn);
            SqlDataAdapter dataAdapter_horas = new SqlDataAdapter();
            dataAdapter_horas.SelectCommand = cmd_horas;
            DataTable dt_horas = new DataTable();
            dataAdapter_horas.Fill(dt_horas);
            var horas = dt_horas.Rows[0][0];
            maskedTextBox12.Text = horas.ToString();

            sqlConn.Close();
           
        }
    }
}
