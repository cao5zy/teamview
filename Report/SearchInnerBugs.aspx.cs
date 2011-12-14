using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Windows.Forms;

public partial class SearchInnerBugs : System.Web.UI.Page
{
    private BindingList<BindingSearchInnerBugItem> BindingSearchInnerBugs
    {
        get
        {
            if (SearchResultsGridView.DataSource == null)
                SearchResultsGridView.DataSource = new BindingList<BindingSearchInnerBugItem>();
            return (BindingList<BindingSearchInnerBugItem>)SearchResultsGridView.DataSource;
        }
    } 

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
            InitializeSearchCriteria();
    }

    private void InitializeCurrentMembers()
    {
        //ArrayList arr = new ArrayList();
        //arr.Add("曹宗颖");
        //arr.Add("方绍军");
        //arr.Add("彭长生");
        //arr.Add("成小平");
        //arr.Add("张果");
        //arr.Add("叶伟");
        //this.CurrentMembersDropDownList.DataSource = arr;
        //this.CurrentMembersDropDownList.DataBind();
        //this.CurrentMembersDropDownList.Items.Add("Please select a member.");
        //this.CurrentMembersDropDownList.Items[this.CurrentMembersDropDownList.Items.Count - 1].Value = " ";
        //this.CurrentMembersDropDownList.SelectedIndex = this.CurrentMembersDropDownList.Items.Count - 1;
    }

    private void InitializeSearchCriteria()
    {
        InitializeCurrentMembers();

        this.StartDateCalendar.Visible = false;
        this.StartDateTextBox.Enabled = false;
        this.EndDateTextBox.Enabled = false;
        this.EndDateCalendar.Visible = false;

        this.SearchResultCountLabel.Text = "0";
    }

    protected void StartDateCalendar_SelectionChanged(object sender, EventArgs e)
    {
        StartDateTextBox.Text = StartDateCalendar.SelectedDate.ToShortDateString();
        StartDateCalendar.Visible = false;
    }
    protected void EndDateCalendar_SelectionChanged(object sender, EventArgs e)
    {
        EndDateTextBox.Text = EndDateCalendar.SelectedDate.ToShortDateString();
        EndDateCalendar.Visible = false;
    }
    protected void SearchButton_Click(object sender, EventArgs e)
    {
        List<SearchInnerBugItemType> bugs = new List<SearchInnerBugItemType>();
        bugs = GetSearchInnerBugsResult();
        PopulateSearchInnerBugsResult(bugs);
        this.SearchResultsGridView.DataBind();
        SearchResultCountLabel.Text = bugs.Count.ToString();
    }

    private void PopulateSearchInnerBugsResult(IEnumerable<SearchInnerBugItemType> bugs)
    {
        foreach (var bug in bugs)
        {
            BindingSearchInnerBugItem item = new BindingSearchInnerBugItem();

            item.Version = bug.Version;
            item.BugNum = bug.BugNum;
            item.BugStatus = bug.BugStatus;
            item.DealMan = bug.DealMan;
            item.Description = bug.Description;
            item.CreatedDate = bug.CreatedTime.ToShortDateString();
            item.CreatedMan = bug.CreatedMan;

            BindingSearchInnerBugs.Add(item);
        }
    }

    private List<SearchInnerBugItemType> GetSearchInnerBugsResult()
    {
        List<SearchInnerBugItemType> searchInnerBugs = new List<SearchInnerBugItemType>();

        bool hasFirstCondition = false;

        string connString = 
            System.Configuration.ConfigurationManager.ConnectionStrings["OA_States_DBConnectionString"].ConnectionString;

        string sql = "SELECT version,bugNum,bugStatus,dealMan,description,detailDoc,createdMan,size,timeStamp,priority,createdTime FROM bugInfo WHERE";

        if (!string.IsNullOrEmpty(StartDateTextBox.Text) 
            && !string.IsNullOrEmpty(EndDateTextBox.Text))
        {
            sql += " DATEDIFF(DAYOFYEAR,'" + StartDateTextBox.Text + "',createdTime) >= 0 and DATEDIFF(DAYOFYEAR,'" + EndDateTextBox.Text + "',createdTime) <= 0";
            hasFirstCondition = true;
        }

        if (!string.IsNullOrEmpty(CurrentMembersDropDownList.SelectedItem.Text))
        {
            if (hasFirstCondition)
                sql += " and";
            hasFirstCondition = true;
            sql += " createdMan = '" + CurrentMembersDropDownList.SelectedItem.Text + "'";
        }

        using (SqlConnection conn = new SqlConnection(connString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                searchInnerBugs.Add(new SearchInnerBugItemType() { 
                    Version = reader[0].ToString(),
                    BugNum = reader[1].ToString(),
                    BugStatus = reader[2].ToString(),
                    DealMan = reader[3].ToString(),
                    Description = reader[4].ToString(),
                    CreatedMan = reader[6].ToString(),
                    Szie = int.Parse(reader[7].ToString()),
                    CreatedTime = DateTime.Parse(reader[10].ToString())
                });
            }
        }
        return searchInnerBugs;
    }

    protected void StartDateImageButton_Click(object sender, ImageClickEventArgs e)
    {
        StartDateCalendar.Visible = true;
    }
    protected void EndDateImageButton_Click(object sender, ImageClickEventArgs e)
    {
        EndDateCalendar.Visible = true;
    }

    private void ShowItemDetail()
    {
        MessageBox.Show("dddddddddddddd");
    }
    private class BindingSearchInnerBugItem
    {
        public string Version { get; set; }
        public string BugNum { get; set; }
        public string BugStatus { get; set; }
        public string DealMan { get; set; }
        public string Description { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedMan { get; set; }
    }

    private class SearchInnerBugItemType
    {
        public string Version { get; set; }
        public string BugNum { get; set; }
        public string BugStatus { get; set; }
        public string DealMan { get; set; }
        public string Description { get; set; }
        public Image DetailDoc { get; set; }
        public string CreatedMan { get; set; }
        public int Szie { get; set; }
        public DateTime timeStamp { get; set; }
        public int Priority { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
