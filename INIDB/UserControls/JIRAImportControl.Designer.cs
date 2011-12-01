namespace IniTeamView.UserControls
{
    partial class JIRAImportControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.mImportfilePathTextBox = new System.Windows.Forms.TextBox();
            this.mVersionTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mReporterTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mHandlerTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.mOpenFileButton = new System.Windows.Forms.Button();
            this.mImportButton = new System.Windows.Forms.Button();
            this.mImportedListBox = new System.Windows.Forms.TextBox();
            this.mBindingModel = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mBindingModel)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Import file";
            // 
            // mImportfilePathTextBox
            // 
            this.mImportfilePathTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mBindingModel, "ImportFile", true));
            this.mImportfilePathTextBox.Location = new System.Drawing.Point(88, 21);
            this.mImportfilePathTextBox.Name = "mImportfilePathTextBox";
            this.mImportfilePathTextBox.Size = new System.Drawing.Size(205, 21);
            this.mImportfilePathTextBox.TabIndex = 1;
            // 
            // mVersionTextBox
            // 
            this.mVersionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mBindingModel, "Version", true));
            this.mVersionTextBox.Location = new System.Drawing.Point(88, 48);
            this.mVersionTextBox.Name = "mVersionTextBox";
            this.mVersionTextBox.Size = new System.Drawing.Size(100, 21);
            this.mVersionTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Version";
            // 
            // mReporterTextBox
            // 
            this.mReporterTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mBindingModel, "Reporter", true));
            this.mReporterTextBox.Location = new System.Drawing.Point(88, 75);
            this.mReporterTextBox.Name = "mReporterTextBox";
            this.mReporterTextBox.Size = new System.Drawing.Size(100, 21);
            this.mReporterTextBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Reporter";
            // 
            // mHandlerTextBox
            // 
            this.mHandlerTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mBindingModel, "Handler", true));
            this.mHandlerTextBox.Location = new System.Drawing.Point(88, 102);
            this.mHandlerTextBox.Name = "mHandlerTextBox";
            this.mHandlerTextBox.Size = new System.Drawing.Size(100, 21);
            this.mHandlerTextBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "Handler";
            // 
            // mOpenFileButton
            // 
            this.mOpenFileButton.Location = new System.Drawing.Point(299, 19);
            this.mOpenFileButton.Name = "mOpenFileButton";
            this.mOpenFileButton.Size = new System.Drawing.Size(26, 23);
            this.mOpenFileButton.TabIndex = 10;
            this.mOpenFileButton.Text = "..";
            this.mOpenFileButton.UseVisualStyleBackColor = true;
            this.mOpenFileButton.Click += new System.EventHandler(this.mOpenFileButton_Click);
            // 
            // mImportButton
            // 
            this.mImportButton.Location = new System.Drawing.Point(270, 167);
            this.mImportButton.Name = "mImportButton";
            this.mImportButton.Size = new System.Drawing.Size(55, 23);
            this.mImportButton.TabIndex = 11;
            this.mImportButton.Text = "Import";
            this.mImportButton.UseVisualStyleBackColor = true;
            this.mImportButton.Click += new System.EventHandler(this.mImportButton_Click);
            // 
            // mImportedListBox
            // 
            this.mImportedListBox.Location = new System.Drawing.Point(88, 129);
            this.mImportedListBox.Multiline = true;
            this.mImportedListBox.Name = "mImportedListBox";
            this.mImportedListBox.ReadOnly = true;
            this.mImportedListBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.mImportedListBox.Size = new System.Drawing.Size(100, 61);
            this.mImportedListBox.TabIndex = 12;
            // 
            // mBindingModel
            // 
            this.mBindingModel.DataSource = typeof(IniTeamView.UserControls.JIRAImportModel);
            // 
            // JIRAImportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mImportedListBox);
            this.Controls.Add(this.mImportButton);
            this.Controls.Add(this.mOpenFileButton);
            this.Controls.Add(this.mHandlerTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mReporterTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mVersionTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mImportfilePathTextBox);
            this.Controls.Add(this.label1);
            this.Name = "JIRAImportControl";
            this.Size = new System.Drawing.Size(333, 196);
            this.Load += new System.EventHandler(this.JIRAImportControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mBindingModel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox mImportfilePathTextBox;
        private System.Windows.Forms.TextBox mVersionTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox mReporterTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox mHandlerTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button mOpenFileButton;
        private System.Windows.Forms.Button mImportButton;
        private System.Windows.Forms.BindingSource mBindingModel;
        private System.Windows.Forms.TextBox mImportedListBox;
    }
}
