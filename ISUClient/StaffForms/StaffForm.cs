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
                var students = _docRepo.GetAll<Employee>().ToList();
                students.ForEach(x => x.PersonObj = _docRepo.Get<Person>(x.Person));
                FormManager.LoadToDataGridView(DataGridViewEmployees, students);
            }
        }

        private void AddPositionButton_Click(object sender, EventArgs e)
        {
            _addPositionForm = new AddPositionForm(this);
            DialogResult dialog = _addPositionForm.ShowDialog();
        }

        private void AddEmployeeButton_Click(object sender, EventArgs e)
        {
            _addEmployeeForm = new AddEmployeeForm(this);
            DialogResult dialog = _addEmployeeForm.ShowDialog();
        }
    }
}
