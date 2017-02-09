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

        DocRepository _docRepo;
        EnumRepository _enumRepo;

        Guid _groupId;

        public AddStudentForm(ContingentForm contingentForm)
        {
            InitializeComponent();
            _contingentForm = contingentForm;

            _docRepo = new DocRepository();
            _enumRepo = new EnumRepository();
            LoadSources();
        }
        public AddStudentForm(ContingentForm contingentForm, ViewGroupForm viewGroupForm, Guid groupId)
        {
            _viewGroupForm = viewGroupForm;
            _groupId = groupId;

            InitializeComponent();
            _contingentForm = contingentForm;

            _docRepo = new DocRepository();
            _enumRepo = new EnumRepository();

            LoadSources();
        }

        private void LoadSources()
        {
            LoadGroups();
            LoadGenders();
            LoadNationalities();
            LoadPersonalDocumentTypes();
        }

        private void LoadGroups()
        {
            var groups = _docRepo.GetAll<Group>().ToList();
            GroupComboBox.DataSource = groups;
            GroupComboBox.DisplayMember = "Name";
            GroupComboBox.ValueMember = "Id";
            if (_viewGroupForm != null)
                GroupComboBox.SelectedValue = _groupId;
        }

        private void LoadGenders()
        {
            GenderComboBox.DataSource = _enumRepo.GetEnum(Enums.GenderEnumDefId).Items;
            GenderComboBox.DisplayMember = "FullName";
            GenderComboBox.ValueMember = "Id";
        }

        private void LoadNationalities()
        {
            NationalityComboBox.DataSource = _enumRepo.GetEnum(Enums.NationalityEnumDefId).Items;
            NationalityComboBox.DisplayMember = "FullName";
            NationalityComboBox.ValueMember = "Id";
        }

        private void LoadPersonalDocumentTypes()
        {
            PersonalDocumentTypeComboBox.DataSource = _enumRepo.GetEnum(Enums.PersonalDocumentTypeEnumDefId).Items;
            PersonalDocumentTypeComboBox.DisplayMember = "FullName";
            PersonalDocumentTypeComboBox.ValueMember = "Id";
        }


        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var persons = _docRepo.GetAll<Person>();
            Person person = persons != null ? persons.FirstOrDefault(x =>
                !x.IsDeleted &&
                x.LastName.Equals(LastNameTextBox.Text) &&
                x.FirstName.Equals(FirstNameTextBox.Text) &&
                x.MiddleName.Equals(MiddleNameTextBox.Text) &&
                x.BirthDate.Date.Equals(BirthDateDateTimePicker.Value.Date)
                ) : null;
            if (person == null)
            {
                person = new Person
                {
                    Id = Guid.NewGuid(),
                    IsNew = true,
                    PIN = PINTextBox.Text,
                    LastName = LastNameTextBox.Text,
                    FirstName = FirstNameTextBox.Text,
                    MiddleName = MiddleNameTextBox.Text,
                    BirthDate = BirthDateDateTimePicker.Value.Date,
                    Gender = GenderComboBox.SelectedItem != null ? (Guid?)GenderComboBox.SelectedValue : null,
                    Nationality = NationalityComboBox.SelectedItem != null ? (Guid?)NationalityComboBox.SelectedValue : null
                };
                _docRepo.Save(person);
            }
            var student = new Student
            {
                Id = Guid.NewGuid(),
                Person = person.Id,
                PersonObj = person,
                Group = Guid.Parse(GroupComboBox.SelectedValue.ToString()),
                IsNew = true,
                PersonalDocumentType = Guid.Parse(PersonalDocumentTypeComboBox.SelectedValue.ToString()),
                PassportSeries = PassportSeriesTextBox.Text,
                PassportNo = PassportNoTextBox.Text
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
