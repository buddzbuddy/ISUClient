using Domain.Entities;
using Domain.Entities.Contingent;
using Logic.Repositories;
using System;
using System.Linq;
using System.Windows.Forms;

namespace UI.ContingentForms
{
    public partial class EditGroupForm : Form
    {
        ContingentForm _contingentForm = null;

        Group _obj;

        public EditGroupForm(ContingentForm contingentForm, Group obj)
        {
            InitializeComponent();

            _contingentForm = contingentForm;
            _obj = obj;
            GroupNameTextBox.Text = obj.Name;

            FormManager.InitializeComboBoxes(this, obj);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FillObj()
        {
            _obj.Name = GroupNameTextBox.Text;
            _obj.Language = Guid.Parse(GroupLanguageComboBox.SelectedValue.ToString());
            _obj.StudyPeriod = Guid.Parse(GroupStudyPeriodComboBox.SelectedValue.ToString());
            _obj.Profession = Guid.Parse(GroupProfessionComboBox.SelectedValue.ToString());
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            string errorMessage;
            FillObj();
            if (SaveToLocalDb(out errorMessage))
            {
                try
                {
                    var _docRepo = new DocRepository();
                    FormManager.LoadToDataGridView(_contingentForm.DataGridViewGroups, _docRepo.GetAll<Group>().ToList());
                    var Students = _docRepo.GetAll<Student>().ToList();
                    Students.ForEach(x => x.PersonObj = _docRepo.Get<Person>(x.Person));
                    FormManager.LoadToDataGridView(_contingentForm.DataGridViewStudents, Students);
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

        private bool SaveToLocalDb(out string errorMessage)
        {
            var _docRepo = new DocRepository();
            errorMessage = "";

            //TODO: Write to progress bar

            //Save changes to xml-db
            try
            {
                _docRepo.Save(_obj, true);
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
