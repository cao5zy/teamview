<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchInnerBugs.aspx.cs" Inherits="SearchInnerBugs" %>

<%@ Register assembly="DevExpress.Web.ASPxEditors.v9.2, Version=9.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Search Inner Bugs Page</title>
</head>
<body style="background-color:#227700">
    <form id="form1" runat="server">
    <div style="text-align:left">
      <img  alt="Team View" src="Picture/users_search.png"/></div>
    <div style="text-align:center">
        <h1>Search Inner Bugs</h1>
    </div>
    <div style="text-align:left;">
          <div style="text-align:left;">
              <b>Search Criteria</b>
          </div>
        <asp:Label ID="CurrentMemberLabel" runat="server" Text="Label">Current Member:</asp:Label>
        &nbsp;&nbsp;
        <asp:DropDownList ID="CurrentMembersDropDownList" runat="server" 
            BackColor="White">
            <asp:ListItem>曹宗颖</asp:ListItem>
            <asp:ListItem>方绍军</asp:ListItem>
            <asp:ListItem>叶伟</asp:ListItem>
            <asp:ListItem>彭长生</asp:ListItem>
            <asp:ListItem>成小平</asp:ListItem>
            <asp:ListItem>张果</asp:ListItem>
            <asp:ListItem>王德林</asp:ListItem>
            <asp:ListItem>石涛</asp:ListItem>
            <asp:ListItem>客户</asp:ListItem>
          </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        
        <asp:Label ID="StartDateLabel" runat="server" Text="Label">Start Date:</asp:Label>
        &nbsp;&nbsp;<asp:TextBox ID="StartDateTextBox" runat="server" 
             Width="80px"></asp:TextBox>
&nbsp;<asp:ImageButton ID="StartDateImageButton" runat="server" ImageUrl="~/Picture/calendar.png"
            onclick="StartDateImageButton_Click" Height="16px" Width="18px" />            
&nbsp;<asp:Calendar ID="StartDateCalendar" runat="server" BackColor="White" 
            BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" 
            DayNameFormat="Shortest" EnableViewState="true" Font-Names="Verdana" 
            Font-Size="8pt" ForeColor="#003399" Height="200px" 
            onselectionchanged="StartDateCalendar_SelectionChanged" Width="220px">
            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
            <WeekendDayStyle BackColor="#CCCCFF" />
            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
            <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" 
                Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
        </asp:Calendar>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        
        <asp:Label ID="EndDateLabel" runat="server" Text="Label">End Date:</asp:Label>
        &nbsp;&nbsp;<asp:TextBox ID="EndDateTextBox" runat="server" 
              Width="80px"></asp:TextBox>
        &nbsp;<asp:ImageButton ID="EndDateImageButton" runat="server" ImageUrl="~/Picture/calendar.png"
            onclick="EndDateImageButton_Click" Height="16px" Width="18px" />
&nbsp;<asp:Calendar ID="EndDateCalendar" runat="server" BackColor="White" 
            BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" 
            DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
            ForeColor="#003399" Height="200px" Width="220px" 
            onselectionchanged="EndDateCalendar_SelectionChanged">
            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
            <WeekendDayStyle BackColor="#CCCCFF" />
            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
            <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" 
                Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
        </asp:Calendar>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        
        <asp:ImageButton ID="SearchInnerBugsImageButton" runat="server" ImageUrl="~/Picture/search.png"
        onclick="SearchButton_Click" ToolTip="Search Inner Bugs" BorderColor="Red" 
                  AlternateText="Search" Height="20px" Width="20px"/>
    </div>
    
    <br />
    
    <div id="searchResultId" style="text-align:left">
        <div style="text-align:left;">
            <b>Search Results</b>
            (<asp:Label ID="SearchResultCountLabel" runat="server"></asp:Label>)</div>
        <asp:GridView ID="SearchResultsGridView" runat="server" CellPadding="4" 
            ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" 
            AllowSorting="True">
            <RowStyle BackColor="#E3EAEB" />
            <Columns>
                <asp:BoundField DataField="Version" HeaderText="Version" FooterText="Version" />
                <asp:BoundField DataField="BugNum" HeaderText="Bug Number" 
                    FooterText="Bug Number" />
                <asp:BoundField DataField="BugStatus" HeaderText="Bug Status" 
                    FooterText="Bug Status" />
                <asp:BoundField DataField="DealMan" HeaderText="Deal Man" 
                    FooterText="Deal Man" />
                <asp:BoundField DataField="Description" HeaderText="Description" 
                    FooterText="Description" />
                <asp:BoundField DataField="CreatedDate" HeaderText="Created Date" 
                    FooterText="Created Date" />
                <asp:BoundField DataField="CreatedMan" HeaderText="Created Man" 
                    FooterText="Created Man" >
                <ItemStyle BackColor="#993333" />
                </asp:BoundField>
                <asp:ButtonField Text="Detail" CommandName="ShowItemDetail" />
            </Columns>
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" 
                BorderColor="#333300" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#7C6F57" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>

    </div>
    
    </form>
</body>
</html>
