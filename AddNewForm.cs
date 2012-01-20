using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TeamView.Common.Models;
using TeamView.Common.Entity;
using TeamView.Common;
using System.Text.RegularExpressions;
using System.IO;
using TeamView.Common.Dao;

namespace TeamView
{
    public partial class AddNewForm : Form
    {
        public AddNewForm()
        {
            InitializeComponent();
        }

        private BugInfoViewModel _model;
        private KeyModel _keyModel;
        private IBugInfoRepository _repository;
        public delegate AddNewForm Factory();

        
        public AddNewForm(BugInfoViewModel model,
            KeyModel keyModel,
            IBugInfoRepository repository
            )
            : this()
        {
            _model = model;
            _keyModel = keyModel;
            _repository = repository;
        }

        public const string InCorrectFormatNumber = "不正确的任务编号，任务编号的格式应该为[Category]-*";
        private void mAddButton_Click(object sender, EventArgs e)
        {
            var formatNum = GetHeadInfo();
            if (!formatNum.State)
            {
                MessageBox.Show(formatNum.ErrorInfo);
                return;
            }

            _model.New();

            _model.Current.bugNum = IsValidCompleteNumber(formatNum.ItemNumber)
                ? formatNum.ItemNumber
                : _keyModel.GenerateKey(headerCategory.Match(formatNum.ItemNumber).Value);
            _model.Current.bugStatus = States.Pending;
            _model.Current.createdTime = DateTime.Now;
            _model.Current.dealMan = GetCurrentLogin();
            _model.Current.description = formatNum.Description;
            _model.Current.fired = 0;
            _model.Current.hardLevel = GetDefaulHardLevel();
            _model.Current.lastStateTime = DateTime.MinValue;
            _model.Current.moveSequence = 0;
            _model.Current.priority = formatNum.Priority;
            _model.Current.size = formatNum.Size;
            _model.Current.version = formatNum.Version;

            var checkResult = _model.SaveCheck();
            if (!string.IsNullOrEmpty(checkResult))
            {
                MessageBox.Show(checkResult);
                return;
            }

            var saveResult = _model.Save();

            _repository.UpdateItem(saveResult.Object);

            _model.SaveDoc(GetDoc());

            Close();
        }

        private readonly Regex completeNumberFormat = new Regex(@"\w+-\d+");
        private bool IsValidCompleteNumber(string itemNumber)
        {
            return completeNumberFormat.IsMatch(itemNumber);
        }

        private readonly Regex validNumberFormat = new Regex(@"(\w+)(-\d+)?");
        private readonly Regex headerCategory = new Regex(@"\w+");

        private byte[] GetDoc()
        {
            int pos = 0;
            for (int i = 0; i < 5; i++)
            {
                pos = mContentRichTextBox.Find(new char[] { '\r' }, ++pos);
            }

            mContentRichTextBox.Select(0, pos);
            mContentRichTextBox.SelectionStart = 0;
            mContentRichTextBox.SelectionLength = pos;
            mContentRichTextBox.SelectedRtf = string.Empty;

            string filePath = Path.GetTempFileName();
            mContentRichTextBox.SaveFile(filePath, RichTextBoxStreamType.RichText);

            byte[] fsBytes;
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                fsBytes = TeamView.Common.Utility.ReadBytes(fs);
            }

            return fsBytes;
        }

        private int GetDefaulHardLevel()
        {
            return 2;
        }

        private string GetCurrentLogin()
        {
            return "曹宗颖";
        }

        class HeadInfo
        {
            public string Description { get; set; }
            public string ItemNumber { get; set; }
            public string Version { get; set; }
            public int Priority { get; set; }
            public int Size { get; set; }
            public bool State { get; set; }
            public string ErrorInfo { get; set; }
        }

        private const string NotInclideHeadLines = "未包含任务头信息";
        private const string PriorityNumberErrorInfo = "第二行应该为优先级，数字";
        private const string SizeNumberErrorInfo = "第三行应该为估计小时数，数字";
        private const string ItemNumberErrorInfo = "Item Number的格式不正确，其格式应该类似于a-1或a";

        private HeadInfo GetHeadInfo()
        {
            /*
             * format:
             * the description of the task; first line
             * priority number;second line
             * estimated size;third line
             * version number;fourth line
             * item number;fifth line
             */
            var lines = mContentRichTextBox.Lines;
            if(lines == null || lines.Length < 5)
            {
                return new HeadInfo{
                    State = false,
                    ErrorInfo = NotInclideHeadLines,
                };
            }

            int n;
            if (!int.TryParse(lines.ElementAt(1), out n))
            {
                return new HeadInfo {
                    ErrorInfo = PriorityNumberErrorInfo
                };
            }

            if(!int.TryParse(lines.ElementAt(2), out n))
            {
                return new HeadInfo{
                    ErrorInfo = SizeNumberErrorInfo
                };
            }

            if (!validNumberFormat.IsMatch(lines.ElementAt(4)))
            {
                return new HeadInfo {
                    ErrorInfo = ItemNumberErrorInfo
                };
            }

            var headLines = lines.Take(5);

            return new HeadInfo { 
                Description = headLines.ElementAt(0),
                Priority = Convert.ToInt32(headLines.ElementAt(1)),
                Size = Convert.ToInt32(headLines.ElementAt(2)),
                Version = headLines.ElementAt(3),
                ItemNumber = headLines.ElementAt(4),
                State = true
            };
        }

        private void mCheckButton_Click(object sender, EventArgs e)
        {
            var headInfo = GetHeadInfo();

            if (!headInfo.State)
            {
                MessageBox.Show(headInfo.ErrorInfo);
                return;
            }

            int pos = 0;
            for (int i = 0; i < 5; i++)
            {
                pos = mContentRichTextBox.Find(new char[]{'\r'}, ++pos);
            }

            mContentRichTextBox.Select(0, pos);
            mContentRichTextBox.SelectionStart = 0;
            mContentRichTextBox.SelectionLength = pos;
            mContentRichTextBox.SelectionBackColor = Color.Black;
            mContentRichTextBox.SelectionColor = Color.White;
        }

        private void mHintButton_Click(object sender, EventArgs e)
        {
            string headerHints = @"task description
priority:int
size:int
version
item number:a/a-*/a-1
";

            mContentRichTextBox.SelectionStart = 0;
            mContentRichTextBox.SelectionLength = 0;
            mContentRichTextBox.SelectedText = headerHints;
        }
    }
}
