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
            this.HostAddressLabel = new System.Windows.Forms.Label();
            this.HostAddressTextBox = new System.Windows.Forms.TextBox();
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
            this.StartButton.BackgroundImage = global::UI.Properties.Resources.play_button;
            this.StartButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.StartButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartButton.Location = new System.Drawing.Point(180, 222);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(206, 177);
            this.StartButton.TabIndex = 1;
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // HostAddressLabel
            // 
            this.HostAddressLabel.AutoSize = true;
            this.HostAddressLabel.Location = new System.Drawing.Point(334, 184);
            this.HostAddressLabel.Name = "HostAddressLabel";
            this.HostAddressLabel.Size = new System.Drawing.Size(120, 13);
            this.HostAddressLabel.TabIndex = 5;
            this.HostAddressLabel.Text = "Адрес сервера: http://";
            // 
            // HostAddressTextBox
            // 
            this.HostAddressTextBox.Location = new System.Drawing.Point(454, 181);
            this.HostAddressTextBox.Name = "HostAddressTextBox";
            this.HostAddressTextBox.Size = new System.Drawing.Size(100, 20);
            this.HostAddressTextBox.TabIndex = 4;
            this.HostAddressTextBox.Text = "isu.kesip.kg:8080";
            // 
            // SynchronizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 463);
            this.Controls.Add(this.HostAddressLabel);
            this.Controls.Add(this.HostAddressTextBox);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.SyncInfoTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SynchronizeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Синхронизация с центральной базой";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SyncInfoTextBox;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label HostAddressLabel;
        private System.Windows.Forms.TextBox HostAddressTextBox;
    }
}