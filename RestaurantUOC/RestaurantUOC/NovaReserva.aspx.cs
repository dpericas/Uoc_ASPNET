using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlServerCe;
using System.Diagnostics;

namespace RestaurantUOC
{
    public partial class NovaReserva : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var id = 0;
            if (Request.QueryString["id"] != null)  id= int.Parse(Request.QueryString["id"]);
            if (id != 0) titleh.Text = "Modifica Reserva Num."+id;
            BuidFormReserva(id);
        }
        protected void BuidFormReserva(int resID)
        {
            if (resID != 0)
            {
                SqlCeConnection linksql = new SqlCeConnection(@"Data Source='C:\Users\Uoc\Documents\GitHub\Uoc_ASPNET\restaurantuoc.sdf';Password='uoc'");
                linksql.Open();
                SqlCeCommand sqlQuery = new SqlCeCommand("SELECT * FROM reserves WHERE id=" + resID, linksql);
                SqlCeDataReader resultSql = sqlQuery.ExecuteReader();
                while (resultSql.Read())
                {
                    nomForm.Text = resultSql["Nom"].ToString();
                    //string Nom = resultSql["Nom"].ToString();
                    cognomForm.Text = resultSql["Cognoms"].ToString();
                    //string Cognoms = resultSql["Cognoms"].ToString();
                    telForm.Text = resultSql["Telefon"].ToString();
                    //string Telefon = resultSql["Telefon"].ToString();
                    string Data = resultSql["Data"].ToString();
                    comensalForm.Text = resultSql["Comensals"].ToString();
                    //int Comensals = int.Parse(resultSql["Comensals"].ToString());
                    comentForm.Text = resultSql["Comentaris"].ToString();
                    //string Comentaris = resultSql["Comentaris"].ToString();
                }
                linksql.Close();
            }
        }
    }
}