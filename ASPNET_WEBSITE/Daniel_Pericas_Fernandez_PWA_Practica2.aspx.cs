using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Daniel_Pericas_Fernandez_PWA_Practica2 : System.Web.UI.Page
{
    string resAction = null;
    int idToEdit = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        eventControl();
        contentBuilder(1);
    }

    void contentBuilder(int page){
        switch (page) {
            case 1:
                titleh.Text = "Llistat de Reserves";
                break;
            case 2:
                if (resAction == "addNew") titleh.Text = "Nova Reserva";
                else titleh.Text = "Modifica Reserva Num."+idToEdit;
                break;
            case 3:
                titleh.Text = "Llistat de Reserves de les Proximes 24h.";
                break;
            case 4:
                titleh.Text = "Reserva Num."+idToEdit;
                break;
        }
    }

    void eventControl()
    {

    }

    void searchReserves(string valAction,int idData,string postData)
    {
        if (valAction == "deleteRes")
        {

        }
    }

}