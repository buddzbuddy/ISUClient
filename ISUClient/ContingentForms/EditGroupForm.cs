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

        GroupRepository _groupRepo;
        EnumRepository _enumRepo;
        ProfessionRepository _profRepo;
        Group _obj;

        public EditGroupForm(ContingentForm contingentForm, Group obj)
        {
            InitializeComponent();

            _contingentForm = contingentForm;
            _groupRepo = new GroupRepository();
            _enumRepo = new EnumRepository();
            _profRepo = new ProfessionRepository();
            InitSources(obj.LanguageId, obj.StudyPeriodId, obj.ProfessionId);
            _obj = obj;

            NameTextBox.Text = obj.Name;
        }

        private void InitSources(Guid? languageId, Guid? studyPeriodId, Guid? professionId)
        {
            InitLanguages(languageId);
            InitStudyPeriods(studyPeriodId);
            InitProfessions(professionId);
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
            ProfessionComboBox.DataSource = _profRepo.GetAll<Profession>().ToList();
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
            _obj.LanguageId = Guid.Parse(LanguageComboBox.SelectedValue.ToString());
            _obj.StudyPeriodId = Guid.Parse(StudyPeriodComboBox.SelectedValue.ToString());
            _obj.ProfessionId = Guid.Parse(ProfessionComboBox.SelectedValue.ToString());
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

                    if (_obj.LanguageId != null)
                    {
                        _contingentForm.DataGridViewGroups.Rows[currentIndex].Cells["GroupLanguageId"] = _contingentForm.InitDGVCB(_enumRepo.GetEnum(Enums.LanguageEnumDefId).Items, _obj.LanguageId);
                    }
                    if (_obj.ProfessionId != null)
                    {
                        _contingentForm.DataGridViewGroups.Rows[currentIndex].Cells["GroupProfessionId"] = _contingentForm.InitDGVCB(_profRepo.GetAll<Profession>().ToList(), _obj.ProfessionId, "Name");
                    }
                    if (_obj.StudyPeriodId != null)
                    {
                        _contingentForm.DataGridViewGroups.Rows[currentIndex].Cells["GroupStudyPeriodId"] = _contingentForm.InitDGVCB(_enumRepo.GetEnum(Enums.StudyPeriodEnumDefId).Items, _obj.StudyPeriodId);
                    }
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
                _groupRepo.Save(_obj, true);
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
