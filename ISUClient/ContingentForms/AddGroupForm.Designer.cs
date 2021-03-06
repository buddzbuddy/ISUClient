﻿namespace UI.ContingentForms
{
    partial class AddGroupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddGroupForm));
            this.GroupNameLabel = new System.Windows.Forms.Label();
            this.GroupNameTextBox = new System.Windows.Forms.TextBox();
            this.GroupLanguageComboBox = new System.Windows.Forms.ComboBox();
            this.LanguageLabel = new System.Windows.Forms.Label();
            this.GroupProfessionComboBox = new System.Windows.Forms.ComboBox();
            this.ProfessionLabel = new System.Windows.Forms.Label();
            this.StudyPeriodLabel = new System.Windows.Forms.Label();
            this.GroupStudyPeriodComboBox = new System.Windows.Forms.ComboBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GroupNameLabel
            // 
            this.GroupNameLabel.AutoSize = true;
            this.GroupNameLabel.Location = new System.Drawing.Point(14, 20);
            this.GroupNameLabel.Name = "GroupNameLabel";
            this.GroupNameLabel.Size = new System.Drawing.Size(96, 13);
            this.GroupNameLabel.TabIndex = 0;
            this.GroupNameLabel.Text = "Название группы";
            // 
            // GroupNameTextBox
            // 
            this.GroupNameTextBox.Location = new System.Drawing.Point(116, 13);
            this.GroupNameTextBox.Name = "GroupNameTextBox";
            this.GroupNameTextBox.Size = new System.Drawing.Size(121, 20);
            this.GroupNameTextBox.TabIndex = 1;
            // 
            // GroupLanguageComboBox
            // 
            this.GroupLanguageComboBox.FormattingEnabled = true;
            this.GroupLanguageComboBox.Location = new System.Drawing.Point(116, 40);
            this.GroupLanguageComboBox.Name = "GroupLanguageComboBox";
            this.GroupLanguageComboBox.Size = new System.Drawing.Size(121, 21);
            this.GroupLanguageComboBox.TabIndex = 2;
            // 
            // LanguageLabel
            // 
            this.LanguageLabel.AutoSize = true;
            this.LanguageLabel.Location = new System.Drawing.Point(26, 48);
            this.LanguageLabel.Name = "LanguageLabel";
            this.LanguageLabel.Size = new System.Drawing.Size(84, 13);
            this.LanguageLabel.TabIndex = 3;
            this.LanguageLabel.Text = "Язык обучения";
            // 
            // GroupProfessionComboBox
            // 
            this.GroupProfessionComboBox.FormattingEnabled = true;
            this.GroupProfessionComboBox.Location = new System.Drawing.Point(116, 68);
            this.GroupProfessionComboBox.Name = "GroupProfessionComboBox";
            this.GroupProfessionComboBox.Size = new System.Drawing.Size(121, 21);
            this.GroupProfessionComboBox.TabIndex = 3;
            // 
            // ProfessionLabel
            // 
            this.ProfessionLabel.AutoSize = true;
            this.ProfessionLabel.Location = new System.Drawing.Point(45, 76);
            this.ProfessionLabel.Name = "ProfessionLabel";
            this.ProfessionLabel.Size = new System.Drawing.Size(65, 13);
            this.ProfessionLabel.TabIndex = 5;
            this.ProfessionLabel.Text = "Профессия";
            // 
            // StudyPeriodLabel
            // 
            this.StudyPeriodLabel.AutoSize = true;
            this.StudyPeriodLabel.Location = new System.Drawing.Point(29, 104);
            this.StudyPeriodLabel.Name = "StudyPeriodLabel";
            this.StudyPeriodLabel.Size = new System.Drawing.Size(81, 13);
            this.StudyPeriodLabel.TabIndex = 6;
            this.StudyPeriodLabel.Text = "Срок обучения";
            // 
            // GroupStudyPeriodComboBox
            // 
            this.GroupStudyPeriodComboBox.FormattingEnabled = true;
            this.GroupStudyPeriodComboBox.Location = new System.Drawing.Point(116, 96);
            this.GroupStudyPeriodComboBox.Name = "GroupStudyPeriodComboBox";
            this.GroupStudyPeriodComboBox.Size = new System.Drawing.Size(121, 21);
            this.GroupStudyPeriodComboBox.TabIndex = 4;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(34, 148);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 7;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(116, 148);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 8;
            this.CancelButton.Text = "Отмена";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // AddGroupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.GroupStudyPeriodComboBox);
            this.Controls.Add(this.StudyPeriodLabel);
            this.Controls.Add(this.ProfessionLabel);
            this.Controls.Add(this.GroupProfessionComboBox);
            this.Controls.Add(this.LanguageLabel);
            this.Controls.Add(this.GroupLanguageComboBox);
            this.Controls.Add(this.GroupNameTextBox);
            this.Controls.Add(this.GroupNameLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddGroupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавить группу";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label GroupNameLabel;
        private System.Windows.Forms.TextBox GroupNameTextBox;
        private System.Windows.Forms.ComboBox GroupLanguageComboBox;
        private System.Windows.Forms.Label LanguageLabel;
        private System.Windows.Forms.ComboBox GroupProfessionComboBox;
        private System.Windows.Forms.Label ProfessionLabel;
        private System.Windows.Forms.Label StudyPeriodLabel;
        private System.Windows.Forms.ComboBox GroupStudyPeriodComboBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelButton;
    }
}