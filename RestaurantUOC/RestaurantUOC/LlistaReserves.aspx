<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LlistaReserves.aspx.cs" Inherits="RestaurantUOC.LlistaReserves" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PROGRAMACIÓ WEB AVANÇADA - PRÀCTICA2</title>
    <link rel="stylesheet" href="Daniel_Pericas_Fernandez_PWA_Practica2css.css" type="text/css" media="all"/>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h3>PRÀTICA2 - Programació Web Avançada - Daniel Pericas Fernàndez</h3>
    <div id="bigcontainer">
	    <div id="TitleDiv"><asp:Label runat="server" Text="Label" id="titleh"><strong>Llistat de Reserves.</strong></asp:Label> </div>
	    <div id="NavButtonDiv">
            <div id="Navul">
                <asp:ListItem>
                    <asp:HyperLink runat="server" id="showList" CssClass="menuClass" NavigateUrl="#">LLISTAT</asp:HyperLink>
                </asp:ListItem>
                <asp:ListItem>
                <asp:HyperLink runat="server" CssClass="show24h menuClass" NavigateUrl="#">24h</asp:HyperLink>
                </asp:ListItem>
            </div>
        </div>
	    <div runat="server" id="UpdatableDiv">
            <div runat="server" id="updatableContent"></div>
            <asp:Button ID="novaresbutton" runat="server" Text="Nova Reserva"/>
        </div>
    </div>
    </form>
</body>
</html>
