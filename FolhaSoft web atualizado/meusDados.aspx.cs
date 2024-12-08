using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading;



namespace pimWeb
{
    public partial class meusDados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Session["id"];


            var connectionSting = ConfigurationManager.ConnectionStrings["projetoPim"].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(connectionSting);
            sqlConn.Open();
            string query = "select id_funcionario as matricula,nome as nome, cpf as cpf,rg as rg, email as email, CONVERT(VARCHAR(30),data_nasc,103) as data, sexo as sexo, estado_civil as estado_civil, carteira_trabalho as carteira_trabalho, nis_pis as nis_pis, car.carga_horaria_sem as carga_horaria, car.descricao_cargo as cargo, CONCAT('R$ ',car.salario) as salario from [projetoPim].[dbo].[funcionario] func LEFT JOIN [projetoPim].[dbo].[cargos] car ON func.id_cargos = car.id_cargos WHERE id_funcionario = " + id+"";
            SqlCommand command = new SqlCommand(query, sqlConn);
            command.CommandTimeout = 500;
            SqlDataReader reader = command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);

            matricula = dt.Rows[0][0].ToString();
            nome = dt.Rows[0][1].ToString();
            cpf = dt.Rows[0][2].ToString();
            rg = dt.Rows[0][3].ToString();
            email = Session["email"].ToString();
            data_nascimento = dt.Rows[0][5].ToString();
            sexo = dt.Rows[0][6].ToString();
            estado_civil = dt.Rows[0][7].ToString();
            carteira_trabalho = dt.Rows[0][8].ToString();
            nis_pis = dt.Rows[0][9].ToString();
            carga_horaria = dt.Rows[0][10].ToString() + "Horas";
            cargo = dt.Rows[0][11].ToString();
            salario = dt.Rows[0][12].ToString();

            //string JSON = JsonConvert.SerializeObject(dt);
            //json = JSON;

            sqlConn.Close();
        }

        public string matricula { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public string rg { get; set; }
        public string email { get; set; }
        public string data_nascimento { get; set; }
        public string sexo { get; set; }
        public string estado_civil { get; set; }
        public string carteira_trabalho { get; set; }
        public string nis_pis { get; set; }
        public string carga_horaria { get; set; }
        public string cargo { get; set; }
        public string salario { get; set; }

    }
}