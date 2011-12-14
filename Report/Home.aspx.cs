using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void dealmen_Init(object sender, EventArgs e)
    {
        string dealMenStr = System.Configuration.ConfigurationManager.AppSettings["DealMen"];
        string programer = System.Configuration.ConfigurationManager.AppSettings["Programmer"];
        string[] dealMen = dealMenStr.Split(new char[] { ',' });
        for (int i = 0; i < dealMen.Length; i++)
        {
            bool selected = dealMen[i] == programer;
            dealmen.Items.Add(new ListItem { Text = dealMen[i], Value = dealMen[i], Selected = selected });
        }
    }
}
