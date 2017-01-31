using Domain.Entities.Contingent;
using Domain.StaticReferences;
using Logic.Implementations;
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

        GroupRepository _groupRepo;
        EnumRepository _enumRepo;

        public AddGroupForm(ContingentForm contingentForm)
        {
            InitializeComponent();

            _contingentForm = contingentForm;
            _groupRepo = new GroupRepository();
            _enumRepo = new EnumRepository();

            LoadSources();
        }

        private void LoadSources()
        {
            LoadLanguages();
            LoadStudyPeriods();
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

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var group = new Group
            {
                Id = Guid.NewGuid(),//TODO: Refactor to stable logic
                Name = NameTextBox.Text,
                LanguageId = LanguageComboBox.SelectedItem != null ? (Guid?)LanguageComboBox.SelectedValue : null,
                ProfessionId = ProfessionComboBox.SelectedItem != null ? (Guid?)ProfessionComboBox.SelectedValue : null,
                StudyPeriodId = StudyPeriodComboBox.SelectedItem != null ? (Guid?)StudyPeriodComboBox.SelectedValue : null
            };
            string errorMessage;
            if (SaveToLocalDb(group, out errorMessage))
            {
                try
                {
                    var newIndex = _contingentForm.DataGridViewGroups.Rows.Add();
                    _contingentForm.DataGridViewGroups.Rows[newIndex].Cells["GroupName"].Value = group.Name;

                    if (group.LanguageId != null)
                    {
                        _contingentForm.DataGridViewGroups.Rows[newIndex].Cells["Language"].Value = _enumRepo.GetEnumItem(group.LanguageId.Value).FullName;
                    }
                    if (group.ProfessionId != null)
                    {
                        _contingentForm.DataGridViewGroups.Rows[newIndex].Cells["Profession"].Value = group.ProfessionId;
                    }
                    if (group.StudyPeriodId != null)
                    {
                        _contingentForm.DataGridViewGroups.Rows[newIndex].Cells["StudyPeriod"].Value = _enumRepo.GetEnumItem(group.StudyPeriodId.Value).FullName;
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
                _groupRepo.Save(obj);
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
