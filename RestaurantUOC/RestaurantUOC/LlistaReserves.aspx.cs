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
                headTable.InnerHtml = "<table id=\"tableReservasA\"><tr bgcolor=\"#A4A4A4\"><td><strong>Nom</strong></td><td><strong>Cognoms</strong></td><td><strong>Telefon</strong></td><td><strong>Data</strong></td><td><strong>Comensals</strong></td></tr></table>";
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
                    TableCell menueditReservas = new TableCell();
                        Button idform1 = new Button();
                        idform1.ID = "detailid" + resultSql["Id"].ToString();
                        idform1.CssClass = "detailres regform";
                        idform1.Text = "Detall";
                        Button idform2 = new Button();
                        idform2.ID = "modid" + resultSql["Id"].ToString();
                        idform2.CssClass = "novamodif regform";
                        idform2.Text = "Modificar";
                        Button idform3 = new Button();
                        idform3.ID = "delid" + resultSql["Id"].ToString();
                        idform3.CssClass = "delRes regform";
                        idform3.Text = "Eliminar";
                        menueditReservas.Controls.Add(idform1);
                        menueditReservas.Controls.Add(idform2);
                        menueditReservas.Controls.Add(idform3);

                    rowReservas.Controls.Add(nomReservas);
                    rowReservas.Controls.Add(cognomsReservas);
                    rowReservas.Controls.Add(telfReservas);
                    rowReservas.Controls.Add(dataReservas);
                    rowReservas.Controls.Add(comenReservas);
                    rowReservas.Controls.Add(menueditReservas);

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