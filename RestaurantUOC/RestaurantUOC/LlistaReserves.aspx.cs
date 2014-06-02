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
             //Response.Write(@"<script languange='javascript'>alert('Arrancant Pagina');</script>");
             searchReserves(null, 0, null);
        }

         protected void searchReserves(string valAction, int idData, string postData)
         {
             //Response.Write(@"<script languange='javascript'>alert('carregant');</script>");
             SqlCeConnection linksql = new SqlCeConnection(@"Data Source='C:\Users\Uoc\Documents\GitHub\Uoc_ASPNET\restaurantuoc.sdf';Password='uoc'");
             linksql.Open();
             SqlCeCommand sqlQuery = new SqlCeCommand("SELECT * FROM reserves", linksql);
             SqlCeDataReader resultSql = sqlQuery.ExecuteReader();
             if (resultSql != null)
             {
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
                             //idform3.OnClientClick = "return false;";
                             //idform3.Click += del_Click;
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

         void del_Click(object sender, EventArgs e)
         {
             
             var myButton = (Button)sender;
             var myID = int.Parse(myButton.ID.TrimStart('d', 'e', 'l', 'i', 'd'));
             myButton.Text = myID.ToString();
             tableReservas.Rows.RemoveAt(1);
             //FindControl("Row" + myID).Controls.Clear();
            /* SqlCeConnection linksql = new SqlCeConnection(@"Data Source='C:\Users\Uoc\Documents\GitHub\Uoc_ASPNET\restaurantuoc.sdf';Password='uoc'");
             linksql.Open();
             string deleteSQL;
             SqlCeCommand sqlQuery = new SqlCeCommand("DELETE FROM reserves WHERE Id="+myID, linksql);
             sqlQuery.ExecuteNonQuery();
             linksql.Close();
             tableReservas.Rows.RemoveAt(1);*/
         }
         protected void detail_Click(object sender, EventArgs e)
         {
             var myButton = (Button)sender;
             var myID = int.Parse(myButton.ID.TrimStart('d', 'e', 't', 'a', 'i', 'l', 'i', 'd'));
             Response.Redirect("DetallReserva.aspx?id=" + myID);
         }
         protected void nova_Click(object sender, EventArgs e)
         {
             var myButton = (Button)sender;
             if (myButton.ID != "novaresbutton")
             {
                 var myID = int.Parse(myButton.ID.TrimStart('m', 'o', 'd', 'i', 'd'));
                 Response.Redirect("NovaReserva.aspx?id=" + myID);
             }
             else Response.Redirect("NovaReserva.aspx");
         }
        void DataBaseConect()
        {
            SqlCeConnection linksql = new SqlCeConnection(@"Data Source='C:\Users\Uoc\Documents\GitHub\Uoc_ASPNET\restaurantuoc.sdf';Password='uoc'");
            linksql.Open();
            SqlCeCommand sqlQuery = new SqlCeCommand("SELECT * FROM reserves", linksql);
            SqlCeDataReader resultSql = sqlQuery.ExecuteReader();
            linksql.Close();
        }
    }
}