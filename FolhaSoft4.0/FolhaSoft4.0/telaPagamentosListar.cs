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

namespace projetoPim
{
    public partial class telaPagamentoListar : Form
    {
        public telaPagamentoListar()
        {
            InitializeComponent();
        }

        private void telaPagamentoListar_Load(object sender, EventArgs e)
        {
            // Exemplo de um DataTable como fonte de dados.
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("id_mes", typeof(int));
            dataTable.Columns.Add("mes", typeof(string));

            // Preencha o DataTable com dados de exemplo.
            dataTable.Rows.Add(0, "TODOS");
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

            string where_func = "";
            string where_month = "";

            if (códigoFuncTextBox1.Text == "Todos")
            {
                where_func = "";
            }
            else
            {
                where_func = " AND fun.email = '" + códigoFuncTextBox1.Text + "'";
            }

            if (comboBox1.SelectedValue.Equals(0))
            {
                where_month = "";
            }
            else
            {
                where_month = " AND MONTH(data_pagamento) = " + comboBox1.SelectedValue + "";
            }

            string where = "WHERE YEAR(data_pagamento)=" + comboBox2.SelectedValue.ToString() + "" + where_func + where_month;

            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["FSConnectionString"].ConnectionString;
                SqlConnection sqlConn = new SqlConnection(connectionString);
                sqlConn.Open();

                //teto gerente
                string query = "SELECT fun.id_funcionario as [CÓD], fun.nome as [NOME], car.descricao_cargo as [CARGO], CAST(pag.[valor_pagamento] AS DECIMAL(10, 2)) as [SALÁRIO], CAST(pag.[valor_pagamento] * CASE WHEN pag.[valor_pagamento] >= 0.01 AND pag.[valor_pagamento] < 1320 THEN 0.075 WHEN pag.[valor_pagamento] >= 1320.01 AND pag.[valor_pagamento] < 2571.29 THEN 0.09 WHEN pag.[valor_pagamento] >= 2571.30 AND pag.[valor_pagamento] < 3856.94 THEN 0.12 WHEN pag.[valor_pagamento] >= 3856.95 THEN 0.14 END AS DECIMAL(10, 2)) as [INSS], CAST(pag.[valor_pagamento] * CASE WHEN pag.[valor_pagamento] >= 0.01 AND pag.[valor_pagamento] < 1903.99 THEN 0 WHEN pag.[valor_pagamento] >= 1904 AND pag.[valor_pagamento] < 2826.66 THEN 0.075 WHEN pag.[valor_pagamento] >= 2826.67 AND pag.[valor_pagamento] < 3751.05 THEN 0.15 WHEN pag.[valor_pagamento] >= 3751.06 AND pag.[valor_pagamento] < 4664.68 THEN 0.225 WHEN pag.[valor_pagamento] >= 4664.69 THEN 0.275 END - CASE WHEN pag.[valor_pagamento] >= 0.01 AND pag.[valor_pagamento] < 1903.99 THEN 0 WHEN pag.[valor_pagamento] >= 1904 AND pag.[valor_pagamento] < 2826.66 THEN 142.80 WHEN pag.[valor_pagamento] >= 2826.67 AND pag.[valor_pagamento] < 3751.05 THEN 354.80 WHEN pag.[valor_pagamento] >= 3751.06 AND pag.[valor_pagamento] < 4664.68 THEN 636.13 WHEN pag.[valor_pagamento] >= 4664.69 THEN 869.36 END AS DECIMAL(10, 2)) as [IRRF], CAST( (pag.[valor_pagamento] - (pag.[valor_pagamento] * CASE WHEN pag.[valor_pagamento] >= 0.01 AND pag.[valor_pagamento] < 1319.99 THEN 0.075 WHEN pag.[valor_pagamento] >= 1320 AND pag.[valor_pagamento] < 2571.29 THEN 0.09 WHEN pag.[valor_pagamento] >= 2571.30 AND pag.[valor_pagamento] < 3856.94 THEN 0.12 WHEN pag.[valor_pagamento] >= 3856.95 THEN 0.14 END) - ((pag.[valor_pagamento] * CASE WHEN pag.[valor_pagamento] >= 0.01 AND pag.[valor_pagamento] < 1903.99 THEN 0 WHEN pag.[valor_pagamento] >= 1904 AND pag.[valor_pagamento] < 2826.66 THEN 0.075 WHEN pag.[valor_pagamento] >= 2826.67 AND pag.[valor_pagamento] < 3751.05 THEN 0.15 WHEN pag.[valor_pagamento] >= 3751.06 AND pag.[valor_pagamento] < 4664.68 THEN 0.225 WHEN pag.[valor_pagamento] >= 4664.69 THEN 0.275 END) - CASE WHEN pag.[valor_pagamento] >= 0.01 AND pag.[valor_pagamento] < 1903.99 THEN 0 WHEN pag.[valor_pagamento] >= 1904 AND pag.[valor_pagamento] < 2826.66 THEN 142.80 WHEN pag.[valor_pagamento] >= 2826.67 AND pag.[valor_pagamento] < 3751.05 THEN 354.80 WHEN pag.[valor_pagamento] >= 3751.06 AND pag.[valor_pagamento] < 4664.68 THEN 636.13 WHEN pag.[valor_pagamento] >= 4664.68 THEN 869.36 END ) ) AS DECIMAL(10, 2)) as [SALÁRIO LIQUÍDO], pag.data_pagamento as [DATA] FROM [projetoPIM].[dbo].[folha_pagamento] pag LEFT JOIN [dbo].[descontos] des ON (des.id_descontos = pag.id_descontos) LEFT JOIN [dbo].[funcionario] fun ON (fun.id_funcionario = pag.id_funcionario) LEFT JOIN [dbo].[cargos] car ON (fun.id_cargos = car.id_cargos) " + where;
                SqlCommand cmd = new SqlCommand(query, sqlConn);
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                // Preencha o DataGridView com o DataTable
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                sqlConn.Close();
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
                var connectionString = ConfigurationManager.ConnectionStrings["FSConnectionString"].ConnectionString;
                SqlConnection sqlConn = new SqlConnection(connectionString);
                sqlConn.Open();

                //teto gerente
                string query_totais = "SELECT CAST(SUM(TB.[Valor Inss]) AS DECIMAL(10, 2)) as inss, CAST(SUM(TB.[Valor Irrf]) AS DECIMAL(10, 2)) as irrf, CAST(SUM([Salário Líquido]) AS DECIMAL(10, 2)) as total FROM( SELECT fun.id_funcionario as [Código], fun.nome as [Nome], car.descricao_cargo as [Cargo], 'Ativo' as [Situação], CAST(pag.[valor_pagamento] AS DECIMAL(10, 2)) as [Salário], CAST(pag.[valor_pagamento] * CASE WHEN pag.[valor_pagamento] >= 0.01 AND pag.[valor_pagamento] < 1320 THEN 0.075 WHEN pag.[valor_pagamento] >= 1320 AND pag.[valor_pagamento] < 2571.29 THEN 0.09 WHEN pag.[valor_pagamento] >= 2571.29 AND pag.[valor_pagamento] < 3856.94 THEN 0.12 WHEN pag.[valor_pagamento] >= 3856.94 THEN 0.14 END AS DECIMAL(10, 2)) as [Valor Inss], CAST(pag.[valor_pagamento] * CASE WHEN pag.[valor_pagamento] >= 0.01 AND pag.[valor_pagamento] < 1903.99 THEN 0 WHEN pag.[valor_pagamento] >= 1903.99 AND pag.[valor_pagamento] < 2826.66 THEN 0.075 WHEN pag.[valor_pagamento] >= 2826.66 AND pag.[valor_pagamento] < 3751.05 THEN 0.15 WHEN pag.[valor_pagamento] >= 3751.05 AND pag.[valor_pagamento] < 4664.68 THEN 0.225 WHEN pag.[valor_pagamento] >= 4664.68 THEN 0.275 END - CASE WHEN pag.[valor_pagamento] >= 0.01 AND pag.[valor_pagamento] < 1903.99 THEN 0 WHEN pag.[valor_pagamento] >= 1903.99 AND pag.[valor_pagamento] < 2826.66 THEN 142.80 WHEN pag.[valor_pagamento] >= 2826.66 AND pag.[valor_pagamento] < 3751.05 THEN 354.80 WHEN pag.[valor_pagamento] >= 3751.05 AND pag.[valor_pagamento] < 4664.68 THEN 636.13 WHEN pag.[valor_pagamento] >= 4664.68 THEN 869.36 END AS DECIMAL(10, 2)) as [Valor Irrf], CAST( (pag.[valor_pagamento] - (pag.[valor_pagamento] * CASE WHEN pag.[valor_pagamento] >= 0.01 AND pag.[valor_pagamento] < 1320 THEN 0.075 WHEN pag.[valor_pagamento] >= 1320 AND pag.[valor_pagamento] < 2571.29 THEN 0.09 WHEN pag.[valor_pagamento] >= 2571.29 AND pag.[valor_pagamento] < 3856.94 THEN 0.12 WHEN pag.[valor_pagamento] >= 3856.94 THEN 0.14 END ) + (CASE WHEN pag.[valor_pagamento] >= 0.01 AND pag.[valor_pagamento] < 1903.99 THEN 0 WHEN pag.[valor_pagamento] >= 1903.99 AND pag.[valor_pagamento] < 2826.66 THEN 0.075 WHEN pag.[valor_pagamento] >= 2826.66 AND pag.[valor_pagamento] < 3751.05 THEN 0.15 WHEN pag.[valor_pagamento] >= 3751.05 AND pag.[valor_pagamento] < 4664.68 THEN 0.225 WHEN pag.[valor_pagamento] >= 4664.68 THEN 0.275 END - CASE WHEN pag.[valor_pagamento] >= 0.01 AND pag.[valor_pagamento] < 1903.99 THEN 0 WHEN pag.[valor_pagamento] >= 1903.99 AND pag.[valor_pagamento] < 2826.66 THEN 142.80 WHEN pag.[valor_pagamento] >= 2826.66 AND pag.[valor_pagamento] < 3751.05 THEN 354.80 WHEN pag.[valor_pagamento] >= 3751.05 AND pag.[valor_pagamento] < 4664.68 THEN 636.13 WHEN pag.[valor_pagamento] >= 4664.68 THEN 869.36 END ) ) AS DECIMAL(10, 2)) as [Salário Líquido], pag.data_pagamento as [Data pagamento] FROM [projetoPIM].[dbo].[folha_pagamento] pag LEFT JOIN [dbo].[descontos] des ON (des.id_descontos = pag.id_descontos) LEFT JOIN [dbo].[funcionario] fun ON (fun.id_funcionario = pag.id_funcionario) LEFT JOIN [dbo].[cargos] car ON (fun.id_cargos = car.id_cargos) " + where + ")TB";
                SqlCommand cmd_totais = new SqlCommand(query_totais, sqlConn);
                SqlDataAdapter dataAdapter_totais = new SqlDataAdapter();
                dataAdapter_totais.SelectCommand = cmd_totais;
                DataTable dt_totais = new DataTable();
                dataAdapter_totais.Fill(dt_totais);

                sqlConn.Close();

                var INSS = dt_totais.Rows[0][0];
                TotalDesconto.Text = INSS.ToString();

                var IRRF = dt_totais.Rows[0][1];
                textBox2.Text = IRRF.ToString();

                var TOTAL = dt_totais.Rows[0][2];
                TotalLiquido.Text = TOTAL.ToString();



                
                //Soma dos valores de: INSS / IRRF / TOTAL
                double soma = 0.0;

                if (INSS != DBNull.Value && IRRF != DBNull.Value && TOTAL != DBNull.Value)
                {
                    double valorINSS, valorIRRF, valorTotal;

                    if (double.TryParse(INSS.ToString(), out valorINSS) &&
                        double.TryParse(IRRF.ToString(), out valorIRRF) &&
                        double.TryParse(TOTAL.ToString(), out valorTotal))
                    {
                        soma = valorINSS + valorIRRF + valorTotal;
                    }
                }

                textBox4.Text = soma.ToString();







            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                "Aviso",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }


        private void Voltarbutton_Click(object sender, EventArgs e)
        {
            var Voltarbutton = new telaFolhaPagamento();
            Voltarbutton.Show();
            this.Visible = false;
        }

        
              
           
           




        
    }
}

