using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.DynamicData;

namespace pimWeb
{
    public partial class index : System.Web.UI.Page
    { 

        protected void Page_Load(object sender, EventArgs e)
        {
            string email = Session["email"].ToString();
            var connectionSting = ConfigurationManager.ConnectionStrings["projetoPim"].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(connectionSting);
            sqlConn.Open();
            //query para consultar nome
            string query_nome = "SELECT TOP(1) nome FROM [projetoPIM].[dbo].[funcionario] WHERE email = '"+email+"'";
            SqlCommand command_nome = new SqlCommand(query_nome, sqlConn);
            SqlDataReader reader_nome = command_nome.ExecuteReader();
            DataTable dt_nome = new DataTable();
            dt_nome.Load(reader_nome);

            //query para consultar id_funcionario
            string query_id = "SELECT TOP(1) id_funcionario FROM [projetoPIM].[dbo].[funcionario] WHERE email = '" + email + "'";
            SqlCommand command_id = new SqlCommand(query_id, sqlConn);
            SqlDataReader reader_id = command_id.ExecuteReader();
            DataTable dt_id = new DataTable();
            dt_id.Load(reader_id);
            Session["id"] = dt_id.Rows[0][0];


            sqlConn.Close();
            usuario = dt_nome.Rows[0][0].ToString();
        }

        public string usuario { get; set; }

    }
}