﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using TeamView.Entity;
using TeamView.Dao;

public partial class SearchCurrentBugs : System.Web.UI.Page
{
    public IBugInfoManagement bugInfoManagement { set; get; }
    private DataTable dt = new GridViewTable().GetDaTaTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
            InitGirdView();
    }

    private void InitGirdView()
    {
        ListItem priority0 = new ListItem();
        ListItem priority1 = new ListItem();
        ListItem priority2 = new ListItem();
        ListItem priority3 = new ListItem();
        ListItem priority4 = new ListItem();
        priority1.Value = "0";
        priority2.Value = "1";
        priority3.Value = "2";
        priority4.Value = "3";
        ListItem[] priority = { priority0, priority1, priority2, priority3, priority4 };
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
        this.BugStatusList.Items.Add("");
        this.BugStatusList.Items.Add("正在处理");
        this.BugStatusList.Items.Add("待处理");
        this.BugStatusList.Items.Add("搁置");
        this.BugStatusList.Items.Add("完成");
        this.PriorityList.Items.AddRange(priority);

    }


    protected void DetailButton_Click(object sender, EventArgs e)
    {
        this.Panel2.Visible = !this.Panel2.Visible;
    }

    protected void SearchButton_Click(object sender, EventArgs e)
    {
        this.ResultGridView.DataSource = QuerySource();
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

    protected DataTable QuerySource()
    {
        string[] programmer = { Request["dealMan"] };
        string bugNum = string.Empty;
        string version = string.Empty;
        string description = string.Empty;
        int? priority = null;
        string bugState = string.Empty;
        dt.Clear();

        version = this.VersionTextBox.Text;
        bugNum = BugNumTextBox.Text;
        bugState = BugStatusList.Text;
        if (!string.IsNullOrEmpty(PriorityList.Text))
            priority = int.Parse(PriorityList.Text);
        List<BugInfoEntity> result = bugInfoManagement.QueryByParameter(programmer, bugNum, version, description, priority, bugState);
        foreach (BugInfoEntity n in result)
        {
            dt.Rows.Add(n.Version, n.BugNum, n.BugStatus, n.DealMan, n.Description, n.Priority);
        }
        if (dt.Rows.Count == 0)
            dt.Rows.Add();
        return dt;
    }
}