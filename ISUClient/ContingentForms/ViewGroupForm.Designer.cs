namespace UI.ContingentForms
{
    partial class ViewGroupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewGroupForm));
            this.StudyPeriodComboBox = new System.Windows.Forms.ComboBox();
            this.StudyPeriodLabel = new System.Windows.Forms.Label();
            this.ProfessionLabel = new System.Windows.Forms.Label();
            this.ProfessionComboBox = new System.Windows.Forms.ComboBox();
            this.LanguageLabel = new System.Windows.Forms.Label();
            this.LanguageComboBox = new System.Windows.Forms.ComboBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.GroupNameLabel = new System.Windows.Forms.Label();
            this.AddStudentButton = new System.Windows.Forms.Button();
            this.DataGridViewStudents = new System.Windows.Forms.DataGridView();
            this.StudentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentPersonPIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentPersonLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentPersonFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentPersonMiddleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentPersonBirthDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentPersonalDocumentType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.StudentPassportSeries = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentPassportNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentPersonGender = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.StudentPersonNationality = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // StudyPeriodComboBox
            // 
            this.StudyPeriodComboBox.Enabled = false;
            this.StudyPeriodComboBox.FormattingEnabled = true;
            this.StudyPeriodComboBox.Location = new System.Drawing.Point(114, 98);
            this.StudyPeriodComboBox.Name = "StudyPeriodComboBox";
            this.StudyPeriodComboBox.Size = new System.Drawing.Size(121, 21);
            this.StudyPeriodComboBox.TabIndex = 12;
            // 
            // StudyPeriodLabel
            // 
            this.StudyPeriodLabel.AutoSize = true;
            this.StudyPeriodLabel.Location = new System.Drawing.Point(27, 106);
            this.StudyPeriodLabel.Name = "StudyPeriodLabel";
            this.StudyPeriodLabel.Size = new System.Drawing.Size(81, 13);
            this.StudyPeriodLabel.TabIndex = 14;
            this.StudyPeriodLabel.Text = "Срок обучения";
            // 
            // ProfessionLabel
            // 
            this.ProfessionLabel.AutoSize = true;
            this.ProfessionLabel.Location = new System.Drawing.Point(43, 78);
            this.ProfessionLabel.Name = "ProfessionLabel";
            this.ProfessionLabel.Size = new System.Drawing.Size(65, 13);
            this.ProfessionLabel.TabIndex = 13;
            this.ProfessionLabel.Text = "Профессия";
            // 
            // ProfessionComboBox
            // 
            this.ProfessionComboBox.Enabled = false;
            this.ProfessionComboBox.FormattingEnabled = true;
            this.ProfessionComboBox.Location = new System.Drawing.Point(114, 70);
            this.ProfessionComboBox.Name = "ProfessionComboBox";
            this.ProfessionComboBox.Size = new System.Drawing.Size(121, 21);
            this.ProfessionComboBox.TabIndex = 10;
            // 
            // LanguageLabel
            // 
            this.LanguageLabel.AutoSize = true;
            this.LanguageLabel.Location = new System.Drawing.Point(24, 50);
            this.LanguageLabel.Name = "LanguageLabel";
            this.LanguageLabel.Size = new System.Drawing.Size(84, 13);
            this.LanguageLabel.TabIndex = 11;
            this.LanguageLabel.Text = "Язык обучения";
            // 
            // LanguageComboBox
            // 
            this.LanguageComboBox.Enabled = false;
            this.LanguageComboBox.FormattingEnabled = true;
            this.LanguageComboBox.Location = new System.Drawing.Point(114, 42);
            this.LanguageComboBox.Name = "LanguageComboBox";
            this.LanguageComboBox.Size = new System.Drawing.Size(121, 21);
            this.LanguageComboBox.TabIndex = 9;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(114, 15);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.ReadOnly = true;
            this.NameTextBox.Size = new System.Drawing.Size(121, 20);
            this.NameTextBox.TabIndex = 8;
            // 
            // GroupNameLabel
            // 
            this.GroupNameLabel.AutoSize = true;
            this.GroupNameLabel.Location = new System.Drawing.Point(12, 22);
            this.GroupNameLabel.Name = "GroupNameLabel";
            this.GroupNameLabel.Size = new System.Drawing.Size(96, 13);
            this.GroupNameLabel.TabIndex = 7;
            this.GroupNameLabel.Text = "Название группы";
            // 
            // AddStudentButton
            // 
            this.AddStudentButton.Location = new System.Drawing.Point(860, 135);
            this.AddStudentButton.Name = "AddStudentButton";
            this.AddStudentButton.Size = new System.Drawing.Size(75, 34);
            this.AddStudentButton.TabIndex = 16;
            this.AddStudentButton.Text = "Добавить учащегося";
            this.AddStudentButton.UseVisualStyleBackColor = true;
            this.AddStudentButton.Click += new System.EventHandler(this.AddStudentButton_Click);
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
            this.StudentPersonGender,
            this.StudentPersonNationality});
            this.DataGridViewStudents.Location = new System.Drawing.Point(3, 135);
            this.DataGridViewStudents.Name = "DataGridViewStudents";
            this.DataGridViewStudents.ReadOnly = true;
            this.DataGridViewStudents.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.DataGridViewStudents.Size = new System.Drawing.Size(841, 150);
            this.DataGridViewStudents.TabIndex = 17;
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
            // ViewGroupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 361);
            this.Controls.Add(this.DataGridViewStudents);
            this.Controls.Add(this.AddStudentButton);
            this.Controls.Add(this.StudyPeriodComboBox);
            this.Controls.Add(this.StudyPeriodLabel);
            this.Controls.Add(this.ProfessionLabel);
            this.Controls.Add(this.ProfessionComboBox);
            this.Controls.Add(this.LanguageLabel);
            this.Controls.Add(this.LanguageComboBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.GroupNameLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ViewGroupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Просмотр группы";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewStudents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox StudyPeriodComboBox;
        private System.Windows.Forms.Label StudyPeriodLabel;
        private System.Windows.Forms.Label ProfessionLabel;
        private System.Windows.Forms.ComboBox ProfessionComboBox;
        private System.Windows.Forms.Label LanguageLabel;
        private System.Windows.Forms.ComboBox LanguageComboBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label GroupNameLabel;
        private System.Windows.Forms.Button AddStudentButton;
        public System.Windows.Forms.DataGridView DataGridViewStudents;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentPersonPIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentPersonLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentPersonFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentPersonMiddleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentPersonBirthDate;
        private System.Windows.Forms.DataGridViewComboBoxColumn StudentPersonalDocumentType;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentPassportSeries;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentPassportNo;
        private System.Windows.Forms.DataGridViewComboBoxColumn StudentPersonGender;
        private System.Windows.Forms.DataGridViewComboBoxColumn StudentPersonNationality;
    }
}