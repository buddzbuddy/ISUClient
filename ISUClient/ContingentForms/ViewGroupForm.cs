using Domain.Entities;
using Domain.Entities.Contingent;
using Logic.Repositories;
using System;
using System.Linq;
using System.Windows.Forms;

namespace UI.ContingentForms
{
    public partial class ViewGroupForm : Form
    {
        ContingentForm _contingentForm = null;
        AddStudentForm _addStudentForm = null;
        Group _obj;
        public ViewGroupForm(ContingentForm contingentForm, Group obj)
        {
            InitializeComponent();

            _contingentForm = contingentForm;
            _obj = obj;

            NameTextBox.Text = obj.Name;
            FormManager.InitializeComboBoxes(this, obj);

            var _docRepo = new DocRepository();

            if (_docRepo.GetAll<Student>() == null) return;
            var Students = _docRepo.GetAll<Student>().ToList();
            Students.ForEach(x => x.PersonObj = _docRepo.Get<Person>(x.Person));

            FormManager.LoadToDataGridView(DataGridViewStudents, Students.Where(x => !x.IsDeleted && x.Group == _obj.Id));
        }

        private void AddStudentButton_Click(object sender, EventArgs e)
        {
            AddStudent();
        }

        private void AddStudent()
        {
            _addStudentForm = new AddStudentForm(_contingentForm, this, _obj.Id);
            DialogResult dialog = _addStudentForm.ShowDialog();
        }
    }
}
