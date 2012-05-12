using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TeamView.Report2.GeneralView;

namespace TeamView.Report2
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void generalViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddControl(Factory.Instance.Resolve<GeneralViewControl>());
        }

        private void AddControl(Control ctrl)
        {
            _containerPanel.Controls.Clear();
            _containerPanel.Controls.Add(ctrl);
            ctrl.Dock = DockStyle.Fill;

        }
    }
}
