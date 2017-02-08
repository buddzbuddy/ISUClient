using UI.ContingentForms;
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
using Logic.Repositories;
using Domain.StaticReferences;
using Domain.Entities.Contingent;
using Logic;
using Domain.Entities;

namespace UI
{
    public partial class ContingentForm : Form
    {

        AddStudentForm _addStudentForm = null;
        AddGroupForm _addGroupForm = null;
        EditGroupForm _editGroupForm = null;

        EnumRepository _enumRepo;
        DocRepository _docRepo;
        public ContingentForm()
        {
            InitializeComponent();
            _enumRepo = new EnumRepository();
            _docRepo = new DocRepository();
            LoadGroupsFromDb();
            LoadStudentsFromDb(DataGridViewStudents, _docRepo.GetAll<Student>());
        }

        private void addStudentButton_Click(object sender, EventArgs e)
        {
            _addStudentForm = new AddStudentForm(this);
            DialogResult dialog = _addStudentForm.ShowDialog();
        }

        private void AddGroupButton_Click(object sender, EventArgs e)
        {
            _addGroupForm = new AddGroupForm(this);
            DialogResult dialog = _addGroupForm.ShowDialog();
        }
        private void copyAlltoClipboard()
        {
            DataGridViewGroups.SelectAll();
            DataObject dataObj = DataGridViewGroups.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void ToExcelGroupsButton_Click(object sender, EventArgs e)
        {
            copyAlltoClipboard();
            _docRepo.ClipboardToExcel();
        }

        private void LoadGroupsFromDb()
        {
            try
            {
                _docRepo = new DocRepository();
                var groups = _docRepo.GetAll<Group>();
                if (groups == null) return;

                var studyPeriods = _enumRepo.GetEnum(Enums.StudyPeriodEnumDefId).Items;
                var languages = _enumRepo.GetEnum(Enums.LanguageEnumDefId).Items;
                var professions = _docRepo.GetAll<Profession>().ToList();

                foreach (var group in groups.Where(x => !x.IsDeleted))
                {
                    var newIndex = DataGridViewGroups.Rows.Add();
                    DataGridViewGroups.Rows[newIndex].Cells["GroupId"].Value = group.Id;
                    DataGridViewGroups.Rows[newIndex].Cells["GroupName"].Value = group.Name;

                    if (group.Language != null)
                    {
                        DataGridViewGroups.Rows[newIndex].Cells["GroupLanguage"] = FormManager.InitDGVCB(languages, group.Language);
                    }
                    if (group.Profession != null)
                    {
                        DataGridViewGroups.Rows[newIndex].Cells["GroupProfession"] = FormManager.InitDGVCB(professions, group.Profession, "Name");
                    }
                    if (group.StudyPeriod != null)
                    {
                        DataGridViewGroups.Rows[newIndex].Cells["GroupStudyPeriod"] = FormManager.InitDGVCB(studyPeriods, group.StudyPeriod);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadStudentsFromDb(DataGridView dataGridView, IEnumerable<Student> students)
        {
            try
            {
                var groups = _docRepo.GetAll<Group>();
                var genders = _enumRepo.GetEnum(Enums.GenderEnumDefId).Items;
                var nationalities = _enumRepo.GetEnum(Enums.NationalityEnumDefId).Items;
                var personalDocumentTypes = _enumRepo.GetEnum(Enums.PersonalDocumentTypeEnumDefId).Items;

                foreach (var student in students.Where(x => !x.IsDeleted))
                {
                    student.PersonObj = _docRepo.Get<Person>(student.Person);
                    if (student.PersonObj == null) continue;
                    var newIndex = dataGridView.Rows.Add();
                    dataGridView.Rows[newIndex].Cells["StudentId"].Value = student.Id;
                    dataGridView.Rows[newIndex].Cells["PIN"].Value = student.PersonObj.PIN;
                    dataGridView.Rows[newIndex].Cells["LastName"].Value = student.PersonObj.LastName;
                    dataGridView.Rows[newIndex].Cells["FirstName"].Value = student.PersonObj.FirstName;
                    dataGridView.Rows[newIndex].Cells["MiddleName"].Value = student.PersonObj.MiddleName;
                    dataGridView.Rows[newIndex].Cells["BirthDate"].Value = student.PersonObj.BirthDate;

                    dataGridView.Rows[newIndex].Cells["StudentPassportSeries"].Value = student.PassportSeries;
                    dataGridView.Rows[newIndex].Cells["StudentPassportNo"].Value = student.PassportNo;

                    if (student.Group != null && dataGridView.Columns["StudentGroup"] != null)
                    {
                        dataGridView.Rows[newIndex].Cells["StudentGroup"] = FormManager.InitDGVCB(groups.ToList(), student.Group, "Name");
                    }

                    if (student.PersonObj.Gender != null && dataGridView.Columns["StudentGender"] != null)
                    {
                        dataGridView.Rows[newIndex].Cells["StudentGender"] = FormManager.InitDGVCB(genders.ToList(), student.PersonObj.Gender);
                    }

                    if (student.PersonObj.Nationality != null && dataGridView.Columns["StudentNationality"] != null)
                    {
                        dataGridView.Rows[newIndex].Cells["StudentNationality"] = FormManager.InitDGVCB(nationalities.ToList(), student.PersonObj.Nationality);
                    }

                    if (student.PersonalDocumentType != null && dataGridView.Columns["StudentPersonalDocumentType"] != null)
                    {
                        dataGridView.Rows[newIndex].Cells["StudentPersonalDocumentType"] = FormManager.InitDGVCB(personalDocumentTypes.ToList(), student.PersonalDocumentType);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ResetDropDownValues<T>(T obj, string columnName, object dataSource, string displayMember = "FullName")
        {
            var objId = (Guid?)typeof(T).GetProperty("Id").GetValue(obj);
            if(!objId.HasValue) return;
            foreach (DataGridViewRow row in DataGridViewStudents.Rows)
            {
                if (Guid.Parse(row.Cells[columnName].Value.ToString()) == objId)
                {
                    row.Cells[columnName] = FormManager.InitDGVCB(dataSource, objId, displayMember);
                }
            }
        }

        private void DataGridViewGroups_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                var row = DataGridViewGroups.Rows[e.RowIndex];
                var cell = row.Cells[e.ColumnIndex];
                var groupId = (Guid)row.Cells["GroupId"].Value;
                if (cell.Equals(row.Cells["EditGroupLink"]))//Edit button clicked
                {
                    EditGroup(groupId);
                }
                else if (cell.Equals(row.Cells["DeleteGroupLink"]))//Delete button clicked
                {
                    DeleteGroup(groupId);
                }
                else if (cell.Equals(row.Cells["ShowGroupLink"]))//Show button clicked
                {
                    ShowGroup(groupId);
                }
            }
        }
        private void EditGroup(Guid groupId)
        {
            _docRepo = new DocRepository();
            var obj = _docRepo.Get<Group>(groupId);
            _editGroupForm = new EditGroupForm(this, obj);
            DialogResult dialog = _editGroupForm.ShowDialog();
        }
        private void DeleteGroup(Guid groupId)
        {
            if (IsBoundWithAnyStudent(groupId))
            {
                MessageBox.Show("В данной группе числятся учащиеся!\n\nПожалуйста, перед удалением переведите всех учащихся из этой группы в другую.");
                return;
            }

            var obj = _docRepo.Get<Group>(groupId);
            var confirmResult = MessageBox.Show("Вы уверены что хотите удалить эту группу \"" + obj.Name + "\"",
                             "Подтверждение",
                             MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                // If 'Yes', do something here.

            }
            else
            {
                // If 'No', do something here.
            }
        }
        private void ShowGroup(Guid groupId)
        {
            _docRepo = new DocRepository();
            var obj = _docRepo.Get<Group>(groupId);
            var viewGroupForm = new ViewGroupForm(this, obj);

            DialogResult dialog = viewGroupForm.ShowDialog();
        }

        private bool IsBoundWithAnyStudent(Guid groupId)
        {
            return _docRepo.GetAll<Student>().Any(x => x.Group == groupId);
        }
    }
}