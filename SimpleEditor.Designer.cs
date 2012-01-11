namespace TeamView
{
    partial class SimpleEditor
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mMaxButton = new System.Windows.Forms.Button();
            this.mGrayButton = new System.Windows.Forms.Button();
            this.mFeedBackSection = new System.Windows.Forms.Button();
            this.mBoldButton = new System.Windows.Forms.Button();
            this.mNormalButton = new System.Windows.Forms.Button();
            this.mSectionButton = new System.Windows.Forms.Button();
            this.mTextBox = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.mTextBox, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(393, 344);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.mMaxButton);
            this.panel1.Controls.Add(this.mGrayButton);
            this.panel1.Controls.Add(this.mFeedBackSection);
            this.panel1.Controls.Add(this.mBoldButton);
            this.panel1.Controls.Add(this.mNormalButton);
            this.panel1.Controls.Add(this.mSectionButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(387, 34);
            this.panel1.TabIndex = 0;
            // 
            // mMaxButton
            // 
            this.mMaxButton.Location = new System.Drawing.Point(326, 3);
            this.mMaxButton.Name = "mMaxButton";
            this.mMaxButton.Size = new System.Drawing.Size(58, 23);
            this.mMaxButton.TabIndex = 5;
            this.mMaxButton.Text = "Max";
            this.mMaxButton.UseVisualStyleBackColor = true;
            this.mMaxButton.Click += new System.EventHandler(this.mMaxButton_Click);
            // 
            // mGrayButton
            // 
            this.mGrayButton.Location = new System.Drawing.Point(263, 3);
            this.mGrayButton.Name = "mGrayButton";
            this.mGrayButton.Size = new System.Drawing.Size(57, 23);
            this.mGrayButton.TabIndex = 4;
            this.mGrayButton.Text = "Gray";
            this.mGrayButton.UseVisualStyleBackColor = true;
            this.mGrayButton.Click += new System.EventHandler(this.mGrayButton_Click);
            // 
            // mFeedBackSection
            // 
            this.mFeedBackSection.Location = new System.Drawing.Point(6, 3);
            this.mFeedBackSection.Name = "mFeedBackSection";
            this.mFeedBackSection.Size = new System.Drawing.Size(61, 23);
            this.mFeedBackSection.TabIndex = 3;
            this.mFeedBackSection.Text = "Feedback";
            this.mFeedBackSection.UseVisualStyleBackColor = true;
            this.mFeedBackSection.Click += new System.EventHandler(this.mFeedBackSection_Click);
            // 
            // mBoldButton
            // 
            this.mBoldButton.Location = new System.Drawing.Point(201, 3);
            this.mBoldButton.Name = "mBoldButton";
            this.mBoldButton.Size = new System.Drawing.Size(56, 23);
            this.mBoldButton.TabIndex = 2;
            this.mBoldButton.Text = "Bold";
            this.mBoldButton.UseVisualStyleBackColor = true;
            this.mBoldButton.Click += new System.EventHandler(this.mBoldButton_Click);
            // 
            // mNormalButton
            // 
            this.mNormalButton.Location = new System.Drawing.Point(139, 3);
            this.mNormalButton.Name = "mNormalButton";
            this.mNormalButton.Size = new System.Drawing.Size(56, 23);
            this.mNormalButton.TabIndex = 1;
            this.mNormalButton.Text = "Normal";
            this.mNormalButton.UseVisualStyleBackColor = true;
            this.mNormalButton.Click += new System.EventHandler(this.mNormalButton_Click);
            // 
            // mSectionButton
            // 
            this.mSectionButton.Location = new System.Drawing.Point(73, 3);
            this.mSectionButton.Name = "mSectionButton";
            this.mSectionButton.Size = new System.Drawing.Size(60, 23);
            this.mSectionButton.TabIndex = 0;
            this.mSectionButton.Text = "Title";
            this.mSectionButton.UseVisualStyleBackColor = true;
            this.mSectionButton.Click += new System.EventHandler(this.mSectionButton_Click);
            // 
            // mTextBox
            // 
            this.mTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mTextBox.Location = new System.Drawing.Point(3, 43);
            this.mTextBox.Name = "mTextBox";
            this.mTextBox.Size = new System.Drawing.Size(387, 298);
            this.mTextBox.TabIndex = 1;
            this.mTextBox.Text = "";
            // 
            // SimpleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SimpleEditor";
            this.Size = new System.Drawing.Size(393, 344);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox mTextBox;
        private System.Windows.Forms.Button mSectionButton;
        private System.Windows.Forms.Button mNormalButton;
        private System.Windows.Forms.Button mBoldButton;
        private System.Windows.Forms.Button mFeedBackSection;
        private System.Windows.Forms.Button mGrayButton;
        private System.Windows.Forms.Button mMaxButton;
    }
}
