using Domain.Entities;
using Domain.Entities.Contingent;
using Logic.Repositories;
using System;
using System.Linq;
using System.Windows.Forms;
using UI.ContingentForms;

namespace UI
{
    public partial class ContingentForm : Form
    {

        AddStudentForm _addStudentForm = null;
        AddGroupForm _addGroupForm = null;
        EditGroupForm _editGroupForm = null;
        EditStudentForm _editStudentForm = null;
        public ContingentForm()
        {
            InitializeComponent();
            var _docRepo = new DocRepository();
            FormManager.LoadToDataGridView(DataGridViewGroups, _docRepo.GetAll<Group>());
            if(_docRepo.GetAll<Student>() != null)
            {
                var students = _docRepo.GetAll<Student>().ToList();
                students.ForEach(x => x.PersonObj = _docRepo.Get<Person>(x.Person));
                FormManager.LoadToDataGridView(DataGridViewStudents, students);
            }
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
        private void copyAlltoClipboard(DataGridView dataGridView)
        {
            dataGridView.SelectAll();
            DataObject dataObj = dataGridView.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void ToExcelGroupsButton_Click(object sender, EventArgs e)
        {
            var _docRepo = new DocRepository();
            copyAlltoClipboard(DataGridViewGroups);
            _docRepo.ClipboardToExcel();
        }

        private void ToExcelStudentsButton_Click(object sender, EventArgs e)
        {
            var _docRepo = new DocRepository();
            copyAlltoClipboard(DataGridViewStudents);
            _docRepo.ClipboardToExcel();
        }

        private void EditGroup(Guid groupId)
        {
            var _docRepo = new DocRepository();
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
            var _docRepo = new DocRepository();
            var obj = _docRepo.Get<Group>(groupId);
            var confirmResult = MessageBox.Show("Вы уверены что хотите удалить эту группу \"" + obj.Name + "\"",
                             "Подтверждение",
                             MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    _docRepo.Delete<Group>(groupId);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Ошибка произошла при попытке удалить группу \"" + obj.Name + "\", текст ошибки: " + e.Message);
                }
            }
            FormManager.LoadToDataGridView(DataGridViewGroups, _docRepo.GetAll<Group>());
        }
        private void ShowGroup(Guid groupId)
        {
            var _docRepo = new DocRepository();
            var obj = _docRepo.Get<Group>(groupId);
            var viewGroupForm = new ViewGroupForm(this, obj);

            DialogResult dialog = viewGroupForm.ShowDialog();
        }

        private bool IsBoundWithAnyStudent(Guid groupId)
        {
            var _docRepo = new DocRepository();
            return _docRepo.GetAll<Student>().Any(x => x.Group == groupId);
        }
        private void DataGridViewGroups_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
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

        private void DataGridViewStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = DataGridViewStudents.Rows[e.RowIndex];
                var cell = row.Cells[e.ColumnIndex];
                var studentId = (Guid)row.Cells["StudentId"].Value;
                if (cell.Equals(row.Cells["EditStudentLink"]))//Edit button clicked
                {
                    EditStudent(studentId);
                }
                else if (cell.Equals(row.Cells["DeleteStudentLink"]))//Delete button clicked
                {
                    DeleteStudent(studentId);
                }
                else if (cell.Equals(row.Cells["ShowStudentLink"]))//Show button clicked
                {
                    ShowStudent(studentId);
                }
            }
        }

        public void EditStudent(Guid studentId)
        {
            var _docRepo = new DocRepository();
            var obj = _docRepo.Get<Student>(studentId);
            obj.PersonObj = _docRepo.Get<Person>(obj.Person);
            _editStudentForm = new EditStudentForm(this, obj);
            DialogResult dialog = _editStudentForm.ShowDialog();
        }
        private void DeleteStudent(Guid studentId)
        {
            var _docRepo = new DocRepository();
            var obj = _docRepo.Get<Student>(studentId);
            obj.PersonObj = _docRepo.Get<Person>(obj.Person);
            var confirmResult = MessageBox.Show("Вы уверены что хотите удалить студента \"" + obj.PersonObj.LastName + "\"?",
                             "Подтверждение",
                             MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    _docRepo.Delete<Student>(studentId);
                    _docRepo.Delete<Person>(obj.Person);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Ошибка произошла при попытке удалить студента \"" + obj.PersonObj.LastName + "\", текст ошибки: " + e.Message);
                }
            }
            if (_docRepo.GetAll<Student>() != null)
            {
                var students = _docRepo.GetAll<Student>().ToList();
                students.ForEach(x => x.PersonObj = _docRepo.Get<Person>(x.Person));
                FormManager.LoadToDataGridView(DataGridViewStudents, students);
            }
            else
                FormManager.LoadToDataGridView(DataGridViewStudents, _docRepo.GetAll<Student>());
        }
        private void ShowStudent(Guid studentId)
        {
            var _docRepo = new DocRepository();
            var obj = _docRepo.Get<Student>(studentId);
            obj.PersonObj = _docRepo.Get<Person>(obj.Person);
            var viewStudentForm = new ViewStudentForm(this, obj);

            DialogResult dialog = viewStudentForm.ShowDialog();
        }
    }
}