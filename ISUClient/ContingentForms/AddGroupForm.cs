using Domain.Entities.Contingent;
using Logic.Repositories;
using System;
using System.Windows.Forms;

namespace UI.ContingentForms
{
    public partial class AddGroupForm : Form
    {
        ContingentForm _contingentForm = null;

        public AddGroupForm(ContingentForm contingentForm)
        {
            InitializeComponent();

            _contingentForm = contingentForm;
            
            FormManager.InitializeComboBoxes(this, new Group());
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var group = new Group
            {
                Id = Guid.NewGuid(),
                Name = GroupNameTextBox.Text,
                Language = GroupLanguageComboBox.SelectedItem != null ? (Guid?)GroupLanguageComboBox.SelectedValue : null,
                Profession = GroupProfessionComboBox.SelectedItem != null ? (Guid?)GroupProfessionComboBox.SelectedValue : null,
                StudyPeriod = GroupStudyPeriodComboBox.SelectedItem != null ? (Guid?)GroupStudyPeriodComboBox.SelectedValue : null,
                IsNew = true
            };
            string errorMessage;
            if (SaveToLocalDb(group, out errorMessage))
            {
                try
                {
                    var _docRepo = new DocRepository();
                    FormManager.LoadToDataGridView(_contingentForm.DataGridViewGroups, _docRepo.GetAll<Group>());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    this.Close();
                }
                
            }
            else
            {
                MessageBox.Show(errorMessage, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool SaveToLocalDb(Group obj, out string errorMessage)
        {
            errorMessage = "";

            //TODO: Write to progress bar

            //Save to xml-db
            try
            {
                var _docRepo = new DocRepository();
                _docRepo.Save(obj);
            }
            catch (Exception e)
            {
                //TODO: WriteLog("Breaking the initializing by exception, " + e.Message + ", count persons - " + i);
                errorMessage = e.Message;
                return false;
            }
            return true;
        }
    }
}
