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
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewBuildings)).BeginInit();
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
            // MTBForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 464);
            this.Controls.Add(this.AddBuildingButton);
            this.Controls.Add(this.DataGridViewBuildings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MTBForm";
            this.Text = "Материально-техническая база";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewBuildings)).EndInit();
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
    }
}