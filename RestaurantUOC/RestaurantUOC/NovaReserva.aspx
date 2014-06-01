<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NovaReserva.aspx.cs" Inherits="RestaurantUOC.NovaReserva" %>

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
                        <input runat="server" id="nomForm" class="fieldsVal" type="text" /><br />
                        <asp:Label ID="Label2" runat="server" Text="Cognoms:"></asp:Label><br />
                        <input runat="server" id="cognomForm" class="fieldsVal" type="text" /><br />
                        <asp:Label ID="Label3" runat="server" Text="Telefon:"></asp:Label><br />
                        <input runat="server" id="telForm" class="fieldsVal" type="text" /><br />
                        <asp:Label ID="Label4" runat="server" Text="Data:"></asp:Label><br />
                        <asp:Label ID="Label5" runat="server" Text="Comensals:"></asp:Label><br />
                        <input runat="server" id="comensalForm" class="fieldsVal" type="text" /><br />
                        <asp:Label ID="Label6" runat="server" Text="Comentaris:"></asp:Label><br />
                        <textarea runat="server" id="comentForm" class="fieldsVal" cols="50" rows="5"></textarea><br /><br /><br />

                        <input runat="server" id="saveForm" type="submit" value="GUARDAR" class="boto"/>
                   </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
