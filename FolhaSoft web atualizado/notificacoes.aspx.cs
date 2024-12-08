using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pimWeb
{
    public partial class notificacoes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Session["id"];

            var connectionSting = ConfigurationManager.ConnectionStrings["projetoPIM"].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(connectionSting);
            sqlConn.Open();
            //query para consultar nome
            string query = "SELECT func.nome as NOME, CONVERT(VARCHAR(30),pag.[data_pagamento], 103) AS DATA,pag.[descricao_evento] AS EVENTO,pag.[situacao] AS SITUAÇÃO,car.descricao_cargo AS CARGO FROM [projetoPim].[dbo].[folha_pagamento] pag LEFT JOIN [projetoPim].[dbo].[cargos] car ON (pag.id_cargos = car.id_cargos) INNER JOIN [projetoPIM].[dbo].[funcionario] func ON (func.id_funcionario = pag.id_funcionario and func.id_cargos = pag.id_cargos) WHERE func.id_funcionario = "+id+" AND pag.data_pagamento < GETDATE() ORDER BY pag.data_pagamento";
            SqlCommand command_nome = new SqlCommand(query, sqlConn);
            SqlDataReader reader = command_nome.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            sqlConn.Close();

            notificacao.DataSource = dt;
            //this.notificacao.DefaultCellStyle.ForeColor = Color.Blue;
            //this.notificacao.DefaultCellStyle.BackColor = Color.Beige;
            notificacao.DataBind();
        }
    }
}