﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NovaReserva.aspx.cs" Inherits="RestaurantUOC.NovaReserva" %>

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
	    <div id="TitleDiv" runat="server"><asp:Label runat="server" Text="Label" id="titleh"><strong>Nova Reserva.</strong></asp:Label> </div>
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
            <div runat="server" id="updatableContent">
           <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="infoBox" runat="server">
                    </asp:Panel>
                    <asp:Panel ID="reservaForm" runat="server">
                        <asp:Label ID="Label1" runat="server" Text="Nom:"></asp:Label><br />
                        <asp:TextBox ID="nomForm" class="fieldsVal" runat="server"></asp:TextBox><br />
                        <asp:Label ID="Label2" runat="server" Text="Cognoms:"></asp:Label><br />
                        <asp:TextBox ID="cognomForm" class="fieldsVal" runat="server"></asp:TextBox><br />
                        <asp:Label ID="Label3" runat="server" Text="Telefon:"></asp:Label><br />
                        <asp:TextBox ID="telForm" class="fieldsVal" runat="server"></asp:TextBox><br />
                        <asp:Label ID="Label4" runat="server" Text="Data:"></asp:Label><br />
                        <asp:DropDownList ID="dies" runat="server"></asp:DropDownList>
                        <asp:DropDownList ID="mesos" runat="server"></asp:DropDownList>
                        <asp:DropDownList ID="anys" runat="server"></asp:DropDownList>
                        <asp:DropDownList ID="hores" runat="server"></asp:DropDownList>
                        <asp:DropDownList ID="minuts" runat="server"></asp:DropDownList><br />
                        <asp:Label ID="Label5" runat="server" Text="Comensals:"></asp:Label><br />
                        <asp:TextBox ID="comensalForm" class="fieldsVal" runat="server"></asp:TextBox><br />
                        <asp:Label ID="Label6" runat="server" Text="Comentaris:"></asp:Label><br />
                        <asp:TextBox ID="comentForm" class="fieldsVal" TextMode="MultiLine" Columns="50" Rows="5" runat="server"></asp:TextBox><br /><br /><br />

                        <asp:Button ID="saveform" class="boto" runat="server" Text="GUARDAR" />
                   </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
