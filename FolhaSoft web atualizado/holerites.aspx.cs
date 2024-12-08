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
    public partial class holerites : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            var connectionSting = ConfigurationManager.ConnectionStrings["projetoPim"].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(connectionSting);
            sqlConn.Open();

            try
            {
                var id = Session["id"];
                
                string query = "SELECT func.nome as nome, func.email as email, func.id_funcionario as codigo, CONVERT(VARCHAR(30),data_pagamento,103) as data, car.descricao_cargo as cargo, pag.id_pagamento as codigo_pagamento, CONCAT('R$ ', CAST(pag.[valor_pagamento] * CASE WHEN pag.[valor_pagamento] >= 0.01 AND pag.[valor_pagamento] < 1320 THEN 0.075 WHEN pag.[valor_pagamento] >= 1320 AND pag.[valor_pagamento] < 2571.29 THEN 0.09 WHEN pag.[valor_pagamento] >= 2571.29 AND pag.[valor_pagamento] < 3856.94 THEN 0.12 WHEN pag.[valor_pagamento] >= 3856.94 THEN 0.14 END AS DECIMAL(10, 2))) as aliquota_inss, CONCAT('R$ ',CAST(pag.[valor_pagamento] * CASE WHEN pag.[valor_pagamento] >= 0.01 AND pag.[valor_pagamento] < 1903.99 THEN 0 WHEN pag.[valor_pagamento] >= 1903.99 AND pag.[valor_pagamento] < 2826.66 THEN 0.075 WHEN pag.[valor_pagamento] >= 2826.66 AND pag.[valor_pagamento] < 3751.05 THEN 0.15 WHEN pag.[valor_pagamento] >= 3751.05 AND pag.[valor_pagamento] < 4664.68 THEN 0.225 WHEN pag.[valor_pagamento] >= 4664.68 THEN 0.275 END - CASE WHEN pag.[valor_pagamento] >= 0.01 AND pag.[valor_pagamento] < 1903.99 THEN 0 WHEN pag.[valor_pagamento] >= 1903.99 AND pag.[valor_pagamento] < 2826.66 THEN 142.80 WHEN pag.[valor_pagamento] >= 2826.66 AND pag.[valor_pagamento] < 3751.05 THEN 354.80 WHEN pag.[valor_pagamento] >= 3751.05 AND pag.[valor_pagamento] < 4664.68 THEN 636.13 WHEN pag.[valor_pagamento] >= 4664.68 THEN 869.36 END AS DECIMAL(10, 2))) as aliquota_irrf, CONCAT('R$ ',des.deducao_irrf) as deducao_irrf, des.id_descontos, CONCAT('R$ ', pag.[valor_pagamento]) as total_vencimentos, CAST( (pag.[valor_pagamento] * CASE WHEN pag.[valor_pagamento] >= 0.01 AND pag.[valor_pagamento] < 1320 THEN 0.075 WHEN pag.[valor_pagamento] >= 1320 AND pag.[valor_pagamento] < 2571.29 THEN 0.09 WHEN pag.[valor_pagamento] >= 2571.29 AND pag.[valor_pagamento] < 3856.94 THEN 0.12 WHEN pag.[valor_pagamento] >= 3856.94 THEN 0.14 END) + (pag.[valor_pagamento] * CASE WHEN pag.[valor_pagamento] >= 0.01 AND pag.[valor_pagamento] < 1903.99 THEN 0 WHEN pag.[valor_pagamento] >= 1903.99 AND pag.[valor_pagamento] < 2826.66 THEN 0.075 WHEN pag.[valor_pagamento] >= 2826.66 AND pag.[valor_pagamento] < 3751.05 THEN 0.15 WHEN pag.[valor_pagamento] >= 3751.05 AND pag.[valor_pagamento] < 4664.68 THEN 0.225 WHEN pag.[valor_pagamento] >= 4664.68 THEN 0.275 END - CASE WHEN pag.[valor_pagamento] >= 0.01 AND pag.[valor_pagamento] < 1903.99 THEN 0 WHEN pag.[valor_pagamento] >= 1903.99 AND pag.[valor_pagamento] < 2826.66 THEN 142.80 WHEN pag.[valor_pagamento] >= 2826.66 AND pag.[valor_pagamento] < 3751.05 THEN 354.80 WHEN pag.[valor_pagamento] >= 3751.05 AND pag.[valor_pagamento] < 4664.68 THEN 636.13 WHEN pag.[valor_pagamento] >= 4664.68 THEN 869.36 END) AS DECIMAL(10, 2)) as [Total Desconto], pag.descricao_evento as evento, CAST(  (pag.[valor_pagamento] -  (pag.[valor_pagamento] * CASE WHEN pag.[valor_pagamento] >= 0.01 AND pag.[valor_pagamento] < 1319.99 THEN 0.075  WHEN pag.[valor_pagamento] >= 1320 AND pag.[valor_pagamento] < 2571.29 THEN 0.09  WHEN pag.[valor_pagamento] >= 2571.30 AND pag.[valor_pagamento] < 3856.94 THEN 0.12  WHEN pag.[valor_pagamento] >= 3856.95 THEN 0.14 END) -  ((pag.[valor_pagamento] * CASE WHEN pag.[valor_pagamento] >= 0.01 AND pag.[valor_pagamento] < 1903.99 THEN 0  WHEN pag.[valor_pagamento] >= 1904 AND pag.[valor_pagamento] < 2826.66 THEN 0.075  WHEN pag.[valor_pagamento] >= 2826.67 AND pag.[valor_pagamento] < 3751.05 THEN 0.15  WHEN pag.[valor_pagamento] >= 3751.06 AND pag.[valor_pagamento] < 4664.68 THEN 0.225  WHEN pag.[valor_pagamento] >= 4664.69 THEN 0.275 END) -  CASE  WHEN pag.[valor_pagamento] >= 0.01 AND pag.[valor_pagamento] < 1903.99 THEN 0  WHEN pag.[valor_pagamento] >= 1904 AND pag.[valor_pagamento] < 2826.66 THEN 142.80  WHEN pag.[valor_pagamento] >= 2826.67 AND pag.[valor_pagamento] < 3751.05 THEN 354.80  WHEN pag.[valor_pagamento] >= 3751.06 AND pag.[valor_pagamento] < 4664.68 THEN 636.13  WHEN pag.[valor_pagamento] >= 4664.68 THEN 869.36 END ) ) AS DECIMAL(10, 2)) as [SALÁRIO LIQUÍDO], pag.faltas AS [FALTAS] FROM [projetoPIM].[dbo].[folha_pagamento] pag LEFT JOIN [projetoPIM].[dbo].[cargos] car ON (pag.id_cargos = car.id_cargos) INNER JOIN [projetoPIM].[dbo].[funcionario] func ON (func.id_funcionario = pag.id_funcionario and func.id_cargos = pag.id_cargos) LEFT JOIN [projetoPIM].[dbo].[descontos] des ON (pag.id_descontos = des.id_descontos) WHERE func.id_funcionario = " + id + " AND MONTH(data_pagamento) = MONTH(GETDATE())";
                SqlCommand command = new SqlCommand(query, sqlConn);
                command.CommandTimeout = 500;
                SqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                nome = dt.Rows[0][0].ToString();
                email = dt.Rows[0][1].ToString();
                codigo_func = dt.Rows[0][2].ToString();
                data = dt.Rows[0][3].ToString();
                cargo = dt.Rows[0][4].ToString();
                codigo_pagamento = dt.Rows[0][5].ToString();
                aliquota_inss = dt.Rows[0][6].ToString();
                aliquota_irrf = dt.Rows[0][7].ToString();
                deducao_irrf = dt.Rows[0][8].ToString();
                total_vencimentos = dt.Rows[0][10].ToString();
                total_descontos = dt.Rows[0][11].ToString();
                referencia = dt.Rows[0][12].ToString();
                total_liquido = dt.Rows[0][13].ToString();
                faltas = dt.Rows[0][14].ToString();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConn.Close();
            }
        }

        public string nome { get; set; }
        public string email { get; set; }
        public string codigo_func { get; set; }
        public string data { get; set; }
        public string cargo { get; set; }
        public string codigo_pagamento { get; set; }
        public string aliquota_inss { get; set; }
        public string aliquota_irrf { get; set; }
        public string deducao_irrf { get; set; }
        public string total_vencimentos { get; set; }
        public string total_descontos { get; set; }
        public string referencia { get; set; }
        public string total_liquido { get; set; }
        public string faltas { get; set; }

    }
}