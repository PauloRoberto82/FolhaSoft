using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace projetoPim
{
    public partial class telaCadastroAlterar : Form
    {
        public telaCadastroAlterar()
        {
            InitializeComponent();
        }

        private void Voltarbutton_Click(object sender, EventArgs e)
        {
            var Voltarbutton = new telaCadastro();
            Voltarbutton.Show();
            this.Visible = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            var nome = textBox1.Text;
            var telefone = maskedTextBox8.Text;
            var data_nasc = maskedTextBox6.Text;
            var cpf = maskedTextBox3.Text;
            var rg = maskedTextBox4.Text;
            var email = textBox8.Text;
            var sexo = textBox10.Text;
            var estado_civil = textBox11.Text;
            var carteira_trabalho = maskedTextBox2.Text;
            var nis_pis = maskedTextBox10.Text;
            var data_admissional = maskedTextBox15.Text;
            var data_demissional = maskedTextBox14.Text;
            var usuario = textBox6.Text;
            var senha = textBox7.Text;
            var email_acesso = textBox9.Text;
            var cargo = textBox13.Text;
            var salario = maskedTextBox11.Text;
            var carga_horaria = maskedTextBox12.Text;


            var connectionString = ConfigurationManager.ConnectionStrings["FSConnectionString"].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            //nome
            string update_nome = "UPDATE funcionario SET nome = @NovoTeto WHERE id_funcionario = " + maskedTextBox1.Text + "";
            SqlCommand cmd_update_nome = new SqlCommand(update_nome, sqlConn);
            cmd_update_nome.Parameters.AddWithValue("@NovoTeto", nome);
            cmd_update_nome.ExecuteNonQuery();

            //telefone
            string update_telefone = "UPDATE funcionario SET telefone = @NovoTeto WHERE id_funcionario = " + maskedTextBox1.Text + "";
            SqlCommand cmd_update_telefone = new SqlCommand(update_telefone, sqlConn);
            cmd_update_telefone.Parameters.AddWithValue("@NovoTeto", telefone);
            cmd_update_telefone.ExecuteNonQuery();

            //data_nasc
            string update_data_nasc = "UPDATE funcionario SET data_nasc = @NovoTeto WHERE id_funcionario = " + maskedTextBox1.Text + "";
            SqlCommand cmd_update_data_nasc = new SqlCommand(update_data_nasc, sqlConn);
            cmd_update_data_nasc.Parameters.AddWithValue("@NovoTeto", data_nasc);
            cmd_update_data_nasc.ExecuteNonQuery();

            //cpf
            string update_cpf = "UPDATE funcionario SET cpf = @NovoTeto WHERE id_funcionario = " + maskedTextBox1.Text + "";
            SqlCommand cmd_update_cpf = new SqlCommand(update_cpf, sqlConn);
            cmd_update_cpf.Parameters.AddWithValue("@NovoTeto", cpf);
            cmd_update_cpf.ExecuteNonQuery();

            //rg
            string update_rg = "UPDATE funcionario SET rg = @NovoTeto WHERE id_funcionario = " + maskedTextBox1.Text + "";
            SqlCommand cmd_update_rg = new SqlCommand(update_rg, sqlConn);
            cmd_update_rg.Parameters.AddWithValue("@NovoTeto", rg);
            cmd_update_rg.ExecuteNonQuery();

            //email
            string update_email = "UPDATE funcionario SET email = @NovoTeto WHERE id_funcionario = " + maskedTextBox1.Text + "";
            SqlCommand cmd_update_email = new SqlCommand(update_email, sqlConn);
            cmd_update_email.Parameters.AddWithValue("@NovoTeto", email);
            cmd_update_email.ExecuteNonQuery();

            //sexo 
            string update_sexo = "UPDATE funcionario SET sexo = @NovoTeto WHERE id_funcionario = " + maskedTextBox1.Text + "";
            SqlCommand cmd_update_sexo = new SqlCommand(update_sexo, sqlConn);
            cmd_update_sexo.Parameters.AddWithValue("@NovoTeto", sexo);
            cmd_update_sexo.ExecuteNonQuery();

            //estado_civil
            string update_estado_civil = "UPDATE funcionario SET estado_civil = @NovoTeto WHERE id_funcionario = " + maskedTextBox1.Text + "";
            SqlCommand cmd_update_estado_civil = new SqlCommand(update_estado_civil, sqlConn);
            cmd_update_estado_civil.Parameters.AddWithValue("@NovoTeto", estado_civil);
            cmd_update_estado_civil.ExecuteNonQuery();

            //carteira_trabalho
            string update_carteira_trabalho = "UPDATE funcionario SET carteira_trabalho = @NovoTeto WHERE id_funcionario = " + maskedTextBox1.Text + "";
            SqlCommand cmd_update_carteira_trabalho = new SqlCommand(update_carteira_trabalho, sqlConn);
            cmd_update_carteira_trabalho.Parameters.AddWithValue("@NovoTeto", carteira_trabalho);
            cmd_update_carteira_trabalho.ExecuteNonQuery();

            //nis_pis
            string update_nis_pis = "UPDATE funcionario SET nis_pis = @NovoTeto WHERE id_funcionario = " + maskedTextBox1.Text + "";
            SqlCommand cmd_update_nis_pis = new SqlCommand(update_nis_pis, sqlConn);
            cmd_update_nis_pis.Parameters.AddWithValue("@NovoTeto", nis_pis);
            cmd_update_nis_pis.ExecuteNonQuery();

            //data_admissional
            string update_data_admissional = "UPDATE funcionario SET data_admissional = @NovoTeto WHERE id_funcionario = " + maskedTextBox1.Text + "";
            SqlCommand cmd_update_data_admissional = new SqlCommand(update_data_admissional, sqlConn);
            cmd_update_data_admissional.Parameters.AddWithValue("@NovoTeto", data_admissional);
            cmd_update_data_admissional.ExecuteNonQuery();

            //data_demissional
            string update_data_demissional = "UPDATE funcionario SET data_demissional = @NovoTeto WHERE id_funcionario = " + maskedTextBox1.Text + "";
            SqlCommand cmd_update_data_demissional = new SqlCommand(update_data_demissional, sqlConn);
            cmd_update_data_demissional.Parameters.AddWithValue("@NovoTeto", data_demissional);
            cmd_update_data_demissional.ExecuteNonQuery();

            //usuario
            string update_usuario = "UPDATE funcionario SET usuario = @NovoTeto WHERE id_funcionario = " + maskedTextBox1.Text + "";
            SqlCommand cmd_update_usuario = new SqlCommand(update_usuario, sqlConn);
            cmd_update_usuario.Parameters.AddWithValue("@NovoTeto", usuario);
            cmd_update_usuario.ExecuteNonQuery();

            //senha
            string update_senha = "UPDATE funcionario SET senha = @NovoTeto WHERE id_funcionario = " + maskedTextBox1.Text + "";
            SqlCommand cmd_update_senha = new SqlCommand(update_senha, sqlConn);
            cmd_update_senha.Parameters.AddWithValue("@NovoTeto", senha);
            cmd_update_senha.ExecuteNonQuery();

            //email_acesso
            string update_email_acesso = "UPDATE funcionario SET email_acesso = @NovoTeto WHERE id_funcionario = " + maskedTextBox1.Text + "";
            SqlCommand cmd_update_email_acesso = new SqlCommand(update_email_acesso, sqlConn);
            cmd_update_email_acesso.Parameters.AddWithValue("@NovoTeto", email_acesso);
            cmd_update_email_acesso.ExecuteNonQuery();

            //cargo
            string update_cargo = "UPDATE cargos SET descricao_cargo = @NovoTeto WHERE id_cargos = @IdCargo";
            SqlCommand cmd_update_cargo = new SqlCommand(update_cargo, sqlConn);
            cmd_update_cargo.Parameters.AddWithValue("@NovoTeto", cargo); 
            cmd_update_cargo.Parameters.AddWithValue("@IdCargo", maskedTextBox1.Text);
            cmd_update_cargo.ExecuteNonQuery();

            //salario
            string update_salario = "UPDATE cargos SET salario = @NovoTeto WHERE id_cargos = " + maskedTextBox1.Text + "";
            SqlCommand cmd_update_salario = new SqlCommand(update_salario, sqlConn);
            cmd_update_salario.Parameters.AddWithValue("@NovoTeto", decimal.Parse(salario));
            cmd_update_salario.ExecuteNonQuery();

            //carga_horaria
            string update_carga_horaria = "UPDATE cargos SET carga_horaria_sem = @NovoTeto WHERE id_cargos = " + maskedTextBox1.Text + "";
            SqlCommand cmd_update_carga_horaria = new SqlCommand(update_carga_horaria, sqlConn);
            cmd_update_carga_horaria.Parameters.AddWithValue("@NovoTeto", carga_horaria);
            cmd_update_carga_horaria.ExecuteNonQuery();

            sqlConn.Close();

           //Confirmação que a alteração foi feita e salva

            MessageBox.Show("CADASTRO ALTERADO !", "FOLHA SOFT", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Limpa todos os textBox após clicar no OK do MessageBox.Show

            textBox1.Clear(); 
           textBox2.Clear(); 
           maskedTextBox1.Clear(); 
           maskedTextBox8.Clear(); 
           maskedTextBox9.Clear(); 
           maskedTextBox3.Clear(); 
           maskedTextBox4.Clear(); 
           maskedTextBox6.Clear(); 
           textBox10.Clear(); 
           textBox11.Clear(); 
           maskedTextBox2.Clear();
           maskedTextBox10.Clear(); 
           maskedTextBox11.Clear(); 
           maskedTextBox12.Clear(); 
           textBox13.Clear(); 
           maskedTextBox15.Clear(); 
           maskedTextBox14.Clear(); 
           textBox6.Clear(); 
           textBox7.Clear(); 
           textBox8.Clear(); 
           textBox9.Clear();

            // DialogResult para saber se o usuário ira fazer outro cadastro

            DialogResult dialogResult = MessageBox.Show(" DESEJA FAZER OUTRA ALTERAÇÃO ? ", " FOLHA SOFT ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

        private void Buscar_Click(object sender, EventArgs e)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["FSConnectionString"].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            //teto gerente
            string query = "SELECT * FROM [projetoPIM].[dbo].[funcionario] func LEFT JOIN [projetoPIM].[dbo].[cargos] cg on (func.id_cargos = cg.id_cargos) WHERE func.email = '"+textBox2.Text.ToString()+"'";
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
            textBox10.Text = sexo.ToString();
            var estado_civil = dt.Rows[0][8];
            textBox11.Text = estado_civil.ToString();
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
            textBox13.Text = cargo.ToString();
            var salario = dt.Rows[0][19];
            maskedTextBox11.Text = salario.ToString();
            var carga_horaria = dt.Rows[0][20];
            maskedTextBox12.Text = carga_horaria.ToString();
            sqlConn.Close();
        }
    }
}
