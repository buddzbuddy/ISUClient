using Domain.Entities.Contingent;
using Domain.StaticReferences;
using Logic.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace UI.ContingentForms
{
    public partial class EditGroupForm : Form
    {
        ContingentForm _contingentForm = null;

        DocRepository _docRepo;
        EnumRepository _enumRepo;
        Group _obj;

        public EditGroupForm(ContingentForm contingentForm, Group obj)
        {
            InitializeComponent();

            _contingentForm = contingentForm;
            _docRepo = new DocRepository();
            _enumRepo = new EnumRepository();
            InitSources(obj.Language, obj.StudyPeriod, obj.Profession);
            _obj = obj;

            NameTextBox.Text = obj.Name;
        }

        private void InitSources(Guid? Language, Guid? studyPeriod, Guid? profession)
        {
            InitLanguages(Language);
            InitStudyPeriods(studyPeriod);
            InitProfessions(profession);
        }

        private void InitLanguages(Guid? value)
        {
            LanguageComboBox.DataSource = _enumRepo.GetEnum(Enums.LanguageEnumDefId).Items;
            LanguageComboBox.DisplayMember = "FullName";
            LanguageComboBox.ValueMember = "Id";
            if (value != null)
                LanguageComboBox.SelectedValue = value;
        }
        private void InitStudyPeriods(Guid? value)
        {
            StudyPeriodComboBox.DataSource = _enumRepo.GetEnum(Enums.StudyPeriodEnumDefId).Items;
            StudyPeriodComboBox.DisplayMember = "FullName";
            StudyPeriodComboBox.ValueMember = "Id";
            if (value != null)
                StudyPeriodComboBox.SelectedValue = value;
        }

        private void InitProfessions(Guid? value)
        {
            ProfessionComboBox.DataSource = _docRepo.GetAll<Profession>().ToList();
            ProfessionComboBox.DisplayMember = "Name";
            ProfessionComboBox.ValueMember = "Id";
            if (value != null)
                ProfessionComboBox.SelectedValue = value;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FillObj()
        {
            _obj.Name = NameTextBox.Text;
            _obj.Language = Guid.Parse(LanguageComboBox.SelectedValue.ToString());
            _obj.StudyPeriod = Guid.Parse(StudyPeriodComboBox.SelectedValue.ToString());
            _obj.Profession = Guid.Parse(ProfessionComboBox.SelectedValue.ToString());
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            string errorMessage;
            FillObj();
            if (SaveToLocalDb(out errorMessage))
            {
                try
                {
                    int currentIndex = -1;
                    foreach (DataGridViewRow row in _contingentForm.DataGridViewGroups.Rows)
                    {
                        if (_obj.Id == Guid.Parse(row.Cells["GroupId"].Value.ToString()))
                            currentIndex = row.Index;
                    }
                    _contingentForm.DataGridViewGroups.Rows[currentIndex].Cells["GroupName"].Value = _obj.Name;

                    if (_obj.Language != null)
                    {
                        _contingentForm.DataGridViewGroups.Rows[currentIndex].Cells["GroupLanguage"] = FormManager.InitDGVCB(_enumRepo.GetEnum(Enums.LanguageEnumDefId).Items, _obj.Language, "FullName", "Id");
                    }
                    if (_obj.Profession != null)
                    {
                        _contingentForm.DataGridViewGroups.Rows[currentIndex].Cells["GroupProfession"] = FormManager.InitDGVCB(_docRepo.GetAll<Profession>().ToList(), _obj.Profession, "Name", "Id");
                    }
                    if (_obj.StudyPeriod != null)
                    {
                        _contingentForm.DataGridViewGroups.Rows[currentIndex].Cells["GroupStudyPeriod"] = FormManager.InitDGVCB(_enumRepo.GetEnum(Enums.StudyPeriodEnumDefId).Items, _obj.StudyPeriod, "FullName", "Id");
                    }
                    FormManager.ResetDropDownValues(_obj, _contingentForm.DataGridViewStudents);
                    //_contingentForm.ResetDropDownValues(_obj, "StudentGroup", _docRepo.GetAll<Group>().ToList(), "Name");
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
