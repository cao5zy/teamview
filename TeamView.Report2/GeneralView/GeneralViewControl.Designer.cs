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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this._searchButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._programmerDropdownlist = new System.Windows.Forms.ComboBox();
            this._dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this._dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this._grid = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._grid)).BeginInit();
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
            this.panel1.Controls.Add(this._searchButton);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this._programmerDropdownlist);
            this.panel1.Controls.Add(this._dateTimePicker2);
            this.panel1.Controls.Add(this._dateTimePicker1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(647, 65);
            this.panel1.TabIndex = 0;
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
            this._programmerDropdownlist.FormattingEnabled = true;
            this._programmerDropdownlist.Location = new System.Drawing.Point(96, 3);
            this._programmerDropdownlist.Name = "_programmerDropdownlist";
            this._programmerDropdownlist.Size = new System.Drawing.Size(121, 20);
            this._programmerDropdownlist.TabIndex = 2;
            // 
            // _dateTimePicker2
            // 
            this._dateTimePicker2.Location = new System.Drawing.Point(329, 31);
            this._dateTimePicker2.Name = "_dateTimePicker2";
            this._dateTimePicker2.Size = new System.Drawing.Size(200, 21);
            this._dateTimePicker2.TabIndex = 1;
            // 
            // _dateTimePicker1
            // 
            this._dateTimePicker1.Location = new System.Drawing.Point(329, 3);
            this._dateTimePicker1.Name = "_dateTimePicker1";
            this._dateTimePicker1.Size = new System.Drawing.Size(200, 21);
            this._dateTimePicker1.TabIndex = 0;
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
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 306);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(641, 94);
            this.panel2.TabIndex = 0;
            // 
            // _grid
            // 
            this._grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._grid.Location = new System.Drawing.Point(3, 3);
            this._grid.Name = "_grid";
            this._grid.RowTemplate.Height = 23;
            this._grid.Size = new System.Drawing.Size(641, 297);
            this._grid.TabIndex = 1;
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
            ((System.ComponentModel.ISupportInitialize)(this._grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker _dateTimePicker2;
        private System.Windows.Forms.DateTimePicker _dateTimePicker1;
        private System.Windows.Forms.ComboBox _programmerDropdownlist;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button _searchButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView _grid;
    }
}
