﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TeamView
{
    public partial class SimpleEditor : UserControl
    {
        private bool mIsUpdated;
        public SimpleEditor()
        {
            InitializeComponent();
            mTextBox.TextChanged += (s, e) => mIsUpdated = true;
            mFeedBackSection.Text = BugInfoManagement_Resource.mFeedBackSection;
            mSectionButton.Text = BugInfoManagement_Resource.mSectionButton;
            mNormalButton.Text = BugInfoManagement_Resource.mNormalButton;
            mBoldButton.Text = BugInfoManagement_Resource.mBoldButton;
            mGrayButton.Text = BugInfoManagement_Resource.mGrayButton;
            mMaxButton.Text = BugInfoManagement_Resource.mMaxButtonText1;
        }

        public bool IsUpdated
        {
            get
            {
                return mIsUpdated;
            }
        }

        public void Reset()
        {
            mIsUpdated = false;
        }


        private const float SECTIONSIZE = 14;
        private const float NORMALSIZE = 10;

        private Font SelectionFont
        {
            get
            {
                return mTextBox.SelectionFont == null ? mTextBox.Font : mTextBox.SelectionFont;
            }
        }

        private void mSectionButton_Click(object sender, EventArgs e)
        {
            mTextBox.SelectionFont = new Font(SelectionFont.FontFamily, SECTIONSIZE, FontStyle.Bold);
        }

        private void mNormalButton_Click(object sender, EventArgs e)
        {
            mTextBox.SelectionFont = new Font(SelectionFont.FontFamily, NORMALSIZE, FontStyle.Regular);
            mTextBox.SelectionColor = Color.Black;
        }

        private void mBoldButton_Click(object sender, EventArgs e)
        {
            mTextBox.SelectionFont = new Font(SelectionFont, FontStyle.Bold);
        }

        private void mFeedBackSection_Click(object sender, EventArgs e)
        {
            mTextBox.SelectedText = mTextBox.SelectedText + ":" + DateTime.Today.ToLongDateString();
            mTextBox.SelectionFont = new Font(SelectionFont.FontFamily, SECTIONSIZE, FontStyle.Bold);
        }

        private void mGrayButton_Click(object sender, EventArgs e)
        {
            mTextBox.SelectionColor = Color.Gray;
        }

        public event EventHandler MaxEditor;
        public event EventHandler MinEditor;
        private bool mIsMaxed = false;
        private void mMaxButton_Click(object sender, EventArgs e)
        {
            if (mIsMaxed)
            {
                if (MinEditor != null)
                    MinEditor(null, null);
                mIsMaxed = false;
                mMaxButton.Text = BugInfoManagement_Resource.mMaxButtonText1;
            }
            else
            {
                if (MaxEditor != null)
                    MaxEditor(null, null);
                mIsMaxed = true;
                mMaxButton.Text = BugInfoManagement_Resource.mMaxButtonText2;
            }
        }

        public void LoadFile(Stream stream, RichTextBoxStreamType streamType)
        {
            mTextBox.LoadFile(stream, streamType);

            Reset();
        }

        public void Load(byte[] docDetails)
        {
            if (docDetails == null || docDetails.Length == 0)
                return;

            var tempFileName = Path.GetTempFileName();
            using (var fs = new FileStream(tempFileName, FileMode.Create))
            {
                TeamView.Common.Utility.WriteBytes(docDetails, fs);
            }

            mTextBox.LoadFile(tempFileName, RichTextBoxStreamType.RichText);

            Reset();
        }

        public void SaveFile(Stream stream, RichTextBoxStreamType streamType)
        {
            mTextBox.SaveFile(stream, streamType);
        }

        public RichTextBox RichText
        {
            get
            {
                return mTextBox;
            }
        }

        public byte[] Save()
        {
            var tempFileName = Path.GetTempFileName();
            mTextBox.SaveFile(tempFileName);
            using (var fs = new FileStream(tempFileName, FileMode.Open))
            {
                byte[] docDetail = TeamView.Common.Utility.ReadBytes(fs);
                return docDetail;
            }
        }

        public void Clear()
        {
            mTextBox.Clear();
        }
    }
}
