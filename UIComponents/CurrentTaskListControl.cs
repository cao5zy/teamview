using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TeamView.Controllers;
using TeamView.Common.Entity;

namespace TeamView.UIComponents
{
    public partial class CurrentTaskListControl : UserControl
    {
        public CurrentTaskListControl()
        {
            InitializeComponent();
        }
        private TaskController _taskController;
        public delegate CurrentTaskListControl Factory();
        public CurrentTaskListControl(TaskController taskController)
            : this()
        {
            _taskController = taskController;
        }

        public void Load(string userName)
        {
            List<BugInfoEntity1> items = _taskController.LoadCurrentTask(userName);

            var tb = BugInfoEntity1.ToDataTable(items);

            tb.Columns.Add(new DataColumn {
                DefaultValue = false,
                ColumnName="selected",
                DataType = typeof(bool)
            });

            _grid.DataSource = tb.DefaultView;

        }
    }
}
