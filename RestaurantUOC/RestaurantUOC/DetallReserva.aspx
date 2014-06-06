<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetallReserva.aspx.cs" Inherits="RestaurantUOC.DetallReserva" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>PROGRAMACIÓ WEB AVANÇADA - PRÀCTICA2</title>
    <link rel="stylesheet" href="RestaurantUOCcss.css" type="text/css" media="all"/>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h3>PRÀTICA2 - Programació Web Avançada - Daniel Pericas Fernàndez</h3>
    <div id="bigcontainer" runat="server">
	    <div id="TitleDiv" runat="server"><asp:Label runat="server" Text="Label" id="titleh"><strong>Detall Reserva.</strong></asp:Label> </div>
	    <div id="NavButtonDiv" runat="server">
            <div id="Navul" runat="server">
                <asp:ListItem>
                    <asp:HyperLink runat="server" id="showList" CssClass="menuClass" NavigateUrl="LlistaReserves.aspx">LLISTAT</asp:HyperLink>
                </asp:ListItem>
                <asp:ListItem>
                <asp:HyperLink runat="server" CssClass="show24h menuClass" NavigateUrl="LlistaReserves.aspx?type=24h" Visible=false>24h</asp:HyperLink>
                </asp:ListItem>
            </div>
        </div>
	    <div runat="server" id="UpdatableDiv">
            <div runat="server" id="updatableContent">
                <asp:Table ID="tabledetail" runat="server">
                </asp:Table>
            </div>
            <div id="idform" class="reservaRegForm2">
                <asp:Button runat="server" id="modid" Text="Modificar" Cssclass="boto" OnClick="nova_Click"/>
                <asp:Button runat="server" id="delid" Text="Eliminar" Cssclass="boto" OnClick="del_Click"/>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
