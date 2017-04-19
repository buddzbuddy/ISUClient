namespace UI.MTBForms
{
    partial class MTBForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MTBForm));
            this.DataGridViewBuildings = new System.Windows.Forms.DataGridView();
            this.BuildingId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BuildingBuildingPurpose = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.BuildingBuildingType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.BuildingBuildYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BuildingExploitationYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BuildingFloorAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShowBuildingLink = new System.Windows.Forms.DataGridViewLinkColumn();
            this.EditBuildingLink = new System.Windows.Forms.DataGridViewLinkColumn();
            this.DeleteBuildingLink = new System.Windows.Forms.DataGridViewLinkColumn();
            this.AddBuildingButton = new System.Windows.Forms.Button();
            this.DataGridViewEquipments = new System.Windows.Forms.DataGridView();
            this.AddEquipmentButton = new System.Windows.Forms.Button();
            this.EquipmentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EquipmentEquipmentCategory = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.EquipmentSector = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.EquipmentProfession = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.EquipmentModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EquipmentReleseYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EquipmentAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EquipmentPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EquipmentWear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShowEquipmentLink = new System.Windows.Forms.DataGridViewLinkColumn();
            this.EditEquipmentLink = new System.Windows.Forms.DataGridViewLinkColumn();
            this.EquipmentDeleteLink = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewBuildings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewEquipments)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridViewBuildings
            // 
            this.DataGridViewBuildings.AllowUserToAddRows = false;
            this.DataGridViewBuildings.AllowUserToDeleteRows = false;
            this.DataGridViewBuildings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewBuildings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BuildingId,
            this.BuildingBuildingPurpose,
            this.BuildingBuildingType,
            this.BuildingBuildYear,
            this.BuildingExploitationYear,
            this.BuildingFloorAmount,
            this.ShowBuildingLink,
            this.EditBuildingLink,
            this.DeleteBuildingLink});
            this.DataGridViewBuildings.Location = new System.Drawing.Point(13, 13);
            this.DataGridViewBuildings.Name = "DataGridViewBuildings";
            this.DataGridViewBuildings.ReadOnly = true;
            this.DataGridViewBuildings.Size = new System.Drawing.Size(929, 150);
            this.DataGridViewBuildings.TabIndex = 0;
            this.DataGridViewBuildings.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewBuildings_CellContentClick);
            // 
            // BuildingId
            // 
            this.BuildingId.HeaderText = "Id";
            this.BuildingId.Name = "BuildingId";
            this.BuildingId.ReadOnly = true;
            this.BuildingId.Visible = false;
            // 
            // BuildingBuildingPurpose
            // 
            this.BuildingBuildingPurpose.HeaderText = "Назначение";
            this.BuildingBuildingPurpose.Name = "BuildingBuildingPurpose";
            this.BuildingBuildingPurpose.ReadOnly = true;
            this.BuildingBuildingPurpose.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BuildingBuildingPurpose.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // BuildingBuildingType
            // 
            this.BuildingBuildingType.HeaderText = "Тип";
            this.BuildingBuildingType.Name = "BuildingBuildingType";
            this.BuildingBuildingType.ReadOnly = true;
            // 
            // BuildingBuildYear
            // 
            this.BuildingBuildYear.HeaderText = "Год постройки";
            this.BuildingBuildYear.Name = "BuildingBuildYear";
            this.BuildingBuildYear.ReadOnly = true;
            // 
            // BuildingExploitationYear
            // 
            this.BuildingExploitationYear.HeaderText = "Введен в эксплуатацию";
            this.BuildingExploitationYear.Name = "BuildingExploitationYear";
            this.BuildingExploitationYear.ReadOnly = true;
            // 
            // BuildingFloorAmount
            // 
            this.BuildingFloorAmount.HeaderText = "Кол-во этажей";
            this.BuildingFloorAmount.Name = "BuildingFloorAmount";
            this.BuildingFloorAmount.ReadOnly = true;
            // 
            // ShowBuildingLink
            // 
            this.ShowBuildingLink.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ShowBuildingLink.HeaderText = "";
            this.ShowBuildingLink.Name = "ShowBuildingLink";
            this.ShowBuildingLink.ReadOnly = true;
            this.ShowBuildingLink.Text = "открыть";
            this.ShowBuildingLink.TrackVisitedState = false;
            this.ShowBuildingLink.UseColumnTextForLinkValue = true;
            this.ShowBuildingLink.Width = 5;
            // 
            // EditBuildingLink
            // 
            this.EditBuildingLink.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.EditBuildingLink.HeaderText = "";
            this.EditBuildingLink.Name = "EditBuildingLink";
            this.EditBuildingLink.ReadOnly = true;
            this.EditBuildingLink.Text = "изменить";
            this.EditBuildingLink.TrackVisitedState = false;
            this.EditBuildingLink.UseColumnTextForLinkValue = true;
            this.EditBuildingLink.Width = 5;
            // 
            // DeleteBuildingLink
            // 
            this.DeleteBuildingLink.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DeleteBuildingLink.HeaderText = "";
            this.DeleteBuildingLink.Name = "DeleteBuildingLink";
            this.DeleteBuildingLink.ReadOnly = true;
            this.DeleteBuildingLink.Text = "удалить";
            this.DeleteBuildingLink.TrackVisitedState = false;
            this.DeleteBuildingLink.UseColumnTextForLinkValue = true;
            this.DeleteBuildingLink.Width = 5;
            // 
            // AddBuildingButton
            // 
            this.AddBuildingButton.Location = new System.Drawing.Point(949, 13);
            this.AddBuildingButton.Name = "AddBuildingButton";
            this.AddBuildingButton.Size = new System.Drawing.Size(75, 37);
            this.AddBuildingButton.TabIndex = 1;
            this.AddBuildingButton.Text = "Добавить здание";
            this.AddBuildingButton.UseVisualStyleBackColor = true;
            this.AddBuildingButton.Click += new System.EventHandler(this.AddBuildingButton_Click);
            // 
            // DataGridViewEquipments
            // 
            this.DataGridViewEquipments.AllowUserToAddRows = false;
            this.DataGridViewEquipments.AllowUserToDeleteRows = false;
            this.DataGridViewEquipments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewEquipments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EquipmentId,
            this.EquipmentEquipmentCategory,
            this.EquipmentSector,
            this.EquipmentProfession,
            this.EquipmentModel,
            this.EquipmentReleseYear,
            this.EquipmentAmount,
            this.EquipmentPrice,
            this.EquipmentWear,
            this.ShowEquipmentLink,
            this.EditEquipmentLink,
            this.EquipmentDeleteLink});
            this.DataGridViewEquipments.Location = new System.Drawing.Point(13, 228);
            this.DataGridViewEquipments.Name = "DataGridViewEquipments";
            this.DataGridViewEquipments.ReadOnly = true;
            this.DataGridViewEquipments.Size = new System.Drawing.Size(929, 150);
            this.DataGridViewEquipments.TabIndex = 2;
            this.DataGridViewEquipments.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewEquipments_CellContentClick);
            // 
            // AddEquipmentButton
            // 
            this.AddEquipmentButton.Location = new System.Drawing.Point(949, 228);
            this.AddEquipmentButton.Name = "AddEquipmentButton";
            this.AddEquipmentButton.Size = new System.Drawing.Size(90, 36);
            this.AddEquipmentButton.TabIndex = 3;
            this.AddEquipmentButton.Text = "Добавить оборудование";
            this.AddEquipmentButton.UseVisualStyleBackColor = true;
            this.AddEquipmentButton.Click += new System.EventHandler(this.AddEquipmentButton_Click);
            // 
            // EquipmentId
            // 
            this.EquipmentId.HeaderText = "Id";
            this.EquipmentId.Name = "EquipmentId";
            this.EquipmentId.ReadOnly = true;
            this.EquipmentId.Visible = false;
            // 
            // EquipmentEquipmentCategory
            // 
            this.EquipmentEquipmentCategory.HeaderText = "Категория";
            this.EquipmentEquipmentCategory.Name = "EquipmentEquipmentCategory";
            this.EquipmentEquipmentCategory.ReadOnly = true;
            // 
            // EquipmentSector
            // 
            this.EquipmentSector.HeaderText = "Отрасль";
            this.EquipmentSector.Name = "EquipmentSector";
            this.EquipmentSector.ReadOnly = true;
            // 
            // EquipmentProfession
            // 
            this.EquipmentProfession.HeaderText = "Специальность";
            this.EquipmentProfession.Name = "EquipmentProfession";
            this.EquipmentProfession.ReadOnly = true;
            // 
            // EquipmentModel
            // 
            this.EquipmentModel.HeaderText = "Модель/Марка";
            this.EquipmentModel.Name = "EquipmentModel";
            this.EquipmentModel.ReadOnly = true;
            // 
            // EquipmentReleseYear
            // 
            this.EquipmentReleseYear.HeaderText = "Год выпуска";
            this.EquipmentReleseYear.Name = "EquipmentReleseYear";
            this.EquipmentReleseYear.ReadOnly = true;
            // 
            // EquipmentAmount
            // 
            this.EquipmentAmount.HeaderText = "Кол-во";
            this.EquipmentAmount.Name = "EquipmentAmount";
            this.EquipmentAmount.ReadOnly = true;
            // 
            // EquipmentPrice
            // 
            this.EquipmentPrice.HeaderText = "Первоначальная стоимость";
            this.EquipmentPrice.Name = "EquipmentPrice";
            this.EquipmentPrice.ReadOnly = true;
            // 
            // EquipmentWear
            // 
            this.EquipmentWear.HeaderText = "Износ (амортизационное отчисление)";
            this.EquipmentWear.Name = "EquipmentWear";
            this.EquipmentWear.ReadOnly = true;
            // 
            // ShowEquipmentLink
            // 
            this.ShowEquipmentLink.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ShowEquipmentLink.HeaderText = "";
            this.ShowEquipmentLink.Name = "ShowEquipmentLink";
            this.ShowEquipmentLink.ReadOnly = true;
            this.ShowEquipmentLink.Text = "открыть";
            this.ShowEquipmentLink.TrackVisitedState = false;
            this.ShowEquipmentLink.UseColumnTextForLinkValue = true;
            this.ShowEquipmentLink.Visible = false;
            this.ShowEquipmentLink.Width = 5;
            // 
            // EditEquipmentLink
            // 
            this.EditEquipmentLink.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.EditEquipmentLink.HeaderText = "";
            this.EditEquipmentLink.Name = "EditEquipmentLink";
            this.EditEquipmentLink.ReadOnly = true;
            this.EditEquipmentLink.Text = "изменить";
            this.EditEquipmentLink.TrackVisitedState = false;
            this.EditEquipmentLink.UseColumnTextForLinkValue = true;
            this.EditEquipmentLink.Width = 5;
            // 
            // EquipmentDeleteLink
            // 
            this.EquipmentDeleteLink.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.EquipmentDeleteLink.HeaderText = "";
            this.EquipmentDeleteLink.Name = "EquipmentDeleteLink";
            this.EquipmentDeleteLink.ReadOnly = true;
            this.EquipmentDeleteLink.Text = "удалить";
            this.EquipmentDeleteLink.TrackVisitedState = false;
            this.EquipmentDeleteLink.UseColumnTextForLinkValue = true;
            this.EquipmentDeleteLink.Width = 5;
            // 
            // MTBForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 464);
            this.Controls.Add(this.AddEquipmentButton);
            this.Controls.Add(this.DataGridViewEquipments);
            this.Controls.Add(this.AddBuildingButton);
            this.Controls.Add(this.DataGridViewBuildings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MTBForm";
            this.Text = "Материально-техническая база";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewBuildings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewEquipments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView DataGridViewBuildings;
        private System.Windows.Forms.DataGridViewTextBoxColumn BuildingId;
        private System.Windows.Forms.DataGridViewComboBoxColumn BuildingBuildingPurpose;
        private System.Windows.Forms.DataGridViewComboBoxColumn BuildingBuildingType;
        private System.Windows.Forms.DataGridViewTextBoxColumn BuildingBuildYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn BuildingExploitationYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn BuildingFloorAmount;
        private System.Windows.Forms.DataGridViewLinkColumn ShowBuildingLink;
        private System.Windows.Forms.DataGridViewLinkColumn EditBuildingLink;
        private System.Windows.Forms.DataGridViewLinkColumn DeleteBuildingLink;
        private System.Windows.Forms.Button AddBuildingButton;
        public System.Windows.Forms.DataGridView DataGridViewEquipments;
        private System.Windows.Forms.Button AddEquipmentButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn EquipmentId;
        private System.Windows.Forms.DataGridViewComboBoxColumn EquipmentEquipmentCategory;
        private System.Windows.Forms.DataGridViewComboBoxColumn EquipmentSector;
        private System.Windows.Forms.DataGridViewComboBoxColumn EquipmentProfession;
        private System.Windows.Forms.DataGridViewTextBoxColumn EquipmentModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn EquipmentReleseYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn EquipmentAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn EquipmentPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn EquipmentWear;
        private System.Windows.Forms.DataGridViewLinkColumn ShowEquipmentLink;
        private System.Windows.Forms.DataGridViewLinkColumn EditEquipmentLink;
        private System.Windows.Forms.DataGridViewLinkColumn EquipmentDeleteLink;
    }
}