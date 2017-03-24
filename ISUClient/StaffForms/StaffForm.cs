using Domain.Entities;
using Domain.Entities.Staff;
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

namespace UI.StaffForms
{
    public partial class StaffForm : Form
    {
        AddEmployeeForm _addEmployeeForm = null;
        AddPositionForm _addPositionForm = null;
        public StaffForm()
        {
            InitializeComponent();
            var _docRepo = new DocRepository();
            FormManager.LoadToDataGridView(DataGridViewPositions, _docRepo.GetAll<Position>());
            if (_docRepo.GetAll<Employee>() != null)
            {
                var Employees = _docRepo.GetAll<Employee>().ToList();
                Employees.ForEach(x => x.PersonObj = _docRepo.Get<Person>(x.Person));
                FormManager.LoadToDataGridView(DataGridViewEmployees, Employees);
            }
        }

        private void AddPositionButton_Click(object sender, EventArgs e)
        {
            _addPositionForm = new AddPositionForm(this);
            DialogResult dialog = _addPositionForm.ShowDialog();
        }

        private void DataGridViewEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = DataGridViewEmployees.Rows[e.RowIndex];
                var cell = row.Cells[e.ColumnIndex];
                var EmployeeId = (Guid)row.Cells["EmployeeId"].Value;
                if (cell.Equals(row.Cells["EditEmployeeLink"]))//Edit button clicked
                {
                    EditEmployee(EmployeeId);
                }
                else if (cell.Equals(row.Cells["DeleteEmployeeLink"]))//Delete button clicked
                {
                    DeleteEmployee(EmployeeId);
                }
                else if (cell.Equals(row.Cells["ShowEmployeeLink"]))//Show button clicked
                {
                    ShowEmployee(EmployeeId);
                }
            }
        }

        public void EditEmployee(Guid EmployeeId)
        {
            var _docRepo = new DocRepository();
            var obj = _docRepo.Get<Employee>(EmployeeId);
            obj.PersonObj = _docRepo.Get<Person>(obj.Person);
            var _editEmployeeForm = new EditEmployeeForm(this, obj);
            DialogResult dialog = _editEmployeeForm.ShowDialog();
        }
        private void DeleteEmployee(Guid EmployeeId)
        {
            var _docRepo = new DocRepository();
            var obj = _docRepo.Get<Employee>(EmployeeId);
            obj.PersonObj = _docRepo.Get<Person>(obj.Person);
            var confirmResult = MessageBox.Show("Вы уверены что хотите удалить сотрудника \"" + obj.PersonObj.LastName + "\"?",
                             "Подтверждение",
                             MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    _docRepo.Delete<Employee>(EmployeeId);
                    _docRepo.Delete<Person>(obj.Person);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Ошибка произошла при попытке удалить сотрудника \"" + obj.PersonObj.LastName + "\", текст ошибки: " + e.Message);
                }
            }
            if (_docRepo.GetAll<Employee>() != null)
            {
                var Employees = _docRepo.GetAll<Employee>().ToList();
                Employees.ForEach(x => x.PersonObj = _docRepo.Get<Person>(x.Person));
                FormManager.LoadToDataGridView(DataGridViewEmployees, Employees);
            }
            else
                FormManager.LoadToDataGridView(DataGridViewEmployees, _docRepo.GetAll<Employee>());
        }
        private void ShowEmployee(Guid EmployeeId)
        {
            var _docRepo = new DocRepository();
            var obj = _docRepo.Get<Employee>(EmployeeId);
            obj.PersonObj = _docRepo.Get<Person>(obj.Person);
            var viewStudentForm = new ViewEmployeeForm(this, obj);

            DialogResult dialog = viewStudentForm.ShowDialog();
        }

        private void AddEmployeeButton_Click(object sender, EventArgs e)
        {
            _addEmployeeForm = new AddEmployeeForm(this);
            DialogResult dialog = _addEmployeeForm.ShowDialog();
        }

        private void DataGridViewPositions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = DataGridViewPositions.Rows[e.RowIndex];
                var cell = row.Cells[e.ColumnIndex];
                var PositionId = (Guid)row.Cells["PositionId"].Value;
                if (cell.Equals(row.Cells["EditPositionLink"]))//Edit button clicked
                {
                    EditPosition(PositionId);
                }
                else if (cell.Equals(row.Cells["DeletePositionLink"]))//Delete button clicked
                {
                    DeletePosition(PositionId);
                }
                else if (cell.Equals(row.Cells["ShowPositionLink"]))//Show button clicked
                {
                    ShowPosition(PositionId);
                }
            }
        }
        public void EditPosition(Guid PositionId)
        {
            var _docRepo = new DocRepository();
            var obj = _docRepo.Get<Position>(PositionId);
            var _editPositionForm = new EditPositionForm(this, obj);
            DialogResult dialog = _editPositionForm.ShowDialog();
        }
        private void DeletePosition(Guid PositionId)
        {
            if (IsBoundWithAnyEmployee(PositionId))
            {
                MessageBox.Show("В данной должности числятся сотрудники!\n\nПожалуйста, перед удалением переведите всех сотрудников из этой должности в другую.");
                return;
            }
            var _docRepo = new DocRepository();

            var obj = _docRepo.Get<Position>(PositionId);

            var confirmResult = MessageBox.Show("Вы уверены что хотите удалить должность \"" + obj.Name + "\"?",
                             "Подтверждение",
                             MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    _docRepo.Delete<Position>(PositionId);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Ошибка произошла при попытке удалить должность \"" + obj.Name + "\", текст ошибки: " + e.Message);
                }
            }
            FormManager.LoadToDataGridView(DataGridViewPositions, _docRepo.GetAll<Position>());
        }
        private bool IsBoundWithAnyEmployee(Guid PositionId)
        {
            var _docRepo = new DocRepository();
            return _docRepo.GetAll<Employee>().Any(x => x.Position == PositionId);
        }

        private void ShowPosition(Guid PositionId)
        {
            var _docRepo = new DocRepository();
            var obj = _docRepo.Get<Position>(PositionId);
            var _viewPositionForm = new ViewPositionForm(this, obj);

            DialogResult dialog = _viewPositionForm.ShowDialog();
        }
    }
}
