using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pimWeb
{
    public partial class fale : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Session["id"];
            var connectionSting = ConfigurationManager.ConnectionStrings["projetoPim"].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(connectionSting);
            sqlConn.Open();
            string query = "select nome as nome, email as email from [projetoPim].[dbo].[funcionario] WHERE id_funcionario = " + id + "";
            SqlCommand command = new SqlCommand(query, sqlConn);
            command.CommandTimeout = 500;
            SqlDataReader reader = command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);

            nome = dt.Rows[0][0].ToString();
            email = dt.Rows[0][1].ToString();
            sqlConn.Close();
        }
       
       

        public string nome { get; set; }
        public string email { get; set; }
    }
}