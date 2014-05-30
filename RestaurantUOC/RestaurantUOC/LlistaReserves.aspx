<!-- Per tal de poder utilitzar Css superior al 2.1, posem opció a Css Internet Explorer 6.0 -->


<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LlistaReserves.aspx.cs" Inherits="RestaurantUOC.LlistaReserves" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PROGRAMACIÓ WEB AVANÇADA - PRÀCTICA2</title>
    <link rel="stylesheet" href="RestaurantUOCcss.css" type="text/css" media="all"/>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h3>PRÀTICA2 - Programació Web Avançada - Daniel Pericas Fernàndez</h3>
    <div id="bigcontainer" runat="server">
	    <div id="TitleDiv" runat="server"><asp:Label runat="server" Text="Label" id="titleh"><strong>Llistat de Reserves.</strong></asp:Label> </div>
	    <div id="NavButtonDiv" runat="server">
            <div id="Navul" runat="server">
                <asp:ListItem>
                    <asp:HyperLink runat="server" id="showList" CssClass="menuClass" NavigateUrl="#">LLISTAT</asp:HyperLink>
                </asp:ListItem>
                <asp:ListItem>
                <asp:HyperLink runat="server" CssClass="show24h menuClass" NavigateUrl="#">24h</asp:HyperLink>
                </asp:ListItem>
            </div>
        </div>
	    <div runat="server" id="UpdatableDiv">
            <div runat="server" id="if24h"></div>
            <div runat="server" id="headTable"></div>
            <div runat="server" id="updatableContent"></div>
            <asp:Button ID="novaresbutton" runat="server" Text="Nova Reserva"/>
        </div>
    </div>
    </form>
</body>
</html>
