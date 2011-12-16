<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Team View</title>
    <link rel="Stylesheet" href="Css/Home.css" type="text/css"/>
    <script language="JavaScript" type="text/javascript">
        function SearchBugs(id) {
            var dealManList = document.getElementById(id);
            var dealMan = dealManList.options[dealManList.selectedIndex].value;
            var type = document.getElementsByName("bugs");
            for (var i = 0; i < type.length; i++) {
                if (type[i].checked) {
                    if (type[i].value == 1)
                        window.open("SearchCurrentBugs.aspx?dealMan=" + dealMan);
                    else if (type[i].value == 2)
                        window.open("AutofacForAsp.aspx?dealMan=" + dealMan);
                    else if (type[i].value == 3)
                        window.open("NoInjection.aspx?dealMan=" + dealMan);
                    else if (type[i].value == 4)
                        window.open("SearchInnerBugs.aspx?dealMan=" + dealMan);
                    return;
                }
            }
            alert("Please select one type of bugs");
        }
    </script>

</head>
<body>
    <form runat = "server">
    <div id="m"  >
       <div id="des">
          <h3>Description:</h3>
          <p></p>
       </div>
    
      <div id="input">
       <label class="instruction" >DealMan:</label>
       <asp:DropDownList name="DealMen" id="dealmen" runat="server" oninit="dealmen_Init"> 
       </asp:DropDownList> 
       <br />
        <input type="radio" name="bugs" value="1" class="check" />
        <label class ="instruction">Current Bugs</label>
        <br />
        <input type="radio" name="bugs" value="2" class="check" />
        <label class="instruction">Current Bugs(using Autofac in Web form)</label>
        <br />
        <input type="radio" name="bugs" value="3" class="check" />
        <label class="instruction">Current Bugs(Querying by sql)</label>
        <br />
        <input type="radio" name="bugs" value="4" class="check" />
        <label class="instruction">Inner Bugs</label>
        <br />
        <input type="submit" value="Search" id="search" onclick="SearchBugs('dealmen')" />

      </div> 
      
     </div>
    </form>
</body>
</html>
