namespace TeamView
{
    partial class AddNewForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mCheckButton = new System.Windows.Forms.Button();
            this.mAddButton = new System.Windows.Forms.Button();
            this.mContentRichTextBox = new System.Windows.Forms.RichTextBox();
            this.mHintButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.mContentRichTextBox, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(456, 338);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.mHintButton);
            this.panel1.Controls.Add(this.mCheckButton);
            this.panel1.Controls.Add(this.mAddButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 304);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 31);
            this.panel1.TabIndex = 0;
            // 
            // mCheckButton
            // 
            this.mCheckButton.Location = new System.Drawing.Point(291, 3);
            this.mCheckButton.Name = "mCheckButton";
            this.mCheckButton.Size = new System.Drawing.Size(75, 23);
            this.mCheckButton.TabIndex = 1;
            this.mCheckButton.Text = "Check";
            this.mCheckButton.UseVisualStyleBackColor = true;
            this.mCheckButton.Click += new System.EventHandler(this.mCheckButton_Click);
            // 
            // mAddButton
            // 
            this.mAddButton.Location = new System.Drawing.Point(372, 3);
            this.mAddButton.Name = "mAddButton";
            this.mAddButton.Size = new System.Drawing.Size(75, 23);
            this.mAddButton.TabIndex = 0;
            this.mAddButton.Text = "Add";
            this.mAddButton.UseVisualStyleBackColor = true;
            this.mAddButton.Click += new System.EventHandler(this.mAddButton_Click);
            // 
            // mContentRichTextBox
            // 
            this.mContentRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mContentRichTextBox.Location = new System.Drawing.Point(3, 3);
            this.mContentRichTextBox.Name = "mContentRichTextBox";
            this.mContentRichTextBox.Size = new System.Drawing.Size(450, 295);
            this.mContentRichTextBox.TabIndex = 1;
            this.mContentRichTextBox.Text = "";
            // 
            // mHintButton
            // 
            this.mHintButton.Location = new System.Drawing.Point(210, 3);
            this.mHintButton.Name = "mHintButton";
            this.mHintButton.Size = new System.Drawing.Size(75, 23);
            this.mHintButton.TabIndex = 2;
            this.mHintButton.Text = "Hint";
            this.mHintButton.UseVisualStyleBackColor = true;
            this.mHintButton.Click += new System.EventHandler(this.mHintButton_Click);
            // 
            // AddNewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 338);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AddNewForm";
            this.Text = "Add New";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button mAddButton;
        private System.Windows.Forms.RichTextBox mContentRichTextBox;
        private System.Windows.Forms.Button mCheckButton;
        private System.Windows.Forms.Button mHintButton;
    }
}