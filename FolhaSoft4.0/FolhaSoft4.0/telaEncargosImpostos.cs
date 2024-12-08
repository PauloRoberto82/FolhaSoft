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
    public partial class telaEncargosImpostos : Form
    {
        public telaEncargosImpostos()
        {
            InitializeComponent();
        }

        private void telaEncargosImpostos_Load(object sender, EventArgs e)
        {
            string query = "SELECT [salario_minimo] FROM [projetoPIM].[dbo].[descontos]";
            var connectionString = ConfigurationManager.ConnectionStrings["FSConnectionString"].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(connectionString);
            sqlConn.Open();
            SqlCommand cmd = new SqlCommand(query, sqlConn);
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            var salario_minimo = dt.Rows[0][0];
            maskedTextBox1.Text = salario_minimo.ToString();
            sqlConn.Close();


        }

        private void Voltarbutton_Click(object sender, EventArgs e)
        {
            var Voltarbutton = new telaInicio();
            Voltarbutton.Show();
            this.Visible = false;
        }

    }
}
