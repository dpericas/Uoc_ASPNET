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
    public partial class LlistaReserves : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var typepage = "";
            if (Request.QueryString["type"] != null) typepage = Request.QueryString["type"];
            searchReserves(typepage);
        }

         protected void searchReserves(string type24)
         {
             SqlCeConnection linksql = new SqlCeConnection(@"Data Source='C:\Users\Uoc\Documents\GitHub\Uoc_ASPNET\restaurantuoc.sdf';Password='uoc'");
             linksql.Open();
             SqlCeCommand sqlQuery = new SqlCeCommand();
             if (type24 == "")
             {
                 Timer1_Tick(this,EventArgs.Empty); // CRIDEM AL EVENT AL ENTRAR PERQUE VEGEM EL LINK DE 24h DESDE EL INICI. DESPRES COMENÇA A FER EL TIMER.
                 sqlQuery.CommandText = "SELECT * FROM reserves WHERE Data > GETDATE() order by Data";
                 if (FindControl("Link24") != null) show24.Visible = true;
             }
             else
             {
                 sqlQuery.CommandText = "SELECT * FROM reserves WHERE Data BETWEEN GETDATE() AND (DATEADD(day,1,GETDATE()))";
                 Timer1.Enabled = false; // PAREM LA CONSULTA DE 24h JA QUE JA ESTEM A LA PÀGINA DE 24h.
                 showList.Visible = true;
                 show24.Visible = false;
             }
             sqlQuery.Connection = linksql;
             SqlCeDataReader resultSql = sqlQuery.ExecuteReader();
             if (resultSql.Read())
             {
                     resultSql.Close();
                     resultSql = sqlQuery.ExecuteReader(); //TORNEM A EXECUTAR EL READER JA QUE SI COMPROVAVEM IF READ() PERDIEM EL PRIMER REGISTRE. TANQUEM I TRONEM A OBRIR.
                     headTable.InnerHtml = "<table id=\"tableReservasA\"><tr bgcolor=\"#A4A4A4\"><td><strong>Nom</strong></td><td><strong>Cognoms</strong></td><td><strong>Telefon</strong></td><td><strong>Data</strong></td><td><strong>Comensals</strong></td></tr></table>";
                      while (resultSql.Read())
                     {

                         TableRow rowReservas = new TableRow();
                         rowReservas.ID = "Row" + resultSql["Id"].ToString();
                         rowReservas.CssClass = "treservas";
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
                             idform1.Click += new EventHandler(this.detail_Click);
                             Button idform2 = new Button();
                             idform2.ID = "modid" + resultSql["Id"].ToString();
                             idform2.CssClass = "novamodif regform";
                             idform2.Text = "Modificar";
                             idform2.Click += new EventHandler(this.nova_Click);
                             Button idform3 = new Button();
                             idform3.ID = "delid" + resultSql["Id"].ToString();
                             idform3.CssClass = "delRes regform";
                             idform3.Text = "Eliminar";
                             idform3.Click += new EventHandler(this.del_Click);
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
             }
             else updatableContent.InnerHtml = "<table id=\"tableReservasA\"><tr><td><strong>NO HI HA RESERVES PREVISTES.</strong></td></tr></table>";
             linksql.Close();
         }

         protected void del_Click(object sender, EventArgs e)
         {
             Button myButton = (Button)sender;
             TableCell cellBut = (TableCell)myButton.Parent;
             TableRow rowBut = (TableRow)cellBut.Parent;
             var indexRow = rowBut.TabIndex;
             var myID = System.Text.RegularExpressions.Regex.Split(myButton.ID,"delid")[1];

             SqlCeConnection linksql = new SqlCeConnection(@"Data Source='C:\Users\Uoc\Documents\GitHub\Uoc_ASPNET\restaurantuoc.sdf';Password='uoc'");
             linksql.Open();
             SqlCeCommand sqlQuery = new SqlCeCommand("DELETE FROM reserves WHERE Id=" + myID, linksql);
             int isRowAffected= sqlQuery.ExecuteNonQuery();
             linksql.Close();
             if (isRowAffected == 1)  // ENS ASSEGUREM QUE LA CONSULTA HA TINGUT ÈXIT I S' HA BORRAT EL REGISTRE. LLAVORS PODEM ELIMINAR LA ROW DE LA TAULA.
             {
                 tableReservas.Rows.Remove(rowBut);
                 if (tableReservas.Rows.Count == 0) Response.Redirect("LlistaReserves.aspx"); //SI NO QUEDEN FILES A LA TAULA TORNEM A GENERAR TAULA I DETECTARÀ QUE NO HI HAN REGISTRES.
             }
         }
         protected void detail_Click(object sender, EventArgs e)
         {
             var myButton = (Button)sender;
             var myID = System.Text.RegularExpressions.Regex.Split(myButton.ID, "detailid")[1];
             Response.Redirect("DetallReserva.aspx?id=" + myID);
         }
         protected void nova_Click(object sender, EventArgs e)
         {
             var myButton = (Button)sender;
             if (myButton.ID != "novaresbutton")
             {
                 var myID = System.Text.RegularExpressions.Regex.Split(myButton.ID, "modid")[1];
                 Response.Redirect("NovaReserva.aspx?id=" + myID);
             }
             else Response.Redirect("NovaReserva.aspx");
         }

         protected void Timer1_Tick(object sender, EventArgs e)
         {
             if24h.Controls.Clear();
             show24.Visible = false;
             SqlCeConnection linksql2 = new SqlCeConnection(@"Data Source='C:\Users\Uoc\Documents\GitHub\Uoc_ASPNET\restaurantuoc.sdf';Password='uoc'");
             linksql2.Open();
             SqlCeCommand sqlQuery2 = new SqlCeCommand("SELECT * FROM reserves WHERE Data BETWEEN GETDATE() AND (DATEADD(day,1,GETDATE()))", linksql2);
             SqlCeDataReader resultSql2 = sqlQuery2.ExecuteReader();
             if (resultSql2.Read())
             {
                 HyperLink link24 = new HyperLink();
                 link24.Text = "Hi ha reserves a les pròximes 24h";
                 link24.NavigateUrl = "LlistaReserves.aspx?type=24h";
                 link24.ID = "Link24";
                 if24h.Controls.Add(link24);
                 if (FindControl("Link24") != null) show24.Visible = true;
             }
             linksql2.Close();
         }
    }
}