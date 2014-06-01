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
    public partial class DetallReserva : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"]);
            if (id != null) titleh.Text = "Detall Reserva Num." + id;
            buildDetail(id);
        }
        protected void buildDetail(int resID)
        {
            SqlCeConnection linksql = new SqlCeConnection(@"Data Source='C:\Users\Uoc\Documents\GitHub\Uoc_ASPNET\restaurantuoc.sdf';Password='uoc'");
            linksql.Open();
            SqlCeCommand sqlQuery = new SqlCeCommand("SELECT * FROM reserves WHERE id=" + resID, linksql);
            SqlCeDataReader resultSql = sqlQuery.ExecuteReader();
           
            while (resultSql.Read())
            {
                TableRow rowdetail1 = new TableRow();
                TableCell cell11 = new TableCell();
                cell11.Style.Add("background-color", "#A4A4A4");
                cell11.Text = "Nom: ";
                TableCell cell12 = new TableCell();
                cell12.Text = resultSql["Nom"].ToString();
                rowdetail1.Controls.Add(cell11);
                rowdetail1.Controls.Add(cell12);

                TableRow rowdetail2 = new TableRow();
                TableCell cell21 = new TableCell();
                cell21.Style.Add("background-color", "#A4A4A4");
                cell21.Text = "Cognoms: ";
                TableCell cell22 = new TableCell();
                cell22.Text = resultSql["Cognoms"].ToString();
                rowdetail2.Controls.Add(cell21);
                rowdetail2.Controls.Add(cell22);

                TableRow rowdetail3 = new TableRow();
                TableCell cell31 = new TableCell();
                cell31.Style.Add("background-color", "#A4A4A4");
                cell31.Text = "Telefon: ";
                TableCell cell32 = new TableCell();
                cell32.Text = resultSql["Telefon"].ToString();
                rowdetail3.Controls.Add(cell31);
                rowdetail3.Controls.Add(cell32);

                TableRow rowdetail4 = new TableRow();
                TableCell cell41 = new TableCell();
                cell41.Style.Add("background-color", "#A4A4A4");
                cell41.Text = "Data: ";
                TableCell cell42 = new TableCell();
                cell42.Text = resultSql["Data"].ToString();
                rowdetail4.Controls.Add(cell41);
                rowdetail4.Controls.Add(cell42);

                TableRow rowdetail5 = new TableRow();
                TableCell cell51 = new TableCell();
                cell51.Style.Add("background-color", "#A4A4A4");
                cell51.Text = "Comensals: ";
                TableCell cell52 = new TableCell();
                cell52.Text = resultSql["Comensals"].ToString();
                rowdetail5.Controls.Add(cell51);
                rowdetail5.Controls.Add(cell52);

                TableRow rowdetail6 = new TableRow();
                TableCell cell61 = new TableCell();
                cell61.Style.Add("background-color", "#A4A4A4");
                cell61.Text = "Comentaris: ";
                TableCell cell62 = new TableCell();
                cell62.Text = resultSql["Comentaris"].ToString();
                rowdetail6.Controls.Add(cell61);
                rowdetail6.Controls.Add(cell62);

                tabledetail.Controls.Add(rowdetail1);
                tabledetail.Controls.Add(rowdetail2);
                tabledetail.Controls.Add(rowdetail3);
                tabledetail.Controls.Add(rowdetail4);
                tabledetail.Controls.Add(rowdetail5);
                tabledetail.Controls.Add(rowdetail6);
            }
            linksql.Close();
            FindControl("modid").ID = resID.ToString();
        }
        protected void nova_Click(object sender, EventArgs e)
        {
            var myButton = (Button)sender;
            var myID = myButton.ID;
            Response.Redirect("NovaReserva.aspx?id=" + myID);
        }
        protected void del_Click(object sender, EventArgs e)
        {
            var myButton = (Button)sender;
            //var myID = id;
            // Response.Redirect("NovaReserva.aspx?id=" + myID);
        }

    }
}