using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FxLib.Algorithms;

namespace IniTeamView.UserControls
{
    public partial class JIRAImportControl : UserControl
    {
        public JIRAImportControl()
        {
            InitializeComponent();
        }

        private JIRAImportController mController;

        public JIRAImportControl(JIRAImportController controller)
            : this()
        {
            mController = controller;
        }

        private void mOpenFileButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDlg = new OpenFileDialog())
            {
                if (fileDlg.ShowDialog() == DialogResult.OK)
                {
                    mImportfilePathTextBox.Text = fileDlg.FileName;
                    mBindingModel.EndEdit();
                }
            }
        }

        private void mImportButton_Click(object sender, EventArgs e)
        {
            mBindingModel.CurrencyManager.EndCurrentEdit();

            mController.Import((JIRAImportModel)mBindingModel.Current);

            mImportedListBox.Text = mController.ImportedList.SafeCount() == 0 ?
                "None is imported"
                : string.Join("\r\n", mController.ImportedList.ToArray())
                + "\r\n"
                + "Imported";
        }

        private void JIRAImportControl_Load(object sender, EventArgs e)
        {
            mBindingModel.AddNew();
        }

    }
}
