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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace projetoPim
{
    public partial class telaCargosBeneficios : Form
    {
        public telaCargosBeneficios()
        {
            InitializeComponent();
        }

        private void Voltarbutton_Click(object sender, EventArgs e)
        {
            var Voltarbutton = new telaInicio();
            Voltarbutton.Show();
            this.Visible = false;
        }

        private void telaCargosBeneficios_Load(object sender, EventArgs e)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["FSConnectionString"].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            //teto gerente
            string query_teto_ger = "SELECT CONCAT('R$ ', [teto_salario]) FROM [projetoPIM].[dbo].[cargos] WHERE descricao_cargo = 'Gerente'";
            SqlCommand cmd_teto_ger = new SqlCommand(query_teto_ger, sqlConn);
            SqlDataAdapter dataAdapterteto_ger = new SqlDataAdapter();
            dataAdapterteto_ger.SelectCommand = cmd_teto_ger;
            DataTable dt_teto_ger = new DataTable();
            dataAdapterteto_ger.Fill(dt_teto_ger);
            var teto_ger = dt_teto_ger.Rows[0][0];

            //piso gerente
            string query_piso_ger = "SELECT CONCAT('R$ ', [piso_salario]) FROM [projetoPIM].[dbo].[cargos] WHERE descricao_cargo = 'Gerente'";
            SqlCommand cmd_piso_ger = new SqlCommand(query_piso_ger, sqlConn);
            SqlDataAdapter dataAdapter_piso_ger = new SqlDataAdapter();
            dataAdapter_piso_ger.SelectCommand = cmd_piso_ger;
            DataTable dt_piso_ger = new DataTable();
            dataAdapter_piso_ger.Fill(dt_piso_ger);
            var piso_ger = dt_piso_ger.Rows[0][0];


            //teto analista
            string query_teto_ana = "SELECT CONCAT('R$ ', [teto_salario]) FROM [projetoPIM].[dbo].[cargos] WHERE descricao_cargo = 'Analista'";
            SqlCommand cmd_teto_ana = new SqlCommand(query_teto_ana, sqlConn);
            SqlDataAdapter dataAdapter_teto_ana = new SqlDataAdapter();
            dataAdapter_teto_ana.SelectCommand = cmd_teto_ana;
            DataTable dt_teto_ana = new DataTable();
            dataAdapter_teto_ana.Fill(dt_teto_ana);
            var teto_ana = dt_teto_ana.Rows[0][0];

            //piso analista
            string query_piso_ana = "SELECT CONCAT('R$ ', [piso_salario]) FROM [projetoPIM].[dbo].[cargos] WHERE descricao_cargo = 'Analista'";
            SqlCommand cmd_piso_ana = new SqlCommand(query_piso_ana, sqlConn);
            SqlDataAdapter dataAdapter_piso_ana = new SqlDataAdapter();
            dataAdapter_piso_ana.SelectCommand = cmd_piso_ana;
            DataTable dt_piso_ana = new DataTable();
            dataAdapter_piso_ana.Fill(dt_piso_ana);
            var piso_ana = dt_piso_ana.Rows[0][0];


            //teto ux
            string query_teto_ux = "SELECT CONCAT('R$ ', [teto_salario]) FROM [projetoPIM].[dbo].[cargos] WHERE descricao_cargo = 'UX Design'";
            SqlCommand cmd_teto_ux = new SqlCommand(query_teto_ux, sqlConn);
            SqlDataAdapter dataAdapter_teto_ux = new SqlDataAdapter();
            dataAdapter_teto_ux.SelectCommand = cmd_teto_ux;
            DataTable dt_teto_ux = new DataTable();
            dataAdapter_teto_ux.Fill(dt_teto_ux);
            var teto_ux = dt_teto_ux.Rows[0][0];

            //piso ux
            string query_piso_ux = "SELECT CONCAT('R$ ', [piso_salario]) FROM [projetoPIM].[dbo].[cargos] WHERE descricao_cargo = 'UX Design'";
            SqlCommand cmd_piso_ux = new SqlCommand(query_piso_ux, sqlConn);
            SqlDataAdapter dataAdapter_piso_ux = new SqlDataAdapter();
            dataAdapter_piso_ux.SelectCommand = cmd_piso_ux;
            DataTable dt_piso_ux = new DataTable();
            dataAdapter_piso_ux.Fill(dt_piso_ux);
            var piso_ux = dt_piso_ux.Rows[0][0];


            //teto dev
            string query_teto_dev = "SELECT CONCAT('R$ ', [teto_salario]) FROM [projetoPIM].[dbo].[cargos] WHERE descricao_cargo = 'Desenvolvedor'";
            SqlCommand cmd_teto_dev = new SqlCommand(query_teto_dev, sqlConn);
            SqlDataAdapter dataAdapter_teto_dev = new SqlDataAdapter();
            dataAdapter_teto_dev.SelectCommand = cmd_teto_dev;
            DataTable dt_teto_dev = new DataTable();
            dataAdapter_teto_dev.Fill(dt_teto_dev);
            var teto_dev = dt_teto_dev.Rows[0][0];

            //piso dev
            string query_piso_dev = "SELECT CONCAT('R$ ', [piso_salario]) FROM [projetoPIM].[dbo].[cargos] WHERE descricao_cargo = 'Desenvolvedor'";
            SqlCommand cmd_piso_dev = new SqlCommand(query_piso_dev, sqlConn);
            SqlDataAdapter dataAdapter_piso_dev = new SqlDataAdapter();
            dataAdapter_piso_dev.SelectCommand = cmd_piso_dev;
            DataTable dt_piso_dev = new DataTable();
            dataAdapter_piso_dev.Fill(dt_piso_dev);
            var piso_dev = dt_piso_dev.Rows[0][0];


            //teto Gerente de projetos                                                                                 
            string query_teto_gpj = "SELECT CONCAT('R$ ', [teto_salario]) FROM [projetoPIM].[dbo].[cargos] WHERE descricao_cargo = 'Gerente de projetos'";
            SqlCommand cmd_teto_gpj = new SqlCommand(query_teto_gpj, sqlConn);
            SqlDataAdapter dataAdapter_teto_gpj = new SqlDataAdapter();
            dataAdapter_teto_gpj.SelectCommand = cmd_teto_gpj;
            DataTable dt_teto_gpj = new DataTable();
            dataAdapter_teto_gpj.Fill(dt_teto_gpj);
            var teto_gpj = dt_teto_gpj.Rows[0][0];

            //piso Gerente de projetos                                                                                 
            string query_piso_gpj = "SELECT CONCAT('R$ ', [piso_salario]) FROM [projetoPIM].[dbo].[cargos] WHERE descricao_cargo = 'Gerente de projetos'";
            SqlCommand cmd_piso_gpj = new SqlCommand(query_piso_gpj, sqlConn);
            SqlDataAdapter dataAdapter_piso_gpj = new SqlDataAdapter();
            dataAdapter_piso_gpj.SelectCommand = cmd_piso_gpj;
            DataTable dt_piso_gpj = new DataTable();
            dataAdapter_piso_gpj.Fill(dt_piso_gpj);
            var piso_gpj = dt_piso_gpj.Rows[0][0];

            sqlConn.Close();


            //preenche os txt box
            maskedTextBox1.Text = piso_ger.ToString();
            maskedTextBox2.Text = teto_ger.ToString();

            maskedTextBox3.Text = piso_ana.ToString();
            maskedTextBox4.Text = teto_ana.ToString();

            maskedTextBox5.Text = piso_ux.ToString();
            maskedTextBox8.Text = teto_ux.ToString();

            maskedTextBox6.Text = piso_dev.ToString();
            maskedTextBox9.Text = teto_dev.ToString();

            maskedTextBox7.Text = piso_gpj.ToString();
            maskedTextBox10.Text = teto_gpj.ToString();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["FSConnectionString"].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            //teto gerente
            string update_teto_ger = "UPDATE cargos SET teto_salario = @NovoTeto WHERE descricao_cargo = 'Gerente'";
            SqlCommand cmd_update_teto_ger = new SqlCommand(update_teto_ger, sqlConn);
            cmd_update_teto_ger.Parameters.AddWithValue("@NovoTeto", maskedTextBox2.Text.Replace("R$ ", ""));
            cmd_update_teto_ger.ExecuteNonQuery();

            //piso gerente
            string query_piso_ger = "UPDATE cargos SET piso_salario = @NovoTeto WHERE descricao_cargo = 'Gerente'";
            SqlCommand cmd_piso_ger = new SqlCommand(query_piso_ger, sqlConn);
            cmd_piso_ger.Parameters.AddWithValue("@NovoTeto", maskedTextBox1.Text.Replace("R$ ", ""));
            cmd_piso_ger.ExecuteNonQuery();

            //teto analista
            string query_teto_ana = "UPDATE cargos SET teto_salario = @NovoTeto WHERE descricao_cargo = 'Analista'";
            SqlCommand cmd_teto_ana = new SqlCommand(query_teto_ana, sqlConn);
            cmd_teto_ana.Parameters.AddWithValue("@NovoTeto", maskedTextBox4.Text.Replace("R$ ", ""));
            cmd_teto_ana.ExecuteNonQuery();

            //piso analista
            string query_piso_ana = "UPDATE cargos SET piso_salario = @NovoTeto WHERE descricao_cargo = 'Analista'";
            SqlCommand cmd_piso_ana = new SqlCommand(query_piso_ana, sqlConn);
            cmd_piso_ana.Parameters.AddWithValue("@NovoTeto", maskedTextBox3.Text.Replace("R$ ", ""));
            cmd_piso_ana.ExecuteNonQuery();


            //teto ux
            string query_teto_ux = "UPDATE cargos SET teto_salario = @NovoTeto WHERE descricao_cargo = 'UX Design'";
            SqlCommand cmd_teto_ux = new SqlCommand(query_teto_ux, sqlConn);
            cmd_teto_ux.Parameters.AddWithValue("@NovoTeto", maskedTextBox8.Text.Replace("R$ ", ""));
            cmd_teto_ux.ExecuteNonQuery();

            //piso ux
            string query_piso_ux = "UPDATE cargos SET piso_salario = @NovoTeto WHERE descricao_cargo = 'UX Design'";
            SqlCommand cmd_piso_ux = new SqlCommand(query_piso_ux, sqlConn);
            cmd_piso_ux.Parameters.AddWithValue("@NovoTeto", maskedTextBox5.Text.Replace("R$ ", ""));
            cmd_piso_ux.ExecuteNonQuery();


            //teto dev
            string query_teto_dev = "UPDATE cargos SET teto_salario = @NovoTeto WHERE descricao_cargo = 'Desenvolvedor'";
            SqlCommand cmd_teto_dev = new SqlCommand(query_teto_dev, sqlConn);
            cmd_teto_dev.Parameters.AddWithValue("@NovoTeto", maskedTextBox9.Text.Replace("R$ ", ""));
            cmd_teto_dev.ExecuteNonQuery();

            //piso dev
            string query_piso_dev = "UPDATE cargos SET piso_salario = @NovoTeto WHERE descricao_cargo = 'Desenvolvedor'";
            SqlCommand cmd_piso_dev = new SqlCommand(query_piso_dev, sqlConn);
            cmd_piso_dev.Parameters.AddWithValue("@NovoTeto", maskedTextBox6.Text.Replace("R$ ", ""));
            cmd_piso_dev.ExecuteNonQuery();


            //teto Gerente de projetos                                                                                 
            string query_teto_gpj = "UPDATE cargos SET teto_salario = @NovoTeto WHERE descricao_cargo = 'Gerente de projetos'";
            SqlCommand cmd_teto_gpj = new SqlCommand(query_teto_gpj, sqlConn);
            cmd_teto_gpj.Parameters.AddWithValue("@NovoTeto", maskedTextBox10.Text.Replace("R$ ", ""));
            cmd_teto_gpj.ExecuteNonQuery();

            //piso Gerente de projetos                                                                                 
            string query_piso_gpj = "UPDATE cargos SET piso_salario = @NovoTeto WHERE descricao_cargo = 'Gerente de projetos'";
            SqlCommand cmd_piso_gpj = new SqlCommand(query_piso_gpj, sqlConn);
            cmd_piso_gpj.Parameters.AddWithValue("@NovoTeto", maskedTextBox7.Text.Replace("R$ ", ""));
            cmd_piso_gpj.ExecuteNonQuery();

            sqlConn.Close();
        }
    }
}
