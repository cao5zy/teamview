namespace TeamView.Report2.GeneralView
{
    partial class GeneralViewControl
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this._onlyCompletedOption = new System.Windows.Forms.CheckBox();
            this._searchButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._programmerDropdownlist = new System.Windows.Forms.ComboBox();
            this._searchEnd = new System.Windows.Forms.DateTimePicker();
            this._searchStart = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this._calButton = new System.Windows.Forms.Button();
            this._saveButton = new System.Windows.Forms.Button();
            this._loadButton = new System.Windows.Forms.Button();
            this._progressSize = new System.Windows.Forms.Label();
            this._progressSizeLabel = new System.Windows.Forms.Label();
            this._totalBurned = new System.Windows.Forms.Label();
            this._totalBurnedLabel = new System.Windows.Forms.Label();
            this._totalSize = new System.Windows.Forms.Label();
            this._totalSizeLabel = new System.Windows.Forms.Label();
            this._grid = new System.Windows.Forms.DataGridView();
            this._bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.programmerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bugNumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sizeInHoursDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.burnedHoursDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pointsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultPointDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(653, 480);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._onlyCompletedOption);
            this.panel1.Controls.Add(this._searchButton);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this._programmerDropdownlist);
            this.panel1.Controls.Add(this._searchEnd);
            this.panel1.Controls.Add(this._searchStart);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(647, 65);
            this.panel1.TabIndex = 0;
            // 
            // _onlyCompletedOption
            // 
            this._onlyCompletedOption.AutoSize = true;
            this._onlyCompletedOption.Location = new System.Drawing.Point(96, 40);
            this._onlyCompletedOption.Name = "_onlyCompletedOption";
            this._onlyCompletedOption.Size = new System.Drawing.Size(108, 16);
            this._onlyCompletedOption.TabIndex = 7;
            this._onlyCompletedOption.Text = "only completed";
            this._onlyCompletedOption.UseVisualStyleBackColor = true;
            // 
            // _searchButton
            // 
            this._searchButton.Location = new System.Drawing.Point(546, 29);
            this._searchButton.Name = "_searchButton";
            this._searchButton.Size = new System.Drawing.Size(75, 23);
            this._searchButton.TabIndex = 6;
            this._searchButton.Text = "search";
            this._searchButton.UseVisualStyleBackColor = true;
            this._searchButton.Click += new System.EventHandler(this._searchButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(288, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "end";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(288, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "start";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Programmer";
            // 
            // _programmerDropdownlist
            // 
            this._programmerDropdownlist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._programmerDropdownlist.FormattingEnabled = true;
            this._programmerDropdownlist.Location = new System.Drawing.Point(96, 3);
            this._programmerDropdownlist.Name = "_programmerDropdownlist";
            this._programmerDropdownlist.Size = new System.Drawing.Size(121, 20);
            this._programmerDropdownlist.TabIndex = 2;
            // 
            // _searchEnd
            // 
            this._searchEnd.Location = new System.Drawing.Point(329, 31);
            this._searchEnd.Name = "_searchEnd";
            this._searchEnd.Size = new System.Drawing.Size(200, 21);
            this._searchEnd.TabIndex = 1;
            // 
            // _searchStart
            // 
            this._searchStart.Location = new System.Drawing.Point(329, 3);
            this._searchStart.Name = "_searchStart";
            this._searchStart.Size = new System.Drawing.Size(200, 21);
            this._searchStart.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this._grid, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 74);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(647, 403);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this._calButton);
            this.panel2.Controls.Add(this._saveButton);
            this.panel2.Controls.Add(this._loadButton);
            this.panel2.Controls.Add(this._progressSize);
            this.panel2.Controls.Add(this._progressSizeLabel);
            this.panel2.Controls.Add(this._totalBurned);
            this.panel2.Controls.Add(this._totalBurnedLabel);
            this.panel2.Controls.Add(this._totalSize);
            this.panel2.Controls.Add(this._totalSizeLabel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 306);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(641, 94);
            this.panel2.TabIndex = 0;
            // 
            // _calButton
            // 
            this._calButton.Location = new System.Drawing.Point(470, 5);
            this._calButton.Name = "_calButton";
            this._calButton.Size = new System.Drawing.Size(75, 23);
            this._calButton.TabIndex = 8;
            this._calButton.Text = "calculate";
            this._calButton.UseVisualStyleBackColor = true;
            this._calButton.Click += new System.EventHandler(this._calButton_Click);
            // 
            // _saveButton
            // 
            this._saveButton.Location = new System.Drawing.Point(563, 34);
            this._saveButton.Name = "_saveButton";
            this._saveButton.Size = new System.Drawing.Size(75, 23);
            this._saveButton.TabIndex = 7;
            this._saveButton.Text = "save";
            this._saveButton.UseVisualStyleBackColor = true;
            this._saveButton.Click += new System.EventHandler(this._saveButton_Click);
            // 
            // _loadButton
            // 
            this._loadButton.Location = new System.Drawing.Point(563, 5);
            this._loadButton.Name = "_loadButton";
            this._loadButton.Size = new System.Drawing.Size(75, 23);
            this._loadButton.TabIndex = 6;
            this._loadButton.Text = "load";
            this._loadButton.UseVisualStyleBackColor = true;
            this._loadButton.Click += new System.EventHandler(this._loadButton_Click);
            // 
            // _progressSize
            // 
            this._progressSize.AutoSize = true;
            this._progressSize.Location = new System.Drawing.Point(100, 57);
            this._progressSize.Name = "_progressSize";
            this._progressSize.Size = new System.Drawing.Size(11, 12);
            this._progressSize.TabIndex = 5;
            this._progressSize.Text = "0";
            // 
            // _progressSizeLabel
            // 
            this._progressSizeLabel.AutoSize = true;
            this._progressSizeLabel.Location = new System.Drawing.Point(17, 57);
            this._progressSizeLabel.Name = "_progressSizeLabel";
            this._progressSizeLabel.Size = new System.Drawing.Size(77, 12);
            this._progressSizeLabel.TabIndex = 4;
            this._progressSizeLabel.Text = "total burned";
            // 
            // _totalBurned
            // 
            this._totalBurned.AutoSize = true;
            this._totalBurned.Location = new System.Drawing.Point(100, 33);
            this._totalBurned.Name = "_totalBurned";
            this._totalBurned.Size = new System.Drawing.Size(11, 12);
            this._totalBurned.TabIndex = 3;
            this._totalBurned.Text = "0";
            // 
            // _totalBurnedLabel
            // 
            this._totalBurnedLabel.AutoSize = true;
            this._totalBurnedLabel.Location = new System.Drawing.Point(17, 33);
            this._totalBurnedLabel.Name = "_totalBurnedLabel";
            this._totalBurnedLabel.Size = new System.Drawing.Size(77, 12);
            this._totalBurnedLabel.TabIndex = 2;
            this._totalBurnedLabel.Text = "total burned";
            // 
            // _totalSize
            // 
            this._totalSize.AutoSize = true;
            this._totalSize.Location = new System.Drawing.Point(100, 10);
            this._totalSize.Name = "_totalSize";
            this._totalSize.Size = new System.Drawing.Size(11, 12);
            this._totalSize.TabIndex = 1;
            this._totalSize.Text = "0";
            // 
            // _totalSizeLabel
            // 
            this._totalSizeLabel.AutoSize = true;
            this._totalSizeLabel.Location = new System.Drawing.Point(29, 10);
            this._totalSizeLabel.Name = "_totalSizeLabel";
            this._totalSizeLabel.Size = new System.Drawing.Size(65, 12);
            this._totalSizeLabel.TabIndex = 0;
            this._totalSizeLabel.Text = "total size";
            // 
            // _grid
            // 
            this._grid.AutoGenerateColumns = false;
            this._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.programmerDataGridViewTextBoxColumn,
            this.bugNumDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.sizeInHoursDataGridViewTextBoxColumn,
            this.burnedHoursDataGridViewTextBoxColumn,
            this.pointsDataGridViewTextBoxColumn,
            this.resultPointDataGridViewTextBoxColumn});
            this._grid.DataSource = this._bindingSource;
            this._grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._grid.Location = new System.Drawing.Point(3, 3);
            this._grid.Name = "_grid";
            this._grid.RowTemplate.Height = 23;
            this._grid.Size = new System.Drawing.Size(641, 297);
            this._grid.TabIndex = 1;
            // 
            // _bindingSource
            // 
            this._bindingSource.DataSource = typeof(TeamView.Report2.GeneralView.ReportEntity);
            // 
            // programmerDataGridViewTextBoxColumn
            // 
            this.programmerDataGridViewTextBoxColumn.DataPropertyName = "Programmer";
            this.programmerDataGridViewTextBoxColumn.HeaderText = "Programmer";
            this.programmerDataGridViewTextBoxColumn.Name = "programmerDataGridViewTextBoxColumn";
            // 
            // bugNumDataGridViewTextBoxColumn
            // 
            this.bugNumDataGridViewTextBoxColumn.DataPropertyName = "BugNum";
            this.bugNumDataGridViewTextBoxColumn.HeaderText = "BugNum";
            this.bugNumDataGridViewTextBoxColumn.Name = "bugNumDataGridViewTextBoxColumn";
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            // 
            // sizeInHoursDataGridViewTextBoxColumn
            // 
            this.sizeInHoursDataGridViewTextBoxColumn.DataPropertyName = "SizeInHours";
            this.sizeInHoursDataGridViewTextBoxColumn.HeaderText = "SizeInHours";
            this.sizeInHoursDataGridViewTextBoxColumn.Name = "sizeInHoursDataGridViewTextBoxColumn";
            this.sizeInHoursDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // burnedHoursDataGridViewTextBoxColumn
            // 
            this.burnedHoursDataGridViewTextBoxColumn.DataPropertyName = "BurnedHours";
            this.burnedHoursDataGridViewTextBoxColumn.HeaderText = "BurnedHours";
            this.burnedHoursDataGridViewTextBoxColumn.Name = "burnedHoursDataGridViewTextBoxColumn";
            this.burnedHoursDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pointsDataGridViewTextBoxColumn
            // 
            this.pointsDataGridViewTextBoxColumn.DataPropertyName = "Points";
            this.pointsDataGridViewTextBoxColumn.HeaderText = "Points";
            this.pointsDataGridViewTextBoxColumn.Name = "pointsDataGridViewTextBoxColumn";
            // 
            // resultPointDataGridViewTextBoxColumn
            // 
            this.resultPointDataGridViewTextBoxColumn.DataPropertyName = "ResultPoint";
            this.resultPointDataGridViewTextBoxColumn.HeaderText = "ResultPoint";
            this.resultPointDataGridViewTextBoxColumn.Name = "resultPointDataGridViewTextBoxColumn";
            // 
            // GeneralViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "GeneralViewControl";
            this.Size = new System.Drawing.Size(653, 480);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._bindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker _searchEnd;
        private System.Windows.Forms.DateTimePicker _searchStart;
        private System.Windows.Forms.ComboBox _programmerDropdownlist;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button _searchButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView _grid;
        private System.Windows.Forms.BindingSource _bindingSource;
        private System.Windows.Forms.Label _totalBurned;
        private System.Windows.Forms.Label _totalBurnedLabel;
        private System.Windows.Forms.Label _totalSize;
        private System.Windows.Forms.Label _totalSizeLabel;
        private System.Windows.Forms.Label _progressSize;
        private System.Windows.Forms.Label _progressSizeLabel;
        private System.Windows.Forms.CheckBox _onlyCompletedOption;
        private System.Windows.Forms.Button _saveButton;
        private System.Windows.Forms.Button _loadButton;
        private System.Windows.Forms.Button _calButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn programmerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bugNumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sizeInHoursDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn burnedHoursDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pointsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultPointDataGridViewTextBoxColumn;
    }
}
