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
            if (!Page.IsPostBack)
            {
                var id = 0;
                if (Request.QueryString["id"] != null) id = int.Parse(Request.QueryString["id"]);
                if (id != 0) titleh.Text = "Modifica Reserva Num." + id;
                BuildFormDate();
                BuidFormReserva(id);
            }
        }

        protected void BuildFormDate()
        {
            for (int i = 1; i <= 31; i++)
            {
                dies.Items.Add( new ListItem(i.ToString()));
            }
            string[] mesosArray = {"Gener","Febrer","Març","Abril","Maig","Juny","Juliol","Agost","Setembre","Octubre","Novembre","Decembre" };
            for (int i = 0; i < 12; i++)
            {
                mesos.Items.Add(new ListItem(mesosArray[i]));
            }
            for (int i = 2014; i <= 2020; i++)
            {
                anys.Items.Add(new ListItem(i.ToString()));
            }
            for (int i = 0; i < 24; i++)
            {
                if (i < 10) hores.Items.Add(new ListItem("0" + i.ToString()));
                else hores.Items.Add(new ListItem(i.ToString()));
            }
            for (int i = 0; i < 60; i++)
            {
                if (i < 10) minuts.Items.Add(new ListItem("0" + i.ToString()));
                else minuts.Items.Add(new ListItem(i.ToString()));
            }
        }

        protected void BuidFormReserva(int resID)
        {
            string[] mesosArray = { "Gener", "Febrer", "Març", "Abril", "Maig", "Juny", "Juliol", "Agost", "Setembre", "Octubre", "Novembre", "Decembre" };
            if (resID != 0)
            {
                SqlCeConnection linksql = new SqlCeConnection(@"Data Source='C:\Users\Uoc\Documents\GitHub\Uoc_ASPNET\restaurantuoc.sdf';Password='uoc'");
                linksql.Open();
                SqlCeCommand sqlQuery = new SqlCeCommand("SELECT * FROM reserves WHERE id=" + resID, linksql);
                SqlCeDataReader resultSql = sqlQuery.ExecuteReader();
                while (resultSql.Read())
                {
                    nomForm.Text = resultSql["Nom"].ToString();
                    cognomForm.Text = resultSql["Cognoms"].ToString();
                    telForm.Text = resultSql["Telefon"].ToString();
                    DateTime Data = Convert.ToDateTime(resultSql["Data"].ToString());
                        dies.Items.FindByValue(Data.Day.ToString()).Selected = true;
                        anys.Items.FindByValue(Data.Year.ToString()).Selected = true;
                        mesos.Items.FindByValue(mesosArray[Data.Month - 1]).Selected = true;
                        if (Data.Hour < 10) hores.Items.FindByValue("0"+Data.Hour.ToString()).Selected = true;
                        else hores.Items.FindByValue(Data.Hour.ToString()).Selected = true;
                        if (Data.Minute < 10) minuts.Items.FindByValue("0"+Data.Minute.ToString()).Selected = true;
                        else minuts.Items.FindByValue(Data.Minute.ToString()).Selected = true;
                    comensalForm.Text = resultSql["Comensals"].ToString();
                    comentForm.Text = resultSql["Comentaris"].ToString();
                }
                linksql.Close();
            }
            else
            {
                DateTime Data = DateTime.Now;
                dies.Items.FindByValue((Data.AddDays(1).Day).ToString()).Selected = true;  // Pre-Seleccionem un dia més per la nova reserva.
                mesos.Items.FindByValue(mesosArray[Data.Month - 1]).Selected = true;
                anys.Items.FindByValue(Data.Year.ToString()).Selected = true;
                if (Data.Hour < 10) hores.Items.FindByValue("0" + Data.AddHours(1).Hour.ToString()).Selected = true; // Pre-Seleccionem una hora més per la nova reserva.
                else hores.Items.FindByValue(Data.AddHours(1).Hour.ToString()).Selected = true;
                if (Data.Minute < 10) minuts.Items.FindByValue("0"+Data.Minute.ToString()).Selected = true;
                else minuts.Items.FindByValue(Data.Minute.ToString()).Selected = true;
            }
        }
        protected void boto_Click(object sender, EventArgs e)
        {
            //Validem com si fos requiredfield a cada camp que volem. Amb AjaxControlToolkit ja controlem el format de cada camp.
            var formFull = true;
            String errorInfoBoxText = "";
            if (nomForm.Text == "") { nomForm.CssClass = "failMark"; errorInfoBoxText += "Falten dades al camp obligatori: NOM.</br>"; formFull = false; }
            else nomForm.CssClass = "fieldsVal";
            if (cognomForm.Text == "") { cognomForm.CssClass = "failMark"; errorInfoBoxText += "Falten dades al camp obligatori: COGNOM.</br>"; formFull = false; }
            else cognomForm.CssClass = "fieldsVal";
            if (telForm.Text == "") { telForm.CssClass = "failMark"; errorInfoBoxText += "Falten dades al camp obligatori: TELEFON.</br>"; formFull = false; }
            else telForm.CssClass = "fieldsVal";
            DateTime Data = new DateTime(int.Parse(anys.SelectedValue), (mesos.SelectedIndex+1), int.Parse(dies.SelectedValue), int.Parse(hores.SelectedValue), int.Parse(minuts.SelectedValue), 0);
            DateTime Datanow = DateTime.Now;
            var diftime = Data.Subtract(Datanow).TotalMilliseconds;
            if (diftime < 24 * 60 * 60 * 1000)
            {
                errorInfoBoxText += "DATA incorrecte. La hora de la reserva ha de ser posterior a 24h.</br>";
                formFull = false;
                dies.CssClass = "failMark";
                mesos.CssClass = "failMark";
                anys.CssClass = "failMark";
                hores.CssClass = "failMark";
                minuts.CssClass = "failMark";
            }
            else
            {
                dies.CssClass = "timeClass";
                mesos.CssClass = "timeClass";
                anys.CssClass = "timeClass";
                hores.CssClass = "timeClass";
                minuts.CssClass = "timeClass";
            }
            if (comensalForm.Text == "") { comensalForm.CssClass = "failMark"; errorInfoBoxText += "Falten dades al camp obligatori: COMENSALS.</br>"; formFull = false; }
            else
            {
                if (int.Parse(comensalForm.Text) > 10 || int.Parse(comensalForm.Text) < 1) { comensalForm.CssClass = "failMark"; errorInfoBoxText += "Només s' accepten reserves de 1 a 10 comensals.</br>"; formFull = false; }
                else comensalForm.CssClass = "fieldsVal";
            }
            infoBox.Controls.Add(new LiteralControl(errorInfoBoxText));
            if (formFull == true)
            {
                int id;
                if (Request.QueryString["id"] != null) id = int.Parse(Request.QueryString["id"]);
                var dataToInsert = Data.ToString();
                SqlCeConnection linksql = new SqlCeConnection(@"Data Source='C:\Users\Uoc\Documents\GitHub\Uoc_ASPNET\restaurantuoc.sdf';Password='uoc'");
                linksql.Open();
                //SqlCeCommand sqlQuery = new SqlCeCommand("INSERT INTO reserves (Nom,Cognoms,Telefon,Data,Comensals,Comentaris) VALUES (\"" + nomForm.Text + "\",\"" + cognomForm.Text + "\",\"" + telForm.Text + "\",\"" + dataToInsert + "\"," + int.Parse(comensalForm.Text) + ",\"" + comentForm.Text + "\")", linksql);
                
                SqlCeCommand sqlQuery = new SqlCeCommand("INSERT INTO reserves (Nom,Cognoms,Telefon,Data,Comensals,Comentaris)" + "VALUES (@elNom,@elCognom,@elTelf,@elData,@elComensal,@elComentari)", linksql);
                sqlQuery.Parameters.AddWithValue("@elNom", nomForm.Text);
                sqlQuery.Parameters.AddWithValue("@elCognom", cognomForm.Text);
                sqlQuery.Parameters.AddWithValue("@elTelf", telForm.Text);
                sqlQuery.Parameters.AddWithValue("@elData", Data.ToString());
                sqlQuery.Parameters.AddWithValue("@elComensal", int.Parse(comensalForm.Text));
                sqlQuery.Parameters.AddWithValue("@elComentari", comentForm.Text);
                sqlQuery.ExecuteNonQuery();
                linksql.Close();
            }
        }
    }
}