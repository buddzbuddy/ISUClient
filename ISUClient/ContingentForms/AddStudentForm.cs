using Domain.Entities;
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

namespace UI.ContingentForms
{
    public partial class AddStudentForm : Form
    {
        ContingentForm _contingentForm;
        ViewGroupForm _viewGroupForm;

        Guid _groupId;

        public AddStudentForm(ContingentForm contingentForm)
        {
            InitializeComponent();
            _contingentForm = contingentForm;
            FormManager.InitializeComboBoxes(this, new Student { PersonObj = new Person() });
        }
        public AddStudentForm(ContingentForm contingentForm, ViewGroupForm viewGroupForm, Guid groupId)
        {
            _viewGroupForm = viewGroupForm;
            _groupId = groupId;

            InitializeComponent();
            _contingentForm = contingentForm;
            FormManager.InitializeComboBoxes(this, new Student { PersonObj = new Person() });
        }


        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var _docRepo = new DocRepository();
            var _enumRepo = new EnumRepository();

            var persons = _docRepo.GetAll<Person>();
            Person person = persons != null ? persons.FirstOrDefault(x =>
                !x.IsDeleted &&
                x.LastName.Equals(StudentPersonLastNameTextBox.Text) &&
                x.FirstName.Equals(StudentPersonFirstNameTextBox.Text) &&
                x.MiddleName.Equals(StudentPersonMiddleNameTextBox.Text) &&
                x.BirthDate.Date.Equals(StudentPersonBirthDateDateTimePicker.Value.Date)
                ) : null;
            if (person == null)
            {
                person = new Person
                {
                    Id = Guid.NewGuid(),
                    IsNew = true,
                    PIN = StudentPersonPINTextBox.Text,
                    LastName = StudentPersonLastNameTextBox.Text,
                    FirstName = StudentPersonFirstNameTextBox.Text,
                    MiddleName = StudentPersonMiddleNameTextBox.Text,
                    BirthDate = StudentPersonBirthDateDateTimePicker.Value.Date,
                    Gender = StudentPersonGenderComboBox.SelectedItem != null ? (Guid?)StudentPersonGenderComboBox.SelectedValue : null,
                    Nationality = StudentPersonNationalityComboBox.SelectedItem != null ? (Guid?)StudentPersonNationalityComboBox.SelectedValue : null
                };
                _docRepo.Save(person);
            }
            var student = new Student
            {
                Id = Guid.NewGuid(),
                Person = person.Id,
                PersonObj = person,
                Group = Guid.Parse(StudentGroupComboBox.SelectedValue.ToString()),
                IsNew = true,
                PersonalDocumentType = Guid.Parse(StudentPersonalDocumentTypeComboBox.SelectedValue.ToString()),
                PassportSeries = StudentPassportSeriesTextBox.Text,
                PassportNo = StudentPassportNoTextBox.Text
            };
            string errorMessage;
            if (SaveToLocalDb(student, out errorMessage))
            {
                try
                {
                    _docRepo = new DocRepository();
                    if(_docRepo.GetAll<Student>() == null) return;
                    var students = _docRepo.GetAll<Student>().ToList();
                    students.ForEach(x => x.PersonObj = _docRepo.Get<Person>(x.Person));
                    FormManager.LoadToDataGridView(_contingentForm.DataGridViewStudents, students);
                    if (_viewGroupForm != null)
                    {
                        FormManager.LoadToDataGridView(_viewGroupForm.DataGridViewStudents, students.Where(x => x.Group == student.Group));
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
        private bool SaveToLocalDb(Student obj, out string errorMessage)
        {
            var _docRepo = new DocRepository();
            var _enumRepo = new EnumRepository();
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
