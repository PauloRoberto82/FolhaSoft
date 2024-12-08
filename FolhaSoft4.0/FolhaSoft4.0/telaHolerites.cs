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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace projetoPim
{
    public partial class telaHolerites : Form
    {
        public telaHolerites()
        {
            InitializeComponent();
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["FSConnectionString"].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            try
            {
                //MES
                string query_mes = "SELECT TOP(1) CONVERT(NVARCHAR(10), pag.data_pagamento, 103) FROM dbo.folha_pagamento pag LEFT JOIN dbo.funcionario fun ON (pag.id_funcionario = fun.id_funcionario) LEFT JOIN dbo.descontos des ON (pag.id_descontos = des.id_descontos) LEFT JOIN dbo.cargos car ON (fun.id_cargos = car.id_cargos) WHERE fun.email = '" + buscarNome.Text.ToString() + "' AND MONTH(pag.data_pagamento) = " + comboBox1.SelectedValue + "";
                SqlCommand cmd_mes = new SqlCommand(query_mes, sqlConn);
                SqlDataAdapter dataAdapter_mes = new SqlDataAdapter();
                dataAdapter_mes.SelectCommand = cmd_mes;
                DataTable dt_mes = new DataTable();
                dataAdapter_mes.Fill(dt_mes);
                var mes = dt_mes.Rows[0][0];
                MesAno.Text = mes.ToString();

                //NOME
                string query_nome = "SELECT TOP(1) fun.nome FROM dbo.folha_pagamento pag LEFT JOIN dbo.funcionario fun ON (pag.id_funcionario = fun.id_funcionario) LEFT JOIN dbo.descontos des ON (pag.id_descontos = des.id_descontos) LEFT JOIN dbo.cargos car ON (fun.id_cargos = car.id_cargos) WHERE fun.email = '" + buscarNome.Text.ToString() + "' AND MONTH(pag.data_pagamento) = " + comboBox1.SelectedValue + "";
                SqlCommand cmd_nome = new SqlCommand(query_nome, sqlConn);
                SqlDataAdapter dataAdapter_nome = new SqlDataAdapter();
                dataAdapter_nome.SelectCommand = cmd_nome;
                DataTable dt_nome = new DataTable();
                dataAdapter_nome.Fill(dt_nome);
                var nome = dt_nome.Rows[0][0];
                Nome.Text = nome.ToString();


                //CARGO
                string query_cargo = "SELECT TOP(1) car.descricao_cargo FROM dbo.folha_pagamento pag LEFT JOIN dbo.funcionario fun ON (pag.id_funcionario = fun.id_funcionario) LEFT JOIN dbo.descontos des ON (pag.id_descontos = des.id_descontos) LEFT JOIN dbo.cargos car ON (fun.id_cargos = car.id_cargos) WHERE fun.email = '" + buscarNome.Text.ToString() + "' AND MONTH(pag.data_pagamento) = " + comboBox1.SelectedValue + "";
                SqlCommand cmd_cargo = new SqlCommand(query_cargo, sqlConn);
                SqlDataAdapter dataAdapter_cargo = new SqlDataAdapter();
                dataAdapter_cargo.SelectCommand = cmd_cargo;
                DataTable dt_cargo = new DataTable();
                dataAdapter_cargo.Fill(dt_cargo);
                var cargo = dt_cargo.Rows[0][0];
                Cargo.Text = cargo.ToString();


                //ID
                string query_id = "SELECT TOP(1) fun.id_funcionario FROM dbo.folha_pagamento pag LEFT JOIN dbo.funcionario fun ON (pag.id_funcionario = fun.id_funcionario) LEFT JOIN dbo.descontos des ON (pag.id_descontos = des.id_descontos) LEFT JOIN dbo.cargos car ON (fun.id_cargos = car.id_cargos) WHERE fun.email = '" + buscarNome.Text.ToString() + "' AND MONTH(pag.data_pagamento) = " + comboBox1.SelectedValue + "";
                SqlCommand cmd_id = new SqlCommand(query_id, sqlConn);
                SqlDataAdapter dataAdapter_id = new SqlDataAdapter();
                dataAdapter_id.SelectCommand = cmd_id;
                DataTable dt_id = new DataTable();
                dataAdapter_id.Fill(dt_id);
                var id = dt_id.Rows[0][0];
                Codigo.Text = id.ToString();


                //TOTAL LIQUIDO
                string query_liquido = "SELECT TOP(1) CAST(  (pag.[valor_pagamento] -  (pag.[valor_pagamento] * CASE WHEN pag.[valor_pagamento] >= 0.01 AND pag.[valor_pagamento] < 1319.99 THEN 0.075  WHEN pag.[valor_pagamento] >= 1320 AND pag.[valor_pagamento] < 2571.29 THEN 0.09  WHEN pag.[valor_pagamento] >= 2571.30 AND pag.[valor_pagamento] < 3856.94 THEN 0.12  WHEN pag.[valor_pagamento] >= 3856.95 THEN 0.14 END) -  ((pag.[valor_pagamento] * CASE WHEN pag.[valor_pagamento] >= 0.01 AND pag.[valor_pagamento] < 1903.99 THEN 0  WHEN pag.[valor_pagamento] >= 1904 AND pag.[valor_pagamento] < 2826.66 THEN 0.075  WHEN pag.[valor_pagamento] >= 2826.67 AND pag.[valor_pagamento] < 3751.05 THEN 0.15  WHEN pag.[valor_pagamento] >= 3751.06 AND pag.[valor_pagamento] < 4664.68 THEN 0.225  WHEN pag.[valor_pagamento] >= 4664.69 THEN 0.275 END) -  CASE  WHEN pag.[valor_pagamento] >= 0.01 AND pag.[valor_pagamento] < 1903.99 THEN 0  WHEN pag.[valor_pagamento] >= 1904 AND pag.[valor_pagamento] < 2826.66 THEN 142.80  WHEN pag.[valor_pagamento] >= 2826.67 AND pag.[valor_pagamento] < 3751.05 THEN 354.80  WHEN pag.[valor_pagamento] >= 3751.06 AND pag.[valor_pagamento] < 4664.68 THEN 636.13  WHEN pag.[valor_pagamento] >= 4664.68 THEN 869.36 END ) ) AS DECIMAL(10, 2)) as [SALÁRIO LIQUÍDO] FROM dbo.folha_pagamento pag LEFT JOIN dbo.funcionario fun ON (pag.id_funcionario = fun.id_funcionario) LEFT JOIN dbo.descontos des ON (pag.id_descontos = des.id_descontos) LEFT JOIN dbo.cargos car ON (fun.id_cargos = car.id_cargos) WHERE fun.email = '" + buscarNome.Text.ToString() + "' AND MONTH(pag.data_pagamento) = " + comboBox1.SelectedValue + "";
                SqlCommand cmd_liquido = new SqlCommand(query_liquido, sqlConn);
                SqlDataAdapter dataAdapter_liquido = new SqlDataAdapter();
                dataAdapter_liquido.SelectCommand = cmd_liquido;
                DataTable dt_liquido = new DataTable();
                dataAdapter_liquido.Fill(dt_liquido);
                var liquido = dt_liquido.Rows[0][0];
                TotalLiquido.Text = liquido.ToString();



                //TOTAL DESCONTOS
                string query_descontos = "SELECT TOP(1) CAST( (pag.[valor_pagamento] * CASE WHEN pag.[valor_pagamento] >= 0.01 AND pag.[valor_pagamento] < 1320 THEN 0.075 WHEN pag.[valor_pagamento] >= 1320 AND pag.[valor_pagamento] < 2571.29 THEN 0.09 WHEN pag.[valor_pagamento] >= 2571.29 AND pag.[valor_pagamento] < 3856.94 THEN 0.12 WHEN pag.[valor_pagamento] >= 3856.94 THEN 0.14 END) + (pag.[valor_pagamento] * CASE WHEN pag.[valor_pagamento] >= 0.01 AND pag.[valor_pagamento] < 1903.99 THEN 0 WHEN pag.[valor_pagamento] >= 1903.99 AND pag.[valor_pagamento] < 2826.66 THEN 0.075 WHEN pag.[valor_pagamento] >= 2826.66 AND pag.[valor_pagamento] < 3751.05 THEN 0.15 WHEN pag.[valor_pagamento] >= 3751.05 AND pag.[valor_pagamento] < 4664.68 THEN 0.225 WHEN pag.[valor_pagamento] >= 4664.68 THEN 0.275 END - CASE WHEN pag.[valor_pagamento] >= 0.01 AND pag.[valor_pagamento] < 1903.99 THEN 0 WHEN pag.[valor_pagamento] >= 1903.99 AND pag.[valor_pagamento] < 2826.66 THEN 142.80 WHEN pag.[valor_pagamento] >= 2826.66 AND pag.[valor_pagamento] < 3751.05 THEN 354.80 WHEN pag.[valor_pagamento] >= 3751.05 AND pag.[valor_pagamento] < 4664.68 THEN 636.13 WHEN pag.[valor_pagamento] >= 4664.68 THEN 869.36 END) AS DECIMAL(10, 2)) as [Total Desconto] FROM dbo.folha_pagamento pag LEFT JOIN dbo.funcionario fun ON (pag.id_funcionario = fun.id_funcionario) LEFT JOIN dbo.descontos des ON (pag.id_descontos = des.id_descontos) LEFT JOIN dbo.cargos car ON (fun.id_cargos = car.id_cargos) WHERE fun.email = '" + buscarNome.Text.ToString() + "' AND MONTH(pag.data_pagamento) = " + comboBox1.SelectedValue + "";
                SqlCommand cmd_descontos = new SqlCommand(query_descontos, sqlConn);
                SqlDataAdapter dataAdapter_descontos = new SqlDataAdapter();
                dataAdapter_descontos.SelectCommand = cmd_descontos;
                DataTable dt_descontos = new DataTable();
                dataAdapter_descontos.Fill(dt_descontos);
                var descontos = dt_descontos.Rows[0][0];
                TotalDesconto.Text = descontos.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,
                                "Aviso",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            

            
            try
            {
                string query = "SELECT pag.id_pagamento as ID, pag.descricao_evento as DESCRIÇÃO, fun.nome as NOME, pag.[valor_pagamento] as SALÁRIO, CAST(pag.[valor_pagamento] * CASE WHEN pag.[valor_pagamento] >= 0.01 AND pag.[valor_pagamento] < 1320 THEN 0.075 WHEN pag.[valor_pagamento] >= 1320 AND pag.[valor_pagamento] < 2571.29 THEN 0.09 WHEN pag.[valor_pagamento] >= 2571.29 AND pag.[valor_pagamento] < 3856.94 THEN 0.12 WHEN pag.[valor_pagamento] >= 3856.94 THEN 0.14 END AS DECIMAL(10, 2)) as [INSS], CAST(pag.[valor_pagamento] * CASE WHEN pag.[valor_pagamento] >= 0.01 AND pag.[valor_pagamento] < 1903.99 THEN 0 WHEN pag.[valor_pagamento] >= 1903.99 AND pag.[valor_pagamento] < 2826.66 THEN 0.075 WHEN pag.[valor_pagamento] >= 2826.66 AND pag.[valor_pagamento] < 3751.05 THEN 0.15 WHEN pag.[valor_pagamento] >= 3751.05 AND pag.[valor_pagamento] < 4664.68 THEN 0.225 WHEN pag.[valor_pagamento] >= 4664.68 THEN 0.275 END - CASE WHEN pag.[valor_pagamento] >= 0.01 AND pag.[valor_pagamento] < 1903.99 THEN 0 WHEN pag.[valor_pagamento] >= 1903.99 AND pag.[valor_pagamento] < 2826.66 THEN 142.80 WHEN pag.[valor_pagamento] >= 2826.66 AND pag.[valor_pagamento] < 3751.05 THEN 354.80 WHEN pag.[valor_pagamento] >= 3751.05 AND pag.[valor_pagamento] < 4664.68 THEN 636.13 WHEN pag.[valor_pagamento] >= 4664.68 THEN 869.36 END AS DECIMAL(10, 2)) as [IRFF], pag.faltas AS [FALTAS] FROM dbo.folha_pagamento pag LEFT JOIN dbo.funcionario fun ON (pag.id_funcionario = fun.id_funcionario) LEFT JOIN dbo.descontos des ON (pag.id_descontos = des.id_descontos) LEFT JOIN dbo.cargos car ON (fun.id_cargos = car.id_cargos) WHERE fun.email = '" + buscarNome.Text.ToString() + "' AND MONTH(pag.data_pagamento) = " + comboBox1.SelectedValue + "";
                SqlCommand cmd = new SqlCommand(query, sqlConn);
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = cmd;
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                // Preencha o DataGridView com o DataTable
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.RowHeadersVisible = false;
                sqlConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("DIGITE UM USUÁRIO!",
                                "Aviso",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

        }

        private void telaHolerites_Load(object sender, EventArgs e)
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

            //// Defina o DataSource do ComboBox.
            comboBox2.DataSource = dt;

            // Defina o ValueMember e o DisplayMember.
            comboBox2.ValueMember = "Ano";     // Coluna para valores.
            comboBox2.DisplayMember = "Ano";    // Coluna para exibição.



            // Databind para associar os dados.
            //comboBox1.DataBind();
        }

        private void Voltarbutton_Click(object sender, EventArgs e)
        {
            // abre o a página do menu.
            var inicio = new telaInicio();
            inicio.Show();
            this.Visible = false;
        }
    }
}
