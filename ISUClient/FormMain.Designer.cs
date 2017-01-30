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
            this.Description = new System.Windows.Forms.Label();
            this.button = new System.Windows.Forms.Button();
            this.ContingentOpenButton = new System.Windows.Forms.Button();
            this.MTBOpenButton = new System.Windows.Forms.Button();
            this.EmployeeOpenButton = new System.Windows.Forms.Button();
            this.ContingentPictureBox = new System.Windows.Forms.PictureBox();
            this.MTBPictureBox = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ContingentPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MTBPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Description
            // 
            this.Description.AutoSize = true;
            this.Description.Location = new System.Drawing.Point(13, 13);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(57, 13);
            this.Description.TabIndex = 0;
            this.Description.Text = "Описание";
            // 
            // button
            // 
            this.button.Location = new System.Drawing.Point(12, 418);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(91, 23);
            this.button.TabIndex = 1;
            this.button.Text = "О программе";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // ContingentOpenButton
            // 
            this.ContingentOpenButton.Location = new System.Drawing.Point(115, 167);
            this.ContingentOpenButton.Name = "ContingentOpenButton";
            this.ContingentOpenButton.Size = new System.Drawing.Size(75, 23);
            this.ContingentOpenButton.TabIndex = 2;
            this.ContingentOpenButton.Text = "Контингент";
            this.ContingentOpenButton.UseVisualStyleBackColor = true;
            this.ContingentOpenButton.Click += new System.EventHandler(this.opentContingent_Click);
            // 
            // MTBOpenButton
            // 
            this.MTBOpenButton.Location = new System.Drawing.Point(288, 167);
            this.MTBOpenButton.Name = "MTBOpenButton";
            this.MTBOpenButton.Size = new System.Drawing.Size(75, 23);
            this.MTBOpenButton.TabIndex = 3;
            this.MTBOpenButton.Text = "МТБ";
            this.MTBOpenButton.UseVisualStyleBackColor = true;
            // 
            // EmployeeOpenButton
            // 
            this.EmployeeOpenButton.Location = new System.Drawing.Point(469, 166);
            this.EmployeeOpenButton.Name = "EmployeeOpenButton";
            this.EmployeeOpenButton.Size = new System.Drawing.Size(75, 23);
            this.EmployeeOpenButton.TabIndex = 4;
            this.EmployeeOpenButton.Text = "Кадры";
            this.EmployeeOpenButton.UseVisualStyleBackColor = true;
            // 
            // ContingentPictureBox
            // 
            this.ContingentPictureBox.Image = global::ISUClient.Properties.Resources.student_icon;
            this.ContingentPictureBox.Location = new System.Drawing.Point(103, 60);
            this.ContingentPictureBox.Name = "ContingentPictureBox";
            this.ContingentPictureBox.Size = new System.Drawing.Size(108, 101);
            this.ContingentPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ContingentPictureBox.TabIndex = 5;
            this.ContingentPictureBox.TabStop = false;
            // 
            // MTBPictureBox
            // 
            this.MTBPictureBox.Image = global::ISUClient.Properties.Resources.ledger_icon;
            this.MTBPictureBox.Location = new System.Drawing.Point(265, 80);
            this.MTBPictureBox.Name = "MTBPictureBox";
            this.MTBPictureBox.Size = new System.Drawing.Size(123, 81);
            this.MTBPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MTBPictureBox.TabIndex = 6;
            this.MTBPictureBox.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ISUClient.Properties.Resources.employee_icon;
            this.pictureBox1.Location = new System.Drawing.Point(456, 69);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 91);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 453);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.MTBPictureBox);
            this.Controls.Add(this.ContingentPictureBox);
            this.Controls.Add(this.EmployeeOpenButton);
            this.Controls.Add(this.MTBOpenButton);
            this.Controls.Add(this.ContingentOpenButton);
            this.Controls.Add(this.button);
            this.Controls.Add(this.Description);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ИСУ-клиент";
            ((System.ComponentModel.ISupportInitialize)(this.ContingentPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MTBPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Description;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.Button ContingentOpenButton;
        private System.Windows.Forms.Button MTBOpenButton;
        private System.Windows.Forms.Button EmployeeOpenButton;
        private System.Windows.Forms.PictureBox ContingentPictureBox;
        private System.Windows.Forms.PictureBox MTBPictureBox;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

