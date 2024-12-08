using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Configuration;
using System.Data.SqlClient;

namespace projetoPim
{
    public partial class telaLogin : Form
    {
        public telaLogin()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                // trecho de código para conectar no bd e dar um select pesquisando o usuário e senha referentes e confirmando se o retorno é positivo
                // executa o select
                // se nao existir retorno, diz que o usuário está incorreto, se existir compara a senha e diga que a senha está incorreta

                email = txtUsername.Text;

                
                var connectionString = ConfigurationManager.ConnectionStrings["FSConnectionString"].ConnectionString;
                SqlConnection sqlConn = new SqlConnection(connectionString);
                sqlConn.Open();

                

                if (email == "admin")
                {
                    if (email == "admin" && txtPassword.Text == "admin")
                    {
                        // abre o a página do menu.
                        var menu = new telaInicio();
                        menu.Show();
                        this.Visible = false;
                    }
                }
                else
                {
                    string query = "select distinct senha from funcionario where email = '" + email + "'";
                    SqlCommand cmd = new SqlCommand(query, sqlConn);
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    dataAdapter.Fill(dt);
                    var variavel = dt.Rows[0][0];
                    sqlConn.Close();

                    if (txtPassword.Text == variavel.ToString())
                    {
                        // abre o a página do menu.
                        var menu = new telaInicio();
                        menu.Show();
                        this.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Usuário ou senha incorretos",
                                        "Aviso",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                        txtUsername.Focus();
                        txtPassword.Text = "";
                    }
                }
            } 
            catch (Exception ex)
            {
                MessageBox.Show("Usuário ou senha incorretos!",
                                "Aviso",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void telaLogin_Load(object sender, EventArgs e)
        {

        }

        public string email { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
