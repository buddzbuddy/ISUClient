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
            this.opentContingent = new System.Windows.Forms.Button();
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
            this.button.Location = new System.Drawing.Point(181, 12);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(91, 23);
            this.button.TabIndex = 1;
            this.button.Text = "О программе";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // opentContingent
            // 
            this.opentContingent.Location = new System.Drawing.Point(16, 65);
            this.opentContingent.Name = "opentContingent";
            this.opentContingent.Size = new System.Drawing.Size(75, 23);
            this.opentContingent.TabIndex = 2;
            this.opentContingent.Text = "Контингент";
            this.opentContingent.UseVisualStyleBackColor = true;
            this.opentContingent.Click += new System.EventHandler(this.opentContingent_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.opentContingent);
            this.Controls.Add(this.button);
            this.Controls.Add(this.Description);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "ИСУ-клиент";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Description;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.Button opentContingent;
    }
}

