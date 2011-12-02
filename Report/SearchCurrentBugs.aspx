<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchCurrentBugs.aspx.cs" Inherits="SearchCurrentBugs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Search Current Bugs</title>
</head>
<body>
    <form id="form1" runat="server">
      <div>
        <h1 style="text-align:center;">
          Search Current Bugs
        </h1>
      </div>
      <br />
      <div style="text-align:center;">
        <asp:Panel ID="Panel1" runat="server" Width="70%">
          <div style="text-align:left;">
            Search Condition
          </div>
          <asp:Panel ID="SearchCondition" runat="server" BorderStyle="Groove" 
                HorizontalAlign="Left">
              
              <div>
                <asp:Label ID="StartDateLabel" runat="server" Text="Start Date:"></asp:Label>
                  &nbsp;
                <asp:TextBox ID="StartDateTextBox" runat="server" Width="144px"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="EndDateLabel" runat="server" Text="End Date:"></asp:Label>
                  &nbsp;
                <asp:TextBox ID="EndDateTextBox" runat="server" Width="144px"></asp:TextBox>
              </div>
              
              <div>
                <asp:Label ID="VersionLabel" runat="server" Text="Version:"></asp:Label>
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="VersionTextBox" runat="server" Width="144px"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="BugNumLabel" runat="server" Text="Bug Num:"></asp:Label>
                  &nbsp;
                <asp:TextBox ID="BugNumTextBox" runat="server" Width="144px"></asp:TextBox>
              </div>
              
              <div>
                <asp:Label ID="BugStatusLabel" runat="server" Text="Bug Status:"></asp:Label>
                  &nbsp;
                <asp:TextBox ID="BugStatusTextBox" runat="server" Width="144px"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="PriorityLabel" runat="server" Text="Priority:"></asp:Label>
                  &nbsp;&nbsp; &nbsp;
                <asp:TextBox ID="PriorityTextBox" runat="server" Width="144px"></asp:TextBox>
              </div>
              
              <asp:Button ID="SearchButton" runat="server" Text="Search" />
          </asp:Panel>
          <br />
          <div style="text-align:left;">
            Search Result
          </div>
          <asp:Panel ID="ResultPanel" runat="server" BorderStyle="Groove"
                HorizontalAlign="Left">
            <div>
            
                <asp:GridView ID="ResultGridView" runat="server" Width="100%">
                </asp:GridView>
            
            </div>
          </asp:Panel>
          
          <br />
          <div style="text-align:left;">
            <asp:Button ID="DetailButton" runat="server" Text="Detail" 
                  onclick="DetailButton_Click"/>
          </div>
          <asp:Panel ID="Panel2" runat="server" BorderStyle="Groove" 
                HorizontalAlign="Left">
            <div>
              
                <asp:TextBox ID="TextBox1" runat="server"
                    TextMode="MultiLine" Width="100%" Height="100px"></asp:TextBox>
              
            </div>
          </asp:Panel>
          
        </asp:Panel>
      </div>
    </form>
</body>
</html>
