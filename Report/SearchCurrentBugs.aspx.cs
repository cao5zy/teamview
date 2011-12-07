using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class SearchCurrentBugs : System.Web.UI.Page
{
    private DataTable dt = new GridViewTable().GetDaTaTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
            InitGirdView();
    }

    private void InitGirdView()
    {
        DataTable s = new DataTable();
        if (dt.Rows.Count == 0)
        {
            dt.Rows.Add(dt.NewRow());
        }

        this.ResultGridView.DataSource = dt;
        this.ResultGridView.DataBind();
        this.Calendar1.Visible = false;
        this.StartDateTextBox.Enabled = false;
        this.EndDateTextBox.Enabled = false;
        this.Calendar2.Visible = false;
    }

   
    protected void DetailButton_Click(object sender, EventArgs e)
    {
        this.Panel2.Visible = !this.Panel2.Visible;
    }

    private DataTable GetSource()
    {
        bool hasFirstCondition = false;
        dt.Clear();
        string connString = System.Configuration.ConfigurationManager.ConnectionStrings["bug_Db"].ConnectionString;
        string sql = "SELECT version, bugNum, bugStatus, dealMan, description, priority, createdTime FROM bugInfo WHERE";
        if (!(StartDateTextBox.Text == "") && !(EndDateTextBox.Text == ""))
        {
            sql += " DATEDIFF(DAYOFYEAR,'" + StartDateTextBox.Text + "',createdTime) >= 0 and DATEDIFF(DAYOFYEAR,'" + EndDateTextBox.Text + "',createdTime) <= 0";
            hasFirstCondition = true;
        }
        if (!(VersionTextBox.Text == ""))
        {
            if (hasFirstCondition)
                sql += " and";
            hasFirstCondition = true;
            sql += " version = '" + VersionTextBox.Text + "'";
        }
        if (!(BugNumTextBox.Text == ""))
        {
            if (hasFirstCondition)
                sql += " and";
            hasFirstCondition = true;
            sql += " bugNum = '" + BugNumTextBox.Text + "'";
        }
        if (!(BugStatusTextBox.Text == ""))
        {
            if (hasFirstCondition)
                sql += " and";
            hasFirstCondition = true;
            sql += " bugStatus = '" + BugStatusTextBox.Text + "'";
        }
        if (!(PriorityTextBox.Text == ""))
        {
            if (hasFirstCondition)
                sql += " and";
            hasFirstCondition = true;
            sql += " priority = '" + PriorityTextBox.Text + "'";
        }
        using (SqlConnection conn=new SqlConnection(connString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            this.TextBox1.Text = sql;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dt.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6]);
            }
            
        }
        if (dt.Rows.Count == 0)
            dt.Rows.Add(dt.NewRow());
        return dt;
    }

    protected void SearchButton_Click(object sender, EventArgs e)
    {
        this.ResultGridView.DataSource = GetSource();
        this.ResultGridView.DataBind();
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        this.StartDateTextBox.Text = this.Calendar1.SelectedDate.ToString();
        this.Calendar1.Visible = false;
    }
    protected void CalendarImageButton_Click(object sender, ImageClickEventArgs e)
    {
        this.Calendar1.Visible = true;
    }
    protected void CalendarImageButtonOne_Click(object sender, ImageClickEventArgs e)
    {
        this.Calendar2.Visible = true;
    }
    protected void Calendar2_SelectionChanged(object sender, EventArgs e)
    {
        this.EndDateTextBox.Text = this.Calendar2.SelectedDate.ToString();
        this.Calendar2.Visible = false;
    }
}
