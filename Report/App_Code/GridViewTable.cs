using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for GridViewTable
/// </summary>
/// 

public class GridViewTable
{
    private DataTable dt = new DataTable();
    public DataTable GetDaTaTable()
    {
        return dt;
    }
    public GridViewTable()
    {
        dt.Columns.Add("Version");
        dt.Columns.Add("Bug Number");
        dt.Columns.Add("Status");
        dt.Columns.Add("Bug Dealer");
        dt.Columns.Add("Description");
        dt.Columns.Add("Priority");
        dt.Columns.Add("Date");
    }
}
