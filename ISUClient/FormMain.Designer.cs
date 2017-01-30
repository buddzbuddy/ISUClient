namespace ISUClient
{
    partial class FormMain
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.UserInfoLabel = new System.Windows.Forms.Label();
            this.AboutButton = new System.Windows.Forms.Button();
            this.ContingentOpenButton = new System.Windows.Forms.Button();
            this.LedgerOpenButton = new System.Windows.Forms.Button();
            this.EmployeeOpenButton = new System.Windows.Forms.Button();
            this.ContingentPictureBox = new System.Windows.Forms.PictureBox();
            this.MTBPictureBox = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.UserInfoPanel = new System.Windows.Forms.Panel();
            this.UserIdTextBox = new System.Windows.Forms.TextBox();
            this.UserIdLabel = new System.Windows.Forms.Label();
            this.OrganizationNameTextBox = new System.Windows.Forms.TextBox();
            this.OrganizationNameLabel = new System.Windows.Forms.Label();
            this.PositionNameTextBox = new System.Windows.Forms.TextBox();
            this.PositionNameLabel = new System.Windows.Forms.Label();
            this.UserNameTextBox = new System.Windows.Forms.TextBox();
            this.UserNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ContingentPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MTBPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.UserInfoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // UserInfoLabel
            // 
            this.UserInfoLabel.AutoSize = true;
            this.UserInfoLabel.Location = new System.Drawing.Point(13, 13);
            this.UserInfoLabel.Name = "UserInfoLabel";
            this.UserInfoLabel.Size = new System.Drawing.Size(57, 13);
            this.UserInfoLabel.TabIndex = 0;
            this.UserInfoLabel.Text = "Описание";
            // 
            // AboutButton
            // 
            this.AboutButton.Location = new System.Drawing.Point(12, 418);
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Size = new System.Drawing.Size(91, 23);
            this.AboutButton.TabIndex = 1;
            this.AboutButton.Text = "О программе";
            this.AboutButton.UseVisualStyleBackColor = true;
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // ContingentOpenButton
            // 
            this.ContingentOpenButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ContingentOpenButton.Enabled = false;
            this.ContingentOpenButton.Location = new System.Drawing.Point(120, 250);
            this.ContingentOpenButton.Name = "ContingentOpenButton";
            this.ContingentOpenButton.Size = new System.Drawing.Size(75, 23);
            this.ContingentOpenButton.TabIndex = 2;
            this.ContingentOpenButton.Text = "Контингент";
            this.ContingentOpenButton.UseVisualStyleBackColor = true;
            this.ContingentOpenButton.Click += new System.EventHandler(this.ContingentOpenButton_Click);
            // 
            // LedgerOpenButton
            // 
            this.LedgerOpenButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LedgerOpenButton.Enabled = false;
            this.LedgerOpenButton.Location = new System.Drawing.Point(293, 250);
            this.LedgerOpenButton.Name = "LedgerOpenButton";
            this.LedgerOpenButton.Size = new System.Drawing.Size(75, 23);
            this.LedgerOpenButton.TabIndex = 3;
            this.LedgerOpenButton.Text = "МТБ";
            this.LedgerOpenButton.UseVisualStyleBackColor = true;
            // 
            // EmployeeOpenButton
            // 
            this.EmployeeOpenButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EmployeeOpenButton.Enabled = false;
            this.EmployeeOpenButton.Location = new System.Drawing.Point(462, 250);
            this.EmployeeOpenButton.Name = "EmployeeOpenButton";
            this.EmployeeOpenButton.Size = new System.Drawing.Size(75, 23);
            this.EmployeeOpenButton.TabIndex = 4;
            this.EmployeeOpenButton.Text = "Кадры";
            this.EmployeeOpenButton.UseVisualStyleBackColor = true;
            // 
            // ContingentPictureBox
            // 
            this.ContingentPictureBox.Image = global::ISUClient.Properties.Resources.student_icon;
            this.ContingentPictureBox.Location = new System.Drawing.Point(104, 143);
            this.ContingentPictureBox.Name = "ContingentPictureBox";
            this.ContingentPictureBox.Size = new System.Drawing.Size(108, 101);
            this.ContingentPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ContingentPictureBox.TabIndex = 5;
            this.ContingentPictureBox.TabStop = false;
            // 
            // MTBPictureBox
            // 
            this.MTBPictureBox.Image = global::ISUClient.Properties.Resources.ledger_icon;
            this.MTBPictureBox.Location = new System.Drawing.Point(270, 163);
            this.MTBPictureBox.Name = "MTBPictureBox";
            this.MTBPictureBox.Size = new System.Drawing.Size(123, 81);
            this.MTBPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MTBPictureBox.TabIndex = 6;
            this.MTBPictureBox.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ISUClient.Properties.Resources.employee_icon;
            this.pictureBox1.Location = new System.Drawing.Point(449, 153);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 91);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // UserInfoPanel
            // 
            this.UserInfoPanel.BackColor = System.Drawing.SystemColors.Info;
            this.UserInfoPanel.Controls.Add(this.UserIdTextBox);
            this.UserInfoPanel.Controls.Add(this.UserIdLabel);
            this.UserInfoPanel.Controls.Add(this.OrganizationNameTextBox);
            this.UserInfoPanel.Controls.Add(this.OrganizationNameLabel);
            this.UserInfoPanel.Controls.Add(this.PositionNameTextBox);
            this.UserInfoPanel.Controls.Add(this.PositionNameLabel);
            this.UserInfoPanel.Controls.Add(this.UserNameTextBox);
            this.UserInfoPanel.Controls.Add(this.UserNameLabel);
            this.UserInfoPanel.Location = new System.Drawing.Point(76, 12);
            this.UserInfoPanel.Name = "UserInfoPanel";
            this.UserInfoPanel.Size = new System.Drawing.Size(597, 57);
            this.UserInfoPanel.TabIndex = 8;
            // 
            // UserIdTextBox
            // 
            this.UserIdTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserIdTextBox.Location = new System.Drawing.Point(366, 36);
            this.UserIdTextBox.Name = "UserIdTextBox";
            this.UserIdTextBox.ReadOnly = true;
            this.UserIdTextBox.Size = new System.Drawing.Size(228, 18);
            this.UserIdTextBox.TabIndex = 7;
            // 
            // UserIdLabel
            // 
            this.UserIdLabel.AutoSize = true;
            this.UserIdLabel.Location = new System.Drawing.Point(273, 39);
            this.UserIdLabel.Name = "UserIdLabel";
            this.UserIdLabel.Size = new System.Drawing.Size(95, 13);
            this.UserIdLabel.TabIndex = 6;
            this.UserIdLabel.Text = "ID пользователя:";
            // 
            // OrganizationNameTextBox
            // 
            this.OrganizationNameTextBox.Location = new System.Drawing.Point(358, 5);
            this.OrganizationNameTextBox.Name = "OrganizationNameTextBox";
            this.OrganizationNameTextBox.ReadOnly = true;
            this.OrganizationNameTextBox.Size = new System.Drawing.Size(236, 20);
            this.OrganizationNameTextBox.TabIndex = 5;
            // 
            // OrganizationNameLabel
            // 
            this.OrganizationNameLabel.AutoSize = true;
            this.OrganizationNameLabel.Location = new System.Drawing.Point(273, 12);
            this.OrganizationNameLabel.Name = "OrganizationNameLabel";
            this.OrganizationNameLabel.Size = new System.Drawing.Size(78, 13);
            this.OrganizationNameLabel.TabIndex = 4;
            this.OrganizationNameLabel.Text = "Название УЗ:";
            // 
            // PositionNameTextBox
            // 
            this.PositionNameTextBox.Location = new System.Drawing.Point(94, 32);
            this.PositionNameTextBox.Name = "PositionNameTextBox";
            this.PositionNameTextBox.ReadOnly = true;
            this.PositionNameTextBox.Size = new System.Drawing.Size(170, 20);
            this.PositionNameTextBox.TabIndex = 3;
            // 
            // PositionNameLabel
            // 
            this.PositionNameLabel.AutoSize = true;
            this.PositionNameLabel.Location = new System.Drawing.Point(20, 39);
            this.PositionNameLabel.Name = "PositionNameLabel";
            this.PositionNameLabel.Size = new System.Drawing.Size(68, 13);
            this.PositionNameLabel.TabIndex = 2;
            this.PositionNameLabel.Text = "Должность:";
            // 
            // UserNameTextBox
            // 
            this.UserNameTextBox.Location = new System.Drawing.Point(94, 5);
            this.UserNameTextBox.Name = "UserNameTextBox";
            this.UserNameTextBox.ReadOnly = true;
            this.UserNameTextBox.Size = new System.Drawing.Size(170, 20);
            this.UserNameTextBox.TabIndex = 1;
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.AutoSize = true;
            this.UserNameLabel.Location = new System.Drawing.Point(5, 12);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(83, 13);
            this.UserNameLabel.TabIndex = 0;
            this.UserNameLabel.Text = "Пользователь:";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 453);
            this.Controls.Add(this.UserInfoPanel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.MTBPictureBox);
            this.Controls.Add(this.ContingentPictureBox);
            this.Controls.Add(this.EmployeeOpenButton);
            this.Controls.Add(this.LedgerOpenButton);
            this.Controls.Add(this.ContingentOpenButton);
            this.Controls.Add(this.AboutButton);
            this.Controls.Add(this.UserInfoLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ИСУ-клиент";
            ((System.ComponentModel.ISupportInitialize)(this.ContingentPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MTBPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.UserInfoPanel.ResumeLayout(false);
            this.UserInfoPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UserInfoLabel;
        private System.Windows.Forms.Button AboutButton;
        private System.Windows.Forms.Button ContingentOpenButton;
        private System.Windows.Forms.Button LedgerOpenButton;
        private System.Windows.Forms.Button EmployeeOpenButton;
        private System.Windows.Forms.PictureBox ContingentPictureBox;
        private System.Windows.Forms.PictureBox MTBPictureBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel UserInfoPanel;
        private System.Windows.Forms.TextBox OrganizationNameTextBox;
        private System.Windows.Forms.Label OrganizationNameLabel;
        private System.Windows.Forms.TextBox PositionNameTextBox;
        private System.Windows.Forms.Label PositionNameLabel;
        private System.Windows.Forms.TextBox UserNameTextBox;
        private System.Windows.Forms.Label UserNameLabel;
        private System.Windows.Forms.TextBox UserIdTextBox;
        private System.Windows.Forms.Label UserIdLabel;
    }
}

