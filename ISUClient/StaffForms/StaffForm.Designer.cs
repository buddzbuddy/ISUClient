namespace UI.StaffForms
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
            this.StudentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentPersonLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentPersonFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentStaffType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.StudentPosition = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DataGridViewPositions = new System.Windows.Forms.DataGridView();
            this.PositionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PositionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddPositionButton = new System.Windows.Forms.Button();
            this.AddStudentButton = new System.Windows.Forms.Button();
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
            this.StudentId,
            this.StudentPersonLastName,
            this.StudentPersonFirstName,
            this.StudentStaffType,
            this.StudentPosition});
            this.DataGridViewEmployees.Location = new System.Drawing.Point(13, 13);
            this.DataGridViewEmployees.Name = "DataGridViewEmployees";
            this.DataGridViewEmployees.ReadOnly = true;
            this.DataGridViewEmployees.Size = new System.Drawing.Size(707, 150);
            this.DataGridViewEmployees.TabIndex = 0;
            // 
            // StudentId
            // 
            this.StudentId.HeaderText = "Id";
            this.StudentId.Name = "StudentId";
            this.StudentId.ReadOnly = true;
            this.StudentId.Visible = false;
            // 
            // StudentPersonLastName
            // 
            this.StudentPersonLastName.HeaderText = "Фамилия";
            this.StudentPersonLastName.Name = "StudentPersonLastName";
            this.StudentPersonLastName.ReadOnly = true;
            // 
            // StudentPersonFirstName
            // 
            this.StudentPersonFirstName.HeaderText = "Имя";
            this.StudentPersonFirstName.Name = "StudentPersonFirstName";
            this.StudentPersonFirstName.ReadOnly = true;
            // 
            // StudentStaffType
            // 
            this.StudentStaffType.HeaderText = "Категория должности";
            this.StudentStaffType.Name = "StudentStaffType";
            this.StudentStaffType.ReadOnly = true;
            // 
            // StudentPosition
            // 
            this.StudentPosition.HeaderText = "Дожность";
            this.StudentPosition.Name = "StudentPosition";
            this.StudentPosition.ReadOnly = true;
            // 
            // DataGridViewPositions
            // 
            this.DataGridViewPositions.AllowUserToAddRows = false;
            this.DataGridViewPositions.AllowUserToDeleteRows = false;
            this.DataGridViewPositions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewPositions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PositionId,
            this.PositionName});
            this.DataGridViewPositions.Location = new System.Drawing.Point(4, 210);
            this.DataGridViewPositions.Name = "DataGridViewPositions";
            this.DataGridViewPositions.ReadOnly = true;
            this.DataGridViewPositions.Size = new System.Drawing.Size(311, 133);
            this.DataGridViewPositions.TabIndex = 1;
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
            // AddStudentButton
            // 
            this.AddStudentButton.Location = new System.Drawing.Point(727, 13);
            this.AddStudentButton.Name = "AddStudentButton";
            this.AddStudentButton.Size = new System.Drawing.Size(75, 43);
            this.AddStudentButton.TabIndex = 3;
            this.AddStudentButton.Text = "Ввод сотрудника";
            this.AddStudentButton.UseVisualStyleBackColor = true;
            this.AddStudentButton.Click += new System.EventHandler(this.AddStudentButton_Click);
            // 
            // StaffForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 458);
            this.Controls.Add(this.AddStudentButton);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentPersonLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentPersonFirstName;
        private System.Windows.Forms.DataGridViewComboBoxColumn StudentStaffType;
        private System.Windows.Forms.DataGridViewComboBoxColumn StudentPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn PositionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PositionName;
        private System.Windows.Forms.Button AddPositionButton;
        private System.Windows.Forms.Button AddStudentButton;
    }
}