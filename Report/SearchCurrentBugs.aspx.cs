using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class SearchCurrentBugs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Version");
        dt.Columns.Add("Bug Number");
        dt.Columns.Add("Status");
        dt.Columns.Add("Bug Dealer");
        dt.Columns.Add("Description");
        dt.Columns.Add("Priority");
        dt.Columns.Add("Date");

        if (dt.Rows.Count == 0)
        {
            dt.Rows.Add(dt.NewRow());
        }

        this.ResultGridView.DataSource = dt;
        this.ResultGridView.DataBind();

        this.Panel2.Visible = false;
    }
    protected void DetailButton_Click(object sender, EventArgs e)
    {
        this.Panel2.Visible = this.Panel2.Visible == true ? false : true;
        this.TextBox1.Visible = !this.TextBox1.Visible;
        //if (!this.Panel2.Visible)
        //{
        //    this.Panel2.Visible = true;
        //    this.StartDateTextBox.Text = "1";
        //}
        //if(this.Panel2.Visible)
        //{
        //    this.Panel2.Visible = false;
        //    this.StartDateTextBox.Text = "2";
        //}
    }
}
