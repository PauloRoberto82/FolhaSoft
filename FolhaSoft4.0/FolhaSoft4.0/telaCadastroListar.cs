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
    public partial class telaCadastroListar : Form
    {
        public telaCadastroListar()
        {
            InitializeComponent();
        }

        private void principalTitle_Click(object sender, EventArgs e)
        {

        }

        private void telaCadastroListar_Load(object sender, EventArgs e)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["FSConnectionString"].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();

            //teto gerente
            string query = "SELECT * FROM [projetoPIM].[dbo].[funcionario] func LEFT JOIN [projetoPIM].[dbo].[cargos] cg on (func.id_cargos = cg.id_cargos)";
            SqlCommand cmd = new SqlCommand(query, sqlConn);
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            // Preencha o DataGridView com o DataTable
            dataGridView1.DataSource = dt;
            sqlConn.Close();
        }

        private void Voltarbutton_Click(object sender, EventArgs e)
        {
            var Voltarbutton = new telaCadastro();
            Voltarbutton.Show();
            this.Visible = false;
        }
    }
}
