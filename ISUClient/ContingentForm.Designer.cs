namespace UI
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContingentForm));
            this.DataGridViewStudents = new System.Windows.Forms.DataGridView();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MiddleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BirthDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentGroupId = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DataGridViewGroups = new System.Windows.Forms.DataGridView();
            this.AddStudentButton = new System.Windows.Forms.Button();
            this.AddGroupButton = new System.Windows.Forms.Button();
            this.ToExcelGroupsButton = new System.Windows.Forms.Button();
            this.GroupId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupLanguageId = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.GroupProfessionId = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.GroupStudyPeriodId = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ShowGroupLink = new System.Windows.Forms.DataGridViewLinkColumn();
            this.EditGroupLink = new System.Windows.Forms.DataGridViewLinkColumn();
            this.DeleteGroupLink = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewStudents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewGroups)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridViewStudents
            // 
            this.DataGridViewStudents.AllowUserToAddRows = false;
            this.DataGridViewStudents.AllowUserToDeleteRows = false;
            this.DataGridViewStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewStudents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LastName,
            this.FirstName,
            this.MiddleName,
            this.BirthDate,
            this.StudentGroupId});
            this.DataGridViewStudents.Location = new System.Drawing.Point(13, 13);
            this.DataGridViewStudents.Name = "DataGridViewStudents";
            this.DataGridViewStudents.ReadOnly = true;
            this.DataGridViewStudents.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.DataGridViewStudents.Size = new System.Drawing.Size(722, 150);
            this.DataGridViewStudents.TabIndex = 0;
            // 
            // LastName
            // 
            this.LastName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.LastName.HeaderText = "Фамилия";
            this.LastName.Name = "LastName";
            this.LastName.ReadOnly = true;
            this.LastName.Width = 81;
            // 
            // FirstName
            // 
            this.FirstName.HeaderText = "Имя";
            this.FirstName.Name = "FirstName";
            this.FirstName.ReadOnly = true;
            // 
            // MiddleName
            // 
            this.MiddleName.HeaderText = "Отчество";
            this.MiddleName.Name = "MiddleName";
            this.MiddleName.ReadOnly = true;
            // 
            // BirthDate
            // 
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.BirthDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.BirthDate.HeaderText = "Дата рождения";
            this.BirthDate.Name = "BirthDate";
            this.BirthDate.ReadOnly = true;
            // 
            // StudentGroupId
            // 
            this.StudentGroupId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.StudentGroupId.HeaderText = "Группа";
            this.StudentGroupId.Name = "StudentGroupId";
            this.StudentGroupId.ReadOnly = true;
            this.StudentGroupId.Sorted = true;
            this.StudentGroupId.Width = 48;
            // 
            // DataGridViewGroups
            // 
            this.DataGridViewGroups.AllowUserToAddRows = false;
            this.DataGridViewGroups.AllowUserToDeleteRows = false;
            this.DataGridViewGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewGroups.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GroupId,
            this.GroupName,
            this.GroupLanguageId,
            this.GroupProfessionId,
            this.GroupStudyPeriodId,
            this.ShowGroupLink,
            this.EditGroupLink,
            this.DeleteGroupLink});
            this.DataGridViewGroups.Location = new System.Drawing.Point(13, 170);
            this.DataGridViewGroups.Name = "DataGridViewGroups";
            this.DataGridViewGroups.ReadOnly = true;
            this.DataGridViewGroups.Size = new System.Drawing.Size(722, 150);
            this.DataGridViewGroups.TabIndex = 1;
            this.DataGridViewGroups.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewGroups_CellContentClick);
            // 
            // AddStudentButton
            // 
            this.AddStudentButton.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.AddStudentButton.Location = new System.Drawing.Point(741, 13);
            this.AddStudentButton.Name = "AddStudentButton";
            this.AddStudentButton.Size = new System.Drawing.Size(75, 47);
            this.AddStudentButton.TabIndex = 2;
            this.AddStudentButton.Text = "Добавить учащегося";
            this.AddStudentButton.UseVisualStyleBackColor = false;
            this.AddStudentButton.Click += new System.EventHandler(this.addStudentButton_Click);
            // 
            // AddGroupButton
            // 
            this.AddGroupButton.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.AddGroupButton.Location = new System.Drawing.Point(741, 170);
            this.AddGroupButton.Name = "AddGroupButton";
            this.AddGroupButton.Size = new System.Drawing.Size(75, 42);
            this.AddGroupButton.TabIndex = 3;
            this.AddGroupButton.Text = "Добавить группу";
            this.AddGroupButton.UseVisualStyleBackColor = false;
            this.AddGroupButton.Click += new System.EventHandler(this.AddGroupButton_Click);
            // 
            // ToExcelGroupsButton
            // 
            this.ToExcelGroupsButton.Location = new System.Drawing.Point(741, 219);
            this.ToExcelGroupsButton.Name = "ToExcelGroupsButton";
            this.ToExcelGroupsButton.Size = new System.Drawing.Size(75, 37);
            this.ToExcelGroupsButton.TabIndex = 4;
            this.ToExcelGroupsButton.Text = "экспорт в Excel";
            this.ToExcelGroupsButton.UseVisualStyleBackColor = true;
            this.ToExcelGroupsButton.Click += new System.EventHandler(this.ToExcelGroupsButton_Click);
            // 
            // GroupId
            // 
            this.GroupId.HeaderText = "Id";
            this.GroupId.Name = "GroupId";
            this.GroupId.ReadOnly = true;
            this.GroupId.Visible = false;
            this.GroupId.Width = 41;
            // 
            // GroupName
            // 
            this.GroupName.HeaderText = "Название группы";
            this.GroupName.Name = "GroupName";
            this.GroupName.ReadOnly = true;
            // 
            // GroupLanguageId
            // 
            this.GroupLanguageId.HeaderText = "Язык обучения";
            this.GroupLanguageId.Items.AddRange(new object[] {
            "Русский",
            "Кыргызский",
            "Узбекский",
            "Турецкий"});
            this.GroupLanguageId.Name = "GroupLanguageId";
            this.GroupLanguageId.ReadOnly = true;
            this.GroupLanguageId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // GroupProfessionId
            // 
            this.GroupProfessionId.HeaderText = "Профессия";
            this.GroupProfessionId.Name = "GroupProfessionId";
            this.GroupProfessionId.ReadOnly = true;
            this.GroupProfessionId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // GroupStudyPeriodId
            // 
            this.GroupStudyPeriodId.HeaderText = "Срок обучения";
            this.GroupStudyPeriodId.Name = "GroupStudyPeriodId";
            this.GroupStudyPeriodId.ReadOnly = true;
            this.GroupStudyPeriodId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ShowGroupLink
            // 
            this.ShowGroupLink.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ShowGroupLink.HeaderText = "";
            this.ShowGroupLink.Name = "ShowGroupLink";
            this.ShowGroupLink.ReadOnly = true;
            this.ShowGroupLink.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ShowGroupLink.Text = "открыть";
            this.ShowGroupLink.TrackVisitedState = false;
            this.ShowGroupLink.UseColumnTextForLinkValue = true;
            this.ShowGroupLink.Width = 19;
            // 
            // EditGroupLink
            // 
            this.EditGroupLink.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.EditGroupLink.HeaderText = "";
            this.EditGroupLink.LinkColor = System.Drawing.Color.Blue;
            this.EditGroupLink.Name = "EditGroupLink";
            this.EditGroupLink.ReadOnly = true;
            this.EditGroupLink.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.EditGroupLink.Text = "изменить";
            this.EditGroupLink.TrackVisitedState = false;
            this.EditGroupLink.UseColumnTextForLinkValue = true;
            this.EditGroupLink.VisitedLinkColor = System.Drawing.Color.DarkViolet;
            this.EditGroupLink.Width = 19;
            // 
            // DeleteGroupLink
            // 
            this.DeleteGroupLink.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DeleteGroupLink.HeaderText = "";
            this.DeleteGroupLink.Name = "DeleteGroupLink";
            this.DeleteGroupLink.ReadOnly = true;
            this.DeleteGroupLink.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DeleteGroupLink.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DeleteGroupLink.Text = "удалить";
            this.DeleteGroupLink.TrackVisitedState = false;
            this.DeleteGroupLink.UseColumnTextForLinkValue = true;
            this.DeleteGroupLink.Width = 19;
            // 
            // ContingentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 483);
            this.Controls.Add(this.ToExcelGroupsButton);
            this.Controls.Add(this.AddGroupButton);
            this.Controls.Add(this.AddStudentButton);
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

        public System.Windows.Forms.DataGridView DataGridViewStudents;
        public System.Windows.Forms.DataGridView DataGridViewGroups;
        private System.Windows.Forms.Button AddStudentButton;
        private System.Windows.Forms.Button AddGroupButton;
        private System.Windows.Forms.Button ToExcelGroupsButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MiddleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BirthDate;
        private System.Windows.Forms.DataGridViewComboBoxColumn StudentGroupId;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupId;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupName;
        private System.Windows.Forms.DataGridViewComboBoxColumn GroupLanguageId;
        private System.Windows.Forms.DataGridViewComboBoxColumn GroupProfessionId;
        private System.Windows.Forms.DataGridViewComboBoxColumn GroupStudyPeriodId;
        private System.Windows.Forms.DataGridViewLinkColumn ShowGroupLink;
        private System.Windows.Forms.DataGridViewLinkColumn EditGroupLink;
        private System.Windows.Forms.DataGridViewLinkColumn DeleteGroupLink;
    }
}