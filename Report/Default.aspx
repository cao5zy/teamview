<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MainPage</title>
    <link rel="Stylesheet" href="Css/Ordinary.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <h1 style="text-align:center;">
         The TeamView Report
      </h1>
    </div>
    <asp:Panel ID="MenuPanel" runat="server">
      <ul id = "menu">
        <li><a href="Home.aspx" />Home</li>
        <li><a href="Search.aspx" />Search</li>
      </ul>
    </asp:Panel>
    <br />
    </form>
</body>
</html>
