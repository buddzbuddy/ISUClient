namespace UI
{
    partial class SynchronizeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SynchronizeForm));
            this.SyncInfoTextBox = new System.Windows.Forms.TextBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SyncInfoTextBox
            // 
            this.SyncInfoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SyncInfoTextBox.Location = new System.Drawing.Point(12, 12);
            this.SyncInfoTextBox.Multiline = true;
            this.SyncInfoTextBox.Name = "SyncInfoTextBox";
            this.SyncInfoTextBox.ReadOnly = true;
            this.SyncInfoTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SyncInfoTextBox.Size = new System.Drawing.Size(542, 163);
            this.SyncInfoTextBox.TabIndex = 0;
            this.SyncInfoTextBox.Text = "Статус синхронизации";
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(13, 320);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 1;
            this.StartButton.Text = "Старт";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // SynchronizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 576);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.SyncInfoTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SynchronizeForm";
            this.Text = "Синхронизация с центральной базой";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SyncInfoTextBox;
        private System.Windows.Forms.Button StartButton;
    }
}