namespace BHHC_ACCOUNTING
{
    partial class PreviewExcelFile
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreviewExcelFile));
            this.dataGridViewStates = new System.Windows.Forms.DataGridView();
            this.buttonExportExcelFile = new System.Windows.Forms.Button();
            this.labelReportName = new System.Windows.Forms.Label();
            this.buttonFilter = new System.Windows.Forms.Button();
            this.buttonClearFilter = new System.Windows.Forms.Button();
            this.labelRowCountStates = new System.Windows.Forms.Label();
            this.dataGridViewNonStates = new System.Windows.Forms.DataGridView();
            this.labelRowCountNonStates = new System.Windows.Forms.Label();
            this.labelStates = new System.Windows.Forms.Label();
            this.labelNonStates = new System.Windows.Forms.Label();
            this.checkedListBoxSelectCompany = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxSelectYear = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxSelectQuarter = new System.Windows.Forms.CheckedListBox();
            this.labelSelectInstructions = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.checkBoxSelectAllCompany = new System.Windows.Forms.CheckBox();
            this.checkBoxSelectAllYear = new System.Windows.Forms.CheckBox();
            this.checkBoxSelectAllQuarter = new System.Windows.Forms.CheckBox();
            this.groupBoxCompany = new System.Windows.Forms.GroupBox();
            this.groupBoxYear = new System.Windows.Forms.GroupBox();
            this.groupBoxQuarter = new System.Windows.Forms.GroupBox();
            this.buttonRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNonStates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBoxCompany.SuspendLayout();
            this.groupBoxYear.SuspendLayout();
            this.groupBoxQuarter.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewStates
            // 
            this.dataGridViewStates.AllowUserToAddRows = false;
            this.dataGridViewStates.AllowUserToDeleteRows = false;
            this.dataGridViewStates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewStates.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewStates.Location = new System.Drawing.Point(186, 91);
            this.dataGridViewStates.Name = "dataGridViewStates";
            this.dataGridViewStates.ReadOnly = true;
            this.dataGridViewStates.RowHeadersVisible = false;
            this.dataGridViewStates.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewStates.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStates.Size = new System.Drawing.Size(949, 273);
            this.dataGridViewStates.TabIndex = 2;
            this.dataGridViewStates.VirtualMode = true;
            this.dataGridViewStates.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewExcelPreview_CellContentClick);
            // 
            // buttonExportExcelFile
            // 
            this.buttonExportExcelFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExportExcelFile.Location = new System.Drawing.Point(1016, 728);
            this.buttonExportExcelFile.Name = "buttonExportExcelFile";
            this.buttonExportExcelFile.Size = new System.Drawing.Size(119, 25);
            this.buttonExportExcelFile.TabIndex = 3;
            this.buttonExportExcelFile.Text = "&Export";
            this.buttonExportExcelFile.UseVisualStyleBackColor = true;
            this.buttonExportExcelFile.Click += new System.EventHandler(this.buttonExportExcelFile_Click_1);
            // 
            // labelReportName
            // 
            this.labelReportName.AutoSize = true;
            this.labelReportName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReportName.Location = new System.Drawing.Point(182, 27);
            this.labelReportName.Name = "labelReportName";
            this.labelReportName.Size = new System.Drawing.Size(314, 24);
            this.labelReportName.TabIndex = 6;
            this.labelReportName.Text = "FDB - Finance Quarterly Reports";
            this.labelReportName.Click += new System.EventHandler(this.labelReportName_Click_1);
            // 
            // buttonFilter
            // 
            this.buttonFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFilter.Location = new System.Drawing.Point(12, 632);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Size = new System.Drawing.Size(60, 23);
            this.buttonFilter.TabIndex = 13;
            this.buttonFilter.Text = "&Filter";
            this.buttonFilter.UseVisualStyleBackColor = true;
            this.buttonFilter.Click += new System.EventHandler(this.buttonFilter_Click);
            // 
            // buttonClearFilter
            // 
            this.buttonClearFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClearFilter.Location = new System.Drawing.Point(105, 632);
            this.buttonClearFilter.Name = "buttonClearFilter";
            this.buttonClearFilter.Size = new System.Drawing.Size(65, 23);
            this.buttonClearFilter.TabIndex = 14;
            this.buttonClearFilter.Text = "&Clear";
            this.buttonClearFilter.UseVisualStyleBackColor = true;
            this.buttonClearFilter.Click += new System.EventHandler(this.buttonClearFilter_Click);
            // 
            // labelRowCountStates
            // 
            this.labelRowCountStates.AutoSize = true;
            this.labelRowCountStates.Location = new System.Drawing.Point(1074, 367);
            this.labelRowCountStates.Name = "labelRowCountStates";
            this.labelRowCountStates.Size = new System.Drawing.Size(43, 13);
            this.labelRowCountStates.TabIndex = 15;
            this.labelRowCountStates.Text = "0 Rows";
            this.labelRowCountStates.Click += new System.EventHandler(this.labelRowCount_Click);
            // 
            // dataGridViewNonStates
            // 
            this.dataGridViewNonStates.AllowUserToAddRows = false;
            this.dataGridViewNonStates.AllowUserToDeleteRows = false;
            this.dataGridViewNonStates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewNonStates.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewNonStates.Location = new System.Drawing.Point(186, 421);
            this.dataGridViewNonStates.Name = "dataGridViewNonStates";
            this.dataGridViewNonStates.ReadOnly = true;
            this.dataGridViewNonStates.RowHeadersVisible = false;
            this.dataGridViewNonStates.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewNonStates.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewNonStates.Size = new System.Drawing.Size(949, 272);
            this.dataGridViewNonStates.TabIndex = 16;
            this.dataGridViewNonStates.VirtualMode = true;
            this.dataGridViewNonStates.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewNonStates_CellContentClick);
            // 
            // labelRowCountNonStates
            // 
            this.labelRowCountNonStates.AutoSize = true;
            this.labelRowCountNonStates.Location = new System.Drawing.Point(1064, 696);
            this.labelRowCountNonStates.Name = "labelRowCountNonStates";
            this.labelRowCountNonStates.Size = new System.Drawing.Size(43, 13);
            this.labelRowCountNonStates.TabIndex = 17;
            this.labelRowCountNonStates.Text = "0 Rows";
            // 
            // labelStates
            // 
            this.labelStates.AutoSize = true;
            this.labelStates.Location = new System.Drawing.Point(183, 66);
            this.labelStates.Name = "labelStates";
            this.labelStates.Size = new System.Drawing.Size(37, 13);
            this.labelStates.TabIndex = 18;
            this.labelStates.Text = "States";
            this.labelStates.Click += new System.EventHandler(this.labelStates_Click);
            // 
            // labelNonStates
            // 
            this.labelNonStates.AutoSize = true;
            this.labelNonStates.Location = new System.Drawing.Point(183, 396);
            this.labelNonStates.Name = "labelNonStates";
            this.labelNonStates.Size = new System.Drawing.Size(60, 13);
            this.labelNonStates.TabIndex = 19;
            this.labelNonStates.Text = "Non States";
            this.labelNonStates.Click += new System.EventHandler(this.labelNonStates_Click);
            // 
            // checkedListBoxSelectCompany
            // 
            this.checkedListBoxSelectCompany.BackColor = System.Drawing.SystemColors.Menu;
            this.checkedListBoxSelectCompany.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBoxSelectCompany.CheckOnClick = true;
            this.checkedListBoxSelectCompany.FormattingEnabled = true;
            this.checkedListBoxSelectCompany.Location = new System.Drawing.Point(8, 39);
            this.checkedListBoxSelectCompany.Name = "checkedListBoxSelectCompany";
            this.checkedListBoxSelectCompany.Size = new System.Drawing.Size(132, 90);
            this.checkedListBoxSelectCompany.TabIndex = 20;
            this.checkedListBoxSelectCompany.ThreeDCheckBoxes = true;
            this.checkedListBoxSelectCompany.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged_1);
            // 
            // checkedListBoxSelectYear
            // 
            this.checkedListBoxSelectYear.BackColor = System.Drawing.SystemColors.MenuBar;
            this.checkedListBoxSelectYear.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBoxSelectYear.CheckOnClick = true;
            this.checkedListBoxSelectYear.FormattingEnabled = true;
            this.checkedListBoxSelectYear.Location = new System.Drawing.Point(8, 37);
            this.checkedListBoxSelectYear.Name = "checkedListBoxSelectYear";
            this.checkedListBoxSelectYear.Size = new System.Drawing.Size(146, 75);
            this.checkedListBoxSelectYear.TabIndex = 21;
            this.checkedListBoxSelectYear.ThreeDCheckBoxes = true;
            this.checkedListBoxSelectYear.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxSelectYear_SelectedIndexChanged);
            // 
            // checkedListBoxSelectQuarter
            // 
            this.checkedListBoxSelectQuarter.BackColor = System.Drawing.SystemColors.MenuBar;
            this.checkedListBoxSelectQuarter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBoxSelectQuarter.CheckOnClick = true;
            this.checkedListBoxSelectQuarter.FormattingEnabled = true;
            this.checkedListBoxSelectQuarter.Location = new System.Drawing.Point(6, 38);
            this.checkedListBoxSelectQuarter.Name = "checkedListBoxSelectQuarter";
            this.checkedListBoxSelectQuarter.Size = new System.Drawing.Size(138, 75);
            this.checkedListBoxSelectQuarter.TabIndex = 22;
            this.checkedListBoxSelectQuarter.ThreeDCheckBoxes = true;
            this.checkedListBoxSelectQuarter.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxSelectQuarter_SelectedIndexChanged);
            // 
            // labelSelectInstructions
            // 
            this.labelSelectInstructions.AutoSize = true;
            this.labelSelectInstructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectInstructions.Location = new System.Drawing.Point(9, 123);
            this.labelSelectInstructions.Name = "labelSelectInstructions";
            this.labelSelectInstructions.Size = new System.Drawing.Size(90, 13);
            this.labelSelectInstructions.TabIndex = 26;
            this.labelSelectInstructions.Text = "Select to Filter";
            this.labelSelectInstructions.Click += new System.EventHandler(this.labelSelectInstructions_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BHHC_ACCOUNTING.Properties.Resources.berkshire_hathaway_homestate_companies_squarelogo;
            this.pictureBox1.Location = new System.Drawing.Point(15, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(86, 76);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // checkBoxSelectAllCompany
            // 
            this.checkBoxSelectAllCompany.AutoSize = true;
            this.checkBoxSelectAllCompany.Location = new System.Drawing.Point(8, 21);
            this.checkBoxSelectAllCompany.Name = "checkBoxSelectAllCompany";
            this.checkBoxSelectAllCompany.Size = new System.Drawing.Size(76, 17);
            this.checkBoxSelectAllCompany.TabIndex = 28;
            this.checkBoxSelectAllCompany.Text = "(Select All)";
            this.checkBoxSelectAllCompany.UseVisualStyleBackColor = true;
            this.checkBoxSelectAllCompany.CheckedChanged += new System.EventHandler(this.checkBoxSelectAllCompany_CheckedChanged);
            // 
            // checkBoxSelectAllYear
            // 
            this.checkBoxSelectAllYear.AutoSize = true;
            this.checkBoxSelectAllYear.Location = new System.Drawing.Point(8, 19);
            this.checkBoxSelectAllYear.Name = "checkBoxSelectAllYear";
            this.checkBoxSelectAllYear.Size = new System.Drawing.Size(76, 17);
            this.checkBoxSelectAllYear.TabIndex = 29;
            this.checkBoxSelectAllYear.Text = "(Select All)";
            this.checkBoxSelectAllYear.UseVisualStyleBackColor = true;
            this.checkBoxSelectAllYear.CheckedChanged += new System.EventHandler(this.checkBoxSelectAllYear_CheckedChanged);
            // 
            // checkBoxSelectAllQuarter
            // 
            this.checkBoxSelectAllQuarter.AutoSize = true;
            this.checkBoxSelectAllQuarter.Location = new System.Drawing.Point(6, 19);
            this.checkBoxSelectAllQuarter.Name = "checkBoxSelectAllQuarter";
            this.checkBoxSelectAllQuarter.Size = new System.Drawing.Size(76, 17);
            this.checkBoxSelectAllQuarter.TabIndex = 30;
            this.checkBoxSelectAllQuarter.Text = "(Select All)";
            this.checkBoxSelectAllQuarter.UseVisualStyleBackColor = true;
            this.checkBoxSelectAllQuarter.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // groupBoxCompany
            // 
            this.groupBoxCompany.Controls.Add(this.checkBoxSelectAllCompany);
            this.groupBoxCompany.Controls.Add(this.checkedListBoxSelectCompany);
            this.groupBoxCompany.Location = new System.Drawing.Point(12, 151);
            this.groupBoxCompany.Name = "groupBoxCompany";
            this.groupBoxCompany.Padding = new System.Windows.Forms.Padding(5);
            this.groupBoxCompany.Size = new System.Drawing.Size(158, 158);
            this.groupBoxCompany.TabIndex = 31;
            this.groupBoxCompany.TabStop = false;
            this.groupBoxCompany.Text = "&Company";
            // 
            // groupBoxYear
            // 
            this.groupBoxYear.Controls.Add(this.checkBoxSelectAllYear);
            this.groupBoxYear.Controls.Add(this.checkedListBoxSelectYear);
            this.groupBoxYear.Location = new System.Drawing.Point(12, 337);
            this.groupBoxYear.Name = "groupBoxYear";
            this.groupBoxYear.Size = new System.Drawing.Size(157, 124);
            this.groupBoxYear.TabIndex = 32;
            this.groupBoxYear.TabStop = false;
            this.groupBoxYear.Text = "&Year";
            // 
            // groupBoxQuarter
            // 
            this.groupBoxQuarter.Controls.Add(this.checkBoxSelectAllQuarter);
            this.groupBoxQuarter.Controls.Add(this.checkedListBoxSelectQuarter);
            this.groupBoxQuarter.Location = new System.Drawing.Point(12, 485);
            this.groupBoxQuarter.Name = "groupBoxQuarter";
            this.groupBoxQuarter.Size = new System.Drawing.Size(157, 129);
            this.groupBoxQuarter.TabIndex = 33;
            this.groupBoxQuarter.TabStop = false;
            this.groupBoxQuarter.Text = "&Quarter";
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(1060, 56);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
            this.buttonRefresh.TabIndex = 34;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // PreviewExcelFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 775);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.groupBoxQuarter);
            this.Controls.Add(this.groupBoxYear);
            this.Controls.Add(this.groupBoxCompany);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelSelectInstructions);
            this.Controls.Add(this.labelNonStates);
            this.Controls.Add(this.labelStates);
            this.Controls.Add(this.labelRowCountNonStates);
            this.Controls.Add(this.dataGridViewNonStates);
            this.Controls.Add(this.labelRowCountStates);
            this.Controls.Add(this.buttonClearFilter);
            this.Controls.Add(this.dataGridViewStates);
            this.Controls.Add(this.buttonFilter);
            this.Controls.Add(this.labelReportName);
            this.Controls.Add(this.buttonExportExcelFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1200, 814);
            this.Name = "PreviewExcelFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FDBApp";
            this.Load += new System.EventHandler(this.PreviewExcelFile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNonStates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBoxCompany.ResumeLayout(false);
            this.groupBoxCompany.PerformLayout();
            this.groupBoxYear.ResumeLayout(false);
            this.groupBoxYear.PerformLayout();
            this.groupBoxQuarter.ResumeLayout(false);
            this.groupBoxQuarter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonExportExcelFile;
        public System.Windows.Forms.DataGridView dataGridViewStates;
        private System.Windows.Forms.Label labelReportName;
        private System.Windows.Forms.Button buttonFilter;
        private System.Windows.Forms.Button buttonClearFilter;
        private System.Windows.Forms.Label labelRowCountStates;
        public System.Windows.Forms.DataGridView dataGridViewNonStates;
        private System.Windows.Forms.Label labelRowCountNonStates;
        private System.Windows.Forms.Label labelStates;
        private System.Windows.Forms.Label labelNonStates;
        private System.Windows.Forms.CheckedListBox checkedListBoxSelectCompany;
        private System.Windows.Forms.CheckedListBox checkedListBoxSelectYear;
        private System.Windows.Forms.CheckedListBox checkedListBoxSelectQuarter;
        private System.Windows.Forms.Label labelSelectInstructions;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox checkBoxSelectAllCompany;
        private System.Windows.Forms.CheckBox checkBoxSelectAllYear;
        private System.Windows.Forms.CheckBox checkBoxSelectAllQuarter;
        private System.Windows.Forms.GroupBox groupBoxCompany;
        private System.Windows.Forms.GroupBox groupBoxYear;
        private System.Windows.Forms.GroupBox groupBoxQuarter;
        private System.Windows.Forms.Button buttonRefresh;
    }
}