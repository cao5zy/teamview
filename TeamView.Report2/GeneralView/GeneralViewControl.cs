using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TeamView.Report2.GeneralView
{
    partial class GeneralViewControl : UserControl
    {
        private IBugInfoRepository _repository;
        public GeneralViewControl()
        {
            InitializeComponent();
        }

        public GeneralViewControl(IBugInfoRepository repository) : this()
        {
            _repository = repository;
        }

        private void _searchButton_Click(object sender, EventArgs e)
        {

        }
    }
}
