namespace UI.ContingentForms
{
    partial class AddStudentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddStudentForm));
            this.LastNameLabel = new System.Windows.Forms.Label();
            this.FirstNameLabel = new System.Windows.Forms.Label();
            this.MiddleNameLabel = new System.Windows.Forms.Label();
            this.LastNameTextBox = new System.Windows.Forms.TextBox();
            this.FirstNameTextBox = new System.Windows.Forms.TextBox();
            this.MiddleNameTextBox = new System.Windows.Forms.TextBox();
            this.BirthDateLabel = new System.Windows.Forms.Label();
            this.BirthDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.GroupComboBox = new System.Windows.Forms.ComboBox();
            this.GroupLabel = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.GenderLabel = new System.Windows.Forms.Label();
            this.GenderComboBox = new System.Windows.Forms.ComboBox();
            this.NationalityLabel = new System.Windows.Forms.Label();
            this.NationalityComboBox = new System.Windows.Forms.ComboBox();
            this.PINLabel = new System.Windows.Forms.Label();
            this.PINTextBox = new System.Windows.Forms.TextBox();
            this.PassportSeriesLabel = new System.Windows.Forms.Label();
            this.PassportSeriesTextBox = new System.Windows.Forms.TextBox();
            this.PassportNoLabel = new System.Windows.Forms.Label();
            this.PassportNoTextBox = new System.Windows.Forms.TextBox();
            this.PersonalDocumentLabel = new System.Windows.Forms.Label();
            this.PersonalDocumentTypeLabel = new System.Windows.Forms.Label();
            this.PersonalDocumentTypeComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // LastNameLabel
            // 
            this.LastNameLabel.AutoSize = true;
            this.LastNameLabel.Location = new System.Drawing.Point(47, 50);
            this.LastNameLabel.Name = "LastNameLabel";
            this.LastNameLabel.Size = new System.Drawing.Size(56, 13);
            this.LastNameLabel.TabIndex = 0;
            this.LastNameLabel.Text = "Фамилия";
            // 
            // FirstNameLabel
            // 
            this.FirstNameLabel.AutoSize = true;
            this.FirstNameLabel.Location = new System.Drawing.Point(74, 76);
            this.FirstNameLabel.Name = "FirstNameLabel";
            this.FirstNameLabel.Size = new System.Drawing.Size(29, 13);
            this.FirstNameLabel.TabIndex = 1;
            this.FirstNameLabel.Text = "Имя";
            // 
            // MiddleNameLabel
            // 
            this.MiddleNameLabel.AutoSize = true;
            this.MiddleNameLabel.Location = new System.Drawing.Point(49, 102);
            this.MiddleNameLabel.Name = "MiddleNameLabel";
            this.MiddleNameLabel.Size = new System.Drawing.Size(54, 13);
            this.MiddleNameLabel.TabIndex = 2;
            this.MiddleNameLabel.Text = "Отчество";
            // 
            // LastNameTextBox
            // 
            this.LastNameTextBox.Location = new System.Drawing.Point(109, 43);
            this.LastNameTextBox.Name = "LastNameTextBox";
            this.LastNameTextBox.Size = new System.Drawing.Size(148, 20);
            this.LastNameTextBox.TabIndex = 1;
            // 
            // FirstNameTextBox
            // 
            this.FirstNameTextBox.Location = new System.Drawing.Point(109, 69);
            this.FirstNameTextBox.Name = "FirstNameTextBox";
            this.FirstNameTextBox.Size = new System.Drawing.Size(148, 20);
            this.FirstNameTextBox.TabIndex = 2;
            // 
            // MiddleNameTextBox
            // 
            this.MiddleNameTextBox.Location = new System.Drawing.Point(109, 95);
            this.MiddleNameTextBox.Name = "MiddleNameTextBox";
            this.MiddleNameTextBox.Size = new System.Drawing.Size(148, 20);
            this.MiddleNameTextBox.TabIndex = 3;
            // 
            // BirthDateLabel
            // 
            this.BirthDateLabel.AutoSize = true;
            this.BirthDateLabel.Location = new System.Drawing.Point(17, 127);
            this.BirthDateLabel.Name = "BirthDateLabel";
            this.BirthDateLabel.Size = new System.Drawing.Size(86, 13);
            this.BirthDateLabel.TabIndex = 3;
            this.BirthDateLabel.Text = "Дата рождения";
            // 
            // BirthDateDateTimePicker
            // 
            this.BirthDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.BirthDateDateTimePicker.Location = new System.Drawing.Point(109, 121);
            this.BirthDateDateTimePicker.Name = "BirthDateDateTimePicker";
            this.BirthDateDateTimePicker.Size = new System.Drawing.Size(148, 20);
            this.BirthDateDateTimePicker.TabIndex = 4;
            // 
            // GroupComboBox
            // 
            this.GroupComboBox.FormattingEnabled = true;
            this.GroupComboBox.Location = new System.Drawing.Point(109, 202);
            this.GroupComboBox.Name = "GroupComboBox";
            this.GroupComboBox.Size = new System.Drawing.Size(148, 21);
            this.GroupComboBox.TabIndex = 100;
            // 
            // GroupLabel
            // 
            this.GroupLabel.AutoSize = true;
            this.GroupLabel.Location = new System.Drawing.Point(61, 210);
            this.GroupLabel.Name = "GroupLabel";
            this.GroupLabel.Size = new System.Drawing.Size(42, 13);
            this.GroupLabel.TabIndex = 5;
            this.GroupLabel.Text = "Группа";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(31, 404);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 6;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(130, 404);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 7;
            this.CancelButton.Text = "Отмена";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // GenderLabel
            // 
            this.GenderLabel.AutoSize = true;
            this.GenderLabel.Location = new System.Drawing.Point(74, 155);
            this.GenderLabel.Name = "GenderLabel";
            this.GenderLabel.Size = new System.Drawing.Size(27, 13);
            this.GenderLabel.TabIndex = 8;
            this.GenderLabel.Text = "Пол";
            // 
            // GenderComboBox
            // 
            this.GenderComboBox.FormattingEnabled = true;
            this.GenderComboBox.Location = new System.Drawing.Point(109, 147);
            this.GenderComboBox.Name = "GenderComboBox";
            this.GenderComboBox.Size = new System.Drawing.Size(148, 21);
            this.GenderComboBox.TabIndex = 5;
            // 
            // NationalityLabel
            // 
            this.NationalityLabel.AutoSize = true;
            this.NationalityLabel.Location = new System.Drawing.Point(11, 185);
            this.NationalityLabel.Name = "NationalityLabel";
            this.NationalityLabel.Size = new System.Drawing.Size(92, 13);
            this.NationalityLabel.TabIndex = 101;
            this.NationalityLabel.Text = "Национальность";
            // 
            // NationalityComboBox
            // 
            this.NationalityComboBox.FormattingEnabled = true;
            this.NationalityComboBox.Location = new System.Drawing.Point(109, 175);
            this.NationalityComboBox.Name = "NationalityComboBox";
            this.NationalityComboBox.Size = new System.Drawing.Size(148, 21);
            this.NationalityComboBox.TabIndex = 6;
            // 
            // PINLabel
            // 
            this.PINLabel.AutoSize = true;
            this.PINLabel.Location = new System.Drawing.Point(39, 24);
            this.PINLabel.Name = "PINLabel";
            this.PINLabel.Size = new System.Drawing.Size(64, 13);
            this.PINLabel.TabIndex = 103;
            this.PINLabel.Text = "ПИН (ИНН)";
            // 
            // PINTextBox
            // 
            this.PINTextBox.Location = new System.Drawing.Point(109, 17);
            this.PINTextBox.Name = "PINTextBox";
            this.PINTextBox.Size = new System.Drawing.Size(148, 20);
            this.PINTextBox.TabIndex = 0;
            // 
            // PassportSeriesLabel
            // 
            this.PassportSeriesLabel.AutoSize = true;
            this.PassportSeriesLabel.Location = new System.Drawing.Point(321, 68);
            this.PassportSeriesLabel.Name = "PassportSeriesLabel";
            this.PassportSeriesLabel.Size = new System.Drawing.Size(38, 13);
            this.PassportSeriesLabel.TabIndex = 104;
            this.PassportSeriesLabel.Text = "Серия";
            // 
            // PassportSeriesTextBox
            // 
            this.PassportSeriesTextBox.Location = new System.Drawing.Point(365, 61);
            this.PassportSeriesTextBox.Name = "PassportSeriesTextBox";
            this.PassportSeriesTextBox.Size = new System.Drawing.Size(37, 20);
            this.PassportSeriesTextBox.TabIndex = 105;
            // 
            // PassportNoLabel
            // 
            this.PassportNoLabel.AutoSize = true;
            this.PassportNoLabel.Location = new System.Drawing.Point(408, 68);
            this.PassportNoLabel.Name = "PassportNoLabel";
            this.PassportNoLabel.Size = new System.Drawing.Size(41, 13);
            this.PassportNoLabel.TabIndex = 106;
            this.PassportNoLabel.Text = "Номер";
            // 
            // PassportNoTextBox
            // 
            this.PassportNoTextBox.Location = new System.Drawing.Point(455, 61);
            this.PassportNoTextBox.Name = "PassportNoTextBox";
            this.PassportNoTextBox.Size = new System.Drawing.Size(100, 20);
            this.PassportNoTextBox.TabIndex = 107;
            // 
            // PersonalDocumentLabel
            // 
            this.PersonalDocumentLabel.AutoSize = true;
            this.PersonalDocumentLabel.Location = new System.Drawing.Point(315, 17);
            this.PersonalDocumentLabel.Name = "PersonalDocumentLabel";
            this.PersonalDocumentLabel.Size = new System.Drawing.Size(203, 13);
            this.PersonalDocumentLabel.TabIndex = 108;
            this.PersonalDocumentLabel.Text = "Документ, удостоверяющий личность:";
            // 
            // PersonalDocumentTypeLabel
            // 
            this.PersonalDocumentTypeLabel.AutoSize = true;
            this.PersonalDocumentTypeLabel.Location = new System.Drawing.Point(318, 34);
            this.PersonalDocumentTypeLabel.Name = "PersonalDocumentTypeLabel";
            this.PersonalDocumentTypeLabel.Size = new System.Drawing.Size(29, 13);
            this.PersonalDocumentTypeLabel.TabIndex = 109;
            this.PersonalDocumentTypeLabel.Text = "Вид:";
            // 
            // PersonalDocumentTypeComboBox
            // 
            this.PersonalDocumentTypeComboBox.FormattingEnabled = true;
            this.PersonalDocumentTypeComboBox.Location = new System.Drawing.Point(356, 34);
            this.PersonalDocumentTypeComboBox.Name = "PersonalDocumentTypeComboBox";
            this.PersonalDocumentTypeComboBox.Size = new System.Drawing.Size(199, 21);
            this.PersonalDocumentTypeComboBox.TabIndex = 110;
            // 
            // AddStudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 430);
            this.Controls.Add(this.PersonalDocumentTypeComboBox);
            this.Controls.Add(this.PersonalDocumentTypeLabel);
            this.Controls.Add(this.PersonalDocumentLabel);
            this.Controls.Add(this.PassportNoTextBox);
            this.Controls.Add(this.PassportNoLabel);
            this.Controls.Add(this.PassportSeriesTextBox);
            this.Controls.Add(this.PassportSeriesLabel);
            this.Controls.Add(this.PINTextBox);
            this.Controls.Add(this.PINLabel);
            this.Controls.Add(this.NationalityComboBox);
            this.Controls.Add(this.NationalityLabel);
            this.Controls.Add(this.GenderComboBox);
            this.Controls.Add(this.GenderLabel);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.GroupLabel);
            this.Controls.Add(this.GroupComboBox);
            this.Controls.Add(this.BirthDateDateTimePicker);
            this.Controls.Add(this.BirthDateLabel);
            this.Controls.Add(this.MiddleNameTextBox);
            this.Controls.Add(this.FirstNameTextBox);
            this.Controls.Add(this.LastNameTextBox);
            this.Controls.Add(this.MiddleNameLabel);
            this.Controls.Add(this.FirstNameLabel);
            this.Controls.Add(this.LastNameLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddStudentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавить учащегося";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LastNameLabel;
        private System.Windows.Forms.Label FirstNameLabel;
        private System.Windows.Forms.Label MiddleNameLabel;
        private System.Windows.Forms.TextBox LastNameTextBox;
        private System.Windows.Forms.TextBox FirstNameTextBox;
        private System.Windows.Forms.TextBox MiddleNameTextBox;
        private System.Windows.Forms.Label BirthDateLabel;
        private System.Windows.Forms.DateTimePicker BirthDateDateTimePicker;
        private System.Windows.Forms.ComboBox GroupComboBox;
        private System.Windows.Forms.Label GroupLabel;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label GenderLabel;
        private System.Windows.Forms.ComboBox GenderComboBox;
        private System.Windows.Forms.Label NationalityLabel;
        private System.Windows.Forms.ComboBox NationalityComboBox;
        private System.Windows.Forms.Label PINLabel;
        private System.Windows.Forms.TextBox PINTextBox;
        private System.Windows.Forms.Label PassportSeriesLabel;
        private System.Windows.Forms.TextBox PassportSeriesTextBox;
        private System.Windows.Forms.Label PassportNoLabel;
        private System.Windows.Forms.TextBox PassportNoTextBox;
        private System.Windows.Forms.Label PersonalDocumentLabel;
        private System.Windows.Forms.Label PersonalDocumentTypeLabel;
        private System.Windows.Forms.ComboBox PersonalDocumentTypeComboBox;
    }
}