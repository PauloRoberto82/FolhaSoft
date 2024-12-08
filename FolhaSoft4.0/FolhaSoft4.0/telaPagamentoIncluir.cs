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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace projetoPim
{
    public partial class telaPagamentoIncluir : Form
    {
        public telaPagamentoIncluir()
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

        private void SalvarHoleritebutton12_Click(object sender, EventArgs e)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["FSConnectionString"].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            var id_cargo = "";
            var id_funcionario = "";

            //id_cargo
            try
            {
                string query = "SELECT car.id_cargos FROM projetoPIM.dbo.cargos car LEFT JOIN projetoPIM.dbo.funcionario fun ON (car.id_cargos = fun.id_cargos) WHERE fun.email = '"+códigoFuncTextBox1.Text.ToString()+"'";
                SqlCommand cmd = new SqlCommand(query, sqlConn);
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                var resultado_cargo = dt.Rows[0][0];
                id_cargo = resultado_cargo.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                "Aviso",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

            //id_funcionario
            try
            {
                string query = "SELECT fun.id_funcionario FROM projetoPIM.dbo.funcionario fun WHERE fun.email = '" + códigoFuncTextBox1.Text.ToString() + "'";
                SqlCommand cmd = new SqlCommand(query, sqlConn);
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                var resultado_func = dt.Rows[0][0];
                id_funcionario = resultado_func.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                "Aviso",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

            try
            {
                string query = "INSERT INTO [projetoPIM].[dbo].[folha_pagamento] ([id_cargos],[id_descontos],[data_pagamento],[id_funcionario],[descricao_evento],[faltas],[valor_pagamento]) VALUES ("+id_cargo+",1,'"+dataText.Text.ToString()+"',"+ id_funcionario + ",'"+textBox2.Text.ToString()+"',"+textBox3.Text+","+SalarioTextBox9.Text.Replace(',', '.') +")";
                SqlCommand cmd = new SqlCommand(query, sqlConn);
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);

                //MessageBox simples de aviso

                MessageBox.Show("PAGAMENTO REGISTRADO !",
                    "FOLHA SOFT",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);

                //Limpa todas a TextBox 
                textBox2.Clear();   
                CodigoTextBox4.Clear();
                NomeTextBox5.Clear();
                CargoTextBox6.Clear();
                SalarioTextBox9.Clear();
                códigoFuncTextBox1.Clear();
                dataText.Clear();
                textBox3.Clear();

                DialogResult dialogResult = MessageBox.Show(" DESEJA FAZER OUTRO PAGAMENTO ? ", "FOLHA SOFT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {

                }
                else if (dialogResult == DialogResult.No)
                {
                    var voltar = new telaFolhaPagamento();
                    voltar.Show();
                    this.Visible = false;

                }






            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                "FOLHA SOFT",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

            sqlConn.Close();




        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["FSConnectionString"].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            try
            {
                string query = "SELECT TOP(1) fun.id_funcionario,fun.nome,car.descricao_cargo,car.salario FROM projetoPIM.dbo.funcionario fun LEFT JOIN projetoPIM.dbo.cargos car ON (fun.id_cargos = car.id_cargos) WHERE fun.email='" + códigoFuncTextBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(query, sqlConn);
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                var id = dt.Rows[0][0];
                var nome = dt.Rows[0][1];
                var cargo = dt.Rows[0][2];
                var salario = dt.Rows[0][3];
                CodigoTextBox4.Text = id.ToString();
                NomeTextBox5.Text = nome.ToString();
                CargoTextBox6.Text = cargo.ToString();
                SalarioTextBox9.Text = salario.ToString();
            }
            catch(Exception ex) {
                MessageBox.Show("DIGITE UM USUÁRIO!",
                                "FOLHA SOFT",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

        }

        private void telaPagamentoIncluir_Load(object sender, EventArgs e)
        {

        }
    }
}
