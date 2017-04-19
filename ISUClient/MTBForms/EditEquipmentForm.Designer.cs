namespace UI.MTBForms
{
    partial class EditEquipmentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditEquipmentForm));
            this.CancelButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.EquipmentSupplierSourceTextBox = new System.Windows.Forms.TextBox();
            this.EquipmentPriceTextBox = new System.Windows.Forms.TextBox();
            this.EquipmentWearTextBox = new System.Windows.Forms.TextBox();
            this.EquipmentReleseYearTextBox = new System.Windows.Forms.TextBox();
            this.SupplierSourceLabel = new System.Windows.Forms.Label();
            this.PriceLabel = new System.Windows.Forms.Label();
            this.WearLabel = new System.Windows.Forms.Label();
            this.EquipmentAmountTextBox = new System.Windows.Forms.TextBox();
            this.ReleseYearLabel = new System.Windows.Forms.Label();
            this.EquipmentModelTextBox = new System.Windows.Forms.TextBox();
            this.AmountLabel = new System.Windows.Forms.Label();
            this.ModelLabel = new System.Windows.Forms.Label();
            this.EquipmentProfessionComboBox = new System.Windows.Forms.ComboBox();
            this.ProfessionLabel = new System.Windows.Forms.Label();
            this.EquipmentSectorComboBox = new System.Windows.Forms.ComboBox();
            this.SectorLabel = new System.Windows.Forms.Label();
            this.EquipmentStateComboBox = new System.Windows.Forms.ComboBox();
            this.StateLabel = new System.Windows.Forms.Label();
            this.EquipmentEquipmentCategoryComboBox = new System.Windows.Forms.ComboBox();
            this.EquipmentCategoryLabel = new System.Windows.Forms.Label();
            this.DefPanel = new System.Windows.Forms.Panel();
            this.DefPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(244, 335);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 4;
            this.CancelButton.Text = "Отмена";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(72, 335);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 4;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // EquipmentSupplierSourceTextBox
            // 
            this.EquipmentSupplierSourceTextBox.Location = new System.Drawing.Point(154, 128);
            this.EquipmentSupplierSourceTextBox.Name = "EquipmentSupplierSourceTextBox";
            this.EquipmentSupplierSourceTextBox.Size = new System.Drawing.Size(196, 20);
            this.EquipmentSupplierSourceTextBox.TabIndex = 3;
            // 
            // EquipmentPriceTextBox
            // 
            this.EquipmentPriceTextBox.Location = new System.Drawing.Point(154, 163);
            this.EquipmentPriceTextBox.Name = "EquipmentPriceTextBox";
            this.EquipmentPriceTextBox.Size = new System.Drawing.Size(196, 20);
            this.EquipmentPriceTextBox.TabIndex = 3;
            // 
            // EquipmentWearTextBox
            // 
            this.EquipmentWearTextBox.Location = new System.Drawing.Point(154, 198);
            this.EquipmentWearTextBox.Name = "EquipmentWearTextBox";
            this.EquipmentWearTextBox.Size = new System.Drawing.Size(196, 20);
            this.EquipmentWearTextBox.TabIndex = 3;
            // 
            // EquipmentReleseYearTextBox
            // 
            this.EquipmentReleseYearTextBox.Location = new System.Drawing.Point(154, 93);
            this.EquipmentReleseYearTextBox.Name = "EquipmentReleseYearTextBox";
            this.EquipmentReleseYearTextBox.Size = new System.Drawing.Size(196, 20);
            this.EquipmentReleseYearTextBox.TabIndex = 3;
            // 
            // SupplierSourceLabel
            // 
            this.SupplierSourceLabel.AutoSize = true;
            this.SupplierSourceLabel.Location = new System.Drawing.Point(41, 122);
            this.SupplierSourceLabel.Name = "SupplierSourceLabel";
            this.SupplierSourceLabel.Size = new System.Drawing.Size(107, 26);
            this.SupplierSourceLabel.TabIndex = 2;
            this.SupplierSourceLabel.Text = "Поставщик/Проект\r\n/Источник";
            // 
            // PriceLabel
            // 
            this.PriceLabel.AutoSize = true;
            this.PriceLabel.Location = new System.Drawing.Point(56, 157);
            this.PriceLabel.Name = "PriceLabel";
            this.PriceLabel.Size = new System.Drawing.Size(92, 26);
            this.PriceLabel.TabIndex = 2;
            this.PriceLabel.Text = "Первоначальная\r\nстоимость";
            // 
            // WearLabel
            // 
            this.WearLabel.AutoSize = true;
            this.WearLabel.Location = new System.Drawing.Point(12, 192);
            this.WearLabel.Name = "WearLabel";
            this.WearLabel.Size = new System.Drawing.Size(136, 26);
            this.WearLabel.TabIndex = 2;
            this.WearLabel.Text = "Износ (амортизационное\r\nотчисление)";
            // 
            // EquipmentAmountTextBox
            // 
            this.EquipmentAmountTextBox.Location = new System.Drawing.Point(154, 67);
            this.EquipmentAmountTextBox.Name = "EquipmentAmountTextBox";
            this.EquipmentAmountTextBox.Size = new System.Drawing.Size(196, 20);
            this.EquipmentAmountTextBox.TabIndex = 3;
            // 
            // ReleseYearLabel
            // 
            this.ReleseYearLabel.AutoSize = true;
            this.ReleseYearLabel.Location = new System.Drawing.Point(77, 100);
            this.ReleseYearLabel.Name = "ReleseYearLabel";
            this.ReleseYearLabel.Size = new System.Drawing.Size(71, 13);
            this.ReleseYearLabel.TabIndex = 2;
            this.ReleseYearLabel.Text = "Год выпуска";
            // 
            // EquipmentModelTextBox
            // 
            this.EquipmentModelTextBox.Location = new System.Drawing.Point(154, 41);
            this.EquipmentModelTextBox.Name = "EquipmentModelTextBox";
            this.EquipmentModelTextBox.Size = new System.Drawing.Size(196, 20);
            this.EquipmentModelTextBox.TabIndex = 3;
            // 
            // AmountLabel
            // 
            this.AmountLabel.AutoSize = true;
            this.AmountLabel.Location = new System.Drawing.Point(107, 74);
            this.AmountLabel.Name = "AmountLabel";
            this.AmountLabel.Size = new System.Drawing.Size(41, 13);
            this.AmountLabel.TabIndex = 2;
            this.AmountLabel.Text = "Кол-во";
            // 
            // ModelLabel
            // 
            this.ModelLabel.AutoSize = true;
            this.ModelLabel.Location = new System.Drawing.Point(102, 48);
            this.ModelLabel.Name = "ModelLabel";
            this.ModelLabel.Size = new System.Drawing.Size(46, 13);
            this.ModelLabel.TabIndex = 2;
            this.ModelLabel.Text = "Модель";
            // 
            // EquipmentProfessionComboBox
            // 
            this.EquipmentProfessionComboBox.FormattingEnabled = true;
            this.EquipmentProfessionComboBox.Location = new System.Drawing.Point(154, 278);
            this.EquipmentProfessionComboBox.Name = "EquipmentProfessionComboBox";
            this.EquipmentProfessionComboBox.Size = new System.Drawing.Size(196, 21);
            this.EquipmentProfessionComboBox.TabIndex = 1;
            // 
            // ProfessionLabel
            // 
            this.ProfessionLabel.AutoSize = true;
            this.ProfessionLabel.Location = new System.Drawing.Point(83, 286);
            this.ProfessionLabel.Name = "ProfessionLabel";
            this.ProfessionLabel.Size = new System.Drawing.Size(65, 13);
            this.ProfessionLabel.TabIndex = 0;
            this.ProfessionLabel.Text = "Профессия";
            // 
            // EquipmentSectorComboBox
            // 
            this.EquipmentSectorComboBox.FormattingEnabled = true;
            this.EquipmentSectorComboBox.Location = new System.Drawing.Point(154, 251);
            this.EquipmentSectorComboBox.Name = "EquipmentSectorComboBox";
            this.EquipmentSectorComboBox.Size = new System.Drawing.Size(196, 21);
            this.EquipmentSectorComboBox.TabIndex = 1;
            // 
            // SectorLabel
            // 
            this.SectorLabel.AutoSize = true;
            this.SectorLabel.Location = new System.Drawing.Point(98, 259);
            this.SectorLabel.Name = "SectorLabel";
            this.SectorLabel.Size = new System.Drawing.Size(50, 13);
            this.SectorLabel.TabIndex = 0;
            this.SectorLabel.Text = "Отрасль";
            // 
            // EquipmentStateComboBox
            // 
            this.EquipmentStateComboBox.FormattingEnabled = true;
            this.EquipmentStateComboBox.Location = new System.Drawing.Point(154, 224);
            this.EquipmentStateComboBox.Name = "EquipmentStateComboBox";
            this.EquipmentStateComboBox.Size = new System.Drawing.Size(196, 21);
            this.EquipmentStateComboBox.TabIndex = 1;
            // 
            // StateLabel
            // 
            this.StateLabel.AutoSize = true;
            this.StateLabel.Location = new System.Drawing.Point(87, 232);
            this.StateLabel.Name = "StateLabel";
            this.StateLabel.Size = new System.Drawing.Size(61, 13);
            this.StateLabel.TabIndex = 0;
            this.StateLabel.Text = "Состояние";
            // 
            // EquipmentEquipmentCategoryComboBox
            // 
            this.EquipmentEquipmentCategoryComboBox.FormattingEnabled = true;
            this.EquipmentEquipmentCategoryComboBox.Location = new System.Drawing.Point(154, 13);
            this.EquipmentEquipmentCategoryComboBox.Name = "EquipmentEquipmentCategoryComboBox";
            this.EquipmentEquipmentCategoryComboBox.Size = new System.Drawing.Size(196, 21);
            this.EquipmentEquipmentCategoryComboBox.TabIndex = 1;
            // 
            // EquipmentCategoryLabel
            // 
            this.EquipmentCategoryLabel.AutoSize = true;
            this.EquipmentCategoryLabel.Location = new System.Drawing.Point(14, 21);
            this.EquipmentCategoryLabel.Name = "EquipmentCategoryLabel";
            this.EquipmentCategoryLabel.Size = new System.Drawing.Size(134, 13);
            this.EquipmentCategoryLabel.TabIndex = 0;
            this.EquipmentCategoryLabel.Text = "Категория оборудования";
            // 
            // DefPanel
            // 
            this.DefPanel.AutoScroll = true;
            this.DefPanel.Controls.Add(this.CancelButton);
            this.DefPanel.Controls.Add(this.SaveButton);
            this.DefPanel.Controls.Add(this.EquipmentSupplierSourceTextBox);
            this.DefPanel.Controls.Add(this.EquipmentPriceTextBox);
            this.DefPanel.Controls.Add(this.EquipmentWearTextBox);
            this.DefPanel.Controls.Add(this.EquipmentReleseYearTextBox);
            this.DefPanel.Controls.Add(this.SupplierSourceLabel);
            this.DefPanel.Controls.Add(this.PriceLabel);
            this.DefPanel.Controls.Add(this.WearLabel);
            this.DefPanel.Controls.Add(this.EquipmentAmountTextBox);
            this.DefPanel.Controls.Add(this.ReleseYearLabel);
            this.DefPanel.Controls.Add(this.EquipmentModelTextBox);
            this.DefPanel.Controls.Add(this.AmountLabel);
            this.DefPanel.Controls.Add(this.ModelLabel);
            this.DefPanel.Controls.Add(this.EquipmentProfessionComboBox);
            this.DefPanel.Controls.Add(this.ProfessionLabel);
            this.DefPanel.Controls.Add(this.EquipmentSectorComboBox);
            this.DefPanel.Controls.Add(this.SectorLabel);
            this.DefPanel.Controls.Add(this.EquipmentStateComboBox);
            this.DefPanel.Controls.Add(this.StateLabel);
            this.DefPanel.Controls.Add(this.EquipmentEquipmentCategoryComboBox);
            this.DefPanel.Controls.Add(this.EquipmentCategoryLabel);
            this.DefPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DefPanel.Location = new System.Drawing.Point(0, 0);
            this.DefPanel.Name = "DefPanel";
            this.DefPanel.Size = new System.Drawing.Size(403, 408);
            this.DefPanel.TabIndex = 1;
            // 
            // EditEquipmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 408);
            this.Controls.Add(this.DefPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditEquipmentForm";
            this.Text = "Редактирование оборудования";
            this.DefPanel.ResumeLayout(false);
            this.DefPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TextBox EquipmentSupplierSourceTextBox;
        private System.Windows.Forms.TextBox EquipmentPriceTextBox;
        private System.Windows.Forms.TextBox EquipmentWearTextBox;
        private System.Windows.Forms.TextBox EquipmentReleseYearTextBox;
        private System.Windows.Forms.Label SupplierSourceLabel;
        private System.Windows.Forms.Label PriceLabel;
        private System.Windows.Forms.Label WearLabel;
        private System.Windows.Forms.TextBox EquipmentAmountTextBox;
        private System.Windows.Forms.Label ReleseYearLabel;
        private System.Windows.Forms.TextBox EquipmentModelTextBox;
        private System.Windows.Forms.Label AmountLabel;
        private System.Windows.Forms.Label ModelLabel;
        private System.Windows.Forms.ComboBox EquipmentProfessionComboBox;
        private System.Windows.Forms.Label ProfessionLabel;
        private System.Windows.Forms.ComboBox EquipmentSectorComboBox;
        private System.Windows.Forms.Label SectorLabel;
        private System.Windows.Forms.ComboBox EquipmentStateComboBox;
        private System.Windows.Forms.Label StateLabel;
        private System.Windows.Forms.ComboBox EquipmentEquipmentCategoryComboBox;
        private System.Windows.Forms.Label EquipmentCategoryLabel;
        private System.Windows.Forms.Panel DefPanel;
    }
}