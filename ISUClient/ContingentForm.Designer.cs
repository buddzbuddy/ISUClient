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
            this.DataGridViewGroups = new System.Windows.Forms.DataGridView();
            this.GroupId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupLanguage = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.GroupProfession = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.GroupStudyPeriod = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ShowGroupLink = new System.Windows.Forms.DataGridViewLinkColumn();
            this.EditGroupLink = new System.Windows.Forms.DataGridViewLinkColumn();
            this.DeleteGroupLink = new System.Windows.Forms.DataGridViewLinkColumn();
            this.AddStudentButton = new System.Windows.Forms.Button();
            this.AddGroupButton = new System.Windows.Forms.Button();
            this.ToExcelGroupsButton = new System.Windows.Forms.Button();
            this.StudentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentPersonPIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentPersonLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentPersonFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentPersonMiddleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentPersonBirthDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentPersonalDocumentType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.StudentPassportSeries = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentPassportNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentGroup = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.StudentPersonGender = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.StudentPersonNationality = new System.Windows.Forms.DataGridViewComboBoxColumn();
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
            this.StudentId,
            this.StudentPersonPIN,
            this.StudentPersonLastName,
            this.StudentPersonFirstName,
            this.StudentPersonMiddleName,
            this.StudentPersonBirthDate,
            this.StudentPersonalDocumentType,
            this.StudentPassportSeries,
            this.StudentPassportNo,
            this.StudentGroup,
            this.StudentPersonGender,
            this.StudentPersonNationality});
            this.DataGridViewStudents.Location = new System.Drawing.Point(13, 13);
            this.DataGridViewStudents.Name = "DataGridViewStudents";
            this.DataGridViewStudents.ReadOnly = true;
            this.DataGridViewStudents.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.DataGridViewStudents.Size = new System.Drawing.Size(841, 150);
            this.DataGridViewStudents.TabIndex = 0;
            // 
            // DataGridViewGroups
            // 
            this.DataGridViewGroups.AllowUserToAddRows = false;
            this.DataGridViewGroups.AllowUserToDeleteRows = false;
            this.DataGridViewGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewGroups.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GroupId,
            this.GroupName,
            this.GroupLanguage,
            this.GroupProfession,
            this.GroupStudyPeriod,
            this.ShowGroupLink,
            this.EditGroupLink,
            this.DeleteGroupLink});
            this.DataGridViewGroups.Location = new System.Drawing.Point(13, 170);
            this.DataGridViewGroups.Name = "DataGridViewGroups";
            this.DataGridViewGroups.ReadOnly = true;
            this.DataGridViewGroups.Size = new System.Drawing.Size(841, 150);
            this.DataGridViewGroups.TabIndex = 1;
            this.DataGridViewGroups.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewGroups_CellContentClick);
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
            // GroupLanguage
            // 
            this.GroupLanguage.HeaderText = "Язык обучения";
            this.GroupLanguage.Items.AddRange(new object[] {
            "Русский",
            "Кыргызский",
            "Узбекский",
            "Турецкий"});
            this.GroupLanguage.Name = "GroupLanguage";
            this.GroupLanguage.ReadOnly = true;
            this.GroupLanguage.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // GroupProfession
            // 
            this.GroupProfession.HeaderText = "Профессия";
            this.GroupProfession.Name = "GroupProfession";
            this.GroupProfession.ReadOnly = true;
            this.GroupProfession.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // GroupStudyPeriod
            // 
            this.GroupStudyPeriod.HeaderText = "Срок обучения";
            this.GroupStudyPeriod.Name = "GroupStudyPeriod";
            this.GroupStudyPeriod.ReadOnly = true;
            this.GroupStudyPeriod.Resizable = System.Windows.Forms.DataGridViewTriState.True;
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
            // AddStudentButton
            // 
            this.AddStudentButton.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.AddStudentButton.Location = new System.Drawing.Point(910, 13);
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
            this.AddGroupButton.Location = new System.Drawing.Point(910, 170);
            this.AddGroupButton.Name = "AddGroupButton";
            this.AddGroupButton.Size = new System.Drawing.Size(75, 42);
            this.AddGroupButton.TabIndex = 3;
            this.AddGroupButton.Text = "Добавить группу";
            this.AddGroupButton.UseVisualStyleBackColor = false;
            this.AddGroupButton.Click += new System.EventHandler(this.AddGroupButton_Click);
            // 
            // ToExcelGroupsButton
            // 
            this.ToExcelGroupsButton.Location = new System.Drawing.Point(910, 219);
            this.ToExcelGroupsButton.Name = "ToExcelGroupsButton";
            this.ToExcelGroupsButton.Size = new System.Drawing.Size(75, 37);
            this.ToExcelGroupsButton.TabIndex = 4;
            this.ToExcelGroupsButton.Text = "экспорт в Excel";
            this.ToExcelGroupsButton.UseVisualStyleBackColor = true;
            this.ToExcelGroupsButton.Click += new System.EventHandler(this.ToExcelGroupsButton_Click);
            // 
            // StudentId
            // 
            this.StudentId.HeaderText = "Id";
            this.StudentId.Name = "StudentId";
            this.StudentId.ReadOnly = true;
            this.StudentId.Visible = false;
            // 
            // StudentPersonPIN
            // 
            this.StudentPersonPIN.HeaderText = "ПИН (ИНН)";
            this.StudentPersonPIN.Name = "StudentPersonPIN";
            this.StudentPersonPIN.ReadOnly = true;
            // 
            // StudentPersonLastName
            // 
            this.StudentPersonLastName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.StudentPersonLastName.HeaderText = "Фамилия";
            this.StudentPersonLastName.Name = "StudentPersonLastName";
            this.StudentPersonLastName.ReadOnly = true;
            this.StudentPersonLastName.Width = 81;
            // 
            // StudentPersonFirstName
            // 
            this.StudentPersonFirstName.HeaderText = "Имя";
            this.StudentPersonFirstName.Name = "StudentPersonFirstName";
            this.StudentPersonFirstName.ReadOnly = true;
            // 
            // StudentPersonMiddleName
            // 
            this.StudentPersonMiddleName.HeaderText = "Отчество";
            this.StudentPersonMiddleName.Name = "StudentPersonMiddleName";
            this.StudentPersonMiddleName.ReadOnly = true;
            // 
            // StudentPersonBirthDate
            // 
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.StudentPersonBirthDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.StudentPersonBirthDate.HeaderText = "Дата рождения";
            this.StudentPersonBirthDate.Name = "StudentPersonBirthDate";
            this.StudentPersonBirthDate.ReadOnly = true;
            // 
            // StudentPersonalDocumentType
            // 
            this.StudentPersonalDocumentType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.StudentPersonalDocumentType.HeaderText = "Вид";
            this.StudentPersonalDocumentType.Name = "StudentPersonalDocumentType";
            this.StudentPersonalDocumentType.ReadOnly = true;
            this.StudentPersonalDocumentType.Width = 32;
            // 
            // StudentPassportSeries
            // 
            this.StudentPassportSeries.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.StudentPassportSeries.HeaderText = "Серия";
            this.StudentPassportSeries.Name = "StudentPassportSeries";
            this.StudentPassportSeries.ReadOnly = true;
            this.StudentPassportSeries.Width = 63;
            // 
            // StudentPassportNo
            // 
            this.StudentPassportNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.StudentPassportNo.HeaderText = "Номер";
            this.StudentPassportNo.Name = "StudentPassportNo";
            this.StudentPassportNo.ReadOnly = true;
            this.StudentPassportNo.Width = 66;
            // 
            // StudentGroup
            // 
            this.StudentGroup.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.StudentGroup.HeaderText = "Группа";
            this.StudentGroup.Name = "StudentGroup";
            this.StudentGroup.ReadOnly = true;
            this.StudentGroup.Sorted = true;
            this.StudentGroup.Width = 48;
            // 
            // StudentPersonGender
            // 
            this.StudentPersonGender.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.StudentPersonGender.HeaderText = "Пол";
            this.StudentPersonGender.Name = "StudentPersonGender";
            this.StudentPersonGender.ReadOnly = true;
            this.StudentPersonGender.Width = 33;
            // 
            // StudentPersonNationality
            // 
            this.StudentPersonNationality.HeaderText = "Национальность";
            this.StudentPersonNationality.Name = "StudentPersonNationality";
            this.StudentPersonNationality.ReadOnly = true;
            // 
            // ContingentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 483);
            this.Controls.Add(this.ToExcelGroupsButton);
            this.Controls.Add(this.AddGroupButton);
            this.Controls.Add(this.AddStudentButton);
            this.Controls.Add(this.DataGridViewGroups);
            this.Controls.Add(this.DataGridViewStudents);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ContingentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupId;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupName;
        private System.Windows.Forms.DataGridViewComboBoxColumn GroupLanguage;
        private System.Windows.Forms.DataGridViewComboBoxColumn GroupProfession;
        private System.Windows.Forms.DataGridViewComboBoxColumn GroupStudyPeriod;
        private System.Windows.Forms.DataGridViewLinkColumn ShowGroupLink;
        private System.Windows.Forms.DataGridViewLinkColumn EditGroupLink;
        private System.Windows.Forms.DataGridViewLinkColumn DeleteGroupLink;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentPersonPIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentPersonLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentPersonFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentPersonMiddleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentPersonBirthDate;
        private System.Windows.Forms.DataGridViewComboBoxColumn StudentPersonalDocumentType;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentPassportSeries;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentPassportNo;
        private System.Windows.Forms.DataGridViewComboBoxColumn StudentGroup;
        private System.Windows.Forms.DataGridViewComboBoxColumn StudentPersonGender;
        private System.Windows.Forms.DataGridViewComboBoxColumn StudentPersonNationality;
    }
}