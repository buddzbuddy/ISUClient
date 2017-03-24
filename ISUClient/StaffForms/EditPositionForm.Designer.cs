﻿namespace UI.StaffForms
{
    partial class EditPositionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditPositionForm));
            this.CancelButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.PositionNameLabel = new System.Windows.Forms.Label();
            this.PositionNameTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(215, 56);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 14;
            this.CancelButton.Text = "Отмена";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(133, 56);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 13;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // PositionNameLabel
            // 
            this.PositionNameLabel.AutoSize = true;
            this.PositionNameLabel.Location = new System.Drawing.Point(27, 19);
            this.PositionNameLabel.Name = "PositionNameLabel";
            this.PositionNameLabel.Size = new System.Drawing.Size(115, 13);
            this.PositionNameLabel.TabIndex = 12;
            this.PositionNameLabel.Text = "Название должности";
            // 
            // PositionNameTextBox
            // 
            this.PositionNameTextBox.Location = new System.Drawing.Point(148, 12);
            this.PositionNameTextBox.Name = "PositionNameTextBox";
            this.PositionNameTextBox.Size = new System.Drawing.Size(248, 20);
            this.PositionNameTextBox.TabIndex = 11;
            // 
            // EditPositionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 104);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.PositionNameLabel);
            this.Controls.Add(this.PositionNameTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditPositionForm";
            this.Text = "Редактировать должность";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label PositionNameLabel;
        private System.Windows.Forms.TextBox PositionNameTextBox;
    }
}