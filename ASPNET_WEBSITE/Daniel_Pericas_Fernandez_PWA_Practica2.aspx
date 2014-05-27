<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Daniel_Pericas_Fernandez_PWA_Practica2.aspx.cs" Inherits="Daniel_Pericas_Fernandez_PWA_Practica2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PROGRAMACIÓ WEB AVANÇADA - PRÀCTICA2</title>
    <link rel="stylesheet" href="Daniel_Pericas_Fernandez_PWA_Practica1css.css" type="text/css" media="all"/>
  <!--  <script type="text/javascript" src="js/jquery-1.11.0.min.js"></script>
    <script type="text/javascript" src="Daniel_Pericas_Fernandez_PWA_Practica1js.js"></script>-->
</head>
<body>
    <form id="form1" runat="server">
    <h3>PRÀTICA2 - Programació Web Avançada - Daniel Pericas Fernàndez</h3>
    <div id="bigcontainer">
	    <div id="TitleDiv"><asp:Label runat="server" Text="Label" id="titleh"></asp:Label> </div>
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
	    <div id="UpdatableDiv"></div>
    </div>
    </form>
</body>
</html>
