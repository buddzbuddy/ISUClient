﻿namespace UI.StaffForms
{
    partial class StaffForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StaffForm));
            this.DataGridViewEmployees = new System.Windows.Forms.DataGridView();
            this.EmployeeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeePersonLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeePersonFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeStaffType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.EmployeePosition = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ShowEmployeeLink = new System.Windows.Forms.DataGridViewLinkColumn();
            this.EditEmployeeLink = new System.Windows.Forms.DataGridViewLinkColumn();
            this.DeleteEmployeeLink = new System.Windows.Forms.DataGridViewLinkColumn();
            this.DataGridViewPositions = new System.Windows.Forms.DataGridView();
            this.AddPositionButton = new System.Windows.Forms.Button();
            this.AddEmployeeButton = new System.Windows.Forms.Button();
            this.PositionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PositionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShowPositionLink = new System.Windows.Forms.DataGridViewLinkColumn();
            this.EditPositionLink = new System.Windows.Forms.DataGridViewLinkColumn();
            this.DeletePositionLink = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewPositions)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridViewEmployees
            // 
            this.DataGridViewEmployees.AllowUserToAddRows = false;
            this.DataGridViewEmployees.AllowUserToDeleteRows = false;
            this.DataGridViewEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewEmployees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EmployeeId,
            this.EmployeePersonLastName,
            this.EmployeePersonFirstName,
            this.EmployeeStaffType,
            this.EmployeePosition,
            this.ShowEmployeeLink,
            this.EditEmployeeLink,
            this.DeleteEmployeeLink});
            this.DataGridViewEmployees.Location = new System.Drawing.Point(13, 13);
            this.DataGridViewEmployees.Name = "DataGridViewEmployees";
            this.DataGridViewEmployees.ReadOnly = true;
            this.DataGridViewEmployees.Size = new System.Drawing.Size(707, 150);
            this.DataGridViewEmployees.TabIndex = 0;
            this.DataGridViewEmployees.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewEmployees_CellContentClick);
            // 
            // EmployeeId
            // 
            this.EmployeeId.HeaderText = "Id";
            this.EmployeeId.Name = "EmployeeId";
            this.EmployeeId.ReadOnly = true;
            this.EmployeeId.Visible = false;
            // 
            // EmployeePersonLastName
            // 
            this.EmployeePersonLastName.HeaderText = "Фамилия";
            this.EmployeePersonLastName.Name = "EmployeePersonLastName";
            this.EmployeePersonLastName.ReadOnly = true;
            // 
            // EmployeePersonFirstName
            // 
            this.EmployeePersonFirstName.HeaderText = "Имя";
            this.EmployeePersonFirstName.Name = "EmployeePersonFirstName";
            this.EmployeePersonFirstName.ReadOnly = true;
            // 
            // EmployeeStaffType
            // 
            this.EmployeeStaffType.HeaderText = "Категория должности";
            this.EmployeeStaffType.Name = "EmployeeStaffType";
            this.EmployeeStaffType.ReadOnly = true;
            // 
            // EmployeePosition
            // 
            this.EmployeePosition.HeaderText = "Дожность";
            this.EmployeePosition.Name = "EmployeePosition";
            this.EmployeePosition.ReadOnly = true;
            // 
            // ShowEmployeeLink
            // 
            this.ShowEmployeeLink.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ShowEmployeeLink.HeaderText = "";
            this.ShowEmployeeLink.Name = "ShowEmployeeLink";
            this.ShowEmployeeLink.ReadOnly = true;
            this.ShowEmployeeLink.Text = "открыть";
            this.ShowEmployeeLink.TrackVisitedState = false;
            this.ShowEmployeeLink.UseColumnTextForLinkValue = true;
            this.ShowEmployeeLink.Width = 5;
            // 
            // EditEmployeeLink
            // 
            this.EditEmployeeLink.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.EditEmployeeLink.HeaderText = "";
            this.EditEmployeeLink.Name = "EditEmployeeLink";
            this.EditEmployeeLink.ReadOnly = true;
            this.EditEmployeeLink.Text = "изменить";
            this.EditEmployeeLink.TrackVisitedState = false;
            this.EditEmployeeLink.UseColumnTextForLinkValue = true;
            this.EditEmployeeLink.Width = 5;
            // 
            // DeleteEmployeeLink
            // 
            this.DeleteEmployeeLink.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DeleteEmployeeLink.HeaderText = "";
            this.DeleteEmployeeLink.Name = "DeleteEmployeeLink";
            this.DeleteEmployeeLink.ReadOnly = true;
            this.DeleteEmployeeLink.Text = "удалить";
            this.DeleteEmployeeLink.TrackVisitedState = false;
            this.DeleteEmployeeLink.UseColumnTextForLinkValue = true;
            this.DeleteEmployeeLink.Width = 5;
            // 
            // DataGridViewPositions
            // 
            this.DataGridViewPositions.AllowUserToAddRows = false;
            this.DataGridViewPositions.AllowUserToDeleteRows = false;
            this.DataGridViewPositions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewPositions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PositionId,
            this.PositionName,
            this.ShowPositionLink,
            this.EditPositionLink,
            this.DeletePositionLink});
            this.DataGridViewPositions.Location = new System.Drawing.Point(4, 210);
            this.DataGridViewPositions.Name = "DataGridViewPositions";
            this.DataGridViewPositions.ReadOnly = true;
            this.DataGridViewPositions.Size = new System.Drawing.Size(311, 133);
            this.DataGridViewPositions.TabIndex = 1;
            this.DataGridViewPositions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewPositions_CellContentClick);
            // 
            // AddPositionButton
            // 
            this.AddPositionButton.Location = new System.Drawing.Point(322, 210);
            this.AddPositionButton.Name = "AddPositionButton";
            this.AddPositionButton.Size = new System.Drawing.Size(75, 23);
            this.AddPositionButton.TabIndex = 2;
            this.AddPositionButton.Text = "Добавить должность";
            this.AddPositionButton.UseVisualStyleBackColor = true;
            this.AddPositionButton.Click += new System.EventHandler(this.AddPositionButton_Click);
            // 
            // AddEmployeeButton
            // 
            this.AddEmployeeButton.Location = new System.Drawing.Point(727, 13);
            this.AddEmployeeButton.Name = "AddEmployeeButton";
            this.AddEmployeeButton.Size = new System.Drawing.Size(75, 43);
            this.AddEmployeeButton.TabIndex = 3;
            this.AddEmployeeButton.Text = "Ввод сотрудника";
            this.AddEmployeeButton.UseVisualStyleBackColor = true;
            this.AddEmployeeButton.Click += new System.EventHandler(this.AddEmployeeButton_Click);
            // 
            // PositionId
            // 
            this.PositionId.HeaderText = "Id";
            this.PositionId.Name = "PositionId";
            this.PositionId.ReadOnly = true;
            this.PositionId.Visible = false;
            // 
            // PositionName
            // 
            this.PositionName.HeaderText = "Должность";
            this.PositionName.Name = "PositionName";
            this.PositionName.ReadOnly = true;
            // 
            // ShowPositionLink
            // 
            this.ShowPositionLink.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ShowPositionLink.HeaderText = "";
            this.ShowPositionLink.Name = "ShowPositionLink";
            this.ShowPositionLink.ReadOnly = true;
            this.ShowPositionLink.Text = "открыть";
            this.ShowPositionLink.TrackVisitedState = false;
            this.ShowPositionLink.UseColumnTextForLinkValue = true;
            this.ShowPositionLink.Width = 5;
            // 
            // EditPositionLink
            // 
            this.EditPositionLink.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.EditPositionLink.HeaderText = "";
            this.EditPositionLink.Name = "EditPositionLink";
            this.EditPositionLink.ReadOnly = true;
            this.EditPositionLink.Text = "изменить";
            this.EditPositionLink.TrackVisitedState = false;
            this.EditPositionLink.UseColumnTextForLinkValue = true;
            this.EditPositionLink.Width = 5;
            // 
            // DeletePositionLink
            // 
            this.DeletePositionLink.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DeletePositionLink.HeaderText = "";
            this.DeletePositionLink.Name = "DeletePositionLink";
            this.DeletePositionLink.ReadOnly = true;
            this.DeletePositionLink.Text = "удалить";
            this.DeletePositionLink.TrackVisitedState = false;
            this.DeletePositionLink.UseColumnTextForLinkValue = true;
            this.DeletePositionLink.Width = 5;
            // 
            // StaffForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 458);
            this.Controls.Add(this.AddEmployeeButton);
            this.Controls.Add(this.AddPositionButton);
            this.Controls.Add(this.DataGridViewPositions);
            this.Controls.Add(this.DataGridViewEmployees);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StaffForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Кадры";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewPositions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView DataGridViewEmployees;
        public System.Windows.Forms.DataGridView DataGridViewPositions;
        private System.Windows.Forms.Button AddPositionButton;
        private System.Windows.Forms.Button AddEmployeeButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeePersonLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeePersonFirstName;
        private System.Windows.Forms.DataGridViewComboBoxColumn EmployeeStaffType;
        private System.Windows.Forms.DataGridViewComboBoxColumn EmployeePosition;
        private System.Windows.Forms.DataGridViewLinkColumn ShowEmployeeLink;
        private System.Windows.Forms.DataGridViewLinkColumn EditEmployeeLink;
        private System.Windows.Forms.DataGridViewLinkColumn DeleteEmployeeLink;
        private System.Windows.Forms.DataGridViewTextBoxColumn PositionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PositionName;
        private System.Windows.Forms.DataGridViewLinkColumn ShowPositionLink;
        private System.Windows.Forms.DataGridViewLinkColumn EditPositionLink;
        private System.Windows.Forms.DataGridViewLinkColumn DeletePositionLink;
    }
}