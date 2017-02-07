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
    public partial class AddGroupForm : Form
    {
        ContingentForm _contingentForm = null;

        DocRepository _docRepo;
        EnumRepository _enumRepo;

        public AddGroupForm(ContingentForm contingentForm)
        {
            InitializeComponent();

            _contingentForm = contingentForm;
            _docRepo = new DocRepository();
            _enumRepo = new EnumRepository();
            LoadSources();
        }

        private void LoadSources()
        {
            LoadLanguages();
            LoadStudyPeriods();
            LoadProfessions();
        }

        private void LoadLanguages()
        {
            LanguageComboBox.DataSource = _enumRepo.GetEnum(Enums.LanguageEnumDefId).Items;
            LanguageComboBox.DisplayMember = "FullName";
            LanguageComboBox.ValueMember = "Id";
        }
        private void LoadStudyPeriods()
        {
            StudyPeriodComboBox.DataSource = _enumRepo.GetEnum(Enums.StudyPeriodEnumDefId).Items;
            StudyPeriodComboBox.DisplayMember = "FullName";
            StudyPeriodComboBox.ValueMember = "Id";
        }

        private void LoadProfessions()
        {
            ProfessionComboBox.DataSource = _docRepo.GetAll<Profession>().ToList();
            ProfessionComboBox.DisplayMember = "Name";
            ProfessionComboBox.ValueMember = "Id";
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
                Name = NameTextBox.Text,
                Language = LanguageComboBox.SelectedItem != null ? (Guid?)LanguageComboBox.SelectedValue : null,
                Profession = ProfessionComboBox.SelectedItem != null ? (Guid?)ProfessionComboBox.SelectedValue : null,
                StudyPeriod = StudyPeriodComboBox.SelectedItem != null ? (Guid?)StudyPeriodComboBox.SelectedValue : null,
                IsNew = true
            };
            string errorMessage;
            if (SaveToLocalDb(group, out errorMessage))
            {
                try
                {
                    var newIndex = _contingentForm.DataGridViewGroups.Rows.Add();
                    _contingentForm.DataGridViewGroups.Rows[newIndex].Cells["GroupName"].Value = group.Name;

                    if (group.Language != null)
                    {
                        _contingentForm.DataGridViewGroups.Rows[newIndex].Cells["GroupLanguage"] = _contingentForm.InitDGVCB(_enumRepo.GetEnum(Enums.LanguageEnumDefId).Items, group.Language);
                    }
                    if (group.Profession != null)
                    {
                        _contingentForm.DataGridViewGroups.Rows[newIndex].Cells["GroupProfessionId"] = _contingentForm.InitDGVCB(_docRepo.GetAll<Profession>().ToList(), group.Profession, "Name");
                    }
                    if (group.StudyPeriod != null)
                    {
                        _contingentForm.DataGridViewGroups.Rows[newIndex].Cells["GroupStudyPeriodId"] = _contingentForm.InitDGVCB(_enumRepo.GetEnum(Enums.StudyPeriodEnumDefId).Items, group.StudyPeriod);

                        //_contingentForm.DataGridViewGroups.Rows[newIndex].Cells["GroupStudyPeriodId"].Value = _enumRepo.GetEnumItem(group.StudyPeriodId.Value).FullName;
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

        private bool SaveToLocalDb(Group obj, out string errorMessage)
        {
            errorMessage = "";

            //TODO: Write to progress bar

            //Save to xml-db
            try
            {
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
