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
            LoadStudentsFromDb();
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
                        DataGridViewGroups.Rows[newIndex].Cells["GroupLanguage"] = InitDGVCB(languages, group.Language);
                    }
                    if (group.Profession != null)
                    {
                        DataGridViewGroups.Rows[newIndex].Cells["GroupProfession"] = InitDGVCB(professions, group.Profession, "Name");
                    }
                    if (group.StudyPeriod != null)
                    {
                        DataGridViewGroups.Rows[newIndex].Cells["GroupStudyPeriod"] = InitDGVCB(studyPeriods, group.StudyPeriod);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadStudentsFromDb()
        {
            try
            {
                _docRepo = new DocRepository();
                var students = _docRepo.GetAll<Student>();
                if (students == null) return;
                var groups = _docRepo.GetAll<Group>();
                var genders = _enumRepo.GetEnum(Enums.GenderEnumDefId).Items;
                var nationalities = _enumRepo.GetEnum(Enums.NationalityEnumDefId).Items;

                foreach (var student in students.Where(x => !x.IsDeleted))
                {
                    student.Person = _docRepo.Get<Person>(student.PersonId);
                    if (student.Person == null) continue;
                    var newIndex = DataGridViewStudents.Rows.Add();
                    DataGridViewStudents.Rows[newIndex].Cells["StudentId"].Value = student.Id;
                    DataGridViewStudents.Rows[newIndex].Cells["PIN"].Value = student.Person.PIN;
                    DataGridViewStudents.Rows[newIndex].Cells["LastName"].Value = student.Person.LastName;
                    DataGridViewStudents.Rows[newIndex].Cells["FirstName"].Value = student.Person.FirstName;
                    DataGridViewStudents.Rows[newIndex].Cells["MiddleName"].Value = student.Person.MiddleName;
                    DataGridViewStudents.Rows[newIndex].Cells["BirthDate"].Value = student.Person.BirthDate;

                    if (student.Group != null)
                    {
                        DataGridViewStudents.Rows[newIndex].Cells["StudentGroup"] = InitDGVCB(groups.ToList(), student.Group, "Name");
                    }

                    if (student.Person.Gender != null)
                    {
                        DataGridViewStudents.Rows[newIndex].Cells["StudentGender"] = InitDGVCB(genders.ToList(), student.Person.Gender);
                    }

                    if (student.Person.Nationality != null)
                    {
                        DataGridViewStudents.Rows[newIndex].Cells["StudentNationality"] = InitDGVCB(nationalities.ToList(), student.Person.Nationality);
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
                    row.Cells[columnName] = InitDGVCB(dataSource, objId, displayMember);
                }
            }
        }


        public DataGridViewComboBoxCell InitDGVCB(object dataSource, Guid? value, string displayMember = "FullName")
        {
            var CBCell = new DataGridViewComboBoxCell();
            CBCell.DataSource = dataSource;
            CBCell.DisplayMember = displayMember;
            CBCell.ValueMember = "Id";
            CBCell.Value = value;
            return CBCell;
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