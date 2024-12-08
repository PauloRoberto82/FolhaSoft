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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            var connectionSting = ConfigurationManager.ConnectionStrings["projetoPim"].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(connectionSting);
            sqlConn.Open();
            string query = "SELECT TOP(1) senha FROM [projetoPim].[dbo].[funcionario] WHERE email = '"+email.Value.ToString()+"'";
            SqlCommand command = new SqlCommand(query, sqlConn);
            SqlDataReader reader = command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            sqlConn.Close();
            try
            {
                string senha_correta = dt.Rows[0][0].ToString();
                if (senha.Value.ToString() == senha_correta)
                {
                    Session["email"] = email.Value.ToString();
                    Response.Redirect("/index.aspx");
                }
                else
                {
                    string script = "alert('E-mail ou senha incorretos! Digite novamente');";
                    ClientScript.RegisterStartupScript(this.GetType(), "ExibirAlerta", script, true);
                }
            }
            catch (Exception ex)
            {
                string script = "alert('Insira um e-mail');";
                ClientScript.RegisterStartupScript(this.GetType(), "ExibirAlerta", script, true);
            }           
            
        }
    }
}