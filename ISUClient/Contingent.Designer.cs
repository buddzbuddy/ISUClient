namespace ISUClient
{
    partial class ContingentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContingentForm));
            this.DataGridViewStudents = new System.Windows.Forms.DataGridView();
            this.DataGridViewGroups = new System.Windows.Forms.DataGridView();
            this.GroupId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Language = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Profession = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.StudyPeriod = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MiddleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BirthDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Group = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewStudents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewGroups)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridViewStudents
            // 
            this.DataGridViewStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewStudents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LastName,
            this.FirstName,
            this.MiddleName,
            this.BirthDate,
            this.Group});
            this.DataGridViewStudents.Location = new System.Drawing.Point(13, 13);
            this.DataGridViewStudents.Name = "DataGridViewStudents";
            this.DataGridViewStudents.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.DataGridViewStudents.Size = new System.Drawing.Size(668, 150);
            this.DataGridViewStudents.TabIndex = 0;
            // 
            // DataGridViewGroups
            // 
            this.DataGridViewGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewGroups.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GroupId,
            this.GroupName,
            this.Language,
            this.Profession,
            this.StudyPeriod});
            this.DataGridViewGroups.Location = new System.Drawing.Point(13, 170);
            this.DataGridViewGroups.Name = "DataGridViewGroups";
            this.DataGridViewGroups.Size = new System.Drawing.Size(446, 150);
            this.DataGridViewGroups.TabIndex = 1;
            this.DataGridViewGroups.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewGroups_RowLeave);
            // 
            // GroupId
            // 
            this.GroupId.HeaderText = "Id";
            this.GroupId.Name = "GroupId";
            this.GroupId.Visible = false;
            // 
            // GroupName
            // 
            this.GroupName.HeaderText = "Название группы";
            this.GroupName.Name = "GroupName";
            // 
            // Language
            // 
            this.Language.HeaderText = "Язык обучения";
            this.Language.Items.AddRange(new object[] {
            "Русский",
            "Кыргызский",
            "Узбекский",
            "Турецкий"});
            this.Language.Name = "Language";
            // 
            // Profession
            // 
            this.Profession.HeaderText = "Профессия";
            this.Profession.Name = "Profession";
            // 
            // StudyPeriod
            // 
            this.StudyPeriod.HeaderText = "Срок обучения";
            this.StudyPeriod.Items.AddRange(new object[] {
            "3 месяца",
            "6 месяцев",
            "1 год",
            "2 года",
            "3 года",
            "3 года и 10 мес."});
            this.StudyPeriod.Name = "StudyPeriod";
            // 
            // LastName
            // 
            this.LastName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.LastName.HeaderText = "Фамилия";
            this.LastName.Name = "LastName";
            this.LastName.Width = 81;
            // 
            // FirstName
            // 
            this.FirstName.HeaderText = "Имя";
            this.FirstName.Name = "FirstName";
            // 
            // MiddleName
            // 
            this.MiddleName.HeaderText = "Отчество";
            this.MiddleName.Name = "MiddleName";
            // 
            // BirthDate
            // 
            this.BirthDate.HeaderText = "Дата рождения";
            this.BirthDate.Name = "BirthDate";
            // 
            // Group
            // 
            this.Group.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Group.HeaderText = "Группа";
            this.Group.Name = "Group";
            this.Group.Sorted = true;
            this.Group.Width = 48;
            // 
            // ContingentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 483);
            this.Controls.Add(this.DataGridViewGroups);
            this.Controls.Add(this.DataGridViewStudents);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ContingentForm";
            this.Text = "Контингент";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewStudents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewGroups)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridViewStudents;
        public System.Windows.Forms.DataGridView DataGridViewGroups;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupId;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupName;
        private System.Windows.Forms.DataGridViewComboBoxColumn Language;
        private System.Windows.Forms.DataGridViewComboBoxColumn Profession;
        private System.Windows.Forms.DataGridViewComboBoxColumn StudyPeriod;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MiddleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BirthDate;
        private System.Windows.Forms.DataGridViewComboBoxColumn Group;
    }
}