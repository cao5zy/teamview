using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TeamView.Common
{
    public partial class CommonForm<T> : Form where T:Control
    {
        public CommonForm()
        {
            InitializeComponent();

            this.Load +=new EventHandler(CommonForm_Load);
        }

        private Action<T> _init;
        private T _component;
        public CommonForm(T component, Action<T> init):this()
        {
            component.Dock = DockStyle.Fill;
            this.Controls.Add(component);

            _component = component;
            _init = init;
        }

        private void CommonForm_Load(object s, EventArgs e)
        {
            if (_init != null)
                _init(_component);
        }
    }
}
