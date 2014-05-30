using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlServerCe;

namespace RestaurantUOC
{
    public partial class LlistaReserves : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            searchReserves(null, 0, null);
        }

        void searchReserves(string valAction, int idData, string postData)
        {
            SqlCeConnection linksql = new SqlCeConnection(@"Data Source='C:\Users\Uoc\Documents\GitHub\Uoc_ASPNET\restaurantuoc.sdf';Password='uoc'");
            linksql.Open();
            SqlCeCommand sqlQuery = new SqlCeCommand("SELECT * FROM reserves", linksql);
            SqlCeDataReader resultSql = sqlQuery.ExecuteReader();
            if (resultSql != null)
            {
                updatableContent.InnerHtml = "<table id=\"tableReservasA\"><tr bgcolor=\"#A4A4A4\"><td><strong>Nom</strong></td><td><strong>Cognoms</strong></td><td><strong>Telefon</strong></td><td><strong>Data</strong></td><td><strong>Comensals</strong></td></tr></table>";
                Table tableReservas = new Table();
                tableReservas.ID = "tableReservas";
                while (resultSql.Read())
                {
                    TableRow rowReservas = new TableRow();
                    TableCell nomReservas = new TableCell();
                    nomReservas.Text = resultSql["Nom"].ToString();
                    TableCell cognomsReservas = new TableCell();
                    cognomsReservas.Text = resultSql["Cognoms"].ToString();
                    TableCell telfReservas = new TableCell();
                    telfReservas.Text = resultSql["Telefon"].ToString();
                    TableCell dataReservas = new TableCell();
                    dataReservas.Text = resultSql["Data"].ToString();
                    TableCell comenReservas = new TableCell();
                    comenReservas.Text = resultSql["Comensals"].ToString();

                    rowReservas.Controls.Add(nomReservas);
                    rowReservas.Controls.Add(cognomsReservas);
                    rowReservas.Controls.Add(telfReservas);
                    rowReservas.Controls.Add(dataReservas);
                    rowReservas.Controls.Add(comenReservas);

                    tableReservas.Controls.Add(rowReservas);
                }
                updatableContent.Controls.Add(tableReservas);
            }
            else updatableContent.InnerHtml = "<table id=\"tableReservasA\"><tr><td><strong>NO HI HA RESERVES PREVISTES.</strong></td></tr></table>";
            linksql.Close();
            if (idData == 0)
            {
              
            }

        }
    }
}