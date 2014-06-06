<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NovaReserva.aspx.cs" Inherits="RestaurantUOC.NovaReserva" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>PROGRAMACIÓ WEB AVANÇADA - PRÀCTICA2</title>
    <link rel="stylesheet" href="RestaurantUOCcss.css" type="text/css" media="all"/>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <h3>PRÀTICA2 - Programació Web Avançada - Daniel Pericas Fernàndez</h3>
    <div id="bigcontainer" runat="server">
	    <div id="TitleDiv" runat="server"><asp:Label runat="server" Text="Label" id="titleh"><strong>Nova Reserva.</strong></asp:Label> </div>
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
           <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="infoBox" runat="server">
                    </asp:Panel>
                    <asp:Panel ID="reservaForm" runat="server">
                        <asp:Label ID="Label1" runat="server" Text="Nom:"></asp:Label><br />
                        <asp:TextBox ID="nomForm" Cssclass="fieldsVal" runat="server"></asp:TextBox><br />
                        
                        <asp:Label ID="Label2" runat="server" Text="Cognoms:"></asp:Label><br />
                        <asp:TextBox ID="cognomForm" Cssclass="fieldsVal" runat="server"></asp:TextBox><br />
                        
                        <asp:Label ID="Label3" runat="server" Text="Telefon:"></asp:Label><br />
                        <asp:TextBox ID="telForm" Cssclass="fieldsVal" runat="server"></asp:TextBox><br />
                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExternder2" runat="server" TargetControlID="telForm" FilterMode="ValidChars" ValidChars="1234567890()-"></asp:FilteredTextBoxExtender>

                        <asp:Label ID="Label4" runat="server" Text="Data:"></asp:Label><br />
                        <asp:DropDownList ID="dies" CssClass="timeClass" runat="server"></asp:DropDownList>
                        <asp:DropDownList ID="mesos" CssClass="timeClass" runat="server"></asp:DropDownList>
                        <asp:DropDownList ID="anys" CssClass="timeClass" runat="server"></asp:DropDownList>
                        <asp:DropDownList ID="hores" CssClass="timeClass" runat="server"></asp:DropDownList>
                        <asp:DropDownList ID="minuts" CssClass="timeClass" runat="server"></asp:DropDownList><br />

                        <asp:Label ID="Label5" runat="server" Text="Comensals:"></asp:Label><br />
                        <asp:TextBox ID="comensalForm" Cssclass="fieldsVal" runat="server"></asp:TextBox><br />
                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExternder1" runat="server" TargetControlID="comensalForm" FilterType="Numbers"></asp:FilteredTextBoxExtender>
                        
                        <asp:Label ID="Label6" runat="server" Text="Comentaris:"></asp:Label><br />
                        <asp:TextBox ID="comentForm" Cssclass="fieldsVal" TextMode="MultiLine" Columns="50" Rows="5" runat="server"></asp:TextBox><br /><br /><br />

                        <asp:Button ID="saveform" CssClass="boto" runat="server" Text="GUARDAR" OnClick="boto_Click"/>
                   </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
