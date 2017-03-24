namespace UI.StaffForms
{
    partial class ViewPositionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewPositionForm));
            this.PositionNameLabel = new System.Windows.Forms.Label();
            this.PositionNameTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // PositionNameLabel
            // 
            this.PositionNameLabel.AutoSize = true;
            this.PositionNameLabel.Location = new System.Drawing.Point(20, 19);
            this.PositionNameLabel.Name = "PositionNameLabel";
            this.PositionNameLabel.Size = new System.Drawing.Size(115, 13);
            this.PositionNameLabel.TabIndex = 3;
            this.PositionNameLabel.Text = "Название должности";
            // 
            // PositionNameTextBox
            // 
            this.PositionNameTextBox.Location = new System.Drawing.Point(141, 12);
            this.PositionNameTextBox.Name = "PositionNameTextBox";
            this.PositionNameTextBox.ReadOnly = true;
            this.PositionNameTextBox.Size = new System.Drawing.Size(248, 20);
            this.PositionNameTextBox.TabIndex = 2;
            // 
            // ViewPositionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 161);
            this.Controls.Add(this.PositionNameLabel);
            this.Controls.Add(this.PositionNameTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ViewPositionForm";
            this.Text = "Просмотр должности";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PositionNameLabel;
        private System.Windows.Forms.TextBox PositionNameTextBox;
    }
}