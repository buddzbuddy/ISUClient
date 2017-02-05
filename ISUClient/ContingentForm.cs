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

namespace UI
{
    public partial class ContingentForm : Form
    {

        AddStudentForm _addStudentForm = null;
        AddGroupForm _addGroupForm = null;
        EditGroupForm _editGroupForm = null;

        GroupRepository _groupRepo;
        ContingentRepository _contingentRepo;
        EnumRepository _enumRepo;
        ProfessionRepository _profRepo;
        StudentRepository _studentRepo;

        public ContingentForm()
        {
            InitializeComponent();
            _groupRepo = new GroupRepository();
            _contingentRepo = new ContingentRepository();
            _enumRepo = new EnumRepository();
            _profRepo = new ProfessionRepository();
            _studentRepo = new StudentRepository();
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
            _contingentRepo.ClipboardToExcel();
        }

        private void LoadGroupsFromDb()
        {
            try
            {
                var groups = _groupRepo.GetAll<Group>();
                if (groups == null) return;

                var studyPeriods = _enumRepo.GetEnum(Enums.StudyPeriodEnumDefId).Items;
                var languages = _enumRepo.GetEnum(Enums.LanguageEnumDefId).Items;
                var professions = _profRepo.GetAll<Profession>().ToList();

                foreach (var group in groups.Where(x => !x.IsDeleted))
                {
                    var newIndex = DataGridViewGroups.Rows.Add();
                    DataGridViewGroups.Rows[newIndex].Cells["GroupId"].Value = group.Id;
                    DataGridViewGroups.Rows[newIndex].Cells["GroupName"].Value = group.Name;

                    if (group.LanguageId != null)
                    {
                        DataGridViewGroups.Rows[newIndex].Cells["GroupLanguageId"] = InitDGVCB(languages, group.LanguageId);
                    }
                    if (group.ProfessionId != null)
                    {
                        DataGridViewGroups.Rows[newIndex].Cells["GroupProfessionId"] = InitDGVCB(professions, group.ProfessionId, "Name");
                    }
                    if (group.StudyPeriodId != null)
                    {
                        DataGridViewGroups.Rows[newIndex].Cells["GroupStudyPeriodId"] = InitDGVCB(studyPeriods, group.StudyPeriodId);
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
                var students = _studentRepo.GetAll<Student>();
                if (students == null) return;

                var groups = _groupRepo.GetAll<Group>();
                foreach (var student in students.Where(x => !x.IsDeleted))
                {
                    var newIndex = DataGridViewStudents.Rows.Add();
                    DataGridViewStudents.Rows[newIndex].Cells["StudentGroupId"].Value = student.Id;
                    DataGridViewStudents.Rows[newIndex].Cells["LastName"].Value = student.LastName;
                    DataGridViewStudents.Rows[newIndex].Cells["FirstName"].Value = student.FirstName;
                    DataGridViewStudents.Rows[newIndex].Cells["MiddleName"].Value = student.MiddleName;
                    DataGridViewStudents.Rows[newIndex].Cells["BirthDate"].Value = student.BirthDate;

                    if (student.GroupId != null)
                    {
                        DataGridViewStudents.Rows[newIndex].Cells["StudentGroupId"] = InitDGVCB(groups.ToList(), student.GroupId, "Name");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                }
            }
        }
        private void EditGroup(Guid groupId)
        {
            _groupRepo = new GroupRepository();
            var obj = _groupRepo.Get<Group>(groupId);
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

            var obj = _groupRepo.Get<Group>(groupId);
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

        private bool IsBoundWithAnyStudent(Guid groupId)
        {
            return _studentRepo.GetAll<Student>().Any(x => x.GroupId == groupId);
        }
    }
}
